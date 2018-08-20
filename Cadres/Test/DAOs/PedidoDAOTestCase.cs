using Base;
using DAO;
using DAO.Context;
using DAO.Implements;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Common;

namespace Test.DAOs
{
    [TestClass]
    public class PedidoDAOTestCase
    {
        private CadresContext Context { get; set; }
        private PedidoDAO PedidoDAO { get; set; }
        private VarillaDAO VarillaDAO { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.Context = new CadresContext();
            this.PedidoDAO = new PedidoDAO(this.Context);
            this.VarillaDAO = new VarillaDAO(this.Context);
        }

        [TestMethod]
        public void InsertPedido_ok()
        {
            Pedido pedido = Utils.CrearPedido();

            this.PedidoDAO.InsertOrUpdate(pedido);

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
