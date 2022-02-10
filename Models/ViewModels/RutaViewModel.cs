using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class RutaViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo codigo no admite más de 50 caracteres")]
        [Display(Name = "*Código")]
        public string codigo { get; set; }

        [Required]
        [Display(Name = "*Perfil")]
        public int? idPerfil { get; set; }

        [Required]
        [Display(Name = "*Turno")]
        public int? idTurno { get; set; }
        [Required]
        [Display(Name = "*Estado ruta")]
        public int? idEstadoRuta { get; set; }

        [Required]
        [Display(Name = "*Promotor")]
        public int? idPromotor { get; set; }

        [Required]
        [Display(Name = "*Cliente")]

        public int? idCliente { get; set; }
    }
}