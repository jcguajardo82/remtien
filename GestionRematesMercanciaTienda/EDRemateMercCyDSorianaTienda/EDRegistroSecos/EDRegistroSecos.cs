using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDRegistroSecos
{
    public class Documento
    {
        public int NumCedis { get; set; }
        public string DescCedis { get; set; }
        public int FolEmb { get; set; }
        public int GuiaEmb { get; set; }
        public int GuiaEmbEnsamb { get; set; }
        public string FecLlegada { get; set; }
        public string Status { get; set; }

    }
}
