using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Procesos;


namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class CuadrillaDistritoBL
    {
        public List<CuadrillaDistritoDTO> ListarCuadrillaDistrito()
        {
            return new CuadrillaDistritoDAO().ListarCuadrillaDistrito();
        }

        public List<CuadrillaDistritoDTO> ListarCuadrillaDistrito2(int IdObra)
        {
            return new CuadrillaDistritoDAO().ListarCuadrillaDistrito2(IdObra);
        }


        public eResultado CuadrillaDistritoActualizar(CuadrillaDistritoDTO oCuadrillaDistritoDTO)
        {
            return new CuadrillaDistritoDAO().CuadrillaDistritoUpdate(oCuadrillaDistritoDTO);
        }

        public eResultado CuadrillaDistritoInsert(CuadrillaDistritoDTO oCuadrillaDistritoDTO)
        {
            return new CuadrillaDistritoDAO().CuadrillaDistritoInsert(oCuadrillaDistritoDTO);
        }

        public eResultado CuadrillaDistritoEliminar(int IdCuadrilla, int IdObra, int IdCuadrillaDistrito)
        {
            return new CuadrillaDistritoDAO().CuadrillaDistritoDelete(IdCuadrilla, IdObra, IdCuadrillaDistrito);
        }

        public List<CuadrillaDistritoDTO> ListarCuadrillaProduccion(int IdObra)
        {
            return new CuadrillaDistritoDAO().ListarCuadrillaProduccion(IdObra);
        }
    }
}
