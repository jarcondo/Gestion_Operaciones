using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.BL.ProduccionServicios.Maestra
{
    public class CatalogoBL
    {
        public List<CatalogoDTO> ListarCatalogo(int IdObra)
        {
            return new CatalogoDAO().ListarCatalogo(IdObra);
        }

        public List<CatalogoDTO> ListarPorActividad(int IdObra, int IdActividad)
        {
            return new CatalogoDAO().ListarPorActividad(IdObra, IdActividad);
        }
    }
}
