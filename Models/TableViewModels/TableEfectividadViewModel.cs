using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.TableViewModels
{
        public class TableEfectividadNewViewModel
    {
        //filtros***
        public int? IdCliente { get; set; }
        public int? IdPromotor { get; set; }
        public int? IdCoordinador { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        //datos***
        public int? Id { get; set; }
        public string Cliente { get; set; }
        public string CodigoRuta { get; set; }
        public string Coordinador { get; set; }
        public string Promotor { get; set; }
        public string Cadena { get; set; }
        public string Det { get; set; }
        public int? IdTienda { get; set; }
        public string Tienda { get; set; }
        public List<Info> Info { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<string> UniqueProductList { get; set; }
        public int Acumlado { get; set; }
        public string Nombre { get; set; }
        public int? Ta { get; set; }
        public int? Cob { get; set; }
        public int? Fp { get; set; }
        public int? Dp { get; set; }
    }

}