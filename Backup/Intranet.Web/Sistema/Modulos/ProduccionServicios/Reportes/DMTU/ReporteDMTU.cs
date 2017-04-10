using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.DMTU
{
    public class ReporteDMTU
    {
        public string Base { get; set; }
        public string Obra { get; set; }
        public string FDesde { get; set; }
        public string FHasta { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Distrito { get; set; }
        public string Actividad { get; set; }
        public string SubActividad { get; set; }
    }
}