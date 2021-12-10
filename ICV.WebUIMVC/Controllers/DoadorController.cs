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
    public class DoadorController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                return View(new DoadorModel().Buscar());
            }
            catch 
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
        public ActionResult Cadastrar(DoadorModel objeto)
        {
            try
            {
                DoadorModel Doador = objeto;

                string email = User.Identity.Name;

                LoginModel Login = new LoginModel().BuscarLoginColaborador(email);

                Doador.FKIdColaborador = Login.Id;

                Doador.Cadastrar(Doador);

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
                return View(new DoadorModel().Buscar(id));
            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DoadorModel objeto)
        {
            try
            {
                new DoadorModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }


        //Não utilizado

        public ActionResult Detalhes(int id)
        {

            return View(new DoadorModel().Buscar(id));
        }

        public ActionResult Remover(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, DoadorModel objeto)
        {
            try
            {

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