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
    public class DetalleLimpiezaBL
    {
        public List<DetalleLimpiezaDTO> ConsultaLimpieza(int cab)
        {
            return new DetalleLimpiezaDAO().ConsultaLimpieza(cab);
        }

        public eResultado ActualizaLimpieza(DetalleLimpiezaDTO DetaLimpia)
        {
            return new DetalleLimpiezaDAO().ActualizaLimpieza(DetaLimpia);
        }

        public eResultado InsertLimpiezaVacio(int cab)
        {
            return new DetalleLimpiezaDAO().InsertLimpiezaVacio(cab);
        }

        public List<LimpiezaColectoresMaqBaldesDTO> LimpiezaColectorMaqBalde(int IdObra, string fecDesde, string fecHasta)
        {
            return new DetalleLimpiezaDAO().LimpiezaColectorMaqBalde(IdObra, fecDesde, fecHasta);
        }

        public List<LimpiezaColectoresMaqBaldesDTO> OrdLimpColectCambioTapaBuz(int IdObra, string fecDesde, string fecHasta)
        {
            return new DetalleLimpiezaDAO().OrdLimpColectCambioTapaBuz(IdObra, fecDesde, fecHasta);
        }

        public List<LimpiezaColectoresMaqBaldesDTO> LimpiezaColBaldeHidro(int IdObra, string fecDesde, string fecHasta)
        {
            return new DetalleLimpiezaDAO().LimpiezaColBaldeHidro(IdObra, fecDesde, fecHasta);
        }
    }
}
