using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.Global;
using System.Data;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class ValorizacionBL
    {
        public List<ValorizacionDTO> ObtenerValorizacion(int IdObra)
        {
            return new ValorizacionDAO().ObtenerValorizacion(IdObra);
        }

        public eResultado InsertarValorizacion(ValorizacionDTO oVal, int Usuario)
        {
            return new ValorizacionDAO().InsertarValorizacion(oVal, Usuario);
        }

        public eResultado ActualizarCabeceraValorizacion(int IdObra, string sgi, int idValorizacion,int estado, int usuario)
        {
            return new ValorizacionDAO().ActualizarCabeceraValorizacion(IdObra, sgi, idValorizacion,estado, usuario);
        }

        public DataRow ValidarSGI(int IdObra, string sgi)
        {
            return new ValorizacionDAO().ValidarSGI(IdObra, sgi);
        }
    }
}
