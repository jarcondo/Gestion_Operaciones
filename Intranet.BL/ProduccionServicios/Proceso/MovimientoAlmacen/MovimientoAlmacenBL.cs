using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios;
using Intranet.DAO.ProduccionServicios;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DAO.ProduccionServicios.Proceso;
using System.Data;
using Intranet.DTO.ProduccionServicios.Reportes;


namespace Intranet.BL.ProduccionServicios.Proceso
{
    public class MovimientoAlmacenBL
    {
        public CabeceraMovimientoDTO GetCabeceraMovimiento(int IdCabecera)
        {
            return new  MovimientoAlmacenDAO().GetCabeceraMovimientoBuscar(IdCabecera);
        }
        public List<DetalleMovimientoDTO> GetDetalleMovimiento(int IdCabecera)
        {
            return new MovimientoAlmacenDAO().GetDetalleMovimiento(IdCabecera);
        }

        public DetalleMovimientoDTO GetCabeceraMovimientoOT(int IdObra ,string SGI ,string NumeroOT,int TipoBusqueda)
        {
            return new MovimientoAlmacenDAO().GetCabeceraOrdenTrabajoBuscar(IdObra , SGI,NumeroOT,TipoBusqueda);
        }
        public List<DetalleMovimientoDTO> GetDetalleMovimientoOT(int IdObra, string SGI, string NumeroOT, int TipoBusqueda)
        {
            return new MovimientoAlmacenDAO().GetDetalleOrdenTrabajoBuscar(IdObra, SGI , NumeroOT ,TipoBusqueda);
        }

        //Reporte Stock
        public List<StockDTO> ReporteStock()
        {
            return new MovimientoAlmacenDAO().ReporteStock();
        }

    }
}
