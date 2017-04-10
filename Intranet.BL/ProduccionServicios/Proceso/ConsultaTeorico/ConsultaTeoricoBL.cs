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
    public class ConsultaTeoricoBL
    {
        public List<CruceMaterialDTO> ListarTablaTeorico(int IdObra)
        {
            return new ConsultaTeoricoDAO().ListarTablaTeorico(IdObra);
        }

        public eResultado TeoricoUpdate(int IdTeorico, decimal Factor)
        {
            return new ConsultaTeoricoDAO().TeoricoUpdate(IdTeorico,Factor);
        }

    }
}
