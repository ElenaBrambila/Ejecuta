using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    /// <summary>
    /// Helper model que tiene metodos de la entidad usuario
    /// </summary>
    public class Producto : producto
    {
        public static bool Existe(string sku,int id=0)
        {
            try
            {
                using(IntegramsaUltimateEntities db = new IntegramsaUltimateEntities()){

                    IEnumerable<producto> lst;
                    if (id != 0)
                    {

                        lst = from d in db.producto
                              where d.idEstado == 1 && d.sku.Equals(sku) && d.id!=id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.producto
                              where d.idEstado == 1 && d.sku.Equals(sku)
                              select d;
                    }

                    //si existe un usuario regresa true
                    if (lst.Count() > 0)
                        return true;
                    

                }
                return false;
            }catch(Exception ex){
                return false;
            }
        }

    }
}