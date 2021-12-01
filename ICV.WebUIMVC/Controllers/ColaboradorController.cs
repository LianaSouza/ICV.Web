using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            return View(new ColaboradorModel().Buscar());
        }

        // GET: Colaborador/Details/5
        public ActionResult Detalhes(int id)
        {
            ColaboradorModel Colaborador = new ColaboradorModel();
            return View(Colaborador.Buscar(id));
        }

        // GET: Colaborador/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ColaboradorModel objeto)
        {
            new Models.ColaboradorModel().Cadastrar(objeto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Colaborador/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ColaboradorModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new ColaboradorModel().Editar(objeto , id);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Colaborador/Delete/5
        public ActionResult Remover(int id)
        {
            return View();
        }

        // POST: Colaborador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, ColaboradorModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                ColaboradorModel Colaborador = new ColaboradorModel();
                Colaborador.Remover(id);

                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }
    }
}