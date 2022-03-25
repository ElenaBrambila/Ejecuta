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
    public class PonderacionController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }

        public ActionResult Nuevo(int idCliente)
        {
            ObtieneSesion();

            PonderacionViewModel model = new PonderacionViewModel();
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
                //validación de negocio
                if (!Validaciones(model))
                {
                    return Content(error);
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
        public ActionResult GuardarEditar(PonderacionViewModel model)
        {
            try
            {
                
                //guardamos
                ponderacion oProducto = db.ponderacion.Find(model.id);
                oProducto.ponderacion1 = model.ponderacion;

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

        public bool Validaciones(ProductoViewModel model)
        {
            if (Models.HelperModels.Producto.Existe(model.sku))
            {
                error = "El sku del producto ya existe, intente con otro";
                return false;
            }

            return true;
        }

        public bool ValidacionesEditar(ProductoViewModel model)
        {
            if (Models.HelperModels.Producto.Existe(model.sku, model.id))
            {
                error = "El sku del producto ya existe, intente con otro";
                return false;
            }

            return true;
        }
        #region 
        public ActionResult Listado(int idCliente)
        {

            return View(idCliente);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idCliente)
        {
            IEnumerable<TablePonderacionViewModel> lst = null;

            if (idCliente == 10)
            {
                lst = from d in db.ponderacion.ToList()
                      join co in db.segmentos on d.idSegmento equals co.idSegmento 
                      join cl in db.cliente on d.idCliente equals cl.id
                      orderby d.idCliente
                      select new TablePonderacionViewModel
                      {
                          id = d.id,
                          segmento = co.segmento,
                          cliente = cl.razonSocial,
                          ponderacion = d.ponderacion1
                      };
            }
            else {
                lst = from d in db.ponderacion.ToList()
                      join co in db.segmentos on d.idSegmento equals co.idSegmento 
                      join cl in db.cliente on d.idCliente equals cl.id
                      where d.idCliente == idCliente
                      orderby d.idCliente
                      select new TablePonderacionViewModel
                      {
                          id = d.id,
                          segmento = co.segmento,
                          cliente = cl.razonSocial,
                          ponderacion = d.ponderacion1
                      };
            }
            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}