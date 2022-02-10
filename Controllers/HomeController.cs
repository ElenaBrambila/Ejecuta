using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegramsaUltimate.Models.TableViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using IntegramsaUltimate.Models.FilterViewModel;
using IntegramsaUltimate.Models;

namespace IntegramsaUltimate.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ObtieneSesion();
            //si el usuario es un cliente
            if (oUsuario.idTipoUsuario == 6)
            {
                if (oUsuario.usuarioCliente != null)
                {
                    int idCliente = (int)oUsuario.usuarioCliente.First().idCliente;
                    ViewBag.idCliente = oUsuario.usuarioCliente.First().idCliente;
                    ViewBag.cliente = oUsuario.nombre;
                    ViewBag.imagenCliente = ViewBag.idCliente + ".jpg";
                    ViewBag.lstUsuarios = Models.HelperModels.Usuario.getUsuariosByTipoSL(2);
                    IList<usuario> promotoresCliente = Models.HelperModels.Usuario.getUsuariosByTipoSL1(2, (int)oUsuario.usuarioCliente.First().idCliente);
                    ViewBag.lstSemanas = Models.HelperModels.Semana.getSemanasSL(Utilidades.Date.obtieneNumeroSemanaAno(DateTime.Now));
                    ViewBag.lstAnos = Models.HelperModels.Ano.getAnosSL(DateTime.Now.Year);
                    int semanaInfo;
                    ViewBag.semana = semanaInfo = Utilidades.Date.obtieneNumeroSemanaAno(DateTime.Now);

                    //Cobertura
                    IQueryable<TableReporteAsistenciaCoberturaViewModel> query = null;
                    IEnumerable<TableReporteTiempoEfectivoViewModel> lst2 = null;
                    query = from d in db.fnReporteAsistenciaCobertura(semanaInfo, null, DateTime.Now.Year)
                            select new TableReporteAsistenciaCoberturaViewModel
                            {
                                Nombre = d.nombre,
                                cobertura = d.cobertura,
                                asignadas = d.asignadas,
                                cubieras = d.cubiertas,
                                idUsuarioPromotor = d.idUsuarioPromotor
                            };

                    //Filtramos por promotores asociados al cliente
                    var uids = promotoresCliente.Select(id => id.id).ToList();
                    var selected = query.Where(t => uids.Contains((int)t.idUsuarioPromotor));
                    System.Nullable<Decimal> promedioCobertura = (from prom in selected select prom.cobertura).Average();
                    System.Nullable<Decimal> sumAsignadas = (from prom in selected select prom.asignadas).Sum();
                    System.Nullable<Decimal> sumCubiertas = (from prom in selected select prom.cubieras).Sum();

                    ViewBag.cobertura = 0;
                    ViewBag.coberturaDia = 0;

                    if (promedioCobertura != null)
                    {
                        ViewBag.cobertura = round((double)promedioCobertura, 2);
                        ViewBag.coberturaDia = round((double)(promedioCobertura / 6), 2);


                    }
                    ViewBag.asignadas = sumAsignadas.ToString();
                    ViewBag.cubiertas = sumCubiertas.ToString();
                    
                    ViewBag.asignadasDia = (sumAsignadas/6).ToString();
                    ViewBag.cubiertasDia = (sumCubiertas/6).ToString();
                   //Fin de cobertura
                    
                    
                    //Tiempo efectivo de la semana
                    IQueryable<TableReporteTiempoEfectivoViewModel> query2 = null;

                    query2 = from d in db.fnReporteTiempoEfectivo()
                             where d.ano == DateTime.Now.Year && d.numSemana == semanaInfo
                             select new TableReporteTiempoEfectivoViewModel
                             {
                                 idUsuarioPromotor = d.idUsuarioPromotor,
                                 Nombre = d.nombre,
                                 dia1 = d.lunes,
                                 dia2 = d.martes,
                                 dia3 = d.miercoles,
                                 dia4 = d.jueves,
                                 dia5 = d.viernes,
                                 dia6 = d.sabado,
                                 total = d.total
                             };

                    //Filtramos por cliente
                    lst2 = query2.Where(t => uids.Contains((int)t.idUsuarioPromotor)).ToList();
                    //Obtenemos todos los ´valores de la semana
                    List<string> list = (from de in lst2 select de.total).ToList();
                    List<double> listaTotalesDobles = new List<double>();
                    
                    

                    TimeSpan tiempoTotalSemana = new TimeSpan();
                    TimeSpan tiempoTotalDia = new TimeSpan();

                    //Tiempo efectivo del día
                    DateTime ClockInfoFromSystem = DateTime.Now;
                    int dia = (int)ClockInfoFromSystem.DayOfWeek;
                    //Vamos a calcular un día antes pero si es lunes tiene que poner el del domingo
                    if (dia == 1)
                    {

                        dia = 7;
                    }

                    else
                    {

                        dia = dia - 1;
                    }
                    string diaSemana = Utilidades.Date.obtieneDiaxNumero(dia);
                    ViewBag.dia = diaSemana;

                    //Vamos a obtener la suma por días
                    double horasLunes = 0;
                    double horasMartes = 0;
                    double horasMiercoles = 0;
                    double horasJueves = 0;
                    double horasViernes = 0;
                    double horasSabado = 0;

                    foreach (var valor in lst2)
                    {  
                        //Sumamos el total de toda la semana de cada promotor
                        TimeSpan ts = new TimeSpan(int.Parse(valor.total.Split(':')[0]),    // hours
                                                   int.Parse(valor.total.Split(':')[1]),    // minutes
                                                   0);

                        tiempoTotalSemana = tiempoTotalSemana.Add(ts);
                        Double valorHoras = ts.TotalHours;
                        listaTotalesDobles.Add(valorHoras);
                        //Dividimos por el día de cada promotor y lo sumamos.
                        TimeSpan tLunes = new TimeSpan(int.Parse(valor.dia1.Split(':')[0]),    // hours
                                           int.Parse(valor.dia1.Split(':')[1]),    // minutes
                                           0);
                        horasLunes += tLunes.TotalHours;
                        TimeSpan tMartes = new TimeSpan(int.Parse(valor.dia2.Split(':')[0]),    // hours
                                              int.Parse(valor.dia2.Split(':')[1]),    // minutes
                                              0);
                        horasMartes += tMartes.TotalHours;
                        TimeSpan tMiercoles = new TimeSpan(int.Parse(valor.dia3.Split(':')[0]),    // hours
                                               int.Parse(valor.dia3.Split(':')[1]),    // minutes
                                               0);
                        horasMiercoles += tMiercoles.TotalHours;
                        TimeSpan tJueves = new TimeSpan(int.Parse(valor.dia4.Split(':')[0]),    // hours
                                               int.Parse(valor.dia4.Split(':')[1]),    // minutes
                                               0);
                        horasJueves += tJueves.TotalHours;
                        TimeSpan tViernes = new TimeSpan(int.Parse(valor.dia5.Split(':')[0]),    // hours
                                               int.Parse(valor.dia5.Split(':')[1]),    // minutes
                                               0);
                        horasViernes += tViernes.TotalHours;
                        TimeSpan tSabado = new TimeSpan(int.Parse(valor.dia6.Split(':')[0]),    // hours
                                              int.Parse(valor.dia6.Split(':')[1]),    // minutes
                                              0);
                        horasSabado += tSabado.TotalHours;


                        switch (dia)
                        {
                            case 1:
                                TimeSpan ts1 = new TimeSpan(int.Parse(valor.dia1.Split(':')[0]),    // hours
                                               int.Parse(valor.dia1.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts1);
                                break;
                            case 2:
                                TimeSpan ts2 = new TimeSpan(int.Parse(valor.dia2.Split(':')[0]),    // hours
                                               int.Parse(valor.dia2.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts2);
                                break;
                            case 3:
                                TimeSpan ts3 = new TimeSpan(int.Parse(valor.dia3.Split(':')[0]),    // hours
                                               int.Parse(valor.dia3.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts3);
                                break;
                            case 4:
                                TimeSpan ts4 = new TimeSpan(int.Parse(valor.dia4.Split(':')[0]),    // hours
                                               int.Parse(valor.dia4.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts4);
                                break;
                            case 5:
                                TimeSpan ts5 = new TimeSpan(int.Parse(valor.dia5.Split(':')[0]),    // hours
                                               int.Parse(valor.dia5.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts5);
                                break;
                            case 6:
                                TimeSpan ts6 = new TimeSpan(int.Parse(valor.dia6.Split(':')[0]),    // hours
                                               int.Parse(valor.dia6.Split(':')[1]),    // minutes
                                               0);
                                tiempoTotalDia = tiempoTotalDia.Add(ts6);
                                break;
                            case 7: // Ahorita no se tiene el domingo
                                    //TimeSpan ts7 = new TimeSpan(int.Parse(valor.dia.Split(':')[0]),    // hours
                                    //               int.Parse(valor.dia7.Split(':')[1]),    // minutes
                                    //               0);
                                    //tiempoTotalDia = tiempoTotalDia.Add(ts7);
                                break;
                            default: break;
                        }
                    }


                    ViewBag.lHorasLunes = Math.Round(horasLunes,2);
                    ViewBag.lHorasMartes = Math.Round(horasMartes,2);
                    ViewBag.lHorasMiercoles = Math.Round(horasMiercoles,2);
                    ViewBag.lHorasJueves = Math.Round(horasJueves,2);
                    ViewBag.lHorasViernes = Math.Round(horasViernes,2);
                    ViewBag.lHorasSabado = Math.Round(horasSabado,2);

                    ViewBag.ListaTotales = listaTotalesDobles;
                    ViewBag.tiempoEfectivoTotal = Math.Round(tiempoTotalSemana.TotalHours, 2).ToString();
                    ViewBag.tiempoEfectivoDiaAnterior = Math.Round(tiempoTotalDia.TotalHours, 2).ToString();
                    if (tiempoTotalSemana.TotalHours > 0)
                    {
                        ViewBag.promPromotorTiempoEfectivo = Math.Round((tiempoTotalSemana.TotalHours / lst2.Count()), 2).ToString();

                    }
                    else
                    {
                        ViewBag.promPromotorTiempoEfectivo = 0;

                    }

                    //Tiempo Efectivo - cadena

                    
                    //var query3 = from d in db.fnRepTiempoTotalCadenas(0, semanaInfo, DateTime.Now.Year, idCliente)
                    //             orderby d.total
                    //             select d;

                    //if (query3.Count() > 0)
                    //{
                    //    IList<TableReporteTiempoEfectivoByCadenaTotalViewModel> lista = new List<TableReporteTiempoEfectivoByCadenaTotalViewModel>();
                    //    foreach (var dato in query3)
                    //    {
                    //        TableReporteTiempoEfectivoByCadenaTotalViewModel tabla = new TableReporteTiempoEfectivoByCadenaTotalViewModel();
                    //        tabla.idCadena = dato.idCadena;
                    //        tabla.Nombre = dato.nombre;
                    //        tabla.total = new TimeSpan(int.Parse(dato.total.Split(':')[0]),    // hours
                    //                            int.Parse(dato.total.Split(':')[1]),    // minutes
                    //                            0);
                    //        tabla.totalHoras = Math.Round(tabla.total.TotalHours,2);
                    //        lista.Add(tabla);

                    //    }

                    //    IList<double> listaTotales = (from p in lista select p.totalHoras).ToList();
                    //    lista = (from lt in lista  orderby lt.totalHoras descending select lt).Take(8).ToList();
                    //    if (lista.Count() > 0)
                    //    {
                    //        ViewBag.cNombre1 = lista[0].Nombre;
                    //        ViewBag.cNombre2 = lista[1].Nombre;
                    //        ViewBag.cNombre3 = lista[2].Nombre;
                    //        ViewBag.cNombre4 = lista[3].Nombre;
                    //        ViewBag.cNombre5 = lista[4].Nombre;
                    //        ViewBag.cNombre6 = lista[5].Nombre;
                    //        ViewBag.cNombre7 = lista[6].Nombre;
                    //        ViewBag.cNombre8 = lista[7].Nombre;

                    //        ViewBag.cValor1 = lista[0].totalHoras;
                    //        ViewBag.cValor2 = lista[1].totalHoras;
                    //        ViewBag.cValor3 = lista[2].totalHoras;
                    //        ViewBag.cValor4 = lista[3].totalHoras;
                    //        ViewBag.cValor5 = lista[4].totalHoras;
                    //        ViewBag.cValor6 = lista[5].totalHoras;
                    //        ViewBag.cValor7 = lista[6].totalHoras;
                    //        ViewBag.cValor8 = lista[7].totalHoras;



                    //        ViewBag.listaCadenas = lista;
                    //    }

                    //    else
                    //    {
                    //        lista = new List<TableReporteTiempoEfectivoByCadenaTotalViewModel>();
                    //        TableReporteTiempoEfectivoByCadenaTotalViewModel tabla = new TableReporteTiempoEfectivoByCadenaTotalViewModel();
                    //        tabla.idCadena = 0;
                    //        tabla.Nombre = "Sin registros<";
                    //        tabla.total = new TimeSpan();
                    //        tabla.totalHoras = 0;
                    //        lista.Add(tabla);
                    //        ViewBag.listaCadenas = lista;

                    //    }
                    //}

                    //else
                    //{
                    //    IList<TableReporteTiempoEfectivoByCadenaTotalViewModel> lista = new List<TableReporteTiempoEfectivoByCadenaTotalViewModel>();
                    //    TableReporteTiempoEfectivoByCadenaTotalViewModel tabla = new TableReporteTiempoEfectivoByCadenaTotalViewModel();
                    //    tabla.idCadena = 0;
                    //    tabla.Nombre = "Sin registros<";
                    //    tabla.total = new TimeSpan();
                    //    tabla.totalHoras = 0;
                    //    lista.Add(tabla);
                    //    ViewBag.listaCadenas = lista;
                    //    ViewBag.cadenas = "Sin resultados";
                    //}

                }
            }




            return View();
        }




        public static double round(double value, int places)
        {
            long factor = (long)Math.Pow(10, places);
            value = value * factor;
            double tmp = Math.Round(value);
            return (double)tmp / factor;
        }

        public ActionResult Listado(ReporteAsistenciaCoberturaViewModel model)
        {


            return View(model);
        }

        public ActionResult JsonGrid([DataSourceRequest] DataSourceRequest request, ReporteAsistenciaCoberturaViewModel model)
        {
            IEnumerable<TableReporteAsistenciaCoberturaViewModel> lst = null;
            IQueryable<TableReporteAsistenciaCoberturaViewModel> query = null;

            query = from d in db.fnReporteAsistenciaCobertura(model.numSemana, model.idPromotor, model.ano)

                    select new TableReporteAsistenciaCoberturaViewModel
                    {
                        Nombre = d.nombre,
                        cobertura = d.cobertura,
                        asignadas = d.asignadas,
                        cubieras = d.cubiertas,
                        idUsuarioPromotor = d.idUsuarioPromotor
                    };

            //filtramos
            if (model.idPromotor != null)
                query = query.Where(d => d.idUsuarioPromotor == model.idPromotor);

            //ejecutamos el query
            lst = query.ToList();


            return Json(lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}