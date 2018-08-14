using DAL.Implements.Operaciones;
using Entidades.Operaciones;
using Services.Assemblers;
using Services.DTO.Operaciones;
using Services.Implements.Base;
using Services.Interfaces.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Enums;

namespace Services.Implements.Operaciones
{
    public class PedidoService : BaseService<PedidoRepository, Pedido, int>, IPedidoService
    {
        protected PedidoAssembler PedidoAssembler { get; set; }

        public PedidoService(PedidoRepository entityRepository) : base(entityRepository)
        {
            PedidoAssembler = new PedidoAssembler(new VarillaAssembler());
        }

        public IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado)
        {
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            foreach (Pedido pedido in EntityRepository.GetWhere(x => x.Estado == estado))
            {
                pedidosDTO.Add(PedidoAssembler.ToDTO(pedido));
            }

            return pedidosDTO;
        }

        public IList<PedidoDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => PedidoAssembler.ToDTO(x)).ToList();
        }

        public PedidoDTO GetDTOById(int id)
        {
            Pedido pedido = this.GetById(id);

            return PedidoAssembler.ToDTO(pedido);
        }

        public void Insert(PedidoDTO pedidoDTO)
        {
            Pedido pedido = PedidoAssembler.FromDTO(pedidoDTO);

            this.Save(pedido);
        }
    }
}
