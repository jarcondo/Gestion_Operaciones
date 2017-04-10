using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DAO;
using Intranet.DTO.CFG;
using Intranet.DAO.CFG;
using Intranet.DTO.Global;
namespace Intranet.BL.CFG
{
    public class CFG_AccesoBL
    {
        public eResultadoCFG ValidaIngreso(ref List<MenuCFG> oListamenu, UsuarioCFG oUsuarioCFG)
        {
            return new CFG_AccesoDAO().ValidaIngreso(ref oListamenu, oUsuarioCFG);
        }

        public eResultado CambiarPassword(int Usuario, string pass, string nuevapass)
        {
            return new CFG_AccesoDAO().CambiarPassword(Usuario, pass, nuevapass);
        }
    }
}
