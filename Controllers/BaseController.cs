using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using System.Data.Entity.Infrastructure;

namespace IntegramsaUltimate.Controllers
{
    public class BaseController : Controller
    {

        public IntegramsaUltimateEntities db;
        public usuario oUsuario = new usuario();

        public string error = ""; //sirve el error 

        public BaseController()
        {
            db = new IntegramsaUltimateEntities();
            var db2 = (db as IObjectContextAdapter).ObjectContext;
            db2.CommandTimeout = 7200;
        }

        /// <summary>
        /// obtiene la sesion del usuario 
        /// </summary>
        public void ObtieneSesion()
        {
            oUsuario = (usuario)Session["Usuario"];
        }

        /// <summary>
        /// Obtiene los errores del modelo
        /// </summary>
        /// <returns></returns>
        public string getErroresModelo()
        {
            string errores = "";
            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errores += error.ErrorMessage + "<br>";
                }
            }

            return errores;
        }
    }
}