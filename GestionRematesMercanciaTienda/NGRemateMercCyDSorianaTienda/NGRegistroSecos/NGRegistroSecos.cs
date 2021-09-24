using EDReciboTiendaSoriana.EDRegistroSecos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGReciboTiendaSoriana.NGRegistroSecos
{
    public class NGRegistroSecos
    {
        DTReciboTiendaSoriana.DTRegistroSecos.DTRegistroSecos dt = new DTReciboTiendaSoriana.DTRegistroSecos.DTRegistroSecos();

        #region NGArriboTransportista
        public string ArriboTpaConCodigo(string CodDoctoCapt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ArriboTpaConCodigo(CodDoctoCapt);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string ValidarCedis(Int16 NumCedis)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidarCedis(NumCedis);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string PrevioArribo(Int16 NumCedis, int FolEmb, Byte CedisSecos, Byte CedisPerece)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.PrevioArribo(NumCedis, FolEmb, CedisSecos, CedisPerece);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0};{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        //public Documento ArriboTransportistaSinCodigo(int NumCedis, int NUMEMBARQUE)
        //{
        //    DataSet ds = dt.ArribarTransportiaSinCodigo(NumCedis);
        //    DataSet ds2 = dt.PrevioArribo(NumCedis, NUMEMBARQUE, Convert.ToInt32(ds.Tables[0].Rows[1]["Bit_Secos"]), Convert.ToInt32(ds.Tables[0].Rows[1]["Bit_Perece"]));

        //    Documento doc = new Documento();

        //    doc.DescCedis = ds.Tables[0].Rows[0]["Desc_UN"].ToString();
        //    //doc.FolEmb = Convert.ToInt32(ds.Tables[0].Rows[0]["Id_Fol_Emb"]);
        //    doc.GuiaEmb = Convert.ToInt32(ds2.Tables[0].Rows[0]["Id_Fol_GuiaEmb"]);
        //    //doc.GuiaEmbEnsamb = Convert.ToInt32(ds.Tables[0].Rows[0]["Id_Fol_GuiaEmbEnsamb"]);
        //    doc.FecLlegada = ds2.Tables[0].Rows[0]["Leyenda02"].ToString();
        //    doc.Status = ds2.Tables[0].Rows[0]["Leyenda04"].ToString();

        //    return doc;
        //}

        public string ActualizaArribo(Int16 NumCedis, int FolioGuia, Int16 NumTerminal)
        {
            try
            {
                string result = dt.ActualizaArribo(NumCedis, FolioGuia, NumTerminal);

                return result;

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;

            }
        }

        public string ActualizaArriboPrece(int NumCedis, int FolioGuia)
        {
            try
            {
                string result = dt.ActualizaArriboPerec(NumCedis, FolioGuia);

                return result;

            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;

            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;

            }
        }
        #endregion

        #region NGControlMarchamos
        public string ValidaGuiaMarchamo(Int16 NumCedis, int FolioGuia, Int16 Origen, Byte Pistola)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidaGuiaMarchamo(NumCedis, FolioGuia, Origen, Pistola);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString() + ',' + ds.Tables[0].Rows[0][1].ToString() + ',' + ds.Tables[0].Rows[0][2].ToString();
                }
                else
                { return null; }
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

        public string ValidaMarchamoCapturado(Int16 NumCedis, int FolioGuia, Int16 IdNumOrigen, string CveMarchamo)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidaMarchamoCapturado(NumCedis, FolioGuia, IdNumOrigen, CveMarchamo);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString() + ',' + ds.Tables[0].Rows[0][1].ToString() + ',' + ds.Tables[0].Rows[0][2].ToString();
                }
                else
                { return null; }
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

        public string UpdMarchamo(Int16 IdNumOrigen, int FolioEmb, string CveMarchamo, Byte StatusMarchamo, string Accion, Byte IndicaMarchEnv)
        {
            try
            {
                string marchamo = dt.UpdMarchamo(IdNumOrigen, FolioEmb, CveMarchamo, StatusMarchamo, Accion, IndicaMarchEnv);

                return marchamo;
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

        public string ResumenMarchamo(Int16 IdNumOrigen, int FolioGuia, int FolioEmb, int IncidMarchamos, int IncidTdasAnt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ResumenMarchamo(IdNumOrigen, FolioGuia, FolioEmb, IncidMarchamos, IncidTdasAnt);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0};{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string FinalizarCapturaMarchamo(int FolioGuia, int FolioEmb, Int16 NumCedis)
        {
            try
            {
                string finCaptura = dt.FinalizarCapturaMarchamo(FolioGuia, FolioEmb, NumCedis);

                return finCaptura;
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
                string pistola = dt.RegPistola(NumPistola, UserId, Operacion);

                return pistola;
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

        #region NGConfirmarTarima
        public string NombreCedis(int NumCedis)
        {
            try
            {
                DataSet ds = dt.NombreCedis(NumCedis);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string ValidaGuiaV02(int FolioGuia, Int16 NumCedis, Byte NumTerminal, Byte Valida, string NumTarima)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidaGuiaV02(FolioGuia, NumCedis, NumTerminal, Valida, NumTarima);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string ValidaTarima(int FolioGuia, Int16 NumCedis, Byte NumTerminal, string NumTarima, Byte Valida)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidaTarima(FolioGuia, NumCedis,NumTerminal, NumTarima, Valida);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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
        
        public string InsertaTarima(int FolioGuia, Int16 NumCedis, string NumTarima, Byte EdoTarima, Byte BitAuditar, Byte NumTerminal)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.InsertaTarima(FolioGuia, NumCedis, NumTarima, EdoTarima, BitAuditar, NumTerminal);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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
        
        public string CalcularFaltanteGuia(int Enviado, int CantidadConfirmada)
        {
            try
            {
                DataSet ds = dt.CalcularFaltanteGuia(Enviado, CantidadConfirmada);

                return ds.Tables[0].Rows[0][0].ToString();
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
        
        public string CierraTarima(int FolioGuia, Int16 NumCedis, Byte NumTerminal)
        {
            try
            {
                string resultado = dt.CierraTarima(FolioGuia, NumCedis, NumTerminal);

                return resultado;
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

        public System.Collections.Hashtable ComboEstadoTarima()
        {
            DataSet ds = dt.ComboEstatusTarima();
            System.Collections.Hashtable lista = new System.Collections.Hashtable();

            string res = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(row[0].ToString().Trim(), row[1].ToString().Trim());
                //res = res + " " + row[0].ToString().Trim() + ".-" + row[1].ToString().Trim();
            }

            return lista;
        }
        
        public int ValidaAutorizacion()
        {
            try
            {
                int resultado = dt.ValidaAutorizacion();

                return resultado;
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

        public string LoginAutoriza(string CveLote)
        {
            try
            {
                DataSet ds = dt.LoginAutoriza(CveLote);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        #region NGRegistroMercanciaIncidencia
        public string IngresaCodigo(int FolioGuia, int NumCedis, decimal CodBarra, string CosSobr)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.IngresaCodigo(FolioGuia,NumCedis,CodBarra,CosSobr);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string InsertaTarimaRecConfV2(int FolioGuia, int NumTransf, decimal CodBarra, int NumCedis, decimal CapacidadEmpaque, int UniVtaMalEdo, Byte EdoBulto, Byte NumAreaEsMcia, Byte CnscFolEsMcia, int FolEsMcia, Byte BitArtEnviado, string Accion, Byte NumMtvoMerma)
        {
            try
            {
                string result = dt.InsertaTarimaRecConfV2(FolioGuia, NumTransf, CodBarra, NumCedis, CapacidadEmpaque, UniVtaMalEdo, EdoBulto, NumAreaEsMcia, CnscFolEsMcia, FolEsMcia, BitArtEnviado, Accion, NumMtvoMerma);
            
                return result;
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
                string result = dt.GenMermasRec(FolioGuia,NumCedis);

                return result;
            }
            catch (SqlException ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    //return false;
                    return ex.Message;
                }
                throw ex;
            }
        }

        public System.Collections.Hashtable ComboEstadoBulto()
        {
            DataSet ds = dt.ComboEstatadoBulto();
            System.Collections.Hashtable lista = new System.Collections.Hashtable();

            string res = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(row[0].ToString().Trim(), row[1].ToString().Trim());
            }

            return lista;
        }

        public System.Collections.Hashtable ComboMotivo()
        {
            DataSet ds = dt.ComboMotivo();
            System.Collections.Hashtable lista = new System.Collections.Hashtable();

            string res = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(row[0].ToString().Trim(), row[1].ToString().Trim());
            }

            return lista;
        }
        #endregion

        #region NGSalidaTransportista
        public string ValidaGuiaSalida(Int16 NumCedis,int FolioGuia)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ValidaGuiaSalida(NumCedis, FolioGuia);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0};{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string DescripcionDestino(int NumDestino)
        {
            DataSet ds = dt.DescipcionDestino(NumDestino);

            try
            {
                return ds.Tables[0].Rows[0][0].ToString();
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

                throw ex;

            }
        }
       
        public string InsMarchamoSalida(int FolioEmbarque, string Marchamo)
        {
            try
            {
                string resultado = dt.InsMarchamoSalida(FolioEmbarque, Marchamo);

                return resultado;
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

        public string ImpFactFlete(Int16 NumCedis, int FolioGuia, string CveFactura, DateTime FechaFact, Decimal ImpTpaFlete, Decimal ImpIvaFact, Decimal ImpRetencion, Decimal FactTpaManiobras, Byte CumpleReqFiscal, Byte SinDocto)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ImpFactFlete(NumCedis, FolioGuia, CveFactura, FechaFact, ImpTpaFlete, ImpIvaFact, ImpRetencion, FactTpaManiobras, CumpleReqFiscal, SinDocto);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string SalidaYLibGuia(Int16 NumCedis, int FolioGuia, Int16 NumDestino, string CveFact, DateTime FecFact, Decimal ImpTpaFlete, Decimal ImpIvaFact, Decimal ImpRetencion, Decimal FactTpaManiobras, Byte CumpleReqFiscal, Byte SinDocto, int FolioEmbarque, int FolGuiaEmbEnsamb)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.SalidaYLibGuia(NumCedis, FolioGuia, NumDestino, CveFact, FecFact, ImpTpaFlete, ImpIvaFact, ImpRetencion, FactTpaManiobras, CumpleReqFiscal, SinDocto, FolioEmbarque, FolGuiaEmbEnsamb);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string ValidaFechaFactFlete(DateTime FechaFact)
        {
            try
            {
                string resultado = dt.ValidaFechaFactFlete(FechaFact);

                return resultado;
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

        public System.Collections.Hashtable ComboSinDcto()
        {
            DataSet ds = dt.ComboSinDcto();
            System.Collections.Hashtable lista = new System.Collections.Hashtable();

            string res = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(row[0].ToString().Trim(), row[1].ToString().Trim());
            }

            return lista;
        }

        public System.Collections.Hashtable ComboReqFiscales()
        {
            DataSet ds = dt.ComboReqFiscales();
            System.Collections.Hashtable lista = new System.Collections.Hashtable();

            string res = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(row[0].ToString().Trim(), row[1].ToString().Trim());
            }

            return lista;
        }
        #endregion

        #region NGCerrarEmbarque
        public string ArtConfDanado(Int16 NumCedis, int FolioEmbarque)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = dt.ArtConfDanado(NumCedis, FolioEmbarque);
                if (ds.Tables.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
                    {
                        ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(column =>
                        {
                            stringBuilder.AppendFormat("{0}:{1}, ", column.ColumnName, dataRow[column]);
                        });
                        stringBuilder.Append(Environment.NewLine);
                    });
                    return stringBuilder.ToString();
                }
                else
                { return null; }
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

        public string UpdArtConfDanado(Int16 NumCedis, int FolEmb, int FolGuiaEmb, Byte NumArea, Byte ConscFolioMcia, int FolioMcia, int NumTransf, int NumSKU, decimal CodBarra, decimal CantVtaMalEdo, Int16 UserId, Byte ConfirmaCant)
        {
            try
            {
                string result = dt.UpdArtConfDanado(NumCedis, FolEmb, FolGuiaEmb, NumArea, ConscFolioMcia, FolioMcia, NumTransf, NumSKU, CodBarra, CantVtaMalEdo, UserId, ConfirmaCant);

                return result;

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

        public string GenReclamacionEmb(Int16 NumCedis, int FolEmb, int FolGuiaEmb, Int16 UserId)
        {
            try
            {
                string result = dt.GenReclamacionEmb(NumCedis, FolEmb, FolGuiaEmb, UserId);

                return result;

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
