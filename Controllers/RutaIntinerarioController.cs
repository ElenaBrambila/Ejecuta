using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class RutaIntinerarioController : BaseController
    {
        // GET: RutaIntinerario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ruta(int idRuta)
        {
            IEnumerable<TableRutaIntinerario> lst = from d in db.rutaTienda
                                                    where d.idRuta == idRuta && d.idEstado==1
                                                    select new TableRutaIntinerario
                                                    {
                                                        idTienda = d.idTienda,
                                                        codigo=d.tienda.codigo,
                                                        nombre=d.tienda.nombre,
                                                        cadena=d.tienda.cadena.nombre,
                                                        clouster=d.cClouster.nombre,
                                                        visitas=d.cFactorVisita.nombre

                                                    };

            IEnumerable<rutaIntinerario> lstIntinerario = from d in db.rutaIntinerario
                                                          where d.idRuta == idRuta && d.idEstado == 1
                                                          select d;

            ViewBag.idRuta = idRuta;
            ViewBag.lstIntinerario = lstIntinerario;

            return View(lst);
        }

        [HttpPost]
        public ActionResult GuardaDia(RutaIntinerarioViewModel model)
        {
            try
            {
                //si existia ya esta ruta con esta tienda con este dia agregado, lo eliminamos
                EliminaRutaIntinerario(model.idRuta,model.idTienda,model.numSemana,model.idDiaSemana);

                rutaIntinerario oRutaIntinierario = new rutaIntinerario();
                oRutaIntinierario.idDiaSemana = model.idDiaSemana;
                oRutaIntinierario.idEstado = 1;
                oRutaIntinierario.idRuta = model.idRuta;
                oRutaIntinierario.idTienda = model.idTienda;
                oRutaIntinierario.orden = ObtenerNumeroOrden(model.idRuta,model.numSemana,model.idDiaSemana);
                oRutaIntinierario.numSemana = model.numSemana;

                db.rutaIntinerario.Add(oRutaIntinierario);
                db.SaveChanges();

                //Guardamos el Reporte Itinerario Promotor
                int numeroSemana = 0;
                try
                {
                    var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                    numeroSemana = cal.GetWeekOfYear(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday);

                }
                catch { }
                DateTime fechaDomingoSemana = db.Database.SqlQuery<DateTime>("select dbo.obtenerFechaInicioByNumeroSemana(" + numeroSemana + ",'" + DateTime.Now.Year + "')").Single();

                int idPromotor = db.Database.SqlQuery<int>("select idPromotor from dbo.ruta where id=" + model.idRuta).Single();
                //creamos la rutaintinerariopromotor
                reporteIntinerarioPromotor oRIP = new reporteIntinerarioPromotor();
                oRIP.idEstado = 1;
                oRIP.idRutaIntinerario = oRutaIntinierario.id;//el id de la rutaIntinerario
                oRIP.fecha = DateTime.Now;
                oRIP.fechaReporte = fechaDomingoSemana.AddDays((double)oRutaIntinierario.idDiaSemana); //agregamos la fecha tomando la fecha de inicio de semana mas el dia que es, ejemplo (29-05-2016 + 1 (si es lunes) = 30-05-216)
                oRIP.ano = DateTime.Now.Year;
                oRIP.idUsuarioPromotor = idPromotor;
                oRIP.numSemana = numeroSemana;

                db.reporteIntinerarioPromotor.Add(oRIP);
                db.SaveChanges();




                return Content("1");
            }catch(Exception ex){
                return Content("Error de sistema: " + ex.Message);

            }
        }

        [HttpPost]
        public ActionResult EliminaDia(RutaIntinerarioViewModel model)
        {
            try
            {
                //si existia ya esta ruta con esta tienda con este dia agregado, lo eliminamos
                EliminaRutaIntinerario(model.idRuta, model.idTienda, model.numSemana, model.idDiaSemana);
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);

            }
        }


        public ActionResult VerHorario(int idRuta)
        {
            
            IEnumerable<rutaIntinerario> lstIntinerario = from d in db.rutaIntinerario
                                                          where d.idEstado == 1 && d.idRuta == idRuta
                                                          orderby d.orden
                                                          select d;
            ViewBag.idRuta = idRuta;

            return View(lstIntinerario);
        }


        public ActionResult GuardaOrden(IEnumerable<int> lstIdsOrden)
        {
            try
            {
                int num=1;
                //recorremos para ir dandoles el orden
                foreach(int idIntinerario in lstIdsOrden){

                    rutaIntinerario oRI = db.rutaIntinerario.Find(idIntinerario);
                    oRI.orden = num++;

                    db.Entry(oRI).State = EntityState.Modified;
                    db.SaveChanges();

                }

               
                return Content("1");
            }catch(Exception ex){
                return Content("Error de sistema: " + ex.Message);

            }
        }

        public ActionResult VerMapa(int idRuta, int numSemana, int idDiaSemana)
        {
            IEnumerable<rutaIntinerario> lstIntinerario = from d in db.rutaIntinerario
                                                          where d.idRuta == idRuta && d.numSemana == numSemana && d.idDiaSemana == idDiaSemana && d.idEstado==1
                                                          orderby d.orden 
                                                          select d;
            return View(lstIntinerario);
        }
        #region HELPERS
        private void EliminaRutaIntinerario(int idRuta, int idTienda, int numSemana, int idDia)
        {
            var lstRI = db.rutaIntinerario.Where(d => d.idRuta == idRuta &&
                                                      d.idTienda == idTienda && 
                                                      d.numSemana == numSemana && 
                                                      d.idDiaSemana == idDia && 
                                                      d.idEstado == 1).ToList();
            //modificamos el listado entero, por si existen varios
            lstRI.ForEach(d=>d.idEstado=3);
            db.SaveChanges();
        }

        /// <summary>
        /// obtiene el orden siguiente en la ruta
        /// </summary>
        /// <param name="idRuta"></param>
        /// <returns></returns>
        private int ObtenerNumeroOrden(int idRuta, int numSemana, int idDiaSemana)
        {
            int orden = 1;

            rutaIntinerario oRI = (from d in db.rutaIntinerario
                                  where d.idRuta == idRuta && d.idEstado == 1 && d.numSemana==numSemana && d.idDiaSemana==idDiaSemana
                                  orderby d.orden descending
                                  select d).FirstOrDefault();

            if (oRI != null) //si existe ya un elemento
                orden = (int)oRI.orden + 1;               

            return orden;
        }
        #endregion
    }
}