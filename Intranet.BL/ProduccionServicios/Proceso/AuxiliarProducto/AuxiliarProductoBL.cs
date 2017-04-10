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
    public class AuxiliarProductoBL
    {
        public List<AuxiliarProductoDTO> ListarAuxiliarProducto(int IdObra)
        {
            return new AuxiliarProductoDAO().ListarAuxilarProducto(IdObra);
        }
        public eResultado Insert(AuxiliarProductoDTO oAuxiliarProductoDTO)
        {
            return new AuxiliarProductoDAO().AuxiliarProductoInsert(oAuxiliarProductoDTO);
        }

        public eResultado Eliminar(int IdAuxiliarProducto)
        {
            return new AuxiliarProductoDAO().AuxiliarProductoDelete(IdAuxiliarProducto);
        }
    }
}
