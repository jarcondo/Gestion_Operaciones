using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.PermisoMunicipal
{
    public class PermisoMuniDTO
    {
        public string Cuadrilla { get; set; }
        public string SGI { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string distrito { get; set; }
        public string subactividad { get; set; }
        public string observacion { get; set; }
    }
}