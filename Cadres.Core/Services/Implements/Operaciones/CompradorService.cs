using DAL.Implements.Operaciones;
using Entidades.Operaciones;
using Filters.Operaciones;
using Services.Assemblers;
using Services.DTO.Operaciones;
using Services.Implements.Base;
using Services.Interfaces.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implements.Operaciones
{
    public class CompradorService : BaseService<CompradorRepository, Comprador, int>, ICompradorService
    {
        protected CompradorAssembler CompradorAssembler { get; set; }

        public CompradorService(CompradorRepository entityRepository) : base(entityRepository)
        {
            CompradorAssembler = new CompradorAssembler(new PedidoAssembler(new VarillaAssembler()));
        }

        public IList<CompradorDTO> GetByFilter(CompradorFilter filter)
        {
            return this.EntityRepository.GetByFilter(filter).Select(x => CompradorAssembler.ToDTO(x)).ToList();
        }

        public IList<CompradorDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => CompradorAssembler.ToDTO(x)).ToList();
        }

        public CompradorDTO GetDTOById(int id)
        {
            Comprador comprador = this.GetById(id);

            return CompradorAssembler.ToDTO(comprador);
        }
    }
}
