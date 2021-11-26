using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View(new CursoModel().Buscar());
        }

        // GET: Curso/Detalhes/5
        public ActionResult Buscar(int id)
        {
            return View(new CursoModel().Buscar(id));
        }

        // GET: Curso/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Curso/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CursoModel objeto)
        {
            try
            {
                new CursoModel().Cadastrar(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Editar/5
        public ActionResult Editar(int id)
        {
            return View(new CursoModel().Buscar(id));
        }

        // POST: Curso/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, CursoModel objeto)
        {
            try
            {
                new CursoModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Remover(int id)
        {
            return View(new CursoModel().Buscar(id)); ;
        }

        // POST: Curso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, CursoModel objeto)
        {
            try
            {
                new CursoModel().Remover(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}