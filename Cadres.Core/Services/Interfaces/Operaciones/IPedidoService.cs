using Services.DTO.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Services.Interfaces.Operaciones
{
    public interface IPedidoService
    {
        void Insert(PedidoDTO pedidoDTO);

        PedidoDTO GetDTOById(int id);

        IList<PedidoDTO> GetDTOAll();

        IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado);
    }
}
