using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class CadenaViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo nombre no admite mas de 50 caracteres")]
        [Display(Name = "*Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "*Giro")]
        public int? idGiro { get; set; }
    }
}