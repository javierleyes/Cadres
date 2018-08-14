using Services.DTO.Base;
using Services.DTO.Inventario;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Services.DTO.Operaciones
{
    public class PedidoDTO : EntityDTO
    {
        public int Id { get; set; }

        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public VarillaDTO Varilla { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Precio { get; set; }

        public Estados.EstadoPedido Estado { get; set; }
    }
}
