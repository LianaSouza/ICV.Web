using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebUIMVC.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            AlunoModel Colaborador = new AlunoModel();
            return View(Colaborador.Buscar());
        }

        // GET: Aluno/Details/5
        public ActionResult Detalhes(int id)
        {
           AlunoModel Colaborador = new AlunoModel();
            return View(Colaborador.Buscar(id));
        }

        // GET: Aluno/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AlunoModel objeto)
        {
            try
            {
                // TODO: Add insert logic here
                new Models.AlunoModel().Cadastrar(objeto);


                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, AlunoModel objeto)
        {
            try
            {
                // TODO: Add update logic here
                new AlunoModel().Editar(objeto, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Remover(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, AlunoModel objeto)
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