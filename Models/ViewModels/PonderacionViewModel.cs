using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class PonderacionViewModel
    {
        public int id { get; set; }
        public int? idCliente { get; set; }
        public string idSegmento { get; set; }
        public Nullable<decimal> ponderacion { get; set; }

    }
}