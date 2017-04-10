using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class DetalleSubActividadDTO
    {
        public int IdDetalleSubAct { get; set;}
        public int IdCabecera { get; set;}
        public int IdSubActividad { get; set;}
        public decimal Cantidad { get; set;}
        public decimal Costo { get; set;}
        public bool SGIO { get; set; }
        public int IdCuadrilla { get; set; }
        public int IdProveedor { get; set; }
        public string Observacion { get; set; }

    }
}
