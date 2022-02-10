using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using IntegramsaUltimate.Models;
using Microsoft.Reporting.WebForms;

namespace IntegramsaUltimate.Utilidades
{
    public static class ReportCreation
    {
        public static bool InventariosReport(int? idTienda, int numSemana, int? idStatus, int? idCriterio, int idCliente)
        {
            IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();

            if (idStatus == null || idStatus == 9 && idCriterio == null || idCriterio == 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idTienda == idTienda && d.idCliente == idCliente).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptInventario.rdlc";

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    ReportParameter ptTienda = new ReportParameter("ptTienda", inventariosDb[0].Tienda);
                    ReportParameter ptSemana = new ReportParameter("ptSemana", inventariosDb[0].numSemana.ToString());

                    paramList.Add(ptTienda);
                    paramList.Add(ptSemana);

                    reportViewer.LocalReport.SetParameters(paramList);

                    ReportDataSource reportDataSource = new ReportDataSource("dbSetInventario", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else if (idCriterio != null && idCriterio != 9 && idStatus != null && idStatus != 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idTienda == idTienda && d.idCriterio == idCriterio && d.idEstatusInv == idStatus).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptInventario.rdlc";

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    ReportParameter ptTienda = new ReportParameter("ptTienda", inventariosDb[0].Tienda);
                    ReportParameter ptSemana = new ReportParameter("ptSemana", inventariosDb[0].numSemana.ToString());

                    paramList.Add(ptTienda);
                    paramList.Add(ptSemana);

                    reportViewer.LocalReport.SetParameters(paramList);

                    ReportDataSource reportDataSource = new ReportDataSource("dbSetInventario", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else if (idStatus != null && idStatus != 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idTienda == idTienda && d.idEstatusInv == idStatus).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptInventario.rdlc";

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    ReportParameter ptTienda = new ReportParameter("ptTienda", inventariosDb[0].Tienda);
                    ReportParameter ptSemana = new ReportParameter("ptSemana", inventariosDb[0].numSemana.ToString());

                    paramList.Add(ptTienda);
                    paramList.Add(ptSemana);

                    reportViewer.LocalReport.SetParameters(paramList);

                    ReportDataSource reportDataSource = new ReportDataSource("dbSetInventario", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idTienda == idTienda && d.idCriterio == idCriterio).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptInventario.rdlc";

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    ReportParameter ptTienda = new ReportParameter("ptTienda", inventariosDb[0].Tienda);
                    ReportParameter ptSemana = new ReportParameter("ptSemana", inventariosDb[0].numSemana.ToString());

                    paramList.Add(ptTienda);
                    paramList.Add(ptSemana);

                    reportViewer.LocalReport.SetParameters(paramList);

                    ReportDataSource reportDataSource = new ReportDataSource("dbSetInventario", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }

            
        }
        public static bool MainInventarioReport(int idCadena, int numSemana, int? idStatus, int? idCriterio, int idCliente)
        {
            IntegramsaUltimateEntities db = new IntegramsaUltimateEntities();

            if (idCriterio != null && idCriterio != 9 && idStatus != null && idStatus != 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idCadena == idCadena && d.idCriterio == idCriterio && d.idEstatusInv == idStatus).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptMainReport.rdlc";


                    ReportDataSource reportDataSource = new ReportDataSource("dbSetMainReport", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else if (idCriterio == null || idCriterio == 9 && idStatus == null || idStatus == 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idCadena == idCadena && d.idCliente == idCliente).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptMainReport.rdlc";


                    ReportDataSource reportDataSource = new ReportDataSource("dbSetMainReport", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else if (idCriterio != null && idCriterio != 9)
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idCadena == idCadena  && d.idCriterio == idCriterio).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptMainReport.rdlc";


                    ReportDataSource reportDataSource = new ReportDataSource("dbSetMainReport", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }
            else
            {
                var inventariosDb = db.vwInventario.Where(d => d.numSemana == numSemana && d.idCadena == idCadena && d.idEstatusInv == idStatus).ToList();

                string path = "";
                if (inventariosDb.Count > 0)
                {
                    //Render Conf
                    string deviceInfo = "<DeviceInfo>" +
                         "  <OutputFormat>PDF</OutputFormat>" +
                         "  <PageWidth>8.27in</PageWidth>" +
                         "  <PageHeight>11.69in</PageHeight>" +
                         "  <MarginTop>0.0in</MarginTop>" +
                         "  <MarginLeft>0.0in</MarginLeft>" +
                         "  <MarginRight>0in</MarginRight>" +
                         "  <MarginBottom>0.25in</MarginBottom>" +
                         "  <EmbedFonts>None</EmbedFonts>" +
                         "</DeviceInfo>";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    Warning[] warnings;
                    string[] streams;
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Reporte_Inventario.pdf");

                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.ReportPath = "rptMainReport.rdlc";


                    ReportDataSource reportDataSource = new ReportDataSource("dbSetMainReport", inventariosDb);
                    reportViewer.LocalReport.DataSources.Add(reportDataSource);


                    byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    return true;
                }
                return false;
            }

            
        }
    }    
}