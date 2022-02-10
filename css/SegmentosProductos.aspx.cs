using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegramsaUltimate
{
    public partial class SegmentosProductos : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void chkProductos_DataBound(object sender, EventArgs e)
        {
            int idDeSegmento = 0;
            bool validarSegmento = int.TryParse(cboSegmentos.SelectedValue, out idDeSegmento);

            int idDeCliente = 0;
            bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
            //Vamos a buscar de ejemplo el formato 8 (bodega Aurrera) y el producto 31 (PH Adorable 600hd 6rollos)
            lblProductos.Text = chkProductos.Items.Count.ToString();
            //Vamos a buscar todos los productos del cliente y del formato
            var buscarSProducto = from p in db.segmentoProductos where p.idSegmento == idDeSegmento select p;
            foreach (IntegramsaUltimate.Models.segmentoProductos dato in buscarSProducto)
            {
                ListItem listItem = this.chkProductos.Items.FindByValue(dato.producto.id.ToString());
                if (listItem != null)
                {
                    listItem.Selected = true;

                }


            }
        }

        protected void gdSegmentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}