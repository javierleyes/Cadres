using Entidades.Inventtario;
using Services.DTO.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Common
{
    public static class EntityBuilder
    {
        public static Varilla BuildVarilla(bool disponible)
        {
            return new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = 3,
                Cantidad = 8,
                Disponible = disponible
            };
        }

        public static VarillaDTO BuildVarillaDTO(bool disponible, decimal? ancho = 3)
        {
            return new VarillaDTO()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = ancho.HasValue ? ancho.Value : 3,
                Cantidad = 8,
                Disponible = disponible
            };
        }
    }
}
