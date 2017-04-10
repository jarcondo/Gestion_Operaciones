using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleBuzonBL
    {
        public List<DetalleBuzonDTO> ConsultaBuzon(int cab)
        {
            return new DetalleBuzonDAO().ConsultaBuzon(cab);
        }

        public eResultado ActualizaBuzon(DetalleBuzonDTO DetaBuzon)
        {
            return new DetalleBuzonDAO().ActualizaBuzon(DetaBuzon);
        }

        public eResultado InsertDetalleBuzonVacio(int cab)
        {
            return new DetalleBuzonDAO().InsertDetalleBuzonVacio(cab);
        }

        public List<BuzonesLimpMaqBaldeDTO> BuzonesLimpMaqBalde(int Idobra, string fecDesde, string fecHasta)
        {
            return new DetalleBuzonDAO().BuzonesLimpMaqBalde(Idobra, fecDesde, fecHasta);
        }
    }
}
