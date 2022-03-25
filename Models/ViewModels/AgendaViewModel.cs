using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class AgendaViewModel
    {

        public int idRuta { get; set; }
        public int idTienda { get; set; }
        public int idDiaSemana { get; set; }
        public int orden { get; set; }
        public int numSemana { get; set; }
        public int Semana { get; set; }
        public int idPromotor { get; set; }
        public int idRutaTienda { get; set; }
        public int year { get; set; }

        public string mes { get; set; }
    }

}