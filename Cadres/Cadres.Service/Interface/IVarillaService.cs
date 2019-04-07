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

        void Actualizar(VarillaDTO dto);

        IList<VarillaDTO> GetAllDTO();

        VarillaDTO GetDTOById(long id);

        IList<VarillaDTO> GetByFilter(VarillaFilter filter);
    }
}
