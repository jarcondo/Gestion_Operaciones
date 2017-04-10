using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    public class CatalogoDTO
    {
        public int IdProCatalogo { get; set; }
        public int IdActividad { get; set; }
        public int IdObra { get; set; }
        public int CodMap { get; set; }
        public string Descripcion1 { get; set; }
        public string Descripcion2 { get; set; }
        public string Unidad { get; set; }
        public bool Valorizable { get; set; }
        public decimal Precio { get; set; }
        public int CodMapActividad { get; set; }
    }
}
