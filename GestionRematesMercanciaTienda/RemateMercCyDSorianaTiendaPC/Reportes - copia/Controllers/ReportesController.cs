using System;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Diagnostics;
using NGReciboTiendaSoriana.NGReportes;
using EDReciboTiendaSoriana.EDReportes;
using System.Collections.Generic;
using System.Collections;
using WebMvc.Menu;
//using EDSeguridadSoriana.EDReportes;

namespace ReciboTiendaPC.Reportes.Controllers
{
    public class ReportesController : Controller
    {
        NGReportes ngReportes = new NGReportes();
        EDReportes edReportes = new EDReportes();
        NGRFolioMciaCaduca ngFolioMciaCad = new NGRFolioMciaCaduca();
        [CheckSessionOut]
        public ActionResult Index()
        {
            try
            {
                iniciarComboReportes();
                iniciarComboArea();
                iniciarComboTipoFichaSalida();
                if (Request.QueryString["rpt"] != null)
                {
                    ViewBag.rpt = Request.QueryString["rpt"].ToString();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        [CheckSessionOut]
        public ActionResult AutorizarFolioMerCadCap()
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            try
            {
                iniciarComboJefeDepto();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("AutorizarFolioMerCadCap", ListMerCadCap);
        }
        [CheckSessionOut]
        public ActionResult ReporteFolioMerCadCap()
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            try
            {
                iniciarComboRepJefeDepto();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("ReporteFolioMerCadCap", ListMerCadCap);
        }
        [CheckSessionOut]
        public ActionResult ReporteCapturaMercancíaCaducar()
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            try
            {
                iniciarComboRepJefeDepto();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("ReporteCapturaMercancíaCaducar", ListMerCadCap);
        }
        [CheckSessionOut]
        public ActionResult ReporteActaDestruccion()
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            try
            {
                iniciarComboRepJefeDepto();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("ReporteActaDestruccion", ListMerCadCap);
        }
        [CheckSessionOut]
        public ActionResult ReporteMerma()
        {
            List<EDRMerma> ListMerma = new List<EDRMerma>();
            try
            {
                iniciarComboRepJefeMerma();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("ReporteMerma", ListMerma);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ReimpresionEtiqueta()
        {
            List<EDRReimpresionEtiqueta> ListEtiqueta = new List<EDRReimpresionEtiqueta>();

            return View("ReimpresionEtiqueta", ListEtiqueta);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerFolios()
        {
            iniciarComboJefeDepto();
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            EDRMerCadCap item = new EDRMerCadCap();
            item.Numero = 1;
            item.CodigoBarra = "4400032234";
            item.CodigoUnicoSalida = "0024080202017";
            item.Descripcion = "RMPC GALLETA CHIAHO NABISC";
            item.FechaCaducidad = "2017-02-27";
            item.Lote = "a01";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 2;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202023";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 3;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202039";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 4;
            item.CodigoBarra = "886002506531";
            item.CodigoUnicoSalida = "0024080202040";
            item.Descripcion = "RMPC GALLETA MACADA MR FIFI";
            item.FechaCaducidad = "2017-02-22";
            item.Lote = "1349";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 5;
            item.CodigoBarra = "7500093660738";
            item.CodigoUnicoSalida = "0024080202055";
            item.Descripcion = "RMPC MERMELADA CHABACANO";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "0975004";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 6;
            item.CodigoBarra = "886002500324";
            item.CodigoUnicoSalida = "0024080202068";
            item.Descripcion = "RMPC GALLETA MRS FIELDS DA";
            item.FechaCaducidad = "2017-02-25";
            item.Lote = "0107";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 7;
            item.CodigoBarra = "631723027113";
            item.CodigoUnicoSalida = "0024080202074";
            item.Descripcion = "RMPC CROSTINI TRADICIONALE";
            item.FechaCaducidad = "2017-02-20";
            item.Lote = "15348";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 8;
            item.CodigoBarra = "85968801203";
            item.CodigoUnicoSalida = "0024080202082";
            item.Descripcion = "RMPC ARROS GOLDEN STAR JAS";
            item.FechaCaducidad = "2017-02-27";
            item.Lote = "s";
            ListMerCadCap.Add(item);

            return View("ReporteFolioMerCadCap", ListMerCadCap);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerFoliosAturorizar()
        {
            iniciarComboJefeDepto();
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            EDRMerCadCap item = new EDRMerCadCap();
            item.Numero = 1;
            item.CodigoBarra = "4400032234";
            item.CodigoUnicoSalida = "0024080202017";
            item.Descripcion = "RMPC GALLETA CHIAHO NABISC";
            item.FechaCaducidad = "2017-02-27";
            item.Lote = "a01";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 2;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202023";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 3;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202039";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 4;
            item.CodigoBarra = "886002506531";
            item.CodigoUnicoSalida = "0024080202040";
            item.Descripcion = "RMPC GALLETA MACADA MR FIFI";
            item.FechaCaducidad = "2017-02-22";
            item.Lote = "1349";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 5;
            item.CodigoBarra = "7500093660738";
            item.CodigoUnicoSalida = "0024080202055";
            item.Descripcion = "RMPC MERMELADA CHABACANO";
            item.FechaCaducidad = "2017-02-26";
            item.Lote = "0975004";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 6;
            item.CodigoBarra = "886002500324";
            item.CodigoUnicoSalida = "0024080202068";
            item.Descripcion = "RMPC GALLETA MRS FIELDS DA";
            item.FechaCaducidad = "2017-02-25";
            item.Lote = "0107";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 7;
            item.CodigoBarra = "631723027113";
            item.CodigoUnicoSalida = "0024080202074";
            item.Descripcion = "RMPC CROSTINI TRADICIONALE";
            item.FechaCaducidad = "2017-02-20";
            item.Lote = "15348";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 8;
            item.CodigoBarra = "85968801203";
            item.CodigoUnicoSalida = "0024080202082";
            item.Descripcion = "RMPC ARROS GOLDEN STAR JAS";
            item.FechaCaducidad = "2017-02-27";
            item.Lote = "s";
            ListMerCadCap.Add(item);

            return View("AutorizarFolioMerCadCap", ListMerCadCap);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridFolioMerCadCapPartial(string fecha, string folio)
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            //ListMerCadCap = ngFolioMciaCad.ObtenerFoliosAutorizar(usuario, jefedepto, fecha, folio);
            ListMerCadCap = ngFolioMciaCad.LlenadoGridFolioMciaCad(fecha, folio);
            //return Json(ngFolioMciaCad.LlenadoGridFolioMciaCad(fecha, folio), JsonRequestBehavior.AllowGet);
            return PartialView("~/Views/Shared/_PartialRptAutorizaMerCadCap.cshtml", ListMerCadCap);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridRepFolioMerCadCapPartial(string fecha, string folio)
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            ListMerCadCap = ngFolioMciaCad.LlenadoGridRepFolioMciaCad(fecha, folio);
            //return Json(ngFolioMciaCad.LlenadoGridFolioMciaCad(fecha, folio), JsonRequestBehavior.AllowGet);
            return PartialView("~/Views/Shared/_PartialRptReporteMerCadCap.cshtml", ListMerCadCap);
        }

        //Reporte de Captura de Mercancía por Caducar
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReporteCapturaMercancíaCaducar(string folio)
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            ListMerCadCap = ngReportes.LlenadoGridCapturaMercancíaCaducar(folio);
            return PartialView("~/Views/Shared/_PartialReporteCapturaMercancíaCaducar.cshtml", ListMerCadCap);
        }

        //Reporte de Reporte de Acta de Destrucción.
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReporteActaDestruccion(string folio)
        {
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            ListMerCadCap = ngReportes.LlenadoGridActaDestruccion(folio);
            return PartialView("~/Views/Shared/_PartialReporteActaDestruccion.cshtml", ListMerCadCap);
        }
        //Reporte de Reporte Artículos de Remate Vencidos.
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReporteArtRemVencidos(string fecha)
        {
            List<EDRArtRemVen> ListMerCadCap = new List<EDRArtRemVen>();
            ListMerCadCap = ngReportes.LlenadoGridArtRemVencidos(fecha);
            return PartialView("~/Views/Shared/_PartialRptArtRemVencidos.cshtml", ListMerCadCap);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReporteArtRemProxCadEtapa(string usuario, string categoria, string opcion, string fecha)
        {
            EDRArtRemProxCaducarEtapa ListMerCadCap = new EDRArtRemProxCaducarEtapa();
            List<EDRArtRemProxCaducarEtapa> ListMerCadCapResult = new List<EDRArtRemProxCaducarEtapa>();
            //ListMerCadCap = ngReportes.LlenadoGridArtRemProxCadEtapa(usuario, categoria, opcion, fecha);
            ListMerCadCap = ngReportes.LlenadoGridArtRemProxCadEtapa(usuario, categoria, opcion, fecha);
            ListMerCadCapResult.Add(ListMerCadCap);
            return PartialView("~/Views/Shared/_PartialRptArProxCadEtapa.cshtml", ListMerCadCapResult);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReporteMerma(string fecha, string usuario)
        {
            List<EDRMerma> ListMerma = new List<EDRMerma>();
            ListMerma = ngReportes.LlenadoGridMerma(fecha, usuario);
            return PartialView("~/Views/Shared/_PartialReporteMerma.cshtml", ListMerma);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ObtenerGridReImpEtiqueta(string fecha, string folio)
        {
            List<EDRReimpresionEtiqueta> ListEtiqueta = new List<EDRReimpresionEtiqueta>();
            ListEtiqueta = ngReportes.LlenadoGridReimpresionEtiqueta(fecha, folio);
            return PartialView("~/Views/Shared/_PartialReporteReimpresionEtiqueta.cshtml", ListEtiqueta);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult AutorizarFolios(string folio)
        {
            try
            {
                Hashtable hasCat = new Hashtable();
                hasCat["result"] = ngFolioMciaCad.AutorizarFolios(folio);
                return Json(hasCat, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult GuardarFolioTablaPasoAux(string folio, string codigobarra, string cantCapturarada, string lote)
        {
            Hashtable hasCat = new Hashtable();
            ngFolioMciaCad.GuardarFolioTablaPaso(folio, codigobarra, cantCapturarada, lote);
            hasCat["result"] = "1";
            return Json(hasCat, JsonRequestBehavior.AllowGet);
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult CancelarFolios(string folio)
        {
            Hashtable hasCat = new Hashtable();
            hasCat["result"] = ngFolioMciaCad.CancelarFolios(folio);
            //try
            //{
            //    ngFolioMciaCad.CancelarFolios(folio);
            //    hasCat["result"] = "1";
            //}
            //catch (Exception ex)
            //{
            //    hasCat["result"] = ex;
            //    throw ex;
            //}
            return Json(hasCat, JsonRequestBehavior.AllowGet);
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult ObtenerGridFolioMerCadCap(string jefedepto, string fecha, string folio)
        {
            string usuario = "";
            return Json(ngFolioMciaCad.LlenadoGridFolioMciaCad(fecha, folio), JsonRequestBehavior.AllowGet);
            /*
            iniciarComboJefeDepto();
            List<EDRMerCadCap> ListMerCadCap = new List<EDRMerCadCap>();
            EDRMerCadCap item = new EDRMerCadCap();
            item.Numero = 1;
            item.CodigoBarra = "4400032234";
            item.CodigoUnicoSalida = "0024080202017";
            item.Descripcion = "RMPC GALLETA CHIAHO NABISC";
            item.FechaCaducidad = DateTime.Parse("2017-02-27");
            item.Lote = "a01";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 2;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202023";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = DateTime.Parse("2017-02-26");
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 3;
            item.CodigoBarra = "70038587941";
            item.CodigoUnicoSalida = "0024080202039";
            item.Descripcion = "RMPC GALLETA HIGO ALWAYS SA";
            item.FechaCaducidad = DateTime.Parse("2017-02-26");
            item.Lote = "b12";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 4;
            item.CodigoBarra = "886002506531";
            item.CodigoUnicoSalida = "0024080202040";
            item.Descripcion = "RMPC GALLETA MACADA MR FIFI";
            item.FechaCaducidad = DateTime.Parse("2017-02-22");
            item.Lote = "1349";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 5;
            item.CodigoBarra = "7500093660738";
            item.CodigoUnicoSalida = "0024080202055";
            item.Descripcion = "RMPC MERMELADA CHABACANO";
            item.FechaCaducidad = DateTime.Parse("2017-02-26");
            item.Lote = "0975004";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 6;
            item.CodigoBarra = "886002500324";
            item.CodigoUnicoSalida = "0024080202068";
            item.Descripcion = "RMPC GALLETA MRS FIELDS DA";
            item.FechaCaducidad = DateTime.Parse("2017-02-25");
            item.Lote = "0107";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 7;
            item.CodigoBarra = "631723027113";
            item.CodigoUnicoSalida = "0024080202074";
            item.Descripcion = "RMPC CROSTINI TRADICIONALE";
            item.FechaCaducidad = DateTime.Parse("2017-02-20");
            item.Lote = "15348";
            ListMerCadCap.Add(item);

            item = new EDRMerCadCap();
            item.Numero = 8;
            item.CodigoBarra = "85968801203";
            item.CodigoUnicoSalida = "0024080202082";
            item.Descripcion = "RMPC ARROS GOLDEN STAR JAS";
            item.FechaCaducidad = DateTime.Parse("2017-02-27");
            item.Lote = "s";
            ListMerCadCap.Add(item);
            
            return View("FolioMerCadCap", ListMerCadCap);
            */
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult ObtenerGridFolioMerCadCapAutorizar(string jefedepto, string fecha, string folio)
        {
            string usuario = "";
            return Json(ngFolioMciaCad.LlenadoGridFolioMciaCad(fecha, folio), JsonRequestBehavior.AllowGet);

        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ArtProxCadEtapa()
        {
            List<EDRArtRemProxCaducarEtapa> ListArtProxCadEtapa = new List<EDRArtRemProxCaducarEtapa>();
            try
            {
                iniciarComboJefeRemProxCadEtapa();
                iniciarComboCatRemProxCadEtapa();
                iniciarComboArtRemProxCadEtapa();
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
            }
            return View("ArtProxCadEtapa", ListArtProxCadEtapa);
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult ArtRemVencidos()
        {
            List<EDRArtRemVen> ListArtRemVen = new List<EDRArtRemVen>();
            iniciarComboJefeDepto();
            return View("ArtRemVencidos", ListArtRemVen);
        }

        #region combos
        private void iniciarComboReportes()
        {
            try
            {
                var dropdownVD = new SelectList(ngReportes.NG_rpts_rec_mciaxautList(null, null, null, null), "Object_Rpt", "Nombre_Rpt");
                ViewData["ddlReportes"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboArea()
        {
            try
            {
                var dropdownVD = new SelectList(ngReportes.NG_Rec_dd_area(false, 0, null, null), "Id_Num_AreaESMcia", "Desc_AreaESMcia");
                ViewData["ddlArea"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboTipoFichaSalida()
        {
            try
            {
                var dropdownVD = new SelectList(ngReportes.NG_Rpt_CartaRecl_Crit(false, 0, null, null), "Id_Tipo_Reclama", "Desc_Reclama");
                ViewData["ddlTipoFichaSalida"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboJefeDepto()
        {
            try
            {
                string UserID = "carlosarc";
                var dropdownVD = new SelectList(ngFolioMciaCad.ListCategoria(UserID), "Id", "Descripcion");
                ViewData["ddlSrcJefeDepto"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void iniciarComboRepJefeDepto()
        {
            try
            {
                string UserID = "53";
                var dropdownVD = new SelectList(ngFolioMciaCad.ListRepJefe(UserID), "Id", "Descripcion");
                ViewData["ddlSrcRepJefeDepto"] = dropdownVD;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void iniciarComboRepJefeMerma()
        {
            try
            {
                string UserID = "53";
                var dropdownVD = new SelectList(ngFolioMciaCad.iniciarComboRepJefeMerma(UserID), "Id", "Descripcion");
                ViewData["ddlSrcRepJefeMerma"] = dropdownVD;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboFolioAutorizar(string jefedepto, string fecha)
        {
            try
            {


                var listfolio = new SelectList(ngFolioMciaCad.ListFoliosAutorizar(fecha.Replace("-", ""), jefedepto), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
        [AuthorizationPrivilegeFilter]
        //Combo de Folio para Reporte de Captura de Mercancía por Caducar
        public ActionResult iniciarComboFolioCapMciaCaducar(string fecha)
        {
            try
            {
                var listfolio = new SelectList(ngFolioMciaCad.ListFoliosRepCapMciaCaducar(fecha.Replace("-", "")), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        //Combo de Folio Reporte de Acta de Destrucción.
        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboFolioActaDestruccion(string fecha)
        {
            try
            {
                var listfolio = new SelectList(ngFolioMciaCad.ListFoliosRepActaDestruccion(fecha.Replace("-", "")), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }

        }

        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboRepFolio(string jefedepto, string fecha)
        {
            try
            {
                var listfolio = new SelectList(ngFolioMciaCad.ListRepFolios(fecha.Replace("-", ""), jefedepto), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        private void iniciarComboJefeRemProxCadEtapa()
        {
            try
            {

                string UserID = "carlosarc";
                var dropdownVD = new SelectList(ngFolioMciaCad.ListJefeProxCadEtapa(UserID), "Id", "Descripcion");
                ViewData["ddlSrcJefePrcoCadEtapa"] = dropdownVD;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void iniciarComboCatRemProxCadEtapa()
        {
            string UserID = "-1";
            var dropdownVD = new SelectList(ngFolioMciaCad.ListCatRemProxCadEtapa(UserID), "Id", "Descripcion");
            ViewData["ddlSrcCatRemProxCadEtapa"] = dropdownVD;
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboCatRemPorEtapaPorJefe(string jefedepto)
        {
            try
            {
                var listfolio = new SelectList(ngFolioMciaCad.ListCatRemProxCadEtapa(jefedepto), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }

        }

        private void iniciarComboArtRemProxCadEtapa()
        {
            string UserID = "53";
            var dropdownVD = new SelectList(ngFolioMciaCad.ListArtRemProxCadEtapa(UserID), "Id", "Descripcion");
            ViewData["ddlSrcArtRemProxCadEtapa"] = dropdownVD;
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboFolioReImpEtiqueta(string fecha)
        {
            try
            {
                var listfolio = new SelectList(ngFolioMciaCad.ListFoliosReImpEtiqueta(fecha.Replace("-", "")), "Id", "Descripcion");
                return Json(listfolio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }

        }

        #endregion

        [AuthorizationPrivilegeFilter]
        public JsonResult RptConfigUno(string reporte, int IdNumAreaESMcia, int folio)
        {
            try
            {
                //Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                string path = Path.Combine(Server.MapPath("~/Reportes/rdlc"), "rptPrueba.rdlc");

                var fileName = Guid.NewGuid().ToString() + ".Pdf";

                string SavePath = Path.Combine(Server.MapPath("~/Reportes/pdf"), fileName);
                string RelativePath = "../Reportes/pdf/" + fileName;
                viewer.LocalReport.ReportPath = path;

                ngReportes.NG_RptCargoPorDevolucion(ref viewer);
                var message = SavePdf(viewer, SavePath);

                var result = new { Success = true, Message = RelativePath };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [AuthorizationPrivilegeFilter]
        public ActionResult pruebaReporte()
        {
            return View();
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult CargoPorDevolucion()
        {
            try
            {

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult RptCargoPorDevolucion()
        {
            try
            {
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                string path = Path.Combine(Server.MapPath("~/Reportes/rdlc"), "rptPrueba.rdlc");

                var fileName = Guid.NewGuid().ToString() + ".Pdf";

                string SavePath = Path.Combine(Server.MapPath("~/Reportes/rdlc"), fileName);
                string RelativePath = "../Reportes/rdlc/" + fileName;
                viewer.LocalReport.ReportPath = path;

                ngReportes.NG_RptCargoPorDevolucion(ref viewer);
                var message = SavePdf(viewer, SavePath);

                var result = new { Success = true, Message = RelativePath };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public string SavePdf(ReportViewer viewer, string savePath)
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            //var path = Path.GetTempPath();
            //var fileName = Guid.NewGuid().ToString() + ".Pdf";
            //string savePath = Path.Combine(path, fileName);


            byte[] Bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream Stream = new FileStream(savePath, FileMode.Create))
            {
                Stream.Write(Bytes, 0, Bytes.Length);
            }

            return savePath;
        }

        public void OpenPdf(string location)
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo(location);
            proc.Start();
        }

    }



}