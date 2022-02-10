using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegramsaUltimate.Models;
using Microsoft.Reporting.WebForms;

namespace IntegramsaUltimate
{
    public partial class ReporteFotosProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarCliente)
                {
                    DateTime fechaInicio = new DateTime();
                    bool validarFechaInicio = DateTime.TryParse(dtInicio.Text, out fechaInicio);
                    DateTime fechaFin = new DateTime();
                    bool validarFechaFin = DateTime.TryParse(dtFin.Text, out fechaFin);
                    int idDeProducto = 0;
                    bool validarProducto = int.TryParse(cboProductos.SelectedValue, out idDeProducto);
                    tablasContenido infoReporte = new tablasContenido();
                    DataTable datosReporte = (DataTable)infoReporte.dtFotosCiudadClienteFecha(fechaInicio, fechaFin, idDeCliente, idDeProducto);

                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }


        protected void btnTodosProductos_Click(object sender, ImageClickEventArgs e)
        {
            chkProductos.Visible = true;
        }
    }
}