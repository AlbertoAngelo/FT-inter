using InterFood.Entity;
using InterFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterFood.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string senha)
        {
            using (PessoaModel model = new PessoaModel())
            {
                Pessoa login = model.Login(email, senha);
                if (login != null)
                {
                    if(login.TipoPessoa == 1)
                    { 
                        return Redirect("Home");
                    }
                    else
                    {
                        Session["truck"] = login;
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            ViewBag.Mensagem = "Email e senha inválido";
            return View();
        }
    }
}