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
    public class ConsultaCatalogoAuxiliarBL
    {

        public List<ConsultaCatalogoAuxiliarDTO> ListarAuxiliarCatalogo(int IdObra)
        {
            return new ConsultaCatalogoAuxiliarDAO().ListarCatalogoAuxiliarObra(IdObra);
        }

        public List<ConsultaCatalogoAuxiliarDTO> ListarAuxiliarProducto()
        {
            return new ConsultaCatalogoAuxiliarDAO().ListarProductoAuxiliar();
        }


    }
}
