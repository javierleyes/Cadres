using Entidades;
using Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler
{
    public static class PedidoAssembler
    {
        public static void ConvertPedidoDTOToPedido(Pedido pedido, PedidoDTO pedidoDTO)
        {
            pedido.Estado = pedidoDTO.Estado;
            pedido.Precio = pedidoDTO.Precio;

            foreach (MarcoDTO marcoDTO in pedidoDTO.Marcos)
            {
                pedido.Marcos.FirstOrDefault(x => x.Id == marcoDTO.Id).Estado = marcoDTO.Estado;
            }
        }
    }
}
