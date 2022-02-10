using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class RutaTiendaViewModel
    {
        public int id { get; set; }
        public int? idRuta { get; set; }

        [Required]
        [Display(Name = "*Tienda")]
        public int? idTienda { get; set; }

        [Required]
        [Display(Name = "*Estado")]
        public int? idEstado { get; set; }

        [Required]
        [Display(Name = "*Municipio")]
        public int? idMunicipio { get; set; }

        [Required]
        [Display(Name = "*Clouster")]
        public int? idClouster { get; set; }

        [Required]
        [Display(Name = "*Factor Visita")]
        public int? idFactorVisita { get; set; }
    }
}