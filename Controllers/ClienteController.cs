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
    public class ClienteController : BaseController
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            ClienteViewModel model = new ClienteViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(ClienteViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }


                //guardamos
                cliente oCliente = new cliente();
                oCliente.idEstado = 1;
                oCliente.razonSocial = model.razonSocial;
                oCliente.domicilio = model.domicilio;
                oCliente.iddEstado = model.iddEstado;
                oCliente.idMunicipio = model.idMunicipio;
                oCliente.telefono = model.telefono;
                oCliente.email = model.email;

                db.cliente.Add(oCliente);
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

            //obtenemos el cliente
            cliente oCliente = db.cliente.Find(id);

            ClienteViewModel model = new ClienteViewModel();
            model.razonSocial = oCliente.razonSocial;
            model.domicilio = oCliente.domicilio;
            model.iddEstado = oCliente.iddEstado;
            model.idMunicipio = oCliente.idMunicipio;
            model.telefono = oCliente.telefono;
            model.email = oCliente.email;
            model.id = oCliente.id;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(ClienteViewModel model)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //obtenemos el cliente
                cliente oCliente = db.cliente.Find(model.id);

                oCliente.razonSocial = model.razonSocial;
                oCliente.domicilio = model.domicilio;
                oCliente.iddEstado = model.iddEstado;
                oCliente.idMunicipio = model.idMunicipio;
                oCliente.telefono = model.telefono;
                oCliente.email = model.email;

                db.Entry(oCliente).State = EntityState.Modified;
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
                cliente oCliente = db.cliente.Find(id);

                oCliente.idEstado = 3;
                db.Entry(oCliente).State = EntityState.Modified;

                //borramos los usuarios relacionados (promotores y clientes)
                db.Database.ExecuteSqlCommand("update usuario set idEstado=3 where idEstado=1 and idTipoUsuario in(2,6) and id in(select idUsuario from usuarioCliente where idCliente='"+oCliente.id+"')");


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
            IEnumerable<TableClientesViewModel> lst = null;

            lst = from d in db.cliente.ToList()
                  where d.idEstado == 1
                  select new TableClientesViewModel
                  {
                      id = d.id,
                      razonSocial = d.razonSocial,
                      telefono=d.telefono,
                      email=d.email
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPERS
      

        #endregion
    }
}