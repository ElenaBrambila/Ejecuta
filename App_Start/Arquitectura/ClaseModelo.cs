using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Arquitectura
{
    public class ClaseModelo
    {
        protected string BRINCO = "\n";
        protected List<string> lErrores = new List<string>();

        /// <summary>
        /// agrega un error
        /// </summary>
        /// <returns></returns>
        public void addError(string error)
        {
            lErrores.Add(error);
        }
        /// <summary>
        /// metodo que regresa el listado de errores
        /// </summary>
        /// <returns></returns>
        public string getErrores()
        {
            string error = "";
            foreach (string err in lErrores)
            {
                error += err + BRINCO;
            }
            return error;
        }

        /// <summary>
        /// metodo privado que sirve para inicializar los errores
        /// </summary>
        protected void clearErrores()
        {
            lErrores = new List<string>();
        }
    }
}