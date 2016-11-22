using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterFood.Entity
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoPessoa { get; set; }
        public int Status { get; set; }
    }
}