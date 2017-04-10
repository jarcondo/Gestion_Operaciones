using System.Collections.Generic;

using Intranet.DTO.SGE;
using Intranet.DAO.SGE;
namespace Intranet.BL.SGE
{
    public class ObraBL
    {
        public List<ObraDTO> ListarObraTodas()
        {
            return new ObraDAO().ListarObraTodas();
        }

        public List<ObraDTO> ListarObra(int IdBase)
        {
            return new ObraDAO().ListarObra(IdBase);
        }

        public ObraDTO GetObraId(int idobra)
        {
            return new ObraDAO().GetObraId(idobra);
        }

        public List<ObraDTO> ListarObraCPxBase(int idbase)
        {
            return new ObraDAO().ListarObraCPxBase(idbase);
        }
    }
}
