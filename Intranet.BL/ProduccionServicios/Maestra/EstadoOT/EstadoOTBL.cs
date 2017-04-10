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
    public class EstadoOTBL
    {
        public List<EstadoOTDTO> ListarEstadoOT()
        {
            return new EstadoOTDAO().ListarEstadoOT();
        }
        public eResultado Delete(string Codigo)
        {
            return new EstadoOTDAO().ElimnarEstadoOT(Codigo);
        }
        public eResultado Insert(string Codigo, string Descripcion ,int IdUsuario)
        {
            return new EstadoOTDAO().InsertarEstadoOT(Codigo, Descripcion, IdUsuario);
        }
        public eResultado Update(string Codigo, string Descripcion, int IdUsuario)
        {
            return new EstadoOTDAO().UpdateEstadoOT(Codigo, Descripcion, IdUsuario);
        }

        public List<EstadoOTDTO> ListarEstadoOTTodos()
        {
            return new EstadoOTDAO().ListarEstadoOTTodos();
        }

    }
}
