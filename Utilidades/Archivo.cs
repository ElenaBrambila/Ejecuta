using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Utilidades
{
    public class Archivo
    {
        /// <summary>
        /// obtiene el contenido de un archivo en string
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public static string GetStringOfFile(string pathFile)
        {
            try
            {
                string contenido = File.ReadAllText(pathFile);

                return contenido;
            }
            catch
            {
                return "";
            }
        }
    }
}