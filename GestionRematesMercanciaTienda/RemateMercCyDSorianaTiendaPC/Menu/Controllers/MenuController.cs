using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using Soriana.FWK.Common;
using Soriana.FWK.Datos.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.Menu;
using oHelperEncriptar = Soriana.FWK.Seguridad.HelperEncriptar;
using System.Data;

namespace ReciboTiendaPC.Menu.Controllers
{
    public class MenuController : Controller
    {
        // GET: User
        [CheckSessionOut]
        public ActionResult Index()
        {
            try
            {
                List<Soriana.FWK.Common.MenuModels> list = new List<Soriana.FWK.Common.MenuModels>();

                list = Soriana.FWK.Common.Helper.GetMenuBySystemId(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim(), System.Web.HttpContext.Current.Session["SystemId"].ToString().Trim());

                ViewBag.listMenu = list;
            }
            catch (Exception ex)
            {

                ViewBag.Error=ex.Message;
            }
            return View();
        }
        //[AuthorizationPrivilegeFilter]
        //public JsonResult validaPermiosBotones(string nombreBoton)
        //{
        //    try
        //    {
        //        string nombreRecurso = "Talones";
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
        //            Session["@usuaioAutoriza"] = System.Web.HttpContext.Current.Session["SystemUserId"].ToString();  //Helper.UsuarioId(cookie).ToString();
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
        //[AuthorizationPrivilegeFilter]
        //public JsonResult PermisoAccion(string usuario, string password, string nombreBoton)
        //{
        //    try
        //    {

        //        string nombreRecurso = "Talones";
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
        //[AuthorizationPrivilegeFilter]
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
        //[AuthorizationPrivilegeFilter]
        //public ActionResult logOut()
        //{
        //    try
        //    {

        //        this.ControllerContext = Helper.LogOutSistema(this.ControllerContext);


        //        return new RedirectResult(ConfigurationManager.AppSettings["srvrName"].ToString() + ConfigurationManager.AppSettings["Login"].ToString());

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #region redirccion


