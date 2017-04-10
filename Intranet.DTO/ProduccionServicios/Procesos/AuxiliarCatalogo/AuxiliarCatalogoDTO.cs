using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class AuxiliarCatalogoDTO
    {
      public int IdCatalogoAuxiliar { get; set; }
      public int IdProCatalogo { get; set; }
      public int IdAuxiliar { get; set; }
      public int IdObra { get; set; }
      public string DescripcionCatalogo { get; set; }
      public string DescripcionAuxiliar { get; set; }
      public int IdActividad { get; set; }
      public string CodigoActividad { get; set; }
    }
}
