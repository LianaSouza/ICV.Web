using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class ItemSaidaController : Controller
    {
        // GET: ItemSaida
        public ActionResult Index()
        {
            return View(new ItemSaidaModel().Buscar());
        }

        // GET: ItemSaida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemSaida/Create
        public ActionResult Cadastrar()
        { 
            // Não será usado pois esta junto do doação saida.
            return View();
        }

        // POST: ItemSaida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(IFormCollection collection)
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

        // GET: ItemSaida/Edit/5
        public ActionResult Editar(int id)
        {
            return View(new ItemSaidaModel().Buscar(id));
        }

        // POST: ItemSaida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ItemSaidaModel objeto)
        {
            new ItemSaidaModel().Editar(objeto, id);
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemSaida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemSaida/Delete/5
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