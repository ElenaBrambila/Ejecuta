using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteTiempoEfectivoViewModel
    {
        public int? idUsuarioPromotor { get; set; }
        public string Nombre { get; set; }
        
        public string dia1 { get; set; }
        public string dia2 { get; set; }
        public string dia3 { get; set; }
        public string dia4 { get; set; }
        public string dia5 { get; set; }
        public string dia6 { get; set; }
        public string total { get; set; }
    }
}