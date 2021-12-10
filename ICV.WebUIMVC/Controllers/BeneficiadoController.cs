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
     
        public ActionResult Index()
        {
            try
            {
                return View(new BeneficiadoModel().Buscar());
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }
           
        }
        
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
                BeneficiadoModel beneficiado = objeto;

                string email = User.Identity.Name;

                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);

                beneficiado.FKIdColaborador = Login.Id;

                beneficiado.Cadastrar(beneficiado);

                return RedirectToAction(nameof(Index));

            }
            catch 
            {
                ViewBag.Error = true;
                return View();
            }
        }

        
        public ActionResult Editar(int id)
        {
            try
            {
                return View(new BeneficiadoModel().Buscar(id));
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }
            
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, BeneficiadoModel objeto)
        {
            try
            {
                new BeneficiadoModel().Editar(objeto, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View();
            }
        }



        // Não utilizado

        public ActionResult Detalhes(int id)
        {
            return View(new BeneficiadoModel().Buscar(id));
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