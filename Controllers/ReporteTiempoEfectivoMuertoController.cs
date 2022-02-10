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
    public class ReporteTiempoEfectivoMuertoController : BaseController
    {
        // GET: ReporteTiempoEfectivoMuerto
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
            IEnumerable<TableReporteTiempoEfectivoMuertoViewModel> lst = null;
            IQueryable<TableReporteTiempoEfectivoMuertoViewModel> query = null;

            query = from d in db.fnReporteTiempoEfectivoMuerto()
                  where model.numSemana==d.numSemana && model.ano==d.ano

                  select new TableReporteTiempoEfectivoMuertoViewModel
                  {
                      idUsuarioPromotor=d.idUsuarioPromotor,
                      Nombre =d.nombre,
                      tiempoEfectivo=d.tiempoEfectivo.ToString(),
                      tiempoMuerto = d.tiempoMuerto.ToString(),
                      efectivo=d.porcentajeEfectivo
                  };

            if (model.idPromotor != null)
                query = query.Where(d => d.idUsuarioPromotor == model.idPromotor);

            lst = query.ToList();

            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}