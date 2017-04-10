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
    public class PuntajeBL
    {
        public List<PuntajesDTO> ListarPuntajeDiario(int IdObra, string FechaIni, string FechaFin, int IdResponsable ,int IdCuadrilla)
        {
            return new PuntajeDAO().ListarPuntajeDiario(IdObra, FechaIni, FechaFin, IdResponsable ,IdCuadrilla);
        }
        public List<PuntajesDTO> ListarPuntajeFecha(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla)
        {
            return new PuntajeDAO().ListarPuntajeFecha(IdObra, FechaIni, FechaFin, IdResponsable, IdCuadrilla);
        }

        public List<PuntajesDTO> ListarPuntajeAcumFecha(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla)
        {
            return new PuntajeDAO().ListarPuntajeAcumFecha(IdObra, FechaIni, FechaFin, IdResponsable, IdCuadrilla);
        }
    }
}
