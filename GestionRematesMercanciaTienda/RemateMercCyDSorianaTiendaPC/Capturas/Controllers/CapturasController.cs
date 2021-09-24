
using EDReciboTiendaSoriana.Captura;
using NGReciboTiendaSoriana.Captura;
using Soriana.FWK.Common;
using Soriana.FWK.Datos.Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.Menu;

namespace ReciboTiendaPC.Capturas.Controllers
{
    public class CapturasController : Controller
    {
        NGRCapturaListItem ngCaptura = new NGRCapturaListItem();
        NGRCapturaMciaCaduca ngCapCat = new NGRCapturaMciaCaduca();
        
        // GET: User
        //[CheckSessionOut]
        public ActionResult Index()
        {
            //List<Soriana.Helper.Seguridad.EntityLayer.MenuModel> modelo = new List<Soriana.Helper.Seguridad.EntityLayer.MenuModel>();
            //iniciarComboBCliente();
            //iniciarComboBApartado();
            //iniciarComboUbicacionalm();
            //iniciarComboUbicaciontmueble();
            //iniciarComboUbicacionmueble();
            //modelo = CrearModelo(ListaPadres());
            //if (Request.QueryString["MessageTurno"] != null)

            //{
            //    if (Request.QueryString["MessageTurno"].ToString() == "1")
            //    {
            //        ViewBag.Error = "Operador actual no tiene turno asignado";
            //    }
            //}

            //return View(modelo);
            return View();
        }


        public ActionResult RevisionDevoluciones()
        { return View(); }
        public ActionResult RevisarFolios()
        { return View(); }
        public ActionResult EntregaDevoluciones()
        { return View(); }
        public ActionResult MantenimientoArtAutBodega()
        { return View(); }
        public ActionResult FacturasEnergéticos()
        { return View(); }


