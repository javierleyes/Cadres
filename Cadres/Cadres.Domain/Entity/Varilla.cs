using Cadres.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Varilla", Schema = "dbo")]
    public class Varilla : Domain<long>
    {
        [Required]
        [MaxLength(60), MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [Range(1, 10)]
        public decimal Ancho { get; set; }

        [Required]
        [Range(60, 1000)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Cantidad { get; set; }

        [Required]
        public bool Disponible { get; set; }
    }
}
