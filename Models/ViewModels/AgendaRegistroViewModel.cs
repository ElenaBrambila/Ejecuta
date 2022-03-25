using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class AgendaRegistroViewModel
    {
        public int? id { get; set; }
        public int? idRutaTienda { get; set; }
        public string storeCheck { get; set; }
        public int Semana { get; set; }
        public int idDiaSemana { get; set; }

    }
}