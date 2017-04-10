using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class CabeceraCruceMaterialDTO
    {
        public   int IdCabeceraCruceMaterial { get; set; } 	
        public int IdObra	{ get; set; } 	
        public int IdResponsable { get; set; }	
        public DateTime FechaInicial	{ get; set; }
        public DateTime FechaFinal	{ get; set; }
        public bool   Activo	{ get; set; }
        public int TipoMaterial { get; set; }
        public string cFechaInicial { get; set; }
        public string cFechaFinal { get; set; }
        public string cActivo { get; set; }
        public string Responsable { get; set; }
        public string DescripcionValorizable { get; set; }
        public DateTime FechaRevision { get; set; }

    }
}
