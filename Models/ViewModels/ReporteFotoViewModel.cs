using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class ReporteFotoViewModel
    {
        public string proposito { get; set; }
        public int? idFotoNueva { get; set; }
        public int? idFotoVieja { get; set; }

        public byte[] fotoNueva { get; set; }

        public byte[] fotoVieja { get; set; }

        public string observaciones { get; set; }
        public string codigoReporte { get; set; }

        public string plaza { get; set; }
        public string cadena { get; set; }
        public string nombreTienda { get; set; }
        public string determinante { get; set; }

        public string promotor { get; set; }
    }

}