using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate
{
    public class tablasContenido
    {

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
            adaptador.FillByClientePlazaFecha(tabla, idCliente, startDate, endDate, idPlaza);
            return tabla;
        }

        public DataTable dtFotosPromotorClienteFecha(DateTime startDate, DateTime endDate, int idCliente, int idPlaza)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClientePromotorFecha(tabla, idCliente, startDate, endDate, idPlaza);
            return tabla;
        }



        public DataTable dtFotosCiudadClienteFecha(DateTime startDate, DateTime endDate, int idCliente, int idCiudad)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClienteCiudadFecha(tabla, idCliente, startDate, endDate, idCiudad);
            return tabla;
        }

        public DataTable dtFotosClienteFecha(DateTime startDate, DateTime endDate, int idCliente)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClienteFecha(tabla, idCliente, startDate, endDate);
            return tabla;
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
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClienteFechaCadena(tabla, idCliente, startDate, endDate, idDeCadena);
            return tabla;
        }

        public DataTable dtFotosClienteFormato(DateTime startDate, DateTime endDate, int idCliente, int idDeFormato)
        {
            IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter adaptador = new IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter();
            IntegramsaUltimateDataSet.vwReporteFotosDataTable tabla = new IntegramsaUltimateDataSet.vwReporteFotosDataTable();
            adaptador.FillByClienteFechaFormato(tabla, idCliente, startDate, endDate, idDeFormato);
            return tabla;
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