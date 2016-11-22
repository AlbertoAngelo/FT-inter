using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterFood.Entity
{
    public class Cliente : Pessoa
    {
        public int IdCliente { get; set; }
        public string CPFCNPJ { get; set; }
    }
}