using Base;
using DAO.Implements;
using Entidades;
using Entidades.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class PedidoService : GenericService<PedidoDAO, Pedido, int>, IPedidoService
    {
        public PedidoService(PedidoDAO entityDAO) : base(entityDAO)
        {
        }

        public IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado)
        {
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            foreach (Pedido pedido in EntityDAO.GetByEstado(estado))
            {
                pedidosDTO.Add(EntityConverter.ConvertPedidoToPedidoDTO(pedido));
            }

            return pedidosDTO;
        }

        public IList<PedidoDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => EntityConverter.ConvertPedidoToPedidoDTO(x)).ToList();
        }

        public PedidoDTO GetDTOById(int id)
        {
            Pedido pedido = this.GetById(id);

            return EntityConverter.ConvertPedidoToPedidoDTO(pedido);
        }

        public void Insert(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Precio = this.CalcularPrecio(pedidoDTO);

            Pedido pedido = EntityConverter.ConvertPedidoDTOToPedido(pedidoDTO);

            this.Save(pedido);
        }

        public decimal CalcularPrecio(PedidoDTO pedidoDTO)
        {
            // Regla de negocio
            // ancho y largo [cm]
            // conversion a mts
            // ( perimetro [cm] + 8 x ancho de varilla [cm] ) x precio varilla [$/m2]

            decimal perimetroCuadro = CalcularPerimetro(pedidoDTO);

            decimal angulosVarilla = CalculorAngulosVarilla(pedidoDTO);

            decimal metrosNecesarios = (perimetroCuadro + angulosVarilla) / 100;

            return (metrosNecesarios * pedidoDTO.Varilla.Precio);
        }

        private static decimal CalculorAngulosVarilla(PedidoDTO pedidoDTO)
        {
            return (8 * pedidoDTO.Varilla.Ancho);
        }

        private static decimal CalcularPerimetro(PedidoDTO pedidoDTO)
        {
            return ((pedidoDTO.Ancho * 2) + (pedidoDTO.Largo * 2));
        }
    }
}
