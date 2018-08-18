using Base;
using Entidades.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Pedido", Schema = "GES")]
    public class Pedido : Entity<int>
    {
        [Required]
        public decimal Ancho { get; set; }

        [Required]
        public decimal Largo { get; set; }

        [Required]
        [ForeignKey("VarillaId")]
        public virtual Varilla Varilla { get; set; }

        [Required]
        public int VarillaId { get; set; }

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
        public int CompradorId { get; set; }

        [Required]
        [ForeignKey("CompradorId")]
        public Comprador Comprador { get; set; }
    }
}
