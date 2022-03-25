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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.logErrorMobile = new HashSet<logErrorMobile>();
            this.logWebService = new HashSet<logWebService>();
            this.reporteIntinerarioPromotor = new HashSet<reporteIntinerarioPromotor>();
            this.reporteTienda = new HashSet<reporteTienda>();
            this.ruta = new HashSet<ruta>();
            this.usuario1 = new HashSet<usuario>();
            this.usuarioCliente = new HashSet<usuarioCliente>();
        }
    
        public int id { get; set; }
        public int idEstado { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> iddEstado { get; set; }
        public int idTipoUsuario { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string curp { get; set; }
        public string IMSS { get; set; }
        public byte[] foto { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string tokenSesionMovil { get; set; }
        public string codigoRecuperar { get; set; }
        public Nullable<int> idSupervisor { get; set; }
    
        public virtual cEstado cEstado { get; set; }
        public virtual cTipoUsuario cTipoUsuario { get; set; }
        public virtual destado destado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<logErrorMobile> logErrorMobile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<logWebService> logWebService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporteIntinerarioPromotor> reporteIntinerarioPromotor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporteTienda> reporteTienda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ruta> ruta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario1 { get; set; }
        public virtual usuario usuario2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarioCliente> usuarioCliente { get; set; }
    }
}
