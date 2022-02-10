using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.FilterViewModel;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteTiempoEfectivoController : BaseController
    {
        // GET: ReporteTiempoEfectivo
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;


            ViewBag.lstUsuarios = Models.HelperModels.Usuario.getUsuariosByTipoSL(2);
            ViewBag.lstSemanas = Models.HelperModels.Semana.getSemanasSL(Utilidades.Date.obtieneNumeroSemanaAno(DateTime.Now));
            ViewBag.lstAnos = Models.HelperModels.Ano.getAnosSL(DateTime.Now.Year);

            return View();
        }

        #region Grid
        public ActionResult Listado(ReporteAsistenciaCoberturaViewModel model)
        {


            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteAsistenciaCoberturaViewModel model)
        {
            IEnumerable<TableReporteTiempoEfectivoViewModel> lst = null;
            IQueryable<TableReporteTiempoEfectivoViewModel> query= null;

            query = from d in db.fnReporteTiempoEfectivo()
                  where d.ano==model.ano && model.numSemana==d.numSemana
                  select new TableReporteTiempoEfectivoViewModel
                  {
                     idUsuarioPromotor=d.idUsuarioPromotor,
                      Nombre = d.nombre,
                     dia1 = d.lunes,
                      dia2 = d.martes,
                      dia3 = d.miercoles,
                      dia4 = d.jueves,
                      dia5 = d.viernes,
                      dia6 = d.sabado,
                      total = d.total
                  };

            //si el promotor se envio lo filtramos
            if (model.idPromotor != null)
            {
                query = query.Where(d=>d.idUsuarioPromotor==model.idPromotor);
            }

            lst = query.ToList();

            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}