using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cadres.Web.Models.DTO.Pedido
{
    public class CrearPedidoView
    {
        [Required]
        [MaxLength(20), MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20), MinLength(8)]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        [DisplayName("Número de pedido")]
        public string NumeroPedido { get; set; }
    }
}