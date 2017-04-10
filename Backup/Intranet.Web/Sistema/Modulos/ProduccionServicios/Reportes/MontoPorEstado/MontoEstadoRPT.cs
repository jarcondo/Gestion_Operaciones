using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.MontoPorEstado
{
    public class MontoEstadoRPT
    {
        public string titulo { get; set; }
        public string sbase { get; set; }
        public string obra { get; set; }
        public string responsable { get; set; }
        public decimal pendiente { get; set; }
        public decimal asignado { get; set; }
        public decimal trabajando { get; set; }
        public decimal atendido { get; set; }
        public decimal resuelto { get; set; }
        public decimal facturado { get; set; }
        public string FecInicio { get; set; }
        public string FecFin { get; set; }
    }
}
