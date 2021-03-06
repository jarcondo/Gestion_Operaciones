﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class CruceMaterialDTO
    {
        public int Item { get; set; }
        public int IdAuxiliar { get; set; }
        public string DescripcionAuxiliar { get; set; }
        public int IdCuadrilla { get; set; }
        public string CodigoCuadrilla { get; set; }
        public string DescripcionCuadrilla { get; set; }
        public decimal CantidadAlmacen { get; set; }
        public decimal CantidadEjecutada { get; set; }
        public decimal Diferencia { get; set; }
        public decimal EnProceso { get; set; }
        public decimal Justificado { get; set; }
        public decimal PrecioAuxiliar { get; set; }
        public decimal MontoAuxiliar { get; set; }
        public string CodigoCuadrilla2 { get; set; }
        public string Observacion { get; set; }
        public int IdCruceMaterial { get; set; }
        public string OrdenTrabajo { get; set; }
        public string Observacionjustificacion { get; set; }
        public decimal Teorico { get; set; }
        public string Observacionproceso { get; set; }

        public string FUENTE { get; set; }
        public int NumeroVale { get; set; }
        public string sgi { get; set; }
        public string NumeroOT { get; set; }
        public DateTime fecha { get; set; }
        public string DESCRIPCIONPRODUCTO { get; set; }

         public string subactividad { get; set; }
         public string material { get; set; }
         public string actividad { get; set; }
         public decimal Factor { get; set; }

         public decimal MontoAuxiliar2 { get; set; }
    }
}
