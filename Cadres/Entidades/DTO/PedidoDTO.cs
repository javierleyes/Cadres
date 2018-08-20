using Base;
using System;
using System.Collections.Generic;

namespace Entidades.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Precio { get; set; }

        public Estados.EstadoPedido Estado { get; set; }

        public IList<MarcoDTO> Marcos { get; set; }

        public CompradorDTO Comprador { get; set; }

        public PedidoDTO()
        {
            this.Marcos = new List<MarcoDTO>();
        }
    }
}
