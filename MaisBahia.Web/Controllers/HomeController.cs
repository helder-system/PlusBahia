using MaisBahia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisBahia.Web.Controllers
{
    public class HomeController : Controller
    {
        private MaisBahiaContext db = new MaisBahiaContext();
        public ActionResult Index()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.FotoId = new SelectList(db.Fotos, "Id", "Titulo");
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome");
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}