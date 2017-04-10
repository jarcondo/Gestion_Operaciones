using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleOtrosDTO
    {
        public int IdOtros { get; set; }
        public int IdCabecera { get; set; }
        public double DUnoAlturaSolBuzon { get; set; }
        public double DUnoVolExtSol { get; set; }
        public double DUnoPulgIntBuzon { get; set; }
        public double DUnoTiranteHidBuzon { get; set; }
        public int DUnoDiametroColector { get; set; }
        public double DUnoAlturaAguaRet { get; set; }
        public double DUnoAlturaTotalBuzon { get; set; }
        public string DUnoOtros { get; set; }
        public int ADdvd { get; set; }
        public bool Desmonte { get; set; }
        public bool ConAgua { get; set; }
    }
}
