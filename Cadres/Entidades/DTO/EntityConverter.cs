using System.Linq;

namespace Entidades.DTO
{
    /// <summary>
    /// Crear otro proyecto "Aseembler" para los mismo e implementar AutoMapper
    /// </summary>
    public static class EntityConverter
    {
        public static CompradorDTO ConvertCompradorToCompradorDTO(Comprador comprador)
        {
            return new CompradorDTO()
            {
                Id = comprador.Id,
                Nombre = comprador.Nombre,
                Direccion = comprador.Direccion,
                Telefono = comprador.Telefono,
            };
        }

        public static Comprador ConvertCompradorDTOToComprador(CompradorDTO compradorDTO)
        {
            return new Comprador()
            {
                Id = compradorDTO.Id,
                Nombre = compradorDTO.Nombre,
                Direccion = compradorDTO.Direccion,
                Telefono = compradorDTO.Telefono,
            };
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
            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                Id = pedido.Id,
                Observaciones = pedido.Observaciones,
                Fecha = pedido.Fecha,
                Precio = pedido.Precio,
                Estado = pedido.Estado,
                Comprador = ConvertCompradorToCompradorDTO(pedido.Comprador),
            };

            foreach (Marco marco in pedido.Marcos)
            {
                MarcoDTO marcoDTO = new MarcoDTO()
                {
                    Id = marco.Id,
                    Ancho = marco.Ancho,
                    Largo = marco.Largo,
                    Estado = marco.Estado,
                    Varilla = ConvertVarillaToVarillaDTO(marco.Varilla),
                    Precio = marco.Precio,
                };

                pedidoDTO.Marcos.Add(marcoDTO);
            }

            return pedidoDTO;
        }

        public static Pedido ConvertPedidoDTOToPedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = new Pedido()
            {
                Id = pedidoDTO.Id,
                Observaciones = pedidoDTO.Observaciones,
                Fecha = pedidoDTO.Fecha,
                Precio = pedidoDTO.Precio,
                Estado = pedidoDTO.Estado,
            };

            foreach (MarcoDTO marcoDTO in pedidoDTO.Marcos)
            {
                Marco marco = new Marco()
                {
                    Id = marcoDTO.Id,
                    Ancho = marcoDTO.Ancho,
                    Largo = marcoDTO.Largo,
                    Estado = marcoDTO.Estado,
                    Varilla = ConvertVarillaDTOToVarilla(marcoDTO.Varilla),
                    Precio = marcoDTO.Precio,
                };

                marco.Pedido = pedido;
                pedido.Marcos.Add(marco);
            }

            pedido.Comprador = ConvertCompradorDTOToComprador(pedidoDTO.Comprador);

            return pedido;
        }

        public static MarcoDTO ConvertMarcoToMarcoDTO(Marco marco)
        {
            return new MarcoDTO()
            {
                Id = marco.Id,
                Ancho = marco.Ancho,
                Largo = marco.Largo,
                Estado = marco.Estado,
                Varilla = ConvertVarillaToVarillaDTO(marco.Varilla),
                Pedido = ConvertPedidoToPedidoDTO(marco.Pedido),
                Precio = marco.Precio,
            };
        }

        public static Marco ConvertMarcoDTOToMarco(MarcoDTO marcoDTO)
        {
            return new Marco()
            {
                Id = marcoDTO.Id,
                Ancho = marcoDTO.Ancho,
                Largo = marcoDTO.Largo,
                Estado = marcoDTO.Estado,
                Varilla = ConvertVarillaDTOToVarilla(marcoDTO.Varilla),
                Pedido = ConvertPedidoDTOToPedido(marcoDTO.Pedido),
                Precio = marcoDTO.Precio,
            };
        }

    }
}
