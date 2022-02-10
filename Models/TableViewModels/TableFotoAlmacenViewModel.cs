using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
    public class TableFotoAlmacenViewModel
    {
        public int id { get; set; }
        public DateTime? fecha { get; set; }

        public string observaciones { get; set; }
        public string existeFirma { get; set; }

        public string existeFotoUnica { get; set; }
        public string existeFotoConcurso { get; set; }
        public string existeFotoAntesDespues { get; set; }

        public string nombreTienda { get; set; }

        public string encargado { get; set; }

        public string codigoRuta { get; set; }
    }
}