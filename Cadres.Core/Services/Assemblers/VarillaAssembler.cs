using Entidades.Inventtario;
using Services.DTO.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assemblers
{
    public class VarillaAssembler : IAssembler<VarillaDTO, Varilla>
    {
        public Varilla FromDTO(VarillaDTO fullEntityDTO)
        {
            return new Varilla()
            {
                Id = fullEntityDTO.Id,
                Nombre = fullEntityDTO.Nombre,
                Ancho = fullEntityDTO.Ancho,
                Precio = fullEntityDTO.Precio,
                Cantidad = fullEntityDTO.Cantidad,
                Disponible = fullEntityDTO.Disponible
            };
        }

        public VarillaDTO ToDTO(Varilla entity)
        {
            return new VarillaDTO()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Ancho = entity.Ancho,
                Precio = entity.Precio,
                Cantidad = entity.Cantidad,
                Disponible = entity.Disponible
            };
        }
    }
}
