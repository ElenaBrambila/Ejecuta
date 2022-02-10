using IntegramsaUltimate.Models.FilterViewModel;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteAsistenciaFechaEnEspecificoPromedioController : BaseController
    {
        // GET: ReporteAsistenciaFechaEnEspecificoPromedio
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
            IEnumerable<TableReporteAsistenciaFechaEnEspecificoPromedioViewModel> lst = null;
            IQueryable<TableReporteAsistenciaFechaEnEspecificoPromedioViewModel> query = null;

            //casteamos fechas
            DateTime FechaInicio = DateTime.ParseExact(model.fechaInicio + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime FechaFin = DateTime.ParseExact(model.fechaFin + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            query = from d in db.fnReporteAsistenciaFechaEspecificaPromedio(FechaInicio, FechaFin, model.idCliente)

                    select new TableReporteAsistenciaFechaEnEspecificoPromedioViewModel
                    {
                        plaza = d.plaza,
                        promotor = d.nombre,
                        fecha = (model.fechaInicio+" "+model.fechaFin),
                        entrada = d.Entrada,
                        salida = d.Salida,
                        tiempoEfectivo = d.tiempoEfectivo.ToString(),
                        tiendasAVisitar = d.tiendasAVisitar,
                        tiendasVisitadas = d.tiendasVisitadas,
                        tiendasNoVisitadas = (d.tiendasAVisitar - d.tiendasVisitadas),
                        dentroPerimetro = d.dentroPerimetro,
                        fueraPerimetro = d.fueraPerimetro,


                    };


            //ejecutamos el query
            lst = query.ToList();


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}