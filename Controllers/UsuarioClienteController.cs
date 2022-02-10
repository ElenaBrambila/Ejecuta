using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using IntegramsaUltimate.Models.ViewModels;

namespace IntegramsaUltimate.Controllers
{
    public class UsuarioClienteController : BaseController
    {
        
        public ActionResult AsignarCliente(int id)
        {
            //obtenemos si existe ya un cliente selecionado para el usuario
            usuarioCliente oUC = db.usuarioCliente.Where(d=>d.idUsuario==id).FirstOrDefault();

            int idUsuarioCliente = 0;
            //si ya tiene un cliente el usuario lo obtenemos
            if (oUC != null)
            {
                idUsuarioCliente = (int)oUC.idCliente;
            }

            //llenamos el viewmodel
            UsuarioClienteViewModel model = new UsuarioClienteViewModel();
            model.idUsuario = id;
            model.idCliente = idUsuarioCliente;

            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View(model);
        }

        [HttpPost]
        public ActionResult Asignar(UsuarioClienteViewModel model)
        {
            try
            {
                //abrimos transaccion
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //obtenemos si existe el usuariocliente
                        usuarioCliente oUC = db.usuarioCliente.Where(d => d.idUsuario == model.idUsuario).FirstOrDefault();

                        //borramos si el usuario ya tiene cliente
                        if (oUC != null)
                            db.usuarioCliente.Remove(oUC);

                        db.SaveChanges();
                        
                        //agregamos el nuevo cliente al usuario
                        usuarioCliente oUsuarioCliente = new usuarioCliente();
                        oUsuarioCliente.idUsuario = model.idUsuario;
                        oUsuarioCliente.idCliente = model.idCliente;
                        db.usuarioCliente.Add(oUsuarioCliente);

                        db.SaveChanges();

                        //comiteamos
                        dbContextTransaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        //hacemos rollback si fallo algo
                        dbContextTransaction.Rollback();

                        return Content("Error de sistema. "+ex.Message);

                    }
                }

                return Content("1");
            }catch(Exception ex){
                 return Content("Ocurrio un error: " + ex.Message);
            }
        }
    }
}