using Cadres.Dto;
using Cadres.Service.Filter;
using Cadres.Service.Interface;
using System;
using System.Linq;
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
            ViewBag.VarillasDisponibles = this.VarillaService.GetByFilter(new VarillaFilter() { Disponible = true }).Select(x => x.Nombre);

            return View();
        }

        [HttpPost]
        public ActionResult Calcular(FormCollection values)
        {
            if (String.IsNullOrEmpty(values["Ancho"]) || String.IsNullOrEmpty(values["Largo"]) || String.IsNullOrEmpty(values["Varilla"]))
            {
                // cambiar mensaje
                throw new Exception("El valor ingresado incorrecto");
            }

            var varilla = this.VarillaService.GetByFilter(new VarillaFilter() { Nombre = values["Varilla"].ToString() }).SingleOrDefault();

            if (String.IsNullOrEmpty(varilla.Nombre))
            {
                // cambiar mensaje
                throw new Exception("La varilla no existe");
            }

            ViewBag.NombreVarilla = varilla.Nombre;

            var marco = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(values["Ancho"]),
                Largo = Convert.ToDecimal(values["Largo"]),
                VarillaId = varilla.Id,
            };

            marco.Precio = this.MarcoService.CalcularPrecio(marco);

            return View(marco);
        }
    }
}