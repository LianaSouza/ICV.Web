using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class DoacaoSaidaController : Controller
    {
        public ActionResult Cadastrar()
        {
            try
            {
                var vm = new DoacaoSaidaModel();
                vm.Beneficiado = new BeneficiadoModel().BuscarBeneficiado();
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
        public ActionResult Cadastrar(DoacaoSaidaModel objeto)
        {
            try
            {
                //Cadastro Doação
                DoacaoSaidaModel doacao = objeto;
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
        public ActionResult CadastrarItem(DoacaoSaidaModel objeto)
        {
            try
            {
                // Cadastro Item  
                DoacaoSaidaModel doacao = objeto;
                string email = User.Identity.Name;
                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
                int colaborador = Login.Id;
                ItemSaidaModel item = new ItemSaidaModel();
                doacao.ListBeneficiado = doacao.BuscarId(colaborador);
                item.FKIdDoacao = doacao.ListBeneficiado.IdDoacao;
                item.categoriaProduto = objeto.CategoriaDoacao;
                item.QuantidadeItem = objeto.QuantidadeItem;
                item.FKIdProduto = doacao.FKIdProduto;
                item.Cadastrar(item);

                // Atualização da Tabela Produto
                ProdutoModel quantProduto = new ProdutoModel().Buscar(objeto.FKIdProduto);
                ProdutoModel produto = new ProdutoModel();
                produto.QuantidadeProduto = quantProduto.QuantidadeProduto - objeto.QuantidadeItem;
                produto.AtualizarQuantidade(produto, objeto.FKIdProduto);

                return RedirectToAction("Index", "ItemSaida");
            }
            catch (Exception e)
            {
                return View("Ops! Ocorreu um erro inesperado..." + e);
            }

        }




        // Não esta usado

        public ActionResult Index()
        {
            //  return View( new TurmaModel().BuscarTurmaCurso());
            return View(new DoacaoSaidaModel().Buscar());
        }

        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        public ActionResult Editar(int id)
        {
            /*var vm = new TurmaModel().BuscarTurma(id);
            vm.Cursos = new CursoModel().BuscarCursoSelect(id);
            return View(vm);*/
           
           
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoacaoSaidaModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Excluir(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, DoacaoSaidaModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                new DoacaoSaidaModel().Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}