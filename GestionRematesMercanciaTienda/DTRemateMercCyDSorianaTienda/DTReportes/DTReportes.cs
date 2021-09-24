using System;
using Soriana.FWK.Datos.SQL;
using System.Configuration;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System.Data;
using System.Data.SqlClient;
using EDReciboTiendaSoriana.EDReportes;

namespace DTReciboTiendaSoriana.DTReportes
{
    public class DTReportes
    {
        EDRHeadReportes EDRHeadReportes = new EDRHeadReportes();
        string cadena = string.Empty;
        public DTReportes()
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

        #region Cargos x Devolución
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo">C¢digo a buscar</param>
        /// <param name="desc">Descripci¢n a buscar</param>
        /// <returns></returns>
        public DataSet DT_Rec_dd_area(bool keydown, int tipo, int? codigo, string desc)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_dd_area", false, parameters);

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
        /// <summary>
        /// Datos Generales para los Reportes ,Se utiliza en Consultas Gerenciales ( Telxon )
        /// </summary>
        /// <param name="IdNumAplicacion"></param>
        /// <param name="Titulo"></param>
        /// <param name="SubTitulo"></param>
        /// <param name="Fec_Elabora"></param>
        /// <returns></returns>
        public DataSet DT_Rpt_DatosGrales_Aplic(int IdNumAplicacion, string Titulo, string SubTitulo, DateTime Fec_Elabora)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdNumAplicacion", IdNumAplicacion);
                parameters.Add("@Titulo", Titulo);
                parameters.Add("@SubTitulo", SubTitulo);
                parameters.Add("@Fec_Elabora", Fec_Elabora);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rpt_DatosGrales_Aplic", false, parameters);

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
        /// <summary>
        /// Reporte de Cargos x Devolucion, Reporte de Lista de Empaque, Reporte de Cartas de Reclamacion a Bodega,Transportista y Seguro
        /// </summary>
        /// <param name="IdNumAreaESMcia">Area de ES de Mercancia</param>
        /// <param name="IdCnscFolESMcia">Foliador de Devoluciones</param>
        /// <param name="IdFolESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public DataSet Dt_Rpt_CargoDev(int IdNumAreaESMcia, int IdCnscFolESMcia, int IdFolESMcia)
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdNumAreaESMcia", IdNumAreaESMcia);
                parameters.Add("@IdCnscFolESMcia", IdCnscFolESMcia);
                parameters.Add("@IdFolESMcia", IdFolESMcia);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_Rpt_CargoDev", false, parameters);

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
        /// <summary>
        ///  Reporte de Lista de Empaque (Movimientos realizados)
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public DataSet Dt_Rpt_lista_emp_mov(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pi_Id_Num_AreaESMcia", pi_Id_Num_AreaESMcia);
                parameters.Add("@pi_Id_Cnsc_FolESMcia", pi_Id_Cnsc_FolESMcia);
                parameters.Add("@pi_Id_Fol_ESMcia", pi_Id_Fol_ESMcia);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_Rpt_lista_emp_mov", false, parameters);

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
        /// <summary>
        /// Selecciona la leyenda del reporte
        /// </summary>
        /// <returns></returns>
        public DataSet Dt_leyenda_cargoxdev()
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_leyenda_cargoxdev", false);

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
        /// <summary>
        /// Selecciona la leyenda del reporte
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public DataSet Dt_leyenda_lista_emp(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pi_Id_Num_AreaESMcia", pi_Id_Num_AreaESMcia);
                parameters.Add("@pi_Id_Cnsc_FolESMcia", pi_Id_Cnsc_FolESMcia);
                parameters.Add("@pi_Id_Fol_ESMcia", pi_Id_Fol_ESMcia);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_leyenda_lista_emp", false, parameters);

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
        /// <summary>
        /// Despliega el pie de pÿgina para el reporte de Cargos por Devoluci›n
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public DataSet Dt_pie_carxdev(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pi_Id_Num_AreaESMcia", pi_Id_Num_AreaESMcia);
                parameters.Add("@pi_Id_Cnsc_FolESMcia", pi_Id_Cnsc_FolESMcia);
                parameters.Add("@pi_Id_Fol_ESMcia", pi_Id_Fol_ESMcia);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_pie_carxdev", false, parameters);

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
        /// <summary>
        ///  Reporte de Cargos x Devolucion (Articulos)
        /// </summary>
        /// <param name="IdNumAreaESMcia">Area de ES de Mercancia</param>
        /// <param name="IdCnscFolESMcia">Foliador de devoluciones</param>
        /// <param name="IdFolESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public DataSet Dt_Rpt_CargoDev_Art(int IdNumAreaESMcia, int IdCnscFolESMcia, int IdFolESMcia)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdNumAreaESMcia", IdNumAreaESMcia);
                parameters.Add("@IdCnscFolESMcia", IdCnscFolESMcia);
                parameters.Add("@IdFolESMcia", IdFolESMcia);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_Rpt_CargoDev_Art", false, parameters);

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
        /// <summary>
        /// Obtiene el detalle de los bultos a devolver al transportista
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia"> Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public DataSet Dt_Rpt_CargoDev_Bultos(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pi_Id_Num_AreaESMcia", pi_Id_Num_AreaESMcia);
                parameters.Add("@pi_Id_Cnsc_FolESMcia", pi_Id_Cnsc_FolESMcia);
                parameters.Add("@pi_Id_Fol_ESMcia", pi_Id_Fol_ESMcia);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_Rpt_CargoDev_Bultos", false, parameters);

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
        /// <summary>
        /// Lista de reportes de Recibo de Mecanc­a x Autorizar
        /// </summary>
        /// <param name="Nombre_Rpt"></param>
        /// <param name="Criterio_Rpt"></param>
        /// <param name="Preview_Rpt"></param>
        /// <param name="Object_Rpt"></param>
        /// <returns></returns>
        public DataSet Dt_rpts_rec_mciaxaut(string Nombre_Rpt, string Criterio_Rpt, string Preview_Rpt, string Object_Rpt)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Nombre_Rpt", Nombre_Rpt);
                parameters.Add("@Criterio_Rpt", Criterio_Rpt);
                parameters.Add("@Preview_Rpt", Preview_Rpt);
                parameters.Add("@Object_Rpt", Object_Rpt);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_rpts_rec_mciaxaut", false, parameters);

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
        /// <summary>
        /// Selecciona los Tipos de reclamacion
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo"> C+digo a buscar</param>
        /// <param name="desc">Descripci+n a buscar</param>
        /// <returns></returns>
        public DataSet Dt_Rpt_CartaRecl_Crit(bool keydown, int tipo, int? codigo, string desc)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "Up_Rec_Rpt_CartaRecl_Crit", false, parameters);

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

        #endregion

        #region Filtros 
        /// <summary>
        /// Lista de reportes de Aplicaciones
        /// </summary>
        /// <param name="Bit_AdmonInv">Numero de Aplicacion</param>
        /// <param name="Id_Num_Aplic"></param>
        /// <returns></returns>
        public DataSet DT_rpts_rec_mcia(bool Bit_AdmonInv, int Id_Num_Aplic)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Num_Aplic", Id_Num_Aplic);
                parameters.Add("@Bit_AdmonInv", Bit_AdmonInv);   

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_rpts_rec_mcia", false, parameters);

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
        /// <summary>
        ///  Consulta informacion de Mermas acumulativo
        /// </summary>
        /// <param name="keydown"></param>
        /// <param name="tipo"></param>
        /// <param name="codigo"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public DataSet DT_dd_div(bool keydown, int tipo, int? codigo, string desc)
        {

            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_dd_div", false, parameters);

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
        /// <summary>
        ///  Selecciona los registros de la tabla rcTipoMovESMcia para los Folios de Entrada
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo">C+digo a buscar</param>
        /// <param name="desc">Descripci+n a buscar</param>
        /// <returns></returns>
        public DataSet DT_dd_tipomcia_NE(bool keydown, int tipo, int? codigo, string desc)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_dd_tipomcia_NE", false, parameters);

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
        /// <summary>
        /// Obtiene todos los departamentos validos en el sistema o que cumplan con cierta descripcion
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo">C+digo a buscar</param>
        /// <param name="desc">Descripci+n a buscar</param>
        /// <param name="IdNumDiv"></param>
        /// <returns></returns>
        public DataSet DT_dd_dpto_div(bool keydown, int tipo, int? codigo, string desc,int IdNumDiv)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);
                parameters.Add("@IdNumDiv", IdNumDiv);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_dd_dpto_div", false, parameters);

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo">C+digo a buscar</param>
        /// <param name="desc">Descripci+n a buscar</param>
        /// <param name="IdNumTipoMovESMcia">Tipo de Movimiento (NE o Transf)</param>
        /// <returns></returns>
        public DataSet DT_dd_status_ne(bool keydown, int tipo, int? codigo, string desc, int IdNumTipoMovESMcia)
        {

            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@keydown", keydown);
                parameters.Add("@tipo", tipo);
                parameters.Add("@codigo", codigo);
                parameters.Add("@desc", desc);
                parameters.Add("@IdNumTipoMovESMcia", IdNumTipoMovESMcia);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "up_Rec_dd_status_ne", false, parameters);

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
        #endregion

        #region Reportes BGH
        //Reporte de Captura de Mercancía por Caducar
        public DataSet LlenadoGridCapturaMercancíaCaducar(string folio)
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
                command.CommandText = "rmpcImpresionMciaCaducaDetalle_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
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
            catch (Exception ex)
            {
                return ds;
                throw;

            }
        }

