using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteAsistenciaFechaEnEspecificoViewModel
    {
        public string plaza { get; set; }
        public string promotor { get; set; }
        public string tiempoEfectivo { get; set; }
        public DateTime? fecha { get; set; }

        public DateTime? entrada { get; set; }

        public DateTime? salida { get; set; }

        public int? tiendasVisitadas { get; set; }
        public int? tiendasAVisitar { get; set; }

        public int? tiendasNoVisitadas { get; set; }

        public int? dentroPerimetro { get; set; }
        public int? fueraPerimetro { get; set; }


    }
}