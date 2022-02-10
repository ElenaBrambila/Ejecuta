using IntegramsaUltimate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate.Controllers
{
    public class UsuarioSupervisorController : BaseController
    {
        // GET: UsuarioSupervisor
        public ActionResult AsignarSupervisor(int id)
        {
            usuario oUsuario = db.usuario.Find(id);
            
            
            //llenamos el viewmodel
            UsuarioSupervisorViewModel model = new UsuarioSupervisorViewModel();
            model.idUsuario = id;
            model.idSupervisor = oUsuario.idSupervisor;

            ViewBag.lstSupervisores = Models.HelperModels.Usuario.getUsuariosByTipoSL(3);

            return View(model);
        }

        public ActionResult AsignarCoordinador(int id)
        {
            usuario oUsuario = db.usuario.Find(id);


            //llenamos el viewmodel
            UsuarioSupervisorViewModel model = new UsuarioSupervisorViewModel();
            model.idUsuario = id;
            model.idSupervisor = oUsuario.idSupervisor;

            ViewBag.lstSupervisores = Models.HelperModels.Usuario.getUsuariosByTipoSL(4);

            return View(model);
        }

        [HttpPost]
        public ActionResult Asignar(UsuarioSupervisorViewModel model)
        {
            try
            {
                //abrimos transaccion
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //obtenemos el usuario
                        usuario oUsuario = db.usuario.Find(model.idUsuario);
            
                        //asignamos el supervisor
                        oUsuario.idSupervisor = model.idSupervisor;

                        db.SaveChanges();

                        //comiteamos
                        dbContextTransaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        //hacemos rollback si fallo algo
                        dbContextTransaction.Rollback();

                        return Content("Error de sistema. " + ex.Message);

                    }
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }

    }
}