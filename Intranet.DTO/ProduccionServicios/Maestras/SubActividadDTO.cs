using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    public class SubActividadDTO
    {
        public int IdSubActividad { get; set;}
        public string CodigoSubActividad { get; set;}
        public int CodMap { get; set;} 
        public ActividadDTO Actividad { get; set;}
        public string DescripcionSubActividad1 { get; set;}
        public string DescripcionSubActividad2 { get; set;}
        public string Unidad { get; set;}
        public Decimal CostoProgramado { get; set;}
        public Decimal Puntaje { get; set;}
        public Boolean Activo { get; set;}
        public string Observacion { get; set;}
        public bool TrabajoComplementario { get; set; }
        public bool Resane { get; set; }
        public decimal TTeorico { get; set; }

    }
}
