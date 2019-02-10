using Cadres.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Comprador", Schema = "dbo")]
    public class Comprador : Domain<long>
    {
        [Required]
        [MaxLength(6), MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20), MinLength(8)]
        public string Telefono { get; set; }

        [MaxLength(100), MinLength(4)]
        public string Direccion { get; set; }

        [Required]
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        [Required]
        public long PedidoId { get; set; }
    }
}
