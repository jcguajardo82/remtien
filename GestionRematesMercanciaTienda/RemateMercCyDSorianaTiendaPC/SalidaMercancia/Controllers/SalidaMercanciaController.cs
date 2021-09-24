using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NGSalidaMercanciaDevDanSorianaTienda.NGPorcentajeRemates;
using EDSalidaMercanciaDevDanSorianaTienda.EDPorcentajeRemates;
using System.Net;
using WebMvc.Menu;

namespace SalidaMercanciaDevDanSorianaTiendaPC.SalidaMercancia.Controllers
{

    public class SalidaMercanciaController : Controller
    {
        NGPorcentajeRemates ngPorcentaje = new NGPorcentajeRemates();
        EDPorcentajeRemates edPorcentaje = new EDPorcentajeRemates();

        #region Combos

        private void iniciarComboDefectos(decimal Num_CodBarra)
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_UpTdagmd_dd_Defecto(Num_CodBarra), "Id_Num_Defecto", "Desc_Defecto");
                ViewData["ddlNumDefecto"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarSolucionProv()
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_UpTdagmd_dd_SolucionProv(), "Id_Num_SolucProv", "Desc_SolucProv");
                ViewData["ddlNumSolucProv"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboFmtoTienda()
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_SP_Get_gmdFmto(), "Id_Cve_Fmto", "Desc_Fmto");
                ViewData["ddlFtoTienda"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboCategoria()
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_SP_Get_gmdCategoria(), "Id_Num_Categ", "Desc_Categ");
                ViewData["ddlCategoria"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void iniciarComboOrigenMcia()
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_SP_Get_gmdOrigenMcia(), "Id_Num_OrigenMcia", "Desc_OrigenMcia");
                ViewData["ddlOrigenMcia"] = dropdownVD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult iniciarComboLinea(int iId_Num_Categ)
        {
            try
            {
                var list = ngPorcentaje.NG_SP_Get_gmdLinea(iId_Num_Categ);
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        #endregion

        #region  Devoluciones Pendientes de Solucion
        [CheckSessionOut]
        public ActionResult RegistroDevoluciones()
        {
            try
            {
                iniciarComboDefectos(-1);
                ViewBag.listDevoluciones = ngPorcentaje.NG_SP_Get_gmdFolioGMD();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [AuthorizationPrivilegeFilter]
        public JsonResult actualizarComboDefectos(decimal Num_CodBarra)
        {
            try
            {
                var dropdownVD = new SelectList(ngPorcentaje.NG_UpTdagmd_dd_Defecto(Num_CodBarra), "Id_Num_Defecto", "Desc_Defecto");
                //ViewData["ddlNumDefecto"] = dropdownVD;

                var result = new { Success = true, Message = "ok", Lista = dropdownVD };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [AuthorizationPrivilegeFilter]
        public JsonResult SolucionarFolio(int Id_Fol_GMD, int? IdNumDefecto, bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto, string CveSerie, string CveModelo)
        {
            try
            {
                string Message = ngPorcentaje.NG_UpTdagmd_Upd_gmdFolioGMD(Id_Fol_GMD, IdNumDefecto, Bit_AptoVta, Bit_EmpOriginal
                    , Bit_ReqDescto, -1, -1, string.Empty, CveSerie, CveModelo, 0);
                // string Message = "ok";

                var result = new { Success = true, Message = Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Alta Devoluciones
        [CheckSessionOut]
        public ActionResult RegistraMercanciaDanada()
        {
            try
            {
                iniciarComboDefectos(-1);
                iniciarComboOrigenMcia();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult ObtenerArt(decimal NumCodBarra)
        {
            try
            {
                var codBarr = ngPorcentaje.NG_SP_Get_gmd_Sel_CodBarra(NumCodBarra);

                string sku = string.Empty, desc = string.Empty, Id_Num_Prov = string.Empty, Id_Num_Linea = string.Empty;
                //                public int Id_Num_Prov { get; set; }
                //public int Id_Num_Linea { get; set; }
                foreach (var item in codBarr)
                {
                    sku = item.Id_Num_SKU.ToString();
                    desc = item.ddDesc_Ensamb.ToString();
                    Id_Num_Prov = item.Id_Num_Prov.ToString();
                    Id_Num_Linea = item.Id_Num_Linea.ToString();
                }

                var result = new { Success = true, Message = "ok", Id_Num_SKU = sku, ddDesc_Ensamb = desc, Id_Num_Prov = Id_Num_Prov, Id_Num_Linea = Id_Num_Linea };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message, Id_Num_SKU = "", ddDesc_Ensamb = "", Id_Num_Prov = string.Empty, Id_Num_Linea = string.Empty };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult Gen_gmdFolioGMD(int iId_Num_OrigenMcia, int iId_Num_SKU, int iId_Num_Linea, int iId_Num_Prov
           , bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto, string iDesc_Incid, string CveSerie, string CveModelo, int? IdNumDefecto)
        {
            try
            {
                int iUserId = int.Parse(System.Web.HttpContext.Current.Session["SystemUserId"] != null ? System.Web.HttpContext.Current.Session["SystemUserId"].ToString() : "0");

                string Message = ngPorcentaje.NG_UpTdagmd_Gen_gmdFolioGMD(iId_Num_OrigenMcia, iId_Num_SKU, iId_Num_Linea, iId_Num_Prov
           , Bit_AptoVta, Bit_EmpOriginal, Bit_ReqDescto, iDesc_Incid, iUserId, CveSerie, CveModelo, IdNumDefecto);
                var result = new { Success = true, Message = Message };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string msg;
                if (ex.Message.Contains("EXECUTE"))
                {
                    msg = ex.Message.Remove(ex.Message.IndexOf("Transaction")); ;
                }
                else
                {
                    msg = ex.Message;
                }
                var result = new { Success = false, Message = msg };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region ConsultaSolucionesAsignadas
        [CheckSessionOut]
        public ActionResult ConsultaSolucionesAsignadas()
        {
            try
            {
                DateTime? FechaFinal = DateTime.Now;
                DateTime? FechaInicial = DateTime.Now.AddDays(-90);
                ViewBag.FechaFinal = DateTime.Now.ToShortDateString();
                ViewBag.FechaInicial = DateTime.Now.AddDays(-90).ToShortDateString();

                ViewBag.listSoluciones = ngPorcentaje.NG_UpTdagmd_Cns_SolGenyPendRepara(FechaInicial, FechaFinal, false);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult BusquedaSoluciones(string FechaInicial, string FechaFinal)
        {
            try
            {
                var list = ngPorcentaje.NG_UpTdagmd_Cns_SolGenyPendRepara(Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal), false);
                return Json(list, JsonRequestBehavior.AllowGet);
                // return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region ConsultaSalidaDevolucionMcia
        [CheckSessionOut]
        public ActionResult ConsultaSalidaDevolucionMcia()
        {
            try
            {
                //iniciarComboDefectos();
                iniciarSolucionProv();
                ViewBag.listPendientesRep = ngPorcentaje.NG_UpTdagmd_Cns_SolGenyPendRepara(null, null, true);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        [AuthorizationPrivilegeFilter]
        public JsonResult SolucionarReparacion(int Id_Fol_GMD, int IdNumDefecto, int Bit_ReparoMcia, string Observaciones, int IdNumSolucProv)
        {
            try
            {
                string Message = ngPorcentaje.NG_UpTdagmd_Upd_gmdFolioGMD(Id_Fol_GMD, IdNumDefecto, false, false
                    , false, Bit_ReparoMcia, -1, Observaciones, "", "", IdNumSolucProv);
                // string Message = "ok";

                var result = new { Success = true, Message = Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


    }
}