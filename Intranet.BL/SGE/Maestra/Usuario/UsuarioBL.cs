using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Intranet.DAO;
using Intranet.DTO.CFG;
namespace Intranet.BL.Maestra
{
    public class UsuarioBL
    {
        public List<UsuarioLoginCFG> GetUsuario()
        {
            return new UsuarioDAO().GetUsuario();
        }

        public UsuarioLoginCFG UsuarioBuscar(int IdUsuario)
        {
            return new UsuarioDAO().UsuarioBuscar(IdUsuario);
        }
    }
}
