using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterFood.Entity
{
    public class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public int IdTruck { get; set; }
        public int IdCliente { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }
        public int Status { get; set; }
    }
}