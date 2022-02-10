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
    public partial class ReporteFotoSimple : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();
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
                            cargarPromotores(idCliente,0);

                            if (Page.Request["e"] != null)
                            {

                                lblMensaje.Text = "Se descargaron correctamente las imagenes. Por favor selecciona un rango de fechas y presiona sobre el botón de 'Generar'";
                            }
                        }
                    }

                }

                else
                {
                    Response.Redirect(@"\");
                }
            }

        }

        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                cargarPromotores(0,1);
            }

        }

        private void cargarPromotores(int indice, int procedencia)
        {
            //1 es que viene del cambio del combo - 0 es del loading

            int idDeCliente = 0;
            bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);

            if (procedencia == 0)
            {
                idDeCliente = indice;
            }

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

        protected void btnTodosPromotores_Click(object sender, ImageClickEventArgs e)
        {
            chkPromotor.Visible = true;
        }

        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            generarReporte();
        }

        private void generarReporte()
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
                    if (chkFiltrarPromotor.Checked == true)
                    {
                        int idDePromotor = 0;
                        bool validarPromotor = int.TryParse(cboPromotor.SelectedValue, out idDePromotor);
                        DataTable datosReporte = (DataTable)infoReporte.dtFotosPromotorClienteFecha(fechaInicio, fechaFin, idDeCliente, idDePromotor);
                        ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                        ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);

                        ReportViewer1.LocalReport.EnableExternalImages = true;
                        ReportViewer1.LocalReport.Refresh();
                    }


                    else
                    {

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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.RawUrl);
        }
    }
}