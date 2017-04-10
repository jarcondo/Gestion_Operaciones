using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DAO.SGE;

namespace Intranet.BL.SGE
{
    public class ProveedorBL
    {
        public List<ProveedorDTO> GetProveedor()
        {
            return new ProveedorDAO().GetProveedor();
        }

        public List<ProveedorDTO> GetCliente()
        {
            return new ProveedorDAO().GetCliente();
        }
    }
}
