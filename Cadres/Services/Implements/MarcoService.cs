using Base;
using DAOs.Implements;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class MarcoService : GenericService<MarcoDAO, Marco, int>, IMarcoService
    {
        public MarcoService(MarcoDAO entityDAO) : base(entityDAO)
        {
        }

        public decimal CalcularPrecio(MarcoDTO marco)
        {
            // Regla de negocio
            // ancho y largo [cm]
            // conversion a mts
            // ( perimetro [cm] + 8 x ancho de varilla [cm] ) x precio varilla [$/m2]

            decimal perimetroCuadro = CalcularPerimetro(marco);

            decimal angulosVarilla = CalculorAngulosVarilla(marco);

            decimal metrosNecesarios = (perimetroCuadro + angulosVarilla) / 100;

            return (metrosNecesarios * marco.Varilla.Precio);
        }

        public IList<MarcoDTO> GetByFilter(FilterMarco filter)
        {
            return this.EntityDAO.GetByFilter(filter).Select(x => EntityConverter.ConvertMarcoToMarcoDTO(x)).ToList();
        }

        private static decimal CalculorAngulosVarilla(MarcoDTO marco)
        {
            return (8 * marco.Varilla.Ancho);
        }

        private static decimal CalcularPerimetro(MarcoDTO marco)
        {
            return ((marco.Ancho * 2) + (marco.Largo * 2));
        }

        public void SetearEstadoListo(MarcoDTO marco)
        {
            marco.Estado = Estados.EstadoMarco.Listo;
        }

        public void SetearEstadoSinMateriales(MarcoDTO marco)
        {
            marco.Estado = Estados.EstadoMarco.Falta_Insumo;
        }
    }
}