        public ActionResult RolesPorcentajes()
        {
            iniciarComboFmtoTienda();
            iniciarComboCategoria();
            iniciarComboPeriodicidad();
            iniciarComboTipoMcia();
            iniciarComboDiaSemana();
            return View("RolesPorcentajes");
        }
        public JsonResult GuardarCategoria(string categoria)
        {
            List<EDRConsultaCategoria> listitem = (List<EDRConsultaCategoria>)Newtonsoft.Json.JsonConvert.DeserializeObject(categoria,typeof(List<EDRConsultaCategoria>));
            Hashtable hasCat = new Hashtable();
            try
            {
                ngCapCat.GuardarCategoria(listitem);
                hasCat["result"] = "1";
            }
            catch (Exception ex)
            {
                hasCat["result"] = ex;
                throw ex;
            }   
            
            return Json(hasCat, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GuardarPorcPorCat(string porcentaje)
        {
            List<EDRConsultaPorcentaje> listitem = (List<EDRConsultaPorcentaje>)Newtonsoft.Json.JsonConvert.DeserializeObject(porcentaje, typeof(List<EDRConsultaPorcentaje>));
            ngCapCat.GuardarPorcPorCat(listitem);
            Hashtable hasCat = new Hashtable();
            hasCat["result"] = "Exito";
            return Json(hasCat, JsonRequestBehavior.AllowGet);

        }
        public JsonResult BorrarPorcPorCat(string porcentaje)
        {
            List<EDRConsultaPorcentaje> listitem = (List<EDRConsultaPorcentaje>)Newtonsoft.Json.JsonConvert.DeserializeObject(porcentaje, typeof(List<EDRConsultaPorcentaje>));
            EDRConsultaPorcentaje item = new EDRConsultaPorcentaje();
            item.FmtoTienda = listitem[0].FmtoTienda;
            item.TipoMcia = listitem[0].TipoMcia;
            item.Categoria = listitem[0].Categoria;
            item.DiaInicio = listitem[0].DiaInicio;
            item.DiaFin = listitem[0].DiaFin;
            item.RebajaVta = listitem[0].RebajaVta;
            item.RebajaMerma = listitem[0].RebajaMerma;

            ngCapCat.BorrarPorcPorCat(item);
            Hashtable hasCat = new Hashtable();
            hasCat["result"] = "Exito";
            return Json(hasCat, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerCategHistElminadas(string FmtoTienda, string TipoBusquedad, string TipoMcia)
        {
            return Json(ngCapCat.ObtenerCategHistElminadas(FmtoTienda, TipoBusquedad, TipoMcia), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerCategPorcentaje(string FmtoTienda, string Categoria)
        {
            string TipoBusquedad = "GP";
            return Json(ngCapCat.ObtenerCategPorcentaje(FmtoTienda, TipoBusquedad, Categoria), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPorcentajeHistorico(string FmtoTienda, string TipoMcia, string RolCapturaHist)
        {
            string TipoBusquedad = "HP";
            return Json(ngCapCat.ObtenerCategHistPorcentaje(FmtoTienda, TipoBusquedad, TipoMcia, RolCapturaHist), JsonRequestBehavior.AllowGet);

        }
        public JsonResult ObtenerCategorias(string FmtoTienda, string TipoMcia)
        {
            string TipoBusquedad = "GC";
            string Usuario = "283";
            return Json(ngCapCat.LlenadoGridCategorias(FmtoTienda, TipoBusquedad, TipoMcia, Usuario), JsonRequestBehavior.AllowGet);
        }

        private void iniciarComboFmtoTienda()
        {
            string UserID = "283";
            var dropdownVD = new SelectList(ngCaptura.ListFmtoTienda(UserID), "Id", "Descripcion");
            ViewData["Fmto_Tienda"] = dropdownVD;
        }
        private void iniciarComboCategoria()
        {
            string UserID = "283";
            var dropdownVD = new SelectList(ngCaptura.ListCategoria(UserID), "Id", "Descripcion");
            ViewData["ddlCategoriaFmoTienda"] = dropdownVD;
        }

        private void iniciarComboPeriodicidad()
        {
            var dropdownVD = new SelectList(ngCaptura.ListPeriodicidad(), "Id", "Descripcion");
            ViewData["ddlPeriodicidad"] = dropdownVD;
        }

        private void iniciarComboTipoMcia()
        {
            var dropdownVD = new SelectList(ngCaptura.ListTipoMcia(), "Id", "Descripcion");
            ViewData["ddlTipoMcia"] = dropdownVD;
        }

        private void iniciarComboDiaSemana()
        {
            var dropdownVD = new SelectList(ngCaptura.ListDiasSemana(), "Id", "Descripcion");
            ViewData["ddlDiaSemana"] = dropdownVD;
        }
        //#region CrearMenu
        //private List<Soriana.Helper.Seguridad.EntityLayer.Menu> ListaPadres()
        //{
        //    string cookie = string.Empty;
        //    if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //    {
        //        cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //    }

        //    var idUsuario = Helper.UsuarioId(cookie);
        //    var listPadres = Helper.GenerarMenu(idUsuario, "Apartados");

        //    return listPadres;
        //}

        //private List<Soriana.Helper.Seguridad.EntityLayer.MenuModel> CrearModelo(List<Soriana.Helper.Seguridad.EntityLayer.Menu> Padres)
        //{
        //    List<Soriana.Helper.Seguridad.EntityLayer.MenuModel> ListMenu = new List<Soriana.Helper.Seguridad.EntityLayer.MenuModel>();
        //    string cookie = string.Empty;
        //    if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //    {
        //        cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //    }

        //    var idUsuario = Helper.UsuarioId(cookie);
        //    foreach (var item in Padres)
        //    {
        //        Soriana.Helper.Seguridad.EntityLayer.MenuModel ObjMenu = new Soriana.Helper.Seguridad.EntityLayer.MenuModel();
        //        ObjMenu.MenuPadre = item;
        //        ObjMenu.MenuHijo = Helper.GenerarSubMenu(item.IdRecurso, idUsuario, "Apartados");
        //        ListMenu.Add(ObjMenu);
        //    }

        //    return ListMenu;

        //}

        //#endregion


        //public ActionResult Busqueda(string origen, string paramBusqueda, string valorBusqueda)
        //{
        //    if (valorBusqueda == "")
        //    {
        //        return View("Index");
        //    }
        //    else
        //    {
        //        switch (origen)
        //        {
        //            //Busqueda Apartado
        //            case "1":
        //                TempData["@srchApartadoParam"] = paramBusqueda;
        //                TempData["@srchApartadoVal"] = valorBusqueda;

        //                break;
        //            case "2":
        //                TempData["@opBusquedaCliente"] = paramBusqueda;
        //                TempData["@busquedaCliente"] = valorBusqueda;

        //                break;

        //            case "3":
        //                TempData["@srchUbicacionParamalm"] = paramBusqueda;
        //                TempData["@srchUbicacionValalm"] = valorBusqueda;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    //ACTION NAME , NOMBRE CARPETA
        //    return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult ValidacionEstadoCuenta()
        //{
        //    try
        //    {

        //        string message = "0";
        //        int Status = 0;


        //        Status = NGApartados.ValidacionEstadoCuenta();

        //        switch (Status)
        //        {

        //            case 1:
        //                message = "No se puede obtener estado de cuenta, hay apartados pendientes de ubicar";
        //                break;
        //            case 2:
        //                message = "No se puede obtener estado de cuenta, hay apartados pendientes de sacar a piso";
        //                break;
        //            case 12:
        //            case 123:
        //                message = "No se puede obtener estado de cuenta, hay apartados pendientes de ubicar y sacar a piso";
        //                break;

        //            case 0:
        //            case 3:
        //                message = "0";
        //                break;
        //            default:
        //                message = "¡Estatus [" + Status.ToString() + "] no es valido !";
        //                break;
        //        }

        //        return Json(new { Message = message }, JsonRequestBehavior.AllowGet);

        //    }

        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(500, ex.Message);
        //    }

        //}


        //private bool validaModelo2(string valorBusqueda, string paramBusqueda)
        //{
        //    if (string.IsNullOrEmpty(valorBusqueda))
        //    {
        //        ModelState.AddModelError("srchApartado", "Debe ingresar un dato a buscar");
        //    }
        //    if (string.IsNullOrEmpty(paramBusqueda))
        //    {
        //        ModelState.AddModelError("Abrev_TipoMueble", "Campo Requerido");
        //    }

        //    return ModelState.IsValid;
        //}


        //private void iniciarComboBCliente()
        //{
        //    var lista = new SelectList(
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "No. Cliente", Value = "1"},
        //        new SelectListItem { Text = "No. Cliente Frecuente", Value = "2"},
        //        new SelectListItem { Text = "Código Postal", Value = "3"},
        //        new SelectListItem { Text = "Nombre", Value = "4"},
        //        new SelectListItem { Text = "Teléfono", Value = "5"},
        //        new SelectListItem { Text = "Ap. Paterno", Value = "6"},
        //        new SelectListItem { Text = "Ap. Materno", Value = "7"},
        //    }, "Value", "Text", "5");
        //    var dropdownVD = lista;
        //    ViewData["ddlSrcCliente"] = dropdownVD;
        //}

        //private void iniciarComboBApartado()
        //{
        //    var lista = new SelectList(
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "No. Cliente", Value = "1"},
        //        new SelectListItem { Text = "No. Cliente Frecuente", Value = "2"},
        //        new SelectListItem { Text = "Código Postal", Value = "3"},
        //        new SelectListItem { Text = "Nombre", Value = "4"},
        //        new SelectListItem { Text = "Teléfono", Value = "5"},
        //        new SelectListItem { Text = "Ap. Paterno", Value = "6"},
        //        new SelectListItem { Text = "Ap. Materno", Value = "7"},
        //        new SelectListItem { Text = "Folio Apartado", Value = "8"},
        //    }, "Value", "Text", "8");
        //    var dropdownVD = lista;
        //    ViewData["ddlSrcApartado"] = dropdownVD;
        //}

        //private void iniciarComboUbicacionalm()
        //{
        //    var lista = new SelectList(
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "No. de Almacen", Value = "1"},
        //        new SelectListItem { Text = "Descripción", Value = "2"},
        //        new SelectListItem { Text = "Abreviación", Value = "3"},

        //    }, "Value", "Text", "5");
        //    var dropdownVD = lista;
        //    ViewData["ddlSrcUbicacionalm"] = dropdownVD;
        //}

        //private void iniciarComboUbicaciontmueble()
        //{
        //    var lista = new SelectList(
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "No. Tipo de Mueble", Value = "1"},
        //        new SelectListItem { Text = "Tipo de Muebles", Value = "2"},
        //        new SelectListItem { Text = "Lados", Value = "3"},
        //        new SelectListItem { Text = "Tramos", Value = "4"},
        //        new SelectListItem { Text = "Niveles", Value = "5"},

        //    }, "Value", "Text", "5");
        //    var dropdownVD = lista;
        //    ViewData["ddlSrcUbicaciontmueble"] = dropdownVD;
        //}

        //private void iniciarComboUbicacionmueble()
        //{
        //    var lista = new SelectList(
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "No. de Mueble", Value = "1"},
        //        new SelectListItem { Text = "Descripción", Value = "2"},
        //        new SelectListItem { Text = "Tipo de Mueble", Value = "3"},
        //        new SelectListItem { Text = "Lado", Value = "4"},
        //        new SelectListItem { Text = "Tramo", Value = "5"},
        //        new SelectListItem { Text = "Nivel", Value = "6"},

        //    }, "Value", "Text", "5");
        //    var dropdownVD = lista;
        //    ViewData["ddlSrcUbicacionmueble"] = dropdownVD;
        //}

        ////public JsonResult validaPermiosBotones(string nombreBoton)
        ////{
        ////    try
        ////    {
        ////        string nombreRecurso = "Apartado";
        ////        string cookie = string.Empty;
        ////        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        ////        {
        ////            cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        ////        }

        ////        if (string.IsNullOrEmpty(cookie))
        ////        {
        ////            string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        ////            var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }

        ////        if (Helper.ObtenerPermisosRecursoPorUsuario(nombreRecurso, nombreBoton, cookie))
        ////        {
        ////            var result = new { Success = true, Message = "OK", urlRedirect = "" };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }
        ////        else
        ////        {
        ////            var result = new { Success = true, Message = "NO", urlRedirect = "" };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        var result = new { Success = false, Message = ex.Message, urlRedirect = "" };
        ////        return Json(result, JsonRequestBehavior.AllowGet);
        ////    }

        ////}

        ////public JsonResult PermisoAccion(string usuario, string password, string nombreBoton)
        ////{
        ////    try
        ////    {

        ////        string nombreRecurso = "Apartado";
        ////        #region Valida Coockie
        ////        string cookie = string.Empty;
        ////        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        ////        {
        ////            cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        ////        }

        ////        if (string.IsNullOrEmpty(cookie))
        ////        {
        ////            string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        ////            var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }


        ////        #endregion


        ////        if (Helper.ValidarUsuarioRecurso(usuario, password, nombreRecurso, nombreBoton))
        ////        {
        ////            var result = new { Success = true, Message = "OK", urlRedirect = "" };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }
        ////        else
        ////        {
        ////            var result = new { Success = true, Message = "NO", urlRedirect = "" };
        ////            return Json(result, JsonRequestBehavior.AllowGet);
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        var result = new { Success = false, Message = ex.Message, urlRedirect = "" };
        ////        return Json(result, JsonRequestBehavior.AllowGet);
        ////    }

        ////}

        //public JsonResult validaPermiosBotones(string nombreBoton)
        //{
        //    try
        //    {
        //        string nombreRecurso = "Apartado";
        //        string cookie = string.Empty;
        //        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //        {
        //            cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //        }

        //        if (string.IsNullOrEmpty(cookie))
        //        {
        //            string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        //            var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }

        //        if (Helper.ObtenerPermisosRecursoPorUsuario(nombreRecurso, nombreBoton, cookie))
        //        {
        //            Session["@usuaioAutoriza"] = Helper.UsuarioId(cookie).ToString();
        //            var result = new { Success = true, Message = "OK", urlRedirect = "" };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            var result = new { Success = true, Message = "NO", urlRedirect = "" };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new { Success = false, Message = ex.Message, urlRedirect = "" };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //public JsonResult PermisoAccion(string usuario, string password, string nombreBoton)
        //{
        //    try
        //    {

        //        string nombreRecurso = "Apartado";
        //        #region Valida Coockie
        //        string cookie = string.Empty;
        //        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //        {
        //            cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //        }

        //        if (string.IsNullOrEmpty(cookie))
        //        {
        //            string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        //            var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }


        //        #endregion


        //        if (Helper.ValidarUsuarioRecurso(usuario, password, nombreRecurso, nombreBoton))
        //        {
        //            string idAutorizo = Helper.UsuarioIdXUser(usuario).ToString();
        //            Session["@usuaioAutoriza"] = idAutorizo;
        //            var result = new { Success = true, Message = "OK", urlRedirect = "", autorizado = idAutorizo };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            var result = new { Success = true, Message = "NO", urlRedirect = "", autorizado = "0" };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new { Success = false, Message = ex.Message, urlRedirect = "", autorizado = "" };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //public ActionResult logOut()
        //{
        //    try
        //    {
        //        #region Valida Coockie
        //        string cookie2 = string.Empty;
        //        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //        {
        //            cookie2 = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //        }

        //        if (string.IsNullOrEmpty(cookie2))
        //        {
        //            string srvName2 = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        //            var result = new { Success = true, Message = "OFF", urlRedirect = srvName2 };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        int Id_Usuario = 0;
        //        string nombreUsuario = ""
        //            , perfiles = "";
        //        Helper.ObtieneNombrePerfilesUsuario(cookie2, ref nombreUsuario, ref perfiles, ref Id_Usuario);

        //        #endregion
        //        string UserId_Cierre = null;
        //        int ReturnCode = 0;
        //        int Id_Num_StatusOper = 3;

        //        NGReportes.OperStatusUpd(Id_Usuario, UserId_Cierre, ReturnCode, Id_Num_StatusOper);


        //        string[] myCookies = Request.Cookies.AllKeys;
        //        foreach (string cookie in myCookies)
        //        {
        //            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        //        }
        //        string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "Login";
        //        return new RedirectResult(srvName); ;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public JsonResult UsuarioPerfiles()
        //{
        //    try
        //    {
        //        int Id_Usuario = 0;
        //        string nombreUsuario = ""
        //            , perfiles = "";
        //        string cookie = string.Empty;
        //        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
        //        {
        //            cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
        //        }

        //        if (string.IsNullOrEmpty(cookie))
        //        {
        //            string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
        //            var result = new { Success = true, Message = "NO", urlRedirect = srvName, Usuario = "", Perfiles = "", MisApps = "" };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            Helper.ObtieneNombrePerfilesUsuario(cookie, ref nombreUsuario, ref perfiles, ref Id_Usuario);
        //            var misApps = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "Login/login/menu_principal";
        //            var result = new { Success = true, Message = "OK", urlRedirect = "", Usuario = nombreUsuario, Perfiles = perfiles, MisApps = misApps };
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new { Success = false, Message = ex.Message, urlRedirect = "", Usuario = "", Perfiles = "", MisApps = "" };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}