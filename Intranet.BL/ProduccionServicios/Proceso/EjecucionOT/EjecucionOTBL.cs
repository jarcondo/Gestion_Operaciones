using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using System.Data;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class EjecucionOTBL
    {
        public List<EjecucionOTMasivaGridDTO> GetEjecucionOTPorObra(int IdObra, string SGI, int IdEstado, string NIS, string direccion, int NroRegistro, string fdesde, string fhasta, string NroOrden, int IdCuadrilla)
        {
            return new EjecucionOTDAO().GetEjecucionOTPorObra(IdObra, SGI, IdEstado, NIS, direccion, NroRegistro, fdesde, fhasta, NroOrden, IdCuadrilla);
            
        }

        public List<EjecucionOTGridDTO> GetEjecucionOTGridPorObra(int IdObra, string NroOT, int IdEstado, string NIS, string direccion, int NroRegistro, string fdesde, string fhasta, string NroOrden, int IdCuadrilla,int area)
        {
            return new EjecucionOTDAO().GetEjecucionOTGridPorObra(IdObra, NroOT, IdEstado, NIS, direccion,NroRegistro, fdesde,  fhasta, NroOrden, IdCuadrilla,area);
        }

        public EjecucionOTDTO GetEjecucionOTPorID(int IdEjecucionOT)
        {
            return new EjecucionOTDAO().GetEjecucionOTPorID(IdEjecucionOT);
        }

        public EjecucionOTDTO GetEjecucionOTPorNroRegistro(int NroRegistro)
        {
            return new EjecucionOTDAO().GetEjecucionOTPorNroRegistro(NroRegistro);
        }

        public eResultado InsertarEjecucionOT(EjecucionOTDTO oEjecucionOT)
        {
            return new EjecucionOTDAO().InsertarEjecucionOT(oEjecucionOT);
        }

        public eResultado ActualizarEjecucionOT(EjecucionOTDTO oEjecucionOT)
        {
            return new EjecucionOTDAO().ActualizarEjecucionOT(oEjecucionOT);
        }

        public List<EjecucionOTGridDTO> GetEjecucionOTGridPorObraSinSGI(int IdObra, string f_alta, int IdEstado, string NIS, string direccion,string cliente)
        {
            return new EjecucionOTDAO().GetEjecucionOTGridPorObraSinSGI(IdObra, f_alta, IdEstado, NIS, direccion, cliente);
        }
                                                //  //usp_monitoreo 20,0,0,'1,2,3,45,100,154','02/03/2017','02/03/2017',0,'INICIO',0   
        public List<EjecucionOTGridDTO> MonitoreoOperacion(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, string fecDesde, string fecHasta, int idarea, string tipoFecha, string SinCuadrilla,string cliente)
        {
            return new EjecucionOTDAO().MonitoreoOperacion(IdObra, IdCuadrilla, IdTipoTrabajo, IdEstadoOT, fecDesde, fecHasta, idarea, tipoFecha, SinCuadrilla,cliente);
        }
        public List<ProgramacionCuadrillaDTO> ObtenerProgramacionCuadrilla(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, string fecDesde, string fecHasta, int idarea, string tipoFecha,string SinCuadrilla)
        {
            return new EjecucionOTDAO().ObtenerProgramacionCuadrilla(IdObra, IdCuadrilla, IdTipoTrabajo, IdEstadoOT, fecDesde, fecHasta, idarea, tipoFecha, SinCuadrilla);
        }

        public List<PermisoMunicipalDTO> ObtenerProgramacionPermisoMunicipal(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, bool PermisoMunicipal, string fecDesde, string fecHasta)
        {
            return new EjecucionOTDAO().ObtenerProgramacionPermisoMunicipal(IdObra, IdCuadrilla, IdTipoTrabajo, IdEstadoOT, PermisoMunicipal, fecDesde, fecHasta);
        }

        public List<ProgramacionCuadrillaDTO> ObtenerProgramacionTC(int IdObra, string TipoTC, string Ejecutor, int IdEjecutor, string IdEstadoOT, string fecDesde, string fecHasta, int IdArea, string tipoObservacion)
        {
            return new EjecucionOTDAO().ObtenerProgramacionTC(IdObra, TipoTC, Ejecutor, IdEjecutor, IdEstadoOT, fecDesde, fecHasta, IdArea, tipoObservacion);
        }

        public eResultado AsignarOTSinSGI(int IdEjecucionConSGI, int IdEjecucionSinSGI)
        {
            return new EjecucionOTDAO().AsignarOTSinSGI(IdEjecucionConSGI, IdEjecucionSinSGI);
        }

        public eResultado AsignarMasivoCuadrillaEstado(List<EjecucionOTMasivaGridDTO> olMasivo, int IdCuadrilla, int IdEstadoOT, int Usuario)
        {
            return new EjecucionOTDAO().AsignarMasivoCuadrillaEstado(olMasivo, IdCuadrilla, IdEstadoOT, Usuario);
        }

        public eResultado InsertarError(string Error, int Usuario)
        {
            return new EjecucionOTDAO().InsertarError(Error, Usuario);
        }

        //public List<MontoEstadoDTO> ObtenerMontosEstado(int obra, string estado, int responsable, int cuadrilla, string fechaini, string fechafin)
        //{
        //    return new EjecucionOTDAO().ObtenerMontosEstado(obra, estado, responsable, cuadrilla, fechaini, fechafin);
        //}

        //public List<MontoEstadoDTO> ObtenerMontosEstadoResumen(int obra, string estado, int responsable, int cuadrilla, string fechaini, string fechafin)
        //{
        //    return new EjecucionOTDAO().ObtenerMontosEstadoResumen(obra, estado, responsable, cuadrilla, fechaini, fechafin);
        //}

        public List<MontoEstadoDTO> ObtenerReporteMontoEstado(int obra, string fechaini, string fechafin)
        {
            return new EjecucionOTDAO().ObtenerReporteMontoEstado(obra, fechaini, fechafin);
        }

        public List<ObservacionEstadisticaDTO> ObtenerObservacionOT(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, string fecDesde, string fecHasta, int idarea, string tipoObservacion)
        {
            return new EjecucionOTDAO().ObtenerObservacionOT(IdObra, IdCuadrilla, IdTipoTrabajo, IdEstadoOT, fecDesde, fecHasta, idarea, tipoObservacion);
        }

        public List<VBIngenieroDTO> ObtenerVBIngenieros(int IdObra, int IdResponsable, bool ConVB)
        {
            return new EjecucionOTDAO().ObtenerVBIngenieros(IdObra, IdResponsable, ConVB);
        }

        public List<DMTUDTO> GetEjecucionOTDMTU(int IdObra, string fDesde, string fHasta)
        {
            return new EjecucionOTDAO().GetEjecucionOTDMTU(IdObra, fDesde, fHasta);
        }
    }
}
