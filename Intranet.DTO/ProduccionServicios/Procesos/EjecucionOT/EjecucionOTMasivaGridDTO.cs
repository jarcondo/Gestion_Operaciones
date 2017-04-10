using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class EjecucionOTMasivaGridDTO
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
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public string Descripcion { get; set; }
        public string FechaAlta { get; set; }
        public string Estado { get; set; }

        public string os_ot { get; set; }
        public int ncod_centro { get; set; }
        public string center { get; set; }
        public string nro_ot { get; set; }
        public string nis_rad { get; set; }
        public string cliente { get; set; }
        public string municipio { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public int nest_ot { get; set; }
        public int actividad { get; set; }
        public string desc_actividad { get; set; }
        public int subactividad { get; set; }
        public string desc_subactividad { get; set; }
        public decimal ncosto_ot { get; set; }
        public string vobservacion_contrata { get; set; }
        public DateTime f_alta { get; set; }
        public DateTime f_ini { get; set; }
        public DateTime f_fin { get; set; }
        public DateTime f_atendido { get; set; }
        public DateTime f_res_contrata { get; set; }
        public string tipo_red { get; set; }
        public int ntip_red { get; set; }
        public string vdescripcion { get; set; }
        public string vref_direccion { get; set; }
        public string vusuario { get; set; }
        public int nres_contrata { get; set; }
        public int ncod_cuadrilla { get; set; }
        public int ncod_incidencia { get; set; }
        public int ncod_factura { get; set; }
        public string secs { get; set; }
        public string secsfin { get; set; }
        public string ot_contrata { get; set; }
        public int ntip_ot { get; set; }
        public string tipo_ot { get; set; }
        public int nnum_os { get; set; }
    }
}
