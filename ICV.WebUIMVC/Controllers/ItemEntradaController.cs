using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class ItemEntradaController : Controller
    {
        public ActionResult Index()
        {
            return View(new ItemEntradaModel().Buscar());
        }
       
        public ActionResult Editar(int id)
        {
            return View(new ItemEntradaModel().Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ItemEntradaModel objeto)
        {
            try
            {
                // Update da Tabela Item
                new ItemEntradaModel().Editar(objeto, id);

                // Atualização da Tabela Produto
                ProdutoModel quantProduto = new ProdutoModel().Buscar(objeto.FKIdProduto);
                ProdutoModel produto = new ProdutoModel();
                produto.QuantidadeProduto = quantProduto.QuantidadeProduto + objeto.QuantidadeItem;
                produto.AtualizarQuantidade(produto, objeto.FKIdProduto);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..." + e);
            }
        }




        // Não utilizado

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}