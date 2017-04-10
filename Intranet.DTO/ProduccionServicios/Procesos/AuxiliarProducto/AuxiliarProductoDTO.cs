using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
   public class AuxiliarProductoDTO
    {
      public int IdProductoAuxiliar { get; set; } 
      public int IdProducto { get; set; } 
      public int IdAuxiliar { get; set; }
      public int IdObra { get; set; }
      public string DescripcionProducto { get; set; }
      public string DescripcionAuxiliar { get; set; }
      public string CodigoProducto { get; set; }
      public string CodigoAuxiliar { get; set; } 
    }
}
