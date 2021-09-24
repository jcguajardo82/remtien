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

namespace DTReciboTiendaSoriana.DTRegistroSecos
{
    public class DTRegistroSecos
    {
        public DTRegistroSecos()
        {
            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
        }

        #region DTArriboTransportista

        public DataSet ArriboTpaConCodigo(string CodDoctoCapt)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@CodDoctoCapt", CodDoctoCapt);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Val_CodDoctoCapt", false, parameters);

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

        public DataSet ValidarCedis(Int16 NumCedis)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Num_UN", NumCedis);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_dd_CAD_TP", false, parameters);

                ds2 = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Rec_val_cad_TP", false, parameters);

                ds.Merge(ds2);

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
            //return null;
        }

        public DataSet PrevioArribo(Int16 NumCedis, int FolEmb, Byte BitSeco, Byte BitPerece)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Num_UNCedis", NumCedis);
                parameters.Add("@Id_Fol_Emb", FolEmb);
                parameters.Add("@Ind_CedisSecos", BitSeco);
                parameters.Add("@Ind_CedisPerece", BitPerece);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Cns_PrevioArribo", false, parameters);

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

        public string ActualizaArribo(Int16 NumCedis, int FolioGuia, Int16 NumTerminal)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pIdNumUNCedis", NumCedis);
                parameters.Add("@pi_Id_Folio_Guia", FolioGuia);
                parameters.Add("@Num_Terminal", NumTerminal);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "up_Rec_actualiza_arribo_TP", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }

        }

        public string ActualizaArriboPerec(int NumCedis, int FolioGuia)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@pi_Id_Fol_Emb", NumCedis);
                parameters.Add("@pi_Ids_Num_UN", FolioGuia);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Rec_upd_emb_perece", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }

        }
        #endregion

        #region DTConfirmarTarmima
        public DataSet NombreCedis(int NumCedis)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@NumUNCedis", NumCedis);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ValidaCedis", false, parameters);

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

        public DataSet ValidaGuiaV02(int FolioGuia, Int16 NumCedis, Byte NumTerminal, Byte Valida, string NumTarima)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@NumTerminal", NumTerminal);
                parameters.Add("@Ind_Valida", Valida);
                parameters.Add("@IdNumTarima", NumTarima);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ValidaGuia_V02", false, parameters);
                
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
        
        public DataSet ValidaTarima(int FolioGuia, Int16 NumCedis, Byte NumTerminal,string NumTarima, Byte Valida)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@NumTerminal", NumTerminal);
                parameters.Add("@NumTarima", NumTarima);
                parameters.Add("@Ind_Valida", Valida);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ValidaTarima_V02", false, parameters);

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
        
        public DataSet InsertaTarima(int FolioGuia, Int16 NumCedis,string NumTarima,Byte EdoTarima,Byte BitAuditar,Byte NumTerminal)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@NumTarima", NumTarima);
                parameters.Add("@EdoTarimaRec", EdoTarima);
                parameters.Add("@BitAuditar", BitAuditar);
                parameters.Add("@NumTerminal", NumTerminal);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_InsertaTarima_V02", false, parameters);

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
        
        public DataSet CalcularFaltanteGuia(int Enviado, int CantidadConfirmada)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Enviado", Enviado);
                parameters.Add("@CantidadConfirmada", CantidadConfirmada);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_CalculaFaltanteGuia", false, parameters);

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
        
        public string CierraTarima(int FolioGuia,Int16 NumCedis,Byte NumTerminal)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@NumTerminal", NumTerminal);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_CierraConfirmaTarima", false, parameters);

                return result.ToString();

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

        public DataSet ComboEstatusTarima()
        {
            System.Collections.Hashtable parameters = new System.Collections.Hashtable();


            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Cns_EdoTarima", false, parameters);

        }
        
        public int ValidaAutorizacion()
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_Cns_AutGcia_ConfTarima", false, parameters);

                return result;

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

        public DataSet LoginAutoriza(string CveLote)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@Id_Cve_Item", CveLote);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "Sp_Val_LoginAutoriza", false, parameters);

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

        #region DTControlMarchamos
        public DataSet ValidaGuiaMarchamo(Int16 NumCedis, int FolioGuia, Int16 Origen, Byte Pistola)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdNumUNCedis", NumCedis);
                parameters.Add("@IdFolGuiaEmb", FolioGuia);
                parameters.Add("@IdNumUNOrigen", Origen);
                parameters.Add("@IdNumPistola", Pistola);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ValidaGuiaRecMarchamos", false, parameters);

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

        public DataSet ValidaMarchamoCapturado(Int16 NumCedis, int FolioGuia, Int16 IdNumOrigen, string CveMarchamo)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdNumUNCedis", NumCedis);
                parameters.Add("@IdFolGuiaEmb", FolioGuia);
                parameters.Add("@IdsNumUNOrigen", IdNumOrigen);
                parameters.Add("@IdCveMarchamo", CveMarchamo);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ValidaMarchamoCapturado", false, parameters);

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

        public string UpdMarchamo(Int16 IdNumOrigen, int FolioEmb, string CveMarchamo, Byte StatusMarchamo, string Accion, Byte IndicaMarchEnv)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdsNumUNOrigen", IdNumOrigen);
                parameters.Add("@IdFolEmb", FolioEmb);
                parameters.Add("@IdCveMarchamo", CveMarchamo);
                parameters.Add("@IdNumStatMarchamo", StatusMarchamo);
                parameters.Add("@Accion", Accion);
                parameters.Add("@IndicaMarchEnv", IndicaMarchEnv);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_UpdMarchamoRec", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }

        public DataSet ResumenMarchamo(Int16 IdNumOrigen, int FolioGuia, int FolioEmb, int IncidMarchamos, int IncidTdasAnt)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdsNumUNOrigen", IdNumOrigen);
                parameters.Add("@IdFolGuiaEmb", FolioGuia);
                parameters.Add("@IdFolEmb", FolioEmb);
                parameters.Add("@IncidMarchamos", IncidMarchamos);
                parameters.Add("@IncidTdasAnt", IncidTdasAnt);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_ResumenMarchamos", false, parameters);

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

        public string FinalizarCapturaMarchamo(int FolioGuia, int FolioEmb, Int16 NumCedis)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdFolGuiaEmb", FolioGuia);
                parameters.Add("@IdFolEmb", FolioEmb);
                parameters.Add("@IdNumCedis", NumCedis);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_FinalizaCapturaMarchamos", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }

        public string RegPistola(Byte NumPistola, Int16 UserId, string Operacion)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@Id_Num_Pistola", NumPistola);
                parameters.Add("@UserId", UserId);
                parameters.Add("@Operacion", Operacion);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Ins_RegistraPistola", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }
        #endregion

        #region DTSalidaTRansportista
        public DataSet ValidaGuiaSalida(Int16 NumCedis, int FolioGuia)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdNumUN", NumCedis);
                parameters.Add("@IdFolGuiaEmb", FolioGuia);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdaRt_ValidaGuiaSalida_TP", false, parameters);

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

        public DataSet DescipcionDestino(int NumDestino)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@IdNumUNDest", NumDestino);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdaRt_ValidaDestinoGuiaSalida_TP", false, parameters);

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
        
        public string InsMarchamoSalida(int FolioEmbarque, string Marchamo)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@Id_Fol_Emb", FolioEmbarque);
                parameters.Add("@pIdCveMarchamo", Marchamo);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpTdaRt_InsMarchamosSalida_TP", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }
        
        public DataSet ImpFactFlete(Int16 NumCedis,int FolioGuia,string CveFactura,DateTime FechaFact,Decimal ImpTpaFlete,Decimal ImpIvaFact,Decimal ImpRetencion,Decimal FactTpaManiobras,Byte CumpleReqFiscal,Byte SinDocto)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@pIdNumUNCedis", NumCedis);
                parameters.Add("@pi_Id_Folio_Guia", FolioGuia);
                parameters.Add("@pi_Id_Cve_Fact", CveFactura);
                parameters.Add("@pi_Fec_Fact", FechaFact);
                parameters.Add("@pi_Imp_FactTptaFlete", ImpTpaFlete);
                parameters.Add("@pi_Imp_IVAFact", ImpIvaFact);
                parameters.Add("@pi_Imp_Retencion", ImpRetencion);
                parameters.Add("@pi_Imp_FactTptaManiobras", FactTpaManiobras);
                parameters.Add("@Bit_CumpleReqFiscal", CumpleReqFiscal);
                parameters.Add("@Bit_SinDocto", SinDocto);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Valida_ImpFactFlete_TP", false, parameters);

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
        
        public DataSet SalidaYLibGuia(Int16 NumCedis,int FolioGuia, Int16 NumDestino,string CveFact,DateTime FecFact,Decimal ImpTpaFlete, Decimal ImpIvaFact, Decimal ImpRetencion, Decimal FactTpaManiobras, Byte CumpleReqFiscal, Byte SinDocto, int FolioEmbarque,int FolGuiaEmbEnsamb)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();

                parameters.Add("@pIdNumUNCedis", NumCedis);
                parameters.Add("@pi_Id_Folio_Guia", FolioGuia);
                parameters.Add("@piIdNumUN_Destino", NumDestino);
                parameters.Add("@pi_Id_Cve_Fact", CveFact);
                parameters.Add("@pi_Fec_Fact", FecFact);
                parameters.Add("@pi_Imp_FactTptaFlete", ImpTpaFlete);
                parameters.Add("@pi_Imp_IVAFact", ImpIvaFact);
                parameters.Add("@pi_Imp_Retencion", ImpRetencion);
                parameters.Add("@pi_Imp_FactTptaManiobras", FactTpaManiobras);
                parameters.Add("@Bit_CumpleReqFiscal", CumpleReqFiscal);
                parameters.Add("@Bit_SinDocto", SinDocto);
                parameters.Add("@Id_Fol_Emb", FolioEmbarque);
                parameters.Add("@IdFolGuiaEmbEnsamb", FolGuiaEmbEnsamb);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdaRt_InsSalidayLibGuia_TP", false, parameters);

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
        
        public string ValidaFechaFactFlete(DateTime FechaFact)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                
                parameters.Add("@pd_Fecx_Fact", FechaFact);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_Valida_FecFactFlete", false, parameters);

                return result.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }

        public DataSet ComboSinDcto()
        {
            System.Collections.Hashtable parameters = new System.Collections.Hashtable();


            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Sel_OpcSinDocto_TP", false, parameters);

        }

        public DataSet ComboReqFiscales()
        {
            System.Collections.Hashtable parameters = new System.Collections.Hashtable();


            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Sel_TipoReqFiscalesNE_TP", false, parameters);

        }
        #endregion

        #region DTRegistroMercanciaIncidencia
        public DataSet IngresaCodigo(int FolioGuia, int NumCedis, decimal CodBarra, string CosSobr)
        {            
            DataSet ds = new DataSet();
            try
            {
                if (CosSobr != null)
                {
                    Convert.ToInt32(CosSobr);
                }

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@NumCodBarra", CodBarra);
                parameters.Add("@Id_Cns_Sobr", CosSobr);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Cns_DetCodRec", false, parameters);

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
        
        public string InsertaTarimaRecConfV2(int FolioGuia, int NumTransf, decimal CodBarra, int NumCedis, decimal CapacidadEmpaque, int UniVtaMalEdo, Byte EdoBulto, Byte NumAreaEsMcia, Byte CnscFolEsMcia, int FolEsMcia, Byte BitArtEnviado, string Accion, Byte NumMtvoMerma)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@Id_Num_Transf", NumTransf);
                parameters.Add("@NumCodBarra", CodBarra);
                parameters.Add("@NumUNCedis", NumCedis);
                parameters.Add("@Capacidad_Empaque", CapacidadEmpaque);
                parameters.Add("@Cant_UniVtaMalEdo", UniVtaMalEdo);
                parameters.Add("@EdoBulto", EdoBulto);
                parameters.Add("@Id_Num_AreaESMcia", NumAreaEsMcia);
                parameters.Add("@Id_Cnsc_FolESMcia", CnscFolEsMcia);
                parameters.Add("@Id_Fol_ESMcia", FolEsMcia);
                parameters.Add("@BitArtEnviado", BitArtEnviado);
                parameters.Add("@Cve_Accion", Accion);
                parameters.Add("@NumMtvoMerma", NumMtvoMerma);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_InsertaTarimaDet_RecConf_V3", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }
        
        public string GenMermasRec(int FolioGuia, int NumCedis)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@FolGuiaEmb", FolioGuia);
                parameters.Add("@NumUNCedis", NumCedis);
              
                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "upTdaRt_GenMermasRecConf", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }

        public DataSet ComboEstatadoBulto()
        {
            System.Collections.Hashtable parameters = new System.Collections.Hashtable();


            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "upTdaRt_Cns_EdoBulto", false, parameters);

        }

        public DataSet ComboMotivo()
        {
            System.Collections.Hashtable parameters = new System.Collections.Hashtable();


            return SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdaRc_MtvosMerma_RecConf", false, parameters);

        }
        #endregion

        #region DTCerrarEmbarque
        public DataSet ArtConfDanado(Int16 NumCedis, int FolioEmbarque)
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdNumUNCedis", NumCedis);
                parameters.Add("@IdFolGuiaEmb", FolioEmbarque);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "UpTdaRt_Sel_ArtConfDanado", false, parameters);

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
        
        public string UpdArtConfDanado(Int16 NumCedis,int FolEmb, int FolGuiaEmb, Byte NumArea, Byte ConscFolioMcia, int FolioMcia, int NumTransf, int NumSKU,decimal CodBarra,decimal CantVtaMalEdo,Int16 UserId, Byte ConfirmaCant)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdsNumUNCedis", NumCedis);
                parameters.Add("@IdFolEmb", FolEmb);
                parameters.Add("@IdFolGuiaEmbEnsamb", FolGuiaEmb);
                parameters.Add("@Id_Num_AreaESMcia", NumArea);
                parameters.Add("@Id_Cnsc_FolESMcia", ConscFolioMcia);
                parameters.Add("@Id_Fol_ESMcia", FolioMcia);
                parameters.Add("@Id_Num_Transf", NumTransf);
                parameters.Add("@Id_Num_SKU", NumSKU);
                parameters.Add("@NumCodBarra", CodBarra);
                parameters.Add("@Cantidad", CantVtaMalEdo);
                parameters.Add("@UserIdConfirma", UserId);
                parameters.Add("@BitConfirmaCant", ConfirmaCant);

                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpTdaRt_Upd_ArtConfDanado", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }
        
        public string GenReclamacionEmb(Int16 NumCedis, int FolEmb, int FolGuiaEmb,Int16 UserId)
        {
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdsNumUNCedis", NumCedis);
                parameters.Add("@IdFolEmb", FolEmb);
                parameters.Add("@IdFolGuiaEmbEnsamb", FolGuiaEmb);
                parameters.Add("@UserIdConfirma", UserId);


                var result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpTdaRt_Gen_ReclamaxEmb", false, parameters);

                return result.ToString();

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    return ex.Message;
                }
                throw ex;

            }
        }
        
        #endregion
    }
}
