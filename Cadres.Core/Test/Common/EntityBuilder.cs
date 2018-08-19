using Entidades.Inventtario;
using Entidades.Operaciones;
using Services.DTO.Inventario;
using Services.DTO.Operaciones;
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

        public static Comprador CrearComprador()
        {
            Comprador comprador = new Comprador()
            {
                Nombre = "Nombre del Cliente",
                Direccion = "Calle falsa 123",
                Telefono = "4512-8754",
                Observaciones = "Las observaciones de test.",
            };

            return comprador;
        }

        public static CompradorDTO CrearCompradorDTO()
        {
            CompradorDTO compradorDTO = new CompradorDTO()
            {
                Nombre = "Nombre del Cliente",
                Direccion = "Calle falsa 123",
                Telefono = "4512-8754",
                Observaciones = "Las observaciones de test.",
            };

            return compradorDTO;
        }
    }
}
