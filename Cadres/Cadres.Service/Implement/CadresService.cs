using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Interface;

namespace Cadres.Service.Implement
{
    public class CadresService : ICadresService
    {
        public ICompradorService CompradorService { get; set; }
        public IPedidoService PedidoService { get; set; }
        public IMarcoService MarcoService { get; set; }
        public IVarillaService VarillaService { get; set; }

        public CadresService(ICompradorService CompradorService, IPedidoService PedidoService, IMarcoService MarcoService, IVarillaService VarillaService)
        {
            this.CompradorService = CompradorService;
            this.PedidoService = PedidoService;
            this.MarcoService = MarcoService;
            this.VarillaService = VarillaService;
        }

        public CompradorDTO CrearVenta(CompradorDTO compradorDTO)
        {
            Pedido pedido = this.PedidoService.CrearNuevo();

            compradorDTO.PedidoId = pedido.Id;

            return this.CompradorService.CrearComprador(compradorDTO);
        }

        public void AgregarMarco(int numeroPedido, MarcoDTO marcoDTO)
        {
            Marco marco = this.MarcoService.CrearMarco(marcoDTO);

            this.PedidoService.AgregarMarco(numeroPedido, marco);
        }

        public VarillaDTO AgregarVarilla(VarillaDTO varillaDTO)
        {
            return this.VarillaService.CrearNueva(varillaDTO);
        }

        public void EntregarPedido(int numeroPedido)
        {
            this.PedidoService.SetearEstadoEntregado(numeroPedido);
        }

        public void PedirMaterialesParaMarco(int numeroMarco)
        {
            this.MarcoService.SetEstadoSinMateriales(numeroMarco);
        }

        public void TerminarMarco(int numeroMarco)
        {
            this.MarcoService.SetEstadoListo(numeroMarco);
        }

        public void TerminarPedido(int numeroPedido)
        {
            this.PedidoService.SetearEstadoTerminado(numeroPedido);
        }
    }
}
