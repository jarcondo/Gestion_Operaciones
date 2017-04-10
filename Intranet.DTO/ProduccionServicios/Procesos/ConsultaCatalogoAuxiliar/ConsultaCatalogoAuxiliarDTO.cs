using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class ConsultaCatalogoAuxiliarDTO
    {

        public int Item { get; set; }
        public int IdAuxiliar { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string DescripcionAuxiliar { get; set; }
        public int IdProducto { get; set; }
        public string DescripcionAlmacen { get; set; }
        public string unidadalmacen { get; set; }
        public int IdProCatalogo { get; set; }
        public string CodigoActividad { get; set; }
        public string DescripcionCatalogo { get; set; }
        public string UnidadSedapro { get; set; }
        
        
        
         
    }
}
