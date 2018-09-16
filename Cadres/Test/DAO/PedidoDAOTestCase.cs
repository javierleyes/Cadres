using Base;
using DAO.Interfaces;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using Test.Common;
using Test.Ninject;

namespace Test.DAO
{
    [TestClass]
    public class PedidoDAOTestCase
    {
        private IPedidoDAO PedidoDAO { get; set; }
        private IVarillaDAO VarillaDAO { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.VarillaDAO = kernel.Get<IVarillaDAO>();
            this.PedidoDAO = kernel.Get<IPedidoDAO>();
        }

        [TestMethod]
        public void InsertPedido_ok()
        {
            Pedido pedido = Utils.CrearPedido();

            this.PedidoDAO.InsertOrUpdate(pedido);

            pedido.Comprador = new Comprador() { Nombre = "Comprador Test." };

            int ultimoId = this.PedidoDAO.GetAll().ToList().LastOrDefault().Id;

            Pedido pedidoIngresado = this.PedidoDAO.GetById(ultimoId);

            Assert.AreEqual(pedidoIngresado.Observaciones, "Pintado de negro");
            Assert.AreEqual(pedidoIngresado.Precio, 250);
            Assert.AreEqual(pedidoIngresado.Estado, Estados.EstadoPedido.Pendiente);
        }

        [TestMethod]
        public void EditarPedido()
        {
            Pedido pedido = Utils.CrearPedido();

            this.PedidoDAO.InsertOrUpdate(pedido);

            int ultimoId = this.PedidoDAO.GetAll().ToList().LastOrDefault().Id;

            Pedido ultimoPedido = this.PedidoDAO.GetById(ultimoId);
            ultimoPedido.Observaciones = "Agrego una observacion en la edicion por service pedido Test";
            ultimoPedido.Estado = Estados.EstadoPedido.Entregado;

            this.PedidoDAO.InsertOrUpdate(ultimoPedido);

            Assert.AreEqual(this.PedidoDAO.GetById(ultimoId).Observaciones, "Agrego una observacion en la edicion por service pedido Test");
            Assert.AreEqual(this.PedidoDAO.GetById(ultimoId).Estado, Estados.EstadoPedido.Entregado);
        }

        [TestMethod]
        public void ObtenerTodosLosPedidos()
        {
            int cantidadPedidosOriginal = this.PedidoDAO.GetAll().ToList().Count();

            this.PedidoDAO.InsertOrUpdate(Utils.CrearPedido());

            IList<Pedido> pedidos = this.PedidoDAO.GetAll().ToList();

            Assert.IsTrue(cantidadPedidosOriginal == pedidos.Count() - 1);
        }
    }
}
