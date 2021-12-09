using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class DoacaoEntradaController : Controller
    {

        // GET: DoacaoEntrada/Create
        public ActionResult Cadastrar()
        
        {
            var vm = new DoacaoEntradaModel();
            vm.Doador = new DoadorModel().BuscarDoador();
            vm.Produto = new ProdutoModel().BuscarProdutoSelect();
            return View(vm);
        }

        // POST: DoacaoEntrada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoacaoEntradaModel objeto)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarItem(DoacaoEntradaModel objeto)
        {
            // Adquirir o Email do colaborador 
            DoacaoEntradaModel doacao = objeto;
            string email = User.Identity.Name;
            LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
            int colaborador = Login.Id;


            ItemEntradaModel item = new ItemEntradaModel();

            // Busco o ultimo cadastro do colaborador
            doacao.ListBeneficiado = doacao.BuscarId(colaborador);

            item.FKIdDoacao = doacao.ListBeneficiado.IdDoacao;

            item.categoriaProduto = objeto.CategoriaDoacao;

            item.QuantidadeItem = objeto.QuantidadeItem;

            // Adquirir o id do produto
            item.FKIdProduto = doacao.FKIdProduto;

            item.Cadastrar(item);

            ProdutoModel quantProduto = new ProdutoModel().Buscar(objeto.FKIdProduto);
            ProdutoModel produto = new ProdutoModel();

            produto.QuantidadeProduto = objeto.QuantidadeItem + quantProduto.QuantidadeProduto;
            produto.AtualizarQuantidade(produto , objeto.FKIdProduto);

            return RedirectToAction("Index", "ItemEntrada");
        }





        // GET: DoacaoEntrada
        public ActionResult Index()
        {
            return View(new DoacaoEntradaModel().Buscar());
        }

        // GET: DoacaoEntrada/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // GET: DoacaoEntrada/Edit/5
        public ActionResult Editar(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // POST: DoacaoEntrada/Edit/5
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

        // GET: DoacaoEntrada/Delete/5
        public ActionResult Excluir(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // POST: DoacaoEntrada/Delete/5
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