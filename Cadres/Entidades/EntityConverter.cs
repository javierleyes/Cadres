using Entidades.DTOs;

namespace Entidades
{
    public static class EntityConverter
    {
        //assembler 
        public static VarillaDTO ConvertVarillaToVarillaDTO(Varilla varilla)
        {
            return new VarillaDTO()
            {
                Id = varilla.Id,
                Nombre = varilla.Nombre,
                Ancho = varilla.Ancho,
                Precio = varilla.Precio,
                Cantidad = varilla.Cantidad,
                Disponible = varilla.Disponible
            };
        }

        public static Pedido ConvertPedidoDTOToPedido(PedidoDTO pedidoDTO)
        {
            return new Pedido()
            {
                Id = pedidoDTO.Id,
                Ancho = pedidoDTO.Ancho,
                Largo = pedidoDTO.Largo,
                Fecha = pedidoDTO.Fecha,
                Observaciones = pedidoDTO.Observaciones,
                Precio = pedidoDTO.Precio,
                Estado = pedidoDTO.Estado,
                Varilla = ConvertVarillaDTOToVarilla(pedidoDTO.Varilla)
            };
        }

        public static Varilla ConvertVarillaDTOToVarilla(VarillaDTO varillaDTO)
        {
            return new Varilla()
            {
                Id = varillaDTO.Id,
                Nombre = varillaDTO.Nombre,
                Ancho = varillaDTO.Ancho,
                Precio = varillaDTO.Precio,
                Cantidad = varillaDTO.Cantidad,
                Disponible = varillaDTO.Disponible
            };
        }

        public static PedidoDTO ConvertoPedidoToPedidoDTO(Pedido pedido)
        {
            return new PedidoDTO()
            {
                Id = pedido.Id,
                Ancho = pedido.Ancho,
                Largo = pedido.Largo,
                Fecha = pedido.Fecha,
                Observaciones = pedido.Observaciones,
                Precio = pedido.Precio,
                Estado = pedido.Estado,
                Varilla = ConvertVarillaToVarillaDTO(pedido.Varilla)
            };
        }
    }
}
