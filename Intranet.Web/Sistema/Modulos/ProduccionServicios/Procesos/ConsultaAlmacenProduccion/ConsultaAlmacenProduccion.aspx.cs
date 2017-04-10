using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Intranet.DTO.SGE;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;
using Ext.Net;
using Intranet.BL.SGE;
using Intranet.Web.AppCode;
using Intranet.Utilities;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsultaAlmacenProduccion
{
    public partial class ConsultaAlmacenProduccion : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ObraDTO> olObra = new List<ObraDTO>();
            ObraBL oObraBL = new ObraBL();
            if (Usuario.IdRol != 1)
            {

                olObra = oObraBL.ListarObra(Usuario.IdBase);
                olObra = (List<ObraDTO>)(from item in olObra
                                         where item.CP == true
                                         select item).ToList();
            }
            else {

                olObra = oObraBL.ListarObraTodas();
                olObra = (List<ObraDTO>)(from item in olObra
                                         where item.CP == true
                                         select item).ToList();                
            }
            int IdObraIni = olObra.ElementAt(0).IdObra;
        }


        [DirectMethod]
        public void btnBuscarVale_Click(int IdVale)
        {

            CabeceraMovimientoDTO oListaCabecera = new CabeceraMovimientoDTO();
            List<DetalleMovimientoDTO> oListaDetalle = new List<DetalleMovimientoDTO>();
            MovimientoAlmacenBL oMovimientoAlmacenBL = new MovimientoAlmacenBL();
            oListaCabecera = oMovimientoAlmacenBL.GetCabeceraMovimiento(IdVale);
            oListaDetalle = oMovimientoAlmacenBL.GetDetalleMovimiento(IdVale);

            if (oListaDetalle.Count == 0)
            {

                X.Msg.Notify("Consulta Almacen", "El Numero de Vale no Existe").Show();
                return;
            }
            else
            {

                if (oListaCabecera.IdMovimiento == 5 || oListaCabecera.IdMovimiento == 4)
                {
                    if (Usuario.IdRol != 1)
                    {

                        if (oListaCabecera.IdBase == Usuario.IdBase)
                        {

                            this.StoreDetalle.DataSource = oListaDetalle;
                            this.StoreDetalle.DataBind();
                            this.Responsable.Text = oListaCabecera.NombresApellidos;
                            this.CodigoCuadrilla.Text = oListaCabecera.CodigoCuadrilla;
                            this.DescripcioCuadrilla.Text = oListaCabecera.DescripcionCuadrilla;
                            this.Entregado.Text = oListaCabecera.NombresApellidos;
                            this.DescripcionObra.Text = oListaCabecera.Descripcion;
                            this.DescripcionMovimiento.Text = oListaCabecera.DescripcionMovimiento;
                            this.IdCabecera.Text = oListaCabecera.IdCabecera.ToString();
                            this.Fecha.Text = oListaCabecera.FechaHoraRegistro.ToString("dd/MM/yyyy");
                            this.Observacion.Text = oListaCabecera.Observacion;
                            this.Referencia.Text = oListaCabecera.Referencia;
                        }
                        else
                        {
                            X.Msg.Notify("Consulta Almacen", "El Numero de Vale no pertenece a la Base").Show();
                            return;
                        }


                    }
                    else {

                        this.StoreDetalle.DataSource = oListaDetalle;
                        this.StoreDetalle.DataBind();
                        this.Responsable.Text = oListaCabecera.NombresApellidos;
                        this.CodigoCuadrilla.Text = oListaCabecera.CodigoCuadrilla;
                        this.DescripcioCuadrilla.Text = oListaCabecera.DescripcionCuadrilla;
                        this.Entregado.Text = oListaCabecera.NombresApellidos;
                        this.DescripcionObra.Text = oListaCabecera.Descripcion;
                        this.DescripcionMovimiento.Text = oListaCabecera.DescripcionMovimiento;
                        this.IdCabecera.Text = oListaCabecera.IdCabecera.ToString();
                        this.Fecha.Text = oListaCabecera.FechaHoraRegistro.ToString("dd/MM/yyyy");
                        this.Observacion.Text = oListaCabecera.Observacion;
                        this.Referencia.Text = oListaCabecera.Referencia;
                        
                    
                    }





                }
                else {
                    X.Msg.Notify("Consulta Almacen", "El Numero de Vale no es un Egreso a produccion o Devolucion Fisica").Show();
                    return;
                
                }
            }
          
        }


        

        [DirectMethod]
        public void btnBuscarSGI_Click(string SGI ,string NumeroOT ,int TipoBusqueda)
        {

            DetalleMovimientoDTO oListaCabecera = new DetalleMovimientoDTO();
            List<DetalleMovimientoDTO> oListaDetalle = new List<DetalleMovimientoDTO>();
            List<DetalleMovimientoDTO> oListaDetalleSubactividad = new List<DetalleMovimientoDTO>();
            MovimientoAlmacenBL oMovimientoAlmacenBL = new MovimientoAlmacenBL();
            oListaCabecera = oMovimientoAlmacenBL.GetCabeceraMovimientoOT(Usuario.IdBase, SGI, NumeroOT, TipoBusqueda);
            oListaDetalle = oMovimientoAlmacenBL.GetDetalleMovimientoOT(Usuario.IdBase, SGI, NumeroOT, TipoBusqueda);

            if (oListaDetalle.Count == 0)
            {
                string Cadena = "";
                if (TipoBusqueda == 1) { Cadena = "SGI"; } else { Cadena = "Numero OT"; }
                
                X.Msg.Notify("Consulta Produccion", "El "+Cadena+ " no Existe").Show();
                return;
            }
            else
            {

                 if (Usuario.IdRol != 1)
                    {
                

                                    if (oListaCabecera.IdCategoria == Usuario.IdBase)
                                    {

                                        oListaDetalleSubactividad = (List<DetalleMovimientoDTO>)(from item in oListaDetalle 
                                                                                            where item.Tipo == "S"
                                                                                            select item).ToList();

                                        oListaDetalle = (List<DetalleMovimientoDTO>)(from item in oListaDetalle
                                                                                                 where item.Tipo == "M"
                                                                                                 select item).ToList();

                                        this.StoreMaterial.DataSource = oListaDetalle;
                                        this.StoreMaterial.DataBind();

                                        this.StoreSubactividad.DataSource = oListaDetalleSubactividad;
                                        this.StoreSubactividad.DataBind();

                                        this.Direccion.Text = oListaCabecera.Direccion;
                                        this.Actividad.Text = oListaCabecera.actividad;
                                        this.Distrito.Text = oListaCabecera.Distrito;
                                        this.SGI.Text = oListaCabecera.Sgi;
                                        this.NIS.Text = oListaCabecera.Suministro;
                                        this.NumeroOT.Text = oListaCabecera.NumeroOrden;
                                        this.FechaInicio.Text = oListaCabecera.FechaInicio;
                                        this.FechaTermino.Text = oListaCabecera.FechaTermino;
                                        this.FechaDigitacion.Text = oListaCabecera.FechaDigitacion;
                                        this.Cuadrilla.Text = oListaCabecera.CodigoCuadrilla;
                                        this.Urbanizacion.Text = oListaCabecera.Urbanizacion;
                                    }
                                    else
                                    {
                                        X.Msg.Notify("Consulta Produccion", "El Numero no pertenece a la Base").Show();
                                        return;
                                    }

                    }
                 else
                 {

                     oListaDetalleSubactividad = (List<DetalleMovimientoDTO>)(from item in oListaDetalle
                                                                              where item.Tipo == "S"
                                                                              select item).ToList();

                     oListaDetalle = (List<DetalleMovimientoDTO>)(from item in oListaDetalle
                                                                  where item.Tipo == "M"
                                                                  select item).ToList();

                     this.StoreMaterial.DataSource = oListaDetalle;
                     this.StoreMaterial.DataBind();

                     this.StoreSubactividad.DataSource = oListaDetalleSubactividad;
                     this.StoreSubactividad.DataBind();

                     this.Direccion.Text = oListaCabecera.Direccion;
                     this.Actividad.Text = oListaCabecera.actividad;
                     this.Distrito.Text = oListaCabecera.Distrito;
                     this.SGI.Text = oListaCabecera.Sgi;
                     this.NIS.Text = oListaCabecera.Suministro;
                     this.NumeroOT.Text = oListaCabecera.NumeroOrden;
                     this.FechaInicio.Text = oListaCabecera.FechaInicio;
                     this.FechaTermino.Text = oListaCabecera.FechaTermino;
                     this.FechaDigitacion.Text = oListaCabecera.FechaDigitacion;
                     this.Cuadrilla.Text = oListaCabecera.CodigoCuadrilla;
                     this.Urbanizacion.Text = oListaCabecera.Urbanizacion;

                     
                     

                 }



            }
          
        }


        


    }
}