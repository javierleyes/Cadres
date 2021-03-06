﻿using Cadres.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace Cadres.Dto
{
    public class VarillaDTO : DomainDTO<long>
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Range(1, 7)]
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
