using Cadres.Domain.Base;
using Cadres.Domain.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Marco", Schema = "dbo")]
    public class Marco : Domain<long>
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
        public long VarillaId { get; set; }

        [Required]
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        [Required]
        public long PedidoId { get; set; }
    }
}
