using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class DetalleMovimientoDTO
    {

        public int IdDetalleMovimiento { get; set; }
        public int IdCabecera { get; set; }
        public int Item { get; set; }
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion1 { get; set; }
        public int IdUnidad { get; set; }
        public string Unidad { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdLinea { get; set; }
        public string Linea { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitarioNacional { get; set; }
        public double PrecioUnitarioExtranjero { get; set; }
        public double TotalNacional { get; set; }
        public double TotalExtranjero { get; set; }
        public bool Estado { get; set; }
        
        public string   Urbanizacion { get; set; }
        public string   Direccion	{ get; set; }
        public string   Cliente	{ get; set; }
        public string   Sgi		{ get; set; }
        public string   Suministro		{ get; set; }
        public string   NumeroOrden	{ get; set; }
        public string   FechaOrden		{ get; set; }
        public string   FechaDigitacion		{ get; set; }
        public string   FechaProgramacion	{ get; set; }
        public string   FechaInicio		{ get; set; }
        public string   HoraInicio	{ get; set; }
        public string   FechaTermino		{ get; set; }
        public string   Horatermino		{ get; set; }
        public double   HorasTrabajadas	{ get; set; }
        public int      NumeroTrabajadores	{ get; set; }
        public string   CodigoCuadrilla		{ get; set; }
        public string   DescripcionEstado	{ get; set; }
        public string   Distrito	{ get; set; }
        public string   actividad	{ get; set; }															

        
    }
}


