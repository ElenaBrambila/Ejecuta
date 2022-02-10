using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using Kendo.Mvc.UI;
using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class RutaController : BaseController
    {
        // GET: Ruta
        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            
            return View();
        }

        public ActionResult RutaOptima()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();


            return View();
        }
        public ActionResult Nuevo(int idCliente)
        {
            ObtieneSesion();

            RutaViewModel model = new RutaViewModel();
            model.idCliente = idCliente;

            ViewBag.lstPerfiles = Models.HelperModels.PerfilRuta.getPerfilesSL();
            ViewBag.lstTurnos = Models.HelperModels.TurnoRuta.getTurnosSL();
            ViewBag.lstEstadoRutas = Models.HelperModels.EstadoRuta.getEstadoRutasSL();
            ViewBag.lstPromotores = Models.HelperModels.Usuario.getUsuariosByTipoSL(2,idCliente);

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(RutaViewModel model)
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
                ruta oRuta = new ruta();
                oRuta.idEstado = 1;
                oRuta.idCliente = model.idCliente;
                oRuta.idEstadoRuta = model.idEstadoRuta;
                oRuta.idPerfil = model.idPerfil;
                oRuta.codigoRuta = model.codigo;
                oRuta.idTurno = model.idTurno;
                oRuta.idPromotor = model.idPromotor;

                db.ruta.Add(oRuta);
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
            //obtenemos la ruta

            ruta oRuta = db.ruta.Find(id);

            RutaViewModel model = new RutaViewModel();
            model.idCliente = oRuta.idCliente;
            model.codigo = oRuta.codigoRuta;
            model.idPerfil = oRuta.idPerfil;
            model.idTurno = oRuta.idTurno;
            model.idEstadoRuta = oRuta.idEstadoRuta;
            model.idPromotor = oRuta.idPromotor;

            ViewBag.lstPerfiles = Models.HelperModels.PerfilRuta.getPerfilesSL();
            ViewBag.lstTurnos = Models.HelperModels.TurnoRuta.getTurnosSL();
            ViewBag.lstEstadoRutas = Models.HelperModels.EstadoRuta.getEstadoRutasSL();
            ViewBag.lstPromotores = Models.HelperModels.Usuario.getUsuariosByTipoSL(2, (int)oRuta.idCliente);

            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(RutaViewModel model)
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
                ruta oRuta = db.ruta.Find(model.id);
                oRuta.idEstadoRuta = model.idEstadoRuta;
                oRuta.idPerfil = model.idPerfil;
                oRuta.codigoRuta = model.codigo;
                oRuta.idTurno = model.idTurno;
                oRuta.idPromotor = model.idPromotor;

                db.Entry(oRuta).State = EntityState.Modified;
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
                ruta oRuta = db.ruta.Find(id);

                oRuta.idEstado = 3;
                oRuta.idPromotor = null; // se le quita el promotor
                db.Entry(oRuta).State = EntityState.Modified;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }
        #region Grid
        public ActionResult Listado(int idCliente)
        {


            return View(idCliente);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idCliente)
        {
            IEnumerable<TableRutaViewModel> lst = null;

            lst = from d in db.ruta.ToList()
                  where d.idEstado == 1 && d.idCliente == idCliente
                  select new TableRutaViewModel
                  {
                      id = d.id,
                      codigo = d.codigoRuta,
                      estadoRuta = d.cEstadoRuta.nombre,
                      perfil = d.cPerfilRuta.nombre,
                      turno = d.cTurnoRuta.nombre,
                      promotor = (new Func<string>(() =>
                      {
                          try
                          {
                              return (d.usuario.nombre + " " + d.usuario.paterno + " " + d.usuario.materno);
                          }
                          catch
                          {
                              return "";
                          }
                      }))()
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPERS
        public bool Validaciones(RutaViewModel model)
        {
            if (Models.HelperModels.Usuario.PromotorYaTieneRuta((int)model.idPromotor,model.id))
            {
                error = "El promotor seleccionado ya tiene una ruta asignada, no puedes asignar 2 rutas a un Promotor";
                return false;
            }

            return true;
        }
        #endregion
    }
}