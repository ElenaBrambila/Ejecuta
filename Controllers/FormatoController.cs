using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class FormatoController : BaseController
    {
        // GET: Formato
        public ActionResult Index()
        {
            ViewBag.lstCadenas = Models.HelperModels.Cadena.getCadenasSL();

            return View();
        }

        public ActionResult Nuevo(int idCadena)
        {
            ObtieneSesion();

            FormatoViewModel model = new FormatoViewModel();
            model.idCadena = idCadena;

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(FormatoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

               
                //guardamos
                formatoTienda oFormato = new formatoTienda();
                oFormato.idEstado = 1;
                oFormato.fecha = DateTime.Now;
                oFormato.nombre = model.nombre;
                oFormato.idCadena = model.idCadena;

                db.formatoTienda.Add(oFormato);
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

            //obtenemos el usuario
            formatoTienda oFormato = db.formatoTienda.Find(id);

            FormatoViewModel model = new FormatoViewModel();
            model.nombre = oFormato.nombre;
            model.idCadena = oFormato.idCadena;
            model.id = oFormato.id;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(FormatoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //guardamos
                formatoTienda oFormato = db.formatoTienda.Find(model.id);
                oFormato.idEstado = 1;
                oFormato.fecha = DateTime.Now;
                oFormato.nombre = model.nombre;
                oFormato.idCadena = model.idCadena;

                db.Entry(oFormato).State = EntityState.Modified;
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
                formatoTienda oFormato = db.formatoTienda.Find(id);

                oFormato.idEstado = 3;
                db.Entry(oFormato).State = EntityState.Modified;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }


        #region Grid
        public ActionResult Listado(int idCadena)
        {


            return View(idCadena);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idCadena)
        {
            IEnumerable<TableFormatosViewModel> lst = null;

            lst = from d in db.formatoTienda.ToList()
                  where d.idEstado == 1 && d.idCadena==idCadena
                  select new TableFormatosViewModel
                  {
                      id = d.id,
                      nombre = d.nombre
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}