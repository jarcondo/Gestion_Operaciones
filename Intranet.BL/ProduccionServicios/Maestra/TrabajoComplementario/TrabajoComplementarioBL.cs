using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DAO.ProduccionServicios.Maestra;

namespace Intranet.BL.ProduccionServicios.Maestra
{
    public class TrabajoComplementarioBL
    {
        public List<TrabajoComplementarioDTO> GetTrabajoComplementarioPorObra(int IdObra)
        {
            return new TrabajoComplementarioDAO().GetTrabajoComplementarioPorObra(IdObra);
        }

        public List<TrabajoComplementarioDTO> GetTrabajoComplementarioPorBase(int IdBase)
        {
            return new TrabajoComplementarioDAO().GetTrabajoComplementarioPorBase(IdBase);
        }

        public List<TrabajoComplementarioDTO> GetTrabajoComplementario()
        {
            return new TrabajoComplementarioDAO().GetTrabajoComplementario();
        }

        public TrabajoComplementarioDTO GetTrabajoComplementarioPorID(int IdTrabajoComplementario)
        {
            return new TrabajoComplementarioDAO().GetTrabajoComplementarioPorID(IdTrabajoComplementario);
        }

        public eResultado InsertarTrabajoComplementario(TrabajoComplementarioDTO oTrabajo, int idusuario)
        {
            return new TrabajoComplementarioDAO().InsertarTrabajoComplementario(oTrabajo, idusuario);
        }

        public eResultado UpdateTrabajoComplementario(TrabajoComplementarioDTO oTrabajo, int idusuario)
        {
            return new TrabajoComplementarioDAO().UpdateTrabajoComplementario(oTrabajo,idusuario);
        }

        public eResultado ElimnarTrabajoComplementario(int IdTrabajoComplementario, int idusuario)
        {
            return new TrabajoComplementarioDAO().ElimnarTrabajoComplementario(IdTrabajoComplementario, idusuario);
        }
    }
}
