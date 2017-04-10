using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleInspeccionDTO
    {
        public int idInspeccion { get; set; }
        public int idCabecera { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int idCuadrilla { get; set; }
    }
}
