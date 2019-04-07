using Cadres.Dto;
using Cadres.Service.Interface;
using Cadres.Web.Models.DTO.Varilla;
using PagedList;
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
        public ActionResult Index(int? page)
        {
            var varillas = this.VarillaService.GetAllDTO();

            // resultados por pagina
            int pageSize = 6;

            // numero de pagina
            int pageNumber = (page ?? 1);

            return View(varillas.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var varilla = this.VarillaService.GetDTOById(id);

            VarillaEditView view = new VarillaEditView()
            {
                Id = varilla.Id,
                Nombre = varilla.Nombre,
                Ancho = varilla.Ancho,
                Cantidad = varilla.Cantidad,
                Precio = varilla.Precio,
                Disponible = varilla.Disponible,
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult Edit(VarillaEditView dto)
        {
            if (ModelState.IsValid)
            {
                VarillaDTO varilla = new VarillaDTO()
                {
                    Id = dto.Id,
                    Cantidad = dto.Cantidad,
                    Precio = dto.Precio,
                    Disponible = dto.Disponible,
                };

                this.VarillaService.Actualizar(varilla);

                return RedirectToAction("Index");
            }

            return View(dto);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var varilla = this.VarillaService.GetDTOById(id);

            ViewBag.NameModal = varilla.Id;

            return PartialView("_Modal", varilla);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VarillaDTO dto)
        {
            if (ModelState.IsValid)
            {
                this.VarillaService.CrearNueva(dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}