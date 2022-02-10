using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegramsaUltimate.Models;
using Microsoft.Reporting.WebForms;

namespace IntegramsaUltimate
{

    public partial class ReporteFotos : System.Web.UI.Page
    {
        IntegramsaUltimate.Models.IntegramsaUltimateEntities db = new Models.IntegramsaUltimateEntities();
        public usuario oUsuario = new usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCadenas();
                cargarPlazas();
                oUsuario = (usuario)Session["Usuario"];

                if (oUsuario != null)
                {

                    if (oUsuario.idTipoUsuario == 6)
                    {
                        if (oUsuario.usuarioCliente != null)
                        {
                            int idCliente = (int)oUsuario.usuarioCliente.First().idCliente;
                            cboClientes.SelectedValue = idCliente.ToString();
                            cboClientes.Enabled = false;
                            cargarPromotores(idCliente, 0);

                            if (Page.Request["e"] != null)
                            {

                                //  lblMensaje.Text = "Se descargaron correctamente las imagenes. Por favor selecciona un rango de fechas y presiona sobre el botón de 'Generar'";
                            }
                        }
                    }

                }

                else
                {
                    Response.Redirect(@"\");
                }
            }
        }

        private void cargarPlazas()
        {
            var todasPlazas = from p in db.cPlaza orderby p.nombre select p;
            cboPlazas.DataSource = todasPlazas.ToList();
            cboPlazas.DataTextField = "nombre";
            cboPlazas.DataValueField = "id";
            cboPlazas.DataBind();
        }

        private void cargarCadenas()
        {

            var todasCadenas = from p in db.cadena orderby p.nombre select p;
            cboCadena.DataSource = todasCadenas.ToList();
            cboCadena.DataTextField = "nombre";
            cboCadena.DataValueField = "id";
            cboCadena.DataBind();

        }

        private void cargarTiposExhibicion(int cliente)
        {


            var todosTiposExhibicion = from p in db.cFotoProposito where p.idEstado == 1 && p.idCliente == cliente orderby p.nombre select p;
            cboTipoExhibicion.DataSource = todosTiposExhibicion.ToList();
            cboTipoExhibicion.DataTextField = "nombre";
            cboTipoExhibicion.DataValueField = "nombre";
            cboTipoExhibicion.DataBind();
        }


        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }


        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
        }


        protected void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {

                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                cargarPromotores(idDeCliente, 1);
                //cboPromotor1.DataSource = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) }).OrderBy(c => c.nombre)).ToList();
                //cboPromotor1.DataValueField = "Id";
                //cboPromotor1.DataTextField = "nombre";
                //cboPromotor1.DataBind();


            }

            //Cargamos los tipos de exhibición
            //cargarTiposExhibicion();
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
            cboPromotor1.DataSource = (db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f => f.idCliente == idDeCliente).Count() > 0).Select(c => new { Id = c.id, nombre = (c.nombre + " " + c.paterno + " " + c.materno) }).OrderBy(c => c.nombre)).ToList();
            cboPromotor1.DataValueField = "Id";
            cboPromotor1.DataTextField = "nombre";
            cboPromotor1.DataBind();

            cargarTiposExhibicion(idDeCliente);

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            ReportViewer1.Visible = true;
            DataTable nuevaTabla = new DataTable();
            nuevaTabla.Columns.Add("id");
            nuevaTabla.Columns.Add("fecha");
            nuevaTabla.Columns.Add("plaza");
            nuevaTabla.Columns.Add("municipio");
            nuevaTabla.Columns.Add("tienda");
            nuevaTabla.Columns.Add("Cadena");

            nuevaTabla.Columns.Add("formatoTienda");
            nuevaTabla.Columns.Add("Promotor");
            nuevaTabla.Columns.Add("proposito");
            nuevaTabla.Columns.Add("comentario");



            foreach (GridViewRow row in datosGrid.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkAgregar");
                if (cb != null && cb.Checked)
                {
                    DataRow drCurrentRow = nuevaTabla.NewRow();
                    drCurrentRow["id"] = row.Cells[1].Text;
                    drCurrentRow["fecha"] = row.Cells[2].Text;
                    drCurrentRow["Plaza"] = row.Cells[3].Text;
                    drCurrentRow["municipio"] = row.Cells[4].Text;
                    drCurrentRow["Cadena"] = row.Cells[5].Text;
                    drCurrentRow["Tienda"] = row.Cells[6].Text;
                    drCurrentRow["formatoTienda"] = row.Cells[7].Text;
                    drCurrentRow["Promotor"] = row.Cells[8].Text;
                    drCurrentRow["Proposito"] = row.Cells[9].Text;
                    drCurrentRow["comentario"] = row.Cells[10].Text;
                    //drCurrentRow["Proposito"] = row.Cells[8].Text;
                    //drCurrentRow["Promotor"] = row.Cells[7].Text;
                    //drCurrentRow["Proposito"] = row.Cells[8].Text;
                    nuevaTabla.Rows.Add(drCurrentRow);
                    //// First, get the ProductID for the selected row
                    //int productID =
                    //    Convert.ToInt32(Products.DataKeys[row.RowIndex].Value);
                    //// "Delete" the row
                    //DeleteResults.Text += string.Format(
                    //    "This would have deleted ProductID {0}<br />", productID);
                }
            }

            ///Valor que tenía antes el reporte
            ///="ID: " & Fields!id.Value & "<br/>" & "CADENA: <b>" &  Fields!cadena.Value & "</b><br/>"  & "PLAZA: <b>" & Fields!plaza.Value &  "</b><br/>CIUDAD: " & Fields!municipio.Value & "<br/>FORMATO:" & Fields!formatoTienda.Value & "<br/>TIENDA: <b>" & Fields!tienda.Value & "</b><br/>FECHA: " &  CDate(Fields!fecha.Value).ToString("dd-MM-yyyy HH:mm:ss") & "<br/>PROPOSITO: " & Fields!proposito.Value & "<br/>PROMOTOR: " & Fields!promotor.Value  &  "<br/>URL: " &  "http://portalsistema.com/fotosReportes/" & Fields!id.Value &".jpg" & "<br/>" & "COMENTARIOS: <b>" &  Fields!comentario.Value
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", nuevaTabla);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.Refresh();

        }
        protected void btnPreliminar_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                btnGenerarReporteHorizontal.Visible = true;
                btnGenerarReporte.Visible = true;
                btnSelectAllPics1.Visible = true;
                btnDeseleccionar.Visible = true;
                btnPreliminar.Visible = false;
                ReportViewer1.Visible = false;

                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarCliente)
                {
                    DateTime fechaInicio = new DateTime();
                    bool validarFechaInicio = DateTime.TryParse(dtInicio.Text, out fechaInicio);
                    DateTime fechaFin = new DateTime();
                    bool validarFechaFin = DateTime.TryParse(dtFin.Text, out fechaFin);
                    tablasContenido infoReporte = new tablasContenido();

                    DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFecha(fechaInicio, fechaFin, idDeCliente);

                    //Buscamos si se puso información del promotor
                    int i;
                    List<string> chosenItems = new List<string>();
                    for (i = 0; i <= cboPromotor1.Items.Count - 1; i++)
                    {
                        if (cboPromotor1.Items[i].Selected)
                        {
                            // chosenItems.Add(cboPromotor1.Items[i].Value.Trim());
                            chosenItems.Add("'" + cboPromotor1.Items[i].Value.Trim() + "'");

                        }
                    }


                    //Buscamos si se puso información de la plaza
                    int i2;
                    List<string> elementosPlaza = new List<string>();
                    for (i2 = 0; i2 <= cboPlazas.Items.Count - 1; i2++)
                    {
                        if (cboPlazas.Items[i2].Selected)
                        {
                            elementosPlaza.Add("'" + cboPlazas.Items[i2].Value.Trim() + "'");

                        }
                    }


                    //Buscamos si se puso información de la cadena
                    int i3;
                    List<string> elementosCadena = new List<string>();
                    for (i3 = 0; i3 <= cboCadena.Items.Count - 1; i3++)
                    {
                        if (cboCadena.Items[i3].Selected)
                        {
                            elementosCadena.Add("'" + cboCadena.Items[i3].Value.Trim() + "'");

                        }
                    }


                    //Buscamos por tipo de exhibición
                    int i4;
                    List<string> elementosTE = new List<string>();
                    for (i4 = 0; i4 <= cboTipoExhibicion.Items.Count - 1; i4++)
                    {
                        if (cboTipoExhibicion.Items[i4].Selected)
                        {
                            elementosTE.Add("'" + cboTipoExhibicion.Items[i4].Value.Trim() + "'");

                        }
                    }



                    //Promotor
                    if (chosenItems.Count() > 0)
                    {
                        string query = "idDUsuario IN (" + string.Join(",", chosenItems + ")");
                        string query2 = string.Join(",", chosenItems);
                        //  datosReporte.Select("idDUsuario IN (" + string.Join(",", chosenItems.ToArray() + ")").ToString());
                        DataRow[] resultados = datosReporte.Select("idDUsuario IN (" + query2 + ")");
                        if (resultados.Count() > 0)
                        {
                            datosReporte = resultados.CopyToDataTable();
                        }

                        else
                        {
                            return;
                        }
                    }


                    //Plaza
                    if (elementosPlaza.Count() > 0)
                    {
                        string query2 = string.Join(",", elementosPlaza);
                        DataRow[] resultados = datosReporte.Select("idPlaza IN (" + query2 + ")");
                        if (resultados.Count() > 0)
                        {
                            datosReporte = resultados.CopyToDataTable();
                        }
                        else
                        {
                            return;
                        }
                    }



                    //Cadena
                    if (elementosCadena.Count() > 0)
                    {
                        string query2 = string.Join(",", elementosCadena);
                        DataRow[] resultados = datosReporte.Select("idCadena IN (" + query2 + ")");
                        if (resultados.Count() > 0)
                        {
                            datosReporte = resultados.CopyToDataTable();
                        }

                        else
                        {
                            return;
                        }
                    }


                    //TE
                    if (elementosTE.Count() > 0)
                    {
                        string query2 = string.Join(",", elementosTE);
                        DataRow[] resultados = datosReporte.Select("proposito IN (" + query2 + ")");
                        if (resultados.Count() > 0)
                        {
                            datosReporte = resultados.CopyToDataTable();
                        }

                        else
                        {
                            return;
                        }
                    }



                    if (datosReporte.Rows.Count > 0)
                    {
                        if (chkDescargarFotos.Checked == true)
                        {
                            IList<int> listaID = new List<int>();
                            foreach (DataRow datos in datosReporte.Rows)
                            {
                                if (!File.Exists(Server.MapPath("~/fotosReportes/" + datos["id"].ToString() + ".jpg")))
                                {
                                    int idDeFoto = 0;
                                    bool validarIDFoto = int.TryParse(datos["id"].ToString(), out idDeFoto);
                                    if (validarIDFoto)
                                    {
                                        var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                                        if (buscarFoto.Count() > 0)
                                        {
                                       /* reporteTiendaFoto datosFoto = buscarFoto.First();
                                        System.Drawing.Image foto = byteArrayToImage(datosFoto.foto);
                                        string ruta = Server.MapPath("~/fotosReportes/" + datosFoto.id.ToString() + ".jpg");
                                        foto.Save(ruta, ImageFormat.Jpeg);
                                            listaID.Add(idDeFoto);*/

                                        }

                                    }
                                }

                                lblCantidadFotos.Text = "Cantidad de registros sin fotos: " + listaID.Count().ToString();
                            }
                        }

                        datosGrid.DataSource = datosReporte;
                        datosGrid.DataBind();
                    }

                    else

                    {

                        datosGrid.DataSource = null;
                        datosGrid.DataBind();

                    }



                    // DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFecha(fechaInicio, fechaFin, idDeCliente);
                    //datosReporte.Columns.Add("imagen", typeof(string));
                    //foreach (DataRow dr in datosReporte.Rows)
                    //{

                    //    dr["imagen"] = "http://portalsistema.com/fotosReportes/" + dr["id"] + ".jpg";

                    //}
                    //http://portalsistema.com/fotosReportes/138261.jpg



                }

            }

        }
        protected void btnPreliminar_ClickR(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                btnGenerarReporteHorizontal.Visible = true;
                btnGenerarReporte.Visible = true;
                btnSelectAllPics1.Visible = true;
                btnDeseleccionar.Visible = true;
                btnPreliminar.Visible = false;
                ReportViewer1.Visible = false;

                int idDeCliente = 0;
                bool validarCliente = int.TryParse(cboClientes.SelectedValue, out idDeCliente);
                if (validarCliente)
                {
                    DateTime fechaInicio = new DateTime();
                    bool validarFechaInicio = DateTime.TryParse(dtInicio.Text, out fechaInicio);
                    DateTime fechaFin = new DateTime();
                    bool validarFechaFin = DateTime.TryParse(dtFin.Text, out fechaFin);
                    tablasContenido infoReporte = new tablasContenido();

                    DataTable datosReporte = (DataTable)infoReporte.dtFotosClienteFecha(fechaInicio, fechaFin, idDeCliente);



                    if (datosReporte.Rows.Count > 0)
                    {
                        if (chkDescargarFotos.Checked == true)
                        {
                            IList<int> listaID = new List<int>();
                            foreach (DataRow datos in datosReporte.Rows)
                            {
                                if (!File.Exists(Server.MapPath("~/fotosReportes/" + datos["id"].ToString() + ".jpg")))
                                {
                                    int idDeFoto = 0;
                                    bool validarIDFoto = int.TryParse(datos["id"].ToString(), out idDeFoto);
                                    if (validarIDFoto)
                                    {
                                        var buscarFoto = from p in db.reporteTiendaFoto where p.id == idDeFoto select p;
                                        if (buscarFoto.Count() > 0)
                                        {
                                            reporteTiendaFoto datosFoto = buscarFoto.First();
                                            System.Drawing.Image foto = byteArrayToImage(datosFoto.foto);
                                            string ruta = Server.MapPath("~/fotosR/" + datosFoto.id.ToString() + ".jpg");
                                            foto.Save(ruta, ImageFormat.Jpeg);
                                            listaID.Add(idDeFoto);

                                        }

                                    }
                                }

                                lblCantidadFotos.Text = "Cantidad de registros sin fotos: " + listaID.Count().ToString();
                            }
                        }

                        datosGrid.DataSource = datosReporte;
                        datosGrid.DataBind();
                    }

                    else

                    {

                        datosGrid.DataSource = null;
                        datosGrid.DataBind();

                    }

                }

            }

        }

        protected void btnPromotores_Click(object sender, EventArgs e)
        {
            int i;
            IList<string> chosenItems = new List<string>();
            for (i = 0; i <= cboPromotor1.Items.Count - 1; i++)
            {
                if (cboPromotor1.Items[i].Selected)
                {
                    chosenItems.Add(cboPromotor1.Items[i].Value.Trim());
                }
            }


        }

        protected void btnSelectAllPics_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in datosGrid.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkAgregar");
                cb.Checked = true;
            }
        }

        protected void btnDeseleccionar_ServerClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in datosGrid.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkAgregar");
                cb.Checked = false;
            }
        }

        protected void btnFotosPendientes_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteHorizontal_Click(object sender, EventArgs e)
        {
            //Agregamos la ruta del reporte 
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
            ReportViewer1.LocalReport.ReportPath = "rptRepFotosHorizontal.rdlc";

            ReportViewer1.Visible = true;
            DataTable nuevaTabla = new DataTable();
            nuevaTabla.Columns.Add("id");
            nuevaTabla.Columns.Add("fecha");
            nuevaTabla.Columns.Add("plaza");
            nuevaTabla.Columns.Add("municipio");
            nuevaTabla.Columns.Add("tienda");
            nuevaTabla.Columns.Add("Cadena");

            nuevaTabla.Columns.Add("formatoTienda");
            nuevaTabla.Columns.Add("Promotor");
            nuevaTabla.Columns.Add("proposito");
            nuevaTabla.Columns.Add("comentario");



            foreach (GridViewRow row in datosGrid.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkAgregar");
                if (cb != null && cb.Checked)
                {
                    DataRow drCurrentRow = nuevaTabla.NewRow();
                    drCurrentRow["id"] = row.Cells[1].Text;
                    drCurrentRow["fecha"] = row.Cells[2].Text;
                    drCurrentRow["Plaza"] = row.Cells[3].Text;
                    drCurrentRow["municipio"] = row.Cells[4].Text;
                    drCurrentRow["Cadena"] = row.Cells[5].Text;
                    drCurrentRow["Tienda"] = row.Cells[6].Text;
                    drCurrentRow["formatoTienda"] = row.Cells[7].Text;
                    drCurrentRow["Promotor"] = row.Cells[8].Text;
                    drCurrentRow["Proposito"] = row.Cells[9].Text;
                    drCurrentRow["comentario"] = row.Cells[10].Text;
                    nuevaTabla.Rows.Add(drCurrentRow);

                }
            }

            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", nuevaTabla);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}