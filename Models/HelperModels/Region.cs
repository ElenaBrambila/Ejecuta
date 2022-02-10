using IntegramsaUltimate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Region
    {

        public static SelectList getcZonaSL()
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cZona
                         
                          orderby d.nombre
                          select d;

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }

        public static bool Existe(EstadoViewModel model)
        {
            try
            {
                using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
                {

                    IEnumerable<ZonaEstado> lst;
                    if (model.id != null)
                    {

                        lst = from d in db.ZonaEstado
                              where d.iddEstado == model.iddEstado && d.id != model.id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.ZonaEstado
                              where d.iddEstado == model.iddEstado 
                              select d;
                    }

                    //si existe un usuario regresa true
                    if (lst.Count() > 0)
                        return true;


                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
         }


    }
}