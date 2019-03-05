using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace Cadres.RepositoryTest
{
    [TestClass]
    public class PedidoRepositoryTestCase
    {
        private IPedidoRepository PedidoRepository { get; set; }
        private IVarillaRepository VarillaRepository { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.PedidoRepository = kernel.Get<IPedidoRepository>();
            this.VarillaRepository = kernel.Get<IVarillaRepository>();
        }

        [TestMethod]
        public void CrearPedido_OK()
        {
            DateTime fechaPedido = DateTime.Now;

            Pedido pedido = new Pedido()
            {
                Fecha = fechaPedido,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Codigo = "1902LU14",
                Estado = Domain.States.Estados.EstadoPedido.Pendiente,
            };

            Marco marco = CrearMarco();
            marco.Varilla = this.VarillaRepository.GetById(1);

            pedido.Marcos.Add(marco);

            int cantidadInicial = this.PedidoRepository.GetAll().Count();

            long id = this.PedidoRepository.Add(pedido).Id;

            Pedido pedidoObtenido = this.PedidoRepository.GetById(id);

            Assert.AreEqual(pedidoObtenido.Observaciones, "Pintado de negro");
            Assert.AreEqual(pedidoObtenido.Fecha, fechaPedido);
            Assert.AreEqual(pedidoObtenido.Precio, 250);
            Assert.AreEqual(pedidoObtenido.Estado, Domain.States.Estados.EstadoPedido.Pendiente);
            Assert.AreEqual(pedidoObtenido.Codigo, "1902LU14");

            Assert.IsTrue(pedidoObtenido.Marcos != null);

            Assert.AreEqual(pedidoObtenido.Marcos.Count(), 1);

            Assert.AreEqual(cantidadInicial + 1, this.PedidoRepository.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearPedidoSinPrecio()
        {
            Pedido pedido = new Pedido()
            {
                Observaciones = "Pintado de negro",
                Codigo = "1902LU14",
                Estado = Domain.States.Estados.EstadoPedido.Pendiente,
            };

            PedidoRepository.Add(pedido);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearPedidoSinCodigo()
        {
            Pedido pedido = new Pedido()
            {
                Precio = 250,
                Observaciones = "Pintado de negro",
                Estado = Domain.States.Estados.EstadoPedido.Pendiente,
            };

            PedidoRepository.Add(pedido);
        }

        public static Marco CrearMarco()
        {
            return new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(71.89),
                Estado = Domain.States.Estados.EstadoMarco.Pendiente,
            };
        }

    }
}
