using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate.Controllers
{
    public class RegionController : BaseController
    {
        //
        // GET: /Region/
        public ActionResult Index()
        {
            ViewBag.lst = Models.HelperModels.Region.getcZonaSL();
            ViewBag.lstEstado = Models.HelperModels.EstadoRegion.getEstadoRegionSL();
            return View();
        }

        
        public ActionResult Listado(int idZona)
        {

            return View(idZona);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idZona)
        {
            IEnumerable<TableRegionEstadoViewModel> lst = null;

            lst = from d in db.ZonaEstado.ToList()  
                  where idZona==d.idZona
                  select new TableRegionEstadoViewModel
                  {
                      iddEstado = d.destado.iddEstado,
                      Nombre = d.destado.Nombre,
                      id = d.id

                      
                  };

           return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo(int idZona)
        {

            EstadoViewModel model = new EstadoViewModel();
            model.idZona = idZona;
            ViewBag.lstEstado = Models.HelperModels.EstadoRegion.getEstadoRegionSL();

            

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(EstadoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }
                if (Validaciones(model)) {
                    return Content("Este estado ya existe");

                }


                //guardamos
                ZonaEstado oZonaEstado = new ZonaEstado();               
                oZonaEstado.idZona = model.idZona;
                oZonaEstado.iddEstado = model.iddEstado;


                db.ZonaEstado.Add(oZonaEstado);
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
            ZonaEstado oZonaEstado = db.ZonaEstado.Find(id);

            EstadoViewModel model = new EstadoViewModel();
       
            model.idZona = oZonaEstado.idZona;
            model.iddEstado = oZonaEstado.iddEstado;
            ViewBag.lstEstado = Models.HelperModels.EstadoRegion.getEstadoRegionSL();


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(EstadoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }
                if (Validaciones(model))
                {
                    return Content("Este estado ya existe");
                }

                //guardamos
                ZonaEstado oZonaEstado= db.ZonaEstado.Find(model.id);
                oZonaEstado.iddEstado = model.iddEstado;
                oZonaEstado.idZona = model.idZona;

                db.Entry(oZonaEstado).State = EntityState.Modified;
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
                ZonaEstado oZonaEstado = db.ZonaEstado.Find(id);

                oZonaEstado.id = id;
                db.Entry(oZonaEstado).State = EntityState.Deleted;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }


        public bool Validaciones(EstadoViewModel model)
        {
            if (Models.HelperModels.Region.Existe(model))
            {
                error = "El nombre del Estado ya existe, intente con otro";
                return true;
            }

            return false;
        }


       
	}
}