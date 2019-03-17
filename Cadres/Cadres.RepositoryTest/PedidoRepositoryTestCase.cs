using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Linq;

namespace Cadres.RepositoryTestCase
{
    [TestClass]
    public class PedidoRepositoryTestCase
    {
        private IPedidoRepository PedidoRepository { get; set; }
        private IVarillaRepository VarillaRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var kernel = StartUp.Initialize();

            this.PedidoRepository = kernel.Get<IPedidoRepository>();
            this.VarillaRepository = kernel.Get<IVarillaRepository>();
        }

        [TestMethod]
        public void CrearPedido_OK()
        {
            DateTime fechaPedido = DateTime.Now;
            Pedido pedido = CrearPedido(fechaPedido);

            int cantidadInicial = this.PedidoRepository.GetAll().Count();

            long id = this.PedidoRepository.Save(pedido).Id;

            Pedido pedidoObtenido = this.PedidoRepository.GetById(id);

            Assert.AreEqual(pedidoObtenido.Observaciones, "Pintado de negro");
            Assert.AreEqual(pedidoObtenido.FechaIngreso, fechaPedido);
            Assert.AreEqual(pedidoObtenido.Precio, 250);
            Assert.AreEqual(pedidoObtenido.Estado, Estados.EstadoPedido.Pendiente);

            Assert.IsTrue(pedidoObtenido.Marcos != null);

            Assert.AreEqual(pedidoObtenido.Marcos.Count(), 1);

            Assert.AreEqual(cantidadInicial + 1, this.PedidoRepository.GetAll().Count());
        }

        private Pedido CrearPedido(DateTime fechaPedido)
        {
            Pedido pedido = new Pedido()
            {
                FechaIngreso = fechaPedido,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Numero = 3,
                Estado = Estados.EstadoPedido.Pendiente,
            };

            Marco marco = CrearMarco();
            marco.Varilla = this.CrearVarilla();

            pedido.Marcos.Add(marco);

            return pedido;
        }

        public static Marco CrearMarco()
        {
            return new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(71.89),
                Estado = Estados.EstadoMarco.Pendiente,
            };
        }

        private Varilla CrearVarilla()
        {
            return new Varilla()
            {
                Nombre = "Chata 3 kiri",
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };
        }

    }
}
