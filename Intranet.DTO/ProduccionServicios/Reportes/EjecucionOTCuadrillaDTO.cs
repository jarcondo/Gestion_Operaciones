using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class EjecucionOTCuadrillaDTO
    {
        public string Base { get; set; }
        public string Obra { get; set; }
        public string FDesde { get; set; }
        public string FHasta { get; set; }
        public string Cuadrilla { get; set; }
        public decimal TotalSubAct { get; set; }
        public decimal TotalMat { get; set; }
        public decimal TotalRes { get; set; }
        public decimal Total { get; set; }
        public string Tipo { get; set; }
        public string Actividad { get; set; }
        public string Unidad { get; set; }
        public string SubActividad { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public string CuadrillaDesc { get; set; }

    }
}
