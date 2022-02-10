using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableEstatusViewModel
    {
        public int? id { get; set; }
        public string Nombre { get; set; }
        public int? rangoInferior { get; set; }
        public int? rangoSuperior { get; set; }
    }
}