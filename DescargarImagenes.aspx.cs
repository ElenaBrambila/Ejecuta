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
    public partial class DescargarImagenes : System.Web.UI.Page
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
                            cargarPromotores(idCliente, 0);

                        }
                    }

                }

                else
                {
                    Response.Redirect(@"\");
                }
            }

        }


        public class FotoVieja
        {
            public int id { get; set; }
            public byte[] foto { get; set; }
        }

        private FotoVieja obtenerUltimaFoto(int? idTipoProposito, int? idTienda, int? idPromotor, DateTime? fecha)
        {

            FotoVieja oFotoVieja = null;
            try
            {
                var oReporteFoto = (from d in db.reporteTiendaFoto
                                    where d.reporteTienda.idEstado == 1 && d.reporteTienda.rutaIntinerario.idTienda == idTienda
                                    && d.idFotoProposito == idTipoProposito && d.reporteTienda.idUsuarioPromotor == idPromotor
                                    && d.reporteTienda.fechaEntrada < fecha
                                    orderby d.reporteTienda.fecha descending
                                    select d).FirstOrDefault();

                if (oReporteFoto != null) //si no es null
                {
                    oFotoVieja.foto = oReporteFoto.foto;
                    oFotoVieja.id = oReporteFoto.id;

                }
            }
            catch { oFotoVieja = null; }

            return oFotoVieja;
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
            DataTable dt = new DataTable("Mydata");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Folder", typeof(string));
            dt.Columns["ID"].AutoIncrement = true;
            dt.Columns["ID"].AutoIncrementSeed = 1;
            dt.Columns["ID"].AutoIncrementStep = 1;
            string ruta = Server.MapPath("~/fotosReportes/");
            ProcessDirectory(ruta, ref dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void ProcessDirectory(string targetDirectory, ref DataTable dt)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                FileInfo fi = new FileInfo(fileName);
                dt.Rows.Add(null, fi.Name, targetDirectory);
            }
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory, ref dt);
            }
        }

        private void descargar()
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
                    //int idDePromotor = 0;
                    //bool validarPromotor = int.TryParse(cbo)

                    foreach (ListItem elPromotor in cboPromotor.Items)
                    {
                        if (elPromotor.Selected == true)
                        {
                            int idDePromotor = 0;
                            bool validarPromotor = int.TryParse(elPromotor.Value, out idDePromotor);

                            var buscarFotos = from p in db.vwReporteFotos where p.idCliente == idDeCliente && p.fecha > fechaInicio && p.fecha < fechaFin && p.idDUsuario == idDePromotor select p;
                            foreach (vwReporteFotos resultado in buscarFotos)
                            {
                                var buscarImagen = from p in db.reporteTiendaFoto where p.id == resultado.id select p;
                                if (buscarImagen.Count() > 0)
                                {

                                    reporteTiendaFoto datosFoto = buscarImagen.First();
                                    System.Drawing.Image foto = byteArrayToImage(datosFoto.foto);
                                    string ruta = Server.MapPath("~/fotosReportes/" + datosFoto.id.ToString() + ".jpg");
                                    foto.Save(ruta, ImageFormat.Jpeg);
                                    lblText.Text = "Foto No." + datosFoto.id.ToString();
                                }
                            }
                        }


                    }

                    lblMensaje.Text = "Se han descargado las imagenes con éxito <p><a href='ReporteFotoSimple.aspx'>Presiona aquí para ir al reporteador </a></p>";
                    string redirectURL = Page.ResolveClientUrl("ReporteFotoSimple.aspx?e=1");
                    string script = "window.location = '" + redirectURL + "';";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "RedirectTo", script, true);
                }
            }
        }

        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                btnDescargar.Visible = true;
                cargarPromotores(0, 1);
            }
        }

        private void cargarPromotores(int indice, int procedencia)
        {

            int idDeCliente = 0;
            bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
            if (procedencia == 0)
            {
                idDeCliente = indice;
            }
            var datosPromotor = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) })).ToList();
            cboPromotor.DataSource = datosPromotor.OrderBy(c => c.nombre);
            cboPromotor.DataValueField = "Id";
            cboPromotor.DataTextField = "nombre";
            cboPromotor.DataBind();


        }

        protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        {
            descargar();
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in cboPromotor.Items)
            {
                item.Selected = true;
            }
        }

        protected void btnDescargar1_Click(object sender, ImageClickEventArgs e)
        {
            descargar();
        }
    }
}