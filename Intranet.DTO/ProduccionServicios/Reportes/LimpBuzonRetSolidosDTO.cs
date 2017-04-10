using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class LimpBuzonRetSolidosDTO
    {
        public string NumeroOrden { get; set; }
        public string FechaInicio { get; set; }
        public string sgi { get; set; }
        public string Suministro { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Distrito { get; set; }
        public int Cantidad { get; set; }
        public double AlturaSolBuzon { get; set; }
        public double PulgIntBuzon { get; set; }
        public double TiranteHidBuzon { get; set; }
        public double DiametroColector { get; set; }
        public double AlturaTotalBuzon { get; set; }

    }
}
