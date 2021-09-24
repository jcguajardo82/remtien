using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDReportes
    {

    }

    #region combos
    /// <summary>
    /// Listado Tipo Ficha de Salida
    /// </summary>
    public class Rpt_CartaRecl_Crit
    {
        public int Id_Tipo_Reclama { get; set; }
        public string Desc_Reclama { get; set; }
    }
    /// <summary>
    /// Listado Area
    /// </summary>
      public class Rec_dd_area
    {
        public int Id_Num_AreaESMcia { get; set; }
        public string Desc_AreaESMcia { get; set; }
    }
    /// <summary>
    /// Listado de Reportes Recibo Tienda
    /// </summary>
    public class rpts_rec_mciaxaut
    {
        //                                                                                          
        public string Nombre_Rpt { get; set; }
        public string Criterio_Rpt { get; set; }
        public string Preview_Rpt { get; set; }
        public string Object_Rpt { get; set; }
    }

    /// <summary>
    /// Lista de reportes de Aplicaciones
    /// </summary>
    public class rpts_rec_mcia
    {
        public string Nombre_Rpt { get; set; }
        public string Criterio_Rpt { get; set; }
        public string Preview_Rpt { get; set; }
        public string Object_Rpt { get; set; }
        public int Id_Rpt { get; set; }
        public int Tipo_CtrlImpresion { get; set; }
        public int Bit_ConteoImpresion { get; set; }
        public int Bit_ControlaImpresion { get; set; }
        public int Cant_LimImpresion { get; set; }
        public int Modif_Zoom { get; set; }
        public bool Bit_PermiteImp { get; set; }
    }
    /// <summary>
    /// Listado de divisiones
    /// </summary>
    public class dd_div
    {
        public int Id_Num_Div { get; set; }
        public string Desc_Div { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class dd_tipomcia_NE
    {
        public int Id_Num_TipoMovESMcia { get; set; }
        public int Desc_TipoMovESMcia { get; set; }
    }

    /// <summary>
    /// Listado de Dtos
    /// </summary>
    public class dd_dpto_div
    {
       
        public int Id_Num_Dpto { get; set; }
        public int Desc_Dpto { get; set; }
    }

    //Id_Num_FolTransfStat Desc_FolTransfStat
    public class dd_status_ne
    {
        public int Id_Num_FolTransfStat { get; set; }
        public string Desc_FolTransfStat { get; set; }
    }
    #endregion

    #region Cargos x Devolución



    public class Rpt_DatosGrales_Aplic
    {
        public int Id_Num_UN { get; set; }
        public string Desc_UN { get; set; }
        public string FechaReporte { get; set; }
        public string Hora { get; set; }
        public string RazonSocial { get; set; }
        public string Aplicacion { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
    }

    public class Rpt_CargoDev
    {
        public int? Id_Num_Dpto { get; set; }
        public string Desc_Dpto { get; set; }
        public int? Id_Num_Prov { get; set; }
        public string Nom_Comercial { get; set; }
        public string Direccion { get; set; }
        public decimal? CP { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaRecibo { get; set; }
        public int? FolioNE { get; set; }
        public string Factura { get; set; }
        public DateTime? FechaFact { get; set; }
        public decimal? Importe { get; set; }
        public string Transportista { get; set; }
        public string Guia { get; set; }
        public string Talon { get; set; }
        public DateTime? FechaTalon { get; set; }
        public int? BultRem { get; set; }
        public int? BultRec { get; set; }
        public int? Folio { get; set; }
        public DateTime? FechaDev { get; set; }
        public int? BultViolados { get; set; }
        public int? BultDanados { get; set; }
        public string Desc_DevStat { get; set; }
        public DateTime? Fecha_Costeo { get; set; }

    }

    public class Rpt_lista_emp_mov
    {
        public string Persona { get; set; }
        public string Movimiento { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class leyenda_cargoxdev
    {
        public string leyenda { get; set; }
    }

    public class leyenda_lista_emp
    {
        public int Id_Num_DevEvto { get; set; }
        public string lc_leyenda { get; set; }
    }

    public class pie_carxdev
    {
        public string Nom_PersonaRecMcia { get; set; }
        public string Identificacion { get; set; }
        public string Desc_TipoIdExterna { get; set; }
        public string Desc_EntIdExterna { get; set; }
    }

    public class Rpt_CargoDev_Art
    {
        public decimal Codigo { get; set; }
        public string Desc_Art { get; set; }
        public int Dpto { get; set; }
        public string UV { get; set; }
        public decimal CantDevUV { get; set; }
        public decimal ImporteUV { get; set; }
        public decimal SubTotalUV { get; set; }
        public string MotivoDev { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IEPS { get; set; }
        public decimal IVA { get; set; }
        public int Cat { get; set; }
    }

    public class Rpt_CargoDev_Bultos
    {
        public int Stipo_EntregaMciaDev { get; set; }
        public string Tipo_Entrega { get; set; }
        public string Desc_ZonaFlete { get; set; }
        public string Desc_TipoBulto { get; set; }
        public string Id_Cve_TipoBulto { get; set; }
        public int Cant_BultosEnviados { get; set; }
        public int Num_DimAnchoCm { get; set; }
        public int Num_DimLargoCm { get; set; }
        public int Num_DimAltoCm { get; set; }
        public decimal Peso { get; set; }
        public int Total_BultosEnviados { get; set; }
    }





    #endregion
}
