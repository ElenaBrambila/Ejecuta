using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using System.IO;
using IntegramsaUltimate.Models.ViewModels;
using Kendo.Mvc.UI;
using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.Extensions;
using System.Data;
using IntegramsaUltimate.Utilidades;
using System.Data.Entity;

namespace IntegramsaUltimate.Controllers
{
    public class InventarioMasivoController : BaseController
    {
        // GET: InventarioMasivo
        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }
        public ActionResult Cargar(int idCliente, int idSemanaHidden, int idCadena, HttpPostedFileBase archivo)
        {

            try
            {
                //validaciones
                if (archivo == null)
                {
                    return Content("El archivo es obligatorio");
                }

                string path = Server.MapPath("~");
                StreamReader sArchivo = new StreamReader(archivo.InputStream);
                Stream stArchivo = sArchivo.BaseStream;

                Excel.InventarioExcel oIE = new Excel.InventarioExcel(stArchivo, idCliente, idSemanaHidden, idCadena);

                if (!oIE.Cargar())
                {
                    return Content(oIE.getErrores());
                }



            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }
        public ActionResult InventarioById(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            InventarioViewModel model = new InventarioViewModel();
            using (IntegramsaUltimateEntities db = new IntegramsaUltimateEntities())
            {
                bool exists = db.inventarios.Any(p => p.idInventario == id);
                if (exists)
                {

                    var inventario = db.inventarios.First(p => p.idInventario == id);
                    string cadena = inventario.idCadena == null ? "null" : db.cadena.Where(p => p.id == inventario.idCadena).Select(p => p.nombre).First();
                    string producto = inventario.idProducto == null ? "null" : db.producto.Where(p => p.id == inventario.idProducto).Select(p => p.nombre).First();
                    string estatusInv = inventario.idEstatusInv == null ? "null" : db.inventarioEstatus.Where(p => p.idEstatusInv == inventario.idEstatusInv).Select(p => p.estatusInventario).First();
                    string cliente = inventario.idCliente == null ? "null" : db.cliente.Where(p => p.id == inventario.idCliente).Select(p => p.razonSocial).First();
                    model.Cliente = cliente;
                    model.Cadena = cadena;
                    model.Producto = producto;
                    model.EstatusInv = estatusInv;
                    model.IdTienda = inventario.idTienda;
                    model.Sku = inventario.sku;
                    model.NumTienda = inventario.numTienda;
                    model.NumSemana = inventario.numSemana;
                    model.Cantidad = Convert.ToString(inventario.cantidadVendida);

                }
            }
            return View(model);
        }
        public ActionResult Listado(int idCliente)
        {

            return View(idCliente);
        }
        #region Grid
        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, int idCliente)
        {
            IEnumerable<TableInventarioViewModel> lst = null;

            lst = db.vwInventario.Where(d => d.idCliente == idCliente)
                  .ToList()
                  .Select(d => new TableInventarioViewModel
                  {
                      idInventario = d.idInventario,
                      cantidadVendida = (decimal)d.Ventas,
                      numTienda = d.Tienda,
                      sku = d.Producto,
                      status = d.Status,
                      numSemana = d.numSemana,
                      EstatusComparado = d.Criterio,
                      diasDeInventario = d.Días_Inv,
                      cantidadInventario = d.Inventario
                  });


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult Editar(int idInventario)
        {

            //obtenemos el usuario
            inventarios oInventario = db.inventarios.First(p => p.idInventario == idInventario);

            InventarioViewModel model = new InventarioViewModel();
            model.Cantidad = Convert.ToString(oInventario.cantidadVendida);
            model.Cliente = Convert.ToString(oInventario.idCliente);
            model.IdTienda = oInventario.idTienda;
            model.NumTienda = oInventario.numTienda;
            model.Sku = oInventario.sku;
            model.NumSemana = oInventario.numSemana;
            model.Inventario = Convert.ToString(oInventario.cantidadInventario);
            model.DiasInventario = Convert.ToString(oInventario.diasInventario);
            

            return View(model);
        }
        [HttpPost]
        public ActionResult GuardarEditar(InventarioViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //guardamos
                inventarios oInventario = db.inventarios.Find(model.IdInventario);

                oInventario.cantidadVendida = Convert.ToDecimal(model.Cantidad);

                var tuple = StatusCalculator.CalculateActualStatus(
                    (int)oInventario.numSemana, 
                    oInventario.idProducto, 
                    oInventario.idTienda, 
                    (decimal)oInventario.cantidadVendida, 
                    (int)oInventario.idCliente,
                    (decimal)oInventario.cantidadInventario
                    );
                int? result = tuple.Item1;
                oInventario.idEstatusInv = result;

                StatusInput input = new StatusInput {
                    idInventarioActual = result,
                    idProducto = (int)oInventario.idProducto,
                    numSemana = (int)oInventario.numSemana,
                    idTienda = (int)oInventario.idTienda
                };
                int? nuewStatusComparativo = StatusCalculator.CalculateStatus(input);
                oInventario.idCriterio = nuewStatusComparativo;
                oInventario.diasInventario = StatusCalculator.CalcularDiasInv(
                                                        (int)oInventario.numSemana,
                                                        oInventario.idProducto,
                                                        oInventario.idTienda,
                                                        (decimal)oInventario.cantidadVendida,
                                                        (int)oInventario.idCliente,
                                                        (decimal)oInventario.cantidadInventario
                                                        );

                db.Entry(oInventario).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();

                if (db.inventarios.Any(d => d.idProducto == oInventario.idProducto && d.idTienda == oInventario.idTienda && d.numSemana == oInventario.numSemana + 1))
                {
                    var nextInventario = db.inventarios.First(d => d.idProducto == oInventario.idProducto && d.idTienda == oInventario.idTienda && d.numSemana == oInventario.numSemana + 1);

                    StatusInput nextInput = new StatusInput
                    {
                        idInventarioActual = nextInventario.idEstatusInv,
                        idProducto = (int)nextInventario.idProducto,
                        numSemana = (int)nextInventario.numSemana,
                        idTienda = (int)nextInventario.idTienda
                    };
                    nextInventario.idCriterio = StatusCalculator.CalculateStatus(nextInput);
                    db.SaveChanges();
                }

                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Eliminar(int idInventario)
        {
            try
            {
                inventarios oInventarios = db.inventarios.Find(idInventario);


                db.Entry(oInventarios).State = (System.Data.Entity.EntityState)EntityState.Deleted;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }
        public ActionResult Status()
        {
            return View();
        }
        public JsonResult CadenasToList(string cadena)
        {
            var cadenas = db.cadena.Where(d => d.nombre.Contains(cadena)).Select(p => new Result { Id = p.id, Nombre = p.nombre }).ToList();
            return Json(cadenas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TiendasToList(string tienda, int? idCadena)
        {
            if (idCadena == null)
            {
                var tiendas = db.tienda.Where(d => d.nombre.Contains(tienda)).Select(d => new Result { Id = d.id, Nombre = d.nombre }).ToList();
                return Json(tiendas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var tiendas = db.tienda.Where(d => d.idCadena == idCadena && d.nombre.Contains(tienda)).Select(d => new Result { Id = d.id, Nombre = d.nombre }).ToList();
                return Json(tiendas, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult StatusToList(string status)
        {
            var stat = db.inventarioEstatus.Where(d => d.estatusInventario.Contains(status)).Select(p => new Result { Id = p.idEstatusInv, Nombre = p.estatusInventario }).ToList();
            return Json(stat, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CriterioToList(string criterio)
        {
            var criterios = db.inventarioCriterios.Where(d => d.criterioInv.Contains(criterio)).Select(p => new Result { Id = p.idCriterioInv, Nombre = p.criterioInv }).ToList();
            return Json(criterios, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductosToList(string producto)
        {
            var productos = db.producto.Where(d => d.nombre.Contains(producto)).Select(d => new Result { Id = d.id, Nombre = d.nombre }).ToList();
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStatus(StatusInput input)
        {
            StatusViewModel model = new StatusViewModel();

            bool inventarioExists = db.inventarios.Any(d => d.idProducto == input.idProducto && d.idTienda == input.idTienda && d.numSemana == input.numSemana);
            if (!inventarioExists)
            {
                NotFound response = new NotFound("No existen inventarios con los parámetros de la búsqueda");
                return View("Status404", response);
            }
            else
            {
                var inventarioDb = db.inventarios.First(d => d.idProducto == input.idProducto && d.idTienda == input.idTienda && d.numSemana == input.numSemana);
                string cadena = "Sin Datos";
                string tienda = "Sin Datos";
                string producto = "Sin Datos";

                if (db.producto.Any(d => d.id == input.idProducto))
                {
                    producto = db.producto.First(d => d.id == input.idProducto).nombre;
                }
                if (db.tienda.Any(d => d.id == input.idTienda))
                {
                    tienda = db.tienda.First(d => d.id == input.idTienda).nombre;
                }
                if (inventarioDb.idTienda != null)
                {
                    if (db.tienda.Any(d => d.id == input.idTienda))
                    {
                        int? idCadena = db.tienda.First(d => d.id == input.idTienda).idCadena;
                        cadena = db.cadena.First(d => d.id == idCadena).nombre;
                    }

                }

                var statusDb = db.inventarioCriterios.First(d => d.idCriterioInv == inventarioDb.idCriterio);
                string color = statusDb.color;
                string status = statusDb.criterioInv;

                model.Status = db.inventarioEstatus.First(d => d.idEstatusInv == inventarioDb.idEstatusInv).estatusInventario;
                model.StatusComparativo = status;
                model.Semana = input.numSemana;
                model.Producto = producto;
                model.Tienda = tienda;
                model.Cadena = cadena;
                model.Color = color;
                return View(model);
            }
        }
        public ActionResult ReportInventario()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();
            ViewBag.lstCriterios = Models.HelperModels.Criterio.getCriteriosSL();
            ViewBag.lstEstatus = Models.HelperModels.Estatus.getEstatusSL();
            return View();
        }
        [HttpPost]
        public ActionResult Report(int idCliente, int numSemana, int idCadena, int? idTienda, int? idStatus, int? idCriterio)
        {
            if (idTienda != null)
            {
                bool response = ReportCreation.InventariosReport(idTienda, numSemana, idStatus, idCriterio, idCliente);
                if (response)
                {
                    ViewData["path"] = "/Reporte_Inventario.pdf";
                    return View();
                }
                else
                {
                    return View("Status404", new NotFound("No existen inventarios con los parámetros de la búsqueda"));
                }
            }
            else
            {
                bool response = ReportCreation.MainInventarioReport(idCadena, numSemana, idStatus, idCriterio, idCliente);
                if (response)
                {
                    ViewData["path"] = "/Reporte_Inventario.pdf";
                    return View();
                }
                else
                {
                    return View("Status404", new NotFound("No existen inventarios con los parámetros de la búsqueda"));
                }
            }
            
        }

    }

    public class Result
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class StatusInput
    {
        public int idTienda { get; set; }
        public int idProducto { get; set; }
        public int numSemana { get; set; }
        public int? idInventarioActual { get; set; }
    }

}
    
