using Cadres.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cadres.Dto
{
    public class PedidoDTO : DomainDTO<long>
    {
        public string Observaciones { get; set; }

        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        public decimal? Precio { get; set; }

        public string Estado { get; set; }

        public int Numero { get; set; }

        public IList<long> MarcoIds { get; set; }

        [DisplayName("Fecha Terminado")]
        public DateTime? FechaTerminado { get; set; }

        [DisplayName("Fecha de Entrega")]
        public DateTime? FechaEntrega { get; set; }

        public PedidoDTO()
        {
            this.MarcoIds = new List<long>();
        }

    }
}
