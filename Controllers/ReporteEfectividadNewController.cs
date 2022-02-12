using IntegramsaUltimate.Models.FilterViewModel;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using System.Data;
using IntegramsaUltimate.Utilidades;

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
            var Reporte = new List<TableReporteEfectividadNewViewModel>();
            int? id, filter = 0;

            DateTime FechaInicio = FormatDatetime.GetDatetimeDefaultByString(model.fechaInicio);
            DateTime FechaFin = FormatDatetime.GetDatetimeDefaultByString(model.fechaFin);

            (id, filter) = (model.idPromotor != 0) ?
                           (model.idPromotor, 0) : (model.idCoordinador != 0) ?
                           (model.idCoordinador, 1) : (model.idCliente != 0) ? (model.idCliente, 2) : (0, 3);


            var result  =   from p 
                            in  db.spxGetNewReporteEfectividad(FechaInicio, FechaFin, id, model.idCliente, filter)
                                .ToList()
                                group p by new {
                                                    p.idTienda, 
                                                    p.tienda, 
                                                    p.idPromotor, 
                                                    p.idCliente, 
                                                    p.promotor, 
                                                    p.idCoordinador, 
                                                    p.coordinador, 
                                                    p.codigoRuta, 
                                                    p.cadena, 
                                                    p.det, 
                                                    p.cliente 
                                                } into grupo
                                select grupo;

            Reporte = result.ToLookup(item => new TableReporteEfectividadNewViewModel
            {
                tienda              = item.Key.tienda,
                promotor            = item.Key.promotor,
                cliente             = item.Key.cliente,
                codigoRuta          = item.Key.codigoRuta,
                coordinador         = item.Key.coordinador,
                cadena              = item.Key.cadena,
                det                 = item.Key.det,
                StartDate           = FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate             = FechaFin.ToString("yyyy-MM-dd HH:mm:ss"),
                uniquePromotorList  = item.ToLookup(i => i.promotor).Select(x => x.Key).ToList(),
                info                = item.ToLookup(x => new Info
                {
                    nombre  = x.fechaText,
                    ta      = x.ta,
                    cob     = x.cob,
                    fp      = x.fp,
                    dp      = x.dp

                }).Select(x => x.Key).ToList()
            }).Select(t => t.Key).ToList();

            return Json(Reporte.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}