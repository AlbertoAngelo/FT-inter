using InterFood.Entity;
using InterFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterFood.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            TruckModel model = new TruckModel();
            Pessoa pessoa = Session["truck"] as Pessoa;
            Truck truck = model.Read(pessoa.IdPessoa);
            
            ViewBag.Nome = truck.Nome;
            ViewBag.NomeTruck = truck.NomeTruck;

            return View(truck);
        }
        public ActionResult InfoGerais()
        {
            return View();
        }
    }
}