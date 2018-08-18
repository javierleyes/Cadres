using DAO.Context;
using DAO.Implements;
using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using Test.Common;
using System.Linq;
using System;

namespace Test.Services
{
    [TestClass]
    public class PedidoServiceTestCase
    {
        private IPedidoService PedidoService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.PedidoService = new PedidoService(new PedidoDAO(new CadresContext()));
        }

        [TestMethod]
        public void InsertPedido_OK()
        {
            int cantidadPedidos = this.PedidoService.GetDTOAll().Count;

            PedidoDTO pedido = Utils.CrearPedidoDTO();

            this.PedidoService.Insert(pedido);

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
                Nombre = "Varilla 4.5 Test"
            };

            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                Ancho = Convert.ToDecimal(40.5),
                Largo = Convert.ToDecimal(20.5),
                Varilla = varillaDTO,
                Fecha = DateTime.Now,
                Estado = Base.Estados.EstadoPedido.Pendiente,
                Observaciones = "Es un test :P",
                Comprador = Utils.CrearCompradorDTO()
            };

            decimal precio = this.PedidoService.CalcularPrecio(pedidoDTO);

            this.PedidoService.Insert(pedidoDTO);

            int ultimoPedido = this.PedidoService.GetDTOAll().LastOrDefault().Id;

            Assert.AreEqual(precio, Convert.ToDecimal(71.89));
            Assert.AreEqual(this.PedidoService.GetDTOById(ultimoPedido).Precio, precio);
        }
    }
}
