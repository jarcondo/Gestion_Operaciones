using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Maestras
{
    [Serializable]
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
    }
}
