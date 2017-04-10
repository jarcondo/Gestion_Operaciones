using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.SGE
{
    public class EmpleadoDTO : EventArgs
    {
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombresApellidos { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
        public string CentroCosto { get; set; }
        public string LicenciaConducir { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string TipoTrabajador { get; set; }
        public string CodigoTipoTrabajador { get; set; }
        public int IdBase { get; set; }
        public string Base { get; set; }
        public bool Estado { get; set; }
    }
}