        public class TransaccionPC
        {
            public int IdSistema { get; set; }
            public string NombreSistema { get; set; }
            public string url { get; set; }
        }
        [AuthorizationPrivilegeFilter]
        public ActionResult RedirectOption(string option)
        {
       

            try
            {
                string variable = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
                sqlHelper.connection_Name(variable);
                DataSet dts = new DataSet();

                int pIdUsuario = int.Parse(System.Web.HttpContext.Current.Session["SystemUserId"].ToString().Trim());
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@pIdUsuario", pIdUsuario);
                parametros.Add("@pOpcion", option);

                dts = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_fmk_ValidaTransaccionPC", false, parametros);


                TransaccionPC item = new TransaccionPC();

                foreach (System.Data.DataTable table in dts.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item.IdSistema = int.Parse(dr["IdSistema"].ToString());
                        item.NombreSistema = (dr["NombreSistema"].ToString());
                        item.url = (dr["url"].ToString());
                    }
                }


                string srvName = ConfigurationManager.AppSettings["srvrName"].ToString() + item.NombreSistema;
                var result = new { Success = true, datos = item, Message = "OK" };
                if (item.IdSistema == 0)
                {

                    result = new { Success = false, datos = item, Message = "Transaccion invalida o usted no tiene acceso!!!" };
                }
                else
                {
                    this.ControllerContext.HttpContext.Response.Cookies.Clear();

                    HttpCookie cookie = new HttpCookie("CookieLogin");

                    cookie["Created"] = DateTime.Now.ToShortTimeString();
                    cookie["UserId"] = Request.Cookies["CookieLogin"]["UserId"];
                    cookie["User"] = Request.Cookies["CookieLogin"]["User"];
                    cookie["Pass"] = Request.Cookies["CookieLogin"]["Pass"];
                    cookie["IdSistema"] = item.IdSistema.ToString();


                    cookie.Expires = DateTime.Now.AddHours(8);
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    item.url = srvName + item.url;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var result = new { Success = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion

        #region seguridad
        [AuthorizationPrivilegeFilter]
        public JsonResult validaPermiosBotones(string nombreBoton)
        {
            try
            {
                string nombreRecurso = "DataPrice";
                string cookie = string.Empty;
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
                }

                if (string.IsNullOrEmpty(cookie))
                {
                    string srvName = ConfigurationManager.AppSettings["srvrName"].ToString() + "login";
                    var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                if (Helper.ObtenerPermisosRecursoPorUsuario(nombreRecurso, nombreBoton, Convert.ToInt32(System.Web.HttpContext.Current.Session["SystemUserId"])))
                {
                    Session["@usuaioAutoriza"] = System.Web.HttpContext.Current.Session["SystemUserId"].ToString(); //Helper.UsuarioId(cookie).ToString();
                    var result = new { Success = true, Message = "OK", urlRedirect = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new { Success = true, Message = "NO", urlRedirect = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message, urlRedirect = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [AuthorizationPrivilegeFilter]
        public JsonResult PermisoAccion(string usuario, string password, string nombreBoton)
        {
            try
            {

                string nombreRecurso = "Talones";
                #region Valida Coockie
                string cookie = string.Empty;

                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
                }

                if (string.IsNullOrEmpty(cookie))
                {
                    string srvName = HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
                    var result = new { Success = true, Message = "OFF", urlRedirect = srvName };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }


                #endregion


                if (Helper.ValidarUsuarioRecurso(usuario, password, nombreRecurso, nombreBoton))
                {
                    string idAutorizo = Helper.UsuarioIdXUser(usuario).ToString();
                    Session["@usuaioAutoriza"] = idAutorizo;
                    var result = new { Success = true, Message = "OK", urlRedirect = "", autorizado = idAutorizo };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new { Success = true, Message = "NO", urlRedirect = "", autorizado = "0" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var result = new { Success = false, Message = ex.Message, urlRedirect = "", autorizado = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult logOut()
        {
            try
            {
                //this.ControllerContext = Helper.LogOutSistema(this.ControllerContext);

                string idsistema = System.Web.HttpContext.Current.Session["SystemId"] != null ? System.Web.HttpContext.Current.Session["SystemId"].ToString() : "0";
                string idUsuario = System.Web.HttpContext.Current.Session["SystemUserId"] != null ? System.Web.HttpContext.Current.Session["SystemUserId"].ToString() : "0";
                string user = System.Web.HttpContext.Current.Session["SystemUser"] != null ? System.Web.HttpContext.Current.Session["SystemUser"].ToString() : string.Empty;
                string pass = System.Web.HttpContext.Current.Session["UserPass"] != null ? HelperEncriptar.Desencriptar(System.Web.HttpContext.Current.Session["UserPass"].ToString()) : string.Empty;


                string[] myCookies = this.ControllerContext.RequestContext.HttpContext.Request.Cookies.AllKeys;
                foreach (string cookie in myCookies)
                {
                    this.ControllerContext.RequestContext.HttpContext.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }

                this.ControllerContext.RequestContext.HttpContext.Response.Cookies.Clear();
                this.ControllerContext.RequestContext.HttpContext.Request.Cookies.Clear();

                HttpCookie cook = new HttpCookie("CookieLogOut");
                //cookie.Value = "Created:" + DateTime.Now.ToShortTimeString() + "," + "UserId:" + usuarioId + "," + "User:" + user;

                cook["Created"] = DateTime.Now.ToShortTimeString();
                cook["UserId"] = idUsuario;
                cook["User"] = user;
                cook["Pass"] = pass;
                cook["IdSistema"] = idsistema;

                cook.Expires = DateTime.Now.AddHours(8);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cook);

                return new RedirectResult(ConfigurationManager.AppSettings["srvrName"].ToString() + ConfigurationManager.AppSettings["Login"].ToString());
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public void UsuarioPerfiles()
        {
            try
            {
                int Id_Usuario = 0;
                string nombreUsuario = ""
                    , perfiles = "";
                string cookie = string.Empty;
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLogin"].Value;
                }

                //cookie = "Created=1:23 PM&UserId=5006&User=dABfAG8AYwB0AGEAdgBpAG8AbQByAA==&Pass=TwBjAHQAQAB2AGkAbwA4ADQA&IdSistema=3";

                if (string.IsNullOrEmpty(cookie))
                {
                    string srvName = oHelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "login";
                    //var result = new { Success = true, Message = "NO", urlRedirect = srvName, Usuario = "USER NAME", Perfiles = "PROFILE", MisApps = "" };
                    TempData["sNombre"] = "USER NAME";
                    TempData["Profile"] = "PROFILE";
                }
                else
                {
                    Helper.ObtieneNombrePerfilesUsuario(cookie, ref nombreUsuario, ref perfiles, ref Id_Usuario);
                    var misApps = oHelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["srvrName"].ToString()) + "Login/login/menu_principal";
                    //var result = new { Success = true, Message = "OK", urlRedirect = "", Usuario = nombreUsuario, Perfiles = perfiles, MisApps = misApps };
                    TempData["sNombre"] = nombreUsuario;
                    TempData["Profile"] = perfiles;
                }
            }
            catch (Exception ex)
            {
                //var result = new { Success = false, Message = ex.Message, urlRedirect = "", Usuario = "", Perfiles = "", MisApps = "" };
                //TempData["ErrorLogin"] = "Error Login = " + ex.Message + " " + ex.StackTrace;
            }
        }
        #endregion
    }
}