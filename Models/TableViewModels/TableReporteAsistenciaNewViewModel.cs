using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableReporteAsistenciaNewViewModel
    {
        public int? id {get;set;}
        public int? idCliente { get; set; }
        public string Plaza { get; set; }

        public string Promotor { get; set; }
        public string Cadena { get; set; }
        public string Tienda { get; set; }
        public string Determinante { get; set; }
        public DateTime? Fecha { get; set; }
        public string HoraEntrada { get; set; }
        public string Perimetro { get; set; }
        public string HoraSalida { get; set; }
        public string tiempoTienda { get; set; }

        public int? ano { get; set; }
        public int? numSemana { get; set; }



    }
}