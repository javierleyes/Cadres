using DAO.Interfaces;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICompradorService : IGenericService<ICompradorDAO, Comprador, int>
    {
        CompradorDTO GetDTOById(int id);

        IList<CompradorDTO> GetDTOAll();

        IList<CompradorDTO> GetByFilter(FilterComprador filter);
    }
}
