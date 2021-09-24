using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soriana.FWK.Datos.SQL;
using System.Configuration;
using sqlHelper = Soriana.FWK.Datos.SQL.SqlHelper;
using System.Data;

namespace DTSeguridadSoriana
{
    public class DTRecibirFolioNE
    {
        public DTRecibirFolioNE()
        {
            string var = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]];
            sqlHelper.connection_Name(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["AmbienteSC"]]);
        }

        ///  FUNCIONES DE 211.-Indica Acción Principal
        public DataSet ObtenerUsuarioXAplicacion()
        {
            DataSet ds = new DataSet();
            try
            {
                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@IdNumAplic", null);

                ds = SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "Sp_Cons_Login_Tlx", false, parameters);

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
                throw;

            }
            return null;
        }



        ///  FUNCIONES DE 212.-Indica Tipo de Entrega
        ///  FUNCIONES DE 213.-Indica Factura
        ///  FUNCIONES DE 214.-Captura datos de factura
        ///  FUNCIONES DE 215.-Confirma datos de factura
        ///  FUNCIONES DE 216.-Resumen de Mercancia
        ///  FUNCIONES DE 217.-Autorización de Folio
        ///  FUNCIONES DE 218.-Autoriza Detalle Ped Ven
        ///  FUNCIONES DE 219.-Indica Código para Recibo
        ///  FUNCIONES DE 2110.-Indica Código GS1
        ///  FUNCIONES DE 2111.-Captura Lote y Peso de GS1
        ///  FUNCIONES DE 2112.-Cofirma Lote y Peso de GS1
        ///  FUNCIONES DE 2113.-Indica Modo Recibo de Cod
        ///  FUNCIONES DE 2114.-Captura Modo Normal
        ///  FUNCIONES DE 2115.-Captura Modo Bascula
        ///  FUNCIONES DE 2116.-Autoriza Cap Empaque
        ///  FUNCIONES DE 2117.-Error de Aut Cap Emp
        ///  FUNCIONES DE 2118.-Cierre de Folio
        ///  FUNCIONES DE 2119.-Mercancía Mal Estado
        ///  FUNCIONES DE 2120.-Cantidad Mal Estado
        ///  FUNCIONES DE 2121.-Confirma Factura Electónica
        ///  FUNCIONES DE 2122.-Indica Detalle Factura
        ///  FUNCIONES DE 2123.-Cierre de Folio Final
        ///  FUNCIONES DE 2124.-Estatus de Folio
        ///  FUNCIONES DE 2125.-Transportista Folio
        ///  FUNCIONES DE 2126.-Detalle Bulto
        ///  FUNCIONES DE 2127.-Retoma Folio
        ///  FUNCIONES DE 2128.-Confirma Retomar Folio
        ///  FUNCIONES DE 2129.-Valida Factura


    }
}
