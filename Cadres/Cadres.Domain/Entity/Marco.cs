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
        [Range(1, 400)]
        public decimal Ancho { get; set; }

        [Required]
        [Range(1, 400)]
        public decimal Largo { get; set; }

        [Required]
        public Estados.EstadoMarco Estado { get; set; }

        [Required]
        [Range(1, 4000)]
        public decimal Precio { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public long VarillaId { get; set; }

        [ForeignKey("VarillaId")]
        public virtual Varilla Varilla { get; set; }
        
        [MaxLength(500)]
        public string Observacion { get; set; }
    }
}
