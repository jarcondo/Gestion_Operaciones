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
    public class ObraDistritoBL
    {
        public List<ObraDistritoDTO> ListarObraDistrito(int IdObra)
        {
            return new ObraDistritoDAO().ListarObraDistrito(IdObra);
        }

        public eResultado Insert(int IdObra, int IdDistrito)
        {
            return new ObraDistritoDAO().InsertarObraDistrito(IdObra,IdDistrito);
        }

        public eResultado Delete(int IdDistrito,int IdObra)
        {
            return new ObraDistritoDAO().DeleteObraDistrito(IdDistrito,IdObra);
        }

    }
}
