using Base;
using DAOs;
using DAOs.Context;
using DAOs.Implements;
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
        private CadresContext context { get; set; }
        private PedidoDAO PedidoDAO { get; set; }
        private VarillaDAO VarillaDAO { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.context = new CadresContext();
            this.PedidoDAO = new PedidoDAO(this.context);
            this.VarillaDAO = new VarillaDAO(this.context);
        }

        [TestMethod]
        public void InsertPedido_ok()
        {
            Pedido pedido = CrearPedido();

            this.PedidoDAO.InsertOrUpdate(pedido);

            int ultimoId = this.PedidoDAO.GetAll().ToList().LastOrDefault().Id;

            Pedido pedidoIngresado = this.PedidoDAO.GetById(ultimoId);

            Assert.AreEqual(pedidoIngresado.Ancho, Convert.ToDecimal(210.50));
            Assert.AreEqual(pedidoIngresado.Largo, Convert.ToDecimal(297.60));
            Assert.AreEqual(pedidoIngresado.Observaciones, "Pintado de negro");
            Assert.AreEqual(pedidoIngresado.Precio, 250);
            Assert.AreEqual(pedidoIngresado.Varilla.Nombre, "Bombre 1,5 Negro Brilloso");
            Assert.AreEqual(pedidoIngresado.Estado, Estados.EstadoPedido.Pendiente);
        }

        [TestMethod]
        public void EditarPedido()
        {
            Pedido pedido = CrearPedido();

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

            this.PedidoDAO.InsertOrUpdate(this.CrearPedido());

            IList<Pedido> pedidos = this.PedidoDAO.GetAll().ToList();

            Assert.IsTrue(cantidadPedidosOriginal == pedidos.Count() - 1);
        }

        private Pedido CrearPedido()
        {
            int ultimoId = CrearVarillaYGuardar();

            Pedido pedido = new Pedido()
            {
                Ancho = Convert.ToDecimal(210.50),
                Largo = Convert.ToDecimal(297.60),
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Varilla = this.VarillaDAO.GetById(ultimoId),
                Estado = Estados.EstadoPedido.Pendiente
            };

            return pedido;
        }

        private int CrearVarillaYGuardar()
        {
            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(true));

            return this.VarillaDAO.GetAll().ToList().LastOrDefault().Id;
        }
    }
}
