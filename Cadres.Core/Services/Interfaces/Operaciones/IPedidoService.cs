using DAL.Interfaces.Operaciones;
using Entidades.Operaciones;
using Services.DTO.Operaciones;
using Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Services.Interfaces.Operaciones
{
    public interface IPedidoService : IBaseService<IPedidoRepository, Pedido>
    {
        void Insert(PedidoDTO pedidoDTO);

        PedidoDTO GetDTOById(int id);

        IList<PedidoDTO> GetDTOAll();

        IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado);
    }
}
