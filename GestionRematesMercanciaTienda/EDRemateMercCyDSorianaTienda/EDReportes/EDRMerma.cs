using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRMerma
    {
        public string SKU { get; set; }
        public string CodInterno { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public string FechaCaducidad { get; set; }
        public string DiasVencidos { get; set; }
        public string Existencia { get; set; }
    }
}
