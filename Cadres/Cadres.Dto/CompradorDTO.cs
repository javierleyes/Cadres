using Cadres.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Dto
{
    public class CompradorDTO : DomainDTO<long>
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public long PedidoId { get; set; }
    }
}
