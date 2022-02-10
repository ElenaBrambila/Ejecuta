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
    public class ProductoController : BaseController
    {
        
        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }

        public ActionResult Nuevo(int idCliente)
        {
            ObtieneSesion();

            ProductoViewModel model = new ProductoViewModel();
            model.idCliente = idCliente;

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(ProductoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }


                //guardamos
                producto oProducto = new producto();
                oProducto.idEstado = 1;
                oProducto.nombre = model.nombre;
                oProducto.presentacion = model.presentacion;
                oProducto.sku = model.sku;
                oProducto.idCliente = model.idCliente;

                db.producto.Add(oProducto);
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
            producto oProducto = db.producto.Find(id);

            ProductoViewModel model = new ProductoViewModel();
            model.nombre = oProducto.nombre;
            model.idCliente = oProducto.idCliente;
            model.id = oProducto.id;
            model.presentacion = oProducto.presentacion;
            model.sku = oProducto.sku;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(ProductoViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //guardamos
                producto oProducto = db.producto.Find(model.id);
                oProducto.idEstado = 1;
                oProducto.nombre = model.nombre;
                oProducto.presentacion = model.presentacion;
                oProducto.sku = model.sku;
                oProducto.idCliente = model.idCliente;

                db.Entry(oProducto).State = EntityState.Modified;
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
                producto oProducto = db.producto.Find(id);

                oProducto.idEstado = 3;
                db.Entry(oProducto).State = EntityState.Modified;

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
            IEnumerable<TableProductoViewModel> lst = null;

            lst = from d in db.producto.ToList()
                  where d.idEstado == 1 && d.idCliente == idCliente
                  select new TableProductoViewModel
                  {
                      id = d.id,
                      nombre = d.nombre,
                      presentacion=d.presentacion,
                      sku=d.sku
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}