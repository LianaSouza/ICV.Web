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
            return View( new TurmaModel().BuscarTurmaCurso());
        }

        public ActionResult Editar(int id)
        {
            return View(new TurmaModel().BuscarTurma(id));
        }

        public ActionResult Cadastrar()
        {
            var vm = new TurmaModel();
            vm.Cursos = new CursoModel().BuscarCursoSelect();
            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TurmaModel objeto)
        {
            TurmaModel turma = new TurmaModel();

            //string email = context.HttpContext.User.Identity.Name;

            //turma.LoginColaborador = new LoginModel().BuscarLoginColaborador(email);




            new TurmaModel().CadastrarTurma(objeto);

            return RedirectToAction(nameof(Index));
        }


        public ActionResult EditarTurma(int id)
        {
            return View(new TurmaModel().BuscarTurma(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarTurma(int id, TurmaModel objeto)
        {
            try
            {
                new TurmaModel().EditarTurma(id, objeto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Turma/Delete/5
        public ActionResult RemoverTurma(int id)
        {
            return View(new TurmaModel().BuscarTurma(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverTurma(int id, TurmaModel Obj)
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