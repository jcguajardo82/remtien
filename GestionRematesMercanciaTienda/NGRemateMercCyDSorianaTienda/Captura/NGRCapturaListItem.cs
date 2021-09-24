using EDReciboTiendaSoriana.Captura;
using Soriana.FWK.Datos.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGReciboTiendaSoriana.Captura
{
    public class NGRCapturaListItem
    {
        DTReciboTiendaSoriana.DTRCaptura.DTRCapturaListItem dt = new DTReciboTiendaSoriana.DTRCaptura.DTRCapturaListItem();
        

        public List<EDRConsultaListGenerica> ListFmtoTienda(string usuario)
        {
            List<EDRConsultaListGenerica> fmtotienda = new List<EDRConsultaListGenerica>();
            EDRConsultaListGenerica item = new EDRConsultaListGenerica();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListGenerica();
            item.Descripcion = "Seleccione";
            item.Id = "-1";
            fmtotienda.Add(item);

            try
            {

                ds = dt.ListFmatoTienda(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListGenerica();

                        item.Descripcion = dr["Desc_Fmto"].ToString();
                        item.Id = dr["Id_Cve_Fmto"].ToString();

                        fmtotienda.Add(item);
                    }
                }
                verificator = 1;

               

                return fmtotienda;
            }
            catch (System.Exception ex)
            {

                verificator = -1;

                return fmtotienda;
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
            item.Descripcion = "Seleccione";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListCategoria(usuario);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Categ"].ToString();
                        item.Id = int.Parse(dr["Id_Num_Categ"].ToString());

                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {

                verificator = -1;

                return cat;
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListPeriodicidad()
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "Seleccione";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListPeriocidad();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Desc_Periodicidad"].ToString();
                        item.Id = int.Parse(dr["Id_Num_Periodicidad"].ToString());
                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {

                verificator = -1;

                return cat;
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListTipoMcia()
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;

            item = new EDRConsultaListItem();
            item.Descripcion = "Seleccione";
            item.Id = -1;
            cat.Add(item);

            try
            {

                ds = dt.ListTipoMcia();

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Desc_TipoMcia"].ToString();
                        item.Id = int.Parse(dr["Id_Num_TipoMcia"].ToString());
                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                verificator = -1;

                return cat;
                throw ex;
            }
        }

        public List<EDRConsultaListItem> ListDiasSemana()
        {
            List<EDRConsultaListItem> cat = new List<EDRConsultaListItem>();
            EDRConsultaListItem item = new EDRConsultaListItem();
            DataSet ds = new DataSet();
            int verificator = -1;
/*
            item = new EDRConsultaListItem();
            item.Descripcion = "Seleccione";
            item.Id = -1;
            cat.Add(item);
*/
            try
            {

                ds = dt.ListDiasSemana();

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        item = new EDRConsultaListItem();

                        item.Descripcion = dr["Descripcion"].ToString();
                        item.Id = int.Parse(dr["Id"].ToString());
                        cat.Add(item);
                    }
                }
                verificator = 1;
                return cat;
            }
            catch (System.Exception ex)
            {
                verificator = -1;

                return cat;
                throw ex;
            }
        }
    }
}
