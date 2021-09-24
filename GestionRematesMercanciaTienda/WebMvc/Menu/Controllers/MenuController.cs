using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebMvc.Menu.Controllers
{
    public class SaldoProvModels
    {
        public int Id_Num_UN { get; set; }
        public int Id_Num_Folio { get; set; }
        public int Id_Num_Prov { get; set; }
        public int Id_Fol_Sol { get; set; }
        public decimal Imp_SinImpto { get; set; }
        public decimal Imp_Impto { get; set; }
        public decimal Imp_ConImpto { get; set; }
        public int TipoMov { get; set; }
    }

    public class AnalizaSaldoProvResponseModel
    {

        public string Status { get; set; }
        public string SaldoProv { get; set; }
        public string FolioAtn { get; set; }
        public string Mensaje { get; set; }
        public string ErrorRec { get; set; }

    }

    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            //SaldoProvModels saldo = new SaldoProvModels();

            //saldo.Id_Fol_Sol = 12345;

            
            //string json2 = string.Empty;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //json2 = js.Serialize(saldo);
            //js = null;

            //var client = new WebMvc.Content.RestClient();
            //client.EndPoint = @"http://tdaqalegsap337/ServicioImp/AnalizaSaldoProv";
            //client.Method = HttpVerb.GET;
            //client.PostData =json2;

            //var json = client.MakeRequest();

            //AnalizaSaldoProvResponseModel flight = Newtonsoft.Json.JsonConvert.DeserializeObject<AnalizaSaldoProvResponseModel>(json);

            return View();
        }

        //[CheckSessionOut]
        public ActionResult Inicio()
        {
            
            string cookie = "There is no cookie!";
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
            {
                cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
            }

            return View();
        }


        public ActionResult AuditoriaTarima()
        {
            return View();
        }

        public ActionResult CierreAuditoria()
        {
            return View();
        }

        public ActionResult ConfGuiaAuditar()
        {
            return View();
        }

        public ActionResult ConfTarimaAudita()
        {
            return View();
        }

        public ActionResult ImprimirAuditoria()
        {
            return View();
        }


        public ActionResult Inicio_1_1()
        {
            return View();
        }
        public ActionResult Inicio_1_7()
        {
            return View();
        }

        public ActionResult Inicio_2()
        {
            return View();
        }

        public ActionResult Inicio_2_1()
        {
            return View();
        }

        public ActionResult Inicio_2_2()
        {
            return View();
        }

        public ActionResult Inicio_2_3()
        {
            return View();
        }

        public ActionResult Inicio_3()
        {
            return View();
        }

        public ActionResult Inicio_4()
        {
            return View();
        }


        public ActionResult Navegacion(string cedis)
        {
            //NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar ng = new NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar();
            //string res = ng.ValidaCedis(cedis);



            //if (!string.IsNullOrEmpty(res))
            //{ TempData["messageLbl"] = res; TempData["cedis"] = cedis; }
            //else
            //{ TempData["messageLbl"] = "Consulte desde el incio - " + ng.ValidaCedis("5554"); }
            return View();
        }

        public ActionResult Navegacion2(string cedis, string infoTxt)
        {
            //    NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar ng = new NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar();
            //    string res = ng.ValidaCedis(cedis);



            //    if (!string.IsNullOrEmpty(res))
            //    { TempData["messageLbl"] = res; TempData["cedis"] = cedis; }
            //    else
            //    { TempData["messageLbl"] = "Consulte desde el incio - " + ng.ValidaCedis("5554"); }


            return View();
        }


        public ActionResult UrlNavegation(string menuOption)
        {
            switch (menuOption)
            {
                case "1":
                    return RedirectToAction("Inicio_1_1", "Menu");
                case "11":
                    return RedirectToAction("ArriboTransportista", "RegistroSecos");
                case "12":
                    return RedirectToAction("ControlMarchamos", "RegistroSecos");
                case "13":
                    return RedirectToAction("ConfirmaTarima", "RegistroSecos");
                case "14":
                    return RedirectToAction("RegistroMercanciaIncidencia", "RegistroSecos");
                case "15":
                    return RedirectToAction("SalidaTransportista", "RegistroSecos");
                case "16":
                    return RedirectToAction("CerrarEmbarque", "RegistroSecos");
                case "17":
                    return RedirectToAction("Inicio_1_7", "RegistroSecos");
                case "171":
                    return RedirectToAction("ConfGuiaAuditar", "AuditoriaGuia");
                case "172":
                    return RedirectToAction("ConfTarimaAudita", "AuditoriaGuia");
                case "173":
                    return RedirectToAction("AuditoriaTarima", "AuditoriaGuia");
                case "174":
                    return RedirectToAction("CierreAuditoria", "AuditoriaGuia");
                case "175":
                    return RedirectToAction("ImprimirAuditoria", "AuditoriaGuia");
                case "2":
                    return RedirectToAction("Inicio_2", "Menu");
                case "21":
                    return RedirectToAction("Inicio_2_1", "Menu");

                case "211":
                    return RedirectToAction("IndicaAccionPrincipal", "RecibirFolioNE");
                case "212":
                    return RedirectToAction("IndicaTipodeEntrega", "RecibirFolioNE");
                case "213":
                    return RedirectToAction("IndicaFactura", "RecibirFolioNE");
                case "214":
                    return RedirectToAction("CapturaDatosdeFactura", "RecibirFolioNE");
                case "215":
                    return RedirectToAction("ConfirmaDatosdeFactura", "RecibirFolioNE");
                case "216":
                    return RedirectToAction("ResumenDeMercancia", "RecibirFolioNE");
                case "217":
                    return RedirectToAction("AutorizacionDeFolio", "RecibirFolioNE");
                case "218":
                    return RedirectToAction("AutorizaDetallePedVen", "RecibirFolioNE");
                case "219":
                    return RedirectToAction("IndicaCodigoParaRecibo", "RecibirFolioNE");
                case "2110":
                    return RedirectToAction("IndicaCodigoGS1", "RecibirFolioNE");
                case "2111":
                    return RedirectToAction("CapturaLoteYPesoDeGS1", "RecibirFolioNE");
                case "2112":
                    return RedirectToAction("CofirmaLoteYPesoDeGS1", "RecibirFolioNE");
                case "2113":
                    return RedirectToAction("IndicaModoReciboDeCod", "RecibirFolioNE");

                case "2114":
                    return RedirectToAction("CapturaModoNormal", "RecibirFolioNE");
                case "2115":
                    return RedirectToAction("CapturaModoBascula", "RecibirFolioNE");
                case "2116":
                    return RedirectToAction("AutorizaCapEmpaque", "RecibirFolioNE");
                case "2117":
                    return RedirectToAction("ErrorDeAutCapEmp", "RecibirFolioNE");
                case "2118":
                    return RedirectToAction("CierreDeFolio", "RecibirFolioNE");
                case "2119":
                    return RedirectToAction("MercanciaMalEstado", "RecibirFolioNE");
                case "2120":
                    return RedirectToAction("CantidadMalEstado", "RecibirFolioNE");
                case "2121":
                    return RedirectToAction("ConfirmaFacturaElectronica", "RecibirFolioNE");
                case "2122":
                    return RedirectToAction("IndicaDetalleFactura", "RecibirFolioNE");
                case "2123":
                    return RedirectToAction("CierreDeFolioFinal", "RecibirFolioNE");
                case "2124":
                    return RedirectToAction("EstatusDeFolio", "RecibirFolioNE");
                case "2125":
                    return RedirectToAction("TransportistaFolio", "RecibirFolioNE");
                case "2126":
                    return RedirectToAction("DetalleBulto", "RecibirFolioNE");
                case "2127":
                    return RedirectToAction("RetomaFolio", "RecibirFolioNE");
                case "2128":
                    return RedirectToAction("ConfirmaRetomarFolio", "RecibirFolioNE");
                case "2129":
                    return RedirectToAction("ValidaFactura", "RecibirFolioNE");


                case "22":
                    return RedirectToAction("Inicio_2_2", "Menu");
                case "23":
                    return RedirectToAction("Inicio_2_3", "Menu");
                case "24":
                    return RedirectToAction("AutorizaDevolucion", "RegistroDeMercancia");
                case "25":
                    return RedirectToAction("CapturaDevolucion", "RegistroDeMercancia");
                case "26":
                    return RedirectToAction("DatosDeEnvio", "RegistroDeMercancia");
                case "27":
                    return RedirectToAction("RevisaDatosFactura", "RegistroDeMercancia");
                case "3":
                    return RedirectToAction("Inicio_3", "Menu");
                case "31":
                    return RedirectToAction("RegistroSalidaMercanciaProveedor", "SalidaMercancia");
                case "32":
                    return RedirectToAction("RegistroSalidaMercanciaTransportista", "SalidaMercancia");
                case "4":
                    return RedirectToAction("Inicio_4", "Menu");
                
                default:
                    return RedirectToAction("Inicio", "Menu");
            }

        }


        public JsonResult PruebaWS()
        {
            try
            {
                //WebMvc.Content.RestClient rest = new WebMvc.Content.RestClient();
                var client = new WebMvc.Content.RestClient();
                client.EndPoint = @"http://localhost:7715/PruebaRecibo";
                client.Method = HttpVerb.GET;
                //client.PostData = "{Reg: value}";
                var json = client.MakeRequest();

                //NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar ng = new NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar();

                //DataSet ds = ng.ConsultaTurno(idTurno);

                //Models.TurnoModels turno = new Models.TurnoModels();

                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    turno.Descripcion = row["Desc_TurnoOper"].ToString();
                //    turno.Abrev = row["Abrev_TurnoOper"].ToString();
                //    turno.Hentrada = row["HIni_TurnoOper"].ToString().Substring(0, 2) + ":" + row["HIni_TurnoOper"].ToString().Substring(2, 2);// row["HIni_TurnoOper"].ToString();
                //    turno.Hsalida = row["HFin_TurnoOper"].ToString().Substring(0, 2) + ":" + row["HFin_TurnoOper"].ToString().Substring(2, 2);//row["HFin_TurnoOper"].ToString();
                //    turno.Hcierre = row["HFin_CierreTurnoOper"].ToString().Substring(0, 2) + ":" + row["HFin_CierreTurnoOper"].ToString().Substring(2, 2);//row["HFin_CierreTurnoOper"].ToString();

                //}

                //return Json(json, JsonRequestBehavior.AllowGet);

                return Json(new { status = json}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData.Keep();
                return Json(new { status = "Error" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

      

    }
}