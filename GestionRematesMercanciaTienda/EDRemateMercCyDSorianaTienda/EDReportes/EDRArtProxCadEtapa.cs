using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRArtProxCadEtapa
    {
        public int Numero { get; set; }
        public string CodigoBarra { get; set; }
        public string CodigoUnicoSalida { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Lote { get; set; }
        public int DiasAntesCaducar { get; set; }
        public int Etapa { get; set; }
        public int RangoIni { get; set; }
        public int RangoFin { get; set; }
        public string MaxOferta { get; set; }
        public string PorAfectacion { get; set; }
        public string AfecMerma { get; set; }
        public DateTime FechaDia { get; set; }
        public int DiasAntesActual { get; set; }
        public int EtapaActual { get; set; }
        public string PorDescuento { get; set; }
        public float PrecioOrigen { get; set; }
        public float Descuento { get; set; }
        public float PrecioRemate { get; set; }
        public string FolioActaDestruccion { get; set; }
    }
}
