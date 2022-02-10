using System.Collections.Generic;

using System;
using System.Linq;
using System.IO;
using SpreadsheetLight;
using IntegramsaUltimate.Models;
using System.Data.Entity;
using IntegramsaUltimate.Utilidades;

namespace IntegramsaUltimate.Excel
{
    /// <summary>
    /// Clase que se encarga de cargar un excel en la tabla productos
    /// </summary>
    public class InventarioExcel : Arquitectura.ClaseModelo
    {

        private int idCadena;
        private int idCliente;
        private int idSemana;
        private Stream archivo;
        List<Fila> lstFilas = new List<Fila>();

        private struct Fila
        {

            public string Sku { get; set; }
            public string Cantidad { get; set; }
            public string NumeroTienda { get; set; }
            public string Inventario { get; set; }

        }

        public InventarioExcel(Stream archivo, int idCliente, int idSemana, int idCadena)
        {
            this.idSemana = idSemana;
            this.idCadena = idCadena;
            this.archivo = archivo;
            this.idCliente = idCliente;

        }

        public bool Cargar()
        {
            try
            {


                //abrimos el excel
                using (SLDocument sl = new SLDocument(archivo))
                {
                    SLWorksheetStatistics stats = sl.GetWorksheetStatistics(); //objeto de informacion de hoja
                    int iStartColumnIndex = stats.StartColumnIndex; //nos indica el inicio de las columnas por si vienen en blanco

                    //recorremos y llenamos la lista
                    for (int row = stats.StartRowIndex + 1; row <= stats.EndRowIndex; ++row)
                    {
                        string sku = sl.GetCellValueAsString(row, iStartColumnIndex);
                        string numeroTienda = sl.GetCellValueAsString(row, iStartColumnIndex + 1);
                        string cantidad = sl.GetCellValueAsString(row, iStartColumnIndex + 2);
                        string inventario = sl.GetCellValueAsString(row, iStartColumnIndex + 3);

                        //validamos
                        if (sku.Equals("") || cantidad.Equals("") || numeroTienda.Equals("") || inventario.Equals(""))
                        {
                            addError("El archivo de excel contiene productos que no tienen todos los valores capturados");
                            return false;
                        }

                        Fila oFila = new Fila();
                        oFila.Sku = sku;
                        oFila.NumeroTienda = numeroTienda;
                        oFila.Cantidad = cantidad;
                        oFila.Inventario = inventario;
                        lstFilas.Add(oFila);
                    }


                }

                //insertamos valores
                Inserta();

            }
            catch (Exception ex)
            {
                addError("Error de sistema: " + ex.Message);
                return false;
            }

            return true;
        }
        #region HELPERS
        private void Inserta()
        {
            using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
            {
                int? idTienda;
                int? idProducto;
                int count = 0;
                foreach (var oFila in lstFilas)
                {
                    string numTienda = oFila.NumeroTienda;
                    if (db.tienda.Where(d => d.codigo == numTienda && d.idCadena == idCadena).Any())
                    {
                        idTienda = db.tienda.Where(d => d.codigo == numTienda && d.idCadena == idCadena).Select(d => d.id).First();
                        //var idRuta = db.rutaTienda.First(p => p.idTienda == idTienda).idRuta;
                        //idPromotor = db.ruta.First(d => d.id == idRuta).idPromotor ?? null;

                        if (db.producto.Where(d => d.sku == oFila.Sku).Any())
                        {
                            idProducto = db.producto.Where(d => d.sku == oFila.Sku).Select(d => d.id).First();

                            decimal ventaActual = Convert.ToDecimal(oFila.Cantidad);


                            inventarios nuevo = new inventarios();

                            var tuple = StatusCalculator.CalculateActualStatus(
                                                                                idSemana,
                                                                                idProducto,
                                                                                idTienda,
                                                                                ventaActual,
                                                                                idCliente,
                                                                                Convert.ToDecimal(oFila.Inventario));
                            int? idInventarioActual = tuple.Item1 ?? 7;
                            decimal? diasInventario = tuple.Item2;
                            int? idStatusComparado = null;

                            if (idProducto != null && idTienda != null)
                            {
                                idStatusComparado = StatusCalculator.CalculateStatus(new Controllers.StatusInput
                                {
                                    idInventarioActual = idInventarioActual,
                                    idTienda = (int)idTienda,
                                    idProducto = (int)idProducto,
                                    numSemana = idSemana
                                });
                            }

                            nuevo.diasInventario = diasInventario;
                            //nuevo.idPromotor = idPromotor;
                            nuevo.idCriterio = idStatusComparado;
                            nuevo.idEstatusInv = idInventarioActual;
                            nuevo.numSemana = idSemana;
                            nuevo.idProducto = idProducto;
                            nuevo.idCadena = idCadena;
                            nuevo.idTienda = idTienda;
                            nuevo.numTienda = oFila.NumeroTienda;
                            nuevo.sku = oFila.Sku;
                            nuevo.cantidadVendida = Convert.ToDecimal(oFila.Cantidad);
                            nuevo.cantidadInventario = Convert.ToInt32(oFila.Inventario);
                            nuevo.idCliente = idCliente;
                            db.inventarios.Add(nuevo);
                            var result = db.SaveChanges();
                        }
                        else
                        {
                            count++;
                            continue;
                        }

                    }
                    else
                    {
                        count++;
                        continue;
                    }
                    

                    
                }

            }

        }


        #endregion
    }
}