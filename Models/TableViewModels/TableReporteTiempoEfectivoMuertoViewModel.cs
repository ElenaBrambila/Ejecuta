using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteTiempoEfectivoMuertoViewModel
    {
        public int? idUsuarioPromotor { get; set; }
        public string Nombre { get; set; }

        public string tiempoEfectivo { get; set; }
        public string tiempoMuerto { get; set; }

        public decimal? efectivo { get; set; }
    }
}