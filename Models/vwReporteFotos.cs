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
    
    public partial class vwReporteFotos
    {
        public int id { get; set; }
        public string proposito { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string promotor { get; set; }
        public int idDUsuario { get; set; }
        public int idDTienda { get; set; }
        public string tienda { get; set; }
        public Nullable<int> idFormato { get; set; }
        public string formatoTienda { get; set; }
        public Nullable<int> idCliente { get; set; }
        public int idcMunicipio { get; set; }
        public string municipio { get; set; }
        public int idCadena { get; set; }
        public string cadena { get; set; }
        public Nullable<int> idPlaza { get; set; }
        public string plaza { get; set; }
        public Nullable<int> idFotoProposito { get; set; }
        public string comentario { get; set; }
        public string formater { get; set; }
    }
}
