using Cadres.Domain.Base;
using Cadres.Domain.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Pedido", Schema = "dbo")]
    public class Pedido : Domain<long>
    {
        [StringLength(256)]
        public string Observaciones { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(1, 4000)]
        public decimal Precio { get; set; }

        [Required]
        public Estados.EstadoPedido Estado { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public virtual IList<Marco> Marcos { get; set; }

        public Pedido()
        {
            this.Marcos = new List<Marco>();
            this.Fecha = DateTime.Now;
        }
    }
}
