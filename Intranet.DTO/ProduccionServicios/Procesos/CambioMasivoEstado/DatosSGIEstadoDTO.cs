using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class DatosSGIEstadoDTO
    {
        public int IdCuadrilla { get; set; }
        public string CodigoCuadrilla { get; set; }
        public string DescripcionCuadrilla { get; set; }
        public string SGI { get; set; }
        public string DescripcionEstadoActual { get; set; }
        public string DescripcionEstadoCambio { get; set; }
        public string Nis { get; set; }
        public string Subactividad { get; set; }
        public string Observacion { get; set; }
        public int Situacion { get; set; }
        public int IdEstadoOT { get; set; }

    }
}
