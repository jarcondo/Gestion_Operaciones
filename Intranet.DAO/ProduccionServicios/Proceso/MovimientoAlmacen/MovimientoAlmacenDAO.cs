using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DAO.SGE;
using Intranet.DTO.SGE;
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class MovimientoAlmacenDAO
    {
        //
        public List<DetalleMovimientoDTO> GetDetalleMovimiento(int IdCabecera)
        {
            List<DetalleMovimientoDTO> olista = new List<DetalleMovimientoDTO>();
            DetalleMovimientoDTO oDetalleMovimientoDTO = new DetalleMovimientoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ALM_DetalleMovimientoListar", new object[]
                {
                    IdCabecera                
                });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oDetalleMovimientoDTO = new DetalleMovimientoDTO();
                    oDetalleMovimientoDTO.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                    oDetalleMovimientoDTO.IdProducto = Convert.ToInt32(dataReader["IdProducto"].ToString());
                    oDetalleMovimientoDTO.CodigoProducto = dataReader["CodigoProducto"].ToString();
                    oDetalleMovimientoDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                    oDetalleMovimientoDTO.Unidad = dataReader["Unidad"].ToString();
                    oDetalleMovimientoDTO.PrecioUnitarioNacional = Convert.ToDouble(dataReader["PrecioUnitarioNacional"]);
                    oDetalleMovimientoDTO.TotalNacional = Convert.ToDouble(dataReader["TotalNacional"].ToString());
                    oDetalleMovimientoDTO.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oDetalleMovimientoDTO.Cantidad = Convert.ToDouble(dataReader["Cantidad"].ToString());
                    oDetalleMovimientoDTO.Categoria = dataReader["Categoria"].ToString();
                    oDetalleMovimientoDTO.IdCategoria = Convert.ToInt32(dataReader["IdCategoria"].ToString());
                    oDetalleMovimientoDTO.IdDetalleMovimiento = Convert.ToInt32(dataReader["IdDetalleMovimiento"].ToString());
                    oDetalleMovimientoDTO.IdLinea = Convert.ToInt32(dataReader["IdLinea"].ToString());
                    oDetalleMovimientoDTO.IdTipo = Convert.ToInt32(dataReader["IdTipo"].ToString());
                    oDetalleMovimientoDTO.IdUnidad = Convert.ToInt32(dataReader["IdUnidad"].ToString());
                    oDetalleMovimientoDTO.Linea = dataReader["Linea"].ToString();
                    oDetalleMovimientoDTO.Tipo = dataReader["Tipo"].ToString();
                    oDetalleMovimientoDTO.Estado = true;
                    olista.Add(oDetalleMovimientoDTO);
                }
            }
            return olista;
        }
        //
        //
        public CabeceraMovimientoDTO GetCabeceraMovimientoBuscar(int IdCabecera)
        {
            List<CabeceraMovimientoDTO> olista = new List<CabeceraMovimientoDTO>();
            CabeceraMovimientoDTO oCabeceraMovimientoDTO = new CabeceraMovimientoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ALM_CabeceraMovimientoBuscar", new object[]
                {
                   IdCabecera,                
                });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCabeceraMovimientoDTO = new CabeceraMovimientoDTO();
                    oCabeceraMovimientoDTO.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                    oCabeceraMovimientoDTO.CentroCosto = dataReader["CentroCosto"].ToString();
                    //oCabeceraMovimientoDTO.CertificadoInscripcion = dataReader["CertificadoInscripcion"].ToString();
                    //oCabeceraMovimientoDTO.CodigoAlmacen = dataReader["CodigoAlmacen"].ToString();
                    //oCabeceraMovimientoDTO.CodigoBase = dataReader["CodigoBase"].ToString();
                    oCabeceraMovimientoDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                    //oCabeceraMovimientoDTO.CodigoDistrito = dataReader["CodigoDistrito"].ToString();
                    //oCabeceraMovimientoDTO.CodigoDocumento = dataReader["CodigoDocumento"].ToString();
                    //oCabeceraMovimientoDTO.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                  
                    //oCabeceraMovimientoDTO.CodigoMovimiento = dataReader["CodigoMovimiento"].ToString();
                    //oCabeceraMovimientoDTO.CodigoObra = dataReader["CodigoObra"].ToString();
                    //oCabeceraMovimientoDTO.CodigoProveedor = dataReader["CodigoProveedor"].ToString();
                    //oCabeceraMovimientoDTO.CodigoVia = dataReader["CodigoVia"].ToString();
                   
                    oCabeceraMovimientoDTO.Departamento = dataReader["Departamento"].ToString();
                    oCabeceraMovimientoDTO.Descripcion = dataReader["Descripcion"].ToString();
                    //oCabeceraMovimientoDTO.DescripcionAlmacen = dataReader["DescripcionAlmacen"].ToString();
                    //oCabeceraMovimientoDTO.DescripcionBase = dataReader["DescripcionBase"].ToString();
                    oCabeceraMovimientoDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                    oCabeceraMovimientoDTO.DescripcionDocumento = dataReader["DescripcionDocumento"].ToString();
                 
                    oCabeceraMovimientoDTO.DescripcionMovimiento = dataReader["DescripcionMovimiento"].ToString();
                    //oCabeceraMovimientoDTO.DescripcionProveedor = dataReader["DescripcionProveedor"].ToString();
                    //oCabeceraMovimientoDTO.DescripcionVia = dataReader["DescripcionVia"].ToString();
                    //oCabeceraMovimientoDTO.Distrito = dataReader["Distrito"].ToString();
                 
                   
                    oCabeceraMovimientoDTO.FechaHoraRegistro = Convert.ToDateTime(dataReader["FechaHoraRegistro"]);
                    //oCabeceraMovimientoDTO.FechaHoraSistema = Convert.ToDateTime(dataReader["FechaHoraSistema"]);
                    //oCabeceraMovimientoDTO.IdAlmacen = Convert.ToInt32(dataReader["IdAlmacen"].ToString());
                    oCabeceraMovimientoDTO.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                    //oCabeceraMovimientoDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    //oCabeceraMovimientoDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"].ToString());
                    //oCabeceraMovimientoDTO.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());

                    oCabeceraMovimientoDTO.IdMovimiento = Convert.ToInt32(dataReader["IdMovimiento"].ToString());
                    //oCabeceraMovimientoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    //oCabeceraMovimientoDTO.IdProveedor = Convert.ToInt32(dataReader["IdProveedor"].ToString());
                 
                    //oCabeceraMovimientoDTO.IdTipoDocumento = Convert.ToInt32(dataReader["IdTipoDocumento"].ToString());
                    //oCabeceraMovimientoDTO.IdVehiculo = Convert.ToInt32(dataReader["IdVehiculo"].ToString());
                    //oCabeceraMovimientoDTO.IdVia = Convert.ToInt32(dataReader["IdVia"].ToString());
                    //oCabeceraMovimientoDTO.IgvExtranjero = Convert.ToDecimal(dataReader["IgvExtranjero"].ToString());
                    //oCabeceraMovimientoDTO.IgvNacional = Convert.ToDecimal(dataReader["IgvNacional"].ToString());
                    //oCabeceraMovimientoDTO.MarcaVehiculo = dataReader["MarcaVehiculo"].ToString();
                    //oCabeceraMovimientoDTO.NombreChofer = dataReader["NombreChofer"].ToString();
                    oCabeceraMovimientoDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    //oCabeceraMovimientoDTO.NombreTransportista = dataReader["NombreTransportista"].ToString();
                    //oCabeceraMovimientoDTO.NombreVia = dataReader["NombreVia"].ToString();
                    //oCabeceraMovimientoDTO.Numdoc = dataReader["Numdoc"].ToString();
                    //oCabeceraMovimientoDTO.NumeroEgreso = Convert.ToInt32(dataReader["NumeroEgreso"].ToString());
                    //oCabeceraMovimientoDTO.NumeroLicenciaChofer = dataReader["NumeroLicenciaChofer"].ToString();
                    //oCabeceraMovimientoDTO.NumeroVia = dataReader["NumeroVia"].ToString();
                    //oCabeceraMovimientoDTO.NumeroGuia = dataReader["NumeroGuia"].ToString();
                    oCabeceraMovimientoDTO.Observacion = dataReader["Observacion"].ToString();
                    //oCabeceraMovimientoDTO.PlacaVehiculo = dataReader["PlacaVehiculo"].ToString();
                    //oCabeceraMovimientoDTO.PorcentajeIgv = Convert.ToInt32(dataReader["PorcentajeIgv"].ToString());
                    //oCabeceraMovimientoDTO.Provincia = dataReader["Provincia"].ToString();
                    oCabeceraMovimientoDTO.Referencia = dataReader["Referencia"].ToString();
                    //oCabeceraMovimientoDTO.RucProveedor = dataReader["RucProveedor"].ToString();
                    //oCabeceraMovimientoDTO.RucTransportista = dataReader["RucTransportista"].ToString();
                    oCabeceraMovimientoDTO.Seriedoc = dataReader["Seriedoc"].ToString();
                    //oCabeceraMovimientoDTO.SubTotalExtranjero = Convert.ToDecimal(dataReader["SubTotalExtranjero"].ToString());
                    //oCabeceraMovimientoDTO.SubtotalNacional = Convert.ToDecimal(dataReader["SubtotalNacional"].ToString());
                    //oCabeceraMovimientoDTO.Tipo = dataReader["Tipo"].ToString();
                    //oCabeceraMovimientoDTO.TotalExtranjero = Convert.ToDecimal(dataReader["TotalExtranjero"].ToString());
                    //oCabeceraMovimientoDTO.TotalLetrasExtranjero = dataReader["TotalLetrasExtranjero"].ToString();
                    //oCabeceraMovimientoDTO.TotalLetrasNacional = dataReader["TotalLetrasNacional"].ToString();
                    oCabeceraMovimientoDTO.TotalNacional = Convert.ToDecimal(dataReader["TotalNacional"].ToString());
                    
                    //oCabeceraMovimientoDTO.IdTipoProducto = Convert.ToInt32(dataReader["IdTipoProducto"].ToString());
                    //oCabeceraMovimientoDTO.CodigoTipoProducto = dataReader["CodigoTipoProducto"].ToString();
                    //oCabeceraMovimientoDTO.DescripcionTipoProducto = dataReader["DescripcionTipoProducto"].ToString();
                    //oCabeceraMovimientoDTO.IdChofer = Convert.ToInt32(dataReader["IdChofer"].ToString());
                    //oCabeceraMovimientoDTO.CodigoChofer = dataReader["CodigoChofer"].ToString();
                    //olista.Add(oCabeceraMovimientoDTO);
                }
            }
            return oCabeceraMovimientoDTO;
        }
        ////////

        public DetalleMovimientoDTO GetCabeceraOrdenTrabajoBuscar(int IdObra, string SGI,string NumeroOT ,int TipoBusqueda)
        {
            List<DetalleMovimientoDTO> olista = new List<DetalleMovimientoDTO>();
            DetalleMovimientoDTO oCabeceraOrdenTrabajo = new DetalleMovimientoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajoCabeceraBuscar", new object[]
                {
                  IdObra, SGI,NumeroOT,TipoBusqueda,                
                });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCabeceraOrdenTrabajo = new  DetalleMovimientoDTO();

                    oCabeceraOrdenTrabajo.actividad = dataReader["actividad"].ToString();
                    oCabeceraOrdenTrabajo.Cliente = dataReader["Cliente"].ToString();
                    oCabeceraOrdenTrabajo.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                    oCabeceraOrdenTrabajo.DescripcionEstado = dataReader["DescripcionEstado"].ToString();
                    oCabeceraOrdenTrabajo.Direccion = dataReader["Direccion"].ToString();
                    oCabeceraOrdenTrabajo.Distrito = dataReader["Distrito"].ToString();
                    oCabeceraOrdenTrabajo.FechaDigitacion = dataReader["FechaDigitacion"].ToString();
                    oCabeceraOrdenTrabajo.FechaInicio = dataReader["FechaInicio"].ToString();
                    oCabeceraOrdenTrabajo.FechaOrden = dataReader["FechaOrden"].ToString();
                    oCabeceraOrdenTrabajo.FechaProgramacion = dataReader["FechaProgramacion"].ToString();
                    oCabeceraOrdenTrabajo.FechaTermino = dataReader["FechaTermino"].ToString();
                    oCabeceraOrdenTrabajo.HoraInicio = dataReader["HoraInicio"].ToString();
                    oCabeceraOrdenTrabajo.Horatermino = dataReader["Horatermino"].ToString();
                    oCabeceraOrdenTrabajo.Sgi = dataReader["Sgi"].ToString();
                    oCabeceraOrdenTrabajo.Suministro = dataReader["Suministro"].ToString();
                    oCabeceraOrdenTrabajo.Urbanizacion = dataReader["Urbanizacion"].ToString();
                    oCabeceraOrdenTrabajo.NumeroOrden = dataReader["NumeroOrden"].ToString();
                    oCabeceraOrdenTrabajo.IdCategoria = Convert.ToInt32(dataReader["IdBase"].ToString());

                    //olista.Add(oCabeceraMovimientoDTO);
                }
            }
            return oCabeceraOrdenTrabajo;
        }
        ////////


        ////////

        public List<DetalleMovimientoDTO> GetDetalleOrdenTrabajoBuscar(int IdObra, string SGI , string NumeroOT ,int TipoBusqueda)
        {
            List<DetalleMovimientoDTO> olista = new List<DetalleMovimientoDTO>();
            DetalleMovimientoDTO oCabeceraOrdenTrabajo = new DetalleMovimientoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajoDetalleBuscar", new object[]
                {
                  IdObra, SGI,  NumeroOT, TipoBusqueda,        
                });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCabeceraOrdenTrabajo = new DetalleMovimientoDTO();

                    oCabeceraOrdenTrabajo.Cantidad = Convert.ToDouble(dataReader["Cantidad"].ToString());
                    oCabeceraOrdenTrabajo.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oCabeceraOrdenTrabajo.IdProducto = Convert.ToInt32(dataReader["IdCatalogo"].ToString());
                    oCabeceraOrdenTrabajo.Tipo = dataReader["tipo"].ToString();
                    oCabeceraOrdenTrabajo.TotalNacional = Convert.ToDouble(dataReader["total"].ToString());
                    oCabeceraOrdenTrabajo.Unidad = dataReader["UnidadSedapro"].ToString();
                    oCabeceraOrdenTrabajo.PrecioUnitarioNacional = Convert.ToDouble(dataReader["costo"].ToString());

                    olista.Add(oCabeceraOrdenTrabajo);
                }
            }
            return olista;
        }
        ////////


        //Reporte STOCK //

        public List<StockDTO> ReporteStock()
        {
            List<StockDTO> olista = new List<StockDTO>();
            StockDTO oStockDTO = new StockDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ALM_ReporteStock", new object[]
                { });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oStockDTO = new StockDTO();

                    oStockDTO.CodigoProducto = dataReader["Codigo"].ToString();
                    oStockDTO.Descripcion1 = dataReader["Producto"].ToString();
                    oStockDTO.A2 = dataReader["A2"].ToString();
                    oStockDTO.MantoVes = Convert.ToDouble(dataReader["MANTTO VILLA SALVADOR"].ToString());
                    oStockDTO.MantoCho = Convert.ToDouble(dataReader["MANTTO CHORRILLOS"].ToString());
                    oStockDTO.AguaCentro = Convert.ToDouble(dataReader["POZOS AGUA CENTRO (CP 033 ITEM2)"].ToString());
                    oStockDTO.AguaNorte = Convert.ToDouble(dataReader["POZOS AGUA NORTE (CP 033 ITEM1)"].ToString());
                    oStockDTO.PozosSur = Convert.ToDouble(dataReader["POZOS SUR (AMC 0048-2012 )"].ToString());
                    oStockDTO.PrevItem2 = Convert.ToDouble(dataReader["PREVENTIVO  ITEM 02 - 032 "].ToString());
                    oStockDTO.PrevItem1 = Convert.ToDouble(dataReader["PREVENTIVO  ITEM 01 - 032"].ToString());
                    oStockDTO.MantoPte = Convert.ToDouble(dataReader["MANTTO. PTE PIEDRA 042"].ToString());
                    oStockDTO.MantoCallao = Convert.ToDouble(dataReader["MANTTO. CALLAO 042"].ToString());

                    olista.Add(oStockDTO);
                }
            }
            return olista;
        }

    }
}
