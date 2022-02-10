using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class TipoFotosNueva : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Page.Request["id"] != null)
                {
                    int idDeProposito = 0;
                    bool validarProposito = int.TryParse(Page.Request["id"].ToString(), out idDeProposito);
                    if (validarProposito)
                    {
                        cargarProposito(idDeProposito);

                    }
                }
            }

        }

        private void cargarProposito(int idDeProposito)
        {
            var buscarProposito = from p in db.cFotoProposito where p.id == idDeProposito select p;
            if (buscarProposito.Count() > 0)
            {
                Models.cFotoProposito fotoProposito = buscarProposito.First();
                txtNuevo.Text = fotoProposito.nombre;
                cboEstatus.SelectedValue = fotoProposito.idEstado.ToString();
                if (fotoProposito.idCliente != null)
                {
                    cboClientes.SelectedValue = fotoProposito.idCliente.ToString();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoFotos.aspx");

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.Request["id"] != null) //Actualización
            {

                int idDeProposito = 0;
                bool validarProposito = int.TryParse(Page.Request["id"].ToString(), out idDeProposito);
                if (validarProposito)
                {
                    //Buscamos el registro para actualizarlo
                    var buscarProposito = from p in db.cFotoProposito where p.id == idDeProposito select p;
                    if (buscarProposito.Count() > 0)
                    {
                        Models.cFotoProposito actualizacionProposito = buscarProposito.First();
                        actualizacionProposito.nombre = txtNuevo.Text;
                        int idDeEstatus = 0;
                        bool validarEstatus = int.TryParse(cboEstatus.SelectedValue, out idDeEstatus);
                        actualizacionProposito.idEstado = idDeEstatus;
                        ///Cliente
                        if (cboClientes.SelectedIndex != -1)
                        {
                            int idDeCliente = 0;
                            bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                            actualizacionProposito.idCliente = idDeCliente;
                        }

                        else
                        {
                            Response.Write("<script language=javascript>alert('Por favor selecciona un cliente');</script>");
                            return;
                        }
                        db.Entry(actualizacionProposito).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Response.Write("<script language=javascript>alert('Se actualizó exitosamente el tipo de foto');</script>");

                        Response.Redirect("TipoFotos.aspx");

                    }
                }
            }

            else //Nuevo registro
            {
                Models.cFotoProposito nuevoProposito = new Models.cFotoProposito();
                nuevoProposito.nombre = txtNuevo.Text;
                int idDeEstatus = 0;
                bool validarEstatus = int.TryParse(cboEstatus.SelectedValue, out idDeEstatus);
                nuevoProposito.idEstado = idDeEstatus;
                ///Cliente
                if (cboClientes.SelectedIndex != -1)
                {
                    int idDeCliente = 0;
                    bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                    nuevoProposito.idCliente = idDeCliente;
                }

                else
                {
                    Response.Write("<script language=javascript>alert('Por favor selecciona un cliente');</script>");
                    return;
                }
                db.cFotoProposito.Add(nuevoProposito);
                db.SaveChanges();
                Response.Write("<script language=javascript>alert('Se registró exitosamente el tipo de foto');</script>");

                Response.Redirect("TipoFotos.aspx");
            }

        }
    }
}