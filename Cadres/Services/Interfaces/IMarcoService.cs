using DAOs.Interfaces;
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

        decimal CalcularPrecio(MarcoDTO marco);
    }
}
