using System;
using System.Data.Entity.Validation;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Cadres.RepositoryTest
{
    [TestClass]
    public class CompradorRepositoryTestCase
    {
        public ICompradorRepository CompradorRepository { get; set; }
        public IPedidoRepository PedidoRepository { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.CompradorRepository = kernel.Get<ICompradorRepository>();
            this.PedidoRepository = kernel.Get<IPedidoRepository>();
        }

        [TestMethod]
        public void CrearComprador_OK()
        {
            Pedido pedido = PedidoRepository.GetById(3);

            Comprador comprador = new Comprador()
            {
                Nombre = "Micaela",
                Direccion = "Belgrano 231",
                Telefono = "4268-9985",
                Pedido = pedido,
            };

            Comprador compradorGuardado = CompradorRepository.Save(comprador);

            Assert.AreEqual("Micaela", compradorGuardado.Nombre);
            Assert.AreEqual("Belgrano 231", compradorGuardado.Direccion);
            Assert.AreEqual("4268-9985", compradorGuardado.Telefono);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearCompradorSinNombre_Error()
        {
            Pedido pedido = PedidoRepository.GetById(1);

            Comprador comprador = new Comprador()
            {
                Direccion = "Belgrano 231",
                Telefono = "4268-9985",
                Pedido = pedido,
            };

            Comprador compradorGuardado = CompradorRepository.Save(comprador);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearCompradorSinTelefono_Error()
        {
            Pedido pedido = PedidoRepository.GetById(1);

            Comprador comprador = new Comprador()
            {
                Nombre = "Micaela",
                Direccion = "Belgrano 231",
                Pedido = pedido,
            };

            Comprador compradorGuardado = CompradorRepository.Save(comprador);
        }
    }
}
