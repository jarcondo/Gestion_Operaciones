using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class CabeceraDTO
    {
        public int IdCabecera {get; set;} 
        public ObraDTO Obra {get; set;} 
        public DistritoDTO Distrito {get; set;} 
        public string Urbanizacion {get; set;}
        public string Direccion {get; set;}
        public string Cliente {get; set;} 
        public string Sgi {get; set;} 
        public string Suministro {get; set;}
        public string NumeroOrden {get; set;}
        public string FechaOrden {get; set;}
        public ActividadDTO Actividad {get; set;}
        public string FechaDigitacion {get; set;}
        public string FechaProgramacion {get; set;}
        public string FechaInicio {get; set;}
        public string HoraInicio {get; set;}
        public string FechaTermino {get; set;} 
        public string Horatermino {get; set;}
        public Decimal HorasTrabajadas {get; set;}
        public int NumeroTrabajadores {get; set;}
        public CuadrillaDTO Cuadrilla {get; set;}
        public string IdZona {get; set;}
        public EstadoOTDTO EstadoOT {get; set;}
        public string Mes {get; set;}
        public string Anno {get; set;}
        public int IdValorizacion {get; set;}
        public Boolean Estado {get; set;}
        public int NroRegistro { get; set; }
        public decimal CostoOPEN { get; set; }
        public EstadoOTDTO EstadoOTRO { get; set; }
        public string NroCargo { get; set; }
        public string Observacion { get; set; }
    }
}
