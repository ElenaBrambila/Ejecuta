using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Cadena 
    {
        public static bool Existe(string nombre, int id = 0)
        {
            try
            {
                using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
                {

                    IEnumerable<cadena> lst;
                    if (id != 0)
                    {

                        lst = from d in db.cadena
                              where d.idEstado == 1 && d.nombre.Equals(nombre) && d.id != id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.cadena
                              where d.idEstado == 1 && d.nombre.Equals(nombre)
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

        public static SelectList getCadenasSL(int id=0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cadena
                          where d.idEstado==1
                          orderby d.nombre
                          select d;


                SelectList slc = null;
                if(id==0)
                    slc=new SelectList(lst, "id", "nombre");
                else
                    slc = new SelectList(lst, "id", "nombre",id);

                return slc;
            }
            catch { return null; }
        }
    }
}