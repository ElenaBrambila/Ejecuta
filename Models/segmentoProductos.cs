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
    
    public partial class segmentoProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public segmentoProductos()
        {
            this.reporteTiendaFrentes = new HashSet<reporteTiendaFrentes>();
        }
    
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> idSegmento { get; set; }
        public int idSegmentoProducto { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual segmentos segmentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporteTiendaFrentes> reporteTiendaFrentes { get; set; }
    }
}
