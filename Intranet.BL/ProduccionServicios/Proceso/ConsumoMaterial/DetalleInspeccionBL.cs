using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleInspeccionBL
    {
        public List<DetalleInspeccionDTO> ConsultaInspeccion(int cab)
        {
            return new DetalleInspeccionDAO().ConsultaInspeccion(cab);
        }

        public eResultado ActualizaInspeccion(DetalleInspeccionDTO DetaCon)
        {
            return new DetalleInspeccionDAO().ActualizaInspeccion(DetaCon);
        }

        public eResultado InsertInspeccionVacio(int cab)
        {
            return new DetalleInspeccionDAO().InsertInspeccionVacio(cab);
        }
    }
}
