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
    
    public partial class fnReporteAsistenciaFechaEspecifica_Result
    {
        public int id { get; set; }
        public Nullable<int> idCliente { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string PLAZA { get; set; }
        public Nullable<System.DateTime> Entrada { get; set; }
        public Nullable<System.DateTime> Salida { get; set; }
        public string tiempoEfectivo { get; set; }
        public Nullable<int> tiempoEfectivoMinutos { get; set; }
        public Nullable<int> tiendasVisitadas { get; set; }
        public Nullable<int> tiendasAVisitar { get; set; }
        public Nullable<int> dentroPerimetro { get; set; }
        public Nullable<int> fueraPerimetro { get; set; }
    }
}
