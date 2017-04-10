using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleCaracteristicasBL
    {
        public List<DetalleCaracteristicasDTO> SelectCaracteristicas(int cab)
        {
            return new DetalleCaracteristicasDAO().SelectCaracteristicas(cab);
        }

        public eResultado ActualizaCaracteristicas(DetalleCaracteristicasDTO DetaCon)
        {
            return new DetalleCaracteristicasDAO().ActualizaCaracteristicas(DetaCon);
        }

        public eResultado InsertDetalleCaracteristicasVacio(int cab)
        {
            return new DetalleCaracteristicasDAO().InsertDetalleCaracteristicasVacio(cab);
        }
    }
}
