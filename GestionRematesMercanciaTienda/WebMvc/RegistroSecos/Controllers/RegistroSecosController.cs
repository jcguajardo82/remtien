using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.RegistroSecos.Controllers
{
    public class RegistroSecosController : Controller
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    int verifiador = -1;

        //    return View();
        //}

        //NGReciboTiendaSoriana.NGRegistroSecos.NGRegistroSecos ng = new NGReciboTiendaSoriana.NGRegistroSecos.NGRegistroSecos();
        //NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar terminal = new NGReciboTiendaSoriana.NGAuditoriaGuia.NGConfigGuiaAuditar();



        //public ActionResult ArriboTransportista(string input_CODDOC, string input_NUMCEDIS, string lbl_NUMEMBARQUE, string optionSelected)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(optionSelected))
        //        {
        //            if (optionSelected == "1")
        //            {
        //                string algo2 = TempData["CedisSecos"].ToString();
        //                string algo = TempData["CedisPerec"].ToString();

        //                if (TempData["CedisSecos"].ToString() == "1")
        //                {
        //                    string result = ng.ActualizaArribo(Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToInt32(TempData["GuiaEmb"]), Convert.ToInt16(TempData["TerminalId"]));
        //                    if (result.Contains("Error"))
        //                    {
        //                        TempData["lblResult"] = result;

        //                    }
        //                    else if (result == "-1")
        //                    {
        //                        //TempData["lblResult"] = "Arribo OK";
        //                        TempData.Clear();

        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult"] = result;
        //                    }
        //                }
        //                else if (TempData["CedisPerec"].ToString() == "1")
        //                {
        //                    string result = ng.ActualizaArriboPrece(Convert.ToInt32(TempData["input_NUMCEDIS"]), Convert.ToInt32(TempData["GuiaEmb"]));
        //                    if (result.Contains("Error"))
        //                    {
        //                        TempData["lblResult"] = result;
        //                    }
        //                    else if (result == "-1")
        //                    {
        //                        //TempData["lblResult"] = "Arribo OK";
        //                        TempData.Clear();
        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult"] = result;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                TempData.Clear();

        //                EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //                TempData["UserId"] = u.userId;
        //                TempData["Cve"] = u.Cve_Habilitado;
        //                TempData["HostName"] = t.HostName;
        //                TempData["TerminalId"] = t.NumTerminal;
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_NUMCEDIS))
        //        {
        //            string cedis = ng.ValidarCedis(Convert.ToInt16(input_NUMCEDIS));
        //            String[] substrings = cedis.Split(',');

        //            TempData["input_NUMCEDIS"] = input_NUMCEDIS;
        //            TempData["lbl_CEDIS"] = substrings[1].Split(':').Last();
        //            TempData["CedisSecos"] = substrings[6].Split(':').Last();
        //            TempData["CedisPerec"] = substrings[7].Split(':').Last();

        //            if (!string.IsNullOrEmpty(lbl_NUMEMBARQUE))
        //            {
        //                string resultado = ng.PrevioArribo(Convert.ToInt16(input_NUMCEDIS), Convert.ToInt32(lbl_NUMEMBARQUE), Convert.ToByte(TempData["CedisSecos"]), Convert.ToByte(TempData["CedisPerec"]));
        //                String[] substringResultado = resultado.Split(',');

        //                TempData["lbl_NUMEMBARQUE"] = lbl_NUMEMBARQUE;

        //                TempData["Leyenda01"] = substringResultado[1].Split(';').Last();
        //                TempData["lbl_FECLLEGADA"] = substringResultado[2].Split(';').Last();
        //                TempData["Leyenda03"] = substringResultado[3].Split(';').Last();
        //                TempData["lbl_STATUS"] = substringResultado[4].Split(';').Last();
        //                TempData["PermGrabar"] = substringResultado[6].Split(';').Last();
        //                TempData["GuiaEmb"] = substringResultado[7].Split(';').Last();
        //            }


        //        }
        //        else if (!string.IsNullOrEmpty(input_CODDOC))
        //        {
        //            //EDReciboTiendaSoriana.EDRegistroSecos.Documento docto = ng.ArriboTransportistaConCodigo(input_CODDOC);

        //            //TempData["input_NUMCEDIS"] = docto.NumCedis;
        //            //TempData["lbl_CEDIS"] = docto.DescCedis;
        //            //TempData["lbl_NUMEMBARQUE"] = docto.FolEmb;
        //            //TempData["lbl_FECLLEGADA"] = docto.FecLlegada;
        //            //TempData["lbl_STATUS"] = docto.Status;
        //            //TempData["GuiaEmb"] = docto.GuiaEmb;

        //            string documento = ng.ArriboTpaConCodigo(input_CODDOC);

        //            if (documento.Contains("Error"))
        //            {
        //                TempData["lblResult"] = documento;
        //            }
        //            else if (documento.Contains(','))
        //            {
        //                String[] substrings = documento.Split(',');

        //                TempData["input_NUMCEDIS"] = substrings[1].Split(':').Last();
        //                TempData["lbl_CEDIS"] = substrings[2].Split(':').Last();
        //                TempData["lbl_NUMEMBARQUE"] = substrings[3].Split(':').Last();
        //                TempData["input_CODDOC"] = input_CODDOC;

        //                //TempData["flagConfirmacion"] = "Y";
        //            }
        //            else
        //            {
        //                TempData["lblResult"] = documento;
        //            }

        //        }
        //        else
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;
        //        }


        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["lblResult"] = ex.Message;
        //        return View();
        //    }
        //}

        //public ActionResult ControlMarchamos(string input_CEDIS, string input_GUIA, string input_VIENE, string input_MARCHAMO, string input_ESTATUS, string input_RECIBOMARCHAMO, string input_INCIDENCIA, string optionSelected, string optionSelected2, string optionSelected3, string optionSelected4)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(optionSelected))
        //        {
        //            if (optionSelected == "1")
        //            {
        //                string pistola = ng.RegPistola(Convert.ToByte(TempData["TerminalId"]), Convert.ToInt16(TempData["UserId"]), "I");

        //                string result = ng.ValidaGuiaMarchamo(Convert.ToInt16(input_CEDIS), Convert.ToInt32(input_GUIA), Convert.ToInt16(input_VIENE), Convert.ToByte(TempData["TerminalId"]));

        //                if (result.Contains("Error") || result.Contains("Guia") || result.Contains("Sucursal"))
        //                {
        //                    TempData["lblResult"] = result;
        //                }
        //                else if (result.Contains(','))
        //                {
        //                    TempData["flagMarchamo"] = "ModalMarchamo";
        //                    //TempData["IdNumOrigen"] = result;
        //                    String[] substrings = result.Split(',');

        //                    TempData["IdNumOrigen"] = substrings[0];
        //                    TempData["idFolEmb"] = substrings[1];
        //                    TempData["BitIncidManual"] = substrings[2];
        //                    TempData["NumCedis"] = input_CEDIS;
        //                    TempData["FolioGuia"] = input_GUIA;
        //                }
        //                else
        //                {
        //                    TempData["lblResult"] = result;
        //                }
        //            }
        //            else
        //            {
        //                TempData.Clear();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                TempData["UserId"] = u.userId;
        //                TempData["Cve"] = u.Cve_Habilitado;
        //                TempData["HostName"] = t.HostName;
        //                TempData["TerminalId"] = t.NumTerminal;
        //                TempData["flagMarchamo"] = "Principal";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected3))
        //        {
        //            if (optionSelected3 == "1")
        //            {
        //                int IncidMarchamos;
        //                int IncidTdasAnt;
        //                if (input_RECIBOMARCHAMO == "1")
        //                {
        //                    IncidMarchamos = 0;
        //                }
        //                else
        //                {
        //                    IncidMarchamos = 1;
        //                }

        //                if (input_INCIDENCIA == "1")
        //                {
        //                    IncidTdasAnt = 1;
        //                }
        //                else
        //                {
        //                    IncidTdasAnt = 0;
        //                }

        //                string result = ng.ResumenMarchamo(Convert.ToInt16(TempData["IdNumOrigen"]), Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt32(TempData["idFolEmb"]), IncidMarchamos, IncidTdasAnt);

        //                if (result.Contains("Error"))
        //                {
        //                    TempData["lblResult3"] = result;
        //                }
        //                else if (result.Contains(','))
        //                {
        //                    String[] substrings = result.Split(',');

        //                    TempData["lbl_RECIBIDOS"] = substrings[1].Split(';').Last();
        //                    TempData["lbl_OK"] = substrings[3].Split(';').Last();
        //                    TempData["lbl_VIOLADOS"] = substrings[4].Split(';').Last();
        //                    TempData["lbl_RESUMEN"] = substrings[9].Split(';').Last();
        //                    TempData["lbl_MARCHAMOSRESUMEN"] = substrings[10].Split(';').Last();
        //                    TempData["flagMarchamo"] = "ModalResumen";
        //                }
        //                else
        //                {
        //                    TempData["lblResult3"] = result;
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMarchamo"] = "ModalConfirmacion";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected4))
        //        {
        //            if (optionSelected4 == "1")
        //            {
        //                string result = ng.FinalizarCapturaMarchamo(Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt32(TempData["idFolEmb"]), Convert.ToInt16(TempData["NumCedis"]));
        //                if (result.Contains("Error"))
        //                {
        //                    TempData["lblResult4"] = result;
        //                }
        //                else if (result == "-1")
        //                {
        //                    //TempData["lblResult4"] = "OK";
        //                    TempData.Clear();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                    TempData["UserId"] = u.userId;
        //                    TempData["Cve"] = u.Cve_Habilitado;
        //                    TempData["HostName"] = t.HostName;
        //                    TempData["TerminalId"] = t.NumTerminal;
        //                    TempData["flagMarchamo"] = "Principal";
        //                }
        //                else
        //                {
        //                    TempData["lblResult4"] = result;
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMarchamo"] = "ModalMarchamo";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_MARCHAMO))
        //        {
        //            if (string.IsNullOrEmpty(optionSelected2))
        //            {
        //                string result = ng.ValidaMarchamoCapturado(Convert.ToInt16(TempData["NumCedis"]), Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt16(TempData["IdNumOrigen"]), input_MARCHAMO);

        //                if (result.Contains("Error"))
        //                {
        //                    TempData["lblResult2"] = result;
        //                }
        //                else if (result.Contains(','))
        //                {
        //                    String[] substrings = result.Split(',');

        //                    TempData["CveMarchamo"] = substrings[0].Split(':').Last();
        //                    TempData["IndicaMarchEnv"] = substrings[2].Split(':').Last();
        //                    if (substrings[1].Split(':').Last() != "0")
        //                    {
        //                        TempData["StatusMarchamo"] = substrings[1].Split(':').Last();
        //                    }

        //                }
        //                else
        //                {
        //                    TempData["lblResult2"] = result;
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(optionSelected2))
        //            {
        //                if (optionSelected2 != "3")
        //                {
        //                    Byte estatusMarchamo;
        //                    if (input_ESTATUS == "2")
        //                    {
        //                        estatusMarchamo = 3;
        //                    }
        //                    else
        //                    {
        //                        estatusMarchamo = 1;
        //                    }

        //                    string result = ng.UpdMarchamo(Convert.ToInt16(TempData["IdNumOrigen"]), Convert.ToInt32(TempData["idFolEmb"]), input_MARCHAMO, estatusMarchamo, optionSelected2, Convert.ToByte(TempData["IndicaMarchEnv"]));

        //                    if (result.Contains("Error"))
        //                    {
        //                        TempData["lblResult2"] = result;
        //                    }
        //                    else
        //                    {
        //                        TempData["CveMarchamo"] = "";
        //                        TempData["StatusMarchamo"] = "";
        //                    }
        //                }
        //                else
        //                {
        //                    TempData.Clear();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                    TempData["UserId"] = u.userId;
        //                    TempData["Cve"] = u.Cve_Habilitado;
        //                    TempData["HostName"] = t.HostName;
        //                    TempData["TerminalId"] = t.NumTerminal;
        //                    TempData["flagMarchamo"] = "Principal";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TempData.Clear();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;
        //            TempData["flagMarchamo"] = "Principal";

        //        }

        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData.Clear();

        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["lblResult"] = ex.Message;

        //        return View();
        //    }
        //}

        //public ActionResult ConfirmaTarima(string input_NUMCEDIS, string input_GUIA, string optionSelected, string input_TARIMA, string cmb_ESTADO, string optionSelected2, string optionSelected3, string optionSelected4)
        //{
        //    try
        //    {
        //        TempData["cmb_ESTADO"] = new System.Collections.Hashtable();

        //        if (!string.IsNullOrEmpty(input_TARIMA))
        //        {
        //            if (!string.IsNullOrEmpty(optionSelected2))
        //            {
        //                if (optionSelected2 == "1")
        //                {
        //                    string res = ng.InsertaTarima(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), TempData["input_TARIMA"].ToString(), Convert.ToByte(cmb_ESTADO), Convert.ToByte(TempData["BitAurditar"]), Convert.ToByte(TempData["TerminalId"]));
        //                    if (res.Contains("Error") || res.Contains("Guia") || res.Contains("Tarima") || res.Contains("Timeout"))
        //                    {
        //                        TempData["lblResult2"] = res;
        //                    }
        //                    else
        //                    {
        //                        #region Recalculo de env y con - ValidadGuia
        //                        string recalculo = ng.ValidaGuiaV02(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]), 1, null);

        //                        String[] substringsRecalculo = recalculo.Split(',');
        //                        TempData["lbl_ENV"] = substringsRecalculo[0].Split(':').Last();
        //                        TempData["lbl_CONF"] = substringsRecalculo[1].Split(':').Last();
        //                        #endregion

        //                        TempData["cmb_ESTADO"] = ng.ComboEstadoTarima();

        //                        TempData["input_TARIMA"] = "";
        //                        TempData["lbl_Leyenda01"] = "";
        //                        TempData["lbl_Leyenda02"] = "";
        //                        TempData["lbl_Leyenda03"] = "";
        //                        TempData["lbl_Leyenda04"] = "";
        //                        TempData["flagTarima"] = "Confirma";
        //                    }
        //                }
        //                else
        //                {
        //                    TempData["flagTarima"] = "Confirma";
        //                    TempData["input_TARIMA"] = "";
        //                    TempData["lbl_Leyenda01"] = "";
        //                    TempData["lbl_Leyenda02"] = "";
        //                    TempData["lbl_Leyenda03"] = "";
        //                    TempData["lbl_Leyenda04"] = "";
        //                }
        //            }
        //            else
        //            {
        //                string result = ng.ValidaTarima(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]), input_TARIMA, 1);
        //                TempData["cmb_ESTADO"] = ng.ComboEstadoTarima();

        //                if (result.Contains(','))
        //                {
        //                    String[] substrings = result.Split(',');
        //                    TempData["input_TARIMA"] = input_TARIMA;
        //                    TempData["lbl_Leyenda01"] = substrings[0].Split(':').Last();
        //                    TempData["lbl_Leyenda02"] = substrings[1].Split(':').Last();
        //                    TempData["lbl_Leyenda03"] = substrings[2].Split(':').Last();
        //                    TempData["lbl_Leyenda04"] = substrings[3].Split(':').Last();
        //                    TempData["BitAurditar"] = substrings[10].Split(':').Last();
        //                    TempData["CantidadConfirmada"] = substrings[0].Split(':').Last();
        //                }
        //                else if (result.Contains("Error") || result.Contains("Guia") || result.Contains("Tarima"))
        //                {
        //                    TempData["lblResult"] = result;
        //                }
        //                else
        //                {
        //                    TempData["lblResult"] = result;
        //                }
        //            }


        //        }

        //        else if (!string.IsNullOrEmpty(optionSelected3))
        //        {
        //            if (optionSelected3 == "1")
        //            {
        //                int Cantidad = Convert.ToInt32(ng.CalcularFaltanteGuia(Convert.ToInt32(TempData["lbl_ENV"]), Convert.ToInt32(TempData["lbl_CONF"])));

        //                if (Cantidad > 0)
        //                {
        //                    TempData["flagTarima"] = "Resumen";
        //                    TempData["QtaFaltante"] = Cantidad;
        //                }
        //                else
        //                {
        //                    string result = ng.CierraTarima(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]));
        //                    if (result != "-1")
        //                    {
        //                        //TempData["lblResult3"] = result;
        //                        TempData.Clear();
        //                        TempData["flagTarima"] = "Principal";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                TempData.Clear();
        //                TempData["flagTarima"] = "Principal";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected4))
        //        {
        //            if (optionSelected4 == "1")
        //            {
        //                int validaAutorizacion = ng.ValidaAutorizacion();
        //                if (validaAutorizacion == 0)
        //                {
        //                    string result = ng.CierraTarima(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]));
        //                    if (result != "-1")
        //                    {
        //                        TempData["lblResult3"] = result;
        //                    }
        //                    else
        //                    {
        //                        TempData.Clear();
        //                        TempData["flagTarima"] = "Principal";
        //                    }
        //                }
        //                else
        //                {
        //                    string login = ng.LoginAutoriza(TempData["CveLote"].ToString());
        //                    if (login.Contains(','))
        //                    {
        //                        String[] substringslogin = login.Split(',');
        //                        if (substringslogin[0].Split(':').Last() == "1")
        //                        {
        //                            string cierra = ng.CierraTarima(Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]));
        //                            if (cierra != "-1")
        //                            {
        //                                TempData["lblResult3"] = cierra;
        //                            }
        //                            else
        //                            {
        //                                TempData.Clear();
        //                                TempData["flagTarima"] = "Principal";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            TempData["flagTarima"] = "Resumen";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult3"] = login;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagTarima"] = "Confirma";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_NUMCEDIS))
        //        {

        //            string DesCedis = ng.NombreCedis(Convert.ToInt32(input_NUMCEDIS));
        //            if (DesCedis.Contains("Error"))
        //            {
        //                TempData["lblResult"] = DesCedis;
        //            }
        //            else if (DesCedis.Contains(','))
        //            {
        //                String[] substringsDesCedis = DesCedis.Split(',');

        //                TempData["lbl_CEDIS"] = substringsDesCedis[0].Split(':').Last();
        //                TempData["input_NUMCEDIS"] = input_NUMCEDIS;

        //                TempData["CveLote"] = substringsDesCedis[1].Split(':').Last();
        //            }
        //            else
        //            {
        //                TempData["lblResult"] = DesCedis;
        //            }

        //            if (!string.IsNullOrEmpty(optionSelected))
        //            {
        //                if (optionSelected == "1")
        //                {
        //                    string pistola = ng.RegPistola(Convert.ToByte(TempData["TerminalId"]), Convert.ToInt16(TempData["UserId"]), "I");
        //                    string result = ng.ValidaGuiaV02(Convert.ToInt32(input_GUIA), Convert.ToInt16(TempData["input_NUMCEDIS"]), Convert.ToByte(TempData["TerminalId"]), 1, null);

        //                    if (result.Contains("Error") || result.Contains("Guia") || result.Contains("Tarima"))
        //                    {
        //                        TempData["lblResult"] = result;
        //                    }
        //                    else
        //                    {
        //                        String[] substrings = result.Split(',');
        //                        TempData["lbl_ENV"] = substrings[0].Split(':').Last();
        //                        TempData["lbl_CONF"] = substrings[1].Split(':').Last();
        //                        TempData["flagTarima"] = "Confirma";

        //                        TempData["input_GUIA"] = input_GUIA;
        //                        TempData["cmb_ESTADO"] = ng.ComboEstadoTarima();
        //                    }

        //                }
        //                else
        //                {
        //                    TempData.Clear();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                    TempData["UserId"] = u.userId;
        //                    TempData["Cve"] = u.Cve_Habilitado;
        //                    TempData["HostName"] = t.HostName;
        //                    TempData["TerminalId"] = t.NumTerminal;
        //                    TempData["flagTarima"] = "Principal";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;
        //            TempData["flagTarima"] = "Principal";

        //        }
        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["cmb_ESTADO"] = ng.ComboEstadoTarima();
        //        TempData["lblResult"] = ex.Message;


        //        return View();
        //    }
        //}

        //public ActionResult RegistroMercanciaIncidencia(string input_CEDIS, string input_GUIA, string optionSelected, string input_CODIGO, string optionSelected2, string input_DANADA, string cmb_ESTADOBULTO, string cmb_MOTIVO, string optionSelected3)
        //{
        //    try
        //    {
        //        TempData["cmb_ESTADOBULTO"] = new System.Collections.Hashtable();
        //        TempData["cmb_MOTIVO"] = new System.Collections.Hashtable();

        //        if (!string.IsNullOrEmpty(optionSelected3))
        //        {
        //            if (optionSelected3 == "1")
        //            {
        //                string res = ng.GenMermasRec(Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt32(TempData["input_CEDIS"]));
        //                if (res == "-1")
        //                {
        //                    TempData["flagCodigo"] = "Principal";
        //                    TempData.Clear();
        //                }
        //                else
        //                {
        //                    TempData["lblResult2"] = res;
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagCodigo"] = "IngresaCodigos";

        //                #region Borro temporales del codigo
        //                TempData["input_CODIGO"] = "";
        //                TempData["lbl_DESCART"] = "";
        //                TempData["lbl_ACUM"] = "";
        //                TempData["lbl_UVTA"] = "";
        //                TempData["lbl_UCOM"] = "";
        //                TempData["lbl_CAPEMP"] = "";

        //                TempData["NumTransf"] = "";
        //                TempData["NumAreaESMcia"] = "";
        //                TempData["CnscFolESMcia"] = "";
        //                TempData["FolESMcia"] = "";
        //                TempData["BitArtEnviado"] = "";
        //                #endregion
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_CODIGO))
        //        {
        //            if (!string.IsNullOrEmpty(optionSelected2))
        //            {
        //                if (optionSelected2 != "3")
        //                {
        //                    string result = ng.InsertaTarimaRecConfV2(Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt32(TempData["NumTransf"]),
        //                        Convert.ToDecimal(TempData["input_CODIGO"]), Convert.ToInt32(TempData["input_CEDIS"]),
        //                        Convert.ToDecimal(TempData["lbl_CAPEMP"]), Convert.ToInt32(input_DANADA), Convert.ToByte(cmb_ESTADOBULTO),
        //                        Convert.ToByte(TempData["NumAreaESMcia"]), Convert.ToByte(TempData["CnscFolESMcia"]), Convert.ToInt32(TempData["FolESMcia"]),
        //                        Convert.ToByte(TempData["BitArtEnviado"]), optionSelected2, Convert.ToByte(cmb_MOTIVO));

        //                    if (result == "-1")
        //                    {
        //                        TempData["cmb_ESTADOBULTO"] = ng.ComboEstadoBulto();
        //                        TempData["cmb_MOTIVO"] = ng.ComboMotivo();
        //                        #region Borro temporales del codigo
        //                        TempData["input_CODIGO"] = "";
        //                        TempData["lbl_DESCART"] = "";
        //                        TempData["lbl_ACUM"] = "";
        //                        TempData["lbl_UVTA"] = "";
        //                        TempData["lbl_UCOM"] = "";
        //                        TempData["lbl_CAPEMP"] = "";

        //                        TempData["NumTransf"] = "";
        //                        TempData["NumAreaESMcia"] = "";
        //                        TempData["CnscFolESMcia"] = "";
        //                        TempData["FolESMcia"] = "";
        //                        TempData["BitArtEnviado"] = "";
        //                        #endregion
        //                        //TempData["lblResult2"] = "Incidencia Mercancia Agregada";
        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult2"] = result;

        //                    }
        //                }
        //                else
        //                {
        //                    TempData["flagCodigo"] = "Principal";
        //                    TempData.Clear();
        //                }
        //            }
        //            else
        //            {
        //                string res = ng.IngresaCodigo(Convert.ToInt32(TempData["FolioGuia"]), Convert.ToInt32(TempData["input_CEDIS"]), Convert.ToDecimal(input_CODIGO), null);

        //                if (res.Contains(','))
        //                {
        //                    String[] substrings = res.Split(',');
        //                    TempData["input_CODIGO"] = input_CODIGO;
        //                    TempData["lbl_DESCART"] = substrings[4].Split(':').Last();
        //                    TempData["lbl_ACUM"] = substrings[0].Split(':').Last();
        //                    TempData["lbl_UVTA"] = substrings[1].Split(':').Last();
        //                    TempData["lbl_UCOM"] = substrings[2].Split(':').Last();
        //                    TempData["lbl_CAPEMP"] = substrings[3].Split(':').Last();

        //                    TempData["NumTransf"] = substrings[8].Split(':').Last();
        //                    TempData["NumAreaESMcia"] = substrings[5].Split(':').Last();
        //                    TempData["CnscFolESMcia"] = substrings[6].Split(':').Last();
        //                    TempData["FolESMcia"] = substrings[7].Split(':').Last();
        //                    TempData["BitArtEnviado"] = substrings[9].Split(':').Last();

        //                    TempData["cmb_ESTADOBULTO"] = ng.ComboEstadoBulto();
        //                    TempData["cmb_MOTIVO"] = ng.ComboMotivo();
        //                }
        //                else
        //                {
        //                    TempData["lblResult2"] = "Codigo Invalido";
        //                }
        //            }
        //        }

        //        else if (!string.IsNullOrEmpty(input_CEDIS))
        //        {
        //            string nomCedis = ng.NombreCedis(Convert.ToInt32(input_CEDIS));
        //            if (nomCedis.Contains("Error"))
        //            {
        //                TempData["lblResult"] = nomCedis;
        //            }
        //            else if (nomCedis.Contains(','))
        //            {
        //                String[] substringsnomCedis = nomCedis.Split(',');

        //                TempData["lbl_DESCEDIS"] = substringsnomCedis[0].Split(':').Last();
        //                TempData["input_CEDIS"] = input_CEDIS;
        //            }
        //            else
        //            {
        //                TempData["lblResult"] = nomCedis;
        //            }

        //            if (!string.IsNullOrEmpty(optionSelected))
        //            {
        //                if (optionSelected == "1")
        //                {
        //                    string pistola = ng.RegPistola(Convert.ToByte(TempData["TerminalId"]), Convert.ToInt16(TempData["UserId"]), "I");

        //                    string validacionGuia = ng.ValidaGuiaV02(Convert.ToInt32(input_GUIA), Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToByte(TempData["TerminalId"]), 2, null);

        //                    if (validacionGuia == null)
        //                    {
        //                        TempData["FolioGuia"] = input_GUIA;
        //                        TempData["flagCodigo"] = "IngresaCodigos";

        //                        TempData["cmb_ESTADOBULTO"] = ng.ComboEstadoBulto();
        //                        TempData["cmb_MOTIVO"] = ng.ComboMotivo();
        //                    }
        //                    else if (validacionGuia.Contains("Error") || validacionGuia.Contains("Guia"))
        //                    {
        //                        TempData["lblResult"] = validacionGuia;
        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult"] = validacionGuia;
        //                    }
        //                }
        //                else
        //                {
        //                    TempData.Clear();

        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                    TempData["UserId"] = u.userId;
        //                    TempData["Cve"] = u.Cve_Habilitado;
        //                    TempData["HostName"] = t.HostName;
        //                    TempData["TerminalId"] = t.NumTerminal;
        //                    TempData["flagCodigo"] = "Principal";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;
        //            TempData["flagCodigo"] = "Principal";

        //        }

        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {

        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["lblResult"] = ex.Message;
        //        return View();
        //    }
        //}

        //public ActionResult SalidaTransportista(string input_CEDIS, string input_GUIA, string input_DESTINO, string optionSelected, string optionSelected2, string input_MARCHAMO, string optionSelected3, string optionSelected4, string cmb_DCTO
        //    , string optionSelected5, string input_SERIE, string input_FECHA, string input_FLETE, string input_IVA, string input_RETENC, string input_MANIOBRAS, string cmb_FISCAL, string optionSelected6, string optionSelected7)
        //{
        //    try
        //    {
        //        TempData["cmb_DCTO"] = new System.Collections.Hashtable();
        //        TempData["cmb_FISCAL"] = new System.Collections.Hashtable();

        //        if (!string.IsNullOrEmpty(optionSelected2))
        //        {
        //            if (optionSelected2 == "1")
        //            {
        //                string result = ng.InsMarchamoSalida(Convert.ToInt32(TempData["FoliEmbarque"]), input_MARCHAMO);

        //                if (result.Contains("-1"))
        //                {
        //                    TempData["flagMarchamo"] = "Confirma";
        //                }
        //                else
        //                {
        //                    TempData["lblResult2"] = result;
        //                }
        //            }
        //            else
        //            {
        //                TempData.Clear();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                TempData["UserId"] = u.userId;
        //                TempData["Cve"] = u.Cve_Habilitado;
        //                TempData["HostName"] = t.HostName;
        //                TempData["TerminalId"] = t.NumTerminal;

        //                TempData["flagMarchamo"] = "Principal";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected3))
        //        {
        //            if (optionSelected3 == "1")
        //            {
        //                TempData["flagMarchamo"] = "Seguro";
        //                string algo = TempData["BitAplica"].ToString();
        //                if (TempData["BitAplica"].ToString() == "1")
        //                {
        //                    TempData["flagMarchamo"] = "DctoFac";
        //                    TempData["cmb_DCTO"] = ng.ComboSinDcto();
        //                }
        //                else
        //                {
        //                    string result = ng.ImpFactFlete(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), TempData["input_SERIE"].ToString(), Convert.ToDateTime(TempData["input_FECHA"]),
        //                    Convert.ToDecimal(TempData["lbl_FLETE"]), Convert.ToDecimal(TempData["lbl_IVA"]), Convert.ToDecimal(TempData["lbl_RETENC"]), Convert.ToDecimal(TempData["lbl_MANIOBRAS"]), Convert.ToByte(TempData["ReqFiscales"]), Convert.ToByte(TempData["sinDcto"]));

        //                    if (result.Contains("Erorr"))
        //                    {
        //                        TempData["lblResult3"] = result;
        //                    }
        //                    else if (result.Contains(','))
        //                    {
        //                        String[] substrings = result.Split(',');
        //                        string BitConfirmaCant = substrings[0].Split(':').Last();
        //                        string BitBorraNoReg = substrings[1].Split(':').Last();

        //                        if (BitConfirmaCant == "1" || BitBorraNoReg == "1")
        //                        {
        //                            TempData["lblResult3"] = "DATOS FACTURA INCORRECTOS";
        //                        }
        //                        else
        //                        {
        //                            string salida = ng.SalidaYLibGuia(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_DESTINO"]), TempData["input_SERIE"].ToString(), Convert.ToDateTime(TempData["input_FECHA"]),
        //                                Convert.ToDecimal(TempData["lbl_FLETE"]), Convert.ToDecimal(TempData["lbl_IVA"]), Convert.ToDecimal(TempData["lbl_RETENC"]), Convert.ToDecimal(TempData["lbl_MANIOBRAS"]), Convert.ToByte(TempData["ReqFiscales"]), Convert.ToByte(TempData["sinDcto"]),
        //                                Convert.ToInt32(TempData["FolEmb"]), Convert.ToInt32(TempData["FolGuiaEmbEnsamb"]));

        //                            if (salida.Contains("Error"))
        //                            {
        //                                TempData["lblResult3"] = salida;
        //                            }
        //                            else if (salida.Contains(','))
        //                            {
        //                                String[] substringsRes = salida.Split(',');

        //                                TempData["lbl_CANTMARCHAMO"] = substringsRes[0].Split(':').Last();
        //                                TempData["lbl_FECHASALIDA"] = substringsRes[1].Split(':').Last();
        //                                TempData["flagMarchamo"] = "Resumen";
        //                            }
        //                            else
        //                            {
        //                                TempData["lblResult3"] = salida;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        TempData["lblResult3"] = result;
        //                    }


        //                }
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected4))
        //        {
        //            if (optionSelected4 == "1")
        //            {
        //                if (cmb_DCTO == "0")
        //                {
        //                    TempData["flagMarchamo"] = "FacturaCaptura";
        //                    TempData["cmb_FISCAL"] = ng.ComboReqFiscales();
        //                    TempData["sinDcto"] = cmb_DCTO;
        //                }
        //                else if (cmb_DCTO == "1")
        //                {
        //                    TempData["flagMarchamo"] = "Factura";

        //                    if (TempData["ReqFiscales"].ToString() == "1")
        //                    {
        //                        TempData["lbl_REQFISCAL"] = "SI";
        //                    }
        //                    else
        //                    {
        //                        TempData["lbl_REQFISCAL"] = "NO";
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMarchamo"] = "DctoFac";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected5))
        //        {
        //            if (optionSelected5 == "1")
        //            {
        //                string result = ng.ImpFactFlete(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), input_SERIE, Convert.ToDateTime(input_FECHA),
        //                    Convert.ToDecimal(input_FLETE), Convert.ToDecimal(input_IVA), Convert.ToDecimal(input_RETENC), Convert.ToDecimal(input_MANIOBRAS), Convert.ToByte(cmb_FISCAL), Convert.ToByte(TempData["sinDcto"]));

        //                if (result.Contains("Error"))
        //                {
        //                    TempData["lblResult5"] = result;
        //                }
        //                else if (result.Contains(','))
        //                {
        //                    String[] substrings = result.Split(',');
        //                    string BitConfirmaCant = substrings[0].Split(':').Last();
        //                    string BitBorraNoReg = substrings[1].Split(':').Last();

        //                    if (BitConfirmaCant == "1" || BitBorraNoReg == "1")
        //                    {
        //                        TempData["lblResult5"] = "DATOS FACTURA INCORRECTOS";
        //                    }
        //                    else
        //                    {
        //                        string res = ng.SalidaYLibGuia(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_DESTINO"]), input_SERIE, Convert.ToDateTime(input_FECHA),
        //                            Convert.ToDecimal(input_FLETE), Convert.ToDecimal(input_IVA), Convert.ToDecimal(input_RETENC), Convert.ToDecimal(input_MANIOBRAS), Convert.ToByte(cmb_FISCAL), Convert.ToByte(TempData["sinDcto"]),
        //                            Convert.ToInt32(TempData["FolEmb"]), Convert.ToInt32(TempData["FolGuiaEmbEnsamb"]));

        //                        if (res.Contains("Error"))
        //                        {
        //                            TempData["lblResult5"] = result;
        //                        }
        //                        else if (res.Contains(','))
        //                        {
        //                            String[] substringsRes = res.Split(',');

        //                            TempData["lbl_CANTMARCHAMO"] = substringsRes[0].Split(':').Last();
        //                            TempData["lbl_FECHASALIDA"] = substringsRes[1].Split(':').Last();
        //                            TempData["flagMarchamo"] = "Resumen";
        //                        }
        //                        else
        //                        {
        //                            TempData["lblResult5"] = result;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    TempData["lblResult5"] = result;
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMarchamo"] = "FacturaCaptura";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected6))
        //        {
        //            if (optionSelected6 == "1")
        //            {
        //                string result = ng.ImpFactFlete(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), TempData["lbl_SERIE"].ToString(),
        //                                            Convert.ToDateTime(TempData["lbl_FECHA"]), Convert.ToDecimal(TempData["lbl_FLETE"]), Convert.ToDecimal(TempData["lbl_IVA"]), Convert.ToDecimal(TempData["lbl_RETENC"]),
        //                                            Convert.ToDecimal(TempData["lbl_MANIOBRAS"]), Convert.ToByte(TempData["ReqFiscales"]), Convert.ToByte(TempData["sinDcto"]));

        //                if (result.Contains("Error"))
        //                {
        //                    TempData["lblResult5"] = result;
        //                }
        //                else if (result.Contains(','))
        //                {
        //                    String[] substrings = result.Split(',');
        //                    string BitConfirmaCant = substrings[0].Split(':').Last();
        //                    string BitBorraNoReg = substrings[1].Split(':').Last();

        //                    if (BitConfirmaCant == "1" || BitBorraNoReg == "1")
        //                    {
        //                        TempData["lblResult6"] = "DATOS FACTURA INCORRECTOS";
        //                    }
        //                    else
        //                    {
        //                        string res = ng.SalidaYLibGuia(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["input_GUIA"]), Convert.ToInt16(TempData["input_DESTINO"]), input_SERIE, Convert.ToDateTime(TempData["lbl_FECHA"]),
        //                            Convert.ToDecimal(TempData["lbl_FLETE"]), Convert.ToDecimal(TempData["lbl_IVA"]), Convert.ToDecimal(TempData["lbl_RETENC"]), Convert.ToDecimal(TempData["lbl_MANIOBRAS"]), Convert.ToByte(TempData["ReqFiscales"]), Convert.ToByte(TempData["sinDcto"]),
        //                            Convert.ToInt32(TempData["FolEmb"]), Convert.ToInt32(TempData["FolGuiaEmbEnsamb"]));

        //                        if (res.Contains("Erorr"))
        //                        {
        //                            TempData["lblResult6"] = result;
        //                        }
        //                        else if (res.Contains(','))
        //                        {
        //                            String[] substringsRes = res.Split(',');

        //                            TempData["lbl_CANTMARCHAMO"] = substringsRes[0].Split(':').Last();
        //                            TempData["lbl_FECHASALIDA"] = substringsRes[1].Split(':').Last();
        //                            TempData["flagMarchamo"] = "Resumen";
        //                        }
        //                        else
        //                        {
        //                            TempData["lblResult6"] = result;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    TempData["lblResult6"] = result;
        //                }
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_DESTINO))
        //        {
        //            string pistola = ng.RegPistola(Convert.ToByte(TempData["TerminalId"]), Convert.ToInt16(TempData["UserId"]), "I");

        //            string guia = ng.ValidaGuiaSalida(Convert.ToInt16(input_CEDIS), Convert.ToInt32(input_GUIA));

        //            if (guia.Contains(','))
        //            {
        //                String[] substrings = guia.Split(',');

        //                string destino = ng.DescripcionDestino(Convert.ToInt32(input_DESTINO));
        //                TempData["lbl_DESCDESTINO"] = destino.Split(' ').Last();

        //                TempData["input_CEDIS"] = input_CEDIS;
        //                TempData["input_GUIA"] = input_GUIA;
        //                TempData["input_DESTINO"] = input_DESTINO;
        //                TempData["lbl_PROVEEDOR"] = substrings[1].Split(';').Last();
        //                TempData["FoliEmbarque"] = substrings[12].Split(';').Last();
        //                TempData["BitAplica"] = substrings[3].Split(';').Last();
        //                TempData["sinDcto"] = substrings[4].Split(';').Last();

        //                TempData["input_SERIE"] = substrings[6].Split(';').Last();
        //                TempData["input_FECHA"] = substrings[7].Split(';').Last();
        //                TempData["FolEmb"] = substrings[12].Split(';').Last();
        //                TempData["FolGuiaEmbEnsamb"] = substrings[13].Split(';').Last();
        //                TempData["ReqFiscales"] = substrings[5].Split(';').Last();

        //                TempData["lbl_SERIE"] = substrings[15].Split(';').Last();
        //                TempData["lbl_FECHA"] = substrings[16].Split(';').Last();
        //                TempData["lbl_FLETE"] = substrings[17].Split(';').Last();
        //                TempData["lbl_IVA"] = substrings[18].Split(';').Last();
        //                TempData["lbl_RETENC"] = substrings[19].Split(';').Last();
        //                TempData["lbl_MANIOBRAS"] = substrings[20].Split(';').Last();
        //            }
        //            else if (guia.Contains("Error") || guia.Contains("INVALIDA"))
        //            {
        //                TempData["lblResult"] = guia;
        //            }
        //            else
        //            {
        //                TempData["lblResult"] = guia;
        //            }

        //            if (!string.IsNullOrEmpty(optionSelected))
        //            {
        //                if (optionSelected == "1")
        //                {
        //                    TempData["flagMarchamo"] = "Confirma";
        //                }
        //                else
        //                {
        //                    TempData.Clear();

        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                    EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                    TempData["UserId"] = u.userId;
        //                    TempData["Cve"] = u.Cve_Habilitado;
        //                    TempData["HostName"] = t.HostName;
        //                    TempData["TerminalId"] = t.NumTerminal;

        //                    TempData["flagMarchamo"] = "Principal";
        //                }
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected7))
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;

        //            TempData["flagMarchamo"] = "Principal";
        //        }


        //        else
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;

        //            TempData["flagMarchamo"] = "Principal";
        //        }

        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["lblResult"] = ex.Message;

        //        return View();
        //    }
        //}

        //public ActionResult CerrarEmbarque(string input_CEDIS, string input_GUIA, string optionSelected, string input_CANT, string optionSelected2, string optionSelected3)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(optionSelected3))
        //        {
        //            if (optionSelected3 == "1")
        //            {
        //                TempData.Clear();

        //                EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //                EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //                TempData["UserId"] = u.userId;
        //                TempData["Cve"] = u.Cve_Habilitado;
        //                TempData["HostName"] = t.HostName;
        //                TempData["TerminalId"] = t.NumTerminal;
        //                TempData["flagMciaDanada"] = "Principal";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected2))
        //        {
        //            if (optionSelected2 == "1")
        //            {
        //                string pistola = ng.RegPistola(Convert.ToByte(TempData["TerminalId"]), Convert.ToInt16(TempData["UserId"]), "I");

        //                string cantConf = ng.UpdArtConfDanado(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["FolGuia"]), Convert.ToInt32(TempData["FolGuiaEmb"]), Convert.ToByte(TempData["AreaMcia"])
        //                    , Convert.ToByte(TempData["CnscFolioMcia"]), Convert.ToInt32(TempData["lbl_FOLIOREC"]), Convert.ToInt32(TempData["lbl_TRANSF"]), Convert.ToInt32(TempData["NumSKU"]), Convert.ToDecimal(TempData["lbl_CODIGO"]), Convert.ToDecimal(input_CANT)
        //                    , Convert.ToInt16(TempData["TerminalId"]), 1);
        //                if (cantConf.Contains("Error") || cantConf.Contains("Verificar") || cantConf.Contains("invalida") || cantConf.Contains("EVTO") || cantConf.Contains("Guia"))
        //                {
        //                    TempData["lblResult2"] = cantConf;
        //                }
        //                else
        //                {
        //                    TempData["BitConfCant"] = cantConf;
        //                    string res = ng.GenReclamacionEmb(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(TempData["FolGuia"]), Convert.ToInt32(TempData["FolGuiaEmb"]), Convert.ToInt16(TempData["TerminalId"]));

        //                    if (res.Contains("Error") || res.Contains("Verificar") || res.Contains("invalida") || res.Contains("EVTO") || res.Contains("Guia"))
        //                    {
        //                        TempData["lblResult2"] = res;
        //                    }
        //                    else
        //                    {
        //                        TempData["flagMciaDanada"] = "Esc";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMciaDanada"] = "Confirma";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(optionSelected))
        //        {
        //            if (optionSelected == "1")
        //            {
        //                string res = ng.ArtConfDanado(Convert.ToInt16(TempData["input_CEDIS"]), Convert.ToInt32(input_GUIA));
        //                if (res.Contains("Guia") || res.Contains("Embarque"))
        //                {
        //                    TempData["lblResult"] = res;
        //                }
        //                else if (res.Contains(','))
        //                {
        //                    String[] substrings = res.Split(',');
        //                    TempData["NumSKU"] = substrings[8].Split(':').Last();
        //                    TempData["lbl_FOLIOREC"] = substrings[5].Split(':').Last();
        //                    TempData["lbl_TARIMA"] = substrings[6].Split(':').Last();
        //                    TempData["lbl_TRANSF"] = substrings[7].Split(':').Last();
        //                    TempData["lbl_CODIGO"] = substrings[9].Split(':').Last();
        //                    TempData["lbl_DES"] = substrings[10].Split(':').Last();

        //                    TempData["FolGuia"] = input_GUIA;
        //                    TempData["FolGuiaEmb"] = substrings[2].Split(':').Last();
        //                    TempData["AreaMcia"] = substrings[3].Split(':').Last();
        //                    TempData["CnscFolioMcia"] = substrings[4].Split(':').Last();

        //                    if (TempData["NumSKU"].ToString() != "0")
        //                    {
        //                        TempData["flagMciaDanada"] = "Confirma";
        //                    }
        //                    else
        //                    {
        //                        TempData.Clear();
        //                        TempData["flagMciaDanada"] = "Principal";
        //                    }
        //                }
        //                else
        //                {
        //                    TempData["lblResult"] = res;
        //                }
        //            }
        //            else
        //            {
        //                TempData["flagMciaDanada"] = "Principal";
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(input_CEDIS))
        //        {
        //            string descCedis = ng.NombreCedis(Convert.ToInt32(input_CEDIS));

        //            if (descCedis.Contains("Error"))
        //            {
        //                TempData["lblResult"] = descCedis;
        //            }
        //            else if (descCedis.Contains(','))
        //            {
        //                String[] substringsdescCedis = descCedis.Split(',');

        //                TempData["lbl_DESCEDIS"] = substringsdescCedis[0].Split(':').Last();
        //                TempData["input_CEDIS"] = input_CEDIS;
        //            }
        //            else
        //            {
        //                TempData["lblResult"] = descCedis;
        //            }
        //        }
        //        else
        //        {
        //            TempData.Clear();

        //            EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //            EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();


        //            TempData["UserId"] = u.userId;
        //            TempData["Cve"] = u.Cve_Habilitado;
        //            TempData["HostName"] = t.HostName;
        //            TempData["TerminalId"] = t.NumTerminal;
        //            TempData["flagMciaDanada"] = "Principal";

        //        }

        //        TempData.Keep();
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.User u = terminal.ObtenerUsuarioXAplicacion();
        //        EDReciboTiendaSoriana.EDAuditoriaGuia.Terminal t = terminal.ObtenerNumTerminal();

        //        TempData["UserId"] = u.userId;
        //        TempData["Cve"] = u.Cve_Habilitado;
        //        TempData["HostName"] = t.HostName;
        //        TempData["TerminalId"] = t.NumTerminal;

        //        TempData["lblResult"] = ex.Message;

        //        return View();
        //    }
        //}
    }
}