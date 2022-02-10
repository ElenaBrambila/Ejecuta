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
using System.Data;

namespace IntegramsaUltimate.Controllers
{
    public class EfectividadController : BaseController
    {
        // GET: ReporteEfectividadNew
        public ActionResult Index()
        {
            ObtieneSesion();
            return View();
        }
      
        private static DataTable GetDataTable( int idCliente, string fechaInicio, string fechaFin)
        {
            DateTime FechaI;
            DateTime FechaF;
            DateTime dateTimeNow = DateTime.Now;
            TableReporteEfectividadNewViewModel tiendaInfo = null;

            if (fechaInicio == "0")
            {
                DateTime FechaInicio;
                FechaInicio = DateTime.ParseExact(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy") + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                FechaI = FechaInicio;
            }
            else
            {
                DateTime FechaInicio;
                FechaInicio = DateTime.ParseExact(fechaInicio + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                FechaI = FechaInicio;
            }
            if (fechaFin == "0")
            {
                DateTime FechaFin;
                string dateOnlyString = dateTimeNow.ToString("dd/MM/yyyy");
                FechaFin = DateTime.ParseExact(dateOnlyString + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                FechaF = FechaFin;
            }
            else
            {
                DateTime FechaFin;
                FechaFin = DateTime.ParseExact(fechaFin + " 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                FechaF = FechaFin;
            }

            var dates = new List<DateTime>();

            for (var dt = FechaI; dt <= FechaF; dt = dt.AddDays(1))
            {
                var num = dt.DayOfWeek.ToString();
                //se agregan los días excluyendo los domingos
                if (num != "Sunday")
                {
                    dates.Add(dt);
                }
            }
            var data = new DataTable();
            data.Columns.Add("Cliente");
            data.Columns.Add("Ruta ");
            data.Columns.Add("Coordinador");
            data.Columns.Add("Promotor");
            data.Columns.Add("Det");
            data.Columns.Add("Tienda");
            //Columnas dinámicas
            foreach (DateTime date in dates)
            {
                //string nombre = "";
                string dateOnlyString = date.ToString("dd/MM");
                switch (date.DayOfWeek.ToString())
                {
                    case "Monday":
                        data.Columns.Add("Lunes " + dateOnlyString);
                        break;
                    case "Tuesday":
                        data.Columns.Add("Martes " + dateOnlyString);
                        break;
                    case "Wednesday":
                        data.Columns.Add("Miercoles " + dateOnlyString);
                        break;
                    case "Thursday":
                        data.Columns.Add("Jueves " + dateOnlyString);
                        break;
                    case "Friday":
                        data.Columns.Add("Viernes " + dateOnlyString);
                        break;
                    case "Saturday":
                        data.Columns.Add("Sabado " + dateOnlyString);
                        break;
                }
            }
            data.Columns.Add("Acumulado");
            List<Models.TableViewModels.TableReporteEfectividadNewViewModel> Reporte = new List<Models.TableViewModels.TableReporteEfectividadNewViewModel>();
            //Lista de las tiendas
           
            return data;
        }

      
        public ActionResult Listado(System.Data.DataTable model, int idCliente, string fechaInicio, string fechaFin)
        {
            DataTable products = GetDataTable(idCliente, fechaInicio, fechaFin);
            var tiendasList = from d in db.vwreporteEfectivadPrincipal
                              select new
                              {
                                  idTienda = d.idTienda,
                                  tienda = d.tienda
                              };
            return View(products);
        }

        
    }
}