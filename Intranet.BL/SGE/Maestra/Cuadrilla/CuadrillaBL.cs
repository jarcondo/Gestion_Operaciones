using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DAO.SGE;
using Intranet.DTO.SGE;

namespace Intranet.BL.SGE
{
    public class CuadrillaBL
    {
        public List<CuadrillaDTO> GetCuadrilla(int IdObra)
        {
            return new CuadrillaDAO().GetCuadrilla(IdObra);
        }

        public List<CuadrillaDTO> GetCuadrillaPorResponsable(int IdResponsable, int IdArea)
        {
            return new CuadrillaDAO().GetCuadrillaPorResponsable(IdResponsable, IdArea);
        }

        public List<CuadrillaDTO> GetCuadrillasMantenimiento(int IdObra)
        {
            return new CuadrillaDAO().GetCuadrillasMantenimiento(IdObra);
        }

        public List<CuadrillaDTO> ListarCuadrillaPorResponsable(int IdObra,int IdResponsable)
        {
            return new CuadrillaDAO().ListarCuadrillaPorResponsable( IdObra ,IdResponsable);
        }
    }
}
