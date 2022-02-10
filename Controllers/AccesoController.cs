using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Controllers
{
    public class AccesoController : BaseController
    {

        public ActionResult Login()
        {


            return View();
        }

        public ActionResult Acceder(string usuario, string password, int idTipoUsuario)
        {
            try
            {
                //validamos
                if (usuario.Equals("") || password.Equals(""))
                {
                    return Content("Usuario y Password son obligatorios");
                }
                //encriptamos
                string passEncryp = Utilidades.Encrypt.GetSHA1(password);


                IEnumerable<usuario> lst = from d in db.usuario
                                           where d.email.Equals(usuario) && d.idEstado == 1 && d.password.Equals(passEncryp) && d.idTipoUsuario==idTipoUsuario
                                           select d;

                //comparamos si existe un usuario
                if (lst.Count() == 0)
                {
                    return Content("Usuario o Password incorrecto");
                }

                Session["Usuario"] = lst.First();

                int idUsuario = lst.First().id;

                //Bitacora.Crear(idUsuario, idModulo, idLogin, "Inició sesión");

                return Content("1");
            }
            catch (Exception ex)
            {

                return Content("Error de sistema: " + ex.Message);
            }
        }

        public ActionResult Salir()
        {
            try
            {
                oUsuario = (usuario)Session["Usuario"];
                int idUsuario = oUsuario.id;

               // Bitacora.Crear(idUsuario, idModulo, idLogOff, "Cerró sesión");

                //borramos el objeto
                Session["Usuario"] = null;

                return Content("1");
            }
            catch (Exception ex)
            {

                return Content("Error de sistema: " + ex.Message);
            }
        }


    }
}