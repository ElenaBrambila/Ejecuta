using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate.Controllers
{
    public class EstadoMunicipioController : Controller
    {
        /// <summary>
        /// regresa los estados
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEstados()
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.destado.Select(c => new { Id=c.iddEstado,nombre=c.Nombre}),JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipios(int iddEstado)
        {
            var db = new IntegramsaUltimateEntities();
            return Json(db.cmunicipio.Where(d=>d.iddEstado==iddEstado).Select(c => new { Id = c.idcMunicipio, nombre = c.Nombre }), JsonRequestBehavior.AllowGet);
        }
    }
}