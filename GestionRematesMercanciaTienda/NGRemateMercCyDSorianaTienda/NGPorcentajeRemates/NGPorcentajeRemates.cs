using DTSalidaMercanciaDevDanSorianaTienda.DTPorcentajeRemates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soriana.FWK.Common;
using EDSalidaMercanciaDevDanSorianaTienda.EDPorcentajeRemates;
using System.Data;
using System.Data.SqlClient;

namespace NGSalidaMercanciaDevDanSorianaTienda.NGPorcentajeRemates
{
    public class NGPorcentajeRemates
    {
        DTPorcentajeRemates dt = new DTPorcentajeRemates();

        public List<UpTdagmd_dd_Defecto> NG_UpTdagmd_dd_Defecto(decimal Num_CodBarra)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_UpTdagmd_dd_Defecto(Num_CodBarra);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<UpTdagmd_dd_Defecto>();
                }
                else
                {
                    return null;
                }
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

        public List<UpTdagmd_dd_SolucionProv> NG_UpTdagmd_dd_SolucionProv()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_UpTdagmd_dd_SolucionProv();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<UpTdagmd_dd_SolucionProv>();
                }
                else
                {
                    return null;
                }
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
        
        public List<SP_Get_gmdFmto> NG_SP_Get_gmdFmto()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdFmto();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdFmto>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdCategoria> NG_SP_Get_gmdCategoria()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdCategoria();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdCategoria>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdLinea> NG_SP_Get_gmdLinea(int iId_Num_Categ)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdLinea(iId_Num_Categ);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdLinea>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdLineaRemateBajo> NG_SP_Get_gmdLineaRemateBajo(int iId_Num_Linea, string cld_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();
                List<SP_Get_gmdLineaRemateBajo> list = new List<SP_Get_gmdLineaRemateBajo>();
                ds = dt.DT_SP_Get_gmdLineaRemateBajo(iId_Num_Linea, cld_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    list = ds.Tables[0].ToList<SP_Get_gmdLineaRemateBajo>();
                }

                int totalEtapas = list.Count();
                int maxValue = 0;
                if (totalEtapas != 0)
                { maxValue = list.Max(x => x.Id_Num_Etapa); }
                if (totalEtapas != 10)
                {
                    for (int i = maxValue + 1; i < 11; i++)
                    {
                        SP_Get_gmdLineaRemateBajo rebaja = new SP_Get_gmdLineaRemateBajo();
                        rebaja.Cant_Dias = 0;
                        rebaja.Porc_Descto = 0;
                        rebaja.Id_Num_Etapa = i;
                        rebaja.Id_Num_Linea = 0;
                        rebaja.Id_Cve_Fmto = "";
                        rebaja.Desc_Fmto = "";
                        rebaja.Desc_Linea = "";
                        list.Add(rebaja);
                    }
                }

                return list;
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

        public List<SP_Get_gmdLineaRemateMedio> NG_SP_Get_gmdLineaRemateMedio(int iId_Num_Linea, string cld_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdLineaRemateMedio(iId_Num_Linea, cld_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdLineaRemateMedio>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdLineaRemateAlto> NG_SP_Get_gmdLineaRemateAlto(int iId_Num_Linea, string cld_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdLineaRemateAlto(iId_Num_Linea, cld_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdLineaRemateAlto>();
                }
                else
                {
                    return null;
                }
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

        public void NG_SP_Ins_gmdLineaRemateBajo(int iId_Num_Linea, string iId_Cve_Fmto, string[][] gridData, int iUserId)
        {
            try
            {
                // Borramos en la tabla temporal
                NG_SP_Del_gmdLineaRemateBajo_Temp(iId_Num_Linea, iId_Cve_Fmto, iUserId);
                if (gridData != null)
                {
                    //insertamos en la tabla temporal cada etapa
                    foreach (var item in gridData)
                    {
                        int iId_Num_Etapa = int.Parse(item[0].ToString());
                        int iCant_Dias = int.Parse(item[1].ToString());
                        decimal dPorc_Descto = Convert.ToDecimal(item[2].ToString());

                        if (iCant_Dias != 0 & dPorc_Descto != 0)
                        {
                            dt.DT_SP_Ins_gmdLineaRemateBajo_Temp(iId_Num_Linea, iId_Cve_Fmto, iId_Num_Etapa, iCant_Dias, dPorc_Descto, iUserId);
                        }
                    }
                }

                //crea respaldo de los datos actuales, pasa los datos de la temporal a la definitiva
                dt.DT_SP_Ins_gmdLineaRemateBajo(iId_Num_Linea, iId_Cve_Fmto, iUserId);
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

        public void NG_SP_Ins_gmdLineaRemateMedio(int iId_Num_Linea, string iId_Cve_Fmto, int iId_Num_Etapa
        , int iCant_Dias, decimal dPorc_Descto, int iUserId)
        {
            try
            {


                dt.DT_SP_Ins_gmdLineaRemateMedio(iId_Num_Linea, iId_Cve_Fmto, iId_Num_Etapa, iCant_Dias, dPorc_Descto, iUserId);

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

        public void NG_SP_Ins_gmdLineaRemateAlto(int iId_Num_Linea, string iId_Cve_Fmto, int iId_Num_Etapa
        , int iCant_Dias, decimal dPorc_Descto, int iUserId)
        {
            try
            {


                dt.DT_SP_Ins_gmdLineaRemateAlto(iId_Num_Linea, iId_Cve_Fmto, iId_Num_Etapa, iCant_Dias, dPorc_Descto, iUserId);

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

        public void NG_SP_Del_gmdLineaRemateBajo_Temp(int iId_Num_Linea, string iId_Cve_Fmto, int iUserId)
        {
            try
            {
                dt.DT_SP_Del_gmdLineaRemateBajo_Temp(iId_Num_Linea, iId_Cve_Fmto, iUserId);
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

        public List<SP_Get_gmdLineaPart> NG_SP_Get_gmdLineaPartRepara(string iId_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdLineaPartRepara(iId_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdLineaPart>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdLineaProvRepara> NG_SP_Get_gmdLineaProvRepara(int iId_Num_Line, string iId_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdLineaProvRepara(iId_Num_Line, iId_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdLineaProvRepara>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdProveedor> NG_SP_Get_gmdProveedor(int Id_Num_Prov, int iId_Num_Line, string iId_Cve_Fmto)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdProveedor(Id_Num_Prov, iId_Num_Line, iId_Cve_Fmto);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdProveedor>();
                }
                else
                {
                    throw new Exception("El Proveedor no existe para este Formato de Tienda y Linea");
                }
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

        public void NG_SP_Ins_gmdLineaProvRepara(int iId_Num_Linea, string iId_Cve_Fmto, string[][] gridData, int iUserId)
        {
            try
            {
                // Borramos en la tabla temporal
                dt.DT_SP_Del_gmdgmdLineaProvRepara_Temp(iId_Num_Linea, iId_Cve_Fmto, iUserId);
                if (gridData != null)
                {
                    //insertamos en la tabla temporal cada etapa
                    foreach (var item in gridData)
                    {
                        int Id_Num_Prov = int.Parse(item[0].ToString());
                        bool Bit_Activo = Convert.ToBoolean(item[2].ToString());
                        dt.DT_SP_Ins_gmdLineaProvRepara_Temp(Id_Num_Prov, Bit_Activo, iId_Num_Linea, iId_Cve_Fmto, iUserId);
                    }
                }

                //crea respaldo de los datos actuales, pasa los datos de la temporal a la definitiva
                dt.DT_SP_Ins_gmdLineaProvRepara(iId_Num_Linea, iId_Cve_Fmto, iUserId);
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

        public List<SP_Get_gmdFolioGMD> NG_SP_Get_gmdFolioGMD()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdFolioGMD();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdFolioGMD>();
                }
                else
                {
                    return null;
                }
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

        public string NG_UpTdagmd_Upd_gmdFolioGMD(int IdFolGMD, int? IdNumDefecto, bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto
            , int? Bit_ReparoMcia, int? Bit_FinRemate,string Observaciones, string CveSerie, string CveModelo, int IdNumSolucProv)
        {

            try
            {
                string Leyenda = string.Empty;
                DataSet ds = new DataSet();

                Leyenda = dt.DT_UpTdagmd_Upd_gmdFolioGMD(IdFolGMD, IdNumDefecto, Bit_AptoVta, Bit_EmpOriginal, Bit_ReqDescto, Bit_ReparoMcia,Bit_FinRemate,Observaciones, CveSerie, CveModelo, IdNumSolucProv);
                //foreach (DataTable table in ds.Tables)
                //{
                //    foreach (DataRow dr in table.Rows)
                //    {
                //        Leyenda = dr["Leyenda"].ToString();
                //    }
                //}
                return Leyenda;
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

        public List<SP_Get_gmd_Sel_CodBarra> NG_SP_Get_gmd_Sel_CodBarra(decimal NumCodBarra)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmd_Sel_CodBarra(NumCodBarra);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmd_Sel_CodBarra>();
                }
                else
                {
                    return null;
                }
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

        public List<SP_Get_gmdOrigenMcia> NG_SP_Get_gmdOrigenMcia()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_SP_Get_gmdOrigenMcia();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<SP_Get_gmdOrigenMcia>();
                }
                else
                {
                    return null;
                }
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

        public string NG_UpTdagmd_Gen_gmdFolioGMD(int iId_Num_OrigenMcia, int iId_Num_SKU, int iId_Num_Linea, int iId_Num_Prov
           , bool Bit_AptoVta, bool Bit_EmpOriginal, bool Bit_ReqDescto, string iDesc_Incid, int iUserId, string CveSerie, string CveModelo, int? IdNumDefecto)
        {
            try
            {
                string Leyenda = string.Empty;
                DataSet ds = new DataSet();

                ds = dt.DT_UpTdagmd_Gen_gmdFolioGMD(iId_Num_OrigenMcia, iId_Num_SKU, iId_Num_Linea, iId_Num_Prov
           , Bit_AptoVta, Bit_EmpOriginal, Bit_ReqDescto, iDesc_Incid, iUserId, CveSerie, CveModelo, IdNumDefecto);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        Leyenda = dr["Leyenda"].ToString();
                    }
                }
                return Leyenda;
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

        public List<UpTdagmd_Cns_SolGenyPendRepara> NG_UpTdagmd_Cns_SolGenyPendRepara(DateTime? FechaInicial, DateTime? FechaFinal, bool Bit_PendRepara)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = dt.DT_UpTdagmd_Cns_SolGenyPendRepara(FechaInicial, FechaFinal, Bit_PendRepara);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].ToList<UpTdagmd_Cns_SolGenyPendRepara>();
                }
                else
                {
                    return null;
                }
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
