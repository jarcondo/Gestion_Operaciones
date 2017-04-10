using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleConexionesDTO
    {
        public int IdConexiones { get; set; }
        public double pulgadas { get; set; }
        public double distancia { get; set; }
        public string izqDer { get; set; }
        public string tipoMaterial { get; set; }
        public int IdCabecera { get; set; }
    }
}
