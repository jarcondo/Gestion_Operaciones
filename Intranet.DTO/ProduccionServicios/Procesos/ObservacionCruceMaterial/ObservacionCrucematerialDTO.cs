using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class ObservacionCrucematerialDTO
    {
     public int  IdObservacion { get; set; } 
     public int IdCabeceraCruceMaterial	{ get; set; } 
     public int IdTipoObservacion	{ get; set; } 
     public int IdAuxiliar	{ get; set; } 
     public decimal Cantidad	{ get; set; } 
     public string OrdenTrabajo	{ get; set; }
     public string Observacion { get; set; }
     public int IdCuadrilla { get; set; }
     public string CodigoCuadrilla { get; set; }

    }
}
