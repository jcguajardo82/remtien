using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRArtRemVen
    {
        public int Cnsc { get; set; }
        public string CodigoBarra { get; set; }
        public string CodigoUnico { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public decimal Precio { get; set; }
        public int Etapa { get; set; }
        public int RangoIni { get; set; }
        public int RangoFinal { get; set; }
        public int PorcOfta { get; set; }
        public int PorcAfecta { get; set; }
        public decimal ImpAfecta { get; set; }
        public int FolioAfecta { get; set; }
        public string FechaCaducidad { get; set; }
        public string FechaCaptura { get; set; }
        public int DiasAntes { get; set; }
    }
}
