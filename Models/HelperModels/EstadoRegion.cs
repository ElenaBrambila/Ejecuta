using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class EstadoRegion
    {

        public static SelectList getEstadoRegionSL()
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.destado
                         
                          orderby d.Nombre
                          select d;

                SelectList slc = new SelectList(lst, "iddEstado", "Nombre");

                return slc;
            }
            catch { return null; }
        }


    }
}