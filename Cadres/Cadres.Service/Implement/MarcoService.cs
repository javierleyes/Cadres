using Cadres.Assembler.Interface;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Interface;
using System.Linq;

namespace Cadres.Service.Implement
{
    public class MarcoService : GenericService<IMarcoRepository, Marco, long>, IMarcoService
    {
        public IVarillaRepository VarillaRepository { get; set; }
        public IMarcoAssembler MarcoAssembler { get; set; }

        public MarcoService(IMarcoRepository entityRepository, IVarillaRepository varillaRepository, IMarcoAssembler marcoAssembler) : base(entityRepository)
        {
            this.VarillaRepository = varillaRepository;
            this.MarcoAssembler = marcoAssembler;
        }

        public MarcoDTO CrearMarco(MarcoDTO marcoDTO)
        {
            Marco marco = this.MarcoAssembler.FromTo(marcoDTO);

            marco.Numero = GetNumeroMarco();
            marco.Estado = Estados.EstadoMarco.Pendiente;
            marco.Precio = CalcularPrecio(marcoDTO);
            marco.Varilla = VarillaRepository.GetById(marcoDTO.VarillaId);

            this.EntityRepository.Save(marco);

            return this.MarcoAssembler.ToDTO(marco);
        }

        public decimal CalcularPrecio(MarcoDTO marco)
        {
            Varilla varilla = VarillaRepository.GetById(marco.VarillaId);

            // Regla de negocio
            // ancho y largo [cm]
            // conversion a mts
            // ( perimetro [cm] + 8 x ancho de varilla [cm] ) x precio varilla [$/m2]

            decimal perimetroCuadro = CalcularPerimetro(marco);

            decimal angulosVarilla = 8 * varilla.Ancho;

            decimal metrosNecesarios = (perimetroCuadro + angulosVarilla) / 100;

            return (metrosNecesarios * varilla.Precio);
        }

        public void SetEstadoListo(int numero)
        {
            ModificarEstado(numero, Estados.EstadoMarco.Listo);
        }

        public void SetEstadoSinMateriales(int numero)
        {
            ModificarEstado(numero, Estados.EstadoMarco.SinMateriales);
        }

        public MarcoDTO GetByNumero(int numero)
        {
            Marco marco = this.GetEntidadByNumero(numero);

            return this.MarcoAssembler.ToDTO(marco);
        }

        private void ModificarEstado(int numero, Estados.EstadoMarco estado)
        {
            Marco marco = this.GetEntidadByNumero(numero);

            marco.Estado = estado;

            EntityRepository.Update(marco);
        }

        private static decimal CalcularPerimetro(MarcoDTO marco)
        {
            return ((marco.Ancho * 2) + (marco.Largo * 2));
        }

        private int GetNumeroMarco()
        {
            return this.EntityRepository.GetAll().Count() + 1;
        }

        private Marco GetEntidadByNumero(int numero)
        {
            return this.EntityRepository.GetAll().Where(x => x.Numero == numero).FirstOrDefault();
        }
    }
}
