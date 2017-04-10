using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class DetalleDTO
    {
        public int IdDetalle {get; set;}
        public CabeceraDTO Cabecera {get; set;}
        public CatalogoDTO Catalogo {get; set;}
        public Decimal Cantidad {get; set;}
        public Decimal Costo { get; set; }
        public Boolean SGIO { get; set; }
        public string Observacion { get; set; }
    }
}
