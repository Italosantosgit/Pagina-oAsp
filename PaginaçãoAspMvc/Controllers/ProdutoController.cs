using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaginaçãoAspMvc.Models;
using X.PagedList;

namespace PaginaçãoAspMvc.Controllers
{
    public class ProdutoController : Controller
    {
        private LojaContext db = new LojaContext();

        public ActionResult Index(string busca ="", int pagina = 1, int tamanhoPagina = 5)
        {
            var produtos = db.Produtos.Where(p => p.Nome.Contains(busca)).
                OrderBy(p => p.Id).ToPagedList(pagina, tamanhoPagina);

            ViewBag.Busca = busca;
            ViewBag.TamanhaPagina = tamanhoPagina;
            return View(produtos);
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
