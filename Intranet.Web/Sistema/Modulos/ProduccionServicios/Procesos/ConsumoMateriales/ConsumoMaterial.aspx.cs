using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Intranet.Web.AppCode;
using Ext.Net;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.BL.SGE;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.Utilities;
using Intranet.DTO.Global;
using Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsumoMateriales
{
    public partial class ConsumoMaterial : BasePage
    {

        #region eventos de la pagina
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    this.InicializarControles();
                    if (!string.IsNullOrEmpty(this.Request.QueryString["sgi"]))
                    {
                        string sSgi = this.Request.QueryString["sgi"].ToString();
                    
                        List<CuadrillaDTO> olCuad = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                        if (olCuad != null)
                        {
                            this.StoreCuadrilla.DataSource = olCuad;
                            this.StoreCuadrilla.DataBind();

                            this.StoreTCCuadrilla.DataSource = olCuad;
                            this.StoreTCCuadrilla.DataBind();
                        }

                        List<CabeceraDTO> olCabeceras = new ConsumoMaterialBL().ObtenerCabeceraConsumo(Convert.ToInt32(this.ddlObra.SelectedItem.Value), "0", sSgi, 0,Usuario.IdUsuario);
                        if (olCabeceras.Count == 1)
                        {
                            this.LimpiarControles();
                            CabeceraDTO oCabecera = new CabeceraDTO();
                            oCabecera = olCabeceras[0];
                            this.hdnIdCabecera.Text = oCabecera.IdCabecera.ToString();
                            this.txtPOrden.Text = oCabecera.NumeroOrden;
                            this.txtPSGIO.Text = oCabecera.Sgi;
                            this.txtObservacion.Text = oCabecera.Observacion;

                            this.txtPNIS.Text = oCabecera.Suministro;
                            this.txtPFecOrden.Text = oCabecera.FechaOrden;
                            this.txtPFecProg.Text = oCabecera.FechaProgramacion;
                            this.txtPFecIni.Text = oCabecera.FechaInicio;
                            this.txtPHorIni.Text = oCabecera.HoraInicio;
                            this.txtPFecFin.Text = oCabecera.FechaTermino;
                            this.txtPHorFin.Text = oCabecera.Horatermino;
                            this.ddlDistrito.SelectedItem.Value = oCabecera.Distrito.IdDistrito.ToString();
                            if (oCabecera.Cuadrilla.IdCuadrilla > 0)
                                this.ddlPCuadrilla.SelectedItem.Value = oCabecera.Cuadrilla.IdCuadrilla.ToString();
                            if (oCabecera.EstadoOT.IdEstadoOT > 0)
                                this.ddlPEstado.SelectedItem.Value = "45";//oCabecera.EstadoOT.IdEstadoOT.ToString();
                            if (oCabecera.EstadoOTRO.IdEstadoOT > 0)
                                this.ddlPEstadoRO.SelectedItem.Value = oCabecera.EstadoOTRO.IdEstadoOT.ToString();
                            this.txtPDireccion.Text = oCabecera.Direccion;
                            this.txtPCliente.Text = oCabecera.Cliente;
                            this.txtPUrbanizacion.Text = oCabecera.Urbanizacion;
                            this.ddlPActividad.SelectedItem.Value = oCabecera.Actividad.IdActividad.ToString();
                            this.txtHorTrab.Text = oCabecera.HorasTrabajadas.ToString();
                            this.txtNroTrab.Text = oCabecera.NumeroTrabajadores.ToString();
                            this.txtPCorrelativo.Text = oCabecera.NroRegistro.ToString();
                            this.TextTotalSGIO.Text = oCabecera.CostoOPEN.ToString();
                            this.txtPNroCargo.Text = oCabecera.NroCargo;
                            this.CargarDetallesConsumo(oCabecera.IdCabecera);
                            this.hdnTipoAccion.Text = "1";
                            this.DesactivarControles(false);


                            this.txtPNIS.Visible = false;
                        }
                        
                    }
                        
                }
            }

            protected void btnPCancelar_Click(object sender, DirectEventArgs e)
            {
                this.DesactivarControles(true);
                this.LimpiarControles();
                this.CargarDetallesConsumo(0);
                this.imgBuscarSGIO.Hidden = false;
                this.ImageButton1.Hidden = false;
                this.ImageButton2.Hidden = true;
                this.txtPCorrelativo.Disabled = false;
                this.btnPNuevo.Disabled = false;
                this.btnPBuscar.Disabled = false;
            }


        #endregion

        #region metodos personalizados - prinicpal

            private void InicializarControles()
            {
                this.Button2.Disabled = true;
                this.CargarCombos();
                this.DesactivarControles(true);
                //this.CargarGrillaCargoSGIs();
                #region ActA
                this.ckLosa.Hide();
                ckMyT.Hide();
                rbsi.Hide();
                rbno.Hide();
                //panUbica.Visible=false;
                this.ImageButton2.Hidden = true;
                #endregion
               
            }

            private void CargarGrillaCargoSGIs()
            {
                try
                {
                    if (string.IsNullOrEmpty(this.ddlCargo.SelectedItem.Value)) return;
                    List<ConsumoMaterialDTO> olCM = new ConsumoMaterialBL().ObtenerCargoSGIs(Convert.ToInt32(this.ddlCargo.SelectedItem.Value));
                    if (olCM != null)
                    {
                        this.lblConteoSGI.Text = olCM.Count.ToString();
                        this.StoreCargoSGI.DataSource = olCM;
                        this.StoreCargoSGI.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void CargaCargosSGI(object sender, DirectEventArgs e)
            {
                this.CargarGrillaCargoSGIs();
            }

            protected void btnIngresaCargo_Click(object sender, DirectEventArgs e)
            {
                if (string.IsNullOrEmpty(this.txtNomCargo.Text))
                {
                    this.Mensaje("INGRESE NOMBRE DEL CARGO.");
                    return;
                }

                if (new ConsumoMaterialBL().InsertarCargoEntrada(Convert.ToInt32(this.ddlObra.SelectedItem.Value), this.txtNomCargo.Text.ToUpper(), Usuario.IdUsuario) != eResultado.Correcto)
                {
                    this.Mensaje("Error al ingresar el cargo.");
                    return;
                }
                this.txtNomCargo.Text = "";
                this.Window5.Hide();
                this.CargarCargos();
            }
        
            private void CargarCombos()
            {
                try
                {
                    List<ObraDTO> olObra = new List<ObraDTO>();
                if (Usuario.IdRol != 1 && Usuario.IdRol != 6)
                    olObra = new ObraBL().ListarObra(Usuario.IdBase).Where(x => x.CP == true).ToList();
                else
                    olObra = new ObraBL().ListarObraTodas().Where(x => x.CP == true).ToList();//(List<ObraDTO>)Session["session.obraCP.intranet"];

                if (olObra == null) return;
                        this.StoreObra.DataSource = olObra;
                        this.StoreObra.DataBind();
                        if (olObra.Count == 1)
                        {
                            this.Button2.Disabled = false;
                            this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                            this.CargarCuadrillas();
                            this.CargarActividades();
                            this.CargarCargos();
                        }
                    

                    List<EstadoOTDTO> olEstadoOT = new List<EstadoOTDTO>();
                    olEstadoOT = new EstadoOTBL().ListarEstadoOT();
                    olEstadoOT = olEstadoOT.Where(x => x.CodigoEstadoOT == "4" || x.CodigoEstadoOT == "5").ToList();
                    if (olEstadoOT != null)
                    {
                        this.StoreEstado.DataSource = olEstadoOT;
                        this.StoreEstado.DataBind();
                    }

                    olEstadoOT = new EstadoOTBL().ListarEstadoOT();
                    if (olEstadoOT != null)
                    {
                        this.StoreEstadoRO.DataSource = olEstadoOT;
                        this.StoreEstadoRO.DataBind();
                    }

                    List<DistritoDTO> olDistrito = new List<DistritoDTO>();
                    olDistrito = new DistritoBL().ListarDistrito().OrderBy(x => x.Distrito).ToList();
                    if (olDistrito != null)
                    {
                        this.StoreDistrito.DataSource = olDistrito;
                        this.StoreDistrito.DataBind();
                    }

                    
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void CargarCargos()
            {
                List<CargoSIODTO> olCargo = new ConsumoMaterialBL().ObtenerCargo(Convert.ToInt32(this.ddlObra.SelectedItem.Value),Usuario.IdUsuario);
                if (olCargo == null) return;
                if (olCargo.Count == 0) return;
                this.StoreCargo.DataSource = olCargo;
                this.StoreCargo.DataBind();
                this.ddlCargo.SelectedItem.Value = olCargo[0].IdCargoEntrega.ToString();

                this.CargarGrillaCargoSGIs();
            }
            private void CargarCuadrillas()
            {
                List<CuadrillaDTO> olCuad = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                if (olCuad != null)
                {
                    this.StoreCuadrilla.DataSource = olCuad;
                    this.StoreCuadrilla.DataBind();

                    this.StoreTCCuadrilla.DataSource = olCuad;
                    this.StoreTCCuadrilla.DataBind();

                    #region Cuadrilla Bryan
                    storeCargaCuadrilla.DataSource = olCuad;
                    storeCargaCuadrilla.DataBind();
                    StorecuadrillaInspeccion.DataSource = olCuad;
                    StorecuadrillaInspeccion.DataBind();
                    #endregion
                }

                var listaProveedor = new ProveedorBL().GetProveedor().Where(x => x.CP == true).ToList(); 
                if (listaProveedor == null) return;
                this.StoreTCProveedor.DataSource = listaProveedor.Where(x => (x.IdBase == Usuario.IdBase || x.ProveedorGeneral == true)).ToList();
                this.StoreTCProveedor.DataBind();
            }

            private void CargarActividades()
            {
                List<ActividadDTO> olistaACT = new ActividadBL().ListarActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                if (olistaACT == null) return;
                this.StoreNActividad.DataSource = olistaACT;
                this.StoreNActividad.DataBind();
            }

            private void DesactivarControles(bool p)
            {
                try
                {
                    //Botones Menu
                    this.btnPGuardar.Disabled = p;
                    this.btnPCancelar.Disabled = p;
                    this.btnPSubAct.Disabled = p;
                    this.btnPMaterial.Disabled = p;
                    this.btnPTC.Disabled = p;
                    this.btnPImprimir.Disabled = p;

                    //Controles Edicion
                    //if(this.ddlObra.Items.Count==1)
                     this.ddlObra.Disabled = true; ;

                    //this.txtPSGIO.Disabled = p;
                    //this.txtPCorrelativo.Disabled = p;
                    this.txtPNIS.Disabled = true;
                    this.txtPOrden.Disabled = true;
                    this.ddlDistrito.Disabled = true;
                    this.txtPUrbanizacion.Disabled = true;
                    this.txtPDireccion.Disabled = true;
                    this.txtPCliente.Disabled = true;
                    this.ddlPActividad.Disabled = true;
                    this.ddlPEstado.Disabled = p;
                    this.txtPFecIni.Disabled = p;
                    this.txtPHorIni.Disabled = p;
                    this.txtPFecFin.Disabled = p;
                    this.txtPHorFin.Disabled = p;
                    this.ddlPCuadrilla.Disabled = true;
                    this.txtHorTrab.Disabled = p;
                    this.txtNroTrab.Disabled = p;
                    this.TextTotalOT.Disabled = p;
                    this.TextTotalSGIO.Disabled = p;

                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void LimpiarControles()
            {
                try
                {
                    this.hdnIdCabecera.Text = "";
                    this.txtPOrden.Text = "";
                    this.txtPNIS.Text = "";
                    this.txtPSGIO.Text = "";
                    this.txtPFecOrden.Text = "";
                    this.ddlDistrito.SelectedItem.Value = "";
                    this.txtPUrbanizacion.Text = "";
                    this.txtPDireccion.Text = "";
                    this.txtPCliente.Text = "";
                    this.ddlPActividad.SelectedItem.Value = "";
                    this.txtPFecProg.Text = "";
                    this.txtPFecIni.Text = "";
                    this.txtPHorIni.Text = "";
                    this.txtPFecFin.Text = "";
                    this.txtPHorFin.Text = "";
                    this.ddlPEstado.SelectedItem.Value = "";
                    this.ddlPEstadoRO.SelectedItem.Value = "";
                    this.ddlPCuadrilla.SelectedItem.Value = "";
                    this.txtHorTrab.Text = "";
                    this.txtNroTrab.Text = "";
                    this.TextTotalOT.Text = "";
                    this.txtPCorrelativo.Text = "";
                    this.TextTotalSGIO.Text = "";
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void CuadrillasPorObra(object sender, DirectEventArgs e)
            {
                this.CargarCuadrillas();
                this.CargarActividades();
                this.CargarCargos();
                this.Button2.Disabled = false;
            }

            protected void btnPNuevo_Click(object sender, DirectEventArgs e)
            {
                this.LimpiarControles();
                this.DesactivarControles(false);
                this.CargarDetallesConsumo(0);
                this.hdnTipoAccion.Text = "0";
                this.hdnIdCabecera.Text = "0";
                this.ddlPEstado.SelectedItem.Value = "45";
                this.txtPCorrelativo.Disabled = true;
                this.imgBuscarSGIO.Hidden = true;
                this.ImageButton1.Hidden = true;
                this.ImageButton2.Hidden = false;
                this.btnPNuevo.Disabled = true;
                this.btnPBuscar.Disabled = true;

                this.txtPOrden.Disabled = false;

                this.txtPNIS.Focus();
              
            }

            protected void btnPGuardar_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    CabeceraDTO oCab = new CabeceraDTO();
                    oCab.IdCabecera = Convert.ToInt32(this.hdnIdCabecera.Text);
                   
                    if (string.IsNullOrEmpty(this.txtPOrden.Text))
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE INGRESAR EL NRO. DE PARTE DE TRABAJO", Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }
                    else
                        oCab.NumeroOrden = this.txtPOrden.Text.ToUpper();

                    if (this.txtPFecIni.Text.Contains("0001"))
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE INGRESAR LA FECHA DE INICION DE LA O/T.", Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }

                    if (this.ddlPCuadrilla.Text == "" || ddlPCuadrilla.SelectedItem.Value == "")
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE SELECCIONAR A QUIEN ESTA ASIGNADO.", Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }

                    if (this.txtPUrbanizacion.Text=="")
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE INGRESAR - V°B° del usuario final en el Cliente", Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }

                    if (ddlPEstadoRO.SelectedItem.Text != "TRABAJANDO" && ddlPEstadoRO.SelectedItem.Text != "RESUELTO")
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig()
                        { Title = "SMC GESTION DE OPERACIONES", 
                            Message = "SOLO PUEDE INGRESAR PARTES DE TRABAJO" + Environment.NewLine +
                            " SI EL ESTADO DE LA OT EN PLANIFICADO ES TRABAJANDO"
                            , Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }

                    if (ddlPEstado.SelectedItem.Text=="RESUELTO" && ddlPEstadoRO.SelectedItem.Text!="RESUELTO")
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig()
                        {
                            Title = "SMC GESTION DE OPERACIONES",
                            Message = "PARA MARCAR EL PARTE DE TRABAJO COMO RESUELTO RECUERDE QUE.." + Environment.NewLine +
                            " DEBE MARCAR PRIMERO EL ESTADO A RESUELTO EN EL PLANIFICADO"
                            ,
                            Buttons = Ext.Net.MessageBox.Button.OK
                        });
                        return;
                        
                    }
                  




                    oCab.FechaOrden = this.txtPFecOrden.Text;
                    oCab.FechaDigitacion = DateTime.Now.ToShortDateString();
                    oCab.FechaProgramacion = this.txtPFecProg.Text;
                    oCab.FechaInicio = this.txtPFecIni.Text;
                    oCab.HoraInicio = this.txtPHorIni.Text;
                    oCab.FechaTermino = this.txtPFecFin.Text;
                    oCab.Horatermino = this.txtPHorFin.Text;
                    oCab.HorasTrabajadas = Convert.ToDecimal(this.txtHorTrab.Text == "" ? "0" : this.txtHorTrab.Text);
                    oCab.NumeroTrabajadores = Convert.ToInt32(this.txtNroTrab.Text == "" ? "0" : this.txtNroTrab.Text);
                    oCab.Cliente = this.txtPCliente.Text.ToUpper();
                    oCab.Observacion = this.txtObservacion.Text;
                    oCab.Suministro = this.txtPNIS.Text;
                    oCab.Urbanizacion = this.txtPDireccion.Text.ToUpper();
                    oCab.Direccion = this.txtPDireccion.Text.ToUpper();
            


                    oCab.EstadoOT = new EstadoOTDTO()
                    {
                        IdEstadoOT = Convert.ToInt32(this.ddlPEstado.SelectedItem.Value),
                    };
                    oCab.Cuadrilla = new CuadrillaDTO()
                    {
                        IdCuadrilla = Convert.ToInt32(this.ddlPCuadrilla.SelectedItem.Value),
                    };
                   
                    if (oCab.IdCabecera != 0 && this.hdnTipoAccion.Text=="1")
                    {

                        /*
                                 * Grabando SGI  a las OT que no tienen.
                                 * 
                                 * */

                        txtPSGIO.Text = this.hdnIdCabecera.Text;

                        if (!string.IsNullOrEmpty(txtPSGIO.Text))
                        {
                            if (new ConsumoMaterialBL().ColocarSGIaOTmanuales(Convert.ToInt32(this.txtPSGIO.Text),
                                Convert.ToInt32(this.hdnIdCabecera.Text)) == eResultado.Error)
                            {
                                return;
                            }
                        }




                        if (new ConsumoMaterialBL().ActualizarCabecera(oCab, Usuario.IdUsuario) != eResultado.Correcto)
                        {

                            X.MessageBox.Alert("SMC GESTION DE OPERACIONES", "Error al actualizar los datos.");
                        }
                        else
                        {


                            if (!string.IsNullOrEmpty(txtPSGIO.Text))
                            {

                                


                                if (new ConsumoMaterialBL().ValidarExistenciaCargo(this.txtPSGIO.Text) == 1)
                                {

                                    X.Msg.Confirm("SMC GESTION DE OPERACIONES", "La O/T se encuentra anexada a otro Cargo. Desea agregarlo al actual?", "if (buttonId == 'yes') { Ext.net.DirectMethods.InsertarACargoNuevo("+ this.hdnIdCabecera.Text.ToString() +"); }").Show();
                                
                                }

                                else
                                    new ConsumoMaterialBL().InsertarCargoSGI(Convert.ToInt32(this.ddlCargo.SelectedItem.Value), Convert.ToInt32(this.ddlObra.SelectedItem.Value), this.hdnIdCabecera.Text.ToString(), Usuario.IdUsuario);


                                

                                this.CargarGrillaCargoSGIs();
                                this.LimpiarControles();
                                this.CargarDetallesConsumo(0);
                                this.txtPSGIO.Focus(true, 10);
                                this.imgBuscarSGIO.Hidden = false;
                                this.ImageButton1.Hidden = false;
                                this.ImageButton2.Hidden = true;
                            }

                            this.CargarGrillaCargoSGIs();
                            this.LimpiarControles();
                            this.CargarDetallesConsumo(0);
                            this.txtPSGIO.Focus(true, 10);
                            this.imgBuscarSGIO.Hidden = false;
                            this.ImageButton1.Hidden = false;
                            this.ImageButton2.Hidden = true;
                        }

                    }
                    else
                    {
                        

                       
                        oCab.Obra = new ObraDTO()
                        {
                            IdObra = Convert.ToInt32(this.ddlObra.SelectedItem.Value),
                        };
                        oCab.Actividad = new ActividadDTO()
                        {
                            IdActividad = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value),
                        };
                        oCab.Distrito = new DistritoDTO()
                        {
                            IdDistrito = Convert.ToInt32(this.ddlDistrito.SelectedItem.Value),
                        };
                        int nroRegistro = 0;

                        


                        int codigo = new ConsumoMaterialBL().InsertarNuevaCabecera(oCab, Usuario.IdUsuario,ref nroRegistro);
                        if (codigo == 0)
                        {
                            X.MessageBox.Alert("SMC GESTION DE OPERACIONES", "Error al ingresar los datos.");
                        }
                        else
                        {
                            this.txtPCorrelativo.Text = nroRegistro.ToString();
                            this.hdnIdCabecera.Text = codigo.ToString();
                            this.hdnTipoAccion.Text = "1";
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

        [DirectMethod]   
        public void EliminaSGICargo(string comando,string sgi)
            {
                try
                {
                    new ConsumoMaterialBL().EliminarSGICargo(Convert.ToInt32(this.ddlObra.SelectedItem.Value), sgi, Usuario.IdUsuario);
                    this.CargarGrillaCargoSGIs();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            [DirectMethod]
               public void InsertarACargoNuevo(string idcabecera)
            {
                new ConsumoMaterialBL().InsertarCargoSGI(Convert.ToInt32(this.ddlCargo.SelectedItem.Value), Convert.ToInt32(this.ddlObra.SelectedItem.Value), idcabecera.ToString(), Usuario.IdUsuario);
                this.CargarGrillaCargoSGIs();
            }

            [DirectMethod]
            public void ManejarConsumo(string comando, int tipo, int id,string unidad)
            {
                try
                {
                    switch (comando)
                    {
                        case "Eliminar":
                            switch (tipo)
                            {
                                case 1:
                                    new ConsumoMaterialBL().EliminarDetalleSubActividad(id, Usuario.IdUsuario);
                                    break;
                                case 2:
                                    new ConsumoMaterialBL().EliminarDetalleSubActividad(id, Usuario.IdUsuario);
                                    break;
                                case 3:
                                    new ConsumoMaterialBL().EliminarDetalle(id, Usuario.IdUsuario);
                                    break;
                            }
                            this.CargarDetallesConsumo(Convert.ToInt32(this.hdnIdCabecera.Text));
                            break;

                        case "Editar":
                            switch (tipo)
                            {
                                case 1:
                                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                                    int actividad = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                                    List<SubActividadDTO> olSubAct = new SubActividadBL().ObtenerSubActividad(obra, actividad);
                                    if (olSubAct != null)
                                    {
                                        this.StoreSubAct.DataSource = olSubAct;
                                        this.StoreSubAct.DataBind();
                                        this.ddlSubActDescripcion.SelectedItem.Value = "";
                                    }
                                    this.txtSubActUnidad.Text = "";
                                    this.txtSubActPrecio.Text = "";
                                    this.txtSubActCantidad.Text = "";
                                    this.txtsubactobservacion.Text = "";

                                    this.Window2.Show();
                                    DetalleSubActividadDTO odet = new ConsumoMaterialBL().ObtenerDetalleSubActividadPorID(id);
                                    if (odet != null)
                                    {
                                        this.hdnIdSubAct.Text = odet.IdDetalleSubAct.ToString();
                                        this.ddlSubActDescripcion.SelectedItem.Value = odet.IdSubActividad.ToString();
                                        this.txtSubActPrecio.Text = odet.Costo.ToString();
                                        this.txtSubActCantidad.Text = odet.Cantidad.ToString();
                                        this.txtsubactobservacion.Text = odet.Observacion.ToString();
                                    }
                                    this.txtSubActUnidad.Text = unidad;
                                    this.txtSubActCantidad.Focus(true, 10);
                                    break;
                                case 2:
                                    int obra3 = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                                    int actividad3 = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                                    List<SubActividadDTO> olSubAct2 = new SubActividadBL().ObtenerTrabajoComplemantario(obra3, actividad3);
                                    if (olSubAct2 != null)
                                    {
                                        this.StoreTC.DataSource = olSubAct2;
                                        this.StoreTC.DataBind();
                                        this.ddlTCDescripcion.SelectedItem.Value = "";
                                    }
                                    
                                    this.txtTCUnidad.Text = "";
                                    this.txtTCPrecio.Text = "";
                                    this.txtTCCantidad.Text = "";
                                    this.txtTCobservacion.Text = "";
                                    this.Window4.Show();
                                    DetalleSubActividadDTO odet2 = new ConsumoMaterialBL().ObtenerDetalleSubActividadPorID(id);
                                    if (odet2 != null)
                                    {
                                        this.hdnIdTC.Text = odet2.IdDetalleSubAct.ToString();
                                        this.ddlTCDescripcion.SelectedItem.Value = odet2.IdSubActividad.ToString();
                                        this.txtTCPrecio.Text = odet2.Costo.ToString();
                                        this.txtTCCantidad.Text = odet2.Cantidad.ToString();
                                        this.txtTCobservacion.Text = odet2.Observacion;
                                        if (odet2.IdCuadrilla != 0)
                                        {
                                            this.ddlTCCuadrilla.SelectedItem.Value = odet2.IdCuadrilla.ToString();
                                            this.ddlTCCuadrilla.Show();
                                            this.ddlTCProveedor.Hide();
                                            this.rCuadrilla.Checked = true;
                                            this.rProveedor.Checked = false;
                                        }
                                        if (odet2.IdProveedor != 0)
                                        {
                                            this.ddlTCProveedor.SelectedItem.Value = odet2.IdProveedor.ToString();
                                            this.ddlTCCuadrilla.Hide();
                                            this.ddlTCProveedor.Show();
                                            this.rCuadrilla.Checked = false;
                                            this.rProveedor.Checked = true;
                                        }
                                    }
                                    this.txtTCUnidad.Text = unidad;
                                    this.txtTCCantidad.Focus(true, 10);
                                    break;
                                case 3:
                                    int obra2 = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                                    int actividad2 = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                                    List<CatalogoDTO> olCatalogo = new CatalogoBL().ListarPorActividad(obra2, actividad2);
                                    if (olCatalogo != null)
                                    {
                                        this.StoreMaterial.DataSource = olCatalogo;
                                        this.StoreMaterial.DataBind();
                                        this.ddlMaterialDescripcion.SelectedItem.Value = "";
                                    }
                                    
                                    this.txtMaterialUnidad.Text = "";
                                    this.txtMaterialPrecio.Text = "";
                                    this.txtMaterialCantidad.Text = "";
                                    this.txtmaterialobservacion.Text = "";

                                    this.Window1.Show();
                                    DetalleDTO odet3 = new ConsumoMaterialBL().ObtenerDetallePorID(id);
                                    if (odet3 != null)
                                    {
                                        this.hdnIdMaterial.Text = odet3.IdDetalle.ToString();
                                        this.ddlMaterialDescripcion.SelectedItem.Value = odet3.Catalogo.IdProCatalogo.ToString();
                                        this.txtMaterialPrecio.Text = odet3.Costo.ToString();
                                        this.txtMaterialCantidad.Text = odet3.Cantidad.ToString();
                                        this.txtmaterialobservacion.Text = odet3.Observacion.ToString();
                                    }
                                    this.txtMaterialUnidad.Text = unidad;
                                    this.txtMaterialCantidad.Focus(true, 10);
                                    break;
                            }
                            this.CargarDetallesConsumo(Convert.ToInt32(this.hdnIdCabecera.Text));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }
        #endregion

        #region eventos - ventana busqueda

            protected void btnPBuscar_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    int nuevo;
                    if (Int32.TryParse(ddlObra.SelectedItem.Value, out nuevo))
                    {
                        nuevo = Convert.ToInt32(ddlObra.SelectedItem.Value);
                        this.Window3.Show();
                    }
                    else
                        this.Mensaje("PRIMERO DEBE SELECCIONAR LA OBRA.");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            //protected void LimpiarCargosSGIs(object sender, DirectEventArgs e)
            //{
            //    try
            //    {
            //        new ConsumoMaterialBL().EliminarCargoSGI(Usuario.IdUsuario);
            //        this.CargarGrillaCargoSGIs();
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Mensaje(ex.Message);
            //    }
            //}

            protected void RowDblClick_Event(object sender, DirectEventArgs e)
            {
                try
                {
                    this.LimpiarControles();
                    
                    string json = e.ExtraParams["Values"];
                    List<CabeceraDTO> olCabeceras = JSON.Deserialize<List<CabeceraDTO>>(json);
                    CabeceraDTO oCabecera = new CabeceraDTO();
                    oCabecera = olCabeceras[0];
                    this.hdnIdCabecera.Text = oCabecera.IdCabecera.ToString();
                    this.txtPOrden.Text = oCabecera.NumeroOrden;
                    this.txtPSGIO.Text = oCabecera.Sgi;
                    
                    

                    this.txtPNIS.Text = oCabecera.Suministro;
                    this.txtPFecOrden.Text = oCabecera.FechaOrden;
                    this.txtPFecProg.Text = oCabecera.FechaProgramacion;
                    this.txtPFecIni.Text = oCabecera.FechaInicio;
                    this.txtPHorIni.Text = oCabecera.HoraInicio;
                    this.txtPFecFin.Text = oCabecera.FechaTermino;
                    this.txtPHorFin.Text = oCabecera.Horatermino;
                    this.ddlDistrito.SelectedItem.Value = oCabecera.Distrito.IdDistrito.ToString();
                    if (oCabecera.Cuadrilla.IdCuadrilla > 0)
                        this.ddlPCuadrilla.SelectedItem.Value = oCabecera.Cuadrilla.IdCuadrilla.ToString();
                    if (oCabecera.EstadoOT.IdEstadoOT > 0)
                    {
                        if (oCabecera.EstadoOT.DescripcionEstado == "RESUELTO")
                            this.ddlPEstado.SelectedItem.Text = "RESUELTO";
                        else
                            this.ddlPEstado.SelectedItem.Value = "45";
                    }
                    if (oCabecera.EstadoOTRO.IdEstadoOT > 0)
                        this.ddlPEstadoRO.SelectedItem.Value = oCabecera.EstadoOTRO.IdEstadoOT.ToString();
                    this.txtPDireccion.Text = oCabecera.Direccion;
                    this.txtPCliente.Text = oCabecera.Cliente;
                    this.txtPUrbanizacion.Text = oCabecera.Urbanizacion;
                    this.ddlPActividad.SelectedItem.Value = oCabecera.Actividad.IdActividad.ToString();
                    this.txtHorTrab.Text = oCabecera.HorasTrabajadas.ToString();
                    this.txtNroTrab.Text = oCabecera.NumeroTrabajadores.ToString();
                    this.txtPCorrelativo.Text = oCabecera.NroRegistro.ToString();
                    this.TextTotalSGIO.Text = oCabecera.CostoOPEN.ToString();
                    this.CargarDetallesConsumo(oCabecera.IdCabecera);
                    this.hdnTipoAccion.Text = "1";
                    if (oCabecera.EstadoOT.DescripcionEstado == "RESUELTO")
                    {
                        this.DesactivarControles(true);
                        this.GridPanel1.Disabled = true;
                    }
                    else
                    {
                        this.DesactivarControles(false);
                        this.GridPanel1.Disabled = false;
                    }
                    
                    this.Window3.Hide();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

           

        #endregion

        #region metodos personalizados - ventana busqueda

            protected void CargarGrillaBusquedaOT(object sender, DirectEventArgs e)
            {
                try
                {
                    if (!string.IsNullOrEmpty(this.txtNroOrden.Text) || !string.IsNullOrEmpty(this.txtSGI.Text))
                    {
                        string nroOT = this.txtNroOrden.Text == "" ? "0" : this.txtNroOrden.Text;
                        string sgi = this.txtSGI.Text == "" ? "0" : this.txtSGI.Text;
                        List<CabeceraDTO> olcab = new ConsumoMaterialBL().ObtenerCabeceraConsumo(Convert.ToInt32(ddlObra.SelectedItem.Value), nroOT, sgi,0,Usuario.IdUsuario);
                        if (olcab != null)
                        {
                            this.StoreOT.DataSource = olcab;
                            this.StoreOT.DataBind();
                        }
                    }
                    else
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE INGRESAR EL NÚMERO DE SGI Y/O EL NÚMERO DE LA ORDEN", Buttons = Ext.Net.MessageBox.Button.OK });
                        //this.Mensaje("DEBE INGRESAR EL NÚMERO DE SGI Y/O EL NÚMERO DE LA ORDEN");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            } 
        
            private void CargarDetallesConsumo(int ID)
            {
                try
                {
                    List<ConsumoMaterialDTO> olCM = new ConsumoMaterialBL().ObtenerDetalleConsumo(ID);
                    if (olCM != null)
                    {
                        this.StoreEjecucionOT.DataSource = olCM;
                        this.StoreEjecucionOT.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
                if(ID!=0)
                    ObtenerTotalOT();
            }

        #endregion

            #region METODOS PERSONALIZADOS - VENTANA DE SUBACTIVIDAD
            protected void AgregarSubActividad(object sender, DirectEventArgs e)
            {
                try
                {
                    if (this.hdnIdCabecera.Text != "0" && this.hdnIdCabecera.Text != "")
                    {
                        int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                        int actividad = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                        List<SubActividadDTO> olSubAct = new SubActividadBL().ObtenerSubActividad(obra, actividad);
                        if (olSubAct != null)
                        {
                            this.StoreSubAct.DataSource = olSubAct;
                            this.StoreSubAct.DataBind();
                            this.ddlSubActDescripcion.SelectedItem.Value = "";
                        }
                        this.txtSubActUnidad.Text = "";
                        this.txtSubActPrecio.Text = "";
                        this.txtSubActCantidad.Text = "";
                        
                        this.Window2.Show();
                        this.ddlSubActDescripcion.Focus(true, 10);
                    }
                    else
                        this.Mensaje("Debe guardar los datos de la cabecera.");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            //protected void CargarUnidad(object sender, DirectEventArgs e)
            //{
            //    try
            //    {
            //        string unid = e.ExtraParams["Unidad"];
            //        string precio = e.ExtraParams["Precio"];
            //        this.txtSubActUnidad.Text = unid;
            //        this.txtSubActPrecio.Text = precio;
            //        this.txtSubActCantidad.Focus();
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Mensaje(ex.Message);
            //    }
            //}

           
            [DirectMethod]
            public void btnSubActAgregar_Click()
            {
                try
                {
                    if (String.IsNullOrEmpty(this.ddlSubActDescripcion.SelectedItem.Value))
                    {
                        this.Mensaje("Seleccione la Sub-Actividad.");
                        return;
                    }
                    if (String.IsNullOrEmpty(this.txtSubActCantidad.Text))
                    {
                        this.Mensaje("Ingrese Cantidad.");
                        return;
                    }
                    DetalleSubActividadDTO oDet = new DetalleSubActividadDTO();
                    oDet.IdCabecera = Convert.ToInt32(this.hdnIdCabecera.Text);
                    oDet.IdSubActividad = Convert.ToInt32(this.ddlSubActDescripcion.SelectedItem.Value);
                    oDet.Costo = Convert.ToDecimal(this.txtSubActPrecio.Text);
                    oDet.Cantidad = Convert.ToDecimal(this.txtSubActCantidad.Text);
                    oDet.Observacion = txtsubactobservacion.Text;
                    if (!string.IsNullOrEmpty(this.hdnIdSubAct.Text))
                    {
                        oDet.IdDetalleSubAct = Convert.ToInt32(this.hdnIdSubAct.Text);
                        new ConsumoMaterialBL().ActualizarDetalleSubActividad(oDet,0,0, Usuario.IdUsuario);
                    }
                    else
                    {
                        new ConsumoMaterialBL().InsertarDetalleSubActividad(oDet,0,0, Usuario.IdUsuario);
                    }

                    this.CargarDetallesConsumo(oDet.IdCabecera);
                    this.txtSubActUnidad.Text = "";
                    this.txtSubActPrecio.Text = "";
                    this.txtSubActCantidad.Text = "";
                    this.txtsubactobservacion.Text = "";
                    this.ddlSubActDescripcion.SelectedItem.Value = "";
                    this.ddlSubActDescripcion.Focus();
                    //this.Window2.Hide();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
                ObtenerTotalOT();
            }
            #endregion

            #region METODOS PERSONALIZADOS - VENTANA DE MATERIALES

            //protected void AgregarMaterial(object sender, DirectEventArgs e)
            [DirectMethod]
            public void AgregarMaterial()
            {
                try
                {
                    if (this.hdnIdCabecera.Text != "0" && this.hdnIdCabecera.Text != "")
                    {
                        int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                        int actividad = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                        List<CatalogoDTO> olcatg = new CatalogoBL().ListarPorActividad(obra, actividad);
                        if (olcatg != null)
                        {
                            this.StoreMaterial.DataSource = olcatg;
                            this.StoreMaterial.DataBind();
                            this.ddlMaterialDescripcion.SelectedItem.Value = "";
                        }
                        this.txtMaterialUnidad.Text = "";
                        this.txtMaterialPrecio.Text = "";
                        this.txtMaterialCantidad.Text = "";
                        
                        this.Window1.Show();
                        this.ddlMaterialDescripcion.Focus(true,10);
                        
                    }
                    else
                        this.Mensaje("Debe guardar los datos de la cabecera.");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            //protected void CargarMaterial(object sender, DirectEventArgs e)
            //{
            //    try
            //    {
            //        string unid = e.ExtraParams["Unidad"];
            //        string precio = e.ExtraParams["Precio"];
            //        this.txtMaterialUnidad.Text = unid;
            //        this.txtMaterialPrecio.Text = precio;
            //        this.txtMaterialCantidad.Focus();
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Mensaje(ex.Message);
            //    }
            //}

            [DirectMethod]
            public void btnMaterialAgregar_Click()
            {
                try
                {
                    if (String.IsNullOrEmpty(this.ddlMaterialDescripcion.SelectedItem.Value))
                    {
                        this.Mensaje("Seleccione el Material.");
                        return;
                    }
                    if (String.IsNullOrEmpty(this.txtMaterialCantidad.Text))
                    {
                        this.Mensaje("Ingrese Cantidad.");
                        return;
                    }
                    DetalleDTO oDet = new DetalleDTO();
                    oDet.Cabecera = new CabeceraDTO()
                    {
                        IdCabecera = Convert.ToInt32(this.hdnIdCabecera.Text),
                    };
                    oDet.Catalogo = new CatalogoDTO()
                    {
                        IdProCatalogo = Convert.ToInt32(this.ddlMaterialDescripcion.SelectedItem.Value),
                    };
                    oDet.Cantidad = Convert.ToDecimal(this.txtMaterialCantidad.Text);
                    oDet.Costo = Convert.ToDecimal(this.txtMaterialPrecio.Text);
                    oDet.Observacion = txtmaterialobservacion.Text;
                    if (!String.IsNullOrEmpty(this.hdnIdMaterial.Text))
                    {
                        oDet.IdDetalle = Convert.ToInt32(this.hdnIdMaterial.Text);
                        new ConsumoMaterialBL().ActualizarDetalle(oDet, Usuario.IdUsuario);
                    }
                    else
                    {
                        new ConsumoMaterialBL().InsertarDetalleMaterial(oDet, Usuario.IdUsuario);
                    }
                    this.CargarDetallesConsumo(oDet.Cabecera.IdCabecera);

                    this.txtMaterialUnidad.Text = "";
                    this.txtMaterialPrecio.Text = "";
                    this.txtMaterialCantidad.Text = "";
                    this.txtmaterialobservacion.Text = "";
                    this.ddlMaterialDescripcion.SelectedItem.Value = "";
                    this.ddlMaterialDescripcion.Focus();
                    //this.Window1.Hide();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }

                ObtenerTotalOT();
            }
            #endregion

            #region METODOS PERSONALIZADOS - VENTANA DE TRABAJOS COMPLEMENTARIOS
            protected void AgregarTC(object sender, DirectEventArgs e)
            {
                try
                {
                    if (this.hdnIdCabecera.Text != "0" && this.hdnIdCabecera.Text != "")
                    {
                        int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                        int actividad = Convert.ToInt32(this.ddlPActividad.SelectedItem.Value);
                        List<SubActividadDTO> olsubact = new SubActividadBL().ObtenerTrabajoComplemantario(obra, actividad);
                        if (olsubact != null)
                        {
                            this.StoreTC.DataSource = olsubact;
                            this.StoreTC.DataBind();
                            this.ddlTCDescripcion.SelectedItem.Value = "";

                            if (string.IsNullOrEmpty(this.ddlPCuadrilla.SelectedItem.Value))
                                this.ddlTCCuadrilla.SelectedItem.Value = "";
                            else
                                this.ddlTCCuadrilla.SelectedItem.Value = this.ddlPCuadrilla.SelectedItem.Value;
                            
                        }
                        this.txtTCUnidad.Text = "";
                        this.txtTCPrecio.Text = "";
                        this.txtTCCantidad.Text = "";

                        this.rCuadrilla.Checked = true;
                        this.rProveedor.Checked = false;
                        this.ddlTCCuadrilla.Show();
                        this.ddlTCProveedor.Hide();

                        this.Window4.Show();
                        this.ddlTCDescripcion.Focus(true,10);
                    }
                    else
                        this.Mensaje("Debe guardar los datos de la cabecera.");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            //protected void CargarTC(object sender, DirectEventArgs e)
            //{
            //    try
            //    {
            //        string unid = e.ExtraParams["Unidad"];
            //        string precio = e.ExtraParams["Precio"];
            //        this.txtTCUnidad.Text = unid;
            //        this.txtTCPrecio.Text = precio;
            //        this.txtTCCantidad.Focus();
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Mensaje(ex.Message);
            //    }
            //}

            [DirectMethod]
            public void btnTCAgregar_Click()
            {
                try
                {
                    if (String.IsNullOrEmpty(this.ddlTCDescripcion.SelectedItem.Value))
                    {
                        this.Mensaje("Seleccione el Trabajo Complementario.");
                        return;
                    }
                    if (String.IsNullOrEmpty(this.txtTCCantidad.Text))
                    {
                        this.Mensaje("Ingrese Cantidad.");
                        return;
                    }
                    DetalleSubActividadDTO oDet = new DetalleSubActividadDTO();
                    oDet.IdCabecera = Convert.ToInt32(this.hdnIdCabecera.Text);
                    oDet.IdSubActividad = Convert.ToInt32(this.ddlTCDescripcion.SelectedItem.Value);
                    oDet.Costo = Convert.ToDecimal(this.txtTCPrecio.Text);
                    oDet.Cantidad = Convert.ToDecimal(this.txtTCCantidad.Text);
                    oDet.Observacion = txtTCobservacion.Text;

                    int IdCuadrilla = 0;
                    int IdProveedor = 0;
                    if (this.rProveedor.Checked == true) IdProveedor = Convert.ToInt32(this.ddlTCProveedor.SelectedItem.Value);
                    if (this.rCuadrilla.Checked == true) IdCuadrilla = Convert.ToInt32(this.ddlTCCuadrilla.SelectedItem.Value); 

                    if (!string.IsNullOrEmpty(this.hdnIdTC.Text))
                    {
                        oDet.IdDetalleSubAct = Convert.ToInt32(this.hdnIdTC.Text);
                        new ConsumoMaterialBL().ActualizarDetalleSubActividad(oDet,IdCuadrilla,IdProveedor, Usuario.IdUsuario);
                    }
                    else
                    {
                        new ConsumoMaterialBL().InsertarDetalleSubActividad(oDet,IdCuadrilla,IdProveedor, Usuario.IdUsuario);
                    }

                    this.CargarDetallesConsumo(oDet.IdCabecera);
                    this.txtTCUnidad.Text = "";
                    this.txtTCPrecio.Text = "";
                    this.txtTCCantidad.Text = "";
                    this.txtTCobservacion.Text = "";
                    this.ddlTCDescripcion.SelectedItem.Value = "";
                    this.ddlTCDescripcion.Focus();
                    //this.Window4.Hide();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
                ObtenerTotalOT();
            }
            #endregion

            #region Obtiene total OT


            private void ObtenerTotalOT()
            {
                try
                {


                    List<ConsumoMaterialDTO> odetalle =
                        new ConsumoMaterialBL().ObtenerDetalleConsumo(Convert.ToInt32(this.hdnIdCabecera.Text));

                    decimal total = 0;
                    foreach (ConsumoMaterialDTO item in odetalle)
                    {
                        total = total + item.SubTotal;
                    }

                    TextTotalOT.Text = total.ToString("0.00");
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void BuscarPorNROOT(object sender, DirectEventArgs e)
            {
                if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    if (string.IsNullOrEmpty(this.txtPOrden.Text))
                        this.Mensaje("INGRESE NÚMERO DE ORDEN DE TRABAJO.");
                    else
                    {

                        List<CuadrillaDTO> olCuad = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                        if (olCuad != null)
                        {
                            this.StoreCuadrilla.DataSource = olCuad;
                            this.StoreCuadrilla.DataBind();

                            this.StoreTCCuadrilla.DataSource = olCuad;
                            this.StoreTCCuadrilla.DataBind();
                        }



                        //List<CabeceraDTO> olCabeceras = new ConsumoMaterialBL().ObtenerCabeceraConsumo(Convert.ToInt32(this.ddlObra.SelectedItem.Value), this.txtPOrden.Text, "0", 0, Usuario.IdUsuario);
                        EjecucionOTDTO olCabeceras = new EjecucionOTBL().GetEjecucionOTPorNroRegistro(Convert.ToInt32(this.txtPOrden.Text));


                        if (olCabeceras.IdEjecucionOT>0)
                        {
                            this.LimpiarControles();
                            
                            //CabeceraDTO oCabecera = new CabeceraDTO();
                            //oCabecera = olCabeceras[0];

                            EjecucionOTDTO oCabecera = olCabeceras;

                            this.hdnIdCabecera.Text = "0"; //oCabecera.IdCabecera.ToString();
                            this.txtPOrden.Text = oCabecera.NroPosicion.ToString();//oCabecera.NumeroOrden;
                            this.txtPSGIO.Text = "0";//oCabecera.Sgi;
                            this.txtObservacion.Text = oCabecera.Observacion;


                            this.txtPNIS.Text = "0";//oCabecera.Suministro;
                            this.txtPFecOrden.Text = oCabecera.FechaOrden;
                            this.txtPFecProg.Text = oCabecera.FechaProg; //oCabecera.FechaProgramacion;
                            this.txtPFecIni.Text = oCabecera.FechaInicio;
                            this.txtPHorIni.Text = oCabecera.HoraInicio;
                            this.txtPFecFin.Text = oCabecera.FechaFin;//oCabecera.FechaTermino;
                            this.txtPHorFin.Text = oCabecera.HoraFin;//oCabecera.Horatermino;

                            
                            
                            //OrdenTrabajoDTO oOrdenTrabajoDTO=new OrdenTrabajoDTO();
                            //oOrdenTrabajoDTO=new OrdenTrabajoBL().GetOrdenTrabajoPorID(Convert.ToInt32(oCabecera.NroOrden));

                            List<DistritoDTO> olDistrito = new List<DistritoDTO>();
                            olDistrito = new DistritoBL().ListarDistrito().OrderBy(x => x.Distrito).ToList();
                            DistritoDTO tmp =(DistritoDTO) (from item in olDistrito
                                     where item.Distrito==oCabecera.OrdenTrabajo.municipio
                                         select item).Single();


                            this.ddlDistrito.SelectedItem.Value = tmp.IdDistrito.ToString(); //oCabecera.Distrito.IdDistrito.ToString();
                            if (oCabecera.Cuadrilla.IdCuadrilla > 0)
                                this.ddlPCuadrilla.SelectedItem.Value = oCabecera.Cuadrilla.IdCuadrilla.ToString();

                            if (oCabecera.EstadoOT.IdEstadoOT > 0)
                            {
                                if (oCabecera.EstadoOT.DescripcionEstado == "FACTURADO")
                                    this.ddlPEstado.SelectedItem.Text = "FACTURADO";
                                else
                                    this.ddlPEstado.SelectedItem.Value = "45";
                            }
                            //if (oCabecera.EstadoOTRO.IdEstadoOT > 0)
                            if (oCabecera.EstadoOT.IdEstadoOT > 0)
                                this.ddlPEstadoRO.SelectedItem.Value = oCabecera.EstadoOT.IdEstadoOT.ToString();//oCabecera.EstadoOTRO.IdEstadoOT.ToString();

                            this.txtPDireccion.Text = oCabecera.Direccion;
                            this.txtPCliente.Text = oCabecera.OrdenTrabajo.cliente;//oCabecera.Cliente;
                            this.txtPUrbanizacion.Text = "";//oCabecera.Urbanizacion;

                            ActividadDTO otmpActividadDTO = new ActividadBL().ListarActividadPorCODIGO(oCabecera.OrdenTrabajo.actividad.ToString());


                            this.ddlPActividad.SelectedItem.Value = otmpActividadDTO.IdActividad.ToString(); //oCabecera.Actividad.IdActividad.ToString();
                            this.txtHorTrab.Text = "0";//oCabecera.HorasTrabajadas.ToString();
                            this.txtNroTrab.Text = "0";// oCabecera.NumeroTrabajadores.ToString();
                            this.txtPCorrelativo.Text = "0";// oCabecera.NroRegistro.ToString();
                            this.TextTotalSGIO.Text = "0";//oCabecera.CostoOPEN.ToString();
                            this.txtPNroCargo.Text = "";// oCabecera.NroCargo;
                            
                            //this.CargarDetallesConsumo(oCabecera.IdCabecera);
                            
                            this.hdnTipoAccion.Text = "1";
                            //if (oCabecera.EstadoOT.DescripcionEstado == "FACTURADO")
                            //{
                            //    this.DesactivarControles(true);
                            //    this.GridPanel1.Disabled = true;
                            //}
                            //else
                            //{
                                this.DesactivarControles(false);
                                this.GridPanel1.Disabled = false;
                                this.txtPUrbanizacion.Disabled = false;

                            //}
                        }
                        else
                        {
                            this.Mensaje("EL NRO DE OT INGRESADO NO EXISTE!.");
                        }
                    }
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA!.");
            }

            #region bryanActD

            [DirectMethod]
            public void ActualizaBuzon(string buz, bool cuerpo, bool emboq, int idBuz, int idCab, bool mEst, string mMat, bool mNiv, bool media, double prof, bool sol, string tEst, string tMat, bool techo, bool sella)
            {
                DetalleBuzonBL oDetalleBuzonBL = new DetalleBuzonBL();
                DetalleBuzonDTO oDetalleBuzonDTO = new DetalleBuzonDTO();
                oDetalleBuzonDTO.idBuzon = idBuz;
                oDetalleBuzonDTO.idCabecera = idCab;
                oDetalleBuzonDTO.buzon = buz;
                oDetalleBuzonDTO.cuerpo = cuerpo;
                oDetalleBuzonDTO.emboquillado = emboq;
                oDetalleBuzonDTO.marcoEstado = mEst;
                oDetalleBuzonDTO.marcoMaterial = mMat;
                oDetalleBuzonDTO.marcoNivelado = mNiv;
                oDetalleBuzonDTO.media = media;
                oDetalleBuzonDTO.profundidad = prof;
                oDetalleBuzonDTO.sellado = sella;
                oDetalleBuzonDTO.solado = sol;
                oDetalleBuzonDTO.tapaEstado = tEst;
                oDetalleBuzonDTO.tapaMaterial = tMat;
                oDetalleBuzonDTO.techo = techo;
                if (oDetalleBuzonBL.ActualizaBuzon(oDetalleBuzonDTO) == eResultado.Correcto)
                {
                    
                }
                else
                {
                    Mensaje("No se pudo Actualizar Buzon");
                }
            }
            [DirectMethod]
            public void ActualizaLimpieza(double longi, double VolExt, string Diam, string FechaEj, string HIni, string HFin, int Cuad,
                string MatTubo, double Tirante, bool arena, bool piedra, bool cascajo, bool otros, string otrosDesc)
            {
                int idLim = 0;
                List<DetalleLimpiezaDTO> lDetalleLimpiezaDTO = new List<DetalleLimpiezaDTO>();
                DetalleLimpiezaBL oDetalleLimpiezaBL = new DetalleLimpiezaBL();
                lDetalleLimpiezaDTO = oDetalleLimpiezaBL.ConsultaLimpieza(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetalleLimpiezaDTO o in lDetalleLimpiezaDTO)
                {
                    idLim = o.idLimpieza;
                }

                DetalleLimpiezaDTO oDetalleLimpiezaDTO = new DetalleLimpiezaDTO();
                oDetalleLimpiezaDTO.idLimpieza = idLim;
                oDetalleLimpiezaDTO.idCuadrilla = Cuad;
                oDetalleLimpiezaDTO.arena = arena;
                oDetalleLimpiezaDTO.cascajo = cascajo;
                oDetalleLimpiezaDTO.diametro = Diam;
                oDetalleLimpiezaDTO.fecha = FechaEj;
                oDetalleLimpiezaDTO.horaFin = HFin;
                oDetalleLimpiezaDTO.horaInicio = HIni;
                oDetalleLimpiezaDTO.longitud = longi;
                oDetalleLimpiezaDTO.materialTubo = MatTubo;
                oDetalleLimpiezaDTO.otros = otros;
                oDetalleLimpiezaDTO.otrosDesc = otrosDesc;
                oDetalleLimpiezaDTO.piedra = piedra;
                oDetalleLimpiezaDTO.tiranteFlujo = Tirante;
                oDetalleLimpiezaDTO.volumenExtraido = VolExt;
                
                if (oDetalleLimpiezaBL.ActualizaLimpieza(oDetalleLimpiezaDTO)==eResultado.Correcto)
                {
                    this.Mensaje("Se registraron los datos correctamente.");
                }
                else
                {
                    this.Mensaje("No se Pudo Actualizar Limpieza Colector");
                }
            }
            [DirectMethod]
            public void RegistraConexion(double pulgadas, double distancia, string derIzq, string tipoMat)
            {
                int idCab = 0;
                List<DetalleConexionesDTO> oDetalleCon = new List<DetalleConexionesDTO>();
                DetalleConexionesBL ConexionBL = new DetalleConexionesBL();
                oDetalleCon = ConexionBL.ConsultaConexiones(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetalleConexionesDTO o in oDetalleCon)
                {
                    idCab = o.IdCabecera;
                }
                DetalleConexionesBL oDetalleConexionesBL = new DetalleConexionesBL();
                DetalleConexionesDTO oDetalleConexionesDTO = new DetalleConexionesDTO();
                oDetalleConexionesDTO.IdCabecera = idCab;
                oDetalleConexionesDTO.pulgadas = pulgadas;
                oDetalleConexionesDTO.distancia = distancia;
                oDetalleConexionesDTO.izqDer = derIzq;
                oDetalleConexionesDTO.tipoMaterial = tipoMat;
                if (oDetalleConexionesBL.InsertarConexiones(oDetalleConexionesDTO) == eResultado.Correcto)
                {
                    cargaConexiones();
                }
                else
                {
                    Mensaje("No se pudo Registrar Conexion");
                }
            }
            [DirectMethod]
            public void ActualizaConexion(double pulg, double dist, string izqDer, string tipoM, int idCab, int idCon)
            {
                DetalleConexionesBL oDetalleConexionesBL = new DetalleConexionesBL();
                DetalleConexionesDTO oDetalleConexionesDTO = new DetalleConexionesDTO();
                oDetalleConexionesDTO.IdConexiones = idCon;
                oDetalleConexionesDTO.pulgadas = pulg;
                oDetalleConexionesDTO.distancia = dist;
                oDetalleConexionesDTO.izqDer = izqDer;
                oDetalleConexionesDTO.tipoMaterial = tipoM;
                if (oDetalleConexionesBL.ActualizaConexiones(oDetalleConexionesDTO)==eResultado.Correcto)
                {
                }
                else
                {
                    Mensaje("Error al Actualizar Conexion");
                }
            }
            [DirectMethod]
            public void EliminarConexion(int idCon)
            {
                DetalleConexionesBL oDetConBL = new DetalleConexionesBL();
                if (oDetConBL.EliminarConexiones(idCon) == eResultado.Correcto)
                {
                    cargaConexiones();
                }
                else
                {
                    Mensaje("No se pudo Eliminar Conexion");
                }
            }
            [DirectMethod]
            public void RegistraDeficiencia(int cod, double dist, bool puntual, double extendida)
            {
                int idCab = 0;
                List<DetalleDeficienciasDTO> oDetalleDef = new List<DetalleDeficienciasDTO>();
                DetalleDeficienciasBL DefBL = new DetalleDeficienciasBL();
                oDetalleDef = DefBL.ConsultaDeficiencias(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetalleDeficienciasDTO o in oDetalleDef)
                {
                    idCab = o.IdCabecera;
                }
                DetalleDeficienciasBL oDetalleDeficienciasBL = new DetalleDeficienciasBL();
                DetalleDeficienciasDTO oDetalleDeficienciasDTO = new DetalleDeficienciasDTO();
                oDetalleDeficienciasDTO.IdCabecera = idCab;
                oDetalleDeficienciasDTO.codigo = cod;
                oDetalleDeficienciasDTO.distancia = dist;
                oDetalleDeficienciasDTO.puntual = puntual;
                oDetalleDeficienciasDTO.extendida = extendida;
                if (oDetalleDeficienciasBL.InsertarDeficiencias(oDetalleDeficienciasDTO) == eResultado.Correcto)
                {
                    cargarDeficiencias();
                }
                else
                {
                    Mensaje("No se pudo Registrar la Deficiencia");
                }
            }
            [DirectMethod]
            public void ActualizaDeficiencias(int cod, double dist, bool puntual, double extendida, int idCab, int idDef)
            {
                DetalleDeficienciasBL oDetalleDeficienciasBL = new DetalleDeficienciasBL();
                DetalleDeficienciasDTO oDetalleDeficienciasDTO = new DetalleDeficienciasDTO();
                oDetalleDeficienciasDTO.IdDeficiencias = idDef;
                oDetalleDeficienciasDTO.codigo = cod;
                oDetalleDeficienciasDTO.distancia = dist;
                oDetalleDeficienciasDTO.puntual = puntual;
                oDetalleDeficienciasDTO.extendida = extendida;
                if (oDetalleDeficienciasBL.ActualizaDeficiencias(oDetalleDeficienciasDTO)==eResultado.Correcto)
                {
                }
                else
                {
                    Mensaje("No se pudo Actualizar Deficiencias");
                }
            }
            [DirectMethod]
            public void EliminarDeficiencia(int idDef)
            {
                DetalleDeficienciasBL oDetDefBL = new DetalleDeficienciasBL();
                if (oDetDefBL.EliminarDeficiencias(idDef)==eResultado.Correcto)
                {
                    cargarDeficiencias();
                }
                else
                {
                    Mensaje("No se pudo Eliminar Deficiencias");
                }
            }
            [DirectMethod]
            public void ActualizaInspeccion(string estado, int Cuad, string TIni, string TFin, string Fecha)
            {
                int idIns = 0;
                List<DetalleInspeccionDTO> lDetalleInspeccionDTO = new List<DetalleInspeccionDTO>();
                DetalleInspeccionBL oDetalleInspeccionBL = new DetalleInspeccionBL();
                lDetalleInspeccionDTO = oDetalleInspeccionBL.ConsultaInspeccion(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetalleInspeccionDTO o in lDetalleInspeccionDTO)
                {
                    idIns = o.idInspeccion;
                }

                //                DetalleLimpiezaBL oDetalleLimpiezaBL = new DetalleLimpiezaBL();
                DetalleInspeccionDTO oDetalleInspeccionDTO = new DetalleInspeccionDTO();
                oDetalleInspeccionDTO.idInspeccion = idIns;
                oDetalleInspeccionDTO.estado = estado;
                oDetalleInspeccionDTO.fecha = Fecha;
                oDetalleInspeccionDTO.horaInicio = TIni;
                oDetalleInspeccionDTO.horaFin = TFin;
                oDetalleInspeccionDTO.idCuadrilla = Cuad;


                if (oDetalleInspeccionBL.ActualizaInspeccion(oDetalleInspeccionDTO)==eResultado.Correcto)
                {
                    this.Mensaje("Se registraron los datos correctamente.");
                }
                else
                {
                    this.Mensaje("No se pudo Actualizar Inspeccion Televisada");
                }
            }
            void cargaConexiones()
            {
                List<DetalleConexionesDTO> oDetalleCon = new List<DetalleConexionesDTO>();
                DetalleConexionesBL ConexionBL = new DetalleConexionesBL();
                oDetalleCon = ConexionBL.ConsultaConexiones(Convert.ToInt32(hdnIdCabecera.Text));

                storeConexiones.DataSource = oDetalleCon;
                storeConexiones.DataBind();

            }
            void cargarDeficiencias()
            {
                List<DetalleDeficienciasDTO> oDetalleDef = new List<DetalleDeficienciasDTO>();
                DetalleDeficienciasBL DeficienciasBL = new DetalleDeficienciasBL();
                oDetalleDef = DeficienciasBL.ConsultaDeficiencias(Convert.ToInt32(hdnIdCabecera.Text));

                this.storeDeficiencias.DataSource = oDetalleDef;
                storeDeficiencias.DataBind();

            }
            #endregion
            #region Purga
            [DirectMethod]
            public void ActualizaPurga(int sector, double cloro,double tpurga,double presion,string caractAgua, string OpInop,
            int nroBoca, string detOpInop, int nroTapa, string marca, string cgi, bool ubica, bool myt, bool losa, bool mantsi, bool mantno,
              double ANF,  string obs, string colorAgua, string descarga, double distancia)
            {
                int idPurga = 0;
                List<DetallePurgaDTO> lDetallePurgaDTO = new List<DetallePurgaDTO>();
                DetallePurgaBL oDetallePurgaBL = new DetallePurgaBL();
                lDetallePurgaDTO = oDetallePurgaBL.ConsultaPurga(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetallePurgaDTO o in lDetallePurgaDTO)
                {
                    idPurga = o.IdPurga;
                }
                //DetallePurgaBL oDetallePurgaBL = new DetallePurgaBL();
                DetallePurgaDTO oDetallePurgaDTO = new DetallePurgaDTO();
                oDetallePurgaDTO.IdPurga = idPurga;
                oDetallePurgaDTO.sector = sector;
                oDetallePurgaDTO.tiempoPurga = tpurga;
                oDetallePurgaDTO.presion = presion;
                oDetallePurgaDTO.cloro = cloro;
                oDetallePurgaDTO.ANF = ANF;
                oDetallePurgaDTO.caracteristicaAgua = caractAgua;
                if (OpInop.ToString() == "Operativo" && detOpInop.ToString() == "Prev. Mayor")
                {
                    oDetallePurgaDTO.opPrevMayor = true;
                }
                else { oDetallePurgaDTO.opPrevMayor = false; }
                if (OpInop.ToString() == "Operativo" && detOpInop.ToString() == "Prev. Menor")
                {
                    oDetallePurgaDTO.opPrevMenor = true;
                }
                else { oDetallePurgaDTO.opPrevMenor = false; }
                if (OpInop.ToString() == "Inoperativo" && detOpInop.ToString() == "Correctivo")
                {
                    oDetallePurgaDTO.InopCorrectivo = true;
                }
                else { oDetallePurgaDTO.InopCorrectivo = false; }
                if (OpInop.ToString() == "Inoperativo" && detOpInop.ToString() == "Cambio")
                {
                    oDetallePurgaDTO.InopCambio = true;
                }
                else { oDetallePurgaDTO.InopCambio = false; }
                
                
                oDetallePurgaDTO.marca = marca;
                oDetallePurgaDTO.nroBocas = nroBoca;
                oDetallePurgaDTO.nroTapas = nroTapa;
                oDetallePurgaDTO.CGI = cgi;

                if (ubica == false)
                {
                    oDetallePurgaDTO.ubica = ubica;
                    oDetallePurgaDTO.sinMyT = false;
                    oDetallePurgaDTO.losaDeteriorada = false;
                    oDetallePurgaDTO.mantenimiento = false;
                }
                if (ubica == true)
                {
                    oDetallePurgaDTO.ubica = ubica;
                    oDetallePurgaDTO.sinMyT = myt;
                    oDetallePurgaDTO.losaDeteriorada = losa;
                    oDetallePurgaDTO.mantenimiento = mantsi;
                }

                oDetallePurgaDTO.colorAgua = colorAgua;
                oDetallePurgaDTO.descargaEn = descarga;
                oDetallePurgaDTO.distanciaDescarga = distancia;
                oDetallePurgaDTO.observacion = obs;
               
               if (oDetallePurgaBL.ActualizaPurga(oDetallePurgaDTO)==eResultado.Correcto)
                {
                    Mensaje("Se guardaron los datos Correctamente.");
                }
                else
                {
                    Mensaje("Error al guardar los datos de Purga");
                }
            }

            protected void btnCancelarPurga_Click(object sender, DirectEventArgs e)
            {
                cancelarPurga();
            }

            void cancelarPurga()
            {
                Sector.Text = "0";
                Cloro.Text = "0";
                Tpurga.Text = "0";
                Presion.Text = "0";
                cbCaractAgua.Text = "";
                nroTapas.Text = "0";
                marca.Text = "";
                cbCGI.Text = "";
                ckUbica.Checked = false;
                ckMyT.Checked = false;
                ckLosa.Checked = false;
                this.rbsi.Checked = false;
                rbno.Checked = false;
                ANF.Text = "0";
                taObs.Text = "";
                cbColorAgua.Text = "";
                cbDescarga.Text = "";
                Distancia.Text = "0";
            }
            #endregion

            #region Caracteristicas
            [DirectMethod]
            public void ActualizaCaracteristicas(int Valvueltas, bool ValIzq, bool ValDer, int ValNivApert,string ValEstado,
            string ValMarca, string GrifDiametro, int GrifoBocas, string GrifMarca, int GrifVueltas,int GrifSec,int GrifVueltAb,
            bool Op, bool Inop, int TapBoc, bool seco, bool hum, string ubica, string ubicaVal)
            {
                int idCaracteristica = 0;
                List<DetalleCaracteristicasDTO> lDetalleCarDTO = new List<DetalleCaracteristicasDTO>();
                DetalleCaracteristicasBL oDetalleCarBL = new DetalleCaracteristicasBL();
                lDetalleCarDTO = oDetalleCarBL.SelectCaracteristicas(Convert.ToInt32(hdnIdCabecera.Text));
                foreach (DetalleCaracteristicasDTO o in lDetalleCarDTO)
                {
                    idCaracteristica = o.IdCaracteristicas;
                }
                DetalleCaracteristicasDTO oDetalleCarDTO = new DetalleCaracteristicasDTO();
                oDetalleCarDTO.IdCaracteristicas = idCaracteristica;
                oDetalleCarDTO.ValNroVueltas = Valvueltas;
                oDetalleCarDTO.ValNivelAp = ValNivApert;
                oDetalleCarDTO.ValMarca = ValMarca;
                //Valvula 1 Derecha ---- 0 Izquierda
                oDetalleCarDTO.ValIzqDer = ValDer;
                oDetalleCarDTO.ValEstado = ValEstado;
                oDetalleCarDTO.GrifoDiametro = GrifDiametro;
                oDetalleCarDTO.GrifoMarca = GrifMarca;
                oDetalleCarDTO.GrifoNroBocas = GrifoBocas;
                oDetalleCarDTO.GrifoNroVueltas = GrifVueltas;
                oDetalleCarDTO.GrifoNroVueltasAb = GrifVueltAb;
                oDetalleCarDTO.GrifoSector = GrifSec;
                //Cuerpo 1 Seco ---- 0 Humedo
                oDetalleCarDTO.OtrosCuerpo = seco;
                oDetalleCarDTO.OtrosNroTapas = TapBoc;
                //Situación 1 Operativo ---- 0 Inoperativo
                oDetalleCarDTO.OtrosSituacion = Op;
                oDetalleCarDTO.OtrosUbica = ubica;
                oDetalleCarDTO.OtrosUbicaValvula = ubicaVal;

                //string msj = oDetalleCarBL.ActualizaCaracteristicas(oDetalleCarDTO);


                if (oDetalleCarBL.ActualizaCaracteristicas(oDetalleCarDTO) == eResultado.Correcto)
                {
                    Mensaje("Se guardaron los datos Correctamente.");
                }
                else
                {
                    Mensaje("Error al guardar los datos.");
                }
            }
            
            protected void btnCancelarCarac_Click(object sender, DirectEventArgs e)
            {
                cancelarCaract();
            }

            void cancelarCaract()
            {
                Nvueltas.Text = "";
                rbDer.Checked = false;
                rbIzq.Checked = false;
                NivApert.Text = "";
                cbEstValvul.Text = "";
                marcaCar.Text = "";
                cbDiametro.Text = "";
                txtBocas.Text = "";
                txtMarca.Text = "";
                txtVueltas.Text = "";
                txtSec.Text = "";
                txtVueltasAb.Text = "";
                rbOp.Checked = false;
                rbInop.Checked = false;
                txtNroTapBoc.Text = "";
                rbseco.Checked = true;
                rbHum.Checked = true;
                cbOtrUbica.Text = "";
                cbOtrUbicaVal.Text = "";
            }

            #endregion

            #region otros
            [DirectMethod]
            public void ActualizaDUno(double AltSolBuzon, double PulgIntBuzon, double VolExtSolido, double TirHidFlujo,
            int DiamColector, double AltAguaRet, double AltTotBuzon, string OtrosD1, bool Desmonte, bool Agua)
            {
                //int idOtros = 0;
                DetalleOtrosDTO oDetalleOtrosDTO = new DetalleOtrosDTO();
                DetalleOtrosBL oDetalleOtrosBL = new DetalleOtrosBL();
                DetalleOtrosDTO oDetalleOtrosDTO1 = new DetalleOtrosDTO();
                oDetalleOtrosDTO1 = oDetalleOtrosBL.SelectDetalleOtros(Convert.ToInt32(hdnIdCabecera.Text));
                int id = Convert.ToInt32(HidOtros.Text);
                if (id != 0)
                {
                    oDetalleOtrosDTO.IdOtros = id;
                    oDetalleOtrosDTO.IdCabecera = Convert.ToInt32(hdnIdCabecera.Text);
                    oDetalleOtrosDTO.DUnoAlturaAguaRet = AltAguaRet;
                    oDetalleOtrosDTO.DUnoAlturaSolBuzon = AltSolBuzon;
                    oDetalleOtrosDTO.DUnoAlturaTotalBuzon = AltTotBuzon;
                    oDetalleOtrosDTO.DUnoDiametroColector = DiamColector;
                    oDetalleOtrosDTO.DUnoOtros = OtrosD1;
                    oDetalleOtrosDTO.DUnoPulgIntBuzon = PulgIntBuzon;
                    oDetalleOtrosDTO.DUnoTiranteHidBuzon = TirHidFlujo;
                    oDetalleOtrosDTO.DUnoVolExtSol = VolExtSolido;
                    oDetalleOtrosDTO.ADdvd = oDetalleOtrosDTO1.ADdvd;
                    oDetalleOtrosDTO.Desmonte = Desmonte;
                    oDetalleOtrosDTO.ConAgua = Agua;

                    if (oDetalleOtrosBL.ActualizaDetalleOtros(oDetalleOtrosDTO) == eResultado.Correcto)
                    {
                        Mensaje("Se guardaron los datos Correctamente.");
                        
                    }
                    else
                    {
                        Mensaje("Error al guardar los datos.");
                    }
                }
                else
                {
                    oDetalleOtrosDTO.IdCabecera = Convert.ToInt32(hdnIdCabecera.Text);
                    
                    oDetalleOtrosDTO.IdOtros = id;
                    oDetalleOtrosDTO.DUnoAlturaAguaRet = AltAguaRet;
                    oDetalleOtrosDTO.DUnoAlturaSolBuzon = AltSolBuzon;
                    oDetalleOtrosDTO.DUnoAlturaTotalBuzon = AltTotBuzon;
                    oDetalleOtrosDTO.DUnoDiametroColector = DiamColector;
                    oDetalleOtrosDTO.DUnoOtros = OtrosD1;
                    oDetalleOtrosDTO.DUnoPulgIntBuzon = PulgIntBuzon;
                    oDetalleOtrosDTO.DUnoTiranteHidBuzon = TirHidFlujo;
                    oDetalleOtrosDTO.DUnoVolExtSol = VolExtSolido;
                    oDetalleOtrosDTO.ADdvd = oDetalleOtrosDTO1.ADdvd;
                    oDetalleOtrosDTO.Desmonte = Desmonte;
                    oDetalleOtrosDTO.ConAgua = Agua;

                    if (oDetalleOtrosBL.InsertDetalleOtrosDUno(oDetalleOtrosDTO) == eResultado.Correcto)
                    {
                        Mensaje("Se guardaron los datos Correctamente.");
                        oDetalleOtrosDTO1 = oDetalleOtrosBL.SelectDetalleOtros(Convert.ToInt32(hdnIdCabecera.Text));
                        HidOtros.Text = oDetalleOtrosDTO1.IdOtros + "";
                    }
                    else
                    {
                        Mensaje("Error al guardar los datos.");
                    }
                }
            }

            [DirectMethod]
            public void ActualizaDVD(int ADdvd)
            {
                //int idOtros = 0;
                DetalleOtrosDTO oDetalleOtrosDTO = new DetalleOtrosDTO();
                DetalleOtrosBL oDetalleOtrosBL = new DetalleOtrosBL();
                DetalleOtrosDTO oDetalleOtrosDTO1 = new DetalleOtrosDTO();
                oDetalleOtrosDTO1 = oDetalleOtrosBL.SelectDetalleOtros(Convert.ToInt32(hdnIdCabecera.Text));
                HidOtros.Text = oDetalleOtrosDTO1.IdOtros + "";
                int id = Convert.ToInt32(HidOtros.Text);
                if (id != 0)
                {

                   
                    oDetalleOtrosDTO.IdOtros = id;
                    oDetalleOtrosDTO.IdCabecera = Convert.ToInt32(hdnIdCabecera.Text);
                    oDetalleOtrosDTO.DUnoAlturaAguaRet = oDetalleOtrosDTO1.DUnoAlturaAguaRet;
                    oDetalleOtrosDTO.DUnoAlturaSolBuzon = oDetalleOtrosDTO1.DUnoAlturaSolBuzon;
                    oDetalleOtrosDTO.DUnoAlturaTotalBuzon = oDetalleOtrosDTO1.DUnoAlturaTotalBuzon;
                    oDetalleOtrosDTO.DUnoDiametroColector = oDetalleOtrosDTO1.DUnoDiametroColector;
                    oDetalleOtrosDTO.DUnoOtros = oDetalleOtrosDTO1.DUnoOtros;
                    oDetalleOtrosDTO.DUnoPulgIntBuzon = oDetalleOtrosDTO1.DUnoPulgIntBuzon;
                    oDetalleOtrosDTO.DUnoTiranteHidBuzon = oDetalleOtrosDTO1.DUnoTiranteHidBuzon;
                    oDetalleOtrosDTO.DUnoVolExtSol = oDetalleOtrosDTO1.DUnoVolExtSol;
                    oDetalleOtrosDTO.ADdvd = ADdvd;
                    oDetalleOtrosDTO.Desmonte = oDetalleOtrosDTO1.Desmonte;
                    oDetalleOtrosDTO.ConAgua = oDetalleOtrosDTO1.ConAgua;

                    if (oDetalleOtrosBL.ActualizaDetalleOtros(oDetalleOtrosDTO) == eResultado.Correcto)
                    {
                        Mensaje("Se guardaron los datos Correctamente.");
                    }
                    else
                    {
                        Mensaje("Error al guardar los datos.");
                    }
                }
                else
                {
                    oDetalleOtrosDTO.IdCabecera = Convert.ToInt32(hdnIdCabecera.Text);
                    oDetalleOtrosDTO.IdOtros = id;
                    oDetalleOtrosDTO.DUnoAlturaAguaRet = 0;
                    oDetalleOtrosDTO.DUnoAlturaSolBuzon = 0;
                    oDetalleOtrosDTO.DUnoAlturaTotalBuzon = 0;
                    oDetalleOtrosDTO.DUnoDiametroColector = 0;
                    oDetalleOtrosDTO.DUnoOtros = "";
                    oDetalleOtrosDTO.DUnoPulgIntBuzon = 0;
                    oDetalleOtrosDTO.DUnoTiranteHidBuzon = 0;
                    oDetalleOtrosDTO.DUnoVolExtSol = 0;
                    oDetalleOtrosDTO.ADdvd = ADdvd;
                    oDetalleOtrosDTO.Desmonte = false;
                    oDetalleOtrosDTO.ConAgua = false;

                    if (oDetalleOtrosBL.InsertDetalleOtrosDUno(oDetalleOtrosDTO) == eResultado.Correcto)
                    {
                        Mensaje("Se guardaron los datos Correctamente.");
                        oDetalleOtrosDTO1 = oDetalleOtrosBL.SelectDetalleOtros(Convert.ToInt32(hdnIdCabecera.Text));
                        HidOtros.Text = oDetalleOtrosDTO1.IdOtros+"";
                    }
                    else
                    {
                        Mensaje("Error al guardar los datos.");
                    }
                }
            }
            #endregion

            protected void BuscarPorSGIO(object sender, DirectEventArgs e)
            {
                if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    if (string.IsNullOrEmpty(this.txtPSGIO.Text))
                        this.Mensaje("INGRESE NÚMERO DE PARTE DE TRABAJO.");
                    else
                    {

                        List<CuadrillaDTO> olCuad = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                        if (olCuad != null)
                        {
                            this.StoreCuadrilla.DataSource = olCuad;
                            this.StoreCuadrilla.DataBind();

                            this.StoreTCCuadrilla.DataSource = olCuad;
                            this.StoreTCCuadrilla.DataBind();
                        }

                        List<CabeceraDTO> olCabeceras = new ConsumoMaterialBL().ObtenerCabeceraConsumo(Convert.ToInt32(this.ddlObra.SelectedItem.Value), "0", this.txtPSGIO.Text,0,Usuario.IdUsuario);
                        if (olCabeceras.Count == 1)
                        {
                            this.LimpiarControles();
                            CabeceraDTO oCabecera = new CabeceraDTO();
                            oCabecera = olCabeceras[0];
                            this.hdnIdCabecera.Text = oCabecera.IdCabecera.ToString();
                            this.txtPOrden.Text = oCabecera.NumeroOrden;
                            this.txtPSGIO.Text = oCabecera.Sgi;
                            this.txtPNIS.Text = oCabecera.Suministro;
                            this.txtPFecOrden.Text = oCabecera.FechaOrden;
                            this.txtPFecProg.Text = oCabecera.FechaProgramacion;
                            this.txtPFecIni.Text = oCabecera.FechaInicio;
                            this.txtPHorIni.Text = oCabecera.HoraInicio;
                            this.txtPFecFin.Text = oCabecera.FechaTermino;
                            this.txtPHorFin.Text = oCabecera.Horatermino;
                            this.txtObservacion.Text = oCabecera.Observacion;

                            this.ddlDistrito.SelectedItem.Value = oCabecera.Distrito.IdDistrito.ToString();
                            if (oCabecera.Cuadrilla.IdCuadrilla > 0)
                                this.ddlPCuadrilla.SelectedItem.Value = oCabecera.Cuadrilla.IdCuadrilla.ToString();
                            if (oCabecera.EstadoOT.IdEstadoOT > 0)
                            {
                                if (oCabecera.EstadoOT.DescripcionEstado == "FACTURADO")
                                    this.ddlPEstado.SelectedItem.Text = "FACTURADO";
                                else
                                    this.ddlPEstado.SelectedItem.Value = oCabecera.EstadoOT.IdEstadoOT.ToString();
                            }


                            EjecucionOTDTO tmpotplani = new EjecucionOTBL().GetEjecucionOTPorNroRegistro(Convert.ToInt32(this.txtPOrden.Text));


                            if (tmpotplani.EstadoOT!=null)
                            {
                                if (tmpotplani.EstadoOT.IdEstadoOT > 0)
                                    this.ddlPEstadoRO.SelectedItem.Value = tmpotplani.EstadoOT.IdEstadoOT.ToString();
                                //    this.ddlPEstadoRO.SelectedItem.Value = oCabecera.EstadoOTRO.IdEstadoOT.ToString();
                            }    


                            this.txtPDireccion.Text = oCabecera.Direccion;
                            this.txtPCliente.Text = oCabecera.Cliente;
                            this.txtPUrbanizacion.Text = oCabecera.Urbanizacion;
                            this.ddlPActividad.SelectedItem.Value = oCabecera.Actividad.IdActividad.ToString();
                            this.txtHorTrab.Text = oCabecera.HorasTrabajadas.ToString();
                            this.txtNroTrab.Text = oCabecera.NumeroTrabajadores.ToString();
                            this.txtPCorrelativo.Text = oCabecera.NroRegistro.ToString();
                            this.TextTotalSGIO.Text = oCabecera.CostoOPEN.ToString();
                            this.txtPNroCargo.Text = oCabecera.NroCargo;
                            this.CargarDetallesConsumo(oCabecera.IdCabecera);
                            this.hdnTipoAccion.Text = "1";
                            if (oCabecera.EstadoOT.DescripcionEstado == "RESUELTO")
                            {
                                this.DesactivarControles(true);
                                this.GridPanel1.Disabled = true;
                            }
                            else
                            {
                                this.DesactivarControles(false);
                                this.GridPanel1.Disabled = false;
                            }

                            #region ACTD - Bryan
                            if (Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 72 || Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 80)
                            {
                                #region Bryan
                                btnGuarda.Disabled = false;
                                btnGuardar.Disabled = false;
                                Button1.Disabled = false;
                                Button3.Disabled = false;
                                Button4.Disabled = false;
                                Button5.Disabled = false;
                                this.Panel5.Disabled = false;
                                this.Panel6.Disabled = false;
                                this.Panel7.Disabled = false;

                                List<DetalleBuzonDTO> oDetalleBuz = new List<DetalleBuzonDTO>();
                                DetalleBuzonBL BuzonBL = new DetalleBuzonBL();
                                oDetalleBuz = BuzonBL.ConsultaBuzon(Convert.ToInt32(hdnIdCabecera.Text));
                                #region Buzon
                                if (oDetalleBuz.Count == 0)
                                {

                                    if (BuzonBL.InsertDetalleBuzonVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetalleBuz = BuzonBL.ConsultaBuzon(Convert.ToInt32(hdnIdCabecera.Text));
                                        storeBuzonxSGI.DataSource = oDetalleBuz;
                                        storeBuzonxSGI.DataBind();
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Buzón Vacío");
                                    }
                                }
                                else
                                {
                                    storeBuzonxSGI.DataSource = oDetalleBuz;
                                    storeBuzonxSGI.DataBind();
                                }
                                #endregion
                                #region Limpieza
                                List<DetalleLimpiezaDTO> oDetalleLimpiezaDTO = new List<DetalleLimpiezaDTO>();
                                DetalleLimpiezaBL oDetalleLimpiezaBL = new DetalleLimpiezaBL();
                                oDetalleLimpiezaDTO = oDetalleLimpiezaBL.ConsultaLimpieza(Convert.ToInt32(hdnIdCabecera.Text));
                                string horaInicio = "";
                                string horaFin = "";
                                if (oDetalleLimpiezaDTO.Count == 0)
                                {
                                    if (oDetalleLimpiezaBL.InsertLimpiezaVacio(Convert.ToInt32(hdnIdCabecera.Text))==eResultado.Correcto)
                                    {
                                        oDetalleLimpiezaDTO = oDetalleLimpiezaBL.ConsultaLimpieza(Convert.ToInt32(hdnIdCabecera.Text));
                                        foreach (DetalleLimpiezaDTO o in oDetalleLimpiezaDTO)
                                        {
                                            longitud.Text = o.longitud + "";
                                            VolExtraido.Text = o.volumenExtraido + "";
                                            Diametro.Text = o.diametro + "";
                                            dfFechaEj.Text = o.fecha;
                                            horaInicio = o.horaInicio;

                                            string h, m, hf, mf = "";
                                            int i = horaInicio.LastIndexOf(":");
                                            if (i == 2 && (horaInicio.Length == 5))
                                            {
                                                h = horaInicio.Substring(0, 2);
                                                m = horaInicio.Substring(3, 2);
                                                horaI1.Text = h;
                                                minutoI1.Text = m;
                                            }
                                            if (i == 1 && (horaInicio.Length == 4))
                                            {
                                                h = horaInicio.Substring(0, 1);
                                                m = horaInicio.Substring(2, 2);
                                                horaI1.Text = h;
                                                minutoI1.Text = m;
                                            }
                                            if (i == 2 && (horaInicio.Length == 4))
                                            {
                                                h = horaInicio.Substring(0, 2);
                                                m = horaInicio.Substring(3);
                                                horaI1.Text = h;
                                                minutoI1.Text = m;
                                            }
                                            if (i == 1 && (horaInicio.Length == 3))
                                            {
                                                h = horaInicio.Substring(0, 1);
                                                m = horaInicio.Substring(2);
                                                horaI1.Text = (h);
                                                minutoI1.Text = m;
                                            }

                                            horaFin = o.horaFin;
                                            int j = horaFin.LastIndexOf(":");
                                            if (j == 2 && (horaFin.Length == 5))
                                            {
                                                hf = horaFin.Substring(0, 2);
                                                mf = horaFin.Substring(3, 2);
                                                horaF1.Text = hf;
                                                minutoF1.Text = mf;
                                            }
                                            if (j == 1 && (horaFin.Length == 4))
                                            {
                                                hf = horaFin.Substring(0, 1);
                                                mf = horaFin.Substring(2, 2);
                                                horaF1.Text = hf;
                                                minutoF1.Text = mf;
                                            }
                                            if (j == 2 && (horaFin.Length == 4))
                                            {
                                                hf = horaFin.Substring(0, 2);
                                                mf = horaFin.Substring(3);
                                                horaF1.Text = hf;
                                                minutoF1.Text = mf;
                                            }
                                            if (j == 1 && (horaFin.Length == 3))
                                            {
                                                hf = horaFin.Substring(0, 1);
                                                mf = horaFin.Substring(2);
                                                horaF1.Text = (hf);
                                                minutoF1.Text = mf;
                                            }

                                            if (o.idCuadrilla == 1)
                                            {
                                                cbCuadrilla.SelectedItem.Value = "";
                                            }
                                            else
                                            {
                                                cbCuadrilla.SelectedItem.Value = o.idCuadrilla.ToString();
                                            }
                                            cbMatTubo.SelectedItem.Value = o.materialTubo;
                                            Tirante.Text = o.tiranteFlujo + "";
                                            ckArena.Checked = o.arena;
                                            ckCascajos.Checked = o.cascajo;
                                            ckPiedra.Checked = o.piedra;
                                            ckOtros.Checked = o.otros;
                                            txtotros.Text = o.otrosDesc;
                                        }
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Limpieza Vacío");
                                    }
                                   
                                }
                                else
                                {

                                    foreach (DetalleLimpiezaDTO o in oDetalleLimpiezaDTO)
                                    {
                                        longitud.Text = o.longitud + "";
                                        VolExtraido.Text = o.volumenExtraido + "";
                                        Diametro.Text = o.diametro + "";
                                        dfFechaEj.Text = o.fecha;
                                        horaInicio = o.horaInicio;

                                        string h, m, hf, mf = "";
                                        int i = horaInicio.LastIndexOf(":");
                                        if (i == 2 && (horaInicio.Length == 5))
                                        {
                                            h = horaInicio.Substring(0, 2);
                                            m = horaInicio.Substring(3, 2);
                                            horaI1.Text = h;
                                            minutoI1.Text = m;
                                        }
                                        if (i == 1 && (horaInicio.Length == 4))
                                        {
                                            h = horaInicio.Substring(0, 1);
                                            m = horaInicio.Substring(2, 2);
                                            horaI1.Text = h;
                                            minutoI1.Text = m;
                                        }
                                        if (i == 2 && (horaInicio.Length == 4))
                                        {
                                            h = horaInicio.Substring(0, 2);
                                            m = horaInicio.Substring(3);
                                            horaI1.Text = h;
                                            minutoI1.Text = m;
                                        }
                                        if (i == 1 && (horaInicio.Length == 3))
                                        {
                                            h = horaInicio.Substring(0, 1);
                                            m = horaInicio.Substring(2);
                                            horaI1.Text = (h);
                                            minutoI1.Text = m;
                                        }

                                        horaFin = o.horaFin;
                                        int j = horaFin.LastIndexOf(":");
                                        if (j == 2 && (horaFin.Length == 5))
                                        {
                                            hf = horaFin.Substring(0, 2);
                                            mf = horaFin.Substring(3, 2);
                                            horaF1.Text = hf;
                                            minutoF1.Text = mf;
                                        }
                                        if (j == 1 && (horaFin.Length == 4))
                                        {
                                            hf = horaFin.Substring(0, 1);
                                            mf = horaFin.Substring(2, 2);
                                            horaF1.Text = hf;
                                            minutoF1.Text = mf;
                                        }
                                        if (j == 2 && (horaFin.Length == 4))
                                        {
                                            hf = horaFin.Substring(0, 2);
                                            mf = horaFin.Substring(3);
                                            horaF1.Text = hf;
                                            minutoF1.Text = mf;
                                        }
                                        if (j == 1 && (horaFin.Length == 3))
                                        {
                                            hf = horaFin.Substring(0, 1);
                                            mf = horaFin.Substring(2);
                                            horaF1.Text = (hf);
                                            minutoF1.Text = mf;
                                        }

                                        if (o.idCuadrilla == 1)
                                        {
                                            cbCuadrilla.SelectedItem.Value = "";
                                        }
                                        else
                                        {
                                            cbCuadrilla.SelectedItem.Value = o.idCuadrilla.ToString();
                                        }
                                        cbMatTubo.SelectedItem.Value = o.materialTubo;
                                        Tirante.Text = o.tiranteFlujo + "";
                                        ckArena.Checked = o.arena;
                                        ckCascajos.Checked = o.cascajo;
                                        ckPiedra.Checked = o.piedra;
                                        ckOtros.Checked = o.otros;
                                        txtotros.Text = o.otrosDesc;
                                    }
                                }
                                #endregion
                                #region Inspeccion
                                List<DetalleInspeccionDTO> oDetalleInspeccionDTO = new List<DetalleInspeccionDTO>();
                                DetalleInspeccionBL oDetalleInspecionBL = new DetalleInspeccionBL();
                                oDetalleInspeccionDTO = oDetalleInspecionBL.ConsultaInspeccion(Convert.ToInt32(hdnIdCabecera.Text));
                                //this.StoreLlenarCajasLimpieza.DataSource = oDetalleLimpiezaDTO;
                                //StoreLlenarCajasLimpieza.DataBind();
                                if (oDetalleInspeccionDTO.Count == 0)
                                {
                                    if (oDetalleInspecionBL.InsertInspeccionVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetalleInspeccionDTO = oDetalleInspecionBL.ConsultaInspeccion(Convert.ToInt32(hdnIdCabecera.Text));
                                        foreach (DetalleInspeccionDTO o in oDetalleInspeccionDTO)
                                        {

                                            cbEstado.SelectedItem.Value = o.estado;
                                            cbCuadrillaInsp.SelectedItem.Value = o.idCuadrilla.ToString();
                                            horaInicio = o.horaInicio;
                                            string h, m, hfi, mfi = "";
                                            int i = horaInicio.LastIndexOf(":");
                                            if (i == 2 && (horaInicio.Length == 5))
                                            {
                                                h = horaInicio.Substring(0, 2);
                                                m = horaInicio.Substring(3, 2);
                                                hi1.Text = h;
                                                mi1.Text = m;
                                            }
                                            if (i == 1 && (horaInicio.Length == 4))
                                            {
                                                h = horaInicio.Substring(0, 1);
                                                m = horaInicio.Substring(2, 2);
                                                hi1.Text = h;
                                                mi1.Text = m;
                                            }
                                            if (i == 2 && (horaInicio.Length == 4))
                                            {
                                                h = horaInicio.Substring(0, 2);
                                                m = horaInicio.Substring(3);
                                                hi1.Text = h;
                                                mi1.Text = m;
                                            }
                                            if (i == 1 && (horaInicio.Length == 3))
                                            {
                                                h = horaInicio.Substring(0, 1);
                                                m = horaInicio.Substring(2);
                                                hi1.Text = (h);
                                                mi1.Text = m;
                                            }

                                            horaFin = o.horaFin;
                                            int j = horaFin.LastIndexOf(":");
                                            if (j == 2 && (horaFin.Length == 5))
                                            {
                                                hfi = horaFin.Substring(0, 2);
                                                mfi = horaFin.Substring(3, 2);
                                                hf1.Text = hfi;
                                                mf1.Text = mfi;
                                            }
                                            if (j == 1 && (horaFin.Length == 4))
                                            {
                                                hfi = horaFin.Substring(0, 1);
                                                mfi = horaFin.Substring(2, 2);
                                                hf1.Text = hfi;
                                                mf1.Text = mfi;
                                            }
                                            if (j == 2 && (horaFin.Length == 4))
                                            {
                                                hfi = horaFin.Substring(0, 2);
                                                mfi = horaFin.Substring(3);
                                                hf1.Text = hfi;
                                                mf1.Text = mfi;
                                            }
                                            if (j == 1 && (horaFin.Length == 3))
                                            {
                                                hfi = horaFin.Substring(0, 1);
                                                mfi = horaFin.Substring(2);
                                                hf1.Text = (hfi);
                                                mf1.Text = mfi;
                                            }
                                            dfFecha.Text = o.fecha;

                                        }
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Inspeccion Televisada Vacía");
                                    }
                                   
                                }
                                else
                                {
                                    foreach (DetalleInspeccionDTO o in oDetalleInspeccionDTO)
                                    {

                                        cbEstado.SelectedItem.Value = o.estado;
                                        cbCuadrillaInsp.SelectedItem.Value = o.idCuadrilla.ToString(); ;
                                        horaInicio = o.horaInicio;
                                        string h, m, hfi, mfi = "";
                                        int i = horaInicio.LastIndexOf(":");
                                        if (i == 2 && (horaInicio.Length == 5))
                                        {
                                            h = horaInicio.Substring(0, 2);
                                            m = horaInicio.Substring(3, 2);
                                            hi1.Text = h;
                                            mi1.Text = m;
                                        }
                                        if (i == 1 && (horaInicio.Length == 4))
                                        {
                                            h = horaInicio.Substring(0, 1);
                                            m = horaInicio.Substring(2, 2);
                                            hi1.Text = h;
                                            mi1.Text = m;
                                        }
                                        if (i == 2 && (horaInicio.Length == 4))
                                        {
                                            h = horaInicio.Substring(0, 2);
                                            m = horaInicio.Substring(3);
                                            hi1.Text = h;
                                            mi1.Text = m;
                                        }
                                        if (i == 1 && (horaInicio.Length == 3))
                                        {
                                            h = horaInicio.Substring(0, 1);
                                            m = horaInicio.Substring(2);
                                            hi1.Text = (h);
                                            mi1.Text = m;
                                        }

                                        horaFin = o.horaFin;
                                        int j = horaFin.LastIndexOf(":");
                                        if (j == 2 && (horaFin.Length == 5))
                                        {
                                            hfi = horaFin.Substring(0, 2);
                                            mfi = horaFin.Substring(3, 2);
                                            hf1.Text = hfi;
                                            mf1.Text = mfi;
                                        }
                                        if (j == 1 && (horaFin.Length == 4))
                                        {
                                            hfi = horaFin.Substring(0, 1);
                                            mfi = horaFin.Substring(2, 2);
                                            hf1.Text = hfi;
                                            mf1.Text = mfi;
                                        }
                                        if (j == 2 && (horaFin.Length == 4))
                                        {
                                            hfi = horaFin.Substring(0, 2);
                                            mfi = horaFin.Substring(3);
                                            hf1.Text = hfi;
                                            mf1.Text = mfi;
                                        }
                                        if (j == 1 && (horaFin.Length == 3))
                                        {
                                            hfi = horaFin.Substring(0, 1);
                                            mfi = horaFin.Substring(2);
                                            hf1.Text = (hfi);
                                            mf1.Text = mfi;
                                        }
                                        dfFecha.Text = o.fecha;

                                    }
                                }

                                #endregion
                                #region Conexion
                                List<DetalleConexionesDTO> oDetalleCon = new List<DetalleConexionesDTO>();
                                DetalleConexionesBL ConexionBL = new DetalleConexionesBL();
                                oDetalleCon = ConexionBL.ConsultaConexiones(Convert.ToInt32(hdnIdCabecera.Text));
                                if (oDetalleCon.Count == 0)
                                {
                                    if (ConexionBL.InsertDetalleConexionesVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetalleCon = ConexionBL.ConsultaConexiones(Convert.ToInt32(hdnIdCabecera.Text));
                                        storeConexiones.DataSource = oDetalleCon;
                                        storeConexiones.DataBind();
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Conexiones Vacío");
                                    }
                                }
                                else
                                {
                                    storeConexiones.DataSource = oDetalleCon;
                                    storeConexiones.DataBind();
                                }
                                #endregion
                                #region Deficiencias
                                List<DetalleDeficienciasDTO> oDetalleDef = new List<DetalleDeficienciasDTO>();
                                DetalleDeficienciasBL DeficienciasBL = new DetalleDeficienciasBL();
                                oDetalleDef = DeficienciasBL.ConsultaDeficiencias(Convert.ToInt32(hdnIdCabecera.Text));
                                if (oDetalleDef.Count == 0)
                                {
                                    if (DeficienciasBL.InsertDeficienciasVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetalleDef = DeficienciasBL.ConsultaDeficiencias(Convert.ToInt32(hdnIdCabecera.Text));
                                        this.storeDeficiencias.DataSource = oDetalleDef;
                                        storeDeficiencias.DataBind();
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Deficiencias Vacio");
                                    }
                                }
                                else
                                {
                                    this.storeDeficiencias.DataSource = oDetalleDef;
                                    storeDeficiencias.DataBind();
                                }
                                #endregion
 
                                #endregion

                            }
                            else
                            {
                                this.Panel5.Disabled = true;
                                this.Panel6.Disabled = true;
                                this.Panel7.Disabled = true;
                                List<DetalleDeficienciasDTO> d = new List<DetalleDeficienciasDTO>();
                                List<DetalleBuzonDTO> b = new List<DetalleBuzonDTO>();
                                List<DetalleConexionesDTO> c = new List<DetalleConexionesDTO>();
                                btnGuarda.Disabled = true;
                                btnGuardar.Disabled = true;
                                Button1.Disabled = true;
                                Button3.Disabled = true;
                                Button4.Disabled = true;
                                Button5.Disabled = true;
                                storeBuzonxSGI.DataSource = b;
                                storeBuzonxSGI.DataBind();
                                longitud.Text = "0";
                                VolExtraido.Text = "0";
                                Diametro.Text = "0";
                                dfFechaEj.Text = "";
                                horaI1.Text = "00";
                                minutoI1.Text = "00";
                                horaF1.Text = "00";
                                minutoF1.Text = "00";
                                cbCuadrilla.SelectedItem.Value = "";
                                cbMatTubo.SelectedItem.Value = "";
                                Tirante.Text = "0";
                                ckArena.Checked = false;
                                ckCascajos.Checked = false;
                                ckPiedra.Checked = false;
                                ckOtros.Checked = false;
                                txtotros.Text = "";
                                cbEstado.SelectedItem.Value = "";
                                cbCuadrillaInsp.SelectedItem.Value = "";
                                hf1.Text = "00";
                                mf1.Text = "00";
                                hi1.Text = "00";
                                mi1.Text = "00";
                                dfFecha.Text = "";
                                storeConexiones.DataSource = c;
                                storeConexiones.DataBind();
                                this.storeDeficiencias.DataSource = d;
                                storeDeficiencias.DataBind();
                            }
                            #endregion
                            #region Act A - Bryan
                            if (Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 69 || Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 77)
                            {   
                                #region purga
                                //btnGuardarPurga.Disabled = false;
                                this.Panel8.Disabled = false;
                                List<DetallePurgaDTO> oDetallePurgaDTO = new List<DetallePurgaDTO>();
                                DetallePurgaBL oDetallePurgaBL = new DetallePurgaBL();
                                oDetallePurgaDTO = oDetallePurgaBL.ConsultaPurga(Convert.ToInt32(hdnIdCabecera.Text));
                               
                                if (oDetallePurgaDTO.Count == 0)
                                {
                                    if (oDetallePurgaBL.InsertPurgaVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetallePurgaDTO = oDetallePurgaBL.ConsultaPurga(Convert.ToInt32(hdnIdCabecera.Text));
                                        foreach (DetallePurgaDTO o in oDetallePurgaDTO)
                                        {
                                            Sector.Text = o.sector + "";
                                            Cloro.Text = o.cloro + "";
                                            Tpurga.Text = o.tiempoPurga + "";
                                            Presion.Text = o.presion + "";
                                            cbCaractAgua.Text = o.caracteristicaAgua + "";

                                            nroBocas.Text = o.nroBocas + "";
                                            if (o.opPrevMenor == true)
                                            {
                                                Countries.Text = "Operativo";
                                                Cities.Text = "Prev. Menor";
                                                List<object> data = new List<object>();
                                                data.Add(new { Id = 2, Name = "Prev. Menor" });
                                                this.CitiesStore.DataSource = data;
                                                this.CitiesStore.DataBind();
                                            }
                                            if (o.opPrevMayor == true)
                                            {
                                                Countries.Text = "Operativo";
                                                Cities.Text = "Prev. Mayor";
                                                List<object> data = new List<object>();
                                                data.Add(new { Id = 1, Name = "Prev. Mayor" });
                                                this.CitiesStore.DataSource = data;
                                                this.CitiesStore.DataBind();
                                            }
                                            if (o.InopCambio == true)
                                            {
                                                Countries.Text = "Inoperativo";
                                                Cities.Text = "Cambio";
                                                List<object> data = new List<object>();
                                                data.Add(new { Id = 4, Name = "Cambio" });
                                                this.CitiesStore.DataSource = data;
                                                this.CitiesStore.DataBind();
                                            }
                                            if (o.InopCorrectivo == true)
                                            {
                                                Countries.Text = "Inoperativo";
                                                Cities.Text = "Correctivo";
                                                List<object> data = new List<object>();
                                                data.Add(new { Id = 3, Name = "Correctivo" });
                                                this.CitiesStore.DataSource = data;

                                                this.CitiesStore.DataBind();
                                            }

                                            nroTapas.Text = o.nroTapas + "";
                                            marca.Text = o.marca + "";
                                            cbCGI.Text = o.CGI + "";
                                            ckUbica.Checked = o.ubica;
                                            ckMyT.Checked = o.sinMyT;
                                            ckLosa.Checked = o.losaDeteriorada;
                                            this.rbsi.Checked = o.mantenimiento;
                                            rbno.Checked = o.mantenimiento;
                                            ANF.Text = o.ANF + "";
                                            taObs.Text = o.observacion;
                                            cbColorAgua.Text = o.colorAgua + "";
                                            cbDescarga.Text = o.descargaEn + "";
                                            Distancia.Text = o.distanciaDescarga + "";
                                        }
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Purga Vacío");
                                    }
                                    
                                }
                                
                                else
                                {

                                    foreach (DetallePurgaDTO o in oDetallePurgaDTO)
                                    {
                                        Sector.Text = o.sector + "";
                                        Cloro.Text = o.cloro + "";
                                        Tpurga.Text = o.tiempoPurga + "";
                                        Presion.Text = o.presion + "";
                                        cbCaractAgua.Text = o.caracteristicaAgua + "";

                                        nroBocas.Text = o.nroBocas + "";
                                        if (o.opPrevMenor == true)
                                        {
                                            Countries.Text = "Operativo";
                                            Cities.Text = "Prev. Menor";
                                            List<object> data = new List<object>();
                                            data.Add(new { Id = 2, Name = "Prev. Menor" });
                                            this.CitiesStore.DataSource = data;

                                            this.CitiesStore.DataBind();
                                        }
                                        if (o.opPrevMayor == true)
                                        {
                                            Countries.Text = "Operativo";
                                            Cities.Text = "Prev. Mayor";
                                            List<object> data = new List<object>();
                                            data.Add(new { Id = 1, Name = "Prev. Mayor" });
                                            this.CitiesStore.DataSource = data;

                                            this.CitiesStore.DataBind();
                                        }
                                        if (o.InopCambio == true)
                                        {
                                            Countries.Text = "Inoperativo";
                                            Cities.Text = "Cambio";
                                            List<object> data = new List<object>();
                                            data.Add(new { Id = 4, Name = "Cambio" });
                                            this.CitiesStore.DataSource = data;

                                            this.CitiesStore.DataBind();
                                        }
                                        if (o.InopCorrectivo == true)
                                        {
                                            Countries.Text = "Inoperativo";
                                            Cities.Text = "Correctivo";
                                            List<object> data = new List<object>();
                                            data.Add(new { Id = 3, Name = "Correctivo" });
                                            this.CitiesStore.DataSource = data;

                                            this.CitiesStore.DataBind();
                                        }

                                        nroTapas.Text = o.nroTapas + "";
                                        marca.Text = o.marca + "";
                                        cbCGI.Text = o.CGI + "";
                                        ckUbica.Checked = o.ubica;
                                        ckMyT.Checked = o.sinMyT;
                                        ckLosa.Checked = o.losaDeteriorada;
                                        this.rbsi.Checked = o.mantenimiento;
                                        rbno.Checked = o.mantenimiento;
                                        ANF.Text = o.ANF + "";
                                        taObs.Text = o.observacion;
                                        cbColorAgua.Text = o.colorAgua + "";
                                        cbDescarga.Text = o.descargaEn + "";
                                        Distancia.Text = o.distanciaDescarga + "";
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                               // btnGuardarPurga.Disabled = true;
                                this.Panel8.Disabled = true;
                                cancelarPurga();
                            }
                            #endregion
                            #region ACT B - Bryan
                            if (Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 70 || Convert.ToInt32(ddlPActividad.SelectedItem.Value) == 78)
                            {
                                #region Caracteristicas
                                //btnGuardarPurga.Disabled = false;
                                this.Panel9.Disabled = false;
                                List<DetalleCaracteristicasDTO> oDetalleCarDTO = new List<DetalleCaracteristicasDTO>();
                                DetalleCaracteristicasBL oDetalleCarBL = new DetalleCaracteristicasBL();
                                oDetalleCarDTO = oDetalleCarBL.SelectCaracteristicas(Convert.ToInt32(hdnIdCabecera.Text));

                                if (oDetalleCarDTO.Count == 0)
                                {
                                    if (oDetalleCarBL.InsertDetalleCaracteristicasVacio(Convert.ToInt32(hdnIdCabecera.Text)) == eResultado.Correcto)
                                    {
                                        oDetalleCarDTO = oDetalleCarBL.SelectCaracteristicas(Convert.ToInt32(hdnIdCabecera.Text));
                                        foreach (DetalleCaracteristicasDTO o in oDetalleCarDTO)
                                        {
                                            Nvueltas.Text = o.ValNroVueltas + "";
                                            //Valvula
                                            //1 DErecha
                                            //0 Izquierda
                                            if (o.ValIzqDer == true)
                                            {
                                                rbDer.Checked = true;
                                            }
                                            else
                                            { rbIzq.Checked = true; }

                                            NivApert.Text = o.ValNivelAp + "";
                                            cbEstValvul.Text = o.ValEstado;
                                            marcaCar.Text = o.ValMarca;
                                            cbDiametro.Text = o.GrifoDiametro;
                                            txtBocas.Text = o.GrifoNroBocas + "";
                                            txtMarca.Text = o.GrifoMarca + "";
                                            txtVueltas.Text = o.GrifoNroVueltas + "";
                                            txtSec.Text = o.GrifoSector + "";
                                            txtVueltasAb.Text = o.GrifoNroVueltasAb + "";

                                            //Situación
                                            //1 Operativo
                                            //0 Inoperativo

                                            if (o.OtrosSituacion == true)
                                            {
                                                rbOp.Checked = true;
                                            }
                                            else
                                            {
                                                rbInop.Checked = true;
                                            }

                                            txtNroTapBoc.Text = o.OtrosNroTapas + "";

                                            //Cuerpo
                                            //1 Seco
                                            //0 Humedo

                                            if (o.OtrosCuerpo == true)
                                            {
                                                rbseco.Checked = true;
                                            }
                                            else
                                            {
                                                rbHum.Checked = true;
                                            }

                                            cbOtrUbica.Text = o.OtrosUbica;
                                            cbOtrUbicaVal.Text = o.OtrosUbicaValvula;
                                        }
                                    }
                                    else
                                    {
                                        Mensaje("No se pudo Insertar Caracteristicas VACIO");
                                    }
                                }

                                else
                                {
                                    foreach (DetalleCaracteristicasDTO o in oDetalleCarDTO)
                                    {
                                        Nvueltas.Text = o.ValNroVueltas + "";
                                        //Valvula
                                        //1 DErecha
                                        //0 Izquierda
                                        if (o.ValIzqDer == true)
                                        {
                                            rbDer.Checked = true;
                                        }
                                        else
                                        { rbIzq.Checked = true; }

                                        NivApert.Text = o.ValNivelAp + "";
                                        cbEstValvul.Text = o.ValEstado;
                                        marcaCar.Text = o.ValMarca;
                                        cbDiametro.Text = o.GrifoDiametro;
                                        txtBocas.Text = o.GrifoNroBocas + "";
                                        txtMarca.Text = o.GrifoMarca + "";
                                        txtVueltas.Text = o.GrifoNroVueltas + "";
                                        txtSec.Text = o.GrifoSector + "";
                                        txtVueltasAb.Text = o.GrifoNroVueltasAb + "";

                                        //Situación
                                        //1 Operativo
                                        //0 Inoperativo
                                        if (o.OtrosSituacion == true)
                                        {
                                            rbOp.Checked = true;
                                        }
                                        else
                                        {
                                            rbInop.Checked = true;
                                        }
                                        txtNroTapBoc.Text = o.OtrosNroTapas + "";

                                        //Cuerpo
                                        //1 Seco
                                        //0 Humedo
                                        if (o.OtrosCuerpo == true)
                                        {
                                            rbseco.Checked = true;
                                        }
                                        else
                                        {
                                            rbHum.Checked = true;
                                        }

                                        cbOtrUbica.Text = o.OtrosUbica;
                                        cbOtrUbicaVal.Text = o.OtrosUbicaValvula;
                                    }

                                }
                                #endregion
                            }
                            else
                            {
                                this.Panel9.Disabled = true;
                                cancelarCaract();
                                
                            }
                            #endregion

                            #region ACT - OTROS bryan
                            #region DUno
                           
                            DetalleOtrosDTO oDetalleOtDTO = new DetalleOtrosDTO();
                            DetalleOtrosBL oDetalleOtBL = new DetalleOtrosBL();
                            oDetalleOtDTO = oDetalleOtBL.SelectDetalleOtros(Convert.ToInt32(hdnIdCabecera.Text));
                            txtAltSolBuzon.Text = oDetalleOtDTO.DUnoAlturaSolBuzon + "";
                            PulgIntBuzon.Text = oDetalleOtDTO.DUnoPulgIntBuzon + "";
                            txtVolExtSolido.Text = oDetalleOtDTO.DUnoVolExtSol + "";
                            txtTirHidFlujo.Text = oDetalleOtDTO.DUnoTiranteHidBuzon + "";
                            txtDiamColector.Text = oDetalleOtDTO.DUnoDiametroColector + "";
                            txtAltAguaRet.Text = oDetalleOtDTO.DUnoAlturaAguaRet + "";
                            txtAltTotBuzon.Text = oDetalleOtDTO.DUnoAlturaTotalBuzon + "";
                            taOtrosD1.Text = oDetalleOtDTO.DUnoOtros;
                            HidOtros.Text = oDetalleOtDTO.IdOtros+"";
                            txtDVD.Text = oDetalleOtDTO.ADdvd + "";
                            if (oDetalleOtDTO.Desmonte == true)
                            {
                                RbDesmontSi.Checked = true;
                            }
                            else RbDesmontNo.Checked = true;
                            if (oDetalleOtDTO.ConAgua == true)
                            {
                                RbAguaSi.Checked = true;
                            }
                            else RbAguaNo.Checked = true;

                            #endregion
                            #endregion
                        }
                        else
                        {
                            this.Mensaje("EL SGI INGRESADO NO EXISTE!.");
                        }
                    }
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA!.");
            }

            protected void BuscarPorCorrelativo(object sender, DirectEventArgs e)
            {
                if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    if (string.IsNullOrEmpty(this.txtPCorrelativo.Text))
                        this.Mensaje("INGRESE NÚMERO DE CORRELATIVO.");
                    else
                    {

                        List<CuadrillaDTO> olCuad = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                        if (olCuad != null)
                        {
                            this.StoreCuadrilla.DataSource = olCuad;
                            this.StoreCuadrilla.DataBind();

                            this.StoreTCCuadrilla.DataSource = olCuad;
                            this.StoreTCCuadrilla.DataBind();
                        }

                        List<CabeceraDTO> olCabeceras = new ConsumoMaterialBL().ObtenerCabeceraConsumo(Convert.ToInt32(this.ddlObra.SelectedItem.Value), "0", "0", Convert.ToInt32(this.txtPCorrelativo.Text),Usuario.IdUsuario);
                        if (olCabeceras.Count == 1)
                        {
                            this.LimpiarControles();
                            CabeceraDTO oCabecera = new CabeceraDTO();
                            oCabecera = olCabeceras[0];
                            this.hdnIdCabecera.Text = oCabecera.IdCabecera.ToString();
                            this.txtPOrden.Text = oCabecera.NumeroOrden;
                            this.txtPSGIO.Text = oCabecera.Sgi;
                            this.txtObservacion.Text = oCabecera.Observacion;
                            

                            this.txtPNIS.Text = oCabecera.Suministro;
                            this.txtPFecOrden.Text = oCabecera.FechaOrden;
                            this.txtPFecProg.Text = oCabecera.FechaProgramacion;
                            this.txtPFecIni.Text = oCabecera.FechaInicio;
                            this.txtPHorIni.Text = oCabecera.HoraInicio;
                            this.txtPFecFin.Text = oCabecera.FechaTermino;
                            this.txtPHorFin.Text = oCabecera.Horatermino;
                            this.ddlDistrito.SelectedItem.Value = oCabecera.Distrito.IdDistrito.ToString();
                            if (oCabecera.Cuadrilla.IdCuadrilla > 0)
                                this.ddlPCuadrilla.SelectedItem.Value = oCabecera.Cuadrilla.IdCuadrilla.ToString();
                            if (oCabecera.EstadoOT.IdEstadoOT > 0)
                            {
                                if (oCabecera.EstadoOT.DescripcionEstado == "FACTURADO")
                                    this.ddlPEstado.SelectedItem.Text = "FACTURADO";
                                else
                                    this.ddlPEstado.SelectedItem.Value = "45";
                            }
                            if (oCabecera.EstadoOTRO.IdEstadoOT > 0)
                                this.ddlPEstadoRO.SelectedItem.Value = oCabecera.EstadoOTRO.IdEstadoOT.ToString();
                            this.txtPDireccion.Text = oCabecera.Direccion;
                            this.txtPCliente.Text = oCabecera.Cliente;
                            this.txtPUrbanizacion.Text = oCabecera.Urbanizacion;
                            this.ddlPActividad.SelectedItem.Value = oCabecera.Actividad.IdActividad.ToString();
                            this.txtHorTrab.Text = oCabecera.HorasTrabajadas.ToString();
                            this.txtNroTrab.Text = oCabecera.NumeroTrabajadores.ToString();
                            this.txtPCorrelativo.Text = oCabecera.NroRegistro.ToString();
                            this.TextTotalSGIO.Text = oCabecera.CostoOPEN.ToString();
                            this.txtPNroCargo.Text = oCabecera.NroCargo;
                            this.CargarDetallesConsumo(oCabecera.IdCabecera);
                            this.hdnTipoAccion.Text = "1";
                            if (oCabecera.EstadoOT.DescripcionEstado == "FACTURADO")
                            {
                                this.DesactivarControles(true);
                                this.GridPanel1.Disabled = true;
                            }
                            else
                            {
                                this.DesactivarControles(false);
                                this.GridPanel1.Disabled = false;
                            }
                        }
                        else
                        {
                            this.Mensaje("EL SGI INGRESADO NO EXISTE!.");
                        }
                    }
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA!.");
            }
        #endregion

    }

}