using EDReciboTiendaSoriana.EDReportes;
using EDSalidaMercanciaDevDanSorianaTienda.EDPorcentajeRemates;
//using EDSeguridadSoriana.EDReportes;
using Microsoft.Reporting.WebForms;

using Soriana.FWK.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace NGReciboTiendaSoriana.NGReportes
{
    public class NGReportes
    {
        DTReciboTiendaSoriana.DTReportes.DTReportes dt = new DTReciboTiendaSoriana.DTReportes.DTReportes();
        DTSalidaMercanciaDevDanSorianaTienda.DTPorcentajeRemates.DTPorcentajeRemates dt2 = new DTSalidaMercanciaDevDanSorianaTienda.DTPorcentajeRemates.DTPorcentajeRemates();

        #region combos
        /// <summary>
        /// Lista de reportes de Recibo de Mecanc­a x Autorizar
        /// </summary>
        /// <param name="Nombre_Rpt"></param>
        /// <param name="Criterio_Rpt"></param>
        /// <param name="Preview_Rpt"></param>
        /// <param name="Object_Rpt"></param>
        /// <returns></returns>
        public List<rpts_rec_mciaxaut> NG_rpts_rec_mciaxautList(string Nombre_Rpt, string Criterio_Rpt, string Preview_Rpt, string Object_Rpt)
        {
            try
            {
                DataSet ds = dt.Dt_rpts_rec_mciaxaut(Nombre_Rpt, Criterio_Rpt, Preview_Rpt, Object_Rpt);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<rpts_rec_mciaxaut>();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keydown">Determina si se oprimio una tecla</param>
        /// <param name="tipo">Tipo de dato del codigo</param>
        /// <param name="codigo">C¢digo a buscar</param>
        /// <param name="desc">Descripci¢n a buscar</param>
        /// <returns></returns>
        public List<Rec_dd_area> NG_Rec_dd_area(bool keydown, int tipo, int? codigo, string desc)
        {

            try
            {
                DataSet ds = dt.DT_Rec_dd_area(keydown, tipo, codigo, desc);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rec_dd_area>();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
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
        public List<Rpt_CartaRecl_Crit> NG_Rpt_CartaRecl_Crit(bool keydown, int tipo, int? codigo, string desc)
        {

            try
            {
                DataSet ds = dt.Dt_Rpt_CartaRecl_Crit(keydown, tipo, codigo, desc);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_CartaRecl_Crit>();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DatosGenerales
        /// <summary>
        /// Datos Generales para los Reportes ,Se utiliza en Consultas Gerenciales ( Telxon )
        /// </summary>
        /// <param name="IdNumAplicacion"></param>
        /// <param name="Titulo"></param>
        /// <param name="SubTitulo"></param>
        /// <param name="Fec_Elabora"></param>
        /// <returns></returns>
        public List<Rpt_DatosGrales_Aplic> NG_Rpt_DatosGrales_Aplic(int IdNumAplicacion, string Titulo, string SubTitulo, DateTime Fec_Elabora)
        {
            try
            {
                DataSet ds = dt.DT_Rpt_DatosGrales_Aplic(IdNumAplicacion, Titulo, SubTitulo, Fec_Elabora);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_DatosGrales_Aplic>();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Cargos x Devolución



        public void NG_RptCargoPorDevolucion(ref ReportViewer reporte)
        {
            try
            {

            
            var DatosGenerales = NG_Rpt_DatosGrales_Aplic(8, "Cargo por Devolución", "", DateTime.Now);
            #region Databind Reporte
            reporte.LocalReport.DataSources.Clear();

            Microsoft.Reporting.WebForms.ReportDataSource rdsDatosGenerales = new ReportDataSource("DatosGenerales", DatosGenerales);
           
            //reporte.LocalReport.SetParameters(p1);
            reporte.LocalReport.DataSources.Add(rdsDatosGenerales);

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

        /// <summary>
        /// Reporte de Cargos x Devolucion, Reporte de Lista de Empaque, Reporte de Cartas de Reclamacion a Bodega,Transportista y Seguro
        /// </summary>
        /// <param name="IdNumAreaESMcia">Area de ES de Mercancia</param>
        /// <param name="IdCnscFolESMcia">Foliador de Devoluciones</param>
        /// <param name="IdFolESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public List<Rpt_CargoDev> NG_Rpt_CargoDev(int IdNumAreaESMcia, int IdCnscFolESMcia, int IdFolESMcia)
        {
            try
            {
                DataSet ds = dt.Dt_Rpt_CargoDev(IdNumAreaESMcia, IdCnscFolESMcia, IdFolESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_CargoDev>();
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
        /// <summary>
        ///  Reporte de Lista de Empaque (Movimientos realizados)
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public List<Rpt_lista_emp_mov> NG_Rpt_lista_emp_mov(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
           
            try
            {
                DataSet ds = dt.Dt_Rpt_lista_emp_mov(pi_Id_Num_AreaESMcia, pi_Id_Cnsc_FolESMcia, pi_Id_Fol_ESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_lista_emp_mov>();
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
        /// <summary>
        /// Selecciona la leyenda del reporte
        /// </summary>
        /// <returns></returns>
        public List<leyenda_cargoxdev> NG_leyenda_cargoxdev()
        {
           
            try
            {

                DataSet ds = dt.Dt_leyenda_cargoxdev();
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<leyenda_cargoxdev>();
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
        /// <summary>
        /// Selecciona la leyenda del reporte
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public List<leyenda_lista_emp> NG_leyenda_lista_emp(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
           
            try
            {
                DataSet ds = dt.Dt_leyenda_lista_emp(pi_Id_Num_AreaESMcia, pi_Id_Cnsc_FolESMcia, pi_Id_Fol_ESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<leyenda_lista_emp>();
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
        /// <summary>
        /// Despliega el pie de pÿgina para el reporte de Cargos por Devoluci›n
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia">Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de Devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de Nota de la Devoluci›n</param>
        /// <returns></returns>
        public List<pie_carxdev> NG_pie_carxdev(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
            
            try
            {
                DataSet ds = dt.Dt_pie_carxdev(pi_Id_Num_AreaESMcia, pi_Id_Cnsc_FolESMcia, pi_Id_Fol_ESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<pie_carxdev>();
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
        /// <summary>
        ///  Reporte de Cargos x Devolucion (Articulos)
        /// </summary>
        /// <param name="IdNumAreaESMcia">Area de ES de Mercancia</param>
        /// <param name="IdCnscFolESMcia">Foliador de devoluciones</param>
        /// <param name="IdFolESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public List<Rpt_CargoDev_Art> NG_Rpt_CargoDev_Art(int IdNumAreaESMcia, int IdCnscFolESMcia, int IdFolESMcia)
        {
        
            try
            {
                DataSet ds = dt.Dt_Rpt_CargoDev_Art(IdNumAreaESMcia, IdCnscFolESMcia, IdFolESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_CargoDev_Art>();
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
        /// <summary>
        /// Obtiene el detalle de los bultos a devolver al transportista
        /// </summary>
        /// <param name="pi_Id_Num_AreaESMcia"> Area de ES de Mercancia</param>
        /// <param name="pi_Id_Cnsc_FolESMcia">Foliador de devoluciones</param>
        /// <param name="pi_Id_Fol_ESMcia">Folio de la Devolucion</param>
        /// <returns></returns>
        public List<Rpt_CargoDev_Bultos> NG_Rpt_CargoDev_Bultos(int pi_Id_Num_AreaESMcia, int pi_Id_Cnsc_FolESMcia, int pi_Id_Fol_ESMcia)
        {
           
            try
            {
                DataSet ds = dt.Dt_Rpt_CargoDev_Bultos(pi_Id_Num_AreaESMcia, pi_Id_Cnsc_FolESMcia, pi_Id_Fol_ESMcia);
                if (ds.Tables.Count > 0)
                {
                    //agregar para columnas sin nombre en SPs
                    //foreach (DataTable table in Seguridad.Tables)
                    //{
                    //    table.Columns[0].ColumnNEDTipoExhibicioname = "Nombre de la Columna";
                    //}
                    return ds.Tables[0].ToList<Rpt_CargoDev_Bultos>();
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

        #endregion

        #region Filtros 

        #endregion

        #region Reportes BGH
        public List<EDRMerCadCap> LlenadoGridCapturaMercancíaCaducar(string folio)
        {
            EDRMerCadCap folios;
            List<EDRMerCadCap> listfolios = new List<EDRMerCadCap>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridCapturaMercancíaCaducar(folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRMerCadCap();

                        folios.Articulo = dr["Articulo"].ToString();
                        folios.Descripcion = dr["Descripcion"].ToString();
                        folios.Lote = dr["Lote"].ToString();
                        folios.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        folios.CantPiezas = int.Parse(dr["CantPiezas"].ToString());
                        listfolios.Add(folios);
                    }
                }
                return listfolios;
            }
            catch (System.Exception ex)
            {
                return listfolios;
                throw ex;
            }
        }

        public List<EDRMerCadCap> LlenadoGridActaDestruccion(string folio)
        {
            EDRMerCadCap folios;
            List<EDRMerCadCap> listfolios = new List<EDRMerCadCap>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridActaDestruccion(folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRMerCadCap();

                        folios.Depto = dr["Depto"].ToString();
                        folios.jefeDpto = dr["jefeDpto"].ToString();
                        folios.Articulo = dr["Articulo"].ToString();
                        folios.Descripcion = dr["Descripcion"].ToString();
                        folios.Lote = dr["Lote"].ToString();
                        folios.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        folios.CantTeorica = int.Parse(dr["CantTeorica"].ToString());
                        folios.CantMerma = int.Parse(dr["CantMerma"].ToString());
                        folios.CantAjustar = int.Parse(dr["CantAjustar"].ToString());

                        listfolios.Add(folios);
                    }
                }
                return listfolios;
            }
            catch (System.Exception ex)
            {
                return listfolios;
                throw ex;
            }
        }

        public List<EDRArtRemVen> LlenadoGridArtRemVencidos(string fecha)
        {
            EDRArtRemVen folios;
            List<EDRArtRemVen> listfolios = new List<EDRArtRemVen>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridArtRemVencidos(fecha);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRArtRemVen();

                        folios.Cnsc = int.Parse(dr["Cnsc"].ToString());
                        folios.CodigoBarra = dr["CodigoBarra"].ToString();
                        folios.CodigoUnico = dr["CodigoUnico"].ToString();
                        folios.Descripcion = dr["Descripcion"].ToString();
                        folios.Lote = dr["Lote"].ToString();
                        folios.Precio = decimal.Parse(dr["Precio"].ToString());
                        folios.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        folios.FechaCaptura = dr["FechaCaptura"].ToString();
                        folios.DiasAntes = int.Parse(dr["DiasAntes"].ToString());
                        folios.Etapa = int.Parse(dr["Etapa"].ToString());
                        folios.RangoIni = int.Parse(dr["RangoIni"].ToString());
                        folios.RangoFinal = int.Parse(dr["RangoFinal"].ToString());
                        folios.PorcOfta = int.Parse(dr["PorcOfta"].ToString());
                        folios.PorcAfecta = int.Parse(dr["PorcAfecta"].ToString());
                        folios.ImpAfecta = decimal.Parse(dr["ImpAfecta"].ToString());
                        folios.FolioAfecta = int.Parse(dr["FolioActa"].ToString());
                        listfolios.Add(folios);
                    }
                }
                return listfolios;
            }
            catch (System.Exception ex)
            {
                return listfolios;
                throw ex;
            }
        }

        public EDRArtRemProxCaducarEtapa LlenadoGridArtRemProxCadEtapa(string usuario, string categoria, string opcion, string fecha)
        {
            EDRArtRemProxCaducarEtapa folios;
            EDRArtRemProxCaducarEtapaTitulos titulo;
            EDRArtRemProxCaducarEtapaDetalle detalle;
            EDRArtRemProxCaducarEtapa listfolios = new EDRArtRemProxCaducarEtapa();
            List<EDRArtRemProxCaducarEtapaTitulos> listtitulo = new List<EDRArtRemProxCaducarEtapaTitulos>();
            List<EDRArtRemProxCaducarEtapaDetalle> listdetalle = new List<EDRArtRemProxCaducarEtapaDetalle>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridArtRemProxCadEtapa(usuario, categoria, opcion, fecha);
                DataTable tableTitulos = ds.Tables[0];
                DataTable tableDetalle = ds.Tables[1];

                foreach (DataRow dr in tableTitulos.Rows)
                {
                    folios = new EDRArtRemProxCaducarEtapa();
                    titulo = new EDRArtRemProxCaducarEtapaTitulos();

                    titulo.Titulo = dr["Titulo"].ToString();
                    titulo.TituloEtapa = dr["TituloEtapa"].ToString();
                    listtitulo.Add(titulo);
                    //folios.Titulo = listtitulo;
                    //listfolios.Add(folios);
                }
                listfolios.Titulo = listtitulo;
                foreach (DataRow dr in tableDetalle.Rows)
                {
                    folios = new EDRArtRemProxCaducarEtapa();
                    detalle = new EDRArtRemProxCaducarEtapaDetalle();

                    detalle.Cnsc = int.Parse(dr["Id_Cnsc"].ToString());
                    detalle.CodigoBarra = dr["Id_Num_CodBarraOrig"].ToString();
                    detalle.CodigoRemate = dr["Id_Num_CodRemate"].ToString();
                    detalle.CodigoUnico = dr["Id_Num_SKUOrig"].ToString();
                    detalle.Descripcion = dr["Desc_ArtRemate"].ToString();
                    detalle.Lote = dr["Lote"].ToString();
                    detalle.FechaCaptura = dr["FechaCaptura"].ToString();
                    detalle.FechaCaducidad = dr["FechaCaducidad"].ToString();
                    detalle.DiasAntesCap = dr["DiasAntesCap"].ToString();
                    detalle.FechaDia = dr["FechaDia"].ToString();
                    detalle.DiasAntesActCap = dr["DiasAntesAct"].ToString();
                    detalle.EtapaActual = int.Parse(dr["EtapaActual"].ToString());
                    detalle.PorcDcto = decimal.Parse(dr["PorcDcto"].ToString());
                    detalle.PrecioOrigen = decimal.Parse(dr["PrecioOrigen"].ToString());
                    detalle.Dcto = decimal.Parse(dr["Dcto"].ToString());
                    detalle.PrecioRem = decimal.Parse(dr["PrecioRem"].ToString());
                    listdetalle.Add(detalle);
                    //folios.Detalle = listdetalle;
                    //listfolios.Add(folios);                
                }
                listfolios.Detalle = listdetalle;
                return listfolios;
            }
            catch (System.Exception ex)
            {
                return listfolios;
                throw ex;
            }
        }

        //public List<EDRArtRemProxCaducarEtapa> LlenadoGridArtRemProxCadEtapa(string usuario, string categoria, string opcion, string fecha)
        //{
        //    EDRArtRemProxCaducarEtapa folios;
        //    EDRArtRemProxCaducarEtapaTitulos titulo;
        //    EDRArtRemProxCaducarEtapaDetalle detalle;
        //    List<EDRArtRemProxCaducarEtapa> listfolios = new List<EDRArtRemProxCaducarEtapa>();
        //    List<EDRArtRemProxCaducarEtapaTitulos> listtitulo = new List<EDRArtRemProxCaducarEtapaTitulos>();
        //    List<EDRArtRemProxCaducarEtapaDetalle> listdetalle = new List<EDRArtRemProxCaducarEtapaDetalle>();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = dt.LlenadoGridArtRemProxCadEtapa(usuario, categoria, opcion, fecha);
        //        DataTable tableTitulos = ds.Tables[0];
        //        DataTable tableDetalle = ds.Tables[1];

        //        foreach (DataRow dr in tableTitulos.Rows)
        //        {
        //            folios = new EDRArtRemProxCaducarEtapa();
        //            titulo = new EDRArtRemProxCaducarEtapaTitulos();

        //            titulo.Titulo = dr["Titulo"].ToString();
        //            titulo.TituloEtapa = dr["TituloEtapa"].ToString();
        //            listtitulo.Add(titulo);
        //            folios.Titulo = listtitulo;
        //            listfolios.Add(folios);
        //        }
        //        foreach (DataRow dr in tableDetalle.Rows)
        //        {
        //            folios = new EDRArtRemProxCaducarEtapa();
        //            detalle = new EDRArtRemProxCaducarEtapaDetalle();

        //            detalle.Cnsc = int.Parse(dr["Id_Cnsc"].ToString());
        //            detalle.CodigoBarra = dr["Id_Num_CodBarraOrig"].ToString();
        //            detalle.CodigoRemate = dr["Id_Num_CodRemate"].ToString();
        //            detalle.CodigoUnico = dr["Id_Num_SKUOrig"].ToString();
        //            detalle.Descripcion = dr["Desc_ArtRemate"].ToString();
        //            detalle.Lote = dr["Lote"].ToString();
        //            detalle.FechaCaptura = dr["FechaCaptura"].ToString();                    
        //            detalle.FechaCaducidad = dr["FechaCaducidad"].ToString();
        //            detalle.DiasAntesCap = dr["DiasAntesCap"].ToString();
        //            detalle.FechaDia = dr["FechaDia"].ToString();
        //            detalle.DiasAntesActCap = dr["DiasAntesAct"].ToString();
        //            detalle.EtapaActual = int.Parse(dr["EtapaActual"].ToString());
        //            detalle.PorcDcto = decimal.Parse(dr["PorcDcto"].ToString());
        //            detalle.PrecioOrigen = decimal.Parse(dr["PrecioOrigen"].ToString());
        //            detalle.Dcto = decimal.Parse(dr["Dcto"].ToString());
        //            detalle.PrecioRem = decimal.Parse(dr["PrecioRem"].ToString());
        //            listdetalle.Add(detalle);
        //            folios.Detalle = listdetalle;
        //            //listfolios.Add(folios);                
        //        }

        //        return listfolios;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return listfolios;
        //        throw ex;
        //    }
        //}

        public List<EDRMerma> LlenadoGridMerma(string fecha, string usuario)
        {
            EDRMerma merma;
            List<EDRMerma> listmerma = new List<EDRMerma>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridMerma(fecha, usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        merma = new EDRMerma();

                        merma.SKU = dr["Id_Num_SKU"].ToString();
                        merma.CodInterno = dr["CodigoInterno"].ToString();
                        merma.Descripcion = dr["descripcion"].ToString();
                        merma.Lote= dr["Lote"].ToString();
                        merma.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        merma.DiasVencidos = dr["DiasVencidos"].ToString();
                        merma.Existencia = dr["Existencia"].ToString();
                        listmerma.Add(merma);
                    }
                }
                return listmerma;
            }
            catch (System.Exception ex)
            {
                return listmerma;
                throw ex;
            }
        }

        public List<EDRReimpresionEtiqueta> LlenadoGridReimpresionEtiqueta(string fecha, string folio)
        {
            EDRReimpresionEtiqueta etiqueta;
            List<EDRReimpresionEtiqueta> listetiqueta = new List<EDRReimpresionEtiqueta>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridReimpresionEtiqueta(fecha, folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        etiqueta = new EDRReimpresionEtiqueta();

                        etiqueta.Articulo = dr["Articulo"].ToString();
                        etiqueta.CodInterno = dr["CodigoInterno"].ToString();
                        etiqueta.Descripcion = dr["descripcion"].ToString();
                        etiqueta.Lote = dr["Lote"].ToString();
                        etiqueta.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        etiqueta.CantPiezas = int.Parse(dr["CantPiezas"].ToString());
                        etiqueta.BitConfirmar = dr["BitConfirmar"].ToString();
                        etiqueta.CantConfirmada = int.Parse(dr["CantConfirmada"].ToString());
                        etiqueta.FechaCad = dr["FechaCad"].ToString();
                        etiqueta.Dias_Vmto = int.Parse(dr["Dias_Vmto"].ToString());
                        etiqueta.UN = int.Parse(dr["UN"].ToString());
                        etiqueta.Fmto = dr["Fmto"].ToString();
                        etiqueta.SKU = dr["IdSku"].ToString();
                        listetiqueta.Add(etiqueta);
                    }
                }
                return listetiqueta;
            }
            catch (System.Exception ex)
            {
                return listetiqueta;
                throw ex;
            }
        }

        #endregion

        #region ActaDestruccion
        public void Rpt_ActaDestruccion(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {

            try
            {

                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt.rptActaDestruccion_r2(ReqDatosGenerales);
                DataSet ds3 = dt.rptActaDestruccion_r3(ReqDatosGenerales);
                DataSet ds4 = dt.rptActaDestruccion_r4(ReqDatosGenerales);

                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<reporte2> lstResumen_R2 = new List<reporte2>();
                List<reporte3> lstResumen_R3 = new List<reporte3>();
                List<reporte4> lstResumen_R4 = new List<reporte4>();

                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario = ReqDatosGenerales.impreso_Por;
                }
                if (ds2.Tables.Count > 0)
                    lstResumen_R2 = ds2.Tables[0].ToList<reporte2>();
                if (ds3.Tables.Count > 0)
                    lstResumen_R3 = ds3.Tables[0].ToList<reporte3>();
                if (ds4.Tables.Count > 0)
                    lstResumen_R4 = ds4.Tables[0].ToList<reporte4>();
                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);
                ReportDataSource Rep3 = new ReportDataSource("Rep3", lstResumen_R3);
                ReportDataSource Rep4 = new ReportDataSource("Rep4", lstResumen_R4);
                //ReportParameter pImpresoPor = new ReportParameter("ImpresoPor", ImpresoPor);

                //reporte.LocalReport.SetParameters(pImpresoPor);
                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);
                reporte.LocalReport.DataSources.Add(Rep3);
                reporte.LocalReport.DataSources.Add(Rep4);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mermas
        public void Rpt_Mermas(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {

            try
            {

                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt.rptMermas_Detalle(ReqDatosGenerales);

                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<Mermas_Detalle> lstResumen_R2 = new List<Mermas_Detalle>();

                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario = ReqDatosGenerales.impreso_Por;
                }
                if (ds2.Tables.Count > 0)
                {

                    foreach (DataTable table in ds2.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Mermas_Detalle lista = new Mermas_Detalle();
                            lista.Id_Num_SKU = Convert.ToDecimal(row["Id_Num_SKU"].ToString());
                            lista.CodigoInterno = Convert.ToDecimal( row["CodigoInterno"].ToString());
                            lista.descripcion = row["descripcion"].ToString();
                            lista.Lote = row["Lote"].ToString();
                            lista.FechaCaducidad = row["FechaCaducidad"].ToString();
                            lista.DiasVencidos = Convert.ToInt32(row["DiasVencidos"].ToString());
                            lista.Existencia = Convert.ToInt32(row["Existencia"].ToString());
                            lista.FechaConsulta = Convert.ToDateTime( ReqDatosGenerales.FechaConsulta);
                            lista.Usuario = ReqDatosGenerales.Nombre_Usuario;

                            lstResumen_R2.Add(lista);
                        }
                    }

                }
                    //lstResumen_R2 = ds2.Tables[0].ToList<Mermas_Detalle>();

                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);
                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet NGGeneraMermasMasivo(string Fecha, int Jefe)
        {
            try
            {
                DataSet ds = dt.DTGeneraMermasMasivo(Fecha, Jefe);
                if (ds.Tables.Count > 0)
                { return ds; }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ArtProxCadEtapa
        public void Rpt_ArtProxCadEtapa(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {

            try
            {

                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt.rptArtProxCadEtapa_Detalle(ReqDatosGenerales);

                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<ArtProxCadEtapa_Rs1> lstResumen_R2 = new List<ArtProxCadEtapa_Rs1>();
                List<ArtProxCadEtapa_Rs2> lstResumen_R3 = new List<ArtProxCadEtapa_Rs2>();

                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario = ReqDatosGenerales.impreso_Por;
                }
                if (ds2.Tables.Count > 0)
                {
                    lstResumen_R2 = ds2.Tables[0].ToList<ArtProxCadEtapa_Rs1>();
                    #region Mapeo
                    foreach (var row in lstResumen_R2)
                    {

                        row.Categoria= ReqDatosGenerales.Nombre_Categoria;
                        row.Vencimiento = ReqDatosGenerales.Nombre_Vencimiento;
                        row.Jefe = ReqDatosGenerales.Nombre_Usuario;

                    }
                    //foreach (DataTable table in ds2.Tables[1])
                    //{
                        foreach (DataRow row in ds2.Tables[1].Rows)
                        {
                            ArtProxCadEtapa_Rs2 lista = new ArtProxCadEtapa_Rs2();
                        lista.Id_Cnsc = Convert.ToInt32(row["Id_Cnsc"].ToString());
                        lista.Id_Num_CodBarraOrig = Convert.ToDecimal(row["Id_Num_CodBarraOrig"].ToString());
                        lista.Id_Num_CodRemate = Convert.ToDecimal(row["Id_Num_CodRemate"].ToString());
                        lista.Id_Num_SKUOrig = Convert.ToDecimal(row["Id_Num_SKUOrig"].ToString());
                        lista.Desc_ArtRemate = row["Desc_ArtRemate"].ToString();
                        lista.Lote = row["Lote"].ToString();
                        lista.FechaCaptura = row["FechaCaptura"].ToString();
                        lista.FechaCaducidad = row["FechaCaducidad"].ToString();
                        if(row["DiasAntesCap"].ToString()=="")
                        {
                            lista.DiasAntesCap = 0;
                        }
                        else
                        {
                            lista.DiasAntesCap = Convert.ToInt32(row["DiasAntesCap"].ToString());
                        }
                        lista.FechaDia = row["FechaDia"].ToString();
                        if(row["DiasAntesAct"].ToString()=="")
                        {
                            lista.DiasAntesAct = 0;
                        }
                        else
                        {
                            lista.DiasAntesAct = Convert.ToInt32(row["DiasAntesAct"].ToString());
                        }
                        if(row["EtapaActual"].ToString()=="")
                        {
                            lista.EtapaActual = 0;
                        }
                        else
                        {
                            lista.EtapaActual = Convert.ToInt32(row["EtapaActual"].ToString());
                        }

                        lista.PorcDcto = Convert.ToDecimal(row["PorcDcto"].ToString());
                        lista.PrecioOrigen = Convert.ToDecimal(row["PrecioOrigen"].ToString());
                        lista.Dcto = Convert.ToDecimal(row["Dcto"].ToString());
                        lista.PrecioRem = Convert.ToDecimal(row["PrecioRem"].ToString());

                        lstResumen_R3.Add(lista);

                        }
                    //}
                    #endregion
                }
                //lstResumen_R2 = ds2.Tables[0].ToList<Mermas_Detalle>();

                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);
                ReportDataSource Rep3 = new ReportDataSource("Rep3", lstResumen_R3);
                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);
                reporte.LocalReport.DataSources.Add(Rep3);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FolioMerCadCap
        public void Rpt_FolioMerCadCap(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {

            try
            {

                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt.rptFolMerCadCap(ReqDatosGenerales);

                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<FolioMerCadCap_Detalle> lstResumen_R2 = new List<FolioMerCadCap_Detalle>();

                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario = ReqDatosGenerales.impreso_Por;
                }
                if (ds2.Tables.Count > 0)
                {
                    lstResumen_R2 = ds2.Tables[0].ToList<FolioMerCadCap_Detalle>();
                    #region Mapeo
                    foreach (var row in lstResumen_R2)
                    {

                        row.Folio = ReqDatosGenerales.Id_Num_ActaDestruccion;
                        row.Jefe = ReqDatosGenerales.Nombre_Usuario;
                        row.Fecha = ReqDatosGenerales.FechaConsulta;

                    }
                    
                    #endregion
                }
                //lstResumen_R2 = ds2.Tables[0].ToList<Mermas_Detalle>();

                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);

                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ReporteCapturaMercancíaCaducar
        public void Rpt_CapturaMercancíaCaducar(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {

            try
            {

                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt.rptCapturaMercancíaCaducar_Enc(ReqDatosGenerales);
                DataSet ds3 = dt.rptCapturaMercancíaCaducar_Det(ReqDatosGenerales);

                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<ReporteCapturaMercancíaCaducar_Header> lstResumen_R2 = new List<ReporteCapturaMercancíaCaducar_Header>();
                List<ReporteCapturaMercancíaCaducar_Detalle> lstResumen_R3 = new List<ReporteCapturaMercancíaCaducar_Detalle>();
                
                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario = ReqDatosGenerales.impreso_Por;
                }
                if (ds2.Tables.Count > 0)
                    lstResumen_R2 = ds2.Tables[0].ToList<ReporteCapturaMercancíaCaducar_Header>();
                if (ds3.Tables.Count > 0)
                    lstResumen_R3 = ds3.Tables[0].ToList<ReporteCapturaMercancíaCaducar_Detalle>();
                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);
                ReportDataSource Rep3 = new ReportDataSource("Rep3", lstResumen_R3);
                //ReportParameter pImpresoPor = new ReportParameter("ImpresoPor", ImpresoPor);

                //reporte.LocalReport.SetParameters(pImpresoPor);
                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);
                reporte.LocalReport.DataSources.Add(Rep3);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SolucionesAsignadas
        public void Rpt_SolucionesAsignadas(reporteReq ReqDatosGenerales, ref ReportViewer reporte)
        {
            try
            {
                DataSet ds = dt.rptEncabezado(ReqDatosGenerales);
                DataSet ds2 = dt2.DT_UpTdagmd_Cns_SolGenyPendRepara2(ReqDatosGenerales);


                #region #Contenido
                List<header> lstDatosGrales = new List<header>();
                List<UpTdagmd_Cns_SolGenyPendRepara> lstResumen_R2 = new List<UpTdagmd_Cns_SolGenyPendRepara>();
                
                if (ds.Tables.Count > 0)
                    lstDatosGrales = ds.Tables[0].ToList<header>();
                foreach (var row in lstDatosGrales)
                {
                    row.Usuario =ReqDatosGenerales.impreso_Por;
                }

                if (ds2.Tables.Count > 0)
                    lstResumen_R2 = ds2.Tables[0].ToList<UpTdagmd_Cns_SolGenyPendRepara>();
                #endregion

                #region DataBind
                reporte.LocalReport.DataSources.Clear();

                ReportDataSource Rep1 = new ReportDataSource("Rep1", lstDatosGrales);
                ReportDataSource Rep2 = new ReportDataSource("Rep2", lstResumen_R2);
                //ReportParameter pImpresoPor = new ReportParameter("ImpresoPor", ImpresoPor);

                //reporte.LocalReport.SetParameters(pImpresoPor);
                reporte.LocalReport.DataSources.Add(Rep1);
                reporte.LocalReport.DataSources.Add(Rep2);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         #endregion
    }
}
