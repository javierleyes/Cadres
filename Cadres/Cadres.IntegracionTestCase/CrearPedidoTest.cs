using Cadres.Domain.Entity;
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

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.CompradorService = kernel.Get<ICompradorService>();
            this.PedidoService = kernel.Get<IPedidoService>();
            this.MarcoService = kernel.Get<IMarcoService>();
            this.VarillaService = kernel.Get<IVarillaService>();
        }

        [TestMethod]
        public void CrearPedidoCompleto_OK()
        {
            // Crear pedido 

            Pedido pedido = this.PedidoService.CrearNuevo();

            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Pendiente);

            // Agregar marco

            MarcoDTO marcoDTO = CrearMarcoDTO();

            Marco marco = this.MarcoService.CrearMarco(marcoDTO);

            this.PedidoService.AgregarMarco(pedido.Numero, marco);

            // Crear comprador

            CompradorDTO compradorDTO = CrearCompradorDTO(pedido);

            this.CompradorService.CrearComprador(compradorDTO);

            this.MarcoService.SetEstadoListo(marco.Numero);

            //void PedirMaterialesParaMarco(int numeroMarco);

            this.PedidoService.SetearEstadoTerminado(pedido.Numero);

            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Terminado);

            this.PedidoService.SetearEstadoEntregado(pedido.Numero);

            Assert.AreEqual(pedido.Precio, Convert.ToDecimal("392"));
            Assert.AreEqual(pedido.Estado, Estados.EstadoPedido.Entregado);
        }

        [TestMethod]
        public void CrearPedidoCompletoConDosMarcos_OK()
        {
            // Crear pedido 

            Pedido pedido = this.PedidoService.CrearNuevo();

            // Agregar marco

            MarcoDTO marcoDTO = CrearMarcoDTO();

            Marco marco = this.MarcoService.CrearMarco(marcoDTO);
            Marco marcoDos = this.MarcoService.CrearMarco(marcoDTO);

            this.PedidoService.AgregarMarco(pedido.Numero, marco);
            this.PedidoService.AgregarMarco(pedido.Numero, marcoDos);

            // Crear comprador

            CompradorDTO compradorDTO = CrearCompradorDTO(pedido);

            this.CompradorService.CrearComprador(compradorDTO);

            this.MarcoService.SetEstadoListo(marco.Numero);
            this.MarcoService.SetEstadoListo(marcoDos.Numero);

            //void PedirMaterialesParaMarco(int numeroMarco);

            this.PedidoService.SetearEstadoTerminado(pedido.Numero);

            this.PedidoService.SetearEstadoEntregado(pedido.Numero);

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

        private CompradorDTO CrearCompradorDTO(Pedido pedido)
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
