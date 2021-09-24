using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSalidaMercanciaDevDanSorianaTienda.EDPorcentajeRemates
{
    public class EDPorcentajeRemates
    {
    }

    public class SP_Get_gmdFmto
    {
        public string Id_Cve_Fmto { get; set; }
        public string Desc_Fmto { get; set; }
    }

    public class SP_Get_gmdCategoria
    {
        public int Id_Num_Categ { get; set; }
        public string Desc_Categ { get; set; }
    }

    public class SP_Get_gmdLinea
    {
        public int Id_Num_Linea { get; set; }
        public string Desc_Linea { get; set; }
    }

    public class gmdLineaRemate
    {
        public int Id_Num_Linea { get; set; }
        public string Desc_Linea { get; set; }
        public string Id_Cve_Fmto { get; set; }
        public string Desc_Fmto { get; set; }
        public int Id_Num_Etapa { get; set; }
        public int Cant_Dias { get; set; }
        public decimal Porc_Descto { get; set; }
    }

    public class SP_Get_gmdLineaRemateBajo : gmdLineaRemate

    {


    }

    public class SP_Get_gmdLineaRemateMedio : gmdLineaRemate
    {


    }

    public class SP_Get_gmdLineaRemateAlto : gmdLineaRemate

    {

    }

    public class SP_Get_gmdLineaPart
    {
        public int Id_Num_Linea { get; set; }
        public string Id_Cve_Fmto { get; set; }
        public bool Bit_PermRemate { get; set; }
        public bool Bit_PermReparable { get; set; }
        public bool Bit_AplicaTodos { get; set; }
        public bool Bit_PermTransferencia { get; set; }
        public bool Bit_PermDevolucion { get; set; }
        public bool Bit_PermMerma { get; set; }
        public string Desc_Linea { get; set; }
        public string Abrev_Linea { get; set; }
    }

    public class SP_Get_gmdLineaProvRepara
    {
        public int Id_Num_Linea { get; set; }
        public string Id_Cve_Fmto { get; set; }
        public int Id_Num_Prov { get; set; }
        public string Nom_Comercial { get; set; }
        public bool Bit_Activo { get; set; }
    }

    public class SP_Get_gmdProveedor
    {
        public int Id_Num_Prov { get; set; }
        public string Nom_Comercial { get; set; }
        public bool ddBit_StatusActivo { get; set; }
        public bool Bit_ProvImp { get; set; }
        public DateTime Fec_Movto { get; set; }

    }

    public class SP_Get_gmdFolioGMD
    {
        public int Id_Fol_GMD { get; set; }        
        public DateTime Fecx_Registro { get; set; }
        public int Id_Num_OrigenMcia { get; set; }
        public string Desc_OrigenMcia { get; set; }
        public int Id_Num_SKU { get; set; }
        public int Id_Num_Linea { get; set; }
        public string Desc_Linea { get; set; }
        public int Id_Num_Prov { get; set; }
        public string RazonSocial { get; set; }
        public bool Bit_AptoVta { get; set; }
        public bool Bit_EmpOriginal { get; set; }
        public bool Bit_ReqDescto { get; set; }
        public int UserId_Complementa { get; set; }        
        public DateTime Fec_Complementa { get; set; }
        public string Desc_Incid { get; set; }
        public string Desc_Stat { get; set; }
        public decimal Prec_VtaNorm { get; set; }
        public decimal Num_CodBarra { get; set; }
        public string ddDesc_Ensamb { get; set; }
    }

    public class SP_Get_gmdOrigenMcia
    {

        public int Id_Num_OrigenMcia { get; set; }
        public string Desc_OrigenMcia { get; set; }
    }

    public class SP_Get_gmd_Sel_CodBarra
    {
        public int Id_Num_SKU { get; set; }
        public string ddDesc_Ensamb { get; set; }
        public string Proveedor { get; set; }
        public int Id_Num_Prov { get; set; }
        public int Id_Num_Linea { get; set; }

    }

    public class UpTdagmd_Gen_gmdFolioGMD
    {
        public string Leyenda { get; set; }
    }

    public class UpTdagmd_Cns_SolGenyPendRepara
    {
        public int Id_Fol_GMD { get; set; }
        public DateTime Fecx_Registro { get; set; }
        public string RazonSocial { get; set; }
        public decimal Num_CodBarra { get; set; }
        public string ddDesc_Ensamb { get; set; }
        public string Desc_TipoSol { get; set; }
        public int FolioGen { get; set; }
        public decimal? CodigoRemate { get; set; }
        public DateTime? Fec_Reparada { get; set; }
        public string Observaciones { get; set; }
        public  DateTime? Fec_LimRepacion { get; set; }
        public int? Id_Fol_GMDPadre { get; set; }
    }

    public class UpTdagmd_dd_Defecto
    {
        public int Id_Num_Defecto { get; set; }
        public string Desc_Defecto { get; set; }
    }

    public class UpTdagmd_dd_SolucionProv
    {
        public int Id_Num_SolucProv { get; set; }
        public string Desc_SolucProv { get; set; }
    }
}
