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
    public class BeneficiadoController : Controller
    {
        // GET: Beneficiado
        public ActionResult Index()
        {
            return View(new BeneficiadoModel().Buscar());
        }

        // GET: Beneficiado/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(new BeneficiadoModel().Buscar(id));
        }

        // GET: Beneficiado/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(BeneficiadoModel objeto)
        {
            try
            {
                var obj = new BeneficiadoModel();

                obj.Cadastrar(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Editar(int id)
        {
            return View(new BeneficiadoModel().Buscar(id));
        }

        // POST: Beneficiado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, BeneficiadoModel objeto)
        {
            try
            {
                
                new BeneficiadoModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Excluir(int id)
        {
            return View(new BeneficiadoModel().Buscar(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, BeneficiadoModel objeto)
        {
            try
            {
               
                new BeneficiadoModel().Remover(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}