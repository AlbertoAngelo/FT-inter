using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterFood.Entity
{
    public class Truck : Pessoa
    {
        public int IdTruck { get; set; }
        public string CNPJ { get; set; }
        public string NomeTruck { get; set; }
        public string DescricaoTruck { get; set; }
        public byte Logo { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}