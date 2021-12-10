using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ICV.WebUIMVC.Controllers
{
    public class TurmaController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                return View(new TurmaModel().BuscarTurmaCurso());
            }
            catch 
            {
                ViewBag.retorno = "Erro";
                return View();
            } 
        }

        public ActionResult Cadastrar()
        {
            try
            {
                var vm = new TurmaModel();
                vm.Cursos = new CursoModel().BuscarCursoSelect();
                return View(vm);
            }
            catch 
            {
                ViewBag.retorno = "Erro";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TurmaModel objeto)
        {
            TurmaModel turma = objeto;

            try
            {
                
                string email = User.Identity.Name;
                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);
                turma.FKIdColaborador = Login.Id;

                if (turma.CadastrarTurma(turma) == true)
                {
                    ViewBag.retorno = "Sucesso";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.retorno = "Erro";
                    return View();
                }
                
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
                var vm = new TurmaModel().BuscarTurma(id);
                vm.Cursos = new CursoModel().BuscarCursoSelect(id);
                return View(vm);
            }
            catch
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, TurmaModel objeto)
        {
            try
            {
                TurmaModel turma = objeto;
                turma.EditarTurma(id, objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.retorno = "Erro";
                return View();
            }
        }


        // Não utilizado

        public ActionResult Detalhes(int id)
        {
            return View();
        }

        public ActionResult Remover(int id)
        {
            return View(new TurmaModel().BuscarTurma(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, TurmaModel Obj)
        {
            try
            {
                new TurmaModel().RemoverTurma(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}