using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class ConsumoMaterialDTO
    {
        public int Item { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public Boolean SGIO { get; set; }
        public string Observacion { get; set; }
    }
}
