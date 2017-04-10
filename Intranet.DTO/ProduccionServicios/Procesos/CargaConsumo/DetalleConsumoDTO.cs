using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class DetalleConsumoDTO
    {
        public int ncod_centro {get; set;}
        public string center {get; set;}
        public string nro_ot {get; set;}
        public int ncod_actividad {get; set;}
        public int ncod_sub_act {get; set;}
        public decimal cantidad {get; set;}
        public int ncod_material {get; set;}
        public decimal ncantidad {get; set;}
        public string estado { get; set; }
    }
}