        //Reporte de Acta de Destrucción.
        public DataSet LlenadoGridActaDestruccion(string folio)
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
                command.CommandText = "rmpcImpresionActaDestruccionDetalle_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_ActaDestruccion";
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
            catch (Exception ex)
            {
                return ds;
                throw;

            }
        }

        public DataSet LlenadoGridArtRemVencidos(string fecha)
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
                command.CommandText = "rmpcRptArticulosRemateVencidos";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pFechaConsulta";
                param.SqlDbType = SqlDbType.SmallDateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
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

        public DataSet LlenadoGridArtRemProxCadEtapa(string usuario, string categoria, string opcion ,string fecha)
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
                command.CommandText = "rmpcRptArtsRemProxCaducarEtapa";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pUserId";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = usuario;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Categ";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Input;
                param.Value = categoria;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pIdOpc";
                param.SqlDbType = SqlDbType.TinyInt;
                param.Direction = ParameterDirection.Input;
                param.Value = opcion;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pFechaRpt";
                param.SqlDbType = SqlDbType.SmallDateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
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

        public DataSet LlenadoGridMerma(string fecha, string usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                //parameters.Add("@Usuario", usuario);
                //ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcRolesPorcentajesListarFormatoSoriana_sUp", false, parameters);

               // string cadena = "Data Source=DESAOPER;Initial Catalog=Tda024ProdDB;User ID=findia;Password=SIC2000";//ConfigurationManager.AppSettings["GestionRMC"].ToString();
                SqlConnection connection = new SqlConnection();
                SqlParameter param = new SqlParameter();

                connection.ConnectionString = cadena;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "rmpcRolesFolioMciaCaducaListarGridFolioMciaCad_sUp";
                command.CommandText = "rmpcMciaCaducaReporteMerma_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@FechaConsulta";
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
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }
        }

        public DataSet LlenadoGridReimpresionEtiqueta(string fecha, string folio)
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
                command.CommandText = "rmpcReimpEtiqListarGrid_pUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@FechaConsulta";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = fecha;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
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
            catch (Exception ex)
            {
                return ds;
                throw;

            }
        }

        #endregion

        #region Reporte Acta Destruccion

        public DataSet rptEncabezado(reporteReq ReqDatosGenerales)
        {
            //DataSet ds = new DataSet();
            //try
            //{
            //    System.Collections.Hashtable parametros = new System.Collections.Hashtable();

            //    parametros.Add("@Id_Num_Aplic", ReqDatosGenerales.Id_Num_Aplic);
            //    parametros.Add("@Id_Num_Rpt", ReqDatosGenerales.Id_Num_Rpt);

            //    ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[upTdaAs_Rpt_MciaCaduca_Encab]", false, parametros);

            //    return ds;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
                command.CommandText = "upTdaAs_Rpt_MciaCaduca_Encab";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_Aplic";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_Aplic;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_Rpt";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_Rpt;
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
                throw ex;

            }
        }

        public DataSet rptActaDestruccion_r2(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcImpresionActaDestruccionHeader_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_ActaDestruccion";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }

        public DataSet rptActaDestruccion_r3(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcImpresionActaDestruccionDetalle_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_ActaDestruccion";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }

        public DataSet rptActaDestruccion_r4(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcImpresionActaDestruccionPiePag_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Num_ActaDestruccion";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }
        #endregion

        #region Mermas
        public DataSet rptMermas_Detalle(reporteReq ReqDatosGenerales)
        {
            DataSet ds = new DataSet();
            try
            {
                //var fechaRpt = ReqDatosGenerales.FechaConsulta;
                //string dia = string.Empty;
                //string mes = string.Empty;
                //string year = string.Empty;

                //year = fechaRpt.Substring(6, 4);
                //mes = fechaRpt.Substring(3, 2);
                //dia = fechaRpt.Substring(0, 2);

                //fechaRpt = year  + "-" + mes  + "-" + dia;

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
                command.CommandText = "rmpcMciaCaducaReporteMerma_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@FechaConsulta";
                param.SqlDbType = SqlDbType.DateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.FechaConsulta;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Usuario";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Usuario;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }

        public DataSet DTGeneraMermasMasivo(string Fecha, int Jefe)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@FechaConsulta ", Fecha);
                parametros.Add("@Usuario ", Jefe);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "rmpcGeneraMermasMasivo_pup", false, parametros);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ArtProxCadEtapa
        public DataSet rptArtProxCadEtapa_Detalle(reporteReq ReqDatosGenerales)
        {
            DataSet ds = new DataSet();
            try
            {
                //var fechaRpt = ReqDatosGenerales.FechaConsulta;
                //string dia = string.Empty;
                //string mes = string.Empty;
                //string year = string.Empty;

                //year = fechaRpt.Substring(6, 4);
                //mes = fechaRpt.Substring(3, 2);
                //dia = fechaRpt.Substring(0, 2);

                //fechaRpt = year  + "-" + mes  + "-" + dia;

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
                command.CommandText = "rmpcRptArtsRemProxCaducarEtapa";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pFechaRpt";
                param.SqlDbType = SqlDbType.DateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.FechaConsulta;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pUserId";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Usuario;
                command.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@pIdOpc";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.pIdOpc;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@pId_Num_Categ";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.pId_Num_Categ;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }
        #endregion

        #region FolMerCadCap
        public DataSet rptFolMerCadCap(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcRptFolioMciaXCaducarAut";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@pId_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }
        #endregion

        #region ReporteCapturaMercancíaCaducar
        public DataSet rptCapturaMercancíaCaducar_Enc(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcImpresionMciaCaducaHeader_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }

        public DataSet rptCapturaMercancíaCaducar_Det(reporteReq ReqDatosGenerales)
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
                command.CommandText = "rmpcImpresionMciaCaducaDetalle_sUp";
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Id_Fol_MciaCaduca";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = ReqDatosGenerales.Id_Num_ActaDestruccion;
                command.Parameters.Add(param);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //return ds;
                throw ex;

            }
        }
        #endregion
    }


}
