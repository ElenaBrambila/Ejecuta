using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class CadenaController : BaseController
    {
        private int idEstado;

        // GET: Cadena
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {

            CadenaViewModel model = new CadenaViewModel();

            ObtenerComponentes();


            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(CadenaViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //validación de negocio
                if (!Validaciones(model))
                {
                    return Content(error);
                }


                
                //guardamos
                cadena oCadena = new cadena();
                oCadena.idEstado = 1;
                oCadena.fecha = DateTime.Now;
                oCadena.nombre = model.nombre;
                oCadena.idGiroComercial = model.idGiro;

                db.cadena.Add(oCadena);
                db.SaveChanges();

                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ObtenerComponentes();

            //obtenemos la cadena
            cadena oCadena = db.cadena.Find(id);

            CadenaViewModel model = new CadenaViewModel();
            model.nombre = oCadena.nombre;
            model.idGiro = oCadena.idGiroComercial;
            model.id = oCadena.id;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(CadenaViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //validación de negocio
                if (!Validaciones(model))
                {
                    return Content(error);
                }


                //guardamos
                cadena oCadena = db.cadena.Find(model.id);
                oCadena.nombre = model.nombre;
                oCadena.idGiroComercial = model.idGiro;

                db.Entry(oCadena).State = EntityState.Modified;
                db.SaveChanges();

                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                cadena oCadena = db.cadena.Find(id);

                oCadena.idEstado = 3;
                db.Entry(oCadena).State = EntityState.Modified;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        #region Grid
        public ActionResult Listado()
        {

            return View();
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<TableCadenasViewModel> lst = null;

            lst = from d in db.cadena.ToList()
                  where d.idEstado == 1
                  select new TableCadenasViewModel
                  {
                      id = d.id,
                      nombre = d.nombre,
                      tipoGiro = d.cGiroComercial.nombre ?? ""
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPERS
        public void ObtenerComponentes()
        {

            ViewBag.lstGiros = Models.HelperModels.Giro.getGirosSL();
        }
        #endregion

        #region HELPERS
        public bool Validaciones(CadenaViewModel model)
        {
            if (Models.HelperModels.Cadena.Existe(model.nombre))
            {
                error = "El nombre de la cadena ya existe, intente con otro";
                return false;
            }

            return true;
        }

        #endregion
    }
}