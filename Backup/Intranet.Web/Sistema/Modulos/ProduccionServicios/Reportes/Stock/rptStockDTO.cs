using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Stock
{
    public class rptStockDTO
    {
        public string CodigoProducto { get; set; }
        public string Descripcion1 { get; set; }
        public string A2 { get; set; }
        public double MantoVes { get; set; }
        public double MantoCho { get; set; }
        public double AguaCentro { get; set; }
        public double AguaNorte { get; set; }
        public double PozosSur { get; set; }
        public double PrevItem2 { get; set; }
        public double PrevItem1 { get; set; }
        public double MantoPte { get; set; }
        public double MantoCallao { get; set; }
    }
}
