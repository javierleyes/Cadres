using Entidades.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Operaciones
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

        [MaxLength(100), MinLength(3)]
        public string Direccion { get; set; }

        [StringLength(256)]
        public string Observaciones { get; set; }

        [Required]
        public virtual IList<Pedido> Pedidos { get; set; }

        public Comprador()
        {
            this.Pedidos = new List<Pedido>();
        }
    }
}
