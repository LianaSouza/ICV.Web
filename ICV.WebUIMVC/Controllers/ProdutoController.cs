using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View(new ProdutoModel().Buscar());
        }

        // GET: Produto/Details/5
        public ActionResult Detalhes(int id)
        {
           ProdutoModel Produto = new ProdutoModel();
            return View(Produto.Buscar(id));
        }

        // GET: Produto/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProdutoModel objeto)
        {        
                // TODO: Add insert logic here
                new Models.ProdutoModel().Cadastrar(objeto);
                return RedirectToAction(nameof(Index));                 
        }

        // GET: Produto/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ProdutoModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new ProdutoModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id, ProdutoModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                ProdutoModel Produto = new ProdutoModel();
                Produto.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}