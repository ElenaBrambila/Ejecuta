using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteEfectividadNewViewModel
    {
        public string cliente { get; set; }
        public string nombre { get; set; }
        public string codigoRuta { get; set; }
        public string coordinador { get; set; }
        public string promotor { get; set; }
        public string cadena { get; set; }
        public string det { get; set; }
        public string tienda { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<Info> info { get; set; }
        public List<string> uniquePromotorList { get; set; }

    }
    public class Info
    {
        public string nombre { get; set; }
        public int? ta { get; set; }
        public int? cob { get; set; }
        public int? fp { get; set; }
        public int? dp { get; set; }
    }

}