using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    [Serializable]
    public class ZonaDTO
    {
        public int IdDistrito { get; set; }
        public string DescripcionZona { get; set; }
        public int IdZona { get; set; }
        public string Distrito { get; set; }
        public int IdObra { get; set; }
    }
}
