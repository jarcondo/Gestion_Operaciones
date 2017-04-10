using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.SGE;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    [Serializable]
    public class ArchivoCargaOTDTO
    {
        public int IdArchivoCargaOT {get; set;}
	    public string ArchivoRuta {get; set;}
	    public string DescripcionCarga {get; set;}
        public int UsuarioCarga { get; set; }
	    public DateTime FechaCarga {get; set;}
        public ObraDTO Obra { get; set; }
    }
}
