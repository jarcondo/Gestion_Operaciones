using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.TrabajoComplementario
{
    public class ProgramacionDTO
    {
        public int NroRegistro { get; set; }
        public int DiasCont { get; set; }
        public int IdOrdenTrabajo { get; set; }
        public string nro_ot { get; set; }
        public string nis_rad { get; set; }
        public string municipio { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
        public int actividad { get; set; }
        public string desc_actividad { get; set; }
        public int subactividad { get; set; }
        public string desc_subactividad { get; set; }
        public DateTime f_alta { get; set; }
        public string vusuario { get; set; }
        public Int32 IdEjecucionOT { get; set; }
        public string direccionCONCYSSA { get; set; }
        public int IdEjecutor { get; set; }
        public string NombreEjecutor { get; set; }
        public int IdCuadrilla { get; set; }
        public string NombreCuadrilla { get; set; }
        public int IdResponsable { get; set; }
        public string NombreResponsable { get; set; }
        public int IdEstadoOT { get; set; }
        public string NombreEstadoOT { get; set; }
        public int IdEstadoTC { get; set; }
        public string NombreEstadoTC { get; set; }
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaFin { get; set; }
        public string HoraFin { get; set; }
        public string FechaProg { get; set; }
        public string HoraProg { get; set; }
        public int IdArea { get; set; }
        public string NombreArea { get; set; }
        public int IdTipoTrabajo { get; set; }
        public string NombreTipoTrabajo { get; set; }
        public string ObservacionCONCYSSA { get; set; }
        public string NroOrden { get; set; }

        public int Cantidad { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public int Parantes { get; set; }
        public int Tranqueras { get; set; }
        public int Machones { get; set; }

        public decimal Cubico { get; set; }
        public decimal Relleno { get; set; }
        public string Titulo { get; set; }
    }
}