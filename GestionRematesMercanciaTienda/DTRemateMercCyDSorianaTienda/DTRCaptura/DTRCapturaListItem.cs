
using Soriana.FWK.Datos.SQL;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soriana.FWK.Datos.SQL;
using System.Configuration;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System.Data;
using System.Data.SqlClient;

namespace DTReciboTiendaSoriana.DTRCaptura
{
    public class DTRCapturaListItem
    {
        public DTRCapturaListItem()
        {
            //string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
            //sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);

            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["GestionRMC"]];
            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["GestionRMC"]]);

        }
        public DataSet ListFmatoTienda(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();               
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarFormatoSoriana_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@pId_Usuario";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;

                command.Parameters.Add(param);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }

        }

        public DataSet ListCategoria(string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarCategCmb_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@pId_Usuario";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;

                command.Parameters.Add(param);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }

        }

        public DataSet ListPeriocidad()
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarPeriodicidad_sUp";
                command.CommandType = CommandType.StoredProcedure;                
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }

        }

        public DataSet ListTipoMcia()
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarTipoMcia_sUp";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }

        }

        public DataSet ListDiasSemana()
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

                string cadena = "Data Source=DESAOPER;Initial Catalog=CompCorpSICProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "rmpcRolesPorcentajesListarDiaSemana_sUp_V2";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }

        }
    }
}
