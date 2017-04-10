using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial
{
    public class DetallePurgaDTO
    {
        public int IdPurga { get; set; }
        public int IdCabecera { get; set; }
        public int sector { get; set; }
        public double tiempoPurga { get; set; }
        public double presion { get; set; }
        public double cloro { get; set; }
        public double ANF { get; set; }
        public string caracteristicaAgua { get; set; }
        public bool opPrevMayor { get; set; }
        public bool opPrevMenor { get; set; }
        public bool InopCorrectivo { get; set; }
        public bool InopCambio { get; set; }
        public string marca { get; set; }
        public int nroBocas { get; set; }
        public int nroTapas { get; set; }
        public string CGI { get; set; }
        public bool ubica { get; set; }
        public bool sinMyT { get; set; }
        public bool losaDeteriorada { get; set; }
        public bool mantenimiento { get; set; }
        public string colorAgua { get; set; }
        public string descargaEn { get; set; }
        public double distanciaDescarga { get; set; }
        public string observacion { get; set; }
    }
}
