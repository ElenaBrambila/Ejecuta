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
    public partial class ReporteFotoSimpleGeneral : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);

                var datosOrigin = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) })).ToList();
                var datosOrdenados = from p in datosOrigin orderby p.nombre select p;
                cboPromotor.DataSource = datosOrdenados;
                cboPromotor.DataValueField = "Id";
                cboPromotor.DataTextField = "nombre";
                cboPromotor.DataBind();

                chkPromotor.DataSource = datosOrdenados;
                chkPromotor.DataValueField = "Id";
                chkPromotor.DataTextField = "nombre";
                chkPromotor.DataBind();
            }

        }

        protected void btnTodosPromotores_Click(object sender, ImageClickEventArgs e)
        {
            chkPromotor.Visible = true;
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
                    tablasContenido infoReporte = new tablasContenido();
                    int idDePromotor = 0;
                    bool validarPromotor = int.TryParse(cboPromotor.SelectedValue, out idDePromotor);
                    DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFecha(fechaInicio, fechaFin, idDeCliente);
                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }


    }
}