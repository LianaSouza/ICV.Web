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
    public class CursoController : Controller
    {
        public ActionResult Index()
        {
            return View(new CursoModel().Buscar());
        }

        public ActionResult Buscar(int id)
        {
            return View(new CursoModel().Buscar(id));
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CursoModel curso)
        {
            try
            {
                var obj = new CursoModel();

                obj.Cadastrar(curso);

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            return View(new CursoModel().Buscar(id));
        }

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

        public ActionResult Remover(int id)
        {
            return View(new CursoModel().Buscar(id)); ;
        }

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