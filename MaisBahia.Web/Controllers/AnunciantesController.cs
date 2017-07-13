using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaisBahia.DataAccess;
using MaisBahia.Models;
using MaisBahia.Repository;

namespace MaisBahia.Web.Controllers
{
    public class AnunciantesController : Controller
    {
        private AnuncianteRepository anuncianteRepository;

        private MaisBahiaContext db = new MaisBahiaContext();
        // GET: Anunciantes
        public AnunciantesController()
        {
            if (anuncianteRepository == null)
            {
                anuncianteRepository = new AnuncianteRepository();
            }
        }

        public ActionResult Index()
        {
            return View(anuncianteRepository.ObterTodos());
        }

        public ActionResult Lista()
        {
            return View(anuncianteRepository.ObterTodos());
        }

        // GET: Anunciantes/Details/5
        public ActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = anuncianteRepository.ObterPorId(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // GET: Anunciantes/Create
        public ActionResult Criar()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.FotoId = new SelectList(db.Fotos, "Id", "Titulo");
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome");
            return View();
        }

        // POST: Anunciantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Descricao,CategoriaId,PlanoId")] Anunciante anunciante, HttpPostedFileBase Imagem)
        {
            if (ModelState.IsValid)
            {
                if (Imagem != null)
                {
                    //informa qual o tipo do arquivo Array de bytes.
                    anunciante.MimeType = Imagem.ContentType;
                    //informa qual o tamanho do arquivo Array de bytes.
                    anunciante.ArquivoFoto = new byte[Imagem.ContentLength];
                    //Passar o arquivo carregado pelo usuário para o dentro do Array de bytes que foi criado. 
                    Imagem.InputStream.Read(anunciante.ArquivoFoto, 0, Imagem.ContentLength);  
                }
                anuncianteRepository.Adiciconar(anunciante);
                return RedirectToAction("Lista");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", anunciante.CategoriaId);
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome", anunciante.PlanoId);
            return View(anunciante);
        }

        // GET: Anunciantes/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = anuncianteRepository.ObterPorId(id);
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
        public ActionResult Editar([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Descricao,CategoriaId,PlanoId,FotoId")] Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                anuncianteRepository.Editar(anunciante);
                return RedirectToAction("Lista");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", anunciante.CategoriaId);
            ViewBag.PlanoId = new SelectList(db.Planos, "Id", "Nome", anunciante.PlanoId);
            return View(anunciante);
        }

        // GET: Anunciantes/Delete/5
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = anuncianteRepository.ObterPorId(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // POST: Anunciantes/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anuncianteRepository.Excluir(id);
            return RedirectToAction("Lista");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public FileContentResult ObterImagem(int Id)
        {
            Anunciante anunciante = anuncianteRepository.ObterPorId(Id);
            if (anunciante.ArquivoFoto != null)
            {
                return File(anunciante.ArquivoFoto, anunciante.MimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
