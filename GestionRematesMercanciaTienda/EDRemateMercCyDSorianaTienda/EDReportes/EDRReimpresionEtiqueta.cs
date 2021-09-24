using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRReimpresionEtiqueta
    {
        public string Articulo { get; set; }
        public string CodInterno { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public string FechaCaducidad { get; set; }
        public int CantPiezas { get; set; }
        public string BitConfirmar { get; set; }
        public int CantConfirmada { get; set; }
        public string FechaCad { get; set; }
        public int Dias_Vmto { get; set; }
        public int UN { get; set; }
        public string Fmto { get; set; }
        public string SKU { get; set; }
    }
}
