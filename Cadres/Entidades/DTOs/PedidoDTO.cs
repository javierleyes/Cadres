using Base;
using System;

namespace Entidades.DTOs
{
    public class PedidoDTO
    {
        public long Id { get; set; }

        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public VarillaDTO Varilla { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Precio { get; set; }

        public Estados.EstadoPedido Estado { get; set; }
    }
}
