using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class ResponsableActividadBL
    {
        public List<ResponsableActividadDTO> GetResponsableActividad(int IdObra,string CodMap)
        { 
            return new ResponsableActividadDAO().GetResponsableActividad(IdObra,CodMap);
        }

        public List<ResponsableActividadDTO> ObtenerResponsableActividad(int IdObra)
        {
            return new ResponsableActividadDAO().ObtenerResponsableActividad(IdObra);
        }

        public ResponsableActividadDTO ObtenerResponsableActividadPorID(int IdRespAct)
        {
            return new ResponsableActividadDAO().ObtenerResponsableActividadPorID(IdRespAct);
        }

        public eResultado InsertarResponsableActividad(ResponsableActividadDTO oResponsableActividad, int Usuario)
        {
            return new ResponsableActividadDAO().InsertarResponsableActividad(oResponsableActividad, Usuario);
        }

        public eResultado ActualizarResponsableActividad(ResponsableActividadDTO oResponsableActividad, int Usuario)
        {
            return new ResponsableActividadDAO().ActualizarResponsableActividad(oResponsableActividad, Usuario);
        }

        public eResultado EliminarResponsableActividad(int IdResponsableActividad, int Usuario)
        {
            return new ResponsableActividadDAO().EliminarResponsableActividad(IdResponsableActividad, Usuario);
        }
    }
}
