using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface IPedidoService : IGenericService<IPedidoRepository, Pedido, long>
    {
        Pedido CrearNuevo();

        void AgregarMarco(int numero, Marco marco);

        void SetearEstadoTerminado(int numero);

        void SetearEstadoEntregado(int numero);

        void IngresarObservacion(int numeroPedido, string observacion);
    }
}
