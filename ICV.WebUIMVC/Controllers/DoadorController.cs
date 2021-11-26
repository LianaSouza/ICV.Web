using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class DoadorController : Controller
    {
        // GET: Doador
        public ActionResult Index()
        {
            return View(new DoadorModel().Buscar());

        }

        // GET: Doador/Details/5
        public ActionResult Detalhes(int id)
        {
            
            return View( new DoadorModel().Buscar(id));
        }

        // GET: Doador/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Doador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoadorModel objeto)
        {
            try
            {
                // TODO: Add insert logic here
                new Models.DoadorModel().Cadastrar(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
        }

        // GET: Doador/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Doador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoadorModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new DoadorModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doador/Delete/5
        public ActionResult Remover(int id)
        {
            return View();
        }

        // POST: Doador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, DoadorModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
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