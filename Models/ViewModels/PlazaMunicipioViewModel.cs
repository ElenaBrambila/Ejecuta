using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class PlazaMunicipioViewModel
    {
         public int id { get; set; }
        
        public int? idPlaza { get; set; }
        

        public int? idcMunicipio { get; set; }


        [Display(Name = "*Estado")]
        public int? iddEstado { get; set; }

        [Required]
        [Display(Name = "*Municipio")]
        public int? idMunicipio { get; set; }
    
    }
}