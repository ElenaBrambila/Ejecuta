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
    
    public partial class PlazaMunicipio
    {
        public int id { get; set; }
        public Nullable<int> idPlaza { get; set; }
        public Nullable<int> idMunicipio { get; set; }
    
        public virtual cmunicipio cmunicipio { get; set; }
        public virtual cPlaza cPlaza { get; set; }
    }
}
