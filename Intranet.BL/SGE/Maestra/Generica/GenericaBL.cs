using System.Collections.Generic;

using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DAO.SGE;

namespace Intranet.BL.SGE
{
    public class GenericaBL
    {
        public List<GenericaDTO> GetGenerica(eTabla nomtabla)
        {
            return new GenericaDAO().GetGenerica(nomtabla);
        }
    }
}
