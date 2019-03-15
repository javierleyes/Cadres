using System;
using System.Data.Entity.Validation;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Cadres.RepositoryTestCase
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
            Pedido pedido = this.CrearPedido();

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

        private Pedido CrearPedido()
        {
            Pedido pedido = new Pedido()
            {
                Fecha = DateTime.Now,
                Observaciones = "Pintado de negro",
                Precio = 250,
                Numero = 3,
                Estado = Estados.EstadoPedido.Pendiente,
            };

            Marco marco = this.CrearMarco();
            marco.Varilla = this.CrearVarilla();

            pedido.Marcos.Add(marco);

            return pedido;
        }

        public Marco CrearMarco()
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
