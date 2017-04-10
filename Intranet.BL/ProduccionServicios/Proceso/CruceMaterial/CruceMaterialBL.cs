using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.SGE;

namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class CruceMaterialBL
    {
        public List<CruceMaterialDTO> ListarCruceMaterial(int IdObra, string FechaIni, string FechaFin,int IdCruceMaterial ,int IdResponsable)
        {
            return new CruceMaterialDAO().ListarCruceMaterial(IdObra, FechaIni, FechaFin,IdCruceMaterial ,IdResponsable);
        }
        public List<CruceMaterialDTO> ListarRptCruceMaterialDetallado(int IdObra, string FechaIni, string FechaFin, int IdResponsable ,int IdCuadrilla , string TipoMaterial )
        {
            return new CruceMaterialDAO().ListarRptCruceMaterialDetalle(IdObra, FechaIni, FechaFin, IdResponsable, IdCuadrilla, TipoMaterial);
        }
        public List<CruceMaterialDTO> ListarRptCruceMaterialDetalladoTeorico(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla, string TipoMaterial)
        {
            return new CruceMaterialDAO().ListarRptCruceMaterialDetalleTeorico(IdObra, FechaIni, FechaFin, IdResponsable, IdCuadrilla, TipoMaterial);
        }

        public List<CruceMaterialDTO> ListarRptCruceMaterialDetalladoProducto(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla, string TipoMaterial,int IdAuxiliar)
        {
            return new CruceMaterialDAO().ListarRptCruceMaterialDetalleProducto(IdObra, FechaIni, FechaFin, IdResponsable, IdCuadrilla, TipoMaterial, IdAuxiliar);
        }

        public List<CruceMaterialDTO> ListarCruceMaterialNoValorizable(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable)
        {
            return new CruceMaterialDAO().ListarCruceMaterialNoValorizable(IdObra, FechaIni, FechaFin, IdCruceMaterial, IdResponsable);
        }
        public List<CruceMaterialDTO> ListarCruceMaterialPorCuadrilla(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable ,int IdCuadrilla)
        {
            return new CruceMaterialDAO().ListarCruceMaterialPorCuadrilla(IdObra, FechaIni, FechaFin, IdCruceMaterial, IdResponsable , IdCuadrilla);
        }
        public List<CruceMaterialDTO> ListarCruceMaterialPorCuadrillaNoValorizable(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable, int IdCuadrilla)
        {
            return new CruceMaterialDAO().ListarCruceMaterialPorCuadrillaNoValorizable(IdObra, FechaIni, FechaFin, IdCruceMaterial, IdResponsable, IdCuadrilla);
        }

        public List<CabeceraCruceMaterialDTO> ListarCabeceraCruceMaterial(int IdObra,int IdResponsable)
        {
            return new CruceMaterialDAO().ListarCabeceraCruceMaterial(IdObra , IdResponsable);
        }
        public List<EmpleadoDTO> ListarEmpleadoCargo(int IdBase)
        {
            return new  CruceMaterialDAO().ListarEmpleadoCargo(IdBase);
        }

        public List<EmpleadoDTO> ListarEmpleadoCargo2(int IdObra)
        {
            return new CruceMaterialDAO().ListarEmpleadoCargo2(IdObra);
        }

        public List<EmpleadoDTO> ListarEmpleadoCargo3()
        {
            return new CruceMaterialDAO().ListarEmpleadoCargo3();
        }
        public eResultado CabeceraCruceMaterialInsert(CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO)
        {
            return new CruceMaterialDAO().CabeceraCruceMaterialInsert(oCabeceraCruceMaterialDTO);
        }
        public eResultado CruceMaterialObservacionInsert(ObservacionCrucematerialDTO ObservacionCrucematerialDTO)
        {
            return new CruceMaterialDAO().CruceMaterialObservacionInsert(ObservacionCrucematerialDTO);
        }
        public eResultado CabeceraCruceMaterialUpdate(CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO)
        {
            return new CruceMaterialDAO().CabeceraCruceMaterialUpdate(oCabeceraCruceMaterialDTO);
        }
        public eResultado CruceMaterialObservacionJustificacionInsert(ObservacionCrucematerialDTO ObservacionCrucematerialDTO)
        {
            return new CruceMaterialDAO().CruceMaterialObservacionJustificacionInsert(ObservacionCrucematerialDTO);
        }

        public eResultado CruceMaterialDelete( int IdCruceMaterial)
        {
            return new CruceMaterialDAO().CruceMaterialDelete(IdCruceMaterial);
        }


    }
}