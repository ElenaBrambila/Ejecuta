using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;

namespace IntegramsaUltimate
{
    public class tablasContenido
    {
        //REPORTE TIEMPO EFECTIVO

        public DataTable dtRepAsistenciaGeneral(DateTime startDate, DateTime endDate, int idCliente)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteEfectividadDataTable tabla = new IntegramsaUltimateDataSet.vwReporteEfectividadDataTable();
            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwReporteEfectividadTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteEfectividadTableAdapter();

                string info = adaptador.Connection.ConnectionString;
                adaptador.FillByClienteFecha(tabla, idCliente, startDate, endDate);
                return tabla;
                //Hay que verificar la conexion en la linea 15846 en el DataSet.xsd
                //if ((this._commandCollection == null))
                //{
                //    this.InitCommandCollection();
                //    _commandCollection[0].CommandTimeout = 0;
                //    _commandCollection[1].CommandTimeout = 0;

                //}
                //_commandCollection[0].CommandTimeout = 0;
                //_commandCollection[1].CommandTimeout = 0;
                //return this._commandCollection;
            }

            catch (Exception error)
            {
                //   string errorB = error.InnerException.Message.ToString();
                //  string errorA = tabla.GetErrors()[0].RowError.ToString();
                return tabla;

            }
        }





        //FIN REPORTE TIEMPO EFECTIVO

        public DataTable dtFotosBasicoFecha(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotocFotoTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotocFotoTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotocFotoDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotocFotoDataTable();
            adaptador.FillBy(tabla, idCliente, startDate, endDate);
            return tabla;
        }

        public DataTable dtFotosPlazaClienteFecha(DateTime startDate, DateTime endDate, int idCliente, int idPlaza)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClientePlazaFecha(tabla, idCliente, startDate.ToShortDateString(), endDate.ToShortDateString(), idPlaza);
            return tabla;
        }

        public DataTable dtFotosPromotorClienteFecha(DateTime startDate, DateTime endDate, int idCliente, int idPromotor)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClientePromotorFecha(tabla, idCliente, startDate, endDate, idPromotor);
            return tabla;
        }

        public DataTable dtFotosPromotorClienteFechaR(DateTime startDate, DateTime endDate, int idCliente, int idPromotor)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClientePromotorFecha(tabla, idCliente, startDate, endDate, idPromotor);
            return tabla;
        }


        public DataTable dtFotosCiudadClienteFecha(DateTime startDate, DateTime endDate, int idCliente, int idCiudad)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            try
            {

                IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
                adaptador.FillByClienteCiudadFecha(tabla, idCliente, idCiudad, startDate.ToShortDateString(), endDate.ToShortDateString());
                return tabla;

            }

            catch (Exception)
            {
                //   string error = tabla.GetErrors()[0].RowError.ToString();
                return tabla;

            }
        }

        public DataTable dtFotosClienteFecha(DateTime startDate, DateTime endDate, int idCliente)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();

            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
                adaptador.FillByClienteFecha(tabla, idCliente, startDate.ToString("MM-dd-yyyy HH:mm:ss"), endDate.ToString("MM-dd-yyyy HH:mm:ss"));
                return tabla;
            }

            catch (Exception e)
            {
                // string error = tabla.GetErrors()[0].RowError.ToString();
                return tabla;

            }


            //Filtro por entitys
            //var filteredRows =
            //     from row in table.Rows.OfType<DataRow>()
            //     where (DateTime)row[0] >= startDate
            //     where (DateTime)row[0] <= endDate
            //     orderby (int)row[1] descending
            //     select row;

            // var filteredTable = table.Clone();

            // filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

            // return filteredTable;


        }


        public DataTable dtFotosClientePromotor(DateTime startDate, DateTime endDate, int idCliente, int idDePromotor)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClientePromotorFecha(tabla, idCliente, startDate, endDate, idDePromotor);
            return tabla;
        }

        public DataTable dtFotosClienteCadena(DateTime startDate, DateTime endDate, int idCliente, int idDeCadena)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
                adaptador.FillByClienteFechaCadena(tabla, idCliente, startDate.ToShortDateString(), endDate.ToShortDateString(), idDeCadena);
                return tabla;
            }

            catch (Exception)
            {

                return tabla;

            }
        }

        public DataTable dtFotosClienteFormato(DateTime startDate, DateTime endDate, int idCliente, int idDeFormato)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();

            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
                adaptador.FillByClienteFechaFormato(tabla, idCliente, startDate.ToShortDateString(), endDate.ToShortDateString(), idDeFormato);
                return tabla;
            }

            catch (Exception)
            {

                return tabla;

            }
        }

        public DataTable dtFotosClienteFormatos(DateTime startDate, DateTime endDate, int idCliente, string idDeFormato)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            var starD = startDate.ToString("MM-dd-yyyy HH:mm:ss");
            var endD = endDate.ToString("MM-dd-yyyy HH:mm:ss");
            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
                //adaptador.FillByClienteFechaFormatos(tabla, idCliente, starD, endD, idDeFormato);

                var io = adaptador.FillByProposito(idCliente, startDate, endDate, idDeFormato);
                return tabla;
            }

            catch (Exception e)
            {

                return tabla;

            }
        }

        //public DataTable dtFotosClienteCadenaFecha(DateTime startDate, DateTime endDate, int idCliente)
        //{
        //    var buscarFoto = from p
        //    //Filtro por entitys
        //    //var filteredRows =
        //    //     from row in table.Rows.OfType<DataRow>()
        //    //     where (DateTime)row[0] >= startDate
        //    //     where (DateTime)row[0] <= endDate
        //    //     orderby (int)row[1] descending
        //    //     select row;

        //    // var filteredTable = table.Clone();

        //    // filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

        //    // return filteredTable;


        //}


        //Tablas de participación
        public DataTable dtPartSegmento(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSetTableAdapters.vwPartSegPromedioTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartSegPromedioTableAdapter();
            IntegramsaUltimateDataSet.vwPartSegPromedioDataTable tabla = new IntegramsaUltimateDataSet.vwPartSegPromedioDataTable();
            adaptador.FillByFecha(tabla, idCliente, startDate, endDate);
            return tabla;
        }

        public DataTable dtPartSegmentoProductos(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdPromTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdPromTableAdapter();
            IntegramsaUltimateDataSet.vwPartSegFechaProdPromDataTable tabla = new IntegramsaUltimateDataSet.vwPartSegFechaProdPromDataTable();
            adaptador.FillByFechaCliente(tabla, startDate.ToShortDateString(), endDate.ToShortDateString(), idCliente);
            return tabla;
        }

        public DataTable dtPartSegmentoProductosTop(DateTime startDate, DateTime endDate, int idCliente)
        {
            //Se modificó la línea 10082 para el command collection y quitar el error del tiempo de espera.
            IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdTopTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdTopTableAdapter();
            IntegramsaUltimateDataSet.vwPartSegFechaProdTopDataTable tabla = new IntegramsaUltimateDataSet.vwPartSegFechaProdTopDataTable();
            adaptador.FillBy1(tabla, idCliente, startDate, endDate);
            return tabla;
        }

        public DataTable dtPartCadenas(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSet.vwPartSegFechaProdCadPromDataTable tabla = new IntegramsaUltimateDataSet.vwPartSegFechaProdCadPromDataTable();

            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdCadPromTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartSegFechaProdCadPromTableAdapter();
                adaptador.FillByFecha(tabla, idCliente, startDate.ToShortDateString(), endDate.ToShortDateString());
                return tabla;
            }

            catch (Exception)
            {
                string error = tabla.GetErrors()[0].RowError.ToString();
                return tabla;

            }
        }

        //Tiene el calculo basado en la suma de frentes de todos los productos en un reporte de tienda contra el segmento
        public DataTable dtPartCadenas2(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSet.vwPartCadFechaDataTable tabla = new IntegramsaUltimateDataSet.vwPartCadFechaDataTable();
            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwPartCadFechaTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartCadFechaTableAdapter();
                adaptador.FillByFecha(tabla, idCliente, startDate.ToShortDateString(), endDate.ToShortDateString());
                return tabla;
            }

            catch (Exception)
            {
                //string error = tabla.GetErrors()[0].RowError.ToString();
                return tabla;

            }
        }

        public DataTable dtPartPromotoresHanCapturado(int idCliente, DateTime startDate, DateTime endDate)
        {
            IntegramsaUltimateDataSet.vwPartPromTerminadosDataTable tabla = new IntegramsaUltimateDataSet.vwPartPromTerminadosDataTable();
            try
            {
                IntegramsaUltimateDataSetTableAdapters.vwPartPromTerminadosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwPartPromTerminadosTableAdapter();
                adaptador.FillByClienteFecha(tabla, idCliente, startDate, endDate);
                return tabla;
            }

            catch (Exception)
            {

                return tabla;

            }

        }

    }
}