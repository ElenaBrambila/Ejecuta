using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Clouster
    {
        public static SelectList getCloustersSL(int id = 0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cClouster
                          orderby d.nombre
                          select d;


                SelectList slc = null;
                if (id == 0)
                    slc = new SelectList(lst, "id", "nombre");
                else
                    slc = new SelectList(lst, "id", "nombre", id);

                return slc;
            }
            catch { return null; }
        }
    }
}