using Cadres.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Dto
{
    public class MarcoDTO : DomainDTO<long>
    {
        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public int Estado { get; set; }

        public decimal Precio { get; set; }

        public int Numero { get; set; }

        public long VarillaId { get; set; }

        public string Observacion { get; set; }
    }
}
