using Base;
using DAO.Interfaces;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPedidoService : IGenericService<IPedidoDAO, Pedido, int>
    {
        void AgregarPedido(PedidoDTO pedidoDTO);

        void AgregarMarco(PedidoDTO pedidoDTO, MarcoDTO marcoDTO);

        void AgregarComprador(PedidoDTO pedidoDTO, CompradorDTO compradorDTO);

        void SetearEstadoTerminado(PedidoDTO pedidoDTO);

        void SetearEstadoEntregado(PedidoDTO pedidoDTO);

        PedidoDTO GetDTOById(int id);

        IList<PedidoDTO> GetDTOAll();

        IList<PedidoDTO> GetByFilter(FilterPedido filter);

        decimal CalcularPrecioTotal(PedidoDTO pedidoDTO);
    }
}
