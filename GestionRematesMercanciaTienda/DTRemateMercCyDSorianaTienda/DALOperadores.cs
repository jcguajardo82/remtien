using System;
using System.Data;

using Soriana.FWK.Datos.SQL;
using System.Configuration;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DTApartadosSoriana.Apartados
{
    public class DALOperadores
    {
        public DALOperadores()
        {
            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
        }


        public DataSet ObtenerOperadoresList(string fechaIni, string fechaFin)
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@Id_Oper", null);
                parametros.Add("@Id_FEV_Turno", fechaIni);
                parametros.Add("@FSV_Turno", fechaFin);


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Apdo_sel_apOper", false, parametros);


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

        public DataSet ObtenerTurnosList()
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@Id_Num_TurnoOper", null);
                //parametros.Add("@Id_FEV_Turno", fechaIni);



                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Apdo_sel_apTurnoOper", false, parametros);


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

        public DataSet ComboTurnos()
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@keydown", 0);
                parametros.Add("@tipo", null);
                parametros.Add("@codigo", null);
                parametros.Add("@desc", null);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_dd_Turnos", false, parametros);


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

        public DataSet ComboOperadores()
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_fmk_GetOperador", false, parametros);


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

        
            public DataSet ComboOperadoresByUser(string userId)
        {
            DataSet ds = new DataSet();

            try
            {
              
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@us", userId);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_fmk_GetOperadorByUser", false, parametros);


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
        public void InsertaTurno(string descripcion, string abrev, string horaIni, string horaFin, string horaCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                int nexTurno = TurnosMaxId();

                parametros.Add("@TipoUpdate", "I");
                parametros.Add("@Id_Num_TurnoOper", nexTurno);
                parametros.Add("@Desc_TurnOOper", descripcion);
                parametros.Add("@Abrev_TurnoOper", abrev);
                parametros.Add("@HIni_TurnoOper", horaIni);
                parametros.Add("@HFin_TurnoOper", horaFin);
                parametros.Add("@HFin_CierreTurnoOper", horaCierre);
                parametros.Add("@vo_Id_Num_TurnoOper", nexTurno);
                parametros.Add("@vo_Desc_TurnOOper", descripcion);
                parametros.Add("@vo_Abrev_TurnoOper", abrev);
                parametros.Add("@vo_HIni_TurnoOper", horaIni);
                parametros.Add("@vo_HFin_TurnoOper", horaFin);
                parametros.Add("@vo_HFin_CierreTurnoOper", horaCierre);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_apdo_upd_apTurnoOper", false, parametros);


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

        public void ModificaTurno(string idTunrno, string descripcion, string abrev, string horaIni, string horaFin, string horaCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();


                parametros.Add("@TipoUpdate", "U");
                parametros.Add("@Id_Num_TurnoOper", idTunrno);
                parametros.Add("@Desc_TurnOOper", descripcion);
                parametros.Add("@Abrev_TurnoOper", abrev);
                parametros.Add("@HIni_TurnoOper", horaIni);
                parametros.Add("@HFin_TurnoOper", horaFin);
                parametros.Add("@HFin_CierreTurnoOper", horaCierre);
                parametros.Add("@vo_Id_Num_TurnoOper", idTunrno);
                parametros.Add("@vo_Desc_TurnOOper", descripcion);
                parametros.Add("@vo_Abrev_TurnoOper", abrev);
                parametros.Add("@vo_HIni_TurnoOper", horaIni);
                parametros.Add("@vo_HFin_TurnoOper", horaFin);
                parametros.Add("@vo_HFin_CierreTurnoOper", horaCierre);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_apdo_upd_apTurnoOper", false, parametros);


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

        public void EliminaTurno(string idTunrno, string descripcion, string abrev, string horaIni, string horaFin, string horaCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();


                parametros.Add("@TipoUpdate", "D");
                parametros.Add("@Id_Num_TurnoOper", idTunrno);
                parametros.Add("@Desc_TurnOOper", descripcion);
                parametros.Add("@Abrev_TurnoOper", abrev);
                parametros.Add("@HIni_TurnoOper", horaIni);
                parametros.Add("@HFin_TurnoOper", horaFin);
                parametros.Add("@HFin_CierreTurnoOper", horaCierre);
                parametros.Add("@vo_Id_Num_TurnoOper", idTunrno);
                parametros.Add("@vo_Desc_TurnOOper", descripcion);
                parametros.Add("@vo_Abrev_TurnoOper", abrev);
                parametros.Add("@vo_HIni_TurnoOper", horaIni);
                parametros.Add("@vo_HFin_TurnoOper", horaFin);
                parametros.Add("@vo_HFin_CierreTurnoOper", horaCierre);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_apdo_upd_apTurnoOper", false, parametros);


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

        public int TurnosMaxId()
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();


                DataSet ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Apdo_ctl_apTurnoOper", false, parametros);
                int re = 0;

                if (ds.Tables.Count > 0)
                {
                    re = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }

                return re;
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

        public DataSet ConsultaTurno(string idTurno)
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@Id_Num_TurnoOper", Convert.ToInt16(idTurno));
                //parametros.Add("@Id_FEV_Turno", fechaIni);



                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Apdo_sel_apTurnoOper", false, parametros);


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

        public void InsertaOperador(string IdApertura, string IdOperador, string IdTurno, string fEntrada, string fSalida, string fCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                int nexTurno = TurnosMaxId();

                #region parametros
                //@TipoUpdate = 'I'
                //, @Id_Oper = 1337
                //, @Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @FSV_Turno = '11-3-2016 23:0:0.000'
                //, @FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @UserId_Apertura = 2640
                //, @UserId_Cierre = null
                //, @Id_Num_StatusOper = 1
                //, @vo_Id_Oper = 1337
                //, @vo_Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @vo_FSV_Turno = '11-3-2016 23:0:0.000'
                //, @vo_FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @vo_UserId_Apertura = 2640
                //, @vo_UserId_Cierre = null
                //, @vo_Id_Num_StatusOper = 1
                #endregion

                parametros.Add("@TipoUpdate", "I");
                parametros.Add("@Id_Oper", IdOperador);
                parametros.Add("@Id_FEV_Turno", Convert.ToDateTime(fEntrada));
                parametros.Add("@FSV_Turno", Convert.ToDateTime(fSalida));
                parametros.Add("@FSV_CierreTurno", Convert.ToDateTime(fCierre));
                parametros.Add("@UserId_Apertura", IdApertura);
                parametros.Add("@UserId_Cierre", null);
                parametros.Add("@Id_Num_StatusOper", 1);
                parametros.Add("@vo_Id_Oper", null);
                parametros.Add("@vo_Id_FEV_Turno", null);
                parametros.Add("@vo_FSV_Turno", null);
                parametros.Add("@vo_FSV_CierreTurno", null);
                parametros.Add("@vo_UserId_Apertura", null);
                parametros.Add("@vo_UserId_Cierre", null);
                parametros.Add("@vo_Id_Num_StatusOper", null);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Apdo_upd_apOper", false, parametros);


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

        public void UpdateOperador(string IdApertura, string IdOperador, string IdTurno, string fEntrada, string fSalida, string fCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                int nexTurno = TurnosMaxId();

                #region parametros
                //@TipoUpdate = 'I'
                //, @Id_Oper = 1337
                //, @Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @FSV_Turno = '11-3-2016 23:0:0.000'
                //, @FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @UserId_Apertura = 2640
                //, @UserId_Cierre = null
                //, @Id_Num_StatusOper = 1
                //, @vo_Id_Oper = 1337
                //, @vo_Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @vo_FSV_Turno = '11-3-2016 23:0:0.000'
                //, @vo_FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @vo_UserId_Apertura = 2640
                //, @vo_UserId_Cierre = null
                //, @vo_Id_Num_StatusOper = 1
                #endregion

                parametros.Add("@TipoUpdate", "U");
                parametros.Add("@Id_Oper", IdOperador);
                parametros.Add("@Id_FEV_Turno", fEntrada);
                parametros.Add("@FSV_Turno", fSalida);
                parametros.Add("@FSV_CierreTurno", fCierre);
                parametros.Add("@UserId_Apertura", IdApertura);
                parametros.Add("@UserId_Cierre", null);
                parametros.Add("@Id_Num_StatusOper", 1);
                parametros.Add("@vo_Id_Oper", nexTurno);
                parametros.Add("@vo_Id_FEV_Turno", fEntrada);
                parametros.Add("@vo_FSV_Turno", fSalida);
                parametros.Add("@vo_FSV_CierreTurno", fCierre);
                parametros.Add("@vo_UserId_Apertura", IdApertura);
                parametros.Add("@vo_UserId_Cierre", null);
                parametros.Add("@vo_Id_Num_StatusOper", 1);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Apdo_upd_apOper", false, parametros);


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

        public void EliminarOperador(string IdApertura, string IdOperador, string IdTurno, string fEntrada, string fSalida, string fCierre)
        {
            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                int nexTurno = TurnosMaxId();

                #region parametros
                //@TipoUpdate = 'I'
                //, @Id_Oper = 1337
                //, @Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @FSV_Turno = '11-3-2016 23:0:0.000'
                //, @FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @UserId_Apertura = 2640
                //, @UserId_Cierre = null
                //, @Id_Num_StatusOper = 1
                //, @vo_Id_Oper = 1337
                //, @vo_Id_FEV_Turno = '11-3-2016 15:0:0.000'
                //, @vo_FSV_Turno = '11-3-2016 23:0:0.000'
                //, @vo_FSV_CierreTurno = '11-3-2016 23:30:0.000'
                //, @vo_UserId_Apertura = 2640
                //, @vo_UserId_Cierre = null
                //, @vo_Id_Num_StatusOper = 1
                #endregion

                parametros.Add("@TipoUpdate", "D");
                parametros.Add("@Id_Oper", IdOperador);
                parametros.Add("@Id_FEV_Turno", fEntrada);
                parametros.Add("@FSV_Turno", fSalida);
                parametros.Add("@FSV_CierreTurno", fCierre);
                parametros.Add("@UserId_Apertura", IdApertura);
                parametros.Add("@UserId_Cierre", null);
                parametros.Add("@Id_Num_StatusOper", 1);
                parametros.Add("@vo_Id_Oper", nexTurno);
                parametros.Add("@vo_Id_FEV_Turno", fEntrada);
                parametros.Add("@vo_FSV_Turno", fSalida);
                parametros.Add("@vo_FSV_CierreTurno", fCierre);
                parametros.Add("@vo_UserId_Apertura", IdApertura);
                parametros.Add("@vo_UserId_Cierre", null);
                parametros.Add("@vo_Id_Num_StatusOper", 1);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Apdo_upd_apOper", false, parametros);


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


        public DataSet ConsultaOperador(string idOperador,string fentrada,string fsalida)
        {
            DataSet ds = new DataSet();

            try
            {
                System.Collections.Hashtable parametros = new System.Collections.Hashtable();

                parametros.Add("@Id_Oper", idOperador);
                //parametros.Add("@FSV_Turno", Convert.ToDateTime(fentrada));
                //parametros.Add("@Id_FEV_Turno", Convert.ToDateTime(fsalida));


                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "sp_Apdo_Cap_apOper", false, parametros);


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
