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
    public class DetallePurgaBL
    {
        public List<DetallePurgaDTO> ConsultaPurga(int IdCabecera)
        {
            return new DetallePurgaDAO().ConsultaPurga(IdCabecera);
        }

        public eResultado ActualizaPurga(DetallePurgaDTO DetaLimpia)
        {
            return new DetallePurgaDAO().ActualizaPurga(DetaLimpia);
        }
        public eResultado InsertPurgaVacio(int IdCabecera)
        {
            return new DetallePurgaDAO().InsertPurgaVacio(IdCabecera);
        }

        public List<PurgaDTO> ReportePurga(int idObra, string fecDesde, string fecHasta)
        {
            return new DetallePurgaDAO().ReportePurga(idObra, fecDesde, fecHasta);
        }

    }
}
