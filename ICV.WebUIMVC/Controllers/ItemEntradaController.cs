using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class ItemEntradaController : Controller
    {
     
        public ActionResult Index()
        {
            return View(new ItemEntradaModel().Buscar());
        }

       
        public ActionResult Editar(int id)
        {
            return View(new ItemEntradaModel().Buscar(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ItemEntradaModel objeto)
        {
            try
            {
                new ItemEntradaModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // Não utilizado

        // GET: ItemEntrada/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemEntrada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemEntrada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemEntrada/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemEntrada/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}