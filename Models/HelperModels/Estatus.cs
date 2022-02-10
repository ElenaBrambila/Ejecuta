using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Estatus
    {
        public static SelectList getEstatusSL(int id = 0)
        {
            try
            {
                IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();
                var lst = from d in db.inventarioEstatus
                          orderby d.estatusInventario
                          select d;


                SelectList slc = null;
                if (id == 0)
                    slc = new SelectList(lst, "idEstatusInv", "estatusInventario");
                else
                    slc = new SelectList(lst, "idEstatusInv", "estatusInventario", id);

                return slc;
            }
            catch { return null; }
        }
    }
}