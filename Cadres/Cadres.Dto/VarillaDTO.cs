using Cadres.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Dto
{
    public class VarillaDTO : DomainDTO<long>
    {
        public string Nombre { get; set; }

        public decimal Ancho { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public bool Disponible { get; set; }
    }
}
