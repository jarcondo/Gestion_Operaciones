using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleConexionesBL
    {
        public List<DetalleConexionesDTO> ConsultaConexiones(int cab)
        {
            return new DetalleConexionesDAO().ConsultaConexiones(cab);
        }

        public eResultado InsertarConexiones(DetalleConexionesDTO DetaCon)
        {
            return new DetalleConexionesDAO().InsertarConexiones(DetaCon);
        }

        public eResultado ActualizaConexiones(DetalleConexionesDTO DetaCon)
        {
            return new DetalleConexionesDAO().ActualizaConexiones(DetaCon);
        }

        public eResultado EliminarConexiones(int idCon)
        {
            return new DetalleConexionesDAO().EliminarConexiones(idCon);
        }

        public eResultado InsertDetalleConexionesVacio(int cab)
        {
            return new DetalleConexionesDAO().InsertDetalleConexionesVacio(cab);
        }
    }
}
