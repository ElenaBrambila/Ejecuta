using IntegramsaUltimate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IntegramsaUltimate.Models.HelperModels
{
    public class Plaza
    {
        public static SelectList getcPlazaSL()
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cPlaza

                          orderby d.nombre
                          select d;

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }    


         public static bool Existe(PlazaMunicipioViewModel model)
            {
                try
                {
                    using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
                    {

                        IEnumerable<PlazaMunicipio> lst=null;
                        if (model.id == 0)
                         {
                        //para agregar
                             lst = db.PlazaMunicipio.Where(d => d.idMunicipio == model.idMunicipio);
                        }
                        else
                        {
                            //para modificar
                            lst = db.PlazaMunicipio.Where(d => d.idMunicipio == model.idMunicipio && d.id != model.id);

                           
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