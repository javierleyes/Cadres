using Cadres.Web.Models.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace Cadres.Web.Models.DTO.Varilla
{
    public class VarillaEditView : GenericView<long>
    {
        public string Nombre { get; set; }

        public decimal Ancho { get; set; }

        [Required]
        [Range(60, 1000)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Cantidad { get; set; }

        [Required]
        public bool Disponible { get; set; }
    }
}