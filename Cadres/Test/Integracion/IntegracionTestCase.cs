using DAO;
using DAO.Context;
using DAO.Implements;
using DAOs.Implements;
using Entidades.DTO;
using Entidades.Filter;
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
        private IVarillaService VarillaService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.Context = new CadresContext();

            this.VarillaService = new VarillaService(new VarillaDAO(this.Context));
            this.MarcoService = new MarcoService(new MarcoDAO(this.Context));

            this.PedidoService = new PedidoService(new PedidoDAO(this.Context))
            {
                MarcoService = this.MarcoService,
            };
        }

        [TestMethod]
        public void CrearPedido_OK()
        {
            int ultimoPedido;
            PedidoDTO pedidoObtenido;

            IngresarPedido(out ultimoPedido, out pedidoObtenido);
            pedidoObtenido = CambiarEstadoMarco(ultimoPedido, pedidoObtenido);
            pedidoObtenido = EntregarPedido(ultimoPedido, pedidoObtenido);
        }

        private PedidoDTO EntregarPedido(int ultimoPedido, PedidoDTO pedidoObtenido)
        {
            this.PedidoService.SetearEstadoEntregado(pedidoObtenido);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            Assert.AreEqual(pedidoObtenido.Estado, Base.Estados.EstadoPedido.Entregado);
            return pedidoObtenido;
        }

        private PedidoDTO CambiarEstadoMarco(int ultimoPedido, PedidoDTO pedidoObtenido)
        {
            foreach (MarcoDTO marcoIngresado in pedidoObtenido.Marcos)
            {
                this.MarcoService.SetearEstadoListo(marcoIngresado);
            }

            this.PedidoService.SetearEstadoTerminado(pedidoObtenido);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);

            foreach (MarcoDTO marcoIngresado in pedidoObtenido.Marcos)
            {
                Assert.AreEqual(marcoIngresado.Estado, Base.Estados.EstadoMarco.Listo);
            }

            Assert.AreEqual(pedidoObtenido.Estado, Base.Estados.EstadoPedido.Terminado);

            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);
            return pedidoObtenido;
        }

        private void IngresarPedido(out int ultimoPedido, out PedidoDTO pedidoObtenido)
        {
            VarillaDTO varillaDTO = CrearVarillaDTO();
            PedidoDTO pedidoDTO = CrearPedidoDTO();

            MarcoDTO marcoDTO = CrearMarcoDTO(varillaDTO);
            MarcoDTO marcoDTO_Otro = CrearMarcoDTO(varillaDTO);

            CompradorDTO compradorDTO = CrearCompradorDTO();

            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO);
            this.PedidoService.AgregarMarco(pedidoDTO, marcoDTO_Otro);

            this.PedidoService.AgregarComprador(pedidoDTO, compradorDTO);

            this.PedidoService.AgregarPedido(pedidoDTO);

            ultimoPedido = this.PedidoService.GetDTOAll().LastOrDefault().Id;
            pedidoObtenido = this.PedidoService.GetDTOById(ultimoPedido);
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
        }

        private static CompradorDTO CrearCompradorDTO()
        {
            return new CompradorDTO()
            {
                Nombre = "Gabriel",
                Telefono = "4241-5798",
            };
        }

        private static MarcoDTO CrearMarcoDTO(VarillaDTO varillaDTO)
        {
            return new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(210),
                Largo = Convert.ToDecimal(297),
                Estado = Base.Estados.EstadoMarco.Pendiente,
                Varilla = varillaDTO,
            };
        }

        private static PedidoDTO CrearPedidoDTO()
        {
            return new PedidoDTO()
            {
                Fecha = DateTime.Now,
                Estado = Base.Estados.EstadoPedido.Pendiente,

                Observaciones = "Estos marcos deben ir pintados con pintura acrilica negra.",
            };
        }

        private static VarillaDTO CrearVarillaDTO()
        {
            return new VarillaDTO()
            {
                Nombre = "Chata 4.5 roble oscuro",
                Ancho = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(140),
            };
        }
    }
}
