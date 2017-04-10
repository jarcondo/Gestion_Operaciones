using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.SGE
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string CodigoProveedor { get; set; }
        public string Proveedor { get; set; }
        public string RUC { get; set; }
        public string Rubro { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string Contacto { get; set; }
        public string Referencia { get; set; }
        public int Entrega { get; set; }
        public int IdFormaPago { get; set; }
        public string Fax { get; set; }
        public int IdRubro { get; set; }
        public bool ProveedorGeneral { get; set; }
        public int IdBase { get; set; }
        public Boolean CP { get; set; }
    }
}
