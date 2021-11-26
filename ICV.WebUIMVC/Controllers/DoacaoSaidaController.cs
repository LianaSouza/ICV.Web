using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class DoacaoSaidaController : Controller
    {
        // GET: DoacaoSaida
        public ActionResult Index()
        {
            return View(new DoacaoSaidaModel().Buscar());
        }

        // GET: DoacaoSaida/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // GET: DoacaoSaida/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: DoacaoSaida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DoacaoSaidaModel objeto)
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

        // GET: DoacaoSaida/Edit/5
        public ActionResult Editar(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // POST: DoacaoSaida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoacaoSaidaModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new DoacaoSaidaModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoacaoSaida/Delete/5
        public ActionResult Excluir(int id)
        {
            return View(new DoacaoSaidaModel().Buscar(id));
        }

        // POST: DoacaoSaida/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, DoacaoSaidaModel objeto)
        {
            try
            {
                // TODO: Add delete logic here
                new DoacaoSaidaModel().Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}