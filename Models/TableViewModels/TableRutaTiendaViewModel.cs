using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableRutaTiendaViewModel
    {
        public int id { get; set; }

        public int? idTienda { get; set; }

        public string codigo { get; set; }

        public string cadena { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string ciudad { get; set; }
        public string formato { get; set; }
        public string clouster { get; set; }
        public string visitas { get; set; }

    }
}