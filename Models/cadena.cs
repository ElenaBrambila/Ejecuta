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
    
    public partial class cadena
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cadena()
        {
            this.formatoTienda = new HashSet<formatoTienda>();
            this.tienda = new HashSet<tienda>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> idGiroComercial { get; set; }
        public Nullable<int> idEstado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> sugerida { get; set; }
        public string cadenaSugerida { get; set; }
    
        public virtual cEstado cEstado { get; set; }
        public virtual cGiroComercial cGiroComercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formatoTienda> formatoTienda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tienda> tienda { get; set; }
    }
}
