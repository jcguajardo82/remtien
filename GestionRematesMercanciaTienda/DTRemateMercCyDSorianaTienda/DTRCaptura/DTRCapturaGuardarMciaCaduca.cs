using EDReciboTiendaSoriana.Captura;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DTReciboTiendaSoriana.DTRCaptura
{
    public class DTRCapturaGuardarMciaCaduca
    {

        public string cadena = string.Empty;
        public DTRCapturaGuardarMciaCaduca()
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

        public void GuardarCategoria(EDRConsultaCategoria ListCat)
        {

            try
            {
                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;
                SqlParameter param;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRolesPorcentajesGuardarCategorias_sUp_V2";
                command.CommandText = "rmpcRolesPorcentajesGuardarCategorias_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pCveOperacion";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.CveOperacion;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Categ";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.Categoria;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Periodicidad";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.Periodicidad;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDiaMes";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.DiaMes;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_DiaSemana";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.DiaSemana;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDias_Aviso";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.DiaAviso;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Cve_Fmto";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.TipoMcia;
                command.Parameters.Add(param);
                /*
                param = new SqlParameter();
                param.ParameterName = "@pId_Usuario";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListCat.TipoMcia;
                command.Parameters.Add(param);
                */
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

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

        public void GuardarPorcPorCat(EDRConsultaPorcentaje ListPorc)
        {
            try
            {

                // string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;
                SqlParameter param;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesGuardarPorcentajes_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Categ";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.Categoria;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Cve_Fmto";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDia_Inicio";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.DiaInicio;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDia_Fin";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.DiaFin;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pPct_RebajaVta";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.RebajaVta;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pPct_RebajaMerma";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.RebajaMerma;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.TipoMcia;
                command.Parameters.Add(param);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

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

        public void BorrarPorcPorCat(EDRConsultaPorcentaje ListPorc)
        {
            try
            {

                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;
                SqlParameter param;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesGuardarPorcentajes_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Categ";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.Categoria;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Cve_Fmto";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDia_Inicio";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.DiaInicio;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pDia_Fin";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.DiaFin;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pPct_RebajaVta";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.RebajaVta;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pPct_RebajaMerma";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.RebajaMerma;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = ListPorc.TipoMcia;
                command.Parameters.Add(param);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

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


        public DataSet ObtenerCategHistElminadas(string FmtoTienda, string TipoBusquedad, string TipoMcia)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarGridCategorias_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Cve_Operacion";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoBusquedad;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Formato";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoMcia;
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

        public DataSet ObtenerCategPorcentaje(string FmtoTienda, string TipoBusquedad, string Categoria)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarGridCategorias_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Cve_Operacion";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoBusquedad;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Formato";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_Categ";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = Categoria;
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

        public DataSet LlenadoGridCategorias(string FmtoTienda, string TipoBusquedad, string Tipo_Mcia, string Usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarGridCategorias_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Cve_Operacion";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoBusquedad;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Formato";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = Tipo_Mcia;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Usuario";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = Usuario;
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

        public DataSet ObtenerCategHistPorcentaje(string FmtoTienda, string TipoBusquedad, string TipoMcia, string RolCapturaHist)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                //string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarGridCategorias_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Cve_Operacion";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoBusquedad;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Formato";
                param.SqlDbType = SqlDbType.Char;
                param.Direction = ParameterDirection.Input;
                param.Value = FmtoTienda;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Cnsc_RolCapturaHist";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = RolCapturaHist;

                command.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@pId_Num_TipoMcia";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = TipoMcia;
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
