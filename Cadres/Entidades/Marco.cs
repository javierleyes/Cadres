using Base;
using Entidades.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Marco", Schema = "GES")]
    public class Marco : Entity<int>
    {
        [Required]
        public decimal Ancho { get; set; }

        [Required]
        public decimal Largo { get; set; }

        [Required]
        public Estados.EstadoMarco Estado { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        [ForeignKey("VarillaId")]
        public virtual Varilla Varilla { get; set; }

        [Required]
        public int VarillaId { get; set; }

        [Required]
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        [Required]
        public int PedidoId { get; set; }
    }
}