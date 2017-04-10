using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.Global;
using System.Data;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class CargaConsumoBL
    {
        public List<DetalleConsumoDTO> CargarConsumoCliente(string rutaCabecera, string rutaDetalle, ref List<CabeceraConsumoDTO> olCabecera, ref string Mensaje, int CentroServicio, int nroContrato, string EstadoCarga,
            Int32 IdObra, ref List<CabeceraConsumoDTO> olCabecerasActualizar, ref List<CabeceraConsumoDTO> olCabecerasInsertar)
        {
            return new CargaConsumoDAO().CargarConsumoCliente(rutaCabecera, rutaDetalle, ref olCabecera, ref Mensaje, CentroServicio, nroContrato, EstadoCarga,IdObra,ref olCabecerasActualizar, ref olCabecerasInsertar);
        }

        public void CargarConsumoCliente(string rutaCabecera, string rutaDetalle, ref DataTable datosgrilla, ref DataTable cab, ref DataTable det, ref string Mensaje
        , int CentroServicio, int nroContrato, string EstadoCarga, Int32 IdObra, int idusuario)
        {
            new CargaConsumoDAO().CargarConsumoCliente(rutaCabecera, rutaDetalle,ref datosgrilla ,ref cab, ref det, ref Mensaje, CentroServicio, nroContrato, EstadoCarga, IdObra, idusuario);
        }

        public eEstadoTransaccion CargarConsumoServidor(int IdObra, int UsuarioCrea, DataTable olCabeceraInsertar, DataTable olDetalleInsertar)
        {
            return new CargaConsumoDAO().CargarConsumoServidor(IdObra, UsuarioCrea, olCabeceraInsertar,  olDetalleInsertar);
        }

        public eEstadoTransaccion CargarConsumoServidor(int IdObra, int UsuarioCrea, List<CabeceraConsumoDTO> olCabeceraInsertar, List<CabeceraConsumoDTO> olCabeceraActualizar, List<DetalleConsumoDTO> olDetalleInsertar)
        {
            return new CargaConsumoDAO().CargarConsumoServidor(IdObra,UsuarioCrea,olCabeceraInsertar,olCabeceraActualizar,olDetalleInsertar);
        }
    }
}
