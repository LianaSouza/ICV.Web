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
    public class AlunoController : Controller
    {
      
        public ActionResult Index()
        {
            try
            {
                AlunoModel Colaborador = new AlunoModel();
                return View(Colaborador.Buscar());
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }
            
        }
     
        public ActionResult Cadastrar()
        {
            try
            {
                var vm = new AlunoModel();
                vm.Turmas = vm.BuscarAlunoTurma();
                return View(vm);
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }
            
        }

        
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

       
        public ActionResult Editar(int id)
        {
            try
            {
                var vm = new AlunoModel().Buscar(id);

                string email = User.Identity.Name;

                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);

                vm.Colaborador = Login.Nome;

                return View(vm);
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }

            
        }

     
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

               
                aluno.Editar(aluno, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
        }

        // Não utilizado

        public ActionResult Detalhes(int id)
        {
            try
            {
                AlunoModel Colaborador = new AlunoModel();
                return View(Colaborador.Buscar(id));
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }

        }

        public ActionResult Remover(int id)
        {
            return View();
        }

        
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