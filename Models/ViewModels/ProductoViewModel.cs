using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int id { get; set; }
        public int? idCliente { get; set; }
        public string nombre { get; set; }
        public string presentacion { get; set; }
        public string sku { get; set; }

    }
}