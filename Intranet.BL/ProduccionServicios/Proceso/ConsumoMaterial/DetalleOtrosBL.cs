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
    public class DetalleOtrosBL
    {
        public DetalleOtrosDTO SelectDetalleOtros(int cab)
        {
            return new DetalleOtrosDAO().SelectDetalleOtros(cab);
        }

        public eResultado ActualizaDetalleOtros(DetalleOtrosDTO DetaOtros)
        {
            return new DetalleOtrosDAO().ActualizaDetalleOtros(DetaOtros);
        }

        public eResultado InsertDetalleOtrosDUno(DetalleOtrosDTO DetaOtros)
        {
            return new DetalleOtrosDAO().InsertDetalleOtrosDUno(DetaOtros);
        }

        public List<LimpBuzonRetSolidosDTO> LimpBuzonRetSolidos(int Idobra, string fecDesde, string fecHasta)
        {
            return new DetalleOtrosDAO().LimpBuzonRetSolidos(Idobra, fecDesde, fecHasta);
        }
    }
}
