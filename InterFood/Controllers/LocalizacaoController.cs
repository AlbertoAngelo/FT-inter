using InterFood.Entity;
using InterFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterFood.Controllers
{
    public class LocalizacaoController : Controller
    {
        // GET: Localizacao
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
            truck.CEP = form["CEP"];
            truck.Endereco = form["Endereco"];
            truck.Numero = form["Numero"];
            truck.Bairro = form["Bairro"];
            truck.Cidade = form["Cidade"];
            truck.Estado = form["Estado"];
            truck.Referencia = form["Referencia"];
            truck.IdTruck = int.Parse(form["IdTruck"]);
            truck.IdPessoa = int.Parse(form["IdPessoa"]);

            using (TruckModel model = new TruckModel())
            {
                model.UpdateLocalizacao(truck);
                Session["truck"] = truck;

                return RedirectToAction("Index", "Admin");
            }
        }
    }
}