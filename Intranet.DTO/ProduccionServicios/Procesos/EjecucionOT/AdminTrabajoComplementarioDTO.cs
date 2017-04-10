using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class AdminTrabajoComplementarioDTO
    {
        public int Item { get; set; } //campo usado a nivel de clase (no existe en BD)
        public int IdAdmTraCom {get; set;}
        public EjecucionOTDTO EjecucionOT {get; set;}
        public TrabajoComplementarioDTO TrabajoComplementario {get; set;}
        public string DesignadoA {get; set;}
        public CuadrillaDTO Cuadrilla {get; set;}
        public ProveedorDTO Proveedor {get; set;}
        public decimal Cantidad {get; set;}
        public string DetalleCantidad { get; set; }
        public decimal CostoProgramado {get; set;}
        public decimal Total {get; set;}
        public decimal Relleno { get; set; }
        public string FechaProgramada { get; set; }
        public string FecInicio { get; set; }
        public string FecFin { get; set; }
        public EstadoOTDTO EstadoOT {get; set;}
        public string Observacion { get; set; }
        public int UsuarioCrea {get; set;}
        public DateTime FechaCrea {get; set;}
        public int UsuarioModi {get; set;}
        public DateTime FechaModi {get; set;}
        public string Usuario { get; set; }

        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}
