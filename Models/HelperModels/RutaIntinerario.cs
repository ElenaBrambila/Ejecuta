using IntegramsaUltimate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Models.HelperModels
{
    public class RutaIntinerario
    {
        public static bool ExisteEnlstRutaIntinerario(IEnumerable<rutaIntinerario> lst, int? idTienda, int? numSemana, int? idDia, int? idRuta)
        {
            try
            {
                if (lst.Where(d => d.idEstado == 1 &&
                                 d.idTienda == idTienda &&
                                 d.idRuta == idRuta &&
                                 d.idDiaSemana == idDia &&
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

        public static AgendaRegistroViewModel ExisteAgenda( int? idTienda, int? numSemana, int? idDia, int? idRuta, int? semana)
        {
            using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
            {
                
                var lsts = (from d in db.rutaIntinerario
                          where d.idDiaSemana == idDia && d.numSemana == numSemana && d.idRuta == idRuta && d.idTienda == idTienda && d.idEstado == 1
                            select new AgendaRegistroViewModel
                            {
                                id = d.id,
                            }).FirstOrDefault();
                if (lsts != null)
                {
                    var Ruta = (from d in db.schedule
                                where d.idRutaTienda == lsts.id && d.semana == semana
                                select new AgendaRegistroViewModel
                                {
                                    id = d.idRutaTienda,
                                    storeCheck = "checked"
                                }).FirstOrDefault();
                    if (Ruta != null) {
                        return Ruta;
                    }
                    else {
                        return lsts;
                    }
                }
                else { 
                }
                return null;
            }
        }
    }
    }
