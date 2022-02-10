using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableUsuariosViewModel
    {
        public int id { get; set; }
        public string email { get; set; }

        public string nombre { get; set; }

        public string estado { get; set; }

        public string cliente { get; set; }

        public string supervisor { get; set; }
    }
}