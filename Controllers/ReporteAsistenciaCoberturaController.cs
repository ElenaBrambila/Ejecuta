﻿using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.FilterViewModel;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteAsistenciaCoberturaController : BaseController
    {
        // GET: ReporteAsistenciaCobertura
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
            IEnumerable<TableReporteAsistenciaCoberturaViewModel> lst = null;
            IQueryable<TableReporteAsistenciaCoberturaViewModel> query = null;

            query = from d in db.fnReporteAsistenciaCobertura(model.numSemana,model.idPromotor,model.ano)
                 
                  select new TableReporteAsistenciaCoberturaViewModel
                  {
                      Nombre = d.nombre,
                      cobertura=d.cobertura,
                      asignadas=d.asignadas,
                      cubieras=d.cubiertas,
                      idUsuarioPromotor=d.idUsuarioPromotor
                  };

            //filtramos
            if (model.idPromotor != null)
                query= query.Where(d => d.idUsuarioPromotor == model.idPromotor);

            //ejecutamos el query
            lst = query.ToList();


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}