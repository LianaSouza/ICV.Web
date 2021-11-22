using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class BeneficiadoController : Controller
    {
        // GET: Beneficiado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Beneficiado/Details/5
        public ActionResult Detalhes(int id)
        {
            return View();
        }

        // GET: Beneficiado/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Beneficiado/Create
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

        // GET: Beneficiado/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Beneficiado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Beneficiado/Delete/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: Beneficiado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, IFormCollection collection)
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