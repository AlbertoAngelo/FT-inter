using InterFood.Entity;
using InterFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterFood.Controllers
{
    public class InformacoesController : Controller
    {
        // GET: Informacoes
        public ActionResult Index()
        {
            TruckModel model = new TruckModel();
            Pessoa pessoa = Session["truck"] as Pessoa;
            Truck truck = model.Read(pessoa.IdPessoa);

            return View(truck);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Truck truck = new Truck();
            truck.IdTruck = int.Parse(form["IdTruck"]);
            truck.IdPessoa = int.Parse(form["IdPessoa"]);
            truck.Nome = form["Nome"];
            truck.Telefone = form["Telefone"];
            truck.Celular = form["Celular"];

            using (TruckModel model = new TruckModel())
            {
                model.UpdateInformacoes(truck);
                Session["truck"] = truck;

                return RedirectToAction("Index", "Admin");
            }
        }
    }
}