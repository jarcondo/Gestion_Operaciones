﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.EjecucionOTFecha
{
    public class ReporteEjecucionFecha
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Sgi { get; set; }
        public string NumeroOrden { get; set; }
        public string Suministro { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Distrito { get; set; }
        public string Cuadrilla { get; set; }
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Horatermino { get; set; }
        public string SubActividad { get; set; }
        public decimal Diametro { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public string Actividad { get; set; }
        public string Tipo { get; set; }
        public string Unidad { get; set; }
    }
}