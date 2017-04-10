using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.ProduccionServicios.Procesos
{
    public class CabeceraMovimientoDTO
    {
        public int IdCabecera { get; set; }
        public int IdTipoDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public string DescripcionDocumento { get; set; }
        public decimal PorcentajeIgv { get; set; }
        public int IdBase { get; set; }
        public string CodigoBase { get; set; }
        public string DescripcionBase { get; set; }
        public string Seriedoc { get; set; }
        public string Numdoc { get; set; }
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombresApellidos { get; set; }
        public int IdAlmacen { get; set; }
        public string CodigoAlmacen { get; set; }
        public string DescripcionAlmacen { get; set; }
        public int IdObra { get; set; }
        public string CodigoObra { get; set; }
        public string Descripcion { get; set; }
        public int IdCuadrilla { get; set; }
        public string CodigoCuadrilla { get; set; }
        public string DescripcionCuadrilla { get; set; }
        public string CentroCosto { get; set; }
        public int IdMovimiento { get; set; }
        public string CodigoMovimiento { get; set; }
        public string DescripcionMovimiento { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaHoraSistema { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public string Referencia { get; set; }
        public string NumeroRequierimiento { get; set; }

        public decimal SubtotalNacional { get; set; }
        public decimal SubTotalExtranjero { get; set; }
        public decimal IgvNacional { get; set; }
        public decimal IgvExtranjero { get; set; }

        public decimal TotalNacional { get; set; }
        public decimal TotalExtranjero { get; set; }
        public string TotalLetrasNacional { get; set; }
        public string TotalLetrasExtranjero { get; set; }
        public string Observacion { get; set; }

      

        public string NumeroGuia { get; set; }
        public DateTime fechaGuia { get; set; }

        public int IdVia { get; set; }
        public string CodigoVia { get; set; }
        public string DescripcionVia { get; set; }
        public string NombreVia { get; set; }
        public string NumeroVia { get; set; }
        public int IdDistrito { get; set; }
        public string CodigoDistrito { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string NumeroLicenciaChofer { get; set; }
        public string CertificadoInscripcion { get; set; }
        public string NombreChofer { get; set; }
        public string NombreTransportista { get; set; }
        public string RucTransportista { get; set; }
        public int IdChofer { get; set; }
        public string CodigoChofer { get; set; }

        public int IdProveedor { get; set; }
        public string CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string RucProveedor { get; set; }

        public int NumeroEgreso { get; set; }
        public int NumeroIngresoTransferencia { get; set; }

        public int IdTipoProducto { get; set; }
        public string CodigoTipoProducto { get; set; }
        public string DescripcionTipoProducto { get; set; }

        public int IdTipoDocumentoReferencia { get; set; }
        public string DescripcionTipoDocumentoReferencia { get; set; }

      

        public decimal Total { get; set; }
     
    }
}
