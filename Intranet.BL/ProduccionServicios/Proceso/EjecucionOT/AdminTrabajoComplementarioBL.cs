using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;


namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class AdminTrabajoComplementarioBL
    {
        public List<AdminTrabajoComplementarioDTO> ListarAdminTrabajoComplementario()
        {
            return new AdminTrabajoComplementarioDAO().ListarAdminTrabajoComplementario();
        }

        public List<AdminTrabajoComplementarioDTO> ListarAdminTrabajoComplementarioPorEjecucion(int IdEjecucionOT)
        {
            return new AdminTrabajoComplementarioDAO().ListarAdminTrabajoComplementarioPorEjecucion(IdEjecucionOT);
        }

        public AdminTrabajoComplementarioDTO ListarAdminTrabajoComplementarioPorID(int IdAdminTC)
        {
            return new AdminTrabajoComplementarioDAO().ListarAdminTrabajoComplementarioPorID(IdAdminTC);
        }

        public int InsertarAdminTrabajoComplementario(AdminTrabajoComplementarioDTO oAdminTC)
        {
            return new AdminTrabajoComplementarioDAO().InsertarAdminTrabajoComplementario(oAdminTC);
        }

        public eResultado ActualizarAdminTrabajoComplementario(AdminTrabajoComplementarioDTO oAdminTC)
        {
            return new AdminTrabajoComplementarioDAO().ActualizarAdminTrabajoComplementario(oAdminTC);
        }

        public eResultado EliminarAdminTrabajoComplementario(int IdAdmTraCom, int idusuario)
        {
            return new AdminTrabajoComplementarioDAO().EliminarAdminTrabajoComplementario(IdAdmTraCom, idusuario);
        }
    }
}
