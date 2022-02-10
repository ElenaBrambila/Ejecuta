using IntegramsaUltimate.Models.FilterViewModel;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.TableViewModels;
using IntegramsaUltimate.Models.ViewModels;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate.Controllers
{
    public class ReporteFotoController : BaseController
    {
        public class FotoVieja
        {
            public int id { get; set; }
            public byte[] foto { get; set; }
        }

        // GET: FotoAnaquel
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
                ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;

            return View();
        }

        public ActionResult Ver(int id, int idProposito)
        {
            reporteTienda oReporteTienda= db.reporteTienda.Find(id);
            
            ReporteFotoViewModel model = new ReporteFotoViewModel();

            FotoVieja oFotoVieja = obtenerUltimaFoto(idProposito, oReporteTienda.rutaIntinerario.tienda.id, oReporteTienda.idUsuarioPromotor, oReporteTienda.fechaEntrada);


            model.codigoReporte = oReporteTienda.rutaIntinerario.ruta.codigoRuta;
            model.fotoNueva = oReporteTienda.reporteTiendaFoto.Where(d=>d.idFotoProposito==idProposito).FirstOrDefault().foto;
            model.idFotoNueva = oReporteTienda.reporteTiendaFoto.Where(d => d.idFotoProposito == idProposito).FirstOrDefault().id;
            if (model.fotoVieja != null) //si existe la foto vieja
            {
                model.fotoVieja = oFotoVieja.foto;
                model.idFotoVieja = oFotoVieja.id;
            }
            model.observaciones = oReporteTienda.observaciones;
            model.proposito = oReporteTienda.reporteTiendaFoto.FirstOrDefault().cFotoProposito.nombre;
            model.nombreTienda = oReporteTienda.rutaIntinerario.tienda.nombre;
            model.determinante = oReporteTienda.rutaIntinerario.tienda.codigo;
            model.promotor=oReporteTienda.usuario.nombre+" "+oReporteTienda.usuario.paterno+" "+oReporteTienda.usuario.materno;
            model.plaza = oReporteTienda.rutaIntinerario.tienda.cmunicipio.PlazaMunicipio.FirstOrDefault().cPlaza.nombre;
            model.cadena = oReporteTienda.rutaIntinerario.tienda.cadena.nombre;
            model.observaciones = oReporteTienda.observaciones;

            return View(model);
        }

        public ActionResult Foto(int idFoto)
        {
            reporteTiendaFoto oRF = db.reporteTiendaFoto.Find(idFoto);

            return base.File(oRF.foto, "image/jpeg");

        }

        public ActionResult VerFirma(int id)
        {
            reporteTienda oRF = db.reporteTienda.Find(id);

            return base.File(oRF.foto, "image/jpeg");

        }
        #region Grid
        public ActionResult Listado(FilterFotoAnaquelViewModel model)
        {

            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, FilterFotoAnaquelViewModel model)
        {
            IEnumerable<TableFotoAlmacenViewModel> lst = null;
            
            //casteamos fechas
            DateTime FechaInicio = DateTime.ParseExact(model.fechaInicio + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime FechaFin = DateTime.ParseExact(model.fechaFin + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

           
            lst = from d in db.reporteTienda.ToList()
                    where d.idEstado==1 && d.idUsuarioPromotor==model.cboPromotores && d.fechaEntrada>= FechaInicio && d.fechaEntrada<=FechaFin
                    select new TableFotoAlmacenViewModel
                    {
                        id = d.id,
                        fecha=d.fechaEntrada,
                        observaciones=d.observaciones,
                        existeFirma = (new Func<string>(() =>
                        {
                            try
                            {
                                if (d.foto!=null)
                                {
                                    return "Si";
                                }
                                else
                                {
                                    return "No";
                                }

                            }
                            catch { return "No"; }
                        }
                                                   )
                                  )(),
                        existeFotoUnica=  (new Func<string>(() => {
                                                            try { 
                                                                    if(d.reporteTiendaFoto.Where(c=>c.idFotoProposito==1).Count()>0){
                                                                         return "Si";
                                                                    }
                                                                    else
                                                                    {
                                                                        return "No";
                                                                    }
                                                                    
                                                                } 
                                                            catch { return "No"; } 
                                                        }
                                                  )
                                 )(),
                        existeFotoConcurso = (new Func<string>(() =>
                        {
                            try
                            {
                                if (d.reporteTiendaFoto.Where(c => c.idFotoProposito == 2).Count() > 0)
                                {
                                    return "Si";
                                }
                                else
                                {
                                    return "No";
                                }

                            }
                            catch { return "No"; }
                        }
                                        )
                       )(),
                        existeFotoAntesDespues = (new Func<string>(() =>
                        {
                            try
                            {
                                if (d.reporteTiendaFoto.Where(c => c.idFotoProposito == 3).Count() > 0)
                                {
                                    return "Si";
                                }
                                else
                                {
                                    return "No";
                                }

                            }
                            catch { return "No"; }
                        }
                                                  )
                                 )(),
                        nombreTienda=d.rutaIntinerario.tienda.nombre,
                        encargado=d.encargado,
                        codigoRuta=d.rutaIntinerario.ruta.codigoRuta
                       

                    };


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HELPER

        /// <summary>
        /// metodo que obtiene la ultima foto respecto a otra foto otorgada
        /// </summary>
        /// <param name="idTipoProposito"></param>
        /// <param name="idTienda"></param>
        /// <param name="idPromotor"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private FotoVieja obtenerUltimaFoto(int? idTipoProposito, int? idTienda, int? idPromotor, DateTime? fecha)
        {

            FotoVieja oFotoVieja= null;
            try
            {
                var oReporteFoto = (from d in db.reporteTiendaFoto
                                   where d.reporteTienda.idEstado == 1 && d.reporteTienda.rutaIntinerario.idTienda == idTienda
                                   && d.idFotoProposito == idTipoProposito && d.reporteTienda.idUsuarioPromotor == idPromotor
                                   && d.reporteTienda.fechaEntrada<fecha
                                   orderby d.reporteTienda.fecha descending
                                   select d).FirstOrDefault();

                if (oReporteFoto != null) //si no es null
                {
                    oFotoVieja.foto = oReporteFoto.foto;
                    oFotoVieja.id = oReporteFoto.id;
                   
                }
            }
            catch { oFotoVieja= null; }

            return oFotoVieja;
        }
        #endregion
    }
}