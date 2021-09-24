using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using EDReciboTiendaSoriana.EDReportes;

namespace DTSalidaMercanciaDevDanSorianaTienda.DTPorcentajeRemates
{
    public class DTPorcentajeRemates
    {
        EDRHeadReportes EDRHeadReportes = new EDRHeadReportes();

        public DTPorcentajeRemates()
        {
            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];

            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
        }

        public DataSet DT_UpTdagmd_dd_Defecto(decimal Num_CodBarra)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@Num_CodBarra ", Num_CodBarra);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdagmd_dd_Defecto", false, parametros);

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

        public DataSet DT_UpTdagmd_dd_SolucionProv()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdagmd_dd_SolucionProv", false);

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

        public DataSet DT_SP_Get_gmdFmto()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdFmto", false);

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

        public DataSet DT_SP_Get_gmdCategoria()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdCategoria", false);

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

        public DataSet DT_SP_Get_gmdLinea(int iId_Num_Categ)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Categ ", iId_Num_Categ);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLinea", false, parametros);

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

        public DataSet DT_SP_Get_gmdLineaRemateBajo(int iId_Num_Linea, string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea ", iId_Num_Linea);
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLineaRemateBajo", false, parametros);

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

        public DataSet DT_SP_Get_gmdLineaRemateMedio(int iId_Num_Linea, string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea ", iId_Num_Linea);
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLineaRemateMedio", false, parametros);

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

        public DataSet DT_SP_Get_gmdLineaRemateAlto(int iId_Num_Linea, string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea ", iId_Num_Linea);
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLineaRemateAlto", false, parametros);

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

        public void DT_SP_Ins_gmdLineaRemateBajo(int iId_Num_Linea, string iId_Cve_Fmto, int iUserId)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iUserId", iUserId);

            sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaRemateBajo]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Ins_gmdLineaRemateBajo_Temp(int iId_Num_Linea, string iId_Cve_Fmto, int iId_Num_Etapa
    , int iCant_Dias, decimal dPorc_Descto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iId_Num_Etapa", iId_Num_Etapa);
                parametros.Add("@iCant_Dias", iCant_Dias);
                parametros.Add("@dPorc_Descto", dPorc_Descto);
                parametros.Add("@iUserId", iUserId);

                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaRemateBajo_Temp]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Ins_gmdLineaRemateMedio(int iId_Num_Linea, string iId_Cve_Fmto, int iId_Num_Etapa
        , int iCant_Dias, decimal dPorc_Descto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iId_Num_Etapa", iId_Num_Etapa);
                parametros.Add("@iCant_Dias", iCant_Dias);
                parametros.Add("@dPorc_Descto", dPorc_Descto);
                parametros.Add("@iUserId", iUserId);

                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaRemateMedio]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Ins_gmdLineaRemateAlto(int iId_Num_Linea, string iId_Cve_Fmto, int iId_Num_Etapa
        , int iCant_Dias, decimal dPorc_Descto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iId_Num_Etapa", iId_Num_Etapa);
                parametros.Add("@iCant_Dias", iCant_Dias);
                parametros.Add("@dPorc_Descto", dPorc_Descto);
                parametros.Add("@iUserId", iUserId);

                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaRemateAlto]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Del_gmdLineaRemateBajo_Temp(int iId_Num_Linea, string iId_Cve_Fmto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iUserId", iUserId);


                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Del_gmdLineaRemateBajo_Temp]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet DT_SP_Get_gmdLineaPartRepara(string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLineaPartRepara", false, parametros);

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

        public DataSet DT_SP_Get_gmdLineaProvRepara(int iId_Num_Linea, string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea ", iId_Num_Linea);
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdLineaProvRepara", false, parametros);

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

        public DataSet DT_SP_Get_gmdProveedor(int Id_Num_Prov, int iId_Num_Linea, string cId_Cve_Fmto)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@Id_Num_Prov ", Id_Num_Prov);
                parametros.Add("@iId_Num_Linea ", iId_Num_Linea);
                parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdProveedor", false, parametros);

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

        public void DT_SP_Del_gmdgmdLineaProvRepara_Temp(int iId_Num_Linea, string iId_Cve_Fmto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iUserId", iUserId);


                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Del_gmdgmdLineaProvRepara_Temp]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Ins_gmdLineaProvRepara_Temp(int Id_Num_Prov, bool Bit_Activo, int iId_Num_Linea, string iId_Cve_Fmto
            , int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@Id_Num_Prov", Id_Num_Prov);
                parametros.Add("Bit_Activo", Bit_Activo);
                parametros.Add("@iUserId", iUserId);


                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaProvRepara_Temp]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DT_SP_Ins_gmdLineaProvRepara(int iId_Num_Linea, string iId_Cve_Fmto, int iUserId)
        {
            try
            {

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Cve_Fmto", iId_Cve_Fmto);
                parametros.Add("@iUserId", iUserId);


                sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Ins_gmdLineaProvRepara]", false, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DT_SP_Get_gmdFolioGMD()
        {
            DataSet ds = new DataSet();
            try
            {
                //System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                //parametros.Add("@cId_Cve_Fmto ", cId_Cve_Fmto);
                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SP_Get_gmdFolioGMD", false);

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

        public string DT_UpTdagmd_Upd_gmdFolioGMD(int IdFolGMD, int? IdNumDefecto, bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto
            , int? Bit_ReparoMcia,int? Bit_FinRemate,string Observaciones, string CveSerie, string CveModelo, int IdNumSolucProv)
        {
            try
            {
                
                System.Collections.Hashtable parametersDeclare = new System.Collections.Hashtable();
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                System.Collections.Hashtable parametrosOut = new System.Collections.Hashtable();

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@IdFolGMD", IdFolGMD);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@IdNumDefecto", IdNumDefecto);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Bit_AptoVta", Bit_AptoVta);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Bit_EmpOriginal", Bit_EmpOriginal);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Bit_ReqDescto", Bit_ReqDescto);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Bit_ReparoMcia", Bit_ReparoMcia);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Bit_FinRemate", Bit_FinRemate);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Observaciones", Observaciones);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@CveSerie", CveSerie);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@CveModelo", CveModelo);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@Leyenda", "Leyenda");
                parameters.Add(parametersDeclare, ParameterDirection.Output);
                
                parametersDeclare = new System.Collections.Hashtable();
                parametersDeclare.Add("@IdNumSolucProv", IdNumSolucProv);
                parameters.Add(parametersDeclare, ParameterDirection.Input);

                parametrosOut = sqlHelper.ExecuteNonQuery("UpTdagmd_Upd_gmdFolioGMD", false, parameters);
                //var paraOut = sqlHelper.ExecuteNonQuery("UpTdagmd_Upd_gmdFolioGMD", false, parameters);

                string leyenda = "";
                 leyenda=   parametrosOut["@Leyenda"].ToString();


                //DataSet ds = new DataSet();
                //System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                //parametros.Add("@IdFolGMD", IdFolGMD);
                //parametros.Add("@Bit_AptoVta", Bit_AptoVta);
                //parametros.Add("@Bit_EmpOriginal", Bit_EmpOriginal);
                //parametros.Add("@Bit_ReqDescto", Bit_ReqDescto);
                //parametros.Add("@Bit_ReparoMcia", Bit_ReparoMcia);


                //ds = sqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[UpTdagmd_Upd_gmdFolioGMD]", false, parameters);



                return leyenda;
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


        public DataSet DT_SP_Get_gmd_Sel_CodBarra(decimal NumCodBarra)
        {
            try
            {
                DataSet ds = new DataSet();
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@NumCodBarra", NumCodBarra);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Get_gmd_Sel_CodBarra]", false, parametros);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DT_SP_Get_gmdOrigenMcia()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[SP_Get_gmdOrigenMcia]", false);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DT_UpTdagmd_Gen_gmdFolioGMD(int iId_Num_OrigenMcia, int iId_Num_SKU, int iId_Num_Linea, int iId_Num_Prov
         , bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto, string iDesc_Incid, int iUserId, string CveSerie, string CveModelo, int? IdNumDefecto)
        {
            try
            {

                DataSet ds = new DataSet();
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@iId_Num_OrigenMcia", iId_Num_OrigenMcia);
                parametros.Add("@iId_Num_SKU", iId_Num_SKU);
                parametros.Add("@iId_Num_Linea", iId_Num_Linea);
                parametros.Add("@iId_Num_Prov", iId_Num_Prov);
                parametros.Add("@iBit_AptoVta", Bit_AptoVta);
                parametros.Add("@iBit_EmpOriginal", Bit_EmpOriginal);
                parametros.Add("@iBit_ReqDescto", Bit_ReqDescto);
                parametros.Add("@iDesc_Incid", iDesc_Incid);
                parametros.Add("@iUserId", iUserId);
                parametros.Add("@CveSerie", CveSerie);
                parametros.Add("@CveModelo", CveModelo);
                parametros.Add("@IdNumDefecto", IdNumDefecto);


                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[UpTdagmd_Gen_gmdFolioGMD]", false, parametros);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DT_UpTdagmd_Cns_SolGenyPendRepara(DateTime? FechaInicial, DateTime? FechaFinal,bool Bit_PendRepara)
        {
            try
            {

                DataSet ds = new DataSet();
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@FechaInicial", FechaInicial);
                parametros.Add("@FechaFinal", FechaFinal);
                parametros.Add("@Bit_PendRepara", Bit_PendRepara);


                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[UpTdagmd_Cns_SolGenyPendRepara]", false, parametros);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DT_UpTdagmd_Cns_SolGenyPendRepara2(reporteReq ReqDatosGenerales)
        {
            try
            {
                DataSet ds = new DataSet();

                var fechaRpt =Convert.ToDateTime( ReqDatosGenerales.FechaConsulta).ToShortDateString();
                var fechaRpt2 = Convert.ToDateTime(ReqDatosGenerales.Nombre_Usuario).ToShortDateString();
                string dia = string.Empty;
                string mes = string.Empty;
                string year = string.Empty;
                string dia2 = string.Empty;
                string mes2 = string.Empty;
                string year2 = string.Empty;

                year = fechaRpt.Substring(6, 4);
                mes = fechaRpt.Substring(3, 2);
                dia = fechaRpt.Substring(0, 2);
                year2 = fechaRpt2.Substring(6, 4);
                mes2 = fechaRpt2.Substring(3, 2);
                dia2 = fechaRpt2.Substring(0, 2);

                fechaRpt = mes + "-" + dia + "-" + year;
                fechaRpt2 = mes2 + "-" + dia2 + "-" + year2;

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("@FechaInicial", fechaRpt); //ReqDatosGenerales.FechaConsulta);
                parametros.Add("@FechaFinal", fechaRpt2); //ReqDatosGenerales.Nombre_Usuario);
                parametros.Add("@Bit_PendRepara", ReqDatosGenerales.bit);

                ds = sqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[UpTdagmd_Cns_SolGenyPendRepara]", false, parametros);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
