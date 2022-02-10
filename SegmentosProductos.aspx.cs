using IntegramsaUltimate.Models;
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
            if (cboClientes.SelectedIndex != -1)
            {
                int idDeCliente = 0;
                bool validarIDCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarIDCliente)
                {
                    if (cboSegmentos.SelectedIndex != -1)
                    {
                        int idDeSegmento = 0;
                        bool validarSegmento = int.TryParse(cboSegmentos.SelectedValue, out idDeSegmento);
                        if (validarSegmento)
                        {
                            foreach (ListItem item in chkProductos.Items)
                            {
                                int idDeProducto = 0;
                                bool validarProducto = int.TryParse(item.Value, out idDeProducto);
                                if (validarProducto)
                                {
                                    bool productoRegistrado = false;
                                    var buscarProducto = from p in db.segmentoProductos where p.idSegmento == idDeSegmento && p.idProducto == idDeProducto select p;
                                    if (buscarProducto.Count() > 0)
                                    {

                                        productoRegistrado = true;

                                    }

                                    //No estaba registrado y lo vamos a guardar
                                    if (item.Selected == true && productoRegistrado == false)
                                    {
                                        segmentoProductos nuevoSP = new segmentoProductos();
                                        nuevoSP.idSegmento = idDeSegmento;
                                        nuevoSP.idProducto = idDeProducto;
                                        db.segmentoProductos.Add(nuevoSP);
                                    }

                                    //Quiere decir que antes estaba registrado pero ahora lo vamos a eliminar
                                    if (item.Selected == false && productoRegistrado == true)
                                    {
                                        segmentoProductos spEliminar = buscarProducto.First();
                                        db.segmentoProductos.Remove(spEliminar);
                                    }


                                }

                            }

                            db.SaveChanges();
                        }


                    }

                }

                Response.Redirect(Page.Request.RawUrl);
            }

        }


        protected void chkProductos_DataBound(object sender, EventArgs e)
        {
            seleccionarProductos();
        }

        private void seleccionarProductos()
        { 
            //Limpiamos la selección de todos.
            foreach (ListItem elementos in chkProductos.Items)
            {
                elementos.Selected = false;
            }

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

        protected void cboSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarProductos();
        }
    }
}