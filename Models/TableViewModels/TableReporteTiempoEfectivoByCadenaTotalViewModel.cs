using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteTiempoEfectivoByCadenaTotalViewModel
    {
        public int? idCadena { get; set; }
        public string Nombre { get; set; }

        public double totalHoras { get; set; }

        public TimeSpan total { get; set; }
    }
}