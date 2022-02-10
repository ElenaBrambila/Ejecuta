using IntegramsaUltimate.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class ReporteParticipacionCadena : System.Web.UI.Page
    {
        IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
        public usuario oUsuario = new usuario();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (usuario)Session["Usuario"];

                if (oUsuario != null)
                {

                    if (oUsuario.idTipoUsuario == 6) //Cliente
                    {
                        if (oUsuario.usuarioCliente != null)
                        {
                            int idCliente = (int)oUsuario.usuarioCliente.First().idCliente;
                            cboClientes.SelectedValue = idCliente.ToString();
                            cboClientes.Enabled = false;
                            //   cargarPromotores(idCliente, 0);


                        }
                    }

                }

                else
                {
                    Response.Redirect(@"\");
                }
            }
        }

        protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            if (cboClientes.SelectedIndex != -1)
            {
                DateTime fechaInicio = new DateTime(); //Rango de fecha que tiene el reporte
                bool validarFechaInicio = DateTime.TryParse(dtInicio.Text, out fechaInicio);
                DateTime fechaFin = new DateTime();
                bool validarFechaFin = DateTime.TryParse(dtFin.Text, out fechaFin);
                tablasContenido infoReporte = new tablasContenido();
                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarCliente)
                {
                    //Vamos a recorrer el grid para obtener las listas de cadenas nacionales
                    IList<int> listaNacional = new List<int>();
                    IList<int> listaRegional = new List<int>();
                    IList<int> listaMayoreo = new List<int>();
                    foreach (GridViewRow gvrow in GridView1.Rows)
                    {
                        int id = 0;
                        string cell_1_Value = GridView1.Rows[gvrow.RowIndex].Cells[0].Text;
                        string cell_2_Value = GridView1.Rows[gvrow.RowIndex].Cells[1].Text;
                        bool validarID = int.TryParse(cell_1_Value, out id);
                        var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                        var chRegional = gvrow.FindControl("CheckBox2") as CheckBox;
                        var chMayoreo = gvrow.FindControl("CheckBox3") as CheckBox;

                        if (checkbox.Checked)
                        {
                            listaNacional.Add(id);
                        }

                        if (chRegional.Checked)
                        {
                            listaRegional.Add(id);

                        }

                        if (chMayoreo.Checked)
                        {
                            listaMayoreo.Add(id);

                        }
                    }
                    DataTable datoCadena = (DataTable)infoReporte.dtPartCadenas(fechaInicio, fechaFin, idDeCliente);
                    var concentrado = (from registros in datoCadena.AsEnumerable() select registros).ToList();
                    var concentradoNacional = concentrado.Where(a => listaNacional.Contains(a.Field<int>("idCadena")));
                    var concentradoRegional = concentrado.Where(a => listaRegional.Contains(a.Field<int>("idCadena")));
                    var concentradoMayoreo = concentrado.Where(a => listaNacional.Contains(a.Field<int>("idCadena")));

                    IntegramsaUltimate.IntegramsaUltimateDataSet.cadenaDataTable tablaCadenaNacional = new IntegramsaUltimateDataSet.cadenaDataTable();
                    var results = db.cadena.Where(r => listaNacional.Contains(r.id));
                    foreach (cadena cust in results)
                    {
                        DataRow row = tablaCadenaNacional.NewRow();
                        row["id"] = cust.id;
                        row["nombre"] = cust.nombre;
                        tablaCadenaNacional.Rows.Add(row);
                    }

                    DataTable datoCadenaNacional = new DataTable();
                    DataTable datoCadenaRegional = new DataTable();
                    DataTable datoCadenaMayoreo = new DataTable();



                    if (concentradoNacional.Count() > 0)
                    {
                        datoCadenaNacional = concentradoNacional.CopyToDataTable();
                    }

                    if (concentradoRegional.Count() > 0)
                    {
                        datoCadenaRegional = concentradoRegional.CopyToDataTable();
                    }

                    if (concentradoMayoreo.Count() > 0)
                    {

                        datoCadenaMayoreo = concentradoMayoreo.CopyToDataTable();

                    }


                    DataTable datosReporte = (DataTable)infoReporte.dtPartSegmento(fechaInicio, fechaFin, idDeCliente);
                    //Datos de segmento producto
                    DataTable datoSegProducto = (DataTable)infoReporte.dtPartSegmentoProductos(fechaInicio, fechaFin, idDeCliente);
                    //Datos de segmento productos top
                    DataTable datoSegProductoTop = (DataTable)infoReporte.dtPartSegmentoProductosTop(fechaInicio, fechaFin, idDeCliente);
                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                    ReportDataSource reportDataSource2 = new ReportDataSource("DSProductos", datoSegProducto);
                    ReportDataSource reportDataSource3 = new ReportDataSource("DSProductosTop", datoSegProductoTop);
                    ReportDataSource reportDataSource4 = new ReportDataSource("DSCadenasNacional", (DataTable)tablaCadenaNacional);
                    ReportDataSource reportDataSource5 = new ReportDataSource("DSCadNacional", datoCadenaNacional);
                    ReportDataSource reportDataSource6 = new ReportDataSource("DSCadRegional", datoCadenaRegional);
                    ReportDataSource reportDataSource7 = new ReportDataSource("DSCadMayoreo", datoCadenaRegional);

                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource2);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource3);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource4);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource5);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource6);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource7);


                    //Parametros del reporte
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("rptCliente", cboClientes.SelectedItem.Text);

                    parameters[1] = new ReportParameter("rptFechas", fechaInicio.ToShortDateString() + " al " + fechaFin.ToShortDateString());
                    ReportViewer1.LocalReport.SetParameters(parameters);

                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();

                    GridView1.Visible = false;
                }
            }
        }

        protected void btnTodasCadenas_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.Visible == false)
            {
                GridView1.Visible = true;
            }

            else
            {
                GridView1.Visible = false;

            }
        }
    }
}