using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo razón social no admite mas de 50 caracteres")]
        [Display(Name = "*Razón Social")]
        public string razonSocial { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo domicilio no admite más de 100 caracteres")]
        [Display(Name = "*Domicilio")]
        public string domicilio { get; set; }

        [Required]
        [Display(Name = "*Estado")]
        public int? iddEstado { get;set;}

        [Required]
        [Display(Name = "*Municipio")]
        public int? idMunicipio { get; set; }

        [Display(Name = "Teléfono")]
        [Phone]
        [StringLength(10, ErrorMessage = "El teléfono no admite más de 10 caracteres")]
        public string telefono { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo domicilio no admite más de 50 caracteres")]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

    }
}