using System.Collections.Generic;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using System.Data;
using System;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class OrdenTrabajoBL
    {
        public List<OrdenTrabajoDTO> CargarOrdenTrabajoCliente(string rutaArchivo, ref string resultado, int IdObra, int CentroServicio, int nroContrato,int idusuario)
        {
            return new OrdenTrabajoDAO().CargarOrdenTrabajoCliente(rutaArchivo,ref resultado,IdObra, CentroServicio, nroContrato,idusuario);
        }

        public eEstadoTransaccion InsertarOrdenTrabajo(ArchivoCargaOTDTO oArchivo, List<OrdenTrabajoDTO> olOrdenTrabajo)
        {
            return new OrdenTrabajoDAO().InsertarOrdenTrabajo(oArchivo, olOrdenTrabajo);
        }

        public List<OrdenTrabajoDTO> GetOrdenTrabajo(int IdObra)
        {
            return new OrdenTrabajoDAO().GetOrdenTrabajo(IdObra);
        }

        public OrdenTrabajoDTO GetOrdenTrabajoPorID(int IdOrdenTrabajo)
        {
            return new OrdenTrabajoDAO().GetOrdenTrabajoPorID(IdOrdenTrabajo);
        }

        public DataTable ObtenerDatosValidacion(int IdObra, string NroOT)
        {
            return new OrdenTrabajoDAO().ObtenerDatosValidacion(IdObra, NroOT);
        }

        public DataTable ObtenerDatosDetalleValidacion(int IdObra, string NroOT)
        {
            return new OrdenTrabajoDAO().ObtenerDatosDetalleValidacion(IdObra, NroOT);
        }

        public Boolean ObtenerValidacionOT(int IdObra, string NroOT)
        {
            try
            {
                return new OrdenTrabajoDAO().ObtenerValidacionOT(IdObra, NroOT);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public eResultado InsertarOrdenTrabajoSinSGI(OrdenTrabajoDTO oOrdenTrabajo, int IdObra, int Usuario)
        {
            return new OrdenTrabajoDAO().InsertarOrdenTrabajoSinSGI(oOrdenTrabajo, IdObra, Usuario);
        }

        public eResultado ActualizarOrdenTrabajoSinSGI(EjecucionOTDTO oEjecucionOT, int Usuario)
        {
            return new OrdenTrabajoDAO().ActualizarOrdenTrabajoSinSGI(oEjecucionOT, Usuario);
        }
    }
}
