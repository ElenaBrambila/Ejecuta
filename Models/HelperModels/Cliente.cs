using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Cliente
    {
        public static SelectList getClientesSL(int id = 0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.cliente
                          where d.idEstado == 1
                          orderby d.razonSocial
                          select d;


                SelectList slc = null;
                if (id == 0)
                    slc = new SelectList(lst, "id", "razonSocial");
                else
                    slc = new SelectList(lst, "id", "razonSocial", id);

                return slc;
            }
            catch { return null; }
        }
    }
}