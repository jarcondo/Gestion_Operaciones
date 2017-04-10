using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Reportes;
using System.Data;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class ConsumoMaterialBL
    {

        public List<DatosValorizacionDTO> ObtenerDatosExistenciaOT(int IdObra, DataTable ListaSgi)
        {
            return new ConsumoMaterialDAO().ObtenerDatosExistenciaOT(IdObra, ListaSgi);
        }

        public List<DatosValorizacionDTO> ObtenerVerificarMontos(int IdObra, DataTable ListaSgi)
        {
            return new ConsumoMaterialDAO().ObtenerVerificarMontos(IdObra, ListaSgi);
        }

        public List<CabeceraDTO> ObtenerCabeceraConsumo(int IdObra, string nroOT, string sgi, int correlativo,int usuario)
        {
            return new ConsumoMaterialDAO().ObtenerCabeceraConsumo(IdObra,usuario, sgi, correlativo, nroOT);
        }

        public List<ConsumoMaterialDTO> ObtenerDetalleConsumo(int IdCabecera)
        {
            return new ConsumoMaterialDAO().ObtenerDetalleConsumo(IdCabecera);
        }

        public DetalleDTO ObtenerDetallePorID(int IdDetalle)
        {
            return new ConsumoMaterialDAO().ObtenerDetallePorID(IdDetalle);
        }

        public DetalleSubActividadDTO ObtenerDetalleSubActividadPorID(int IdDetalleSubAct)
        {
            return new ConsumoMaterialDAO().ObtenerDetalleSubActividadPorID(IdDetalleSubAct);
        }

        public eResultado InsertarDetalleSubActividad(DetalleSubActividadDTO oDetSub, int idCuadrilla, int IdProveedor, int Usuario)
        {
            return new ConsumoMaterialDAO().InsertarDetalleSubActividad(oDetSub,idCuadrilla, IdProveedor, Usuario);
        }

        public eResultado InsertarDetalleMaterial(DetalleDTO oDet, int Usuario)
        {
            return new ConsumoMaterialDAO().InsertarDetalleMaterial(oDet, Usuario);
        }

        public int InsertarNuevaCabecera(CabeceraDTO oCabecera, int Usuario,ref int nroRegistro)
        {
            return new ConsumoMaterialDAO().InsertarNuevaCabecera(oCabecera, Usuario,ref nroRegistro);
        }

        public eResultado ActualizarCabecera(CabeceraDTO oCabecera, int Usuario)
        {
            return new ConsumoMaterialDAO().ActualizarCabecera(oCabecera, Usuario);
        }

        public eResultado ActualizarDetalle(DetalleDTO oDetalle, int Usuario)
        {
            return new ConsumoMaterialDAO().ActualizarDetalle(oDetalle, Usuario);
        }

        public eResultado ActualizarDetalleSubActividad(DetalleSubActividadDTO oDetalle, int IdCuadrilla, int IdProveedor, int Usuario)
        {
            return new ConsumoMaterialDAO().ActualizarDetalleSubActividad(oDetalle,IdCuadrilla, IdProveedor, Usuario);
        }

        public eResultado EliminarDetalle(int IdDetalle, int Usuario)
        {
            return new ConsumoMaterialDAO().EliminarDetalle(IdDetalle, Usuario);
        }

        public eResultado EliminarDetalleSubActividad(int IdDetalleSubAct, int Usuario)
        {
            return new ConsumoMaterialDAO().EliminarDetalleSubActividad(IdDetalleSubAct, Usuario);
        }

        public List<ConsumoMaterialDTO> ObtenerCargoSGIs(int IdCargoEntrega)
        {
            return new ConsumoMaterialDAO().ObtenerCargoSGIs(IdCargoEntrega);
        }

        public eResultado InsertarCargoSGI(int IdCargoEntrega, int IdObra, string IdCabecera, int Usuario)
        {
            return new ConsumoMaterialDAO().InsertarCargoSGI(IdCargoEntrega, IdObra, IdCabecera, Usuario);
        }

        public eResultado EliminarCargoSGI(int Usuario)
        {
            return new ConsumoMaterialDAO().EliminarCargoSGI(Usuario);
        }

        public List<CargoEntregaDTO> ObtenerCargoEntrega(int Usuario, int IdObra,string Ordenacion,int cargo)
        {
            return new ConsumoMaterialDAO().ObtenerCargoEntrega(Usuario,IdObra,Ordenacion,cargo);
        }

        public List<CargoSIODTO> ObtenerCargo(int IdObra,int usuario)
        {
            return new ConsumoMaterialDAO().ObtenerCargo(IdObra,usuario);
        }

        public int ValidarExistenciaCargo(string SGI)
        {
            return new ConsumoMaterialDAO().ValidarExistenciaCargo(SGI);
        }

        public eResultado InsertarCargoEntrada(int IdObra, string NombreCargo, int Usuario)
        {
            return new ConsumoMaterialDAO().InsertarCargoEntrada(IdObra, NombreCargo, Usuario);
        }

        public eResultado EliminarSGICargo(int IdObra, string sgi, int Usuario)
        {
            return new ConsumoMaterialDAO().EliminarSGICargo(IdObra, sgi, Usuario);
        }

        public eResultado ProcesarOTs(int idObra, int usuario)
        {
            return new ConsumoMaterialDAO().ProcesarOTs(idObra, usuario);
        }

        public List<EjecucionOTFechaDTO> ObtenerEjecucionOTFecha(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().ObtenerEjecucionOTFecha(IdObra, fecDesde, fecHasta);
        }

        public List<EjecucionOTCuadrillaDTO> ObtenerEjecucionOTCuadrilla(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().ObtenerEjecucionOTCuadrilla(IdObra, fecDesde, fecHasta);
        }

        public List<DatosValorizacionDTO> ObtenerDatosArchivoValidacion(int IdObra, int IdValorizacion)
        {
            return new ConsumoMaterialDAO().ObtenerDatosArchivoValidacion(IdObra, IdValorizacion);
        }

        public List<DatosValorizacionDTO> ObtenerDatosArchivoValidacion(int IdObra,DataTable ListaSgi)
        {
            return new ConsumoMaterialDAO().ObtenerDatosArchivoValidacion(IdObra, ListaSgi);
        }


        public List<RadioProduccionDTO> ObtenerCruceRadioProduccion(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().ObtenerCruceRadioProduccion(IdObra, fecDesde, fecHasta);
        }

        public List<CruceOTsDTO> ObtenerCruceOTsProduccion(int IdObra)
        {
            return new ConsumoMaterialDAO().ObtenerCruceOTsProduccion(IdObra);
        }

        public List<EjecucionOTFechaDTO> GenerarSEPC(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().GenerarSEPC(IdObra, fecDesde, fecHasta);
        }

        //public List<EjecucionOTFechaDTO> GenerarSEPC(int IdObra, int sgi)
        //{
        //    return new ConsumoMaterialDAO().GenerarSEPC(IdObra, sgi);
        //}


        public List<EjecucionOTFechaDTO> GenerarSEPI(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().GenerarSEPI(IdObra, fecDesde, fecHasta);
        }

        public eResultado ColocarSGIaOTmanuales(Int32 mSGI, Int32 midcabecera)
        {
            return new ConsumoMaterialDAO().ColocarSGIaOTmanuales(mSGI, midcabecera);
        }

        public List<OTValorizacionDTO> OTxValorizacion(int IdObra, DataTable ListaSgi)
        {
            return new ConsumoMaterialDAO().OTxValorizacion(IdObra, ListaSgi);
        }

        public List<OTValorizacionDTO> OTxDistrito(int IdObra, DataTable ListaSgi)
        {
            return new ConsumoMaterialDAO().OTxDistrito(IdObra, ListaSgi);
        }

        public List<CargoOTChorrillosDTO> CargoOTChorrillos(int Usuario, int IdObra, string Ordenacion, int cargo)
        {
            return new ConsumoMaterialDAO().CargoOTChorrillos(Usuario, IdObra, Ordenacion, cargo);
        }

        public List<EjecucionOTCuadrillaDTO> ObtenerEjecucionOTCuadrillaDet(int IdObra, string fecDesde, string fecHasta)
        {
            return new ConsumoMaterialDAO().ObtenerEjecucionOTCuadrillaDet(IdObra, fecDesde, fecHasta);
        }
        
    }
}
