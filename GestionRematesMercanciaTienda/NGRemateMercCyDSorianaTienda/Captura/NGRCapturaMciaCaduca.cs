using EDReciboTiendaSoriana.Captura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace NGReciboTiendaSoriana.Captura
{
    public class NGRCapturaMciaCaduca
    {
        DTReciboTiendaSoriana.DTRCaptura.DTRCapturaGuardarMciaCaduca dalcat = new DTReciboTiendaSoriana.DTRCaptura.DTRCapturaGuardarMciaCaduca();
        public void GuardarCategoria(List<EDRConsultaCategoria> ListCat)
        {
            for (int i = 0; i < ListCat.Count; i++)
            {
                EDRConsultaCategoria item = new EDRConsultaCategoria();
                item.CveOperacion = ListCat[i].CveOperacion;
                item.TipoMcia = ListCat[i].TipoMcia;
                item.FmtoTienda = ListCat[i].FmtoTienda;
                item.Categoria = ListCat[i].Categoria;
                item.Periodicidad = ListCat[i].Periodicidad;
                item.DiaMes = ListCat[i].DiaMes;
                item.DiaSemana = ListCat[i].DiaSemana;
                item.DiaAviso = ListCat[i].DiaAviso;
                dalcat.GuardarCategoria(item);
            }
        }
        public void GuardarPorcPorCat(List<EDRConsultaPorcentaje> ListPor)
        {
            for (int i = 0; i < ListPor.Count; i++)
            {
                EDRConsultaPorcentaje item = new EDRConsultaPorcentaje();
                item.FmtoTienda = ListPor[i].FmtoTienda;
                item.TipoMcia = ListPor[i].TipoMcia;
                item.Categoria = ListPor[i].Categoria;
                item.DiaInicio = ListPor[i].DiaInicio;
                item.DiaFin = ListPor[i].DiaFin;
                item.RebajaVta = ListPor[i].RebajaVta;
                item.RebajaMerma = ListPor[i].RebajaMerma;                
                dalcat.GuardarPorcPorCat(item);
            }
        }

        public void BorrarPorcPorCat(EDRConsultaPorcentaje ListPor)
        {
            dalcat.GuardarPorcPorCat(ListPor);          
        }


        public string ObtenerCategHistElminadas(string FmtoTienda, string TipoBusquedad, string TipoMcia)
        {
            var data = dalcat.ObtenerCategHistElminadas(FmtoTienda, TipoBusquedad, TipoMcia);
            return TablaCategHist(data.Tables[0]);
        }

        //Obtiene los porcentajes para las categoria seleccionada.
        public string ObtenerCategPorcentaje(string FmtoTienda, string TipoBusquedad, string Categoria)
        {
            var data = dalcat.ObtenerCategPorcentaje(FmtoTienda, TipoBusquedad, Categoria);
            return TablaCategPorcentaje(data.Tables[0]);
        }
        //Obtiene las Categorias para llenar el grid
        public string LlenadoGridCategorias(string FmtoTienda, string TipoBusquedad, string Tipo_Mcia, string Usuario)
        {
            var data = dalcat.LlenadoGridCategorias(FmtoTienda, TipoBusquedad, Tipo_Mcia, Usuario);
            if(data.Tables.Count <= 0) { return string.Empty; }
            else { return TablaCategorias(data.Tables[0]);}           
        }
        public string ObtenerCategHistPorcentaje(string FmtoTienda, string TipoBusquedad, string TipoMcia, string RolCapturaHist)
        {
            var data = dalcat.ObtenerCategHistPorcentaje(FmtoTienda, TipoBusquedad, TipoMcia, RolCapturaHist);
            return TablaHistPorc(data.Tables[0]);
        }
        private string TablaCategHist(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) {  return string.Empty;  }
            StringBuilder html = new StringBuilder();
            /*
            html.AppendLine("<table class=\"table table-striped table-hover\">");

            html.AppendLine("<thead>");
            html.AppendLine("<tr >");

            html.AppendLine("<th>Categoria</th>");
            html.AppendLine("<th>Periodicidad:</th>");
            html.AppendLine("<th>Dia del Mes</th>");
            html.AppendLine("<th>Dia de la Semana</th>");
            html.AppendLine("<th>Dias de Aviso</th>");

            html.AppendLine("</tr>");
            html.AppendLine("</thead>");

            html.AppendLine("<tbody>");
            */
            string id = string.Empty;
            string desccat = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                html.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    string valor = string.Empty;
                    
                    switch (col.ColumnName.ToUpper())
                    {
                        case "ID_CNSC_ROLCAPTURAHIST":
                            id = row[col.ColumnName].ToString();
                            //valor = row[col.ColumnName].ToString();
                            break;                        
                        case "CATEG":
                            desccat = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "ID_NUM_CATEG":
                        case "ID_CVE_FMTO":                       
                        case "ID_NUM_PERIODICIDAD":
                        case "DESC_PERIODICIDAD":
                        case "DIAMES":
                        case "ID_DIASEMANA":
                        case "DIAS_AVISO":
                            valor = row[col.ColumnName].ToString();
                            break;

                    }

                    switch (col.ColumnName.ToUpper())
                    {
                        //case "ID_CNSC_ROLCAPTURAHIST":
                            //html.AppendLine("<td style='display:none;'>" + valor + "</td>");
                            //break;
                        case "CATEG":
                        case "DESC_PERIODICIDAD":
                        case "DIAMES":
                        case "ID_DIASEMANA":
                            html.AppendLine("<td>" + valor + "</td>");
                            break;
                        case "DIAS_AVISO":
                            html.AppendLine("<td>" + valor + "</td>");
                            html.AppendLine("<td><button class=\"btn btn-info btn-conporchist\" id=" + id + " onclick=\"BuscarPorcentajeHistoricoModal(" + id + ",'" + desccat + "' )\">Consultar</button></td>");
                            //html.AppendLine("<td><button class=\"btn btn-info btn-conporchist\"  data-toggle=\"modal\" data-target=\"#ConHistPorcModal\"  id=" + id + " onclick=\"BuscarPorcentajeHistoricoModal(" + id+ ",'" + desccat +"' )\">Consultar</button></td>");
                            break;
                    }
                    
                }
                html.AppendLine("</tr>");
            }
            /*
            html.AppendLine("</tbody>");

            html.AppendLine("</table>");
            */
            return html.ToString();
        }

        private string TablaCategHistorico(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) { return string.Empty; }
            StringBuilder html = new StringBuilder();
            html.AppendLine("<table class=\"table table-striped table-hover\">");

            html.AppendLine("<thead>");
            html.AppendLine("<tr >");

            html.AppendLine("<th>Categoria</th>");
            html.AppendLine("<th>Periodicidad:</th>");
            html.AppendLine("<th>Dia del Mes</th>");
            html.AppendLine("<th>Dia de la Semana</th>");
            html.AppendLine("<th>Dias de Aviso</th>");

            html.AppendLine("</tr>");
            html.AppendLine("</thead>");

            html.AppendLine("<tbody>");

            foreach (DataRow row in dt.Rows)
            {
                html.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    string valor = string.Empty;

                    switch (col.ColumnName.ToUpper())
                    {
                        case "CATEG":
                        case "ID_NUM_PERIODICIDAD":
                        case "DIAMES":
                        case "ID_DIASEMANA":
                        case "DIAS_AVISO":
                            valor = row[col.ColumnName].ToString();
                            break;

                    }

                    switch (col.ColumnName.ToUpper())
                    {
                        case "CATEG":
                        case "ID_NUM_PERIODICIDAD":
                        case "DIAMES":
                        case "ID_DIASEMANA":
                        case "DIAS_AVISO":
                            html.AppendLine("<td>" + valor + "</td>");
                            break;
                    }
                }
                html.AppendLine("</tr>");
            }
            html.AppendLine("</tbody>");

            html.AppendLine("</table>");
            return html.ToString();
        }

        private string TablaCategPorcentaje(DataTable dt)
        {
            StringBuilder html = new StringBuilder();

            if (dt == null || dt.Rows.Count <= 0) {
                html.Append("");
                //html.AppendLine("<table class=\"table table-striped table-hover\" id=\"tblCatPorc\">");

                //html.AppendLine("<thead>");
                //html.AppendLine("<tr >");

                //html.AppendLine("<th>De:</th>");
                //html.AppendLine("<th>A:</th>");
                //html.AppendLine("<th>% Remate</th>");
                //html.AppendLine("<th>% Merca</th>");
                //html.AppendLine("<th></th>");

                //html.AppendLine("</tr>");
                //html.AppendLine("</thead>");

                //html.AppendLine("<tbody>");
                //html.AppendLine("</tbody>");

                //html.AppendLine("</table>");
                return html.ToString();
            }
            /*
            html.AppendLine("<table class=\"table table-striped table-hover\" id=\"tblCatPorc\">");

            html.AppendLine("<thead>");
            html.AppendLine("<tr >");

            html.AppendLine("<th>Categoria</th>");
            html.AppendLine("<th>Periodicidad:</th>");
            html.AppendLine("<th>Dia del Mes</th>");
            html.AppendLine("<th>Dia de la Semana</th>");
            html.AppendLine("<th>Dias de Aviso</th>");

            html.AppendLine("</tr>");
            html.AppendLine("</thead>");

            html.AppendLine("<tbody>");
            */
            foreach (DataRow row in dt.Rows)
            {
                html.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    string valor = string.Empty;

                    switch (col.ColumnName.ToUpper())
                    {
                        //case "DIAINICIO":
                        case "DIAFIN":
                        case "PORCENTAJEREMATE":
                        case "PORCENTAJEMERMA":
                        case "ELIMINAR":
                            valor = row[col.ColumnName].ToString();
                            break;

                    }
                   
                    switch (col.ColumnName.ToUpper())
                    {
                        //case "DIAINICIO":
                        case "DIAFIN":
                        case "PORCENTAJEREMATE":
                        case "PORCENTAJEMERMA":                          
                            html.AppendLine("<td> <input class=\"form-control\"  value='" + valor + "' type='text' /></td>");
                            break;
                        case "ELIMINAR":
                            html.AppendLine("<td><button class=\"btn btn-danger btn-delPor\" >Eliminar</button></td>");
                            break;
                    }
                }
                html.AppendLine("</tr>");
            }
            //html.AppendLine("</tbody>");

            //html.AppendLine("</table>");

            return html.ToString();
        }
        //Obtiene la tabla de Categorias
        private string TablaCategorias(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) { return string.Empty; }

            StringBuilder html = new StringBuilder();
            StringBuilder html_aux = new StringBuilder();
            StringBuilder html_result = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                //html.AppendLine("<tr>");
                string id = string.Empty;
                string ftotienda = string.Empty;
                string tipomcia = string.Empty;
                string categoria = string.Empty;
                string period = string.Empty;
                string diames = string.Empty;
                string diasemana = string.Empty;
                string diaaviso = string.Empty;
                html = new StringBuilder();
                html_aux = new StringBuilder();
                foreach (DataColumn col in dt.Columns)
                {
                    string valor = string.Empty;
                    
                 
                    switch (col.ColumnName.ToUpper())
                    {

                        case "ID_CVE_FMTO":
                            ftotienda = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "ID_NUM_TIPOMCIA":
                            tipomcia = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "ID_NUM_CATEG":
                            categoria = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "ID_NUM_PERIODICIDAD":
                            period = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "CATEG":
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "DESC_PERIODICIDAD":
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "DIAMES":
                            diames = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "ID_DIASEMANA":
                            diasemana = row[col.ColumnName].ToString();
                            valor = row[col.ColumnName].ToString();
                            break;
                        case "DIAS_AVISO":
                            valor = row[col.ColumnName].ToString();
                            diaaviso = row[col.ColumnName].ToString();
                            //if (id == string.Empty)
                            //{
                            //    id = valor;
                            //}
                            //else
                            //{
                            //    id = id + "," + valor;
                            //}                            
                            break;

                    }

                    switch (col.ColumnName.ToUpper())
                    {
                        case "CATEG":
                        case "DESC_PERIODICIDAD":                        
                        case "DIAMES":
                        case "ID_DIASEMANA":
                        case "DIAS_AVISO":
                            html.AppendLine("<td>" + valor + "</td>");
                            break;
                    }
                }
               
                id = ftotienda + "," + tipomcia + "," + categoria + "," + period + "," + diames + "," + diasemana + "," + diaaviso;
                html_aux.AppendLine("<tr id='" + id + "' >");
                html.AppendLine("<td><button class=\"btn btn-danger btn-del\" id='" + id + "' onclick=\"BorrarRowCat(this)\" >Eliminar</button></td>");
                html.AppendLine("<td><button class=\"btn btn-info btn-edit\"  id='" + id + "' onclick=\"EditarCategoria(this)\">Editar</button></td>");
                html.AppendLine("<td><button class=\"btn btn-primary btn-AddPorGuarda\"  id='" + id + "' onclick=\"AgregarPorcentaje(this)\">Editar %</button></td>");
                //html.AppendLine("<td><button class=\"btn btn-info btn-edit\"  data-toggle=\"modal\" data-target=\"#Editar\"  id='" + id + "' onclick=\"EditarCategoria(this)\">Editar</button></td>");
                //html.AppendLine("<td><button class=\"btn btn-primary btn-AddPorGuarda\"  data-toggle=\"modal\" data-target=\"#AddPorcentaje\"  id='" + id + "' onclick=\"AgregarPorcentaje(this)\">Editar %</button></td>");
                html.AppendLine("</tr>");
                html_result.AppendLine(html_aux.ToString());
                html_result.AppendLine(html.ToString());
                
            }            
            return html_result.ToString();
        }

        private string TablaHistPorc(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) { return string.Empty; }
            StringBuilder html = new StringBuilder();
            
            html.AppendLine("<table class=\"table table-striped table-hover\">");

            html.AppendLine("<thead>");
            html.AppendLine("<tr >");

            html.AppendLine("<th>De</th>");
            html.AppendLine("<th>A:</th>");
            html.AppendLine("<th>% Remate</th>");
            html.AppendLine("<th>% Merma</th>");            

            html.AppendLine("</tr>");
            html.AppendLine("</thead>");

            html.AppendLine("<tbody>");
            
            string id = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                html.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    string valor = string.Empty;

                    switch (col.ColumnName.ToUpper())
                    {   
                        case "ID_CNSC_PCTREBAJA":
                        case "ID_CNSC_ROLCAPTURAHIST":
                        case "DIAINICIO":
                        case "DIAFIN":
                        case "PORCENTAJEREMATE":
                        case "PORCENTAJEMERMA":
                            valor = row[col.ColumnName].ToString();
                            break;
                    }

                    switch (col.ColumnName.ToUpper())
                    {
                        //case "ID_CNSC_PCTREBAJA":
                        //case "ID_CNSC_ROLCAPTURAHIST":
                        case "DIAINICIO":
                        case "DIAFIN":
                        case "PORCENTAJEREMATE":
                        case "PORCENTAJEMERMA":
                            html.AppendLine("<td>" + valor + "</td>");
                            break;
                    }

                }
                html.AppendLine("</tr>");
            }
            
            html.AppendLine("</tbody>");

            html.AppendLine("</table>");
            
            return html.ToString();
        }

    }
}
