using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaisBahia.AcessoDados;
using MaisBahia.Models;

namespace MaisBahia.Controllers
{
    public class AnunciantesController : Controller
    {
        private AnuncianteContexto db = new AnuncianteContexto();

        // GET: Anunciantes
        public ActionResult Index()
        {
            var anunciantes = db.Anunciantes.Include(a => a.categoria).Include(a => a.plano);
            return View(anunciantes.ToList());
        }

        // GET: Anunciantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // GET: Anunciantes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome");
            return View();
        }

        // POST: Anunciantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Descricao,CategoriaId,PlanoId")] Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                db.Anunciantes.Add(anunciante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", anunciante.CategoriaId);
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome", anunciante.PlanoId);
            return View(anunciante);
        }

        // GET: Anunciantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", anunciante.CategoriaId);
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome", anunciante.PlanoId);
            return View(anunciante);
        }

        // POST: Anunciantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Descricao,CategoriaId,PlanoId")] Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anunciante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", anunciante.CategoriaId);
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome", anunciante.PlanoId);
            return View(anunciante);
        }

        // GET: Anunciantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // POST: Anunciantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            db.Anunciantes.Remove(anunciante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
