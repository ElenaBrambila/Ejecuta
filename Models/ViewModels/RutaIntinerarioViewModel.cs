using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class RutaIntinerarioViewModel
    {
        public int idRuta { get; set; }
        public int idTienda { get; set; }
        public int idDiaSemana { get; set; }
        public int orden { get; set; }
        public int numSemana { get; set; }
    }

}