//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntegramsaUltimate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReporteTiendaSegmento
    {
        public Nullable<int> idreporteTienda { get; set; }
        public Nullable<int> idSegmento { get; set; }
        public Nullable<int> cantidadSegmento { get; set; }
        public int id { get; set; }
    
        public virtual reporteTienda reporteTienda { get; set; }
        public virtual segmentos segmentos { get; set; }
    }
}
