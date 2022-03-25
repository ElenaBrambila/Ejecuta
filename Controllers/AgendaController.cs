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
    public class AgendaController : BaseController
    {
        // GET: RutaIntinerario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agenda(string mes,int idPromotor, int idCoordinador, int idCliente)
        {
            string[] parts = (mes).Split('/');
            int? id, filter = 0;
            IEnumerable<TableUsuarioAgendaViewModel> lstPromotores = null;
            IEnumerable<TableAgendaViewModel> lst = null;

            if (idPromotor != 0)
            {

                lstPromotores  = (from d in db.rutaTienda
                      join co in db.ruta on d.idRuta equals co.id
                      join pr in db.usuario on co.idPromotor equals pr.id
                      where co.idPromotor == idPromotor && d.idEstado == 1
                      select new TableUsuarioAgendaViewModel
                      {
                          id = pr.id,
                          promotor = pr.paterno + " " + pr.materno + " " + pr.nombre
                      }).Distinct().ToList();
            }
            else
            {
                lstPromotores = (from d in db.rutaTienda
                      join co in db.ruta on d.idRuta equals co.id
                      join pr in db.usuario on co.idPromotor equals pr.id
                      join su in db.usuario on pr.idSupervisor equals su.id
                      join cor in db.usuario on su.idSupervisor equals cor.id
                      where cor.id == idCoordinador && d.idEstado == 1
                      select new TableUsuarioAgendaViewModel
                      {
                          id = pr.id,
                          promotor = pr.paterno + " " + pr.materno + " " + pr.nombre
                      }).Distinct().ToList();
            }

            (id, filter) = (idPromotor != 0) ?
                           (idPromotor, 0) : (idCoordinador != 0) ?
                           (idCoordinador, 1) : (idCliente != 0) ? (idCliente, 2) : (0, 3);
            var query = from d in db.spxGetSchedule(idCliente, mes, id, filter)

                        select new TableAgendaViewModel
                        {
                            tienda = d.tienda,
                            cadena = d.cadena,
                            ruta = d.ruta,
                            promotor = d.promotor,
                            idPromotor = d.idPromotor,
                            idCliente = d.idCliente,
                            idCoordinador = d.idCoordinador,
                            L1 = d.L1,
                            M1 = d.M1,
                            I1 = d.I1,
                            J1 = d.J1,
                            V1 = d.V1,
                            S1 = d.S1,
                            L2 = d.L2,
                            M2 = d.M2,
                            I2 = d.I2,
                            J2 = d.J2,
                            V2 = d.V2,
                            S2 = d.S2,
                            L3 = d.L3,
                            M3 = d.M3,
                            I3 = d.I3,
                            J3 = d.J3,
                            V3 = d.V3,
                            S3 = d.S3,
                            L4 = d.L4,
                            M4 = d.M4,
                            I4 = d.I4,
                            J4 = d.J4,
                            V4 = d.V4,
                            S4 = d.S4,
                            STL1 = d.STL1,
                            STM1 = d.STM1,
                            STI1 = d.STI1,
                            STJ1 = d.STJ1,
                            STV1 = d.STV1,
                            STS1 = d.STS1,
                            STL2 = d.STL2,
                            STM2 = d.STM2,
                            STI2 = d.STI2,
                            STJ2 = d.STJ2,
                            STV2 = d.STV2,
                            STS2 = d.STS2,
                            STL3 = d.STL3,
                            STM3 = d.STM3,
                            STI3 = d.STI3,
                            STJ3 = d.STJ3,
                            STV3 = d.STV3,
                            STS3 = d.STS3,
                            STL4 = d.STL4,
                            STM4 = d.STM4,
                            STI4 = d.STI4,
                            STJ4 = d.STJ4,
                            STV4 = d.STV4,
                            STS4 = d.STS4
                        };

            //ejecutamos el query
            lst = query.ToList();

            //ViewBag.idRuta = Ruta.id;
            ViewBag.idPromotor = idPromotor;
            ViewBag.Mes = mes;
            ViewBag.Semana1 = int.Parse(parts[0]);
            ViewBag.Semana2 = int.Parse(parts[1]);
            ViewBag.Semana3 = int.Parse(parts[2]);
            ViewBag.Semana4 = int.Parse(parts[3]);
            ViewBag.Year = int.Parse(parts[4]);
           ViewBag.lstIntinerario = lstPromotores;
            return View(lst);
        }

        [HttpPost]
        public ActionResult GuardaDia(AgendaViewModel model)
        {
            try
            {

                schedule oSchedule = new schedule();
                oSchedule.idDiaSemana = model.idDiaSemana;
                oSchedule.idEncargado = 0;
                oSchedule.idEstado = 1;
                oSchedule.idPromotor = model.idPromotor;
                oSchedule.idRuta = model.idRuta;
                oSchedule.idRutaTienda = model.idRutaTienda;
                oSchedule.idTienda = model.idTienda;
                oSchedule.numSemana = model.numSemana;
                oSchedule.semana = model.Semana;
                oSchedule.storecheck = 1;
                oSchedule.mes = model.mes;
                oSchedule.ano = 2000+model.year;

                /*var lstRI = db.schedule.Where(d => d.id == model.idRutaTienda &&
                                             d.idRuta == model.idRuta && d.idEstado == 1 &&
                                             d.numSemana == model.numSemana &&
                                             d.idDiaSemana == model.idDiaSemana).ToList();
                lstRI.ForEach(d => d.idEstado = 3);*/
                db.schedule.Add(oSchedule);
                db.SaveChanges();


                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);

            }
        }

        [HttpPost]
        public ActionResult EliminaDia(AgendaRegistroViewModel model)
        {
            try
            {
                //si existia ya esta ruta con esta tienda con este dia agregado, lo eliminamos
                EliminaRutaIntinerario(model.idRutaTienda, model.Semana, model.idDiaSemana);
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);

            }
        }

        private void EliminaRutaIntinerario(int? id, int semana, int dia)
        {
            var lstRI = db.schedule.Where(d => d.semana == semana && d.idRutaTienda == id && d.idDiaSemana == dia).ToList();
            //modificamos el listado entero, por si existen varios
            foreach (var selectedDetail in lstRI)
            {
                db.schedule.Remove(selectedDetail);
            }
            db.SaveChanges();
        }


    }
}