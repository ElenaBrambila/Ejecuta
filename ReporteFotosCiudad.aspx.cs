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
    public partial class ReporteFotosCiudad : System.Web.UI.Page
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
                    int idDeCiudad = 0;
                    bool validarCiudad = int.TryParse(cboCiudad.SelectedValue, out idDeCiudad);
                    tablasContenido infoReporte = new tablasContenido();
                    DataTable datosReporte = (DataTable)infoReporte.dtFotosCiudadClienteFecha(fechaInicio, fechaFin, idDeCliente,idDeCiudad);

                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }

        protected void btnGenerarPlaza_Click(object sender, ImageClickEventArgs e)
        {

            generarPlazaRep();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.RawUrl);
        }
        private void generarPlazaRep()
        { 
            try
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
                        int idDePlaza = 0;
                        bool validarPlaza = int.TryParse(cboPlaza.SelectedValue, out idDePlaza);

                        tablasContenido infoReporte = new tablasContenido();
                        DataTable datosReporte = (DataTable)infoReporte.dtFotosPlazaClienteFecha(fechaInicio, fechaFin, idDeCliente, idDePlaza);
                        ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                        ReportViewer1.LocalReport.ReportPath = "rptRepFotosSimple.rdlc";
                        ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                        ReportViewer1.LocalReport.EnableExternalImages = true;
                        ReportViewer1.LocalReport.Refresh();
                    }

                }


            }


            catch (Exception error)
            {
                lblMensajePlaza.Text = error.InnerException.ToString();
                
            }
        }

        protected void btnTodasCiudades_Click(object sender, ImageClickEventArgs e)
        {
            chkCiudad.Visible = true;
        }

        protected void btnGenerarPlaza_Click1(object sender, EventArgs e)
        {
            generarPlazaRep();

        }
    }
}