//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntegramsaUltimate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reporteTiendaFoto
    {
        public int id { get; set; }
        public Nullable<int> idReporteTienda { get; set; }
        public byte[] foto { get; set; }
        public Nullable<int> idFotoProposito { get; set; }
        public string comentario { get; set; }
        public string url { get; set; }
    
        public virtual cFotoProposito cFotoProposito { get; set; }
        public virtual reporteTienda reporteTienda { get; set; }
    }
}
