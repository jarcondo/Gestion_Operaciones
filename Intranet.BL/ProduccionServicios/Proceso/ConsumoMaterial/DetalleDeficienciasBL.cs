using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.Global;

namespace Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleDeficienciasBL
    {
        public eResultado InsertarDeficiencias(DetalleDeficienciasDTO DetaDef)
        {
            return new DetalleDeficienciasDAO().InsertarDeficiencias(DetaDef);
        }

        public List<DetalleDeficienciasDTO> ConsultaDeficiencias(int cab)
        {
            return new DetalleDeficienciasDAO().ConsultaDeficiencias(cab);
        }

        public eResultado ActualizaDeficiencias(DetalleDeficienciasDTO DetaCon)
        {
            return new DetalleDeficienciasDAO().ActualizaDeficiencias(DetaCon);
        }

        public eResultado EliminarDeficiencias(int idCon)
        {
            return new DetalleDeficienciasDAO().EliminarDeficiencias(idCon);
        }

        public eResultado InsertDeficienciasVacio(int cab)
        {
            return new DetalleDeficienciasDAO().InsertDeficienciasVacio(cab);
        }
    }
}
