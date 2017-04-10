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
   public class AuxiliarBL
    {
       public List<AuxiliarDTO> ListarAuxiliar(int IdObra)
       {
           return new AuxiliarDAO().ListarAuxilar(IdObra);
       }

       public eResultado Insert(AuxiliarDTO oAuxiliarDTO)
       {
           return new AuxiliarDAO().AuxiliarInsert(oAuxiliarDTO);
       }
    }
}
