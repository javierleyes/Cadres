using Base;
using Entidades;
using Entidades.DTOs;
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
                Ancho = Convert.ToDecimal(210.50),
                Largo = Convert.ToDecimal(297.60),
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Varilla = CrearVarilla(true),
                Estado = Estados.EstadoPedido.Pendiente
            };

            return pedido;
        }

        public static PedidoDTO CrearPedidoDTO()
        {
            PedidoDTO pedido = new PedidoDTO()
            {
                Ancho = Convert.ToDecimal(210.50),
                Largo = Convert.ToDecimal(297.60),
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Varilla = CrearVarillaDTO(true),
                Estado = Estados.EstadoPedido.Pendiente
            };

            return pedido;
        }
    }
}
