using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    [Serializable]
    public class AuxiliarDTO
    {
      public int IdAuxiliar { get; set; }
      public int IdObra { get; set; }
      public string CodigoAuxiliar { get; set; }
      public string Descripcion { get; set; }
      public string Unidad { get; set; }
      public bool Valorizable { get; set; }
      public Decimal Precio { get; set; }
    }
}
