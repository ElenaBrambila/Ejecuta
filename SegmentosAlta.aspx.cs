using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate
{
    public partial class SegmentosAlta : System.Web.UI.Page
    {
        IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Actualización
                if (Page.Request["ce"] != null)
                {

                    cargarDatos();
                }


            }
        }

        private void cargarDatos()
        {
            int idDeSegmento = 0;
            bool validarSegmento = int.TryParse(Page.Request["ce"].ToString(), out idDeSegmento);
            if (validarSegmento)
            {
                var buscarSegmento = from p in db.segmentos where p.idSegmento == idDeSegmento select p;
                if (buscarSegmento.Count() > 0)
                {
                    segmentos elSegmento = buscarSegmento.First();
                    cboClientes.SelectedValue = elSegmento.idCliente.ToString();
                    txtSegmento.Text = elSegmento.segmento;

                }

            }
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            //Actualización
            if (Page.Request["ce"] != null)
            {
                int idDeSegmento = 0;
                bool validarSegmento = int.TryParse(Page.Request["ce"].ToString(), out idDeSegmento);
                if (validarSegmento)
                {
                    var buscarSegmento = from p in db.segmentos where p.idSegmento == idDeSegmento select p;
                    if (buscarSegmento.Count() > 0)
                    {
                        segmentos elSegmento = buscarSegmento.First();
                        int idDeCliente = 0;
                        bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                        if (validarCliente)
                        {
                            elSegmento.idCliente = idDeCliente;
                            elSegmento.segmento = txtSegmento.Text;
                            db.Entry(elSegmento).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }

                        else
                        {

                            lblMensaje.Text = "Por favor selecciona el cliente";
                        }

                    }
                }
            }
            else
            {
                segmentos elSegmento = new segmentos();
                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarCliente)
                {
                    elSegmento.idCliente = idDeCliente;
                    elSegmento.segmento = txtSegmento.Text;
                    db.segmentos.Add(elSegmento);
                    db.SaveChanges();
                }

                else
                {
                    lblMensaje.Text = "Por favor selecciona el cliente";
                }

            }
            
        }

        protected void gdSegmentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idDeSegmento = 0;
            bool validarSegmento = int.TryParse(e.CommandArgument.ToString(), out idDeSegmento);
            if (e.CommandName == "btnEditar")
            {
                // e.CommandArgument
            }

            if (e.CommandName == "btnEliminar")
            {
                if (validarSegmento)
                {
                    //Vamos a eliminar el segmento

                    var buscarSegmento = from p in db.segmentos where p.idSegmento == idDeSegmento select p;
                    if (buscarSegmento.Count() > 0)
                    {
                        //Buscamos los registros relacionados

                        //Eliminamos finalmente el registro
                        segmentos segmentoElminar = buscarSegmento.First();
                        db.segmentos.Remove(segmentoElminar);
                        db.SaveChanges();

                    }
                }

            }
        }
    }
}
