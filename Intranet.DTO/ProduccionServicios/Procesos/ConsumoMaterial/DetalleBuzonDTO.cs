using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleBuzonDTO
    {
        public int idBuzon { get; set; }
        public string buzon { get; set; }
        public int idCabecera { get; set; }
        public double profundidad { get; set; }
        public string marcoMaterial { get; set; }
        public bool marcoEstado { get; set; }
        public string tapaMaterial { get; set; }
        public string tapaEstado { get; set; }
        public bool solado { get; set; }
        public bool media { get; set; }
        public bool cuerpo { get; set; }
        public bool techo { get; set; }
        public bool emboquillado { get; set; }
        public bool sellado { get; set; }
        public bool marcoNivelado { get; set; }
    }
}
