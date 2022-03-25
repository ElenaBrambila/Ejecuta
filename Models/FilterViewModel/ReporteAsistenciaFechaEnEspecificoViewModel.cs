﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.FilterViewModel
{
    public class ReporteAsistenciaFechaEnEspecificoViewModel
    {
        public int? idPlaza { get; set; }
        public int? idCliente { get; set; }
        public int? idPromotor { get; set; }
        public int? idCoordinador { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}