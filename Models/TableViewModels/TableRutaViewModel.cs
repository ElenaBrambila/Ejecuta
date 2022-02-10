using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableRutaViewModel
    {
        public int id { get; set; }
        public string codigo { get; set; }

        public string promotor { get; set; }
        public string estadoRuta { get; set; }

        public string perfil { get; set; }
        public string turno { get; set; }
    }
}