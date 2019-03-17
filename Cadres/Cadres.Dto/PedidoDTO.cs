using Cadres.Dto.Base;
using System;
using System.Collections.Generic;

namespace Cadres.Dto
{
    public class PedidoDTO : DomainDTO<long>
    {
        public string Observaciones { get; set; }

        public DateTime FechaIngreso { get; set; }

        public decimal? Precio { get; set; }

        public string Estado { get; set; }

        public int Numero { get; set; }

        public virtual IList<long> MarcoIds { get; set; }

        public DateTime? FechaTerminado { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public PedidoDTO()
        {
            this.MarcoIds = new List<long>();
        }

    }
}
