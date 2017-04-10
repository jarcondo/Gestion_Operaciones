using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleCaracteristicasDTO
    {
        public int IdCaracteristicas { get; set; }
        public int IdCabecera { get; set; }
        public int ValNroVueltas { get; set; }
        public bool ValIzqDer { get; set; }
        public int ValNivelAp { get; set; }
        public string ValEstado { get; set; }
        public string ValMarca { get; set; }
        public string GrifoDiametro { get; set; }
        public string GrifoMarca { get; set; }
        public int GrifoSector { get; set; }
        public int GrifoNroBocas { get; set; }
        public int GrifoNroVueltas { get; set; }
        public int GrifoNroVueltasAb { get; set; }
        public bool OtrosSituacion { get; set; }
        public int OtrosNroTapas { get; set; }
        public bool OtrosCuerpo { get; set; }
        public string OtrosUbica { get; set; }
        public string OtrosUbicaValvula { get; set; }
    }
}
