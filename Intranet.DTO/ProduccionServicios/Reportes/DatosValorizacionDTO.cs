using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class DatosValorizacionDTO
    {
        public string ENLACE { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIP { get; set; }
        public decimal SumaDeCANTIDAD { get; set; }
        public decimal PRECIO_UNI { get; set; }
        public string Tipo { get; set; }
        public string NOMACTIVID { get; set; }
        public string UNIDAD { get; set; }
        public string SGI { get; set; }
    }
}
