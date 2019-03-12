using Cadres.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Dto
{
    public class PedidoDTO : DomainDTO<long>
    {
        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Precio { get; set; }

        public int Estado { get; set; }

        public int Numero { get; set; }

        public virtual IList<long> MarcosIds { get; set; }
    }
}
