using System;
using Intranet.DTO.Global;

namespace Intranet.DTO.SGE
{
    [Serializable]
    public class CuadrillaDTO
    {
        public int IdCuadrilla { get; set; }
        public int IdObra { get; set; }
        public string CodigoCuadrilla { get; set; }
        public string Descripcion { get; set; }
        public string CentroCosto { get; set; }
        public string CodigoObra { get; set; }
        public string DescripcionObra { get; set; }
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombresApellidos { get; set; }
        public eActivoFijo ActivoFijo { get; set; }
        public int IdGrupoCuadrilla { get; set; }
        public int IdSubGrupoCuadrilla { get; set; }
        public string DetalleZona { get; set; }
        public int IdResponsable { get; set; }
        public int IdArea { get; set; }
    }
}
