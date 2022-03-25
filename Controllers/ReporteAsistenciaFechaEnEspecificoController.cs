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
    public class ReporteAsistenciaFechaEnEspecificoController : BaseController
    {
        // GET: ReporteAsistenciaFechaEnEspecifico
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;


            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
           
        }

        #region Grid
        public ActionResult Listado(ReporteAsistenciaFechaEnEspecificoViewModel model)
        {


            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteAsistenciaFechaEnEspecificoViewModel model)
        {

            var Reporte = new List<TableReporteEfectividadNewViewModel>();
            int? id, filter = 0;
            IEnumerable<TableReporteAsistenciaFechaEnEspecificoViewModel> lst = null;
            DateTime FechaInicio = FormatDatetime.GetDatetimeDefaultByString(model.fechaInicio);
            DateTime FechaFin = FormatDatetime.GetDatetimeDefaultByString(model.fechaFin);
            FechaFin = FechaFin.AddHours(23);

            (id, filter) = (model.idPromotor != 0) ?
                          (model.idPromotor, 0) : (model.idCoordinador != 0) ?
                          (model.idCoordinador, 1) : (model.idCliente != 0) ? (model.idCliente, 2) : (0, 3);

           var query = from d in db.spxGetNewResumenEjecutivoChar(FechaInicio, FechaFin, id, model.idCliente, filter, model.idPlaza)

                    select new TableReporteAsistenciaFechaEnEspecificoViewModel
                    {
                        plaza = d.plaza,
                        promotor = d.promotor,
                        fecha = d.fecha,
                        entrada = d.entrada,
                        tiempoEfectivo = d.tiempoEfectivo,
                        tiempoTotal = d.tiempoTotal,
                        tiempoTraslado = d.tiempoTraslado,
                        salida = d.salida,
                        cliente = d.cliente,
                        coordinador = d.coordinador,
                        tiendasAVisitar = d.ta,
                        tiendasVisitadas = d.cob,
                        tiendasNoVisitadas = (d.ta - d.cob),
                        dentroPerimetro = d.dp,
                        fueraPerimetro = d.fp,
                        ruta = d.ruta,
                        turno = d.turno
                    };
            //ejecutamos el query
            lst = query.ToList();

            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}