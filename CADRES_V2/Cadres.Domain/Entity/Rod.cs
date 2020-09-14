using Cadres.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Rod", Schema = "dbo")]
    public class Rod : Domain<long>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; }

        public Rod() { }
        public Rod(string name, decimal width, decimal price, bool available)
        {
            Name = name;
            Width = width;
            Price = price;
            Available = available;
        }
    }
}
