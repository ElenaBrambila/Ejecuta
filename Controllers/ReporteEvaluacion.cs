using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.ViewModels;
using System.Data.Entity;
using System.IO;
using IntegramsaUltimate.Utilidades; //NECESARIO PARA GRID DE KENDO

namespace IntegramsaUltimate.Controllers
{
    public class ReporteEvaluacionController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo(int idTipoUsuario)
        {
            ObtieneSesion();
         

            UsuarioViewModel model= new UsuarioViewModel();
            model.idTipoUsuario=idTipoUsuario;

            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(UsuarioViewModel model, HttpPostedFileBase foto)
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

                //FOTO
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(foto.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }

                 
                    Images.byteArrayToImage(fileData);
                    model.fotoUsuario = fileData;
                }

                //guardamos
                usuario oUsuario = new usuario();
                oUsuario.idEstado = 1;
                oUsuario.fecha = DateTime.Now;
                oUsuario.iddEstado = model.estado;
                oUsuario.nombre = model.nombre;
                oUsuario.materno = model.materno;
                oUsuario.paterno = model.paterno;
                oUsuario.IMSS = model.imss;
                oUsuario.idTipoUsuario = model.idTipoUsuario;
                oUsuario.password = Utilidades.Encrypt.GetSHA1(model.pass1);
                oUsuario.curp = model.curp;
                oUsuario.celular = model.celular;
                oUsuario.telefono = model.telefono;
                oUsuario.foto = model.fotoUsuario;
                oUsuario.email = model.email;
                oUsuario.fechaNacimiento = model.fechaNacimiento;


                db.usuario.Add(oUsuario);
                db.SaveChanges();

                return Content("1");

            }catch(Exception ex){
                 return Content("Ocurrio un error: " + ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ObtieneSesion();

            //obtenemos el usuario
            usuario oUsuario = db.usuario.Find(id);

            UsuarioEditarViewModel model = new UsuarioEditarViewModel();
            model.idTipoUsuario = oUsuario.idTipoUsuario;
            model.nombre = oUsuario.nombre;
            model.paterno = oUsuario.paterno;
            model.materno = oUsuario.materno;
            model.imss = oUsuario.IMSS;
            model.fotoUsuario = oUsuario.foto;
            model.fechaNacimiento = oUsuario.fechaNacimiento;
            model.curp = oUsuario.curp;
            model.estado = oUsuario.iddEstado;
            model.telefono = oUsuario.telefono;
            model.email = oUsuario.email;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarEditar(UsuarioEditarViewModel model, HttpPostedFileBase foto)
        {
            try
            {
                //model es valido
                if (!ModelState.IsValid)
                {
                    return Content(getErroresModelo());
                }

                //validación de negocio
                if (!ValidacionesEditar(model))
                {
                    return Content(error);
                }

                //FOTO
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(foto.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }
                    Images.byteArrayToImage(fileData);
                    model.fotoUsuario = fileData;
                }

                

                //guardamos
                usuario oUsuario = db.usuario.Find(model.id);
               // oUsuario.idEstado = 1;
               // oUsuario.fecha = DateTime.Now;
                oUsuario.iddEstado = model.estado;
                oUsuario.nombre = model.nombre;
                oUsuario.materno = model.materno;
                oUsuario.paterno = model.paterno;
                oUsuario.IMSS = model.imss;
                //password no viene en blanco
                if (model.pass1!=null)
                {
                    oUsuario.password = Utilidades.Encrypt.GetSHA1(model.pass1);
                }
                oUsuario.curp = model.curp;
                oUsuario.celular = model.celular;
                oUsuario.telefono = model.telefono;
                if(model.fotoUsuario!=null) //si se seleccionno foto
                    oUsuario.foto = model.fotoUsuario;
                oUsuario.email = model.email;

                db.Entry(oUsuario).State = EntityState.Modified;
                db.SaveChanges();

                return Content("1");

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }

        public ActionResult Eliminar(int idUsuario)
        {
            try
            {
                usuario oUsuario = db.usuario.Find(idUsuario);

                oUsuario.idEstado=3;
                db.Entry(oUsuario).State = EntityState.Modified;

                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }

        #region Grid
        public ActionResult Listado(int idTipoUsuario)
        {


            return View(idTipoUsuario);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request,int idTipoUsuario)
        {
            IEnumerable<TableUsuariosViewModel> lst = null;

            lst = from d in db.usuario.ToList()
                  where d.idEstado == 1 && d.idTipoUsuario == idTipoUsuario
                  select new TableUsuariosViewModel
                  {
                      id = d.id,
                      nombre = d.nombre + " " + d.paterno + " " + d.materno,
                      email = d.email,

                      estado = d.destado.Nombre ?? "",
                      //esta columna solo aparece cuando es cliente
                      cliente = (new Func<string>(() => {
                                                            try { return d.usuarioCliente.First().cliente.razonSocial; } 
                                                            catch { return ""; } 
                                                        }
                                                  )
                                 )(),
                      supervisor = (new Func<string>(() =>
                      {
                          try { return d.usuario2.nombre + " "+d.usuario2.paterno +" "+d.usuario2.materno; }
                          catch { return "Sin supervisor"; }
                      }
                                       )
                      )()
                  };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPER
        public void ObtenerComponentes()
        {

        }

        public bool Validaciones(UsuarioViewModel model)
        {
            if (Models.HelperModels.Usuario.Existe(model.email))
            {
                error = "El correo electrónico ya existe, intente con otro";
                return false;
            }

            return true;
        }

        public bool ValidacionesEditar(UsuarioEditarViewModel model)
        {
            if (Models.HelperModels.Usuario.Existe(model.email,model.id))
            {
                error = "El correo electrónico ya existe, intente con otro";
                return false;
            }

            return true;
        }
        #endregion
    }
}