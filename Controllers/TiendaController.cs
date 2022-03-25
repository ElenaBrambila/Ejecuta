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
using System.Data.Entity.Spatial;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class TiendaController : BaseController
    {
        // GET: Tienda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoTiendasRepetidas()
        {
            return View();
        }
        public ActionResult Nuevo()
        {

            TiendaViewModel model = new TiendaViewModel();

            ObtenerComponentes();


            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(TiendaViewModel model)
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
                tienda oTienda = new tienda();
                oTienda.idEstado = 1;
                oTienda.fecha = DateTime.Now;
                oTienda.nombre = model.nombre;
                oTienda.idCadena = model.idCadena;
                oTienda.idFormato = model.idFormato;
                oTienda.codigo = model.codigo;
                oTienda.iddEstado = model.iddEstado;
                oTienda.idMunicipio = model.idMunicipio;
                oTienda.calle = model.calle;
                oTienda.numero = model.numero;
                oTienda.colonia = model.colonia;
                oTienda.cp = model.cp;
                oTienda.ubicacion = DbGeography.PointFromText(
                    string.Format("POINT({0} {1})", model.longitud, model.latitud)
                    , 4326);
                
                db.tienda.Add(oTienda);
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

            TiendaViewModel model = new TiendaViewModel();

            //llenamos model
            tienda oTienda = db.tienda.Find(id);
            model.nombre = oTienda.nombre;
            model.iddEstado = oTienda.iddEstado;
            model.idMunicipio = oTienda.idMunicipio;
            model.codigo = oTienda.codigo;
            model.idCadena = oTienda.idCadena;
            model.idFormato = oTienda.idFormato;
            model.idGiro = oTienda.idGiro;
            model.calle = oTienda.calle;
            model.numero = oTienda.numero;
            model.colonia = oTienda.colonia;
            model.cp = oTienda.cp;
            model.latitud = oTienda.ubicacion.Latitude.ToString();
            model.longitud = oTienda.ubicacion.Longitude.ToString();
            model.id = id;
            var cad = "";
            var cadena = (from d in db.cadena where d.idEstado == 1 && d.id == model.idCadena select d).FirstOrDefault();
            if (cadena.cadenaSugerida != null) {
                cad = cadena.cadenaSugerida;
               
            }
            model.prefijo = cad;
            ObtenerComponentes();

            return View(model);
        }


        [HttpPost]
        public ActionResult GuardarEditar(TiendaViewModel model)
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
                tienda oTienda= db.tienda.Find(model.id);
                oTienda.nombre = model.nombre;
                oTienda.idCadena = model.idCadena;
                oTienda.idFormato = model.idFormato;
                oTienda.codigo = model.codigo;
                oTienda.iddEstado = model.iddEstado;
                oTienda.idMunicipio = model.idMunicipio;
                oTienda.calle = model.calle;
                oTienda.numero = model.numero;
                oTienda.colonia = model.colonia;
                oTienda.cp = model.cp;
                oTienda.ubicacion = DbGeography.PointFromText(
                    string.Format("POINT({0} {1})", model.longitud, model.latitud)
                    , 4326);

                db.Entry(oTienda).State = EntityState.Modified;
                db.SaveChanges();

                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                tienda oTienda = db.tienda.Find(id);

                oTienda.idEstado = 3;
                db.Entry(oTienda).State = EntityState.Modified;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }


        public ActionResult Show(int id)
        {
            TiendaViewModel model = new TiendaViewModel();

            
            tienda oTienda = db.tienda.Find(id);
            ViewBag.TiendaNombre = oTienda.nombre;   
            ViewBag.codigo = oTienda.codigo;
            ViewBag.idCadena = oTienda.idCadena;
            ViewBag.calle = oTienda.calle;
            ViewBag.numero = oTienda.numero;
            ViewBag.colonia = oTienda.colonia;
            ViewBag.cp = oTienda.cp;
            model.latitud = oTienda.ubicacion.Latitude.ToString();
            model.longitud = oTienda.ubicacion.Longitude.ToString();
            model.id = id;
            ViewBag.cadenaNombre = oTienda.cadena.nombre;
            ViewBag.FormatoNombre = oTienda.formatoTienda.nombre;
            ViewBag.NombreEstado = oTienda.destado.Nombre;
            ViewBag.NombreMunicipio = oTienda.cmunicipio.Nombre;

            return View(model);
        }



        #region Grid
        public ActionResult Listado()
        {

            return View();
        }


        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<TableTiendaViewModel> lst = null;

            lst = from d in db.tienda.ToList()
                   where d.idEstado == 1
                   select new TableTiendaViewModel
                   {
                       id = d.id,
                       nombre = d.nombre,
                       determinante = d.codigo,
                       cadena = d.cadena.nombre ?? "",
                       formato = d.formatoTienda.nombre ?? "",
                       plaza= (new Func<string>(() => {
                                                               try { return d.cmunicipio.PlazaMunicipio.First().cPlaza.nombre; } 
                                                               catch { return ""; } 
                                                           }
                                                     )
                                    )(),
                         zona=(new Func<string>(() => {
                                                               try { return d.destado.ZonaEstado.First().cZona.nombre; } 
                                                               catch { return ""; } 
                                                           }
                                                     )
                                    )()
                    
                   };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        public string Determinante(int idCadena) {

            string nombre = "";
            var cadena = (from d in db.cadena where d.idEstado == 1 && d.id == idCadena select d).FirstOrDefault();
            if (cadena.cadenaSugerida != null)
            {
                var cadenaSugerida = cadena.cadenaSugerida;

                int count = (from d in db.tienda where d.idCadena == idCadena select d).Count();

                count = count + 1;
                nombre = cadenaSugerida + "-00" + count;
            }
            else {
                nombre = "libre";
            }
            
            return nombre;
        }
        public string DeterminanteEditar(int idCadena, int id)
        {

            string nombre = "";
            var cadena = (from d in db.cadena where d.idEstado == 1 && d.id == idCadena select d).FirstOrDefault();
            if (cadena.cadenaSugerida != null)
            {
                var cadenaSugerida = cadena.cadenaSugerida;

                int count = (from d in db.tienda where d.idCadena == idCadena && d.id != id select d).Count();

                count = count + 1;
                nombre = cadenaSugerida + "-00" + count;
            }
            else
            {
                nombre = "libre";
            }

            return nombre;
        }

        #region HELPERS
        public void ObtenerComponentes()
        {
            ViewBag.lstGiros = Models.HelperModels.Giro.getGirosSL();
            ViewBag.lstFormato = Models.HelperModels.Formato.getFormatosSL();
        }
        public bool Validaciones(TiendaViewModel model)
        {   
            return true;
        }

        #endregion
    }
}