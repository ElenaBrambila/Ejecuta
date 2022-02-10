using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Criterio
    {
        public static SelectList getCriteriosSL(int id = 0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.inventarioCriterios                          
                          orderby d.criterioInv
                          select d;


                SelectList slc = null;
                if (id == 0)
                    slc = new SelectList(lst, "idCriterioInv", "criterioInv");
                else
                    slc = new SelectList(lst, "idCriterioInv", "criterioInv", id);

                return slc;
            }
            catch { return null; }
        }
    }
}