using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    [Serializable]
    public class TrabajoComplementarioDTO
    {
        public int IdTrabajoComplementario { get; set; }
        public string CodigoTrabajoComplementario {get; set;}
        public string CodMap {get; set;}
        public string Descripcion {get; set;}
        public string Unidad {get; set;}
        public decimal CostoProgramado {get; set;}
        public Boolean Activo {get; set;}
        public string Observacion {get; set;}
        public ObraDTO Obra {get; set;}


       
    }
}
