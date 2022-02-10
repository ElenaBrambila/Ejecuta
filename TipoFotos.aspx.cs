using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class TipoFotos : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cboProposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProposito.SelectedIndex != -1)
            {
                int idDeProposito = 0;
                bool validarProposito = int.TryParse(cboProposito.SelectedValue,out idDeProposito);
                var buscarProposito = from p in db.cFotoProposito where p.id == idDeProposito select p;
                if (buscarProposito.Count() > 0)
                {
                    IntegramsaUltimate.Models.cFotoProposito tipoFoto = buscarProposito.First();
                    cboEstatus.SelectedValue = tipoFoto.idEstado.ToString();
                }

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idDeTipoFoto = 0;
            bool validarTipoFoto = int.TryParse(cboProposito.SelectedValue, out idDeTipoFoto);
            if (validarTipoFoto)
            {
                Response.Redirect("TipoFotosNueva.aspx?id=" + idDeTipoFoto.ToString());
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoFotosNueva.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Primero buscamos que esté seleccionado un tipo de exhibición
            if (cboProposito.SelectedIndex != -1)
            {
                int idDeProposito = 0;
                bool validarProposito = int.TryParse(cboProposito.SelectedValue, out idDeProposito);
                if (validarProposito)
                {
                    //Buscamos
                    this.db.Database.CommandTimeout = 300;
                    var todasFotos = from p in db.reporteTiendaFoto where p.idFotoProposito == idDeProposito select p;
                    db.reporteTiendaFoto.RemoveRange(todasFotos);
                    db.SaveChanges();

                    var registro = from p in db.cFotoProposito where p.id == idDeProposito select p;
                    if (registro.Count() > 0)
                    {
                        Models.cFotoProposito proposito = registro.FirstOrDefault();
                        db.cFotoProposito.Remove(proposito);
                        db.SaveChanges();

                    }

                }
                Response.Write("<script language=javascript>alert('Se eliminó exitosamente el tipo de foto');</script>");

                Response.Redirect(Request.RawUrl);
            
            }

            else
            {
                lblMensaje.Text = "Por favor selecciona un tipo de exhibición";
            }
        }
    }
}