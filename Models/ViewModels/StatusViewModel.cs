using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class StatusViewModel
    {
        public string Tienda { get; set; }
        public string Cadena { get; set; }
        public string Producto { get; set; }
        public int Semana { get; set; }
        [Display(Name = "Estatus Actual")]
        public string Status { get; set; }
        [Display(Name ="Estatus Comparado")]
        public string StatusComparativo { get; set; }
        public string Color { get; set; }
    }
}