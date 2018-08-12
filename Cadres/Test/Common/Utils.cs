using Entidades;
using Entidades.DTOs;
using System;

namespace Test.Common
{
    public static class Utils
    {
        public static VarillaDTO CrearVarillaDTO(bool estado)
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = 3,
                Cantidad = 8,
                Disponible = estado
            };

            return EntityConverter.ConvertVarillaToVarillaDTO(varilla);
        }

        public static Varilla CrearVarilla(bool estado)
        {
            return new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Ancho = 3,
                Cantidad = 8,
                Disponible = estado
            };
        }
    }
}
