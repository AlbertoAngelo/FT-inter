using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterFood.Entity
{
    public class Cardapio
    {
        public int IdCardapio { get; set; }
        public int IdTruck { get; set; }
        public string NomeItem { get; set; }
        public string DescricaoItem { get; set; }
        public int Status { get; set; }
    }
}