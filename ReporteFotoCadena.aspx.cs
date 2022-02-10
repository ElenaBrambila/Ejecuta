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
    public partial class ReporteFotoCadena : System.Web.UI.Page
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
                    int idDeFormato = 0;
                    bool validarCiudad = int.TryParse(cboFormato.SelectedValue, out idDeFormato);
                    tablasContenido infoReporte = new tablasContenido();
                    DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFormato(fechaInicio, fechaFin, idDeCliente, idDeFormato);

                    if (chkDescargarFotos.Checked == true)
                    {
                        IList<int> listaID = new List<int>();
                        foreach (DataRow datos in datosReporte.Rows)
                        {
                            if (!File.Exists(Server.MapPath("~/fotosReportes/" + datos["id"].ToString() + ".jpg")))
                            {
                                int idDeFoto = 0;
                                bool validarIDFoto = int.TryParse(datos["id"].ToString(), out idDeFoto);
                                if (validarIDFoto)
                                {
                                    var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                                    if (buscarFoto.Count() > 0)
                                    {
                                        reporteTiendaFoto datosFoto = buscarFoto.First();
                                        System.Drawing.Image foto = byteArrayToImage(datosFoto.foto);
                                        string ruta = Server.MapPath("~/fotosReportes/" + datosFoto.id.ToString() + ".jpg");
                                        foto.Save(ruta, ImageFormat.Jpeg);
                                        listaID.Add(idDeFoto);

                                    }

                                }
                            }

                          //  lblCantidadFotos.Text = "Cantidad de registros sin fotos: " + listaID.Count().ToString();
                        }
                    }


                    ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }


        protected void btnGenerarPlaza_Click(object sender, ImageClickEventArgs e)
        {

            generarPlazaRep();
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
                        bool validarPlaza = int.TryParse(cboCadena.SelectedValue, out idDePlaza);

                        tablasContenido infoReporte = new tablasContenido();
                        DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteCadena(fechaInicio, fechaFin, idDeCliente, idDePlaza);
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
            chkFormato.Visible = true;
        }

        protected void btnGenerarPlaza_Click1(object sender, EventArgs e)
        {
            generarPlazaRep();

        }
    }
}