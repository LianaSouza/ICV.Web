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

        public ActionResult Index()
        {
            try
            {
                return View(new ProdutoModel().Buscar());
            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }


        public ActionResult Detalhes(int id)
        {
            try
            {
                ProdutoModel Produto = new ProdutoModel();
                return View(Produto.Buscar(id));
            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }


        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProdutoModel objeto)
        {
            try
            {
                new Models.ProdutoModel().Cadastrar(objeto);
                ViewBag.retorno = "Sucesso";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                return View(new ProdutoModel().Buscar(id));
            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ProdutoModel objeto)
        {
            try
            {
                new ProdutoModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
        }


        //Não utilizado
        
        public ActionResult Deletar(int id)
        {
            return View();
        }
       
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