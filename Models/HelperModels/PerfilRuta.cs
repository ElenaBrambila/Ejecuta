using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class PerfilRuta
    {
        public static SelectList getPerfilesSL()
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();

               
               var lst = from d in db.cPerfilRuta

                          select d;

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }
    }
}