using DAL.Interfaces.Operaciones;
using Entidades.Operaciones;
using Filters.Operaciones;
using Services.DTO.Operaciones;
using Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Operaciones
{
    public interface ICompradorService : IBaseService<ICompradorRepository, Comprador>
    {
        CompradorDTO GetDTOById(int id);

        IList<CompradorDTO> GetDTOAll();

        IList<CompradorDTO> GetByFilter(CompradorFilter filter);
    }
}
