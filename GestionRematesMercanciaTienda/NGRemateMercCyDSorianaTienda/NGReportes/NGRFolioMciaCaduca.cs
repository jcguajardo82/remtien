using EDReciboTiendaSoriana.Captura;
using EDReciboTiendaSoriana.EDReportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGReciboTiendaSoriana.NGReportes
{
    public class NGRFolioMciaCaduca
    {
        DTReciboTiendaSoriana.DTReportes.DTRFolioMciaCaduca dt = new DTReciboTiendaSoriana.DTReportes.DTRFolioMciaCaduca();

        public List<EDRConsultaListItem> ListArtRemProxCadEtapa(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "----SELECCIONE----";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListArtRemProxCadEtapa(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["DescOpc"].ToString();
                        item.Id = int.Parse(dr["IdOpc"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {                
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListCatRemProxCadEtapa(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            //item = new EDRConsultaListItem();
            //item.Descripcion = "----SELECCIONE----";
            //item.Id = -1;
            //cat.Add(item);

            try
            {

                ds = dt.ListCatRemProxCadEtapa(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Desc_Categ"].ToString();
                        item.Id = int.Parse(dr["Id_Num_Categ"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListCategoria(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "----SELECCIONE----";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListJefeDepto(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Nombre"].ToString();
                        item.Id = int.Parse(dr["Usuario"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListJefeProxCadEtapa(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "----SELECCIONE----";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListJefeProxCadEtapa(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Nombre"].ToString();
                        item.Id = int.Parse(dr["Usuario"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListRepJefe(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "----SELECCIONE----";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListRepJefeDepto(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Nombre"].ToString();
                        item.Id = int.Parse(dr["Usuario"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> iniciarComboRepJefeMerma(string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "----SELECCIONE----";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListRepJefeMerma(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Nombre"].ToString();
                        item.Id = int.Parse(dr["Usuario"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListFolios(string fecha, string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            //item = new EDRConsultaListItem();
            //item.Descripcion = "Seleccione";
            //item.Id = -1;
            //cat.Add(item);

            try
            {

                ds = dt.ListFolios(fecha, usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Fol_MciaCaduca"].ToString();
                        item.Id = int.Parse(dr["Id_Fol_MciaCaduca"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListFoliosAutorizar(string fecha, string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            //item = new EDRConsultaListItem();
            //item.Descripcion = "Seleccione";
            //item.Id = -1;
            //cat.Add(item);

            try
            {

                ds = dt.ListFoliosAutorizar(fecha, usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Fol_MciaCaduca"].ToString();
                        item.Id = int.Parse(dr["Id_Fol_MciaCaduca"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListFoliosRepCapMciaCaducar(string fecha)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();

            try
            {

                ds = dt.ListFoliosRepCapMciaCaducar(fecha);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Fol_MciaCaduca"].ToString();
                        item.Id = int.Parse(dr["DId_Fol_MciaCaduca"].ToString());

                        cat.Add(item);
                    }
                }
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListFoliosRepActaDestruccion(string fecha)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();

            try
            {

                ds = dt.ListFoliosRepDestruccionFolios(fecha);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["ActaDestruccion"].ToString();
                        item.Id = int.Parse(dr["Id_Num_ActaDestruccion"].ToString());

                        cat.Add(item);
                    }
                }
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListRepFolios(string fecha, string usuario)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            //item = new EDRConsultaListItem();
            //item.Descripcion = "Seleccione";
            //item.Id = -1;
            //cat.Add(item);

            try
            {

                ds = dt.ListRepFolios(fecha, usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Fol_MciaCaduca"].ToString();
                        item.Id = int.Parse(dr["Fol_MciaCaduca"].ToString());
                        //item.Id = int.Parse(dr["Id_Fol_MciaCaduca"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListFoliosReImpEtiqueta(string fecha)
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            //item = new EDRConsultaListItem();
            //item.Descripcion = "Seleccione";
            //item.Id = -1;
            //cat.Add(item);

            try
            {

                ds = dt.ListFoliosReImpEtiqueta(fecha);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Fol_MciaCaduca"].ToString();
                        item.Id = int.Parse(dr["Id_Fol_MciaCaduca"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //Llenar Grid de Mercancia segun el folio seleccionado.
        public List<EDRMerCadCap> LlenadoGridFolioMciaCad(string fecha, string folio)
        {
            EDRMerCadCap folios;
            List<EDRMerCadCap> listfolios = new List<EDRMerCadCap>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridFolioMciaCad(fecha, folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRMerCadCap();

                        folios.Numero = int.Parse(dr["Articulo"].ToString());
                        folios.CodigoBarra = dr["CodBarra"].ToString();
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
                throw ex;
            }
        }

        public List<EDRMerCadCap> LlenadoGridRepFolioMciaCad(string fecha, string folio)
        {
            EDRMerCadCap folios;
            List<EDRMerCadCap> listfolios = new List<EDRMerCadCap>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridRepFolioMciaCad(fecha, folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRMerCadCap();

                        folios.Cnsc = int.Parse(dr["Cnsc"].ToString());
                        folios.CodigoBarra = dr["CodigoBarra"].ToString();
                        folios.CodigoUnico = dr["CodigoUnico"].ToString();
                        folios.Descripcion = dr["Descripcion"].ToString();
                        folios.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        folios.Lote = dr["Lote"].ToString();
                        listfolios.Add(folios);
                    }
                }
                return listfolios;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        //public string LlenadoGridFolioMciaCad(string fecha, string folio)
        //{
        //    var data = dt.LlenadoGridFolioMciaCad(fecha, folio);
        //    return TablaFolioMciaCad(data.Tables[0]);
        //}
        //Obtener listado de Folios para Autorizar
        public List<EDRMerCadCap> ObtenerFoliosAutorizar(string usuario, string jefedepto, string fecha, string folio)
        {
            EDRMerCadCap folios;
            List<EDRMerCadCap> listfolios = new List<EDRMerCadCap>();
            DataSet ds = new DataSet();
            try
            {
                ds = dt.LlenadoGridFolioMciaCad(fecha, folio);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        folios = new EDRMerCadCap();

                        folios.Numero = int.Parse(dr["Numero"].ToString());
                        folios.CodigoBarra = dr["CodigoBarra"].ToString();
                        folios.CodigoUnicoSalida = dr["CodigoUnicoSalida"].ToString();
                        folios.Descripcion = dr["Descripcion"].ToString();
                        folios.FechaCaducidad = dr["FechaCaducidad"].ToString();
                        folios.Lote = dr["Lote"].ToString();

                        listfolios.Add(folios);
                    }
                }
                return listfolios;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public string AutorizarFolios(string folio)
        {
            try
            {
                return dt.AutorizarFolios(folio);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string CancelarFolios(string folio)
        {
            try
            {
                return dt.CancelarFolios(folio);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        public void GuardarFolioTablaPaso(string folio, string codigobarra, string cantCapturarada, string lote)
        {
            try
            {
                dt.GuardarFolioTablaPaso(folio, codigobarra, cantCapturarada, lote);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        public void NG_EliminaDetalleFolioTablaPaso(string folio)
        {
            try
            {
                dt.DT_EliminaDetalleFolioTablaPaso(folio);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private string TablaFolioMciaCad(DataTable dt)
        {
            try
            {


                if (dt == null || dt.Rows.Count <= 0) { return string.Empty; }

                StringBuilder html = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    html.AppendLine("<tr>");
                    string id = string.Empty;
                    foreach (DataColumn col in dt.Columns)
                    {
                        string valor = string.Empty;

                        switch (col.ColumnName.ToUpper())
                        {
                            case "ARTICULO":
                            case "DESCRIPCION":
                            case "LOTE":
                            case "FECHACADUCIDAD":
                            case "CANTPIEZAS":
                                valor = row[col.ColumnName].ToString();
                                break;
                        }

                        switch (col.ColumnName.ToUpper())
                        {
                            case "ARTICULO":
                            case "DESCRIPCION":
                            case "LOTE":
                            case "FECHACADUCIDAD":
                            case "CANTPIEZAS":
                                html.AppendLine("<td>" + valor + "</td>");
                                break;
                        }
                    }
                    //html.AppendLine("<td><button class=\"btn btn-danger btn-del\" id=" + id + " onclick=\"BorrarRowCat(this)\" >Eliminar</button></td>");
                    //html.AppendLine("<td><button class=\"btn btn-info btn-edit\"  data-toggle=\"modal\" data-target=\"#Editar\"  id=" + id + " onclick=\"EditarCategoria(this)\">Editar</button></td>");
                    //html.AppendLine("<td><button class=\"btn btn-primary btn-AddPorGuarda\"  data-toggle=\"modal\" data-target=\"#AddPorcentaje\"  id=" + id + " onclick=\"AgregarPorcentaje(this)\">Editar %</button></td>");
                    html.AppendLine("</tr>");
                }
                return html.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
