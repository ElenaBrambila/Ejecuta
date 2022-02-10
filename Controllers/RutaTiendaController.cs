using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using IntegramsaUltimate.Models;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class RutaTiendaController : BaseController
    {
        // GET: RutaTienda
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Nuevo(int idRuta)
        {

            ViewBag.lstClousters = Models.HelperModels.Clouster.getCloustersSL();
            ViewBag.lstFactorVisita = Models.HelperModels.FactorVisita.getFactorVisitaSL();

            RutaTiendaViewModel model = new RutaTiendaViewModel();
            model.idRuta = idRuta;

            return View(model);

        }


        [HttpPost]
        public ActionResult Guardar(RutaTiendaViewModel model)
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

                rutaTienda oRutaTienda = new rutaTienda();
                oRutaTienda.idTienda = model.idTienda;
                oRutaTienda.idRuta = model.idRuta;
                oRutaTienda.idClouster = model.idClouster;
                oRutaTienda.idFactorVisita = model.idFactorVisita;
                oRutaTienda.idEstado = 1;
                oRutaTienda.fecha = DateTime.Now;
                

                db.rutaTienda.Add(oRutaTienda);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        public ActionResult Editar(int id)
        {

            rutaTienda oRutaTienda = db.rutaTienda.Find(id);


            //componentes
            ViewBag.lstClousters = Models.HelperModels.Clouster.getCloustersSL();
            ViewBag.lstFactorVisita = Models.HelperModels.FactorVisita.getFactorVisitaSL();

            RutaTiendaViewModel model = new RutaTiendaViewModel();
            model.idRuta = oRutaTienda.idRuta;
            model.idFactorVisita = oRutaTienda.idFactorVisita;
            model.idMunicipio = oRutaTienda.tienda.cmunicipio.idcMunicipio;
            model.idEstado = oRutaTienda.tienda.destado.iddEstado;
            model.idClouster = oRutaTienda.idClouster;
            model.idTienda = oRutaTienda.idTienda;
            model.id = oRutaTienda.id;

            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(RutaTiendaViewModel model)
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

                rutaTienda oRutaTienda = db.rutaTienda.Find(model.id);
                oRutaTienda.idTienda = model.idTienda;
                oRutaTienda.idRuta = model.idRuta;
                oRutaTienda.idClouster = model.idClouster;
                oRutaTienda.idFactorVisita = model.idFactorVisita;

                db.Entry(oRutaTienda).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                rutaTienda oRutaTienda = db.rutaTienda.Find(id);

                oRutaTienda.idEstado = 3;
                db.Entry(oRutaTienda).State = EntityState.Modified;

                //eliminamos todas las tiendas que esten en rutas en la tabla rutaIntinerario
                IEnumerable<rutaIntinerario> lstIntinerario = db.rutaIntinerario.Where(d => d.idRuta == oRutaTienda.idRuta && d.idTienda == oRutaTienda.idTienda);
                foreach(rutaIntinerario oRI in lstIntinerario){

                    oRI.idEstado = 3;
                    db.Entry(oRI).State = EntityState.Modified;

                }

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        #region Grid
        public ActionResult Listado(int idRuta)
        {


            return View(idRuta);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idRuta)
        {
            IEnumerable<TableRutaTiendaViewModel> lst = null;

            lst = from d in db.rutaTienda.ToList()
                  where d.idEstado == 1 && d.idRuta==idRuta
                  select new TableRutaTiendaViewModel
                  {
                      id = d.id,
                      nombre = d.tienda.nombre,
                      idTienda=d.idTienda,
                      codigo=d.tienda.codigo,
                      cadena=d.tienda.cadena.nombre,
                      estado=d.tienda.destado.Nombre,
                      ciudad=d.tienda.cmunicipio.Nombre,
                      formato=d.tienda.formatoTienda.nombre,
                      clouster=d.cClouster.nombre,
                      visitas=d.cFactorVisita.nombre

                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPERS
        public bool Validaciones(RutaTiendaViewModel model)
        {
            if (Models.HelperModels.RutaTienda.Existe((int)model.idRuta,(int)model.idTienda,model.id))
            {
                error = "La tienda ya fue agregada a la ruta";
                return false;
            }

            //esta validación no es necesaria
           // if (Models.HelperModels.RutaTienda.ExisteEnRuta((int)model.idTienda, model.id))
           // {
           //     error = "La tienda ya existe en una ruta";
           //     return false;
           // }

            return true;
        }

     

        #endregion

    }
}