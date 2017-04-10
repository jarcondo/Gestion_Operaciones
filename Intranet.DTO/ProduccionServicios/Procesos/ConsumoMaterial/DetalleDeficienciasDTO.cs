using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleDeficienciasDTO
    {
        public int IdDeficiencias { get; set; }
        public int IdCabecera { get; set; }
        public int codigo { get; set; }
        public double distancia { get; set; }
        public bool puntual { get; set; }
        public double extendida { get; set; }
    }
}
