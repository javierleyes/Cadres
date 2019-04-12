using Cadres.Dto.Base;
using System.ComponentModel;

namespace Cadres.Dto
{
    public class MarcoDTO : DomainDTO<long>
    {
        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public decimal Precio { get; set; }

        public int Numero { get; set; }

        public string Observacion { get; set; }

        [DisplayName("Varilla")]
        public long VarillaId { get; set; }

        public string Estado { get; set; }
    }
}
