using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class RutaTienda
    {
        public static bool Existe(int idRuta,int idTienda, int id = 0)
        {
            try
            {
                using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
                {

                    IEnumerable<rutaTienda> lst;
                    if (id != 0)
                    {

                        lst = from d in db.rutaTienda
                              where d.idEstado == 1 && d.idTienda==idTienda && d.idRuta==idRuta && d.id != id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.rutaTienda
                              where d.idEstado == 1 && d.idTienda == idTienda && d.idRuta == idRuta
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

        public static bool ExisteEnRuta(int idTienda, int id = 0)
        {
            try
            {
                using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
                {

                    IEnumerable<rutaTienda> lst;
                    if (id != 0)
                    {

                        lst = from d in db.rutaTienda
                              where d.idEstado == 1 && d.idTienda == idTienda && d.id != id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.rutaTienda
                              where d.idEstado == 1 && d.idTienda == idTienda 
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