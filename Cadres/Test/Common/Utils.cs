using Base;
using Entidades;
using Entidades.DTO;
using System;

namespace Test.Common
{
    public static class Utils
    {
        public static VarillaDTO CrearVarillaDTO(bool estado, decimal? ancho = 3)
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = ancho.HasValue ? ancho.Value : 3,
                Cantidad = 8,
                Disponible = estado
            };

            return EntityConverter.ConvertVarillaToVarillaDTO(varilla);
        }

        public static Varilla CrearVarilla(bool estado)
        {
            return new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = 3,
                Cantidad = 8,
                Disponible = estado
            };
        }

        public static Pedido CrearPedido()
        {
            Pedido pedido = new Pedido()
            {
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Estado = Estados.EstadoPedido.Pendiente,
                Comprador = new Comprador() { Nombre = "Comprador Test.", Telefono = "5487-9658", },
            };

            Marco marco = CrearMarco();
            marco.Pedido = pedido;

            pedido.Marcos.Add(marco);

            return pedido;
        }

        public static PedidoDTO CrearPedidoDTO()
        {
            PedidoDTO pedido = new PedidoDTO()
            {
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Estado = Estados.EstadoPedido.Pendiente,
                Comprador = new CompradorDTO() { Nombre = "Nombre test", Telefono = "7854-6958", },
            };

            pedido.Marcos.Add(CrearMarcoDTO());

            return pedido;
        }

        public static Comprador CrearComprador()
        {
            Pedido pedido = new Pedido()
            {
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Estado = Estados.EstadoPedido.Pendiente,
            };

            Marco marco = CrearMarco();
            marco.Pedido = pedido;

            pedido.Marcos.Add(marco);

            Comprador comprador = new Comprador()
            {
                Nombre = "Nombre del Cliente",
                Direccion = "Calle falsa 123",
                Telefono = "4512-8754",
                Pedido = pedido,
            };

            pedido.Comprador = comprador;

            return comprador;
        }

        public static CompradorDTO CrearCompradorDTO()
        {
            CompradorDTO compradorDTO = new CompradorDTO()
            {
                Nombre = "Nombre del Cliente",
                Direccion = "Calle falsa 123",
                Telefono = "4512-8754",
            };

            return compradorDTO;
        }

        public static Marco CrearMarco()
        {
            return new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = CrearVarilla(true),
                Precio = Convert.ToDecimal(71.89),
            };
        }

        public static MarcoDTO CrearMarcoDTO()
        {
            return new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = CrearVarillaDTO(true),
                Precio = Convert.ToDecimal(71.89),
            };
        }
    }
}
