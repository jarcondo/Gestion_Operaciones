using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.SGE;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class CambioMasivoEstadoBL
    {
        public List<DatosSGIEstadoDTO> ListarSgiArchivoTexto(int IdObra ,int IdEstadoOT)
        {
            return new CambioMasivoEstadoDAO().ListarSgiArchivoTexto(IdObra , IdEstadoOT);
        }

        public  eEstadoTransaccion  CambioMasivoEstadoUpdate(int IdObra, int IdEstadoOT ,int IdUsuario)
        {
            return new CambioMasivoEstadoDAO().CambioMasivoEstadoUpdate(IdObra, IdEstadoOT,IdUsuario);
        }
    }
}
