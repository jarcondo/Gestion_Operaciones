using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.Global
{
    public enum eReciboxHonorario
    { 
        Ninguno,
        Si,
        No,
    }

    public enum eActivoFijo
    { 
        Ninguno,
        Si,
        No,
    }


    public enum eTipoMovimiento
    {
        Ninguno,
        Entrada,
        Salida,
    }
    public enum eRequerido
    {
        Ninguno,
        Si,
        No,
    }

    public enum eProceso
    {
        Ninguna,
        AlmacenMovimientoxVale,
        Logistica,
        Venta,
        GenerarPedido,
        EgresoaProduccion,
        EgresoporTransferencia,
        EgresoporDevolucion,
        IngresoporTransferencia,
        DevolucionEquipo,
        ReporteKardex,
        IngresoInventario,
        ReporteCCosto,
        ExportarMovimiento,
        ReporteMovimientoValorizado,
        IngresoxCompraenObra,
        IngresoxCompraCajaChica,
        OrdenDeCompra,
        AprobacionPedido,
        Acceso,
        Usuario,
        ReporteCuadrilla,
        IngresoxServicio,
        ConsultaStock,
        ReporteF14,
        CierreMensual,
        ReporteCuadrillaLineas,
        ReporteAcumuladoProducto,
        ReporteCompraObraSF,
        ReporteIngresosXTransferenciaPendiente,
        ReporteComparativo,
        ReporteListaPrecio,
        ConsultaCompraObraSinFactura,
        GenerarPedidoServicios
    }
    

    public enum eTabla
    {
        Ninguna, 
        Categoria,
        Linea,
        Base,
        Unidad,
        Tipo,
        Cuadrilla,
        Movimiento,
        Obra,
        Almacen,
        TipoCambio,
        TipoDocumento,
        Producto,
        Proveedor,
        FormaPago,
        Via,
        TipoMovimiento,
        Cargo,
        Vehiculo,
        CondicionVehiculo,
        Rubro,
        GrupoCuadrilla,
        subgrupoCuadrilla,
        Division,
        TipoTrabajador,
        Area,
        TipoTrabajo,
        TrabajoComplementario,
        TipoMaterial,
    }
    public enum eEstado
    {
        Eliminado,
        Activo,
    }
    public enum eResultado
    {
        Ninguno,
        Correcto,
        Error,
    }
    public enum eAccionRegistro
    {
        Ninguno,
        Insertar,
        Actualizar,
        Eliminar,
    }
    //public enum eAccionMovimiento
    //{
    //    Ninguno,
    //    NuevoIngreso,
    //    Actualizar,
    //    Eliminar,
    //}

    public enum eEstadoTransaccion
    {
        Ninguno,
        Correctamente,
        Duplicado,
        ErrorBaseDatos,

    }
    public enum eEstadoTransferencia
    {
        Ninguno,
        EnProceso,
        Aceptada,
    }

    public enum eEstadoPedido
    {
        Ninguno,
        Pendiente,
        Aprobado,
        Revisado,
        EnEvalucion,
        Aceptado,
        Rechazado,
        EnProcesoCompra,
        Recepcionado,
        Atendido,
    }

    public enum eMeses
    {
        Enero = 1,
        Febrero,
        Marzo,
        Abril,
        Mayo,
        Junio,
        Julio,
        Agosto,
        Septiembre,
        Octubre,
        Noviembre,
        Diciembre
    }
    public enum eTipoDeOrden
    {
        ORDEN_DE_COMPRA,
        ORDEN_DE_SERVICIO,
    }
    public enum eEstadoRegistro
    {
        Ninguno,
        Asignar,
        Quitar_Asignacion
    }

    public enum eTipoRegistro
    {
        Ninguno,
        Manual,
        Sistema,
    }

    public enum eEstadoCabeceraOT
    {
        Ninguno,
        ConSGIO,
        SinSGIO,
    }

    


}