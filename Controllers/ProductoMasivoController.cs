using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models;
using System.IO;

namespace IntegramsaUltimate.Controllers
{
    public class ProductoMasivoController : BaseController
    {
        // GET: ProductoMasivo
        public ActionResult Index()
        {
            ViewBag.lstClientes = Models.HelperModels.Cliente.getClientesSL();

            return View();
        }

        public ActionResult Cargar(int idCliente, HttpPostedFileBase archivo)
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

                Excel.ProductoExcel oPE = new Excel.ProductoExcel(stArchivo,idCliente);

                if (!oPE.Cargar())
                {
                    return Content(oPE.getErrores());
                }



            }
            catch (Exception ex)
            {
                return Content("Error de sistema: " + ex.Message);
            }
            return Content("1");
        }
    }
}