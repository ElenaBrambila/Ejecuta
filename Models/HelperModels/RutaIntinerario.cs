using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class RutaIntinerario
    {
        public static bool ExisteEnlstRutaIntinerario(IEnumerable<rutaIntinerario> lst,int? idTienda, int? numSemana, int? idDia, int? idRuta)
        {
            try
            {
                if(lst.Where(d=>d.idEstado==1 &&
                                d.idTienda==idTienda &&
                                d.idRuta==idRuta&&
                                d.idDiaSemana==idDia &&
                                d.numSemana == numSemana).Count() > 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}