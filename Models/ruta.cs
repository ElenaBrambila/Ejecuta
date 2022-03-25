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
    
    public partial class ruta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ruta()
        {
            this.rutaIntinerario = new HashSet<rutaIntinerario>();
            this.rutaTienda = new HashSet<rutaTienda>();
        }
    
        public int id { get; set; }
        public Nullable<int> idPromotor { get; set; }
        public string codigoRuta { get; set; }
        public Nullable<int> idPerfil { get; set; }
        public Nullable<int> idTurno { get; set; }
        public Nullable<int> idEstado { get; set; }
        public Nullable<int> idEstadoRuta { get; set; }
        public Nullable<int> idCliente { get; set; }
    
        public virtual cEstado cEstado { get; set; }
        public virtual cEstadoRuta cEstadoRuta { get; set; }
        public virtual cliente cliente { get; set; }
        public virtual cPerfilRuta cPerfilRuta { get; set; }
        public virtual cTurnoRuta cTurnoRuta { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rutaIntinerario> rutaIntinerario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rutaTienda> rutaTienda { get; set; }
    }
}
