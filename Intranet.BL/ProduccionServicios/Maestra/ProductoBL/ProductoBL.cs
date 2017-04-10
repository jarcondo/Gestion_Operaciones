using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.BL.ProduccionServicios.Maestra
{
    public class ProductoBL
    {
        public List<ProductoDTO> ListarProducto()
        {
            return new ProductoDAO().ListarProductoMaterial();
        }
    }
}
