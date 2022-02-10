using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate
{
    public partial class RegistroProductoFormato : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            checarProductos();
        }

        private void checarProductos()
        {
            // lblProductos.Text = chkProductos.Items.Count.ToString();
            //ListItem listItem = this.chkProductos.Items.FindByText(valueToSelect);

            //if (listItem != null) listItem.Selected = true;
        }

        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        protected void chkProductos_DataBound(object sender, EventArgs e)
        {
            int idDeFormato = 0;
            bool validarFormato = int.TryParse(cboFormatos.SelectedValue, out idDeFormato);
            int idDeCliente = 0;
            bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
            //Vamos a buscar de ejemplo el formato 8 (bodega Aurrera) y el producto 31 (PH Adorable 600hd 6rollos)
            lblProductos.Text = chkProductos.Items.Count.ToString();
            //Vamos a buscar todos los productos del cliente y del formato
            var buscarFormatos = from p in db.formatoProducto where p.idFormato == idDeFormato select p;
            foreach (formatoProducto dato in buscarFormatos)
            {
                ListItem listItem = this.chkProductos.Items.FindByValue(dato.idProducto.ToString());
                if (listItem != null)
                {
                    listItem.Selected = true;

                }


            }
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Actualizamos todos los registros de productos por formato

            //Necesitamos saber si ya estaban registrados antes
            int idDeFormato = 0;
            bool validarFormato = int.TryParse(cboFormatos.SelectedValue, out idDeFormato);
            var buscarFormatos = from p in db.formatoProducto where p.idFormato == idDeFormato select p;

            foreach (ListItem registro in chkProductos.Items)
            {
                //Obtenemos el indice para compararlo con los que ya están.
                int indiceProducto = 0;
                bool validarIndice = int.TryParse(registro.Value, out indiceProducto);
                if (validarIndice)
                {
                    if (registro.Selected == true)
                    {
                        //Si ya está agregado no hacemos nada/ usamos el RETURN!
                        if (buscarFormatos.Any(o => o.idProducto == indiceProducto))
                        {
                            return;
                        }

                        else
                        {
                            //Agregamos el registro
                            formatoProducto nuevoRegistro = new formatoProducto();
                            nuevoRegistro.idFormato = idDeFormato;
                            nuevoRegistro.idProducto = indiceProducto;
                            db.formatoProducto.Add(nuevoRegistro);
                            db.SaveChanges();
                        }
                       
                    }
                    else
                    {
                        //Si no está seleccionado, tenemos que verificar que antes no estuviera palomeado
                        //Si antes estaba agregado, debemos eliminarlo.
                        if (buscarFormatos.Any(o => o.idProducto == indiceProducto))
                        {
                            var buscarProducto = from p in db.formatoProducto where p.idFormato == idDeFormato && p.idProducto == indiceProducto select p;
                            if (buscarProducto.Count() > 0)
                            {
                                formatoProducto fpEliminar = buscarProducto.First();
                                db.formatoProducto.Remove(fpEliminar);
                                db.SaveChanges();
                            }
                        }

                    }
                }

              
            }
        }
    }
}