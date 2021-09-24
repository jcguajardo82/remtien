using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRHeadReportes
    {
        public string JefeDepto { get; set; }
        public string Fecha { get; set; }
        public string Folio { get; set; }
        public int CantArtCapturados { get; set; }
        public string Estatus { get; set; }
    }

    public class reporteReq
    {
        public int Id_Num_Aplic { get; set; }
        public int Id_Num_Rpt { get; set; }
        public int Id_Num_ActaDestruccion { get; set; }
        public string FechaConsulta { get; set; }
        public int Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public int pId_Num_Categ { get; set; }
        public int pIdOpc { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Nombre_Vencimiento { get; set; }


    }

    #region Encabezado
    public class header
    {
        public string Desc_Aplic { get; set; }
        public string Encabezado { get; set; }
        public string Sucursal { get; set; }
        public string Fecha_Imp { get; set; }
        public string Hora_Imp { get; set; }
        public string TituloRpt { get; set; }
        public string SubTituloRpt { get; set; }
        public string Fecha_Rpt { get; set; }
    }

    #endregion

    #region Acta Destruccion
    public class reporte2
    {

        public string Gerente { get; set; }
        public string FechaCaptura { get; set; }
        public int FolActaDest { get; set; }
        public int CantArticulos { get; set; }
    }

    public class reporte3
    {
        public string Depto { get; set; }
        public string jefeDpto { get; set; }
        public decimal Articulo { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public string FechaCaducidad { get; set; }
        public int CantTeorica { get; set; }
        public int CantMerma { get; set; }
        public int CantAjustar { get; set; }
    }

    public class reporte4
    {
        public int Usuario { get; set; }
        public string jefeDpto { get; set; }
    }
    #endregion

    #region Mermas
    public class Mermas_Detalle
    {
        public decimal Id_Num_SKU { get; set; }
        public decimal CodigoInterno { get; set; }
        public string descripcion { get; set; }
        public string Lote { get; set; }
        public string FechaCaducidad { get; set; }
        public int DiasVencidos { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Usuario { get; set; }
    }
    #endregion

    #region ArtProxCadEtapa
    public class ArtProxCadEtapa_Rs1
    {
        public string Titulo { get; set; }
        public string TituloEtapa { get; set; }
        public string Jefe { get; set; }
        public string Categoria { get; set; }
        public string Vencimiento { get; set; }
    }

    public class ArtProxCadEtapa_Rs2
    {
        public int Id_Cnsc { get; set; }
        public decimal Id_Num_CodBarraOrig { get; set; }
        public decimal Id_Num_CodRemate { get; set; }
        public decimal Id_Num_SKUOrig { get; set; }
        public string Desc_ArtRemate { get; set; }
        public string Lote { get; set; }
        public string FechaCaptura { get; set; }
        public string FechaCaducidad { get; set; }
        public int DiasAntesCap { get; set; }
        public string FechaDia { get; set; }
        public int DiasAntesAct { get; set; }
        public int EtapaActual { get; set; }
        public decimal PorcDcto { get; set; }
        public decimal PrecioOrigen { get; set; }
        public decimal Dcto { get; set; }
        public decimal PrecioRem { get; set; }
    }
    #endregion

    #region FolioMerCadCap
    public class FolioMerCadCap_Detalle
    {
        public int Cnsc { get; set; }
        public decimal CodigoBarra { get; set; }
        public decimal CodigoUnico { get; set; }
        public string Descripcion { get; set; }
        public string FechaCaducidad { get; set; }
        public string Lote { get; set; }
        public string Fecha { get; set; }
        public string Jefe { get; set; }
        public int Folio { get; set; }
    }
    #endregion

    #region ReporteCapturaMercancíaCaducar

    public class ReporteCapturaMercancíaCaducar_Header
    {
        public string JefeDepartamento { get; set; }
        public string FechaDcto { get; set; }
        public int Folio { get; set; }
        public int CantArticulos { get; set; }
        public string Estatus { get; set; }
    }

    public  class ReporteCapturaMercancíaCaducar_Detalle
    {
        public decimal Articulo { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public string FechaCaducidad { get; set; }
        public int CantPiezas { get; set; }
    }
    #endregion
}
