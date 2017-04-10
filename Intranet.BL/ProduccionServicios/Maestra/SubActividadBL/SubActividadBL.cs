using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Maestra
{
    public class SubActividadBL
    {
        public List<SubActividadDTO> ObtenerSubActividad(int IdObra, int IdActividad)
        {
            return new SubActividadDAO().ObtenerSubActividad(IdObra, IdActividad);
        }

        public List<SubActividadDTO> ObtenerSubActividadCreacion(int IdObra, int CodMapActividad)
        {
            return new SubActividadDAO().ObtenerSubActividadCreacion(IdObra, CodMapActividad);
        }

        public List<SubActividadDTO> ObtenerTrabajoComplemantario(int IdObra, int IdActividad)
        {
            return new SubActividadDAO().ObtenerTrabajoComplemantario(IdObra, IdActividad);
        }

        public eResultado InsertarSubActividad(SubActividadDTO oSubActividad, int Usuario)
        {
            return new SubActividadDAO().InsertarSubActividad(oSubActividad, Usuario);
        }

        public eResultado ActualizarSubActividad(SubActividadDTO oSubActividad, int Usuario)
        {
            return new SubActividadDAO().ActualizarSubActividad(oSubActividad, Usuario);
        }

        public eResultado EliminarSubActividad(int IdSubActividad, int Usuario)
        {
            return new SubActividadDAO().EliminarSubActividad(IdSubActividad, Usuario);
        }

        public SubActividadDTO ListarSubActividadPorID(int IdSubActividad)
        {
            return new SubActividadDAO().ListarSubActividadPorID(IdSubActividad);
        }
    }
}
