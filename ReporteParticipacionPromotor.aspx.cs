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
    public partial class ReporteParticipacionPromotor : System.Web.UI.Page
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

                    if (oUsuario.idTipoUsuario == 6) //Cliente
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



        protected void btnTodosPromotores_Click(object sender, ImageClickEventArgs e)
        {
            chkPromotor.Visible = true;
        }

        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                cargarPromotores(0, 1);
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


            var datosOrigin = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) }).OrderBy(c => c.nombre)).ToList();
            cboPromotor.DataSource = datosOrigin;
            cboPromotor.DataValueField = "Id";
            cboPromotor.DataTextField = "nombre";
            cboPromotor.DataBind();

            chkPromotor.DataSource = datosOrigin;
            chkPromotor.DataValueField = "Id";
            chkPromotor.DataTextField = "nombre";
            chkPromotor.DataBind();


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            cargarDatosPromotores();
        }


        private void cargarDatosPromotores()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

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
                    tablasContenido tablas = new tablasContenido();
                    DataTable datosTabla = (DataTable)tablas.dtPartPromotoresHanCapturado(idDeCliente, fechaInicio, fechaFin);
                    gdDatos.DataSource = datosTabla;
                    gdDatos.DataBind();

                }


            }

        }

        protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        {
            cargarDatosPromotores();
        }

    }
}