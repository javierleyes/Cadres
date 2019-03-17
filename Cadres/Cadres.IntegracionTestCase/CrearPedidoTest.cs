using Cadres.Domain.States;
using Cadres.Dto;
using Cadres.IoD.Ninject;
using Cadres.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;

namespace Cadres.IntegracionTestCase
{
    [TestClass]
    public class CrearPedidoTest
    {
        public ICompradorService CompradorService { get; set; }
        public IPedidoService PedidoService { get; set; }
        public IMarcoService MarcoService { get; set; }
        public IVarillaService VarillaService { get; set; }

        public StandardKernel Kernel { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.Kernel = StartUp.Initialize();

            this.CompradorService = Kernel.Get<ICompradorService>();
            this.PedidoService = Kernel.Get<IPedidoService>();
            this.MarcoService = Kernel.Get<IMarcoService>();
            this.VarillaService = Kernel.Get<IVarillaService>();
        }

        [TestMethod]
        public void CrearPedidoCompleto_OK()
        {
            // Crear pedido 

            PedidoDTO pedido = this.PedidoService.CrearNuevo();

            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Pendiente.ToString());
            Assert.IsTrue(pedido.FechaTerminado == null);
            Assert.IsTrue(pedido.FechaEntrega == null);
            Assert.IsTrue(pedido.FechaIngreso != null);

            // Agregar marco

            MarcoDTO marcoDTO = CrearMarcoDTO();

            MarcoDTO marco = this.MarcoService.CrearMarco(marcoDTO);

            this.PedidoService.AgregarMarco(pedido.Numero, marco.Numero);

            // Crear comprador

            CompradorDTO compradorDTO = CrearCompradorDTO(pedido);

            this.CompradorService.CrearComprador(compradorDTO);

            this.MarcoService.SetEstadoListo(marco.Numero);

            //void PedirMaterialesParaMarco(int numeroMarco);

            this.PedidoService.SetearEstadoTerminado(pedido.Numero);

            pedido = this.PedidoService.GetByNumero(pedido.Numero);

            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Terminado.ToString());
            Assert.IsTrue(pedido.FechaTerminado != null);

            this.PedidoService.SetearEstadoEntregado(pedido.Numero);

            pedido = this.PedidoService.GetByNumero(pedido.Numero);

            Assert.AreEqual(pedido.Precio, Convert.ToDecimal("392"));
            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Entregado.ToString());
            Assert.IsTrue(pedido.FechaEntrega != null);
        }

        [TestMethod]
        public void CrearPedidoCompletoConDosMarcos_OK()
        {
            // Crear pedido 

            PedidoDTO pedido = this.PedidoService.CrearNuevo();

            // Agregar marco

            MarcoDTO marcoDTO = CrearMarcoDTO();

            MarcoDTO marco = this.MarcoService.CrearMarco(marcoDTO);
            MarcoDTO marcoDos = this.MarcoService.CrearMarco(marcoDTO);

            this.PedidoService.AgregarMarco(pedido.Numero, marco.Numero);
            this.PedidoService.AgregarMarco(pedido.Numero, marcoDos.Numero);

            // Crear comprador

            CompradorDTO compradorDTO = CrearCompradorDTO(pedido);

            this.CompradorService.CrearComprador(compradorDTO);

            this.MarcoService.SetEstadoListo(marco.Numero);
            this.MarcoService.SetEstadoListo(marcoDos.Numero);

            //void PedirMaterialesParaMarco(int numeroMarco);

            this.PedidoService.SetearEstadoTerminado(pedido.Numero);

            this.PedidoService.SetearEstadoEntregado(pedido.Numero);

            pedido = this.PedidoService.GetByNumero(pedido.Numero);

            Assert.AreEqual(pedido.Precio, Convert.ToDecimal("784"));
        }

        private MarcoDTO CrearMarcoDTO()
        {
            return new MarcoDTO()
            {
                Ancho = 63,
                Largo = 65,
                VarillaId = 2,
            };
        }

        private CompradorDTO CrearCompradorDTO(PedidoDTO pedido)
        {
            return new CompradorDTO()
            {
                Nombre = "Micaela",
                Telefono = "Casanova",
                Direccion = "Sarandi",
                PedidoId = pedido.Id,
            };
        }

    }
}
