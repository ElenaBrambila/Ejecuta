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
    
    public partial class logErrorMobile
    {
        public int id { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<System.DateTime> fechaMobile { get; set; }
        public string error { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
