using Cadres.Dto;
using Cadres.Service.Filter;
using Cadres.Service.Interface;
using Cadres.Web.Models.DTO.CalcularPrecio;
using Cadres.Web.Models.DTO.Pedido;
using System.Web.Mvc;

namespace Cadres.Web.Controllers
{
    public class PedidoController : Controller
    {
        public IPedidoService PedidoService { get; set; }
        public IVarillaService VarillaService { get; set; }
        public IMarcoService MarcoService { get; set; }

        public PedidoController(IPedidoService pedidoService, IVarillaService varillaService, IMarcoService marcoService)
        {
            this.PedidoService = pedidoService;
            this.VarillaService = varillaService;
            this.MarcoService = marcoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var pedidos = this.PedidoService.GetByFilter(new PedidoFilter() { Estado = 0 });

            return View(pedidos);
        }

        [HttpGet]
        public ActionResult CrearPedido()
        {
            CrearPedidoView pedido = new CrearPedidoView()
            {
                NumeroPedido = this.PedidoService.GetNumeroPedido().ToString(),
            };

            return View(pedido);
        }

        [HttpPost]
        public ActionResult CrearPedido(CrearPedidoView datos)
        {
            if (ModelState.IsValid)
            {
                PedidoDTO pedido = this.PedidoService.CrearNuevo();

                CompradorDTO comprador = new CompradorDTO()
                {
                    Nombre = datos.Nombre,
                    Telefono = datos.Telefono,
                    Direccion = datos.Dirección,
                    PedidoId = pedido.Id,
                };

                TempData["NumeroPedido"] = pedido.Numero;

                return RedirectToAction("CargarMarco");
            }

            return View(datos);
        }

        [HttpGet]
        public ActionResult CargarMarco()
        {
            ViewBag.Varillas = this.VarillaService.GetByFilter(new VarillaFilter() { Disponible = true });

            int numeroPedido = (int)TempData["NumeroPedido"];

            ViewBag.Marcos = this.PedidoService.GetMarcosByNumeroPedido(numeroPedido);

            TempData.Keep();

            return View();
        }

        [HttpPost]
        public ActionResult CargarMarco(CalcularPrecioView dto)
        {
            if (ModelState.IsValid)
            {
                int numeroPedido = (int)TempData["NumeroPedido"];

                MarcoDTO marco = new MarcoDTO()
                {
                    Ancho = dto.Ancho,
                    Largo = dto.Largo,
                    VarillaId = dto.VarillaId,
                };

                marco = this.MarcoService.CrearMarco(marco);

                this.PedidoService.AgregarMarco(numeroPedido, marco.Numero);

                TempData.Keep();

                return RedirectToAction("CargarMarco");
            }

            TempData.Keep();

            return View(dto);
        }
    }
}