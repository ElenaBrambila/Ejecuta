using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.ViewModels;
using IntegramsaUltimate.Models;
using System.Data.Entity;


namespace IntegramsaUltimate.Controllers
{
    public class PlazaController : BaseController
    {
        
        // GET: /Plaza/
        public ActionResult Index()
        {
            ViewBag.lst = Models.HelperModels.Plaza.getcPlazaSL();
           
            return View();
        }

        public ActionResult Listado(int idPlaza)
        {
            return View(idPlaza);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int? idPlaza)
        {
            IEnumerable<TablePlazaMunicipioViewModel> lst = null;

            lst = from d in db.PlazaMunicipio.ToList()
                where idPlaza==d.idPlaza
                  select new TablePlazaMunicipioViewModel
                  {
                      id = d.id,
                      idMunicipio=d.cmunicipio.idcMunicipio,
                      Nombre = d.cmunicipio.Nombre
                    


                  };

            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Nuevo(int idPlaza)
        {

            PlazaMunicipioViewModel model = new PlazaMunicipioViewModel();
           

            return View(model);
        }


        [HttpPost]
        public ActionResult Guardar(PlazaMunicipioViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }
                // se hace la validacion de que no este repetido el Municipio
                if (Validaciones(model))
                {
                    return Content("Este Municipio ya existe");

                }


                //guardamosPlazaMunicipio
                PlazaMunicipio oPlazaMunicipio = new PlazaMunicipio();
                oPlazaMunicipio.idPlaza= model.idPlaza;
                oPlazaMunicipio.idMunicipio = model.idMunicipio;
               // oPlazaMunicipio.iddEstado = model.iddEstado;


                db.PlazaMunicipio.Add(oPlazaMunicipio);

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
            PlazaMunicipio oPlazaMunicipio = db.PlazaMunicipio.Find(id);

            PlazaMunicipioViewModel model = new PlazaMunicipioViewModel();

            model.idPlaza = oPlazaMunicipio.idPlaza;
            model.idMunicipio = oPlazaMunicipio.idMunicipio;
           // model.iddEstado = oPlazaMunicipio.iddEstado;
          
           
            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(PlazaMunicipioViewModel model)
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
               PlazaMunicipio oPlazaMunicipio = db.PlazaMunicipio.Find(model.id);
                oPlazaMunicipio.idMunicipio = model.idMunicipio;
                oPlazaMunicipio.idPlaza = model.idPlaza;
             //   oPlazaMunicipio.iddEstado = model.iddEstado;

                db.Entry(oPlazaMunicipio).State = EntityState.Modified;
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
                PlazaMunicipio oPlazaMunicipio = db.PlazaMunicipio.Find(id);

                oPlazaMunicipio.id = id;
                db.Entry(oPlazaMunicipio).State = EntityState.Deleted;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        public bool Validaciones(PlazaMunicipioViewModel model)
        {
            if (Models.HelperModels.Plaza.Existe(model))
            {
                error = "El nombre del Municipio ya existe, intente con otro";
                return true;
            }

            return false;
        }



    }
}