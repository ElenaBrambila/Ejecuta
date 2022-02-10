using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using SpreadsheetLight;
using IntegramsaUltimate.Models;
using System.Data.Entity;

namespace IntegramsaUltimate.Excel
{
    /// <summary>
    /// Clase que se encarga de cargar un excel en la tabla productos
    /// </summary>
    public class ProductoExcel : Arquitectura.ClaseModelo
    {
       
        private int idCliente;
        private Stream archivo;
        List<Fila> lstFilas = new List<Fila>();

        private struct Fila
        {
            public string nombre { get; set; }
            public string sku { get; set; }
            public string presentacion { get; set; }
        }

        public ProductoExcel(Stream archivo, int idCliente)
        {
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
                    for (int row = stats.StartRowIndex; row <= stats.EndRowIndex; ++row)
                    {
                        string sku = sl.GetCellValueAsString(row, iStartColumnIndex);
                        string nombre = sl.GetCellValueAsString(row, iStartColumnIndex+1);
                        string presentacion = sl.GetCellValueAsString(row, iStartColumnIndex+2);

                        //validamos
                        if (sku.Equals("") || nombre.Equals("") || presentacion.Equals(""))
                        {
                            addError("El archivo de excel contiene productos que no tienen todos los valores capturados (sku="+sku+")");
                            return false;
                        }

                        Fila oFila = new Fila();
                        oFila.nombre = nombre;
                        oFila.sku = sku;
                        oFila.presentacion = presentacion;
                        lstFilas.Add(oFila);
                    }

                    
                }

                //insertamos valores
                Inserta();

            }catch(Exception ex){
                addError("Error de sistema: "+ex.Message);
                return false;
            }

            return true;
        }

        #region HELPERS
        private void Inserta()
        {
            using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
            {
                foreach (var oFila in lstFilas)
                {
                    //obtenemos producto si ya existe
                    var oProducto= db.producto.Where(d=>d.idEstado==1&&d.sku.Equals(oFila.sku.Trim())&&d.idCliente==idCliente).FirstOrDefault();

                    if(oProducto==null){


                        oProducto = new producto();
                        oProducto.nombre = oFila.nombre;
                        oProducto.sku = oFila.sku;
                        oProducto.idCliente = idCliente;
                        oProducto.presentacion = oFila.presentacion;
                        oProducto.idEstado = 1;

                        db.producto.Add(oProducto);
                    }
                    else
                    {
                        oProducto.nombre = oFila.nombre;
                        oProducto.sku = oFila.sku;
                        oProducto.presentacion = oFila.presentacion;
                        db.Entry(oProducto).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                }
             
            }
        
        }

      
        #endregion
    }
}