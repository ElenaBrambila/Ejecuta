using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Controllers
{
    public class EstatusController : BaseController
    {
        // GET: Estatus
        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();
            return View();
        }
        public ActionResult Listado(int idCliente)
        {

            return View(idCliente);
        }
        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idCliente)
        {
            IEnumerable<TableEstatusViewModel> lst = null;

            lst = from d in db.estatusPorCliente.ToList()
                  join i in db.inventarioEstatus on d.idEstatus equals i.idEstatusInv
                  where d.idCliente == idCliente
                  orderby d.rangoSuperior descending
                  select new TableEstatusViewModel
                  {
                      id = d.id,
                      Nombre = i.estatusInventario,
                      rangoInferior = d.rangoInferior,
                      rangoSuperior = d.rangoSuperior
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            TableEstatusViewModel model = new TableEstatusViewModel();
            var estatus = db.estatusPorCliente.First(d => d.id == id);
            model.Nombre = estatus.inventarioEstatus.estatusInventario;
            model.rangoInferior = estatus.rangoInferior;
            model.rangoSuperior = estatus.rangoSuperior;
            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar (TableEstatusViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                var estatus = db.estatusPorCliente.First(d => d.id == model.id);
                estatus.rangoInferior = model.rangoInferior;
                estatus.rangoSuperior = model.rangoSuperior;
                db.SaveChanges();
                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }


    }
}