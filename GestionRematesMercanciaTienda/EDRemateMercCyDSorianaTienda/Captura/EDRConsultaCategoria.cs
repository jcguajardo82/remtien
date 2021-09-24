using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.Captura
{
    public class EDRConsultaCategoria
    {
        public string CveOperacion { get; set; }
        public string FmtoTienda { get; set; }
        public int TipoMcia { get; set; }
        public int Categoria { get; set; }
        public int Periodicidad { get; set; }
        public int DiaMes { get; set; }
        public int DiaSemana { get; set; }
        public int DiaAviso { get; set; }
        
    }
}
