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
    public class Usuario : usuario
    {
        public static bool Existe(string email,int id=0)
        {
            try
            {
                using(IntegramsaUltimateEntities db = new IntegramsaUltimateEntities()){

                    IEnumerable<usuario> lst;
                    if (id != 0)
                    {

                        lst = from d in db.usuario
                              where d.idEstado == 1 && d.email.Equals(email) && d.id!=id
                              select d;
                    }
                    else
                    {
                        lst = from d in db.usuario
                              where d.idEstado == 1 && d.email.Equals(email)
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


        public static SelectList getUsuariosByTipoSL(int idTipoUsuario)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.usuario
                          where d.idEstado == 1 && d.idTipoUsuario == idTipoUsuario
                          select new { id=d.id,nombre=d.nombre+" "+d.paterno+" "+d.materno};

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }

        public static SelectList getUsuariosByTipoSL(int idTipoUsuario, int idCliente)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.usuario
                          where d.idEstado == 1 && d.idTipoUsuario == idTipoUsuario && d.usuarioCliente.Where(e=>e.idCliente==idCliente).Count()>0
                          select new { id = d.id, nombre = d.nombre + " " + d.paterno + " " + d.materno };

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }

        public static IList<usuario> getUsuariosByTipoSL1(int idTipoUsuario, int idCliente)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.usuario
                          where d.idEstado == 1 && d.idTipoUsuario == idTipoUsuario && d.usuarioCliente.Where(e => e.idCliente == idCliente).Count() > 0
                          select d;

                SelectList slc = new SelectList(lst, "id", "nombre");

                return lst.ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Regresa si el promotor ya tiene una ruta asignada
        /// </summary>
        /// <param name="idPromotor"></param>
        /// <returns></returns>
        public static bool PromotorYaTieneRuta(int idPromotor, int id=0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                if (id == 0)
                {
                    var lst = from d in db.usuario
                              where d.id == idPromotor && d.ruta.Count() > 0
                              select d.id;
                    if (lst.Count() > 0) //si el promotor ya tiene una ruta regresamos true
                    {
                        return true;
                    }
                }
                else
                {
                    var lst = from d in db.usuario
                              where d.id == idPromotor && d.ruta.Count() > 0 && d.ruta.Where(e=>e.id!=id).Count()>0
                              select d.id;
                    if (lst.Count() > 0) //si el promotor ya tiene una ruta regresamos true
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return true;
            }

        }
    }
}