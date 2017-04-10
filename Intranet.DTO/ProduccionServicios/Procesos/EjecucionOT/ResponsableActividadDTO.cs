using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class ResponsableActividadDTO
    {
        public int IdResponsableActividad {get; set;}
        public ActividadDTO Actividad {get; set;}
        public GenericaDTO Area {get; set;}
        public EmpleadoDTO Responsable {get; set;}
        public int UsuarioCrea {get; set;}
        public DateTime FechaCrea {get; set;}
        public int UsuarioModi {get; set;}
        public DateTime FechaModi { get; set; }
    }
}
