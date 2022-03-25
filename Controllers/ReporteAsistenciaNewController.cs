using IntegramsaUltimate.Models.FilterViewModel;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteAsistenciaNewController : BaseController
    {
        // GET: ReporteAsistenciaNew
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;


            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }


        public ActionResult VerMapa(int idReporteTienda)
        {

            ReporteAsistenciaNewMapa oRANM = (from d in db.reporteTienda
                                              where d.id == idReporteTienda && d.idEstado == 1
                                              select new ReporteAsistenciaNewMapa
                                              {
                                                  tiendaLatitud = d.rutaIntinerario.tienda.ubicacion.Latitude.ToString(),
                                                  tiendaLongitud = d.rutaIntinerario.tienda.ubicacion.Longitude.ToString(),
                                                  posicionLatitud = d.ubicacion.Latitude.ToString(),
                                                  posicionLongitud = d.ubicacion.Longitude.ToString(),
                                                  Tienda = d.rutaIntinerario.tienda.nombre
                                              }).First();

            return View(oRANM);
        }

        #region Grid
        public ActionResult Listado(ReporteAsistenciaNewFilterViewModel model)
        {


            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteAsistenciaNewFilterViewModel model)
        {
            IEnumerable<TableReporteAsistenciaNewViewModel> lst = null;
            IQueryable<TableReporteAsistenciaNewViewModel> query = null;
            List<TableReporteAsistenciaNewViewModel> reporte = new List<TableReporteAsistenciaNewViewModel>();
            DateTime FechaInicio;
            DateTime FechaFin;
           // DateTime DateLess3Months = DateTime.Today.AddMonths(-3);
           // string DateLess3MonthsString = DateLess3Months.ToString("dd/MM/yyyy");
           // DateTime.ParseExact("04/30/2013 23:00", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (model.fechaInicio == null)
            {
                FechaInicio = DateTime.ParseExact(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy") + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                FechaInicio = DateTime.ParseExact(model.fechaInicio + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (model.fechaFin == null)
            {
                DateTime dateTimeNow = DateTime.Now;
                string dateOnlyString = dateTimeNow.ToString("dd/MM/yyyy");
                FechaFin = DateTime.ParseExact(dateOnlyString + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                FechaFin = DateTime.ParseExact(model.fechaFin + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            //Verificamos si la fecha de inicio es mayor a 3 meses para que busque en otra tabla 
            if (model.idCliente != null) {
                if (FechaInicio >= DateTime.Today.AddMonths(-3))
                {

                    var querys = (from d in db.fnReporteAsistenciaNew(FechaInicio, FechaFin).Where(d=>d.idCliente == model.idCliente)
                                  group d by
                                  new TableReporteAsistenciaNewViewModel
                                  {
                                      id = d.id,
                                      idCliente = d.idCliente,
                                      Plaza = d.Plaza,
                                      Promotor = d.nombre,
                                      Cadena = d.cadena,
                                      Tienda = d.tienda,
                                      Determinante = d.codigo,
                                      Fecha = d.dfechaSalida,
                                      HoraEntrada = d.horaEntrada,
                                      HoraSalida = d.horaSalida,
                                      Perimetro = d.perimetro,
                                      tiempoTienda = d.tiempoTienda,
                                      ano = d.ano,
                                      numSemana = d.numSemana

                                  } into grupo
                                  select grupo).ToList();
                    foreach (var grupo in querys)
                    {
                        reporte.Add(new TableReporteAsistenciaNewViewModel
                        {
                            id = grupo.Key.id,
                            idCliente = grupo.Key.idCliente,
                            Plaza = grupo.Key.Plaza,
                            Promotor = grupo.Key.Promotor,
                            Cadena = grupo.Key.Cadena,
                            Tienda = grupo.Key.Tienda,
                            Determinante = grupo.Key.Determinante,
                            Fecha = grupo.Key.Fecha,
                            HoraEntrada = grupo.Key.HoraEntrada,
                            HoraSalida = grupo.Key.HoraSalida,
                            Perimetro = grupo.Key.Perimetro,
                            tiempoTienda = grupo.Key.tiempoTienda,
                            ano = grupo.Key.ano,
                            numSemana = grupo.Key.numSemana
                        });
                    }

                }
                else
                {
                    var querys = (from d in db.fnReporteAsistenciaPas(FechaInicio, FechaFin).Where(d => d.idCliente == model.idCliente)
                                  group d by
                                  new TableReporteAsistenciaNewViewModel
                                  {
                                      id = d.id,
                                      idCliente = d.idCliente,
                                      Plaza = d.Plaza,
                                      Promotor = d.nombre,
                                      Cadena = d.cadena,
                                      Tienda = d.tienda,
                                      Determinante = d.codigo,
                                      Fecha = d.dfechaSalida,
                                      HoraEntrada = d.horaEntrada,
                                      HoraSalida = d.horaSalida,
                                      Perimetro = d.perimetro,
                                      tiempoTienda = d.tiempoTienda,
                                      ano = d.ano,
                                      numSemana = d.numSemana

                                  } into grupo
                                  select grupo).ToList();
                    foreach (var grupo in querys)
                    {
                        reporte.Add(new TableReporteAsistenciaNewViewModel
                        {
                            id = grupo.Key.id,
                            idCliente = grupo.Key.idCliente,
                            Plaza = grupo.Key.Plaza,
                            Promotor = grupo.Key.Promotor,
                            Cadena = grupo.Key.Cadena,
                            Tienda = grupo.Key.Tienda,
                            Determinante = grupo.Key.Determinante,
                            Fecha = grupo.Key.Fecha,
                            HoraEntrada = grupo.Key.HoraEntrada,
                            HoraSalida = grupo.Key.HoraSalida,
                            Perimetro = grupo.Key.Perimetro,
                            tiempoTienda = grupo.Key.tiempoTienda,
                            ano = grupo.Key.ano,
                            numSemana = grupo.Key.numSemana
                        });
                    }
                }
            }
            else {
                if (FechaInicio >= DateTime.Today.AddMonths(-3))
                {

                    var querys = (from d in db.fnReporteAsistenciaNew(FechaInicio, FechaFin)
                                  group d by
                                  new TableReporteAsistenciaNewViewModel
                                  {
                                      id = d.id,
                                      idCliente = d.idCliente,
                                      Plaza = d.Plaza,
                                      Promotor = d.nombre,
                                      Cadena = d.cadena,
                                      Tienda = d.tienda,
                                      Determinante = d.codigo,
                                      Fecha = d.dfechaSalida,
                                      HoraEntrada = d.horaEntrada,
                                      HoraSalida = d.horaSalida,
                                      Perimetro = d.perimetro,
                                      tiempoTienda = d.tiempoTienda,
                                      ano = d.ano,
                                      numSemana = d.numSemana

                                  } into grupo
                                  select grupo).ToList();
                    foreach (var grupo in querys)
                    {
                        reporte.Add(new TableReporteAsistenciaNewViewModel
                        {
                            id = grupo.Key.id,
                            idCliente = grupo.Key.idCliente,
                            Plaza = grupo.Key.Plaza,
                            Promotor = grupo.Key.Promotor,
                            Cadena = grupo.Key.Cadena,
                            Tienda = grupo.Key.Tienda,
                            Determinante = grupo.Key.Determinante,
                            Fecha = grupo.Key.Fecha,
                            HoraEntrada = grupo.Key.HoraEntrada,
                            HoraSalida = grupo.Key.HoraSalida,
                            Perimetro = grupo.Key.Perimetro,
                            tiempoTienda = grupo.Key.tiempoTienda,
                            ano = grupo.Key.ano,
                            numSemana = grupo.Key.numSemana
                        });
                    }

                }
                else
                {
                    var querys = (from d in db.fnReporteAsistenciaPas(FechaInicio, FechaFin)
                                  group d by
                                  new TableReporteAsistenciaNewViewModel
                                  {
                                      id = d.id,
                                      idCliente = d.idCliente,
                                      Plaza = d.Plaza,
                                      Promotor = d.nombre,
                                      Cadena = d.cadena,
                                      Tienda = d.tienda,
                                      Determinante = d.codigo,
                                      Fecha = d.dfechaSalida,
                                      HoraEntrada = d.horaEntrada,
                                      HoraSalida = d.horaSalida,
                                      Perimetro = d.perimetro,
                                      tiempoTienda = d.tiempoTienda,
                                      ano = d.ano,
                                      numSemana = d.numSemana

                                  } into grupo
                                  select grupo).ToList();
                    foreach (var grupo in querys)
                    {
                        reporte.Add(new TableReporteAsistenciaNewViewModel
                        {
                            id = grupo.Key.id,
                            idCliente = grupo.Key.idCliente,
                            Plaza = grupo.Key.Plaza,
                            Promotor = grupo.Key.Promotor,
                            Cadena = grupo.Key.Cadena,
                            Tienda = grupo.Key.Tienda,
                            Determinante = grupo.Key.Determinante,
                            Fecha = grupo.Key.Fecha,
                            HoraEntrada = grupo.Key.HoraEntrada,
                            HoraSalida = grupo.Key.HoraSalida,
                            Perimetro = grupo.Key.Perimetro,
                            tiempoTienda = grupo.Key.tiempoTienda,
                            ano = grupo.Key.ano,
                            numSemana = grupo.Key.numSemana
                        });
                    }
                }

            }
           

           // query = query.OrderBy(d => d.HoraEntrada);
            //ejecutamos el query
           // lst = query.ToList();
            return Json(reporte.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}