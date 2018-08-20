using Entidades.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Comprador", Schema = "GES")]
    public class Comprador : Entity<int>
    {
        [Required]
        [MaxLength(60), MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20), MinLength(8)]
        public string Telefono { get; set; }

        [MaxLength(100), MinLength(4)]
        public string Direccion { get; set; }

        [Required]
        public Pedido Pedido { get; set; }
    }
}
