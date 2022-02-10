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

    public partial class ReporteFotos : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();


        protected void Page_Load(object sender, EventArgs e)
        {

        }


    
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
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
                    DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFecha(fechaInicio,fechaFin, idDeCliente);

                    ReportDataSource reportDataSource1 = new ReportDataSource("dsGeneralesFoto", datosReporte);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }


        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                cboPromotor.DataSource = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) })).ToList();
                cboPromotor.DataValueField = "Id";
                cboPromotor.DataTextField = "nombre";
                cboPromotor.DataBind();
            }

        }

       
    }
}