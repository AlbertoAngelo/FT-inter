using InterFood.Entity;
using InterFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterFood.Controllers
{
    public class CadastrarController : Controller
    {
        // GET: Cadastrar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Truck truck = new Truck();
            truck.NomeTruck = form["nomeTruck"];

            if(truck.NomeTruck == "")
            {
                Cliente cliente = new Cliente();
                cliente.Nome = form["name"];
                cliente.Telefone = form["phone"]; 
                cliente.Celular = form["cel"];
                cliente.Email = form["email"];
                cliente.Senha = form["senha"];
                cliente.TipoPessoa = 1;
                cliente.Status = 1;
                cliente.CPFCNPJ = form["cpf"];

                using (ClienteModel model = new ClienteModel())
                {
                    model.Create(cliente);
                }
                return Redirect("Home");
            }
            else
            {
                truck.Nome = form["name"];
                truck.Telefone = form["phone"];
                truck.Celular = form["cel"];
                truck.Email = form["email"];
                truck.Senha = form["senha"];
                truck.TipoPessoa = 0;
                truck.Status = 1;
                truck.CNPJ = form["cnpj"];
                truck.DescricaoTruck = form["descricao"];
                truck.CEP = form["cep"];
                truck.Estado = form["uf"];
                truck.Cidade = form["cidade"];
                truck.Bairro = form["bairro"];
                truck.Endereco = form["endereco"];
                truck.Numero = form["numero"];
                truck.Referencia = form["referencia"];
                truck.Latitude = "1";
                truck.Longitude = "1";
                truck.Logo = 123;

                using (TruckModel model = new TruckModel())
                {
                    model.Create(truck);
                }
                return Redirect("Login");
                    
            }
        }
    }
}