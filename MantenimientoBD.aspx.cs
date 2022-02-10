using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class MantenimientoBD : System.Web.UI.Page
    {

        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int valorAno = 0;
            int valorMes = 0;

            bool validarAno = int.TryParse(txtAno.Text, out valorAno);
            bool validarMes = int.TryParse(txtMes.Text, out valorMes);

            if (validarAno)
            {
                if (validarMes)
                {
                    //Comenzamos a borrar los registros


                    
                }

                else
                {

                    lblMensaje.Text = "Por favor selecciona un mes";
                }

            }

            else
            {
                lblMensaje.Text = "Por favor selecciona un año";

            }
        }
    }
}