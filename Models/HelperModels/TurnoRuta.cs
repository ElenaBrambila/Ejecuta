using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class TurnoRuta
    {
        public static SelectList getTurnosSL()
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();

                var lst = from d in db.cTurnoRuta
                          select d;

                SelectList slc = new SelectList(lst, "id", "nombre");

                return slc;
            }
            catch { return null; }
        }
    }
}