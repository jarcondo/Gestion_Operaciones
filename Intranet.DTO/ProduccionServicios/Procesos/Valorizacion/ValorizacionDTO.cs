using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class ValorizacionDTO
    {
        public int IdValorizacion {get; set;}
        public int IdObra { get; set; }
        public string CodigoValorizacion {get; set;}
        public string Descripcion {get; set;}
        public string FechaInicio {get; set;}
        public string FechaFin {get; set;}
        public string FechaValorizacion {get; set;}
    }
}
