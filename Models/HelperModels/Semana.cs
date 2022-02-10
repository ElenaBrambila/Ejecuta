using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Semana
    {
        public static SelectList getSemanasSL(int numSemana=0)
        {
            try
            {
                Dictionary<int, string> lstSemanas = new Dictionary<int, string>();
                SelectList slc = null;

                for (int i = 1; i < 53; i++)
                {
                    lstSemanas.Add(i, "Semana " + i);
                }

                if(numSemana==0)
                    slc = new SelectList(lstSemanas, "Key", "Value");
                else
                    slc = new SelectList(lstSemanas, "Key", "Value",numSemana);

                return slc;
            }
            catch(Exception ex) { return null; }
        }
    }
}