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
    public class ZonaBL
    {
        public List<ZonaDTO> ListarZona(int IdDistrito)
        {
            return new ZonaDAO().ListarZona(IdDistrito);
        }
        public List<ZonaDTO> ListarZona2()
        {
            return new ZonaDAO().ListarZona2();
        }

        public List<ZonaDTO> ListarZona3(int IdObra)
        {
            return new ZonaDAO().ListarZona3(IdObra);
        }

        public eResultado Delete(int IdZona,int IdObra)
        {
            return new ZonaDAO().DeleteZona(IdZona,IdObra);
        }
        public eResultado Insert(string DescripcionZona, int IdDistrito , int IdObra)
        {
            return new ZonaDAO().InsertarZona(DescripcionZona,IdDistrito,IdObra);
        }
        public eResultado Update(string DescripcionZona, int IdDistrito, int IdZona ,int IdObra)
        {
            return new ZonaDAO().UpdateZona(DescripcionZona,IdDistrito,IdZona,IdObra);
        }
    }
}
