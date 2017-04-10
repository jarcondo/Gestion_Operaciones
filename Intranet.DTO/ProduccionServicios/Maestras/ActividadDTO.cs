using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    public class ActividadDTO
    {
        public int IdActividad { get; set;}
        public string CodigoActividad { get; set;}
        public string CodMap { get; set;}
        public ObraDTO Obra { get; set;}
        public string Descripcion1 { get; set;}
        public string Descripcion2 { get; set;}
        public Boolean Estado { get; set;}
    }
}
