using System.Web.Mvc;

namespace Cadres.Web.Controllers
{
    public class DocumentacionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}