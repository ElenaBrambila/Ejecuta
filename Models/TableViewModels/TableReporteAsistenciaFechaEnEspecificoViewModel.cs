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
        public string cliente { get; set; }
        public string coordinador { get; set; }
        public string tiempoEfectivo { get; set; }
        public string tiempoTraslado { get; set; }
        public string tiempoTotal { get; set; }
        public DateTime? fecha { get; set; }

        public string entrada { get; set; }

        public string salida { get; set; }

        public int? tiendasVisitadas { get; set; }
        public int? tiendasAVisitar { get; set; }

        public int? tiendasNoVisitadas { get; set; }

        public int? dentroPerimetro { get; set; }
        public int? fueraPerimetro { get; set; }
        public string ruta { get; set; }
        public string turno { get; set; }


    }
}