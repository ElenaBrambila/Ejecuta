using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Controllers
{
    public class DropDownListController : Controller
    {
        /// <summary>
        /// regresa las cadenas activas del sistema
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCadenas()
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.cadena.Where(d=>d.idEstado==1).Select(c => new { Id = c.id, nombre = c.nombre }), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// regresa los formatos recibiendo la cadena
        /// </summary>
        /// <param name="idCadena"></param>
        /// <returns></returns>
        public JsonResult GetFormatos(int idCadena)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.formatoTienda.Where(d => d.idEstado == 1 && d.idCadena==idCadena).Select(c => new { Id = c.id, nombre = c.nombre }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// regresa los formatos recibiendo la cadena
        /// </summary>
        /// <param name="NombreDeterminante"></param>
        /// <returns></returns>
        public JsonResult GetDeterminante(int idCadena)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.tienda.Where(d => d.idEstado == 1 && d.idCadena == idCadena).Select(c => new { Id = c.id, nombre = c.nombre }), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// regresa todos los clientes activos
        /// </summary>
        /// <returns></returns>
        public JsonResult GetClientes()
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.cliente.Where(d => d.idEstado == 1 ).Select(c => new { Id = c.id, nombre = c.razonSocial }), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// regresa todos las Plazas activas
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPlazas()
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.cPlaza.OrderBy(d => d.nombre).Select(c => new { Id = c.id, nombre = c.nombre }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// regresa las rutas de un cliente en particular
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRutas(int idCliente)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.ruta.Where(d => d.idEstado == 1 && d.idCliente==idCliente).Select(c => new { Id = c.id, nombre = c.codigoRuta }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTiendasByMunicipio(int idMunicipio)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.tienda.Where(d => d.idEstado == 1 && d.idMunicipio==idMunicipio).Select(c => new { Id = c.id, nombre = c.nombre }), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obtiene los promotores por cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public JsonResult GetPromotoresByCliente(int idCliente)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.usuario.Where(d => d.idEstado == 1 && d.usuarioCliente.Where(f=>f.idCliente==idCliente ).Count()>0).Select(c => new { Id = c.id, nombre = (c.nombre +" "+c.paterno+" "+c.materno) }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoordinadoresByCliente(int idCliente)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.vwclienteCoordinador.Where(d => d.idCliente == idCliente).OrderBy(d => d.paterno).Select(c => new { Id = c.id, nombre = (c.paterno + " " + c.materno + " " + c.nombre) }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPromotoresByCoordinador(int idCoordinador, int idCliente)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.vwcoordinador.Where(d => d.idCoordinador == idCoordinador && d.idCliente == idCliente).OrderBy(d => d.paterno).Select(c => new { Id = c.id, nombre = (c.paterno + " " + c.materno + " " + c.nombre ) }), JsonRequestBehavior.AllowGet);
        }

    }
}