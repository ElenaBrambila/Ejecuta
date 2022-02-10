using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableInventarioViewModel
    {
        public int idInventario { get; set; }
        public decimal cantidadVendida { get; set; }
        public string numTienda { get; set; }
        public string sku { get; set; }
        public string status { get; set; }
        public int? numSemana { get; set; }
        public string EstatusComparado { get; set; }
        public int? cantidadInventario { get; set; }
        public decimal? diasDeInventario { get; set; }
    }
}