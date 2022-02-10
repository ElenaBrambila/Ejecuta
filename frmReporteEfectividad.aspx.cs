using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegramsaUltimate.Models;


namespace IntegramsaUltimate
{
    public partial class frmReporteEfectividad : System.Web.UI.Page
    {
        public usuario oUsuario = new usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (usuario)Session["Usuario"];

                if (oUsuario != null)
                {

                    if (oUsuario.idTipoUsuario == 6)
                    {
                        if (oUsuario.usuarioCliente != null)
                        {
                            int idCliente = (int)oUsuario.usuarioCliente.First().idCliente;
                            cboClientes.SelectedValue = idCliente.ToString();
                            cboClientes.Enabled = false;

                        }
                    }

                }

                else
                {
                    Response.Redirect(@"\");
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
 
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
                    //Obtenemos valores de días de rango del reporte
                    TimeSpan dias = fechaFin - fechaInicio;
                    int totalDias = dias.Days;
                    totalDias = totalDias + 1;
                    DataTable datosReporte = (DataTable)infoReporte.dtRepAsistenciaGeneral(fechaInicio, fechaFin, idDeCliente);
                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet2", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    //Parametros del reporte
                    ReportParameter[] parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("rptDias", totalDias.ToString());
                    ReportViewer1.LocalReport.SetParameters(parameters);

                    ReportViewer1.LocalReport.Refresh();


                }
            }
        }
    }
}