using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class EjecucionOTDTO
    {
        public int NroPosicion { get; set; }
        public Int32 IdEjecucionOT { get; set; }
        public string CodigoEjecucionOT {get; set;}
        public OrdenTrabajoDTO OrdenTrabajo {get; set;}
        public string Direccion { get; set; }
        public CuadrillaDTO Cuadrilla {get; set;}
        public EmpleadoDTO IdResponsable {get; set;}
        public string NombreResponsable { get; set; }
        public EstadoOTDTO EstadoOT {get; set;}
        public string FechaInicio {get; set;}
        public string HoraInicio {get; set;}
        public string FechaFin {get; set;}
        public string HoraFin {get; set;}
        public string FechaProg {get; set;}
        public GenericaDTO Area {get; set;}
        public GenericaDTO TipoTrabajo {get; set;}
        public string NroOrden {get; set;}
        public string FechaOrden {get; set;}
        public Boolean EstadoOrden { get; set; }
        public string Observacion {get; set;}
        public string FechaRegistro {get; set;}
        public string HoraRegistro {get; set;}
        public Boolean TuberiaRota { get; set; }
        public Boolean FugaToma { get; set; }
        public Boolean RoturaMedidor { get; set; }
        public Boolean Limpieza { get; set; }
        public Boolean Bombeo { get; set; }
        public Boolean PermisoMunicipal { get; set; }
        public string FechaPermiso { get; set; }
        public string Estatus { get; set; }
        public Int32 UsuarioCreacion {get; set;}
        public DateTime FechaCreacion {get; set;}
        public Int32 UsuarioModificacion {get; set;}
        public string UsuarioMod{ get; set; }
        public DateTime FechaModificacion {get; set;}
        public bool VBIngeniero { get; set; }
        public Int32 UsuarioVB { get; set; }
        public DateTime FechaVB { get; set; }
        public string UsuVBIngeniero { get; set; }
        public bool DMTU { get; set; }
        public string CUS { get; set; }
        public decimal Puntaje { get; set; }
        public int DiasEstimadoEjec { get; set; }
    }
}
