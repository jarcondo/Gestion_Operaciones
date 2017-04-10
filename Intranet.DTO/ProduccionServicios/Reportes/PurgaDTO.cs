using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Reportes
{
    public class PurgaDTO
    {
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Distrito { get; set; }
        public string sgi { get; set; }
        public string Suministro { get; set; }
        public int Sector { get; set; }
        public string FechaInicio { get; set; }
        public double TiempoPurga { get; set; }
        public double Presion { get; set; }
        public double Cloro { get; set; }
        public double ANF { get; set; }
        public string OpPrevMayor { get; set; }
        public string OpPrevMenor { get; set; }
        public string InopCorrectivo { get; set; }
        public string InopCambio { get; set; }
        public string Marca { get; set; }
        public int NroBocas { get; set; }
        public int NroTapas { get; set; }
        public string CGI { get; set; }
        public string Ubica { get; set; }
        public string SinMyT { get; set; }
        public string LosaDeteriorada { get; set; }
        public string MantSi { get; set; }
        public string MantNo { get; set; }
        public string CaracteristicaAgua { get; set; }
        public string ColorAgua { get; set; }
        public string DescargaEn { get; set; }
        public string DistanciaDescarga { get; set; }
        public string Observacion { get; set; }
    }
}
