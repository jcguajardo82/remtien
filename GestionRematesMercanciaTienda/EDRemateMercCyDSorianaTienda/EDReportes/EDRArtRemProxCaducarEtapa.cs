using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDReciboTiendaSoriana.EDReportes
{
    public class EDRArtRemProxCaducarEtapa
    {   
        public List<EDRArtRemProxCaducarEtapaTitulos> Titulo { get; set; }
        public List<EDRArtRemProxCaducarEtapaDetalle> Detalle { get; set; }

    }
    public class EDRArtRemProxCaducarEtapaTitulos
    {
        public string Titulo { get; set; }
        public string TituloEtapa { get; set; }
    }
    public class EDRArtRemProxCaducarEtapaDetalle
    {
        public int Cnsc { get; set; }
        public string CodigoBarra { get; set; }
        public string CodigoRemate { get; set; }
        public string CodigoUnico { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public decimal Precio { get; set; }
        public string FechaCaptura { get; set; }
        public string FechaCaducidad { get; set; }
        public string DiasAntesCap { get; set; }
        public string FechaDia { get; set; }
        public string DiasAntesActCap { get; set; }
        public int EtapaActual { get; set; }
        public decimal PorcDcto { get; set; }
        public decimal PrecioOrigen { get; set; }
        public decimal Dcto { get; set; }
        public decimal PrecioRem { get; set; }
    }
}
