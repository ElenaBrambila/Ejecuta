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
using IntegramsaUltimate.Models;
using System.Data;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteEfectividadNewController : BaseController
    {
        // GET: ReporteEfectividadNew
        public ActionResult Index()
        {
            ObtieneSesion();
            //check sesion
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;


            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }

        #region Grid
        public ActionResult Listado(ReporteEfectividadNewFilterViewModel model)
        {

            return View(model);
        }
        /// <summary>
        /// Función para el llenado de registros del reporte de Efectividad
        /// Por cada filtro se realiza unllenado de modelo y una consulta diferente.
        /// En la función existe una lista "promotorUnico" que contiene a todos los promotores que existen en el rango de fechas que se llama, en el front se toma en cuenta para agruparlos
        /// Por cada día y tienda visitada hay 4 parámetros que se necesitan mostrar: ta (tiendas asignadas), cob (cobertura), fp (fuera de perimetro) y dp (dentro de perímetro)
        /// 
        /// </summary>
        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteEfectividadNewFilterViewModel model)
        {
            DateTime FechaInicio;
            DateTime FechaFin;
            if (model.fechaInicio == null)
            {
                FechaInicio = DateTime.ParseExact(DateTime.Today.ToString("dd/MM/yyyy") + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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
            
            List<string> promotorUnico = new List<string>();
            List<TableReporteEfectividadNewViewModel> Reporte = new List<TableReporteEfectividadNewViewModel>();
            
            if (model.idPromotor != 0)
            {
                var agrupacion = from p in db.fnReporteEfectividadNew_copy1(FechaInicio, FechaFin).Where(d => d.idPromotor == model.idPromotor)
                                 group p by new { p.idTienda, p.tienda, p.idPromotor, p.idCliente, p.promotor, p.idCoordinador, p.coordinador, p.codigoRuta, p.cadena, p.det, p.cliente } into grupo
                                 select grupo;

                foreach (var grupo in agrupacion)
                {
                    promotorUnico.Add(grupo.Key.promotor);
                    var idt = grupo.Key.idTienda;
                    var nomti = grupo.Key.tienda;
                    List<Info> inf = new List<Info>();
                    foreach (var objetoAgrupado in grupo)
                    {
                        inf.Add(new Info
                        {
                            nombre = objetoAgrupado.fechaText,
                            ta = objetoAgrupado.ta,
                            cob = objetoAgrupado.cob,
                            fp = objetoAgrupado.fp,
                            dp = objetoAgrupado.dp
                        });
                    }
                    Reporte.Add(new TableReporteEfectividadNewViewModel
                    {
                        
                        tienda = grupo.Key.tienda,
                        promotor = grupo.Key.promotor,
                        cliente = grupo.Key.cliente,
                        codigoRuta = grupo.Key.codigoRuta,
                        coordinador = grupo.Key.coordinador,
                        cadena = grupo.Key.cadena,
                        det = grupo.Key.det,
                        StartDate = FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = FechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                        info = inf
                    });
                }
            }
            else if (model.idCoordinador != 0)
            {
                var agrupacion = from p in db.fnReporteEfectividadNew_copy1(FechaInicio, FechaFin).Where(d => d.idCoordinador == model.idCoordinador && d.idCliente == model.idCliente)
                                 group p by new { p.idTienda, p.tienda, p.idPromotor, p.idCliente, p.promotor, p.idCoordinador, p.coordinador, p.codigoRuta, p.cadena, p.det, p.cliente } into grupo
                                 orderby grupo.Key.promotor
                                 select grupo;

                foreach (var grupo in agrupacion)
                {
                    promotorUnico.Add(grupo.Key.promotor);
                    var idt = grupo.Key.idTienda;
                    var nomti = grupo.Key.tienda;
                    List<Info> inf = new List<Info>();
                    foreach (var objetoAgrupado in grupo)
                    {
                        inf.Add(new Info
                        {
                            nombre = objetoAgrupado.fechaText,
                            ta = objetoAgrupado.ta,
                            cob = objetoAgrupado.cob,
                            fp = objetoAgrupado.fp,
                            dp = objetoAgrupado.dp
                        });
                    }
                    Reporte.Add(new TableReporteEfectividadNewViewModel
                    {
                        
                        tienda = grupo.Key.tienda,
                        promotor = grupo.Key.promotor,
                        cliente = grupo.Key.cliente,
                        codigoRuta = grupo.Key.codigoRuta,
                        coordinador = grupo.Key.coordinador,
                        cadena = grupo.Key.cadena,
                        det = grupo.Key.det,
                        StartDate = FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = FechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                        info = inf
                    });
                }
            }
            else if (model.idCliente != 0)
            {
                var agrupacion = from p in db.fnReporteEfectividadNew_copy1(FechaInicio, FechaFin).Where(d => d.idCliente == model.idCliente)
                                 group p by new { p.idTienda, p.tienda, p.idPromotor, p.idCliente, p.promotor, p.idCoordinador, p.coordinador, p.codigoRuta, p.cadena, p.det, p.cliente } into grupo
                                 select grupo;

                foreach (var grupo in agrupacion)
                {
                    promotorUnico.Add(grupo.Key.promotor);
                    var idt = grupo.Key.idTienda;
                    var nomti = grupo.Key.tienda;
                    List<Info> inf = new List<Info>();
                    foreach (var objetoAgrupado in grupo)
                    {
                        inf.Add(new Info
                        {
                            nombre = objetoAgrupado.fechaText,
                            ta = objetoAgrupado.ta,
                            cob = objetoAgrupado.cob,
                            fp = objetoAgrupado.fp,
                            dp = objetoAgrupado.dp
                        });
                    }
                    Reporte.Add(new TableReporteEfectividadNewViewModel
                    {
                        tienda = grupo.Key.tienda,
                        promotor = grupo.Key.promotor,
                        cliente = grupo.Key.cliente,
                        codigoRuta = grupo.Key.codigoRuta,
                        coordinador = grupo.Key.coordinador,
                        cadena = grupo.Key.cadena,
                        det = grupo.Key.det,
                        StartDate = FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = FechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                        info = inf
                    });
                }
            }
            else
            {
                var agrupacion = from p in db.fnReporteEfectividadNew_copy1(FechaInicio, FechaFin)
                                 group p by new { p.idTienda, p.tienda, p.idPromotor, p.idCliente, p.promotor, p.idCoordinador, p.coordinador, p.codigoRuta, p.cadena, p.det, p.cliente } into grupo
                                 select grupo;

                foreach (var grupo in agrupacion)
                {
                    promotorUnico.Add(grupo.Key.promotor);
                    var idt = grupo.Key.idTienda;
                    var nomti = grupo.Key.tienda;
                    List<Info> inf = new List<Info>();
                    foreach (var objetoAgrupado in grupo)
                    {
                        inf.Add(new Info
                        {
                            nombre = objetoAgrupado.fechaText,
                            ta = objetoAgrupado.ta,
                            cob = objetoAgrupado.cob,
                            fp = objetoAgrupado.fp,
                            dp = objetoAgrupado.dp
                        });
                    }
                    Reporte.Add(new TableReporteEfectividadNewViewModel
                    {
                        tienda = grupo.Key.tienda,
                        promotor = grupo.Key.promotor,
                        cliente = grupo.Key.cliente,
                        codigoRuta = grupo.Key.codigoRuta,
                        coordinador = grupo.Key.coordinador,
                        cadena = grupo.Key.cadena,
                        det = grupo.Key.det,
                        StartDate = FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = FechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                        info = inf
                    });
                }
            }
            promotorUnico = promotorUnico.Distinct().ToList();
            Reporte[0].uniquePromotorList = promotorUnico;

            return Json(Reporte.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}