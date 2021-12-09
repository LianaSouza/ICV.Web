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
        // GET: DoacaoSaida
        public ActionResult Index()
        {
            //  return View( new TurmaModel().BuscarTurmaCurso());
            return View(new DoacaoSaidaModel().Buscar());
        }

        // GET: DoacaoSaida/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // GET: DoacaoSaida/Create
        public ActionResult Cadastrar()
       {
            var vm = new DoacaoSaidaModel();
            vm.Beneficiado = new BeneficiadoModel().BuscarBeneficiado();
            vm.Produto = new ProdutoModel().BuscarProdutoSelect();
            return View(vm);
        }

        // POST: DoacaoSaida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoacaoSaidaModel objeto)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarItem(DoacaoSaidaModel objeto)
        {
            // Adquirir o Email do colaborador 
            DoacaoSaidaModel doacao = objeto;
            string email = User.Identity.Name;
            LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
            int colaborador = Login.Id;

            
            ItemSaidaModel item = new ItemSaidaModel();

            // Busco o ultimo cadastro do colaborador
            doacao.ListBeneficiado = doacao.BuscarId(colaborador);

            item.FKIdDoacao = doacao.ListBeneficiado.IdDoacao;

            item.categoriaProduto = objeto.CategoriaDoacao;

            item.QuantidadeItem = objeto.QuantidadeItem;

            // Adquirir o id do produto
            item.FKIdProduto = doacao.FKIdProduto ;

            item.Cadastrar(item);

            return RedirectToAction("Index","ItemSaida");
        }

        // GET: DoacaoSaida/Edit/5
        public ActionResult Editar(int id)
        {
            /*var vm = new TurmaModel().BuscarTurma(id);
            vm.Cursos = new CursoModel().BuscarCursoSelect(id);
            return View(vm);*/
           
           
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // POST: DoacaoSaida/Edit/5
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

        // GET: DoacaoSaida/Delete/5
        public ActionResult Excluir(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // POST: DoacaoSaida/Delete/5
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