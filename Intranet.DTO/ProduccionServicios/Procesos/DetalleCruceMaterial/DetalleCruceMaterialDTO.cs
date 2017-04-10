using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class DetalleCruceMaterialDTO
    {
       public int  IdDetalleCruceMaterial { get; set; } 
        public int IdCabeceraCruceMaterial	{ get; set; } 
        public int IdAuxiliar	{ get; set; } 
        public string CodigoAuxiliar	{ get; set; }
        public string DescripcionAuxiliar	{ get; set; }
        public decimal CantidadAlmacen	{ get; set; }
        public decimal CantidadProduccion	{ get; set; }
        public decimal Diferencia	{ get; set; }
        public decimal CantidadJustificada	{ get; set; }
        public decimal CantidadEnProceso	{ get; set; }
        public decimal PrecioAuxiliar	{ get; set; }
        public decimal Monto { get; set; }
		
    }
}
