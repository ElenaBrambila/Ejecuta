using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class ObtieneMunicipio
    {
        public static SelectList getcMunicipioSL()
        {
            try
            {

                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cmunicipio

                          orderby d.Nombre
                          select d;
                SelectList slc = new SelectList(lst, "idcMunicipio", "Nombre");

                return slc;
            
            }

            catch { return null; }
        }
    }
}