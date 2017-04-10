using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class PuntajesDTO
    {
        public string numeroorden { get; set; }
        public string fechainicio { get; set; }
        public string direccion { get; set; }
        public string descripcionsubactividad { get; set; }
        public string unidad { get; set; }
        public decimal puntaje { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public string codigocuadrilla { get; set; }
        public string descripcioncuadrilla { get; set; }
        public string NombresApellidos { get; set; }
        public string Mes { get; set; }
        public string Anno { get; set; }
        public string ResponsableActividad { get; set; }
    }
}
