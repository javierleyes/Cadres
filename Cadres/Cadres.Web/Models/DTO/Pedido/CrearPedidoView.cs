using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cadres.Web.Models.DTO.Pedido
{
    public class CrearPedidoView
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string Dirección { get; set; }

        [DisplayName("Número de pedido")]
        public string NumeroPedido { get; set; }
    }
}