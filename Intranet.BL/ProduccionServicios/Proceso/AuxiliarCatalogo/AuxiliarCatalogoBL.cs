using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class AuxiliarCatalogoBL
    {
        public List<AuxiliarCatalogoDTO> ListarAuxiliarCatalogo(int IdObra)
        {
            return new AuxiliarCatalogoDAO().ListarAuxilarCatalogo(IdObra);
        }

        public eResultado Insert(AuxiliarCatalogoDTO oAuxiliarCatalogoDTO)
        {
            return new AuxiliarCatalogoDAO().AuxiliarCatalogoUpdate(oAuxiliarCatalogoDTO);
        }

        public eResultado Eliminar(AuxiliarCatalogoDTO oAuxiliarCatalogoDTO)
        {
            return new AuxiliarCatalogoDAO().AuxiliarCatalogoDelete(oAuxiliarCatalogoDTO);
        }
    }
}
