using Entidades.Operaciones;
using Services.DTO.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Assemblers
{
    public class CompradorAssembler : IAssembler<CompradorDTO, Comprador>
    {
        protected PedidoAssembler PedidoAssembler { get; set; }

        public CompradorAssembler(PedidoAssembler pedidoAssembler)
        {
            PedidoAssembler = pedidoAssembler;
        }

        public CompradorDTO ToDTO(Comprador comprador)
        {
            return new CompradorDTO()
            {
                Id = comprador.Id,
                Nombre = comprador.Nombre,
                Direccion = comprador.Direccion,
                Telefono = comprador.Telefono,
                Observaciones = comprador.Observaciones,
                Pedidos = comprador.Pedidos.Select(x => PedidoAssembler.ToDTO(x)).ToList()
            };
        }

        public Comprador FromDTO(CompradorDTO compradorDTO)
        {
            return new Comprador()
            {
                Id = compradorDTO.Id,
                Nombre = compradorDTO.Nombre,
                Direccion = compradorDTO.Direccion,
                Telefono = compradorDTO.Telefono,
                Observaciones = compradorDTO.Observaciones,
                Pedidos = compradorDTO.Pedidos.Select(x => PedidoAssembler.FromDTO(x)).ToList()
            };
        }
    }
}
