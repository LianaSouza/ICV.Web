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
    public class DoacaoEntradaController : Controller
    {
        public ActionResult Cadastrar()
        {
            try
            {
                var vm = new DoacaoEntradaModel();
                vm.Doador = new DoadorModel().BuscarDoador();
                vm.Produto = new ProdutoModel().BuscarProdutoSelect();
                return View(vm);
            }
            catch (Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..." + e);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoacaoEntradaModel objeto)
        {
            try
            {
                //Cadastro Doação
                DoacaoEntradaModel doacao = objeto;
                string email = User.Identity.Name;
                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
                doacao.FKIdColaborador = Login.Id;
                doacao.BuscarId(doacao.FKIdColaborador);
                ViewBag.IdSaidaDoacao = doacao.IdDoacao;
                doacao.Cadastrar(doacao);

                return RedirectToAction(nameof(Cadastrar));
            }
            catch (Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..." + e);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarItem(DoacaoEntradaModel objeto)
        {
            try
            {
                // Cadastro Item 
                DoacaoEntradaModel doacao = objeto;
                string email = User.Identity.Name;
                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
                int colaborador = Login.Id;
                doacao.ListBeneficiado = doacao.BuscarId(colaborador);
                ItemEntradaModel item = new ItemEntradaModel();
                item.FKIdDoacao = doacao.ListBeneficiado.IdDoacao;
                item.categoriaProduto = objeto.CategoriaDoacao;
                item.QuantidadeItem = objeto.QuantidadeItem;
                item.FKIdProduto = doacao.FKIdProduto;
                item.Cadastrar(item);

                // Atualização da Tabela Produto
                ProdutoModel quantProduto = new ProdutoModel().Buscar(objeto.FKIdProduto);
                ProdutoModel produto = new ProdutoModel();
                produto.QuantidadeProduto = objeto.QuantidadeItem + quantProduto.QuantidadeProduto;
                produto.AtualizarQuantidade(produto, objeto.FKIdProduto);

                return RedirectToAction("Index", "ItemEntrada");
            }
            catch (Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..." + e);
            }

        }

        // Actions Não Utilizadas

        public ActionResult Index()
        {
            return View(new DoacaoEntradaModel().Buscar());
        }
        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }
        public ActionResult Editar(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoacaoEntradaModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new DoacaoEntradaModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Excluir(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, DoacaoEntradaModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                new DoacaoEntradaModel().Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}