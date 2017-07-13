using MaisBahia.Models;
using MaisBahia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisBahia.Web.Controllers
{
    public class fotosController : Controller
    {
        private FotoRepository fotoRepository;

        public fotosController()
        {
            if (fotoRepository == null)
            {
                fotoRepository = new FotoRepository();
            }
        }
        public ActionResult Index()
        {
            return View(fotoRepository.ObterTodos());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Foto foto, HttpPostedFileBase Imagem)
        {
            foto.DataCriacao = DateTime.Now;
            foto.DataModificacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (Imagem != null)
                {
                    //informa qual o tipo do arquivo Array de bytes.
                    foto.MimeType = Imagem.ContentType;
                    //informa qual o tamanho do arquivo Array de bytes.
                    foto.Arquivo = new byte[Imagem.ContentLength];
                    //Passar o arquivo carregado pelo usuário para o dentro do Array de bytes que foi criado. 
                    Imagem.InputStream.Read(foto.Arquivo, 0, Imagem.ContentLength);
                }
                fotoRepository.Adiciconar(foto);
                return RedirectToAction("Index");
            }
            return View(foto);
        }

        public FileContentResult ObterImagem(int Id)
        {
            Foto foto = fotoRepository.ObterPorId(Id);
            if (foto != null)
            {
                return File(foto.Arquivo, foto.MimeType);
            }
            else
            {
                return null;
            }
        }
    }
}