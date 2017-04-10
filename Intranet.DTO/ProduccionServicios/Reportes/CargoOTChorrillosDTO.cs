using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class CargoOTChorrillosDTO
    {
        public string sgi { get; set; }
        public string Suministro { get; set; }
        public string FechaDigitacion { get; set; }
        public string DescEstado{ get; set; }
        public string Actividad { get; set; }
        public string SubActividad { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Cserv { get; set; }
        public string NroOrden { get; set; }
        public string FechaInicio { get; set; }
        public double Sca { get; set; }
        public double CostoOT { get; set; }
        public double Diferencia { get; set; }
        
    }
}
