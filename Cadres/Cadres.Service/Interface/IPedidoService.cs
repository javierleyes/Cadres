using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface IPedidoService : IGenericService<IPedidoRepository, Pedido, long>
    {
        PedidoDTO CrearNuevo();

        PedidoDTO GetByNumero(int numero);

        void AgregarMarco(int numero, int numeroMarco);

        void SetearEstadoTerminado(int numero);

        void SetearEstadoEntregado(int numero);

        void IngresarObservacion(int numeroPedido, string observacion);
    }
}
