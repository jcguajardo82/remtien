using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;

namespace DTReciboTiendaSoriana.DTReportes
{
    public class DTRFolioMciaCaduca
    {
        public string cadena = string.Empty;
        public DTRFolioMciaCaduca()
        {
            if (ConfigurationManager.AppSettings["flagTypeConection"].ToString().Equals("Y"))
            {
                cadena = string.Format(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"].ToString()].ToString(), ConfigurationManager.AppSettings["DataSoruce_cs"].ToString(), ConfigurationManager.AppSettings["InitialCatalog_cs"].ToString());
            }
            else
            {
                cadena = string.Format(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"].ToString()].ToString(), ConfigurationManager.AppSettings["DataSoruce_cs"].ToString(), ConfigurationManager.AppSettings["InitialCatalog_cs"].ToString(), ConfigurationManager.AppSettings["User_cs"].ToString(), Soriana.FWK.Seguridad.HelperEncriptar.Desencriptar(ConfigurationManager.AppSettings["Pass_cs"].ToString()));
            }
        }

        public DataSet ListArtRemProxCadEtapa(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {

                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                // string cadena = Cnn; //"Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRptArtsRemProxCaducarEtapa_Opc";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListCatRemProxCadEtapa(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRptArtsRemProxCaducarEtapa_Categ";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pUserId";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;

                command.Parameters.Add(param);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataSet ListJefeDepto(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcAutorizacionMciaCaducaListarJD_sUp";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListJefeProxCadEtapa(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRptArtsRemProxCaducarEtapa_JD";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListRepJefeDepto(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";
                //ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRptMciaProxCaducarCapturadaListarJD_sUp";
                command.CommandText = "rmpcRptFolioMciaXCaducarAutJD_sUp";
                command.CommandType = CommandType.StoredProcedure;
                /*
                param = new SqlParameter();
                param.ParameterName = "@UserId";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);
                */

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListRepJefeMerma(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";
                //ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRptMciaProxCaducarCapturadaListarJD_sUp";
                command.CommandText = "rmpcMciaCaducaListarJD_sUp";
                command.CommandType = CommandType.StoredProcedure;
                /*
                param = new SqlParameter();
                param.ParameterName = "@UserId";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);
                */

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListFolios(string fecha, string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcAutorizacionMciaCaducaListarFolios_suP";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Fecha";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Usuario";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListFoliosAutorizar(string fecha, string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcAutorizacionMciaCaducaListarFolios_suP";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Fecha";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Usuario";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListFoliosRepCapMciaCaducar(string fecha)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcReimpresionMciaCaducaFolios_sUp";

                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Fec_Caducidad";

                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListFoliosRepDestruccionFolios(string fecha)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcReimpresionActaDestruccionFolios_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Fec_Caducidad";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListRepFolios(string fecha, string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcReimpresionMciaCaducaFolios_sUp";
                command.CommandText = "rmpcRptFolioMciaXCaducarAut_Folios";

                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pFechaConsulta";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;

                command.Parameters.Add(param);
                /*
                param = new SqlParameter();
                param.ParameterName = "@pUserId";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Fec_Caducidad";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);
                */
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListFoliosReImpEtiqueta(string fecha)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param;

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcReimpresionMciaCaducaListarFolios_suP";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Fecha";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet LlenadoGridFolioMciaCad(string fecha, string folio)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRolesFolioMciaCaducaListarGridFolioMciaCad_sUp";
                command.CommandText = "rmpcAutorizacionMciaCaduca_PuP";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@FechaConsulta";
                param.SqlDbType = SqlDbType.DateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = DateTime.Parse(fecha);
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = folio;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AutorizarFolios(string folio)
        {
            try
            {
                DataSet ds = new DataSet();
                #region fwk
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@Id_Fol_MciaCaduca", int.Parse(folio));

                string result = string.Empty;
                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[rmpcAutorizacionMciaCaducaAutorizaFolios_pUp]", false, parametros);


                result = ds.Tables[0].Rows[0][0].ToString();
                return result;
                #endregion

                #region brich

                #endregion
                //string result = string.Empty;
                ////string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                //SqlConnection connection = new SqlConnection();
                //connection.ConnectionString = cadena;
                //SqlParameter param;
                //SqlDataAdapter da;
                //DataSet data;
                //SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                //command.CommandText = "rmpcAutorizacionMciaCaducaAutorizaFolios_pUp";
                //command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Id_Fol_MciaCaduca";
                //param.SqlDbType = SqlDbType.Int;
                //param.Direction = ParameterDirection.Input;
                //param.Value = folio;
                //command.Parameters.Add(param);

                //connection.Open();
                //data = new DataSet();
                //da = new SqlDataAdapter(command);
                //da.Fill(data);
                ////result = command.ExecuteNonQuery().ToString();
                //connection.Close();
                //result = data.Tables[0].Rows[0][0].ToString();
                //return result;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string CancelarFolios(string folio)
        {
            try
            {
                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                string result = string.Empty;
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;
                SqlParameter param;
                DataSet data;
                SqlDataAdapter da;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcAutorizacionMciaCaducaCancelaFolios_pUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = folio;
                command.Parameters.Add(param);


                connection.Open();
                data = new DataSet();
                da = new SqlDataAdapter(command);
                da.Fill(data);
                connection.Close();
                result = data.Tables[0].Rows[0][0].ToString();
                return result;
                //connection.Open();
                //command.ExecuteNonQuery();
                //connection.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //rmpcEliminaDetalleCrg_pUP
        public void DT_EliminaDetalleFolioTablaPaso(string folio)
        {
            try
            {
                #region fwk
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@Id_Fol_MciaCaduca", int.Parse(folio));
               
                string result = string.Empty;
                sqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[rmpcEliminaDetalleCrg_pUP]", false, parametros);


                #endregion
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GuardarFolioTablaPaso(string folio, string codigobarra, string cantCapturarada, string lote)
        {
            try
            {
                #region fwk
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@Id_Fol_MciaCaduca", int.Parse(folio));
                parametros.Add("@Id_Num_CodBarra", decimal.Parse(codigobarra));
                parametros.Add("@Cant_Autorizada", int.Parse(cantCapturarada));
                parametros.Add("@Id_Cve_Lote", lote);

                string result = string.Empty;
                sqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[rmpcInsertaDetalleCrg_pUP]", false, parametros);



                #endregion
                //#region brich
                ////string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                //SqlConnection connection = new SqlConnection();
                //connection.ConnectionString = cadena;
                //SqlParameter param;

                //SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                //command.CommandText = "rmpcInsertaDetalleCrg_pUP";
                //command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Id_Fol_MciaCaduca";
                //param.SqlDbType = SqlDbType.Int;
                //param.Direction = ParameterDirection.Input;
                //param.Value = int.Parse(folio);
                //command.Parameters.Add(param);

                //param = new SqlParameter();
                //param.ParameterName = "@Id_Num_CodBarra";
                //param.SqlDbType = SqlDbType.Decimal;
                //param.Direction = ParameterDirection.Input;
                //param.Value = codigobarra;
                //command.Parameters.Add(param);

                //param = new SqlParameter();
                //param.ParameterName = "@Cant_Autorizada";
                //param.SqlDbType = SqlDbType.Int;
                //param.Direction = ParameterDirection.Input;
                //param.Value = cantCapturarada;
                //command.Parameters.Add(param);

                //param = new SqlParameter();
                //param.ParameterName = "@Id_Cve_Lote";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Direction = ParameterDirection.Input;
                //param.Value = lote;
                //command.Parameters.Add(param);

                //connection.Open();
                //command.ExecuteNonQuery();
                //connection.Close();
                //#endregion


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public DataSet LlenadoGridRepFolioMciaCad(string fecha, string folio)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRolesFolioMciaCaducaListarGridFolioMciaCad_sUp";
                //command.CommandText = "rmpcImpresionMciaCaducaDetalle_sUp";
                command.CommandText = "rmpcRptFolioMciaXCaducarAut";
                command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@pFechaCaptura";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Direction = ParameterDirection.Input;
                //param.Value = fecha;
                //command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = folio;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
