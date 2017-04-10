using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Maestra
{
    public class ActividadBL
    {
        public List<ActividadDTO> ListarActividad(int IdObra)
        {
            return new ActividadDAO().ListarActividad(IdObra);
        }

        public ActividadDTO ListarActividadPorID(int IdActividad)
        {
            return new ActividadDAO().ListarActividadPorID(IdActividad);
        }

        public ActividadDTO ListarActividadPorCODIGO(string CodActividad)
        {
            return new ActividadDAO().ListarActividadPorCODIGO(CodActividad);
        }

        public eResultado InsertarActividad(ActividadDTO oActividad, int Usuario)
        {
            return new ActividadDAO().InsertarActividad(oActividad, Usuario);
        }

        public eResultado ActualizarActividad(ActividadDTO oActividad, int Usuario)
        {
            return new ActividadDAO().ActualizarActividad(oActividad, Usuario);
        }

        public eResultado EliminarActividad(int IdActividad, int Usuario)
        {
            return new ActividadDAO().EliminarActividad(IdActividad, Usuario);
        }
    }
}
