using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            AlunoModel Colaborador = new AlunoModel();
            return View(Colaborador.Buscar());
        }

        // GET: Aluno/Details/5
        public ActionResult Detalhes(int id)
        {
           AlunoModel Colaborador = new AlunoModel();
            return View(Colaborador.Buscar(id));
        }

        // GET: Aluno/Create
        public ActionResult Cadastrar()
        {
            var vm = new AlunoModel();
            vm.Turmas = vm.BuscarAlunoTurma();
            return View(vm);
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AlunoModel objeto)
        {
            try
            {
                var aluno = objeto;

                string email = User.Identity.Name;

                LoginModel login = new LoginModel().BuscarLoginColaborador(email);

                aluno.FKIdColaborador = login.Id;

                new Models.AlunoModel().Cadastrar(aluno);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Editar(int id)
        {
            //return View(new CursoModel().Buscar(id));

            var vm = new AlunoModel().Buscar(id);

            string email = User.Identity.Name;

            LoginModel Login = new LoginModel().BuscarLoginColaborador(email);

            vm.Colaborador = Login.Nome;

            return View(vm);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, AlunoModel objeto)
        {
            try
            {
                var aluno = objeto;

                string email = User.Identity.Name;

                LoginModel login = new LoginModel().BuscarLoginColaborador(email);

                aluno.FKIdColaborador = login.Id;

                // TODO: Add update logic here
                aluno.Editar(aluno, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Remover(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, AlunoModel objeto)
        {
            try
            {
                DoadorModel Doador = new DoadorModel();
                Doador.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}