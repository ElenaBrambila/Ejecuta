using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public usuario oUsuario = new usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            oUsuario = (usuario)Session["Usuario"];

            if (oUsuario != null)
            {
                lblUsuario.Text = oUsuario.nombre;

                if (oUsuario.idTipoUsuario == 6)
                {
                    if (oUsuario.usuarioCliente != null)
                    {
                        int idCliente = (int)oUsuario.usuarioCliente.First().idCliente;
                        pnlMenu.Controls.Add(this.LoadControl("v2/ctrlMenuCliente.ascx"));

                    }
                }

                else
                {
                    pnlMenu.Controls.Add(this.LoadControl("v2/ctrlMenu.ascx"));

                }
            }
        }
    }
}