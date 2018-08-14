using Entidades.Operaciones;
using Services.DTO.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assemblers
{
    public class PedidoAssembler : IAssembler<PedidoDTO, Pedido>
    {
        protected VarillaAssembler VarillaAssembler { get; set; }

        public PedidoAssembler(VarillaAssembler varillaAssembler)
        {
            VarillaAssembler = varillaAssembler;
        }

        public Pedido FromDTO(PedidoDTO fullEntityDTO)
        {
            return new Pedido()
            {
                Id = fullEntityDTO.Id,
                Ancho = fullEntityDTO.Ancho,
                Largo = fullEntityDTO.Largo,
                Fecha = fullEntityDTO.Fecha,
                Observaciones = fullEntityDTO.Observaciones,
                Precio = fullEntityDTO.Precio,
                Estado = fullEntityDTO.Estado,
                Varilla = VarillaAssembler.FromDTO(fullEntityDTO.Varilla)
            };
        }

        public PedidoDTO ToDTO(Pedido entity)
        {
            return new PedidoDTO()
            {
                Id = entity.Id,
                Ancho = entity.Ancho,
                Largo = entity.Largo,
                Fecha = entity.Fecha,
                Observaciones = entity.Observaciones,
                Precio = entity.Precio,
                Estado = entity.Estado,
                Varilla = VarillaAssembler.ToDTO(entity.Varilla)
            };
        }
    }
}
