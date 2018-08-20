using Base;
using Entidades.DTO;

namespace Entidades.Filter
{
    public class FilterMarco
    {
        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public Estados.EstadoMarco Estado { get; set; }

        public VarillaDTO Varilla { get; set; }
    }
}
