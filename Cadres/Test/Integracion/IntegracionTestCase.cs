using DAO.Context;
using DAO.Implements;
using DAOs.Implements;
using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Integracion
{
    [TestClass]
    public class IntegracionTestCase
    {
        private CadresContext Context { get; set; }
        private IMarcoService MarcoService { get; set; }
        private PedidoService PedidoService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.Context = new CadresContext();

            this.MarcoService = new MarcoService(new MarcoDAO(this.Context));

            this.PedidoService = new PedidoService(new PedidoDAO(this.Context));
            this.PedidoService.MarcoService = this.MarcoService;
        }

        [TestMethod]
        public void CrearPedido_OK()
        {
            VarillaDTO varillaDTO = new VarillaDTO()
            {
                Nombre = "Chata 4.5 roble oscuro",
                Ancho = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(140),
            };

            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                Fecha = DateTime.Now,
                Estado = Base.Estados.EstadoPedido.Pendiente,

                Observaciones = "Estos marcos deben ir pintados con pintura acrilica negra.",
            };

            MarcoDTO marcoDTO = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(210),
                Largo = Convert.ToDecimal(297),
                Estado = Base.Estados.EstadoMarco.Pendiente,
                Varilla = varillaDTO,
            };

            MarcoDTO marcoDTO_Otro = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(210),
                Largo = Convert.ToDecimal(297),
                Estado = Base.Estados.EstadoMarco.Pendiente,
                Varilla = varillaDTO,
            };

            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO);
            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO_Otro);

            CompradorDTO compradorDTO = new CompradorDTO()
            {
                Nombre = "Gabriel",
                Telefono = "4241-5798",
            };

            this.PedidoService.AgregarComprador(pedidoDTO, compradorDTO);

            this.PedidoService.GuardarPedido(pedidoDTO);

            int ultimoPedido = this.PedidoService.GetDTOAll().LastOrDefault().Id;

            PedidoDTO pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            Assert.AreEqual(this.PedidoService.CalcularPrecioTotal(pedidoDTO), Convert.ToDecimal(1470.0) * 2);
            Assert.AreEqual(pedidoObtenido.Precio, this.PedidoService.CalcularPrecioTotal(pedidoDTO));
            Assert.AreEqual(pedidoObtenido.Estado, Base.Estados.EstadoPedido.Pendiente);

            Assert.IsTrue(pedidoObtenido.Id != 0);
            Assert.IsTrue(pedidoObtenido.Comprador.Id != 0);

            foreach (MarcoDTO marcoIngresado in pedidoObtenido.Marcos)
            {
                Assert.IsTrue(marcoIngresado.Id != 0);
                Assert.IsTrue(marcoIngresado.Varilla.Id != 0);
            }

            foreach (MarcoDTO marcoIngresado in pedidoObtenido.Marcos)
            {
                this.MarcoService.SetearEstadoListo(marcoIngresado);
            }

            this.PedidoService.SetearEstadoTerminado(pedidoObtenido);
            this.PedidoService.GuardarPedido(pedidoObtenido);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            //foreach (MarcoDTO marcoIngresado in pedidoObtenido.Marcos)
            //{
            //    Assert.AreEqual(marcoIngresado.Estado, Base.Estados.EstadoMarco.Listo);
            //}

            Assert.AreEqual(pedidoObtenido.Estado, Base.Estados.EstadoPedido.Terminado);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            this.PedidoService.SetearEstadoTerminado(pedidoObtenido);
            this.PedidoService.GuardarPedido(pedidoObtenido);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            Assert.AreEqual(pedidoObtenido.Estado, Base.Estados.EstadoPedido.Terminado);
        }
    }
}
