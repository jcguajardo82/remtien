using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.Captura
{
    public class EDRConsultaPorcentaje
    {
        public string FmtoTienda { get; set; }
        public int TipoMcia { get; set; }
        public int Categoria { get; set; }
        public int DiaInicio { get; set; }
        public int DiaFin { get; set; }
        public int RebajaVta { get; set; }
        public int RebajaMerma { get; set; }
    }
}
