using Base;
using Entidades.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Pedido", Schema = "GES")]
    public class Pedido : Entity<int>
    {
        [Required]
        [StringLength(256)]
        public string Observaciones { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public Estados.EstadoPedido Estado { get; set; }

        [Required]
        public virtual IList<Marco> Marcos { get; set; }

        public virtual Comprador Comprador { get; set; }

        public Pedido()
        {
            this.Marcos = new List<Marco>();
        }
    }
}
