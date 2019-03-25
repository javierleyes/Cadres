using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Filter;
using System.Collections.Generic;

namespace Cadres.Service.Interface
{
    public interface IVarillaService : IGenericService<IVarillaRepository, Varilla, long>
    {
        VarillaDTO CrearNueva(VarillaDTO varillaDTO);

        void SetCantidad(long id, int cantidad);

        void SetPrecio(long id, decimal precio);

        void DarDeBaja(long id);

        IList<VarillaDTO> GetAllDTO();

        VarillaDTO GetDTOById(long id);

        IList<VarillaDTO> GetByFilter(VarillaFilter filter);
    }
}
