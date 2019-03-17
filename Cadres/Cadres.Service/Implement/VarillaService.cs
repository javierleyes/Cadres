using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Interface;

namespace Cadres.Service.Implement
{
    public class VarillaService : GenericService<IVarillaRepository, Varilla, long>, IVarillaService
    {
        public VarillaService(IVarillaRepository entityRepository) : base(entityRepository) { }

        public VarillaDTO CrearNueva(VarillaDTO varillaDTO)
        {
            Varilla varilla = this.FromTo(varillaDTO);

            varillaDTO.Id = EntityRepository.Save(varilla).Id;

            return varillaDTO;
        }

        public void DarDeBaja(long id)
        {
            Varilla varilla = EntityRepository.GetById(id);

            varilla.Disponible = false;

            EntityRepository.Update(varilla);
        }

        public void SetCantidad(long id, int cantidad)
        {
            Varilla varilla = EntityRepository.GetById(id);

            varilla.Cantidad = cantidad;

            EntityRepository.Update(varilla);
        }

        public void SetPrecio(long id, decimal precio)
        {
            Varilla varilla = EntityRepository.GetById(id);

            varilla.Precio = precio;

            EntityRepository.Update(varilla);
        }

        private Varilla FromTo(VarillaDTO dto)
        {
            return new Varilla()
            {
                Ancho = dto.Ancho,
                Cantidad = dto.Cantidad,
                Disponible = dto.Disponible,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
            };
        }
    }
}
