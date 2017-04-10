using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class LimpiezaColectoresMaqBaldesDTO
    {
        public string NumeroOrden { get; set; }
        public string fechaInicio { get; set; }
        public string sgi { get; set; }
        public string suministro { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Distrito { get; set; }
        public string Diametro { get; set; }
        public string Arena { get; set; }
        public string Cascajos { get; set; }
        public string Piedras { get; set; }
        public string Otros { get; set; }
        public string OtrosDesc { get; set; }
        public string MaterialTubo { get; set; }
        public string estado { get; set; }
        public double VolumenExt { get; set; }
        public double Longitud { get; set; }
        public double cantidad { get; set; }
        public string material { get; set; }

        public string DescripcionSubActividad1 { get; set; }
        public string CuadrillaLimpieza { get; set; }
        public string CuadrillaTelevisada { get; set; }
        public string Cuadrilla { get; set; }
        public int NroConexiones { get; set; }



    }
}
