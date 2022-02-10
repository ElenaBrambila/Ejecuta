using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.HelperModels;
using IntegramsaUltimate.Models.FilterViewModel;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteTiempoEfectivoByCadenaController : BaseController
    {
        // GET: ReporteTiempoEfectivoByCadena
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;



            ViewBag.lstCadenas = Models.HelperModels.Cadena.getCadenasSL();
            ViewBag.lstSemanas = Models.HelperModels.Semana.getSemanasSL(Utilidades.Date.obtieneNumeroSemanaAno(DateTime.Now));
            ViewBag.lstAnos = Models.HelperModels.Ano.getAnosSL(DateTime.Now.Year);


            return View();
        }
        #region Grid
        public ActionResult Listado(ReporteTiempoEfectivoByCadenaViewModel model)
        {


            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteTiempoEfectivoByCadenaViewModel model)
        {
            IQueryable<TableReporteTiempoEfectivoByCadenaViewModel> query = null;
            IEnumerable<TableReporteTiempoEfectivoByCadenaViewModel> lst = null;

            if (model.idCadena == null) model.idCadena = 0; //si es null lo ponemos a 0

            query = from d in db.fnReporteTiempoEfectivoDeCadena(model.idCadena,model.numSemana,model.ano)
                //  where d.numSemana==model.numSemana && d.ano==model.ano 
                  select new TableReporteTiempoEfectivoByCadenaViewModel
                  {
                      idCadena = d.idCadena,
                      Nombre = d.nombre,
                      dia1 = d.lunes,
                      dia2 = d.martes,
                      dia3 = d.miercoles,
                      dia4 = d.jueves,
                      dia5 = d.viernes,
                      dia6 = d.sabado,
                      total = d.total
                  };

            lst = query.ToList();

            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}