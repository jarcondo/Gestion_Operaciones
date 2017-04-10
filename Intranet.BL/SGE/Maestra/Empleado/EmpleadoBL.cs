using System.Collections.Generic;

using Intranet.DTO.SGE;
using Intranet.DAO.SGE;
namespace Intranet.BL.SGE
{
    public class EmpleadoBL
    {
        public List<EmpleadoDTO> CargaEmpleado(int IdBase)
        {
            return new EmpleadoDAO().CargaEmpleado(IdBase);
        }
        public List<EmpleadoDTO> GetEmpleadosAdmin(int idbase)
        {
            return new EmpleadoDAO().GetEmpleadosAdmin(idbase);
        }

        public List<EmpleadoDTO> ObtenerResponsables(int IdObra)
        {
            return new EmpleadoDAO().ObtenerResponsables(IdObra);
        }
    }
}
