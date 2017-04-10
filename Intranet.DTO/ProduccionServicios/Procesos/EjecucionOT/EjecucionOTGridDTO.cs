using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class EjecucionOTGridDTO
    {
        public int Item { get; set; }
        public int NroRegistro { get; set; }
        public int IdEjecucionOT { get; set; }
        public string NroOT { get; set; }
        public string NIS { get; set; }
        public string NroOrden { get; set; }
        public string DesCuadrilla { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public string Localidad { get; set; }
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public string SubActividad { get; set; }
        public string Descripcion { get; set; }
        public string FechaAlta { get; set; }
        public string Estado { get; set; }
        public bool CambioMasivo { get; set; }
        public string TipoTrabajo { get; set; }
        public string Ingeniero { get; set; }
        public string FechaHoraIni { get; set; }
        public string FechaHoraFin { get; set; }
        public string GESTION { get; set; }
        public int diascont { get; set; }
    }
}
