using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class BuzonesLimpMaqBaldeDTO
    {
        public string NumeroOrden { get; set; }
        public string FechaInicio { get; set; }
        public string sgi { get; set; }
        public string Suministro { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Distrito { get; set; }
        public double Profundidad { get; set; }
        public string Buzon { get; set; }
        public string marcoMaterial { get; set; }
        public string marcoEstado { get; set; }
        public string tapaMaterial { get; set; }
        public string TapaEstado { get; set; }
        public string Media { get; set; }
        public string Cuerpo { get; set; }
        public string Techo { get; set; }
        public string Emboquillado { get; set; }
        public string MarcoNivelado { get; set; }

    }
}
