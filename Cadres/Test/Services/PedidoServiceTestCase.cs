using DAOs.Context;
using DAOs.Implements;
using Entidades.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using Test.Common;
using System.Linq;

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
    }
}
