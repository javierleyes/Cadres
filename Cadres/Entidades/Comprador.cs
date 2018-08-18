using Entidades.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Comprador", Schema = "GES")]
    public class Comprador : Entity<int>
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public virtual IList<Pedido> Pedidos { get; set; }
    }
}
