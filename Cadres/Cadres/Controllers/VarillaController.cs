using DAO;
using DAO.Context;
using Entidades.DTO;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cadres.Controllers
{
    public class VarillaController : Controller
    {
        private CadresContext Context { get; set; }

        private IVarillaService VarillaService { get; set; }

        public VarillaController()
        {
            this.Context = new CadresContext();

            this.VarillaService = new VarillaService(new VarillaDAO(this.Context));
        }

        // GET: Varilla
        public ActionResult AdministracionVarillas()
        {
            var model = this.VarillaService.GetDTOAll();
            return View(model);
        }
    }
}