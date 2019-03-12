using Cadres.Dto;

namespace Cadres.Service.Interface
{
    public interface ICadresService
    {
        // INGRESAR PEDIDO //

        CompradorDTO CrearVenta(CompradorDTO compradorDTO); //PedidoDTO CrearPedido(PedidoDTO pedidoDTO);

        void AgregarMarco(int numeroPedido, MarcoDTO marcoDTO); //decimal CalcularPrecio(MarcoDTO marco);

        void TerminarMarco(int numeroMarco);

        void PedirMaterialesParaMarco(int numeroMarco);

        void TerminarPedido(int numeroPedido);

        void EntregarPedido(int numeroPedido);

        // INGRESAR VARILLA NUEVA //

        VarillaDTO AgregarVarilla(VarillaDTO varillaDTO);

        // MOSTRAR DATOS //
    }
}
