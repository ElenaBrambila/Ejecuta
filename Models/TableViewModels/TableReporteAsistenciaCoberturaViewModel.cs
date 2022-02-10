using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteAsistenciaCoberturaViewModel
    {
        public string Nombre { get; set; }
        public int? asignadas { get; set; }

        public int? cubieras { get; set; }

        public decimal? cobertura { get; set; }

        public int? idUsuarioPromotor { get; set; }
    }
}