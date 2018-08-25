using DAO.Context;
using DAO.Implements;
using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using Test.Common;
using System.Linq;
using System;
using Base;
using DAOs.Implements;

namespace Test.Services
{
    [TestClass]
    public class PedidoServiceTestCase
    {
        private PedidoService PedidoService { get; set; }
        private IMarcoService MarcoService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.MarcoService = new MarcoService(new MarcoDAO(new CadresContext()));
            this.PedidoService = new PedidoService(new PedidoDAO(new CadresContext()));
            this.PedidoService.MarcoService = this.MarcoService;
        }

        [TestMethod]
        public void InsertPedido_OK()
        {
            int cantidadPedidos = this.PedidoService.GetDTOAll().Count;

            PedidoDTO pedido = Utils.CrearPedidoDTO();

            this.PedidoService.AgregarPedido(pedido);

            int ultimoId = this.PedidoService.GetDTOAll().LastOrDefault().Id;

            PedidoDTO obtenido = this.PedidoService.GetDTOById(ultimoId);

            Assert.AreEqual(obtenido.Observaciones, "Pintado de negro");
            Assert.AreEqual(cantidadPedidos, this.PedidoService.GetDTOAll().Count - 1);
        }

        [TestMethod]
        public void CalcularPrecio_OK()
        {
            VarillaDTO varillaDTO = new VarillaDTO()
            {
                Ancho = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(45.5),
                Cantidad = 10,
                Disponible = true,
                Nombre = "Varilla 4.5 Test",
            };

            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                Fecha = DateTime.Now,
                Estado = Base.Estados.EstadoPedido.Pendiente,
                Observaciones = "Es un test :P",
                Comprador = Utils.CrearCompradorDTO(),
            };

            MarcoDTO marcoDTO = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(40.5),
                Largo = Convert.ToDecimal(20.5),
                Varilla = varillaDTO,
                Precio = Convert.ToDecimal(71.89),
            };

            pedidoDTO.Marcos.Add(marcoDTO);

            decimal precio = this.PedidoService.CalcularPrecioTotal(pedidoDTO);

            this.PedidoService.AgregarPedido(pedidoDTO);

            int ultimoPedido = this.PedidoService.GetDTOAll().LastOrDefault().Id;

            Assert.AreEqual(precio, Convert.ToDecimal(71.89));
            Assert.AreEqual(this.PedidoService.GetDTOById(ultimoPedido).Precio, precio);
        }

        [TestMethod]
        public void AgregarMarcoAPedido_OK()
        {
            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Estado = Estados.EstadoPedido.Pendiente,
                Comprador = new CompradorDTO() { Nombre = "Nombre test", Telefono = "7854-6958", },
            };

            MarcoDTO marcoDTO1 = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = Utils.CrearVarillaDTO(true),
            };

            MarcoDTO marcoDTO2 = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = Utils.CrearVarillaDTO(true),
            };

            marcoDTO1.Precio = this.MarcoService.CalcularPrecio(marcoDTO1);
            marcoDTO2.Precio = this.MarcoService.CalcularPrecio(marcoDTO2);

            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO1);
            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO2);

            decimal precio = this.PedidoService.CalcularPrecioTotal(pedidoDTO);

            Assert.AreEqual(precio, (Convert.ToDecimal(20.832) * 2));
        }
    }
}
