using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Inventario
    {
        public static SelectList GetCadena()
        {
            try
            {
                using (IntegramsaUltimateDataSet db = new IntegramsaUltimateDataSet())
                {
                    var cadena = db.cadena.ToList();
                    SelectList slc = null;
                    slc = new SelectList("id", "nombre");
                    return slc;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}