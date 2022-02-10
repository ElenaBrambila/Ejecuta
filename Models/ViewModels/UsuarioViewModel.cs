using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    /// <summary>
    /// View model de usuario basico
    /// </summary>
    public class UsuarioViewModel
    {
        public byte[] fotoUsuario { get; set; }

        [Required]
        public int idTipoUsuario { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El campo correo electrónico no admite mas de 100 caracteres")]
        [Display(Name = "*Correo electrónico")]
        public string email { get; set; }

        [Required]
        [Display(Name = "*Contraseña")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La propiedad {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string pass1 { get; set; }

        [Required]
        [Compare("pass1")]
        [Display(Name = "*Confirmar contraseña")]

        public string pass2 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo nombre no admite mas de 50 caracteres")]
        [Display(Name = "*Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo apellido paterno no admite mas de 50 caracteres")]
        [Display(Name = "*Apellido paterno")]
        public string paterno { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo apellido materno no admite mas de 50 caracteres")]
        [Display(Name = "*Apellido materno")]
        public string materno { get; set; }

        [Required]
        [Display(Name="*Estado")]
        public int? estado { get; set; }

        [Required]
        [Display(Name = "*Fecha de nacimiento")]
        public DateTime? fechaNacimiento { get; set; }

       
        [StringLength(20, ErrorMessage = "El campo curp no admite mas de 12 caracteres")]
        [Display(Name = "CURP")]
        public string curp { get; set; }

     
        [StringLength(12, ErrorMessage = "El campo imss no admite mas de 12 caracteres")]
        [Display(Name = "IMSS")]
        public string imss { get; set; }

        [Required]
        [Phone]
        [StringLength(14, ErrorMessage = "El campo telefono no admite mas de 14 caracteres")]
        [Display(Name = "*Teléfono")]
        public string telefono { get; set; }

   
        [Phone]
        [StringLength(14, ErrorMessage = "El campo celular no admite mas de 14 caracteres")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

    }

    public class UsuarioEditarViewModel
    {
        public byte[] fotoUsuario { get; set; }

        [Required]
        public int idTipoUsuario { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El campo correo electrónico no admite mas de 100 caracteres")]
        [Display(Name = "*Correo electrónico")]
        public string email { get; set; }

        
        [Display(Name = "*Contraseña")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La propiedad {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string pass1 { get; set; }

        
        [Compare("pass1")]
        [Display(Name = "*Confirmar contraseña")]

        public string pass2 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo nombre no admite mas de 50 caracteres")]
        [Display(Name = "*Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo apellido paterno no admite mas de 50 caracteres")]
        [Display(Name = "*Apellido paterno")]
        public string paterno { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El campo apellido materno no admite mas de 50 caracteres")]
        [Display(Name = "*Apellido materno")]
        public string materno { get; set; }

        [Required]
        [Display(Name = "*Estado")]
        public int? estado { get; set; }

        [Required]
        [Display(Name = "*Fecha de nacimiento")]
        public DateTime? fechaNacimiento { get; set; }


        [StringLength(20, ErrorMessage = "El campo curp no admite mas de 12 caracteres")]
        [Display(Name = "CURP")]
        public string curp { get; set; }


        [StringLength(12, ErrorMessage = "El campo imss no admite mas de 12 caracteres")]
        [Display(Name = "IMSS")]
        public string imss { get; set; }

        [Required]
        [Phone]
        [StringLength(14, ErrorMessage = "El campo telefono no admite mas de 14 caracteres")]
        [Display(Name = "*Teléfono")]
        public string telefono { get; set; }


        [Phone]
        [StringLength(14, ErrorMessage = "El campo celular no admite mas de 14 caracteres")]
        [Display(Name = "Celular")]
        public string celular { get; set; }



        public int id { get; set; }
    }
}