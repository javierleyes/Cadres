using Entidades.DTO;

namespace Entidades
{
    /// <summary>
    /// Crear otro proyecto "Aseembler" para los mismo e implementar AutoMapper
    /// </summary>
    public static class EntityConverter
    {
        public static CompradorDTO ConvertCompradorToCompradorDTO(Comprador comprador)
        {
            CompradorDTO compradorDTO = new CompradorDTO()
            {
                Id = comprador.Id,
                Nombre = comprador.Nombre,
                Direccion = comprador.Direccion,
                Telefono = comprador.Telefono,
                Observaciones = comprador.Observaciones
            };

            foreach (Pedido pedido in comprador.Pedidos)
            {
                compradorDTO.Pedidos.Add(ConvertPedidoToPedidoDTO(pedido));
            }

            return compradorDTO;
        }

        public static Comprador ConvertCompradorDTOToComprador(CompradorDTO compradorDTO)
        {
            Comprador comprador = new Comprador()
            {
                Id = compradorDTO.Id,
                Nombre = compradorDTO.Nombre,
                Direccion = compradorDTO.Direccion,
                Telefono = compradorDTO.Telefono,
                Observaciones = compradorDTO.Observaciones,
            };

            foreach (PedidoDTO pedidoDTO in compradorDTO.Pedidos)
            {
                comprador.Pedidos.Add(ConvertPedidoDTOToPedido(pedidoDTO));
            }

            return comprador;
        }

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
                Varilla = ConvertVarillaDTOToVarilla(pedidoDTO.Varilla),
                Comprador = ConvertCompradorDTOToComprador(pedidoDTO.Comprador)
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

        public static PedidoDTO ConvertPedidoToPedidoDTO(Pedido pedido)
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
