using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRMerCadCap
    {
       
        public int Numero { get; set; }
        public string Articulo { get; set; }
        public string CodigoBarra { get; set; }
        public string CodigoUnico { get; set; }
        public string CodigoUnicoSalida { get; set; }
        public string Descripcion { get; set; }
        public string FechaCaducidad { get; set; }
        public string FechaCaptura { get; set; }
        public string Lote { get; set; }
        public int CantPiezas { get; set; }
        public byte BitConfirmar { get; set; }
        public int CantConfirmada { get; set; }
        public DateTime FechaCad { get; set; }
        public int Dias_Vmto { get; set; }
        public int DiasAntes { get; set; }
        public int UN { get; set; }
        public string Fmto { get; set; }
        public string Depto { get; set; }
        public string jefeDpto { get; set; }
        public int CantTeorica { get; set; }
        public int CantMerma { get; set; }
        public int CantAjustar { get; set; }
        public decimal Precio { get; set; }
        public int Etapa { get; set; }
        public int RangoIni { get; set; }
        public int RangoFinal { get; set; }
        public int PorcOfta { get; set; }
        public int PorcAfecta { get; set; }
        public int ImpAfecta { get; set; }
        public int FolioAfecta { get; set; }
        public int Cnsc { get; set; }
        
    }
}
