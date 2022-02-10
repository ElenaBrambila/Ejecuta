using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableClientesViewModel
    {
        public int? id { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}