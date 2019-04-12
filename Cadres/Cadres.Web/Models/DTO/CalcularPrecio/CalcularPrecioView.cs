﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cadres.Web.Models.DTO.CalcularPrecio
{
    // poner en carpeta shared
    public class CalcularPrecioView
    {
        [Required]
        [Range(1, 200)]
        public decimal Ancho { get; set; }

        [Required]
        [Range(1, 200)]
        public decimal Largo { get; set; }

        [Required]
        [DisplayName("Varilla")]
        [Range(1, 1000)]
        public long VarillaId { get; set; }
    }
}