using Cadres.Dto;
using Cadres.Service.Interface;
using System.Web.Mvc;

namespace Cadres.Web.Controllers
{
    public class VarillaController : Controller
    {
        public IVarillaService VarillaService { get; set; }

        public VarillaController(IVarillaService varillaService)
        {
            this.VarillaService = varillaService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var varillas = this.VarillaService.GetAllDTO();
            return View(varillas);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var varilla = this.VarillaService.GetDTOById(id);
            return View(varilla);
        }

        [HttpPost]
        public ActionResult Edit(VarillaDTO dto)
        {
            this.VarillaService.SetPrecio(dto.Id, dto.Precio);
            this.VarillaService.SetCantidad(dto.Id, dto.Cantidad);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var varilla = this.VarillaService.GetDTOById(id);
            return View(varilla);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VarillaDTO dto)
        {
            this.VarillaService.CrearNueva(dto);
            return RedirectToAction("Index");
        }
    }
}