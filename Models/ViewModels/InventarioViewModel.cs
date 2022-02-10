using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class InventarioViewModel
    {
        public int? IdTienda { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        [Display(Name = "Semana")]
        public int? NumSemana { get; set; }
        [Display(Name = "Ventas")]
        public string Cantidad { get; set; }
        [Display(Name = "Estatus")]
        public string EstatusInv { get; set; }
        public string Sku { get; set; }
        [Display(Name = "Tienda")]
        public string NumTienda { get; set; }
        public string Cadena { get; set; }
        public int IdInventario { get; set; }
        public string Inventario { get; set; }
        public string DiasInventario { get; set; }
    }
}