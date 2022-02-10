using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class Fotos : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.Request["id"] != null)
                {
                    int idDeFoto = 0;
                    bool validarFoto = int.TryParse(Page.Request["id"].ToString(), out idDeFoto);
                    if (validarFoto)
                    {

                        var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                        if (buscarFoto.Count() > 0)
                        {
                            reporteTiendaFoto foto = buscarFoto.First();
                            txtComentario.Text = foto.comentario;
                            if (File.Exists(Server.MapPath("~/fotosReportes/" + foto.id.ToString() + ".jpg")))
                            {
                                img.ImageUrl = "~/fotosReportes/" + foto.id.ToString() + ".jpg";
                                btnGenerar.Visible = false;
                                lblNoImagen.Visible = false;
                            }

                            else
                            {
                                btnGenerar.Visible = true;
                                lblNoImagen.Visible = true;
                            }

                        }

                    }

                }


            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.Request["id"] != null)
            {
                int idDeFoto = 0;
                bool validarFoto = int.TryParse(Page.Request["id"].ToString(), out idDeFoto);
                if (validarFoto)
                {
                    var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                    if (buscarFoto.Count() > 0)
                    {
                        reporteTiendaFoto foto = buscarFoto.First();
                        foto.comentario = txtComentario.Text;
                        db.Entry(foto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                }
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (Page.Request["id"] != null)
            {
                int idDeFoto = 0;
                bool validarFoto = int.TryParse(Page.Request["id"].ToString(), out idDeFoto);
                if (validarFoto)
                {
                    var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                    if (buscarFoto.Count() > 0)
                    {
                        reporteTiendaFoto datosFoto = buscarFoto.First();
                        System.Drawing.Image foto = byteArrayToImage(datosFoto.foto);
                        string ruta = Server.MapPath("~/fotosReportes/" + datosFoto.id.ToString() + ".jpg");
                        foto.Save(ruta, ImageFormat.Jpeg);
                        Response.Redirect(Request.RawUrl);

                    }
                }
            }

        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
    }
}