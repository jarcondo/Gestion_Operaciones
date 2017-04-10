using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.SGE
{
    public class ObraDTO : EventArgs
    {
        public int IdObra { get; set; }
        public int IdBase { get; set; }
        public string CodigoObra { get; set; }
        public string Descripcion { get; set; }
        public string DescripBase { get; set; }
        public string DescripcionCorta { get; set; }
        public int IdDivision { get; set; }
        public Boolean CP { get; set; }


    }
}
