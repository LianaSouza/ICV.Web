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
    public class ColaboradorController : Controller
    {
        
        public ActionResult Index()
        {
            try
            {
                return View(new ColaboradorModel().Buscar());
            }
            catch (Exception)
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ColaboradorModel objeto)
        {
            try
            {
                new Models.ColaboradorModel().Cadastrar(objeto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }

        
        public ActionResult Editar(int id)
        {
            try
            {
                return View(new ColaboradorModel().Buscar(id));
            }
            catch 
            {
                ViewBag.retorno = "Erro";
                return View();
            }
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ColaboradorModel objeto)
        {
            try
            {
                new ColaboradorModel().Editar(objeto , id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.retorno = "Erro";
                return View();
            }
        }



        //Não utilizado

        public ActionResult Detalhes(int id)
        {
            ColaboradorModel Colaborador = new ColaboradorModel();
            return View(Colaborador.Buscar(id));
        }

        public ActionResult Remover(int id)
        {
            return View();
        }
       
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