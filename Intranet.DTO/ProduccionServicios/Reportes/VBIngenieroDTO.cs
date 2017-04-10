using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class VBIngenieroDTO
    {
        public string Base {get; set;}
        public string Obra  {get; set;}
        public string Responsable {get; set;}
        public string NroRegistro {get; set;}
        public string FechaProg { get; set; }
        public string desc_subactividad  {get; set;}
        public string Direccion {get; set;}
        public string localidad {get; set;}
        public string municipio {get; set;}
        public string Estado { get; set; }
    }
}
