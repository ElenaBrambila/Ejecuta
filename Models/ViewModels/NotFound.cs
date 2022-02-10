using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.ViewModels
{
    public class NotFound
    {
        public NotFound(string mensaje)
        {
            this.Mensaje = mensaje;
        }
        public string Mensaje { get; set; }
    }
}