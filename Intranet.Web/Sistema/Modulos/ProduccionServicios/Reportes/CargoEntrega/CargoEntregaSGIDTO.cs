using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.CargoEntrega
{
    public class CargoEntregaSGI
    {
        public int Item { get; set; }
        public string NroCargo { get; set; }
        public string Area { get; set; }
        public string Residente { get; set; }
        public string SGI { get; set; }
        public string NIS { get; set; }
        public string ACTIVIDAD { get; set; }
        public string SUBACTIVIDAD { get; set; }
        public string ORDEN { get; set; }
        public string FechaEjecucion { get; set; }
        public string DIRECCION { get; set; }
        public string CUADRILLA { get; set; }
        public string DESCUADRILLA { get; set; }
        public string DISTRITO { get; set; }
        public string DESDISTRITO { get; set; }
        public string FechaEmision { get; set; }
        public string ESTADO { get; set; }
        public decimal COSTO_SEDAPRO { get; set; }
        public decimal COSTO_OPEN { get; set; }
        public decimal DIFERENCIA { get; set; }
    }
}
