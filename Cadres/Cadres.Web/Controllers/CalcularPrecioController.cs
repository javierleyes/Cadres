using Cadres.Dto;
using Cadres.Service.Filter;
using Cadres.Service.Interface;
using Cadres.Web.Models.DTO.CalcularPrecio;
using System.Web.Mvc;

namespace Cadres.Web.Controllers
{
    public class CalcularPrecioController : Controller
    {
        public IVarillaService VarillaService { get; set; }
        public IMarcoService MarcoService { get; set; }

        public CalcularPrecioController(IVarillaService varillaService, IMarcoService marcoService)
        {
            this.VarillaService = varillaService;
            this.MarcoService = marcoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.VarillasDisponibles = this.VarillaService.GetByFilter(new VarillaFilter() { Disponible = true });

            return View();
        }

        [HttpPost]
        public ActionResult Calcular(CalcularPrecioView dto)
        {
            var varilla = this.VarillaService.GetDTOById(dto.VarillaId);

            ViewBag.NombreVarilla = varilla.Nombre;

            var marco = new MarcoDTO()
            {
                Ancho = dto.Ancho,
                Largo = dto.Largo,
                VarillaId = varilla.Id,
            };

            marco.Precio = this.MarcoService.CalcularPrecio(marco);

            return View(marco);
        }
    }
}