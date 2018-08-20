using Base;

namespace Entidades.DTO
{
    public class MarcoDTO
    {
        public int Id { get; set; }

        public decimal Ancho { get; set; }

        public decimal Largo { get; set; }

        public Estados.EstadoMarco Estado { get; set; }

        public decimal Precio { get; set; }

        public VarillaDTO Varilla { get; set; }

        public PedidoDTO Pedido { get; set; }
    }
}
