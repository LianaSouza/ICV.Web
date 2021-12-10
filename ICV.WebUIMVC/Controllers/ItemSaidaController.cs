using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemSaidaController : Controller
    {
       
        public ActionResult Index()
        {
            return View(new ItemSaidaModel().Buscar());
        }
        
        public ActionResult Editar(int id)
        {
            return View(new ItemSaidaModel().Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ItemSaidaModel objeto)
        {
            try
            {
                // Update da Tabela Item
                new ItemSaidaModel().Editar(objeto, id);

                // Atualização da Tabela Produto
                ProdutoModel quantProduto = new ProdutoModel().Buscar(objeto.FKIdProduto);
                ProdutoModel produto = new ProdutoModel();
                produto.QuantidadeProduto = quantProduto.QuantidadeProduto + objeto.QuantidadeItem;
                produto.AtualizarQuantidade(produto, objeto.FKIdProduto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..."+ e);
            }
            
        }



        // Não utilizado


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(IFormCollection collection)
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

        public ActionResult Detalhes(int id)
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            // Não será usado pois esta junto do doação saida.
            return View();
        }
   
        public ActionResult Excluir(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, IFormCollection collection)
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