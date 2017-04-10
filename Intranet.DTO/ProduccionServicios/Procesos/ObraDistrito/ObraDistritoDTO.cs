using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class ObraDistritoDTO
    {
        public int IdObraDistrito { get; set; }
        public int IdObra { get; set; }
        public int IdDistrito { get; set; }
        public string Distrito { get; set; }
    }
}
