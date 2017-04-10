using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetalleLimpiezaDTO
    {
        public int idLimpieza { get; set; }
        public int idCabecera { get; set; }
        public double longitud { get; set; }
        public double volumenExtraido { get; set; }
        public string diametro { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int idCuadrilla { get; set; }
        public string materialTubo { get; set; }
        public double tiranteFlujo { get; set; }
        public bool arena { get; set; }
        public bool piedra { get; set; }
        public bool cascajo { get; set; }
        public bool otros { get; set; }
        public string otrosDesc { get; set; }
    }
}
