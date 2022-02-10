using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class Ano
    {
        public static SelectList getAnosSL(int ano=0)
        {
            try
            {
                Dictionary<int, string> lst = new Dictionary<int, string>();
                 SelectList slc=null;

                for (int i = 2016; i <= DateTime.Now.Year; i++)
                {
                    lst.Add(i, i.ToString());
                }

                if(ano==0)
                  slc = new SelectList(lst, "Key", "Value");
                else
                    slc = new SelectList(lst, "Key", "Value",ano);

                return slc;
            }
            catch (Exception ex) { return null; }
        }
    }
}