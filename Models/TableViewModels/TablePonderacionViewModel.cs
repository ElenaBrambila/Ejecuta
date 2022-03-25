using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TablePonderacionViewModel
    {
        public int id { get; set; }
        public string segmento { get; set; }
        public string cliente { get; set; }
        public Nullable<decimal> ponderacion { get; set; }
        
    }
}