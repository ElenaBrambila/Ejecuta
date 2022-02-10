using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class TiendaViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo nombre no admite mas de 50 caracteres")]
        [Display(Name = "*Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Giro")]
        public int? idGiro { get; set; }

        [Required]
        [Display(Name = "*Cadena")]
        public int? idCadena { get; set; }

        [Required]
        [Display(Name = "*Formato")]
        public int? idFormato { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El campo código no admite mas de 15 caracteres")]
        [Display(Name = "*Código")]
        public string codigo { get; set; }

        [Required]
        [Display(Name = "*Estado")]
        public int? iddEstado { get; set; }

        [Required]
        [Display(Name = "*Municipio")]
        public int? idMunicipio { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo calle no admite mas de 50 caracteres")]
        [Display(Name = "*Calle")]
        public string calle { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo número no admite mas de 50 caracteres")]
        [Display(Name = "*Número")]
        public string numero { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo colonia no admite mas de 50 caracteres")]
        [Display(Name = "*Colonia")]
        public string colonia { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "El campo código postal no admite mas de 5 caracteres")]
        [Display(Name = "*Código postal")]
        public string cp { get; set; }

        [Required]
        [Display(Name = "Latitud")]
        public string latitud { get; set; }

        [Required]
        [Display(Name = "Longitud")]
        public string longitud { get; set; }

    }
}