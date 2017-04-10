using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class CuadrillaDistritoDTO
    {
        public int IdCuadrillaDistrito { get; set; }
        public int IdCuadrilla { get; set; }
        public string CodigoCuadrilla { get; set; }
        public string DescripcionCuadrilla { get; set; }
        public int IdDistrito { get; set; }
        public string DescripcionDistrito { get; set; }
        public string DescripcionZona { get; set; }
        public int IdZona { get; set; }
        public int IdObra { get; set; }
    }
}
