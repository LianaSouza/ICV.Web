using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class DoacaoEntradaController : Controller
    {
        // GET: DoacaoEntrada
        public ActionResult Index()
        {
            return View(new DoacaoEntradaModel().Buscar());
        }

        // GET: DoacaoEntrada/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // GET: DoacaoEntrada/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: DoacaoEntrada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoacaoEntradaModel objeto)
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

        // GET: DoacaoEntrada/Edit/5
        public ActionResult Editar(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // POST: DoacaoEntrada/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoacaoEntradaModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new DoacaoEntradaModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoacaoEntrada/Delete/5
        public ActionResult Excluir(int id)
        {
            return View(new DoacaoEntradaModel().Buscar(id));
        }

        // POST: DoacaoEntrada/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, DoacaoEntradaModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                new DoacaoEntradaModel().Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}