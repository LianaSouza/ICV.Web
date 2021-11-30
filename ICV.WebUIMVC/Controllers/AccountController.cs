using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICV.WebUIMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ICV.WebUIMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && string.IsNullOrEmpty(senha))
                {
                    ViewBag.retorno = "Erro";
                    return RedirectToAction(nameof(Login));
                }

                ClaimsIdentity identity = null;
                bool isAuthenticated = false;

                var loginModel = new LoginModel();

                loginModel.Email = email;
                loginModel.Senha = senha;

                //loginModel.Login(loginModel);

                if (loginModel.Login(loginModel) == true)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, email),
                        new Claim(ClaimTypes.Role, "Admin")
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;

                    if (isAuthenticated)
                    {
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction ("Index", "Curso");
                    }
                    ////Create the identity for the user  
                    //var identity = new ClaimsIdentity(new[] {
                    //new Claim(ClaimTypes.Name, email),
                    //new Claim(ClaimTypes.Role, "Admin")
                    //}, CookieAuthenticationDefaults.AuthenticationScheme);
                }
                else
                {
                    ViewBag.retorno = "Erro";
                    return View();
                }
            }
            catch (Exception erro)
            {
                return View(erro);
            }

            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}