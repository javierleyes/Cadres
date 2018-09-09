using DAO.Interfaces;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IMarcoService : IGenericService<IMarcoDAO, Marco, int>
    {
        IList<MarcoDTO> GetByFilter(FilterMarco filter);

        void SetearEstadoListo(MarcoDTO marco);

        void SetearEstadoSinMateriales(MarcoDTO marco);

        decimal CalcularPrecio(MarcoDTO marco);
    }
}
