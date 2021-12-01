using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICV.WebUIMVC.Controllers
{
    public class TurmaController : Controller
    {

        public ActionResult Index()
        {
            return View(new TurmaModel().BuscarTurma());
        }

        public ActionResult BuscarTurma(int id)
        {
            return View(new TurmaModel().BuscarTurma(id));
        }

        public ActionResult Cadastrar()
        {
            var vm = new CursoModel();
            vm.Cursos = new CursoModel().BuscarCursoSelect();
            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TurmaModel objeto)
        {
            try
            {
                new TurmaModel().CadastrarTurma(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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