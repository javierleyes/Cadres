using Entidades.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Inventtario
{
    [Table("Varilla", Schema = "VAR")]
    public class Varilla : Entity<int>
    {
        [Required]
        [MaxLength(60), MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public bool Disponible { get; set; }
    }
}
