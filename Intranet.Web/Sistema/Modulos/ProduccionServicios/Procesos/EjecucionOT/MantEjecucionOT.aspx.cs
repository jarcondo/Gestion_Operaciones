using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Proceso;
using Ext.Net;
using Intranet.BL.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;
using System.Xml;
using System.Xml.Xsl;
using System.Configuration;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT
{
    public partial class MantEjecucionOT : BasePage
    {
        #region EVENTOS 
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    this.InicializarControles();

                    //if (Usuario.IdRol == 20)
                    //{
                    //    this.btnGuardarOT.Enabled = false;
                    //    this.direccionCONCYSSA.ReadOnly = true;
                    //    this.ddlArea.ReadOnly = true;
                    //    this.ddlResponsable.ReadOnly = true;
                    //    this.StoreCuadrilla.ReadOnly = true;
                    //    this.FechaProg.ReadOnly = true;
                    //    this.FechaInicio.ReadOnly = true;
                    //    this.HoraInicio.ReadOnly = true;
                    //    this.FechaFin.ReadOnly = true;
                    //    this.HoraFin.ReadOnly = true;
                    //    this.chkTuberiaRota.Enabled = false;
                    //    this.chkFugaToma.Enabled = false;
                    //    this.chkRoturaMedidor.Enabled = false;
                    //    this.chkLimpieza.Enabled = false;
                    //    this.chkBombeo.Enabled = false;
                    //    this.ddlEstado.ReadOnly = true;
                    //    this.observacionCONCYSSA.ReadOnly = true;
                    //    this.chkOrden.Enabled = false;
                    //    this.NroOrden.ReadOnly = true;
                    //    this.FechaOrden.ReadOnly = true;
                    //}
                    string[] sRol = ConfigurationManager.AppSettings["RolesVB"].ToString().Split(';');
                    foreach (string oRol in sRol)
                    {
                        if (Usuario.IdRol == Convert.ToInt32(oRol))
                        {
                            this.chkPermisoMunicipal.Disabled = false;
                            this.txtFechaPermisoMuni.Disabled = false;
                            this.chkVB.Disabled = false;
                            continue;
                        }
                    }


                    string[] sRolMANAGER = ConfigurationManager.AppSettings["RolMANAGER"].ToString().Split(';');
                    foreach (string oRol in sRolMANAGER)
                    {
                        if (Usuario.IdRol == Convert.ToInt32(oRol))
                        {
                            this.ddlResponsable.ReadOnly = false;
                            this.ddlCuadrilla.ReadOnly = false;
                            continue;
                        }
                    }

                    string[] sRolSUPERVISOROPERACION = ConfigurationManager.AppSettings["RolSUPERVISOROPERACION"].ToString().Split(';');
                    foreach (string oRol in sRolSUPERVISOROPERACION)
                    {
                        if (Usuario.IdRol == Convert.ToInt32(oRol))
                        {
                            this.ddlResponsable.ReadOnly = true;
                            this.ddlCuadrilla.ReadOnly = false;
                            continue;
                        }
                    }

                    string[] sRolESPECIALISTA = ConfigurationManager.AppSettings["RolESPECIALISTA"].ToString().Split(';');
                    foreach (string oRol in sRolESPECIALISTA)
                    {
                        if (Usuario.IdRol == Convert.ToInt32(oRol))
                        {
                            this.ddlResponsable.ReadOnly = true;
                            this.ddlCuadrilla.ReadOnly = true;
                            continue;
                        }
                    }

                    chkDimension.Visible = false;
                    chkRelleno.Visible = false;
                    txtUnidad.Visible = false;

                    



                }
            }

            protected void btnBuscar_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    this.CargarGrilla();
                }
                catch (Exception ex)
                {
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                }
                
            }

            protected void RowDblClick_Event(object sender, DirectEventArgs e)
            {
                try
                {
                    string json = e.ExtraParams["IdEjecucionOT"];
                    List<EjecucionOTGridDTO> olEjecucionOT = JSON.Deserialize<List<EjecucionOTGridDTO>>(json);
                    EjecucionOTGridDTO oEjecucionOT = new EjecucionOTGridDTO();
                    oEjecucionOT = olEjecucionOT[0];

                    var listaCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).OrderBy(d => d.Descripcion).ToList();
                    if (listaCuadrilla == null) return;

                    this.StoreEjecutorCuadrilla.DataSource = listaCuadrilla;
                    this.StoreEjecutorCuadrilla.DataBind();

                    List<TrabajoComplementarioDTO> olistatc = new TrabajoComplementarioBL().GetTrabajoComplementarioPorObra(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                    if (olistatc == null) return;

                    this.StoreTrabajoComplementario.DataSource = olistatc;
                    this.StoreTrabajoComplementario.DataBind();
                    this.CargarMantenimiento(oEjecucionOT.Item);
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void btnPrevious_click(object sender, DirectEventArgs e)
            {
                try
                {
                    int NroPosicion = Convert.ToInt32(this.NroPosicion.Text);
                    NroPosicion--;

                    this.CargarDatosEjecucion(NroPosicion);
                    this.LimpiarTC();
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void btnNext_click(object sender, DirectEventArgs e)
            {
                try
                {
                    int NroPosicion = Convert.ToInt32(this.NroPosicion.Text);
                    NroPosicion++;

                    this.CargarDatosEjecucion(NroPosicion);
                    this.LimpiarTC();
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void btnGuardarOT_click(object sender, DirectEventArgs e)
            {
                try
                {


                    EjecucionOTDTO oEjecucion = new EjecucionOTBL().GetEjecucionOTPorID(Convert.ToInt32(this.hdnIdEjecucionOT.Text));
                    if (oEjecucion == null) return;

                    oEjecucion.Direccion = this.direccionCONCYSSA.Text.ToUpper();
                    oEjecucion.FechaInicio = this.FechaInicio.Text.Contains("0001") ? null : this.FechaInicio.Text;
                    oEjecucion.HoraInicio = this.HoraInicio.Text;
                    oEjecucion.FechaFin = this.FechaFin.Text.Contains("0001") ? null : this.FechaFin.Text;
                    oEjecucion.HoraFin = this.HoraFin.Text;
                    oEjecucion.FechaProg = this.FechaProg.Text.Contains("0001") ? null : this.FechaProg.Text;
                    oEjecucion.TipoTrabajo = new GenericaDTO()
                    {
                        IdGenerica = Convert.ToInt32(this.ddlTipoTrabajo.SelectedItem.Value),
                    };
                    oEjecucion.Observacion = this.observacionCONCYSSA.Text.ToUpper();
                    oEjecucion.NroOrden = this.NroOrden.Text;
                    oEjecucion.FechaOrden = this.FechaOrden.Text.Contains("0001") ? null : this.FechaOrden.Text;
                    oEjecucion.EstadoOrden = this.chkOrden.Checked;
                    oEjecucion.TuberiaRota = this.chkTuberiaRota.Checked;
                    oEjecucion.FugaToma = this.chkFugaToma.Checked;
                    oEjecucion.RoturaMedidor = this.chkRoturaMedidor.Checked;
                    oEjecucion.Limpieza = this.chkLimpieza.Checked;
                    oEjecucion.Bombeo = this.chkBombeo.Checked;
                    oEjecucion.PermisoMunicipal = this.chkPermisoMunicipal.Checked;
                    oEjecucion.FechaPermiso = this.txtFechaPermisoMuni.Text.Contains("0001") ? null : this.txtFechaPermisoMuni.Text;
                    oEjecucion.VBIngeniero = this.chkVB.Checked;

                    try
                    {
                        oEjecucion.Puntaje = Convert.ToDecimal(this.txtpuntaje.Text);
                        oEjecucion.DiasEstimadoEjec = Convert.ToInt32(this.txtDiasEstimadoEjec.Text);
                    }
                    catch (Exception ex)
                    {

                        oEjecucion.Puntaje = 0;
                    }
                    


                    if (this.chkVB.Checked == true && (Usuario.IdRol == 1 || Usuario.IdRol == 20))
                    {
                        oEjecucion.UsuarioVB = Usuario.IdUsuario;
                        oEjecucion.FechaVB = DateTime.Now;
                    }
                    oEjecucion.DMTU = this.chkDMTU.Checked;
                    oEjecucion.UsuarioModificacion = Usuario.IdUsuario;
                    oEjecucion.FechaModificacion = DateTime.Now;
                    if (Convert.ToInt32(this.ddlEstado.SelectedItem.Value) > 1 && string.IsNullOrEmpty(this.ddlCuadrilla.SelectedItem.Value))
                    {
                        //X.MessageBox.Alert("Intranet CONCYSSA", );
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE ASIGNAR UNA CUADRILLA ANTES DE GUARDAR LA O/T", Buttons = Ext.Net.MessageBox.Button.OK });
                        return;
                    }
                    else
                    {
                        if (new EjecucionOTBL().ActualizarEjecucionOT(oEjecucion) == eResultado.Correcto)
                        {
                            int cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);
                            int estado = Convert.ToInt32(this.ddlEstado.SelectedItem.Value);
                            if (oEjecucion.Cuadrilla.IdCuadrilla != cuadrilla || oEjecucion.EstadoOT.IdEstadoOT != estado)
                            {
                                oEjecucion.Area = new GenericaDTO()
                                {
                                    IdGenerica = Convert.ToInt32(this.ddlArea.SelectedItem.Value),
                                };
                                oEjecucion.IdResponsable = new EmpleadoDTO()
                                {
                                    IdEmpleado = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value),
                                };
                                oEjecucion.Cuadrilla = new CuadrillaDTO()
                                {
                                    IdCuadrilla = cuadrilla,
                                };
                                oEjecucion.EstadoOT = new EstadoOTDTO()
                                {
                                    IdEstadoOT = estado,
                                };
                                oEjecucion.UsuarioCreacion = Usuario.IdUsuario;
                                oEjecucion.FechaCreacion = DateTime.Now;
                                new EjecucionOTBL().InsertarEjecucionOT(oEjecucion);
                            }
                        }
                        else
                        {
                            this.Mensaje("Error al guardar la OT.");
                        }
                        this.CargarGrilla();
                        this.Window1.Hide();
                    }
                }
                catch (Exception ex)
                {
                    if(Usuario!=null)
                        new EjecucionOTBL().InsertarError(ex.StackTrace, Usuario.IdUsuario);
                    else
                        new EjecucionOTBL().InsertarError(ex.StackTrace, 0);
                    Mensaje(ex.Message);
                }
            }

            [DirectMethod]
            public void btnGuardarTC_Click()
            {
                try
                {
                    AdminTrabajoComplementarioDTO oATC = new AdminTrabajoComplementarioDTO();
                    if (this.rCuadrilla.Checked == true)
                    {
                        oATC.DesignadoA = "CUADRILLA";
                        oATC.Cuadrilla = new CuadrillaDTO()
                        {
                            IdCuadrilla = Convert.ToInt32(this.ddlEjecutorCuadrilla.SelectedItem.Value),
                        };
                        oATC.Proveedor = new ProveedorDTO()
                        {
                            IdProveedor = 0,
                        };
                    }
                    if (this.rProveedor.Checked == true)
                    {
                        oATC.DesignadoA = "PROVEEDOR";
                        oATC.Cuadrilla = new CuadrillaDTO()
                        {
                            IdCuadrilla = 0,
                        };
                        oATC.Proveedor = new ProveedorDTO()
                        {
                            IdProveedor = Convert.ToInt32(this.ddlEjecutorProveedor.SelectedItem.Value),
                        };
                    }

                    if (this.chkDimension.Checked == true)
                    {
                        //if (this.Dimension1.Text.Length==0 || this.Dimension2.Text.Length==0 )
                        //{
                        //    Mensaje("Ingrese Dimension");
                        //    return;
                        //}

                        oATC.DetalleCantidad = this.Dimension1.Text + ';' + this.Dimension2.Text;
                        //this.txtCantidad.Text = (Convert.ToDecimal(this.Dimension1.Text) * Convert.ToDecimal(this.Dimension2.Text)).ToString("0.00");
                    }

                    if (this.chkRelleno.Checked == true)
                        oATC.Relleno = Convert.ToDecimal(this.txtRelleno.Text);
                    else
                        oATC.Relleno = 0;

                    oATC.TrabajoComplementario = new TrabajoComplementarioDTO()
                    {
                        IdTrabajoComplementario = Convert.ToInt32(this.ddlTrabajoComplementario.SelectedItem.Value),
                    };

                    oATC.CostoProgramado = Convert.ToDecimal(this.txtPrecio.Text);
                    oATC.Cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                    oATC.Total = oATC.CostoProgramado * oATC.Cantidad;
                    oATC.EstadoOT = new EstadoOTDTO()
                    {
                        IdEstadoOT = Convert.ToInt32(this.ddlEstadoTC.SelectedItem.Value),
                    };

                    oATC.FechaProgramada = this.txtFProg.Text.Contains("0001") ? null : this.txtFProg.Text;

                    oATC.FecInicio = this.txtFInicio.Text.Contains("0001") ? null : this.txtFInicio.Text;
                    oATC.HoraInicio = txtHoraInicioTC.Text;

                    oATC.FecFin = this.txtFFin.Text.Contains("0001") ? null : this.txtFFin.Text;
                    oATC.HoraFin=txtHoraFinTC.Text;
                    oATC.Observacion = this.txtObsTC.Text.ToUpper();

                    if (!string.IsNullOrEmpty(this.ddlCuadrilla.SelectedItem.Text))
                    {
                        if (!string.IsNullOrEmpty(this.hdIdAdminTC.Text))
                        {
                            oATC.IdAdmTraCom = Convert.ToInt32(this.hdIdAdminTC.Text);
                            oATC.UsuarioModi = Usuario.IdUsuario;
                            oATC.FechaModi = DateTime.Now;
                            try
                            {
                                new AdminTrabajoComplementarioBL().ActualizarAdminTrabajoComplementario(oATC);
                            }
                            catch (Exception ex)
                            {
                                Mensaje(ex.Message);
                            }

                        }
                        else
                        {
                            oATC.EjecucionOT = new EjecucionOTDTO()
                            {
                                IdEjecucionOT = Convert.ToInt32(this.hdnIdEjecucionOT.Text),
                            };
                            oATC.UsuarioCrea = Usuario.IdUsuario;
                            oATC.FechaCrea = DateTime.Now;
                            try
                            {
                                new AdminTrabajoComplementarioBL().InsertarAdminTrabajoComplementario(oATC);
                            }
                            catch (Exception ex)
                            {
                                Mensaje(ex.Message);
                            }

                        }
                    }
                    else
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE ASIGNAR UNA CUADRILLA A LA O/T ANTES DE AGREGAR EL TRABAJO COMPLEMENTARIO", Buttons = Ext.Net.MessageBox.Button.OK });
                    }
                    this.LimpiarTC();
                    this.CargarTC(Convert.ToInt32(this.hdnIdEjecucionOT.Text));

                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void btnLimpiarTC_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    this.LimpiarTC();
                }
                catch(Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void btnBuscarTodos_Click(object sender, DirectEventArgs e)
            {
                //try
                //{
                //    List<EjecucionOTGridDTO> olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(Convert.ToInt32(this.ddlObra.SelectedItem.Value), "0", 0, "0", "0", 0, null, null, "0", 0);
                //    if (olEjecucion == null) return;
                //    this.StoreEjecucionOT.DataSource = olEjecucion;
                //    this.StoreEjecucionOT.DataBind();
                //    //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                //}
                //catch (Exception ex)
                //{
                //    Mensaje(ex.Message);
                //}
            }
        #endregion

        #region METODOS PERSONALIZADOS

            private void InicializarControles()
            {
                try
                {
                    this.CargarCombos();
                    this.ddlEjecutorCuadrilla.Hidden = true;
                    this.ddlEjecutorProveedor.Hidden = true;
                    this.Dimension1.Hidden = true;
                    this.Dimension2.Hidden = true;
                    this.Fecha.Text = DateTime.Now.ToShortDateString();
                    this.FechaD.Text = DateTime.Now.ToShortDateString();
                    this.txtFProg.Text = DateTime.Now.ToShortDateString();

                    if (Usuario.IdRol == 17)
                        this.txtFProg.Disabled = true;
                    else
                        this.txtFProg.Disabled = false;
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void CargarCombos()
            {
                try
                {
                    List<ObraDTO> olObra = new List<ObraDTO>();
                    if (Usuario.IdRol != 1 && Usuario.IdRol != 6)
                        olObra = new ObraBL().ListarObra(Usuario.IdBase).Where(x=>x.CP==true).ToList();
                    else
                        olObra = new ObraBL().ListarObraTodas().Where(x => x.CP == true).ToList();//(List<ObraDTO>)Session["session.obraCP.intranet"];

                    if (olObra == null) return;

                    this.StoreObra.DataSource = olObra;
                    this.StoreObra.DataBind();
                    if (olObra.Count == 1)
                    {
                        this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                        try
                        {
                            this.CargarCuadrillaFiltro();
                        }
                        catch (Exception ex)
                        {
                            Mensaje(ex.Message);
                        }
                    }

                    List<GenericaDTO> olAreaFiltro = new GenericaBL().GetGenerica(eTabla.Area);
                    olAreaFiltro.Insert(0, new GenericaDTO() { IdGenerica = 0, A2 = "TODOS" });
                    this.StoreAreaFiltro.DataSource = olAreaFiltro;
                    this.StoreAreaFiltro.DataBind();
                    this.ddlAreaFiltro.SelectedItem.Value = "0";

                    List<EstadoOTDTO> olEstado = new List<EstadoOTDTO>();
                    olEstado = new EstadoOTBL().ListarEstadoOT();
                    olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 6 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();

                    if (olEstado == null) return;
                    List<EstadoOTDTO> listEstado = olEstado;

                    this.StoreEstadoTC.DataSource = listEstado;
                    this.StoreEstadoTC.DataBind();
                    
                    this.StoreEstadoOT.DataSource = listEstado;
                    this.StoreEstadoOT.DataBind();

                    olEstado.Insert(0, new EstadoOTDTO() { IdEstadoOT = 0, DescripcionEstado = "TODOS" });

                    this.StoreEstado.DataSource = olEstado;
                    this.StoreEstado.DataBind();
                    this.ddlPEstado.SelectedItem.Value = "0";

                    //(List<EstadoOTDTO>)Session["session.estadoTodos.intranet"];
                    //listEstado = new EstadoOTBL().ListarEstadoOT();//(List<EstadoOTDTO>)Session["session.estadoOT.intranet"];
                    //if (listEstado == null) return;

                    

                    //listEstado = new EstadoOTBL().ListarEstadoOT(); //(List<EstadoOTDTO>)Session["session.estadoOT.intranet"];
                    //if (listEstado == null) return;

                    

                    List<GenericaDTO> listgenerica = new GenericaBL().GetGenerica(eTabla.TipoTrabajo);
                    if (listgenerica == null) return;

                    this.StoreTipoTrabajo.DataSource = listgenerica;
                    this.StoreTipoTrabajo.DataBind();

                    var listaProveedor = new ProveedorBL().GetProveedor().Where(x => x.CP == true).ToList(); //(List<ProveedorDTO>)Session["session.proveedorCP.intranet"];
                    if (listaProveedor == null) return;

                    this.StoreEjecutorProveedor.DataSource = listaProveedor.Where(x => (x.IdBase == Usuario.IdBase || x.ProveedorGeneral == true)).ToList();
                    this.StoreEjecutorProveedor.DataBind();
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            protected void CargarCuadrillasFiltro(object sender, DirectEventArgs e)
            {
                try
                {
                    this.CargarCuadrillaFiltro();
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            private void CargarCuadrillaFiltro()
            {
                try
                {
                    List<CuadrillaDTO> olCuadrillaFiltro = new List<CuadrillaDTO>();
                    olCuadrillaFiltro = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));

                    if (olCuadrillaFiltro == null) return;

                    olCuadrillaFiltro.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                    this.StoreCuadrillaFiltro.DataSource = olCuadrillaFiltro;
                    this.StoreCuadrillaFiltro.DataBind();
                    this.ddlCuadrillaFiltro.SelectedItem.Value = "0";
                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message);
                }
            }

            private void CargarGrilla()
            {
                try
                {


                    if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                    {
                        int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                        string nroOT = Numero.Text;

                        List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();

                        if (!string.IsNullOrEmpty(nroOT))
                        {
                            olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, nroOT, 0, "0", "0", 0, null, null, "0", 0, 0);
                            this.StoreEjecucionOT.DataSource = olEjecucion;
                            this.StoreEjecucionOT.DataBind();
                            //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                            return;
                        }

                        if (!string.IsNullOrEmpty(this.pNIS.Text))
                        {
                            olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, this.pNIS.Text, "0", 0, null, null, "0", 0, 0);
                            this.StoreEjecucionOT.DataSource = olEjecucion;
                            this.StoreEjecucionOT.DataBind();
                            //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                            return;
                        }

                        if (!string.IsNullOrEmpty(this.txtCorrelativo.Text))
                        {
                            olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, "0", "0", Convert.ToInt32(this.txtCorrelativo.Text), null, null, "0", 0, 0);
                            this.StoreEjecucionOT.DataSource = olEjecucion;
                            this.StoreEjecucionOT.DataBind();
                            //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                            return;
                        }

                        if (!string.IsNullOrEmpty(this.OTConcyssa.Text))
                        {
                            olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, "0", "0", 0, null, null, this.OTConcyssa.Text, 0, 0);
                            this.StoreEjecucionOT.DataSource = olEjecucion;
                            this.StoreEjecucionOT.DataBind();
                            //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                            return;
                        }

                        string sFecha = !Fecha.Text.Contains("0001") ? Convert.ToDateTime(Fecha.Text).ToShortDateString() : null;
                        string sFechaD = !FechaD.Text.Contains("0001") ? Convert.ToDateTime(FechaD.Text).ToShortDateString() : null;

                        int estado = Convert.ToInt32(this.ddlPEstado.SelectedItem.Value);
                        int cuadrilla = Convert.ToInt32(this.ddlCuadrillaFiltro.SelectedItem.Value);
                        string direccion = this.pDireccion.Text.ToUpper();
                        int area = Convert.ToInt32(this.ddlAreaFiltro.SelectedItem.Value);
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", estado, "0", direccion.Trim(), 0, sFechaD, sFecha, "0", cuadrilla, area);
                        this.StoreEjecucionOT.DataSource = olEjecucion;
                        this.StoreEjecucionOT.DataBind();

                        

                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                    }
                    else
                        this.Mensaje("DEBE SELECCIONAR LA OBRA.");

                }
                catch (Exception ex)
                {
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                }
            }

            private void CargarMantenimiento(int Item)
            {
                this.CargarDatosEjecucion(Item);
                this.Window1.SetTitle("Programacion & Planificacion de Orden de Trabajo");
                this.Window1.Show();
            }

            private void CargarDatosEjecucion(int Item)
            {
                try
                {
                    int valIntro = 0;
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    string nroOT = Numero.Text;

                    List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();

                    if (!string.IsNullOrEmpty(nroOT))
                    {
                        valIntro = 1;
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, nroOT, 0, "0", "0", 0, null, null, "0", 0, 0);
                        //this.StoreEjecucionOT.DataSource = olEjecucion;
                        //this.StoreEjecucionOT.DataBind();
                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                    }

                    if (!string.IsNullOrEmpty(this.pNIS.Text))
                    {
                        valIntro = 1;
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, this.pNIS.Text, "0", 0, null, null, "0", 0, 0);
                        //this.StoreEjecucionOT.DataSource = olEjecucion;
                        //this.StoreEjecucionOT.DataBind();
                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                    }

                    if (!string.IsNullOrEmpty(this.txtCorrelativo.Text))
                    {
                        valIntro = 1;
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, "0", "0", Convert.ToInt32(this.txtCorrelativo.Text), null, null, "0", 0, 0);
                        //this.StoreEjecucionOT.DataSource = olEjecucion;
                        //this.StoreEjecucionOT.DataBind();
                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                    }

                    if (!string.IsNullOrEmpty(this.OTConcyssa.Text))
                    {
                        valIntro = 1;
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", 0, "0", "0", 0, null, null, this.OTConcyssa.Text, 0, 0);
                        //this.StoreEjecucionOT.DataSource = olEjecucion;
                        //this.StoreEjecucionOT.DataBind();
                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                    }

                    if (valIntro == 0)
                    {
                        string sFecha = !Fecha.Text.Contains("0001") ? Convert.ToDateTime(Fecha.Text).ToShortDateString() : null;
                        string sFechaD = !FechaD.Text.Contains("0001") ? Convert.ToDateTime(FechaD.Text).ToShortDateString() : null;

                        int estado = Convert.ToInt32(this.ddlPEstado.SelectedItem.Value);
                        int cuadrilla = Convert.ToInt32(this.ddlCuadrillaFiltro.SelectedItem.Value);
                        string direccion = this.pDireccion.Text.ToUpper();
                        int area = Convert.ToInt32(this.ddlAreaFiltro.SelectedItem.Value);

                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(obra, "0", estado, "0", direccion.Trim(), 0, sFechaD, sFecha, "0", cuadrilla, area);
                    }
                    //List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();
                    //olEjecucion = (List<EjecucionOTGridDTO>)Session["lista.ejecucion.mantenimiento"];
                    
                    if ((Item <= olEjecucion.Count) && (Item > 0))
                    {
                        EjecucionOTDTO oEjec = new EjecucionOTBL().GetEjecucionOTPorID(olEjecucion.Where(x => x.Item == Item).FirstOrDefault().IdEjecucionOT);
                        this.CargarArea();
                        //this.CargarAsignacion(oEjec.OrdenTrabajo.actividad);
                        //Datos SEDAPAL
                        this.hdnIdEjecucionOT.Text = oEjec.IdEjecucionOT.ToString();
                        this.NroPosicion.Text = Item.ToString();
                        this.NroRegistro.Text = oEjec.NroPosicion.ToString();
                        this.nro_ot.Text = oEjec.OrdenTrabajo.nro_ot;
                        this.nis.Text = oEjec.OrdenTrabajo.nis_rad;
                        DateTime fecProg = oEjec.OrdenTrabajo.f_alta;//Convert.ToDateTime(oEjec.FechaProg);
                        TimeSpan diffResult = DateTime.Now.Subtract(fecProg);
                        this.conteoFecProg.Text = diffResult.Days.ToString();
                        this.vusuario.Text = oEjec.OrdenTrabajo.vusuario;
                        this.txtpuntaje.Text = oEjec.Puntaje.ToString();
                        this.txtDiasEstimadoEjec.Text = oEjec.DiasEstimadoEjec.ToString();


                        this.scliente.Text = oEjec.OrdenTrabajo.cliente;
                        this.direccion.Text = oEjec.OrdenTrabajo.direccion;
                        this.localidad.Text = oEjec.OrdenTrabajo.localidad;
                        this.municipio.Text = oEjec.OrdenTrabajo.municipio;

                        this.desc_actividad.Text = oEjec.OrdenTrabajo.desc_actividad;
                        this.desc_subactividad.Text = oEjec.OrdenTrabajo.desc_subactividad;

                        this.vdescripcion.Text = oEjec.OrdenTrabajo.vdescripcion;
                        this.f_alta.Text = oEjec.OrdenTrabajo.f_alta.ToShortDateString() + " " + oEjec.OrdenTrabajo.f_alta.ToShortTimeString();
                       

                        //Datos CONCYSSA
                        this.direccionCONCYSSA.Text = oEjec.Direccion;
                        this.FechaProg.Text = oEjec.FechaProg;
                        this.FechaInicio.Text = oEjec.FechaInicio;
                        this.HoraInicio.Text = oEjec.HoraInicio;
                        this.FechaFin.Text = oEjec.FechaFin;
                        this.HoraFin.Text = oEjec.HoraFin;
                        this.chkTuberiaRota.Checked = oEjec.TuberiaRota;
                        this.chkFugaToma.Checked = oEjec.FugaToma;
                        this.chkRoturaMedidor.Checked = oEjec.RoturaMedidor;
                        this.chkLimpieza.Checked = oEjec.Limpieza;
                        this.chkBombeo.Checked = oEjec.Bombeo;
                        this.chkPermisoMunicipal.Checked = oEjec.PermisoMunicipal;
                        this.observacionCONCYSSA.Text = oEjec.Observacion;
                        this.chkOrden.Checked = oEjec.EstadoOrden;
                        this.NroOrden.Text = oEjec.NroOrden;
                        this.FechaOrden.Text = oEjec.FechaOrden;
                        this.txtActualizado.Text = oEjec.UsuarioMod;
                        this.txtFechaPermisoMuni.Text = oEjec.FechaPermiso;

                        //Datos VB
                        this.chkVB.Checked = oEjec.VBIngeniero;
                        if (oEjec.VBIngeniero == true) this.txtUsuarioVB.Text = oEjec.UsuVBIngeniero;

                        //DATOS DMTU
                        this.chkDMTU.Checked = oEjec.DMTU;

                        //CUS
                        this.txtCUS.Text = oEjec.CUS;

                        //Datos Combos

                        List<ResponsableActividadDTO> olResAct = new ResponsableActividadBL().GetResponsableActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value), oEjec.OrdenTrabajo.actividad.ToString());
                        var lista = (from op in olResAct select new { IdGenerica = op.Area.IdGenerica, A2 = op.Area.A2 }).Distinct().ToList();
                        var lista2 = (from op in olResAct select new { IdEmpleado = op.Responsable.IdEmpleado, NombresApellidos = op.Responsable.NombresApellidos }).Distinct().ToList();

                        this.ddlArea.SelectedItem.Value = "";
                        this.ddlResponsable.SelectedItem.Value = "";
                        this.ddlCuadrilla.SelectedItem.Value = "";

                        if (oEjec.Area.IdGenerica > 0)
                            this.ddlArea.SelectedItem.Value = oEjec.Area.IdGenerica.ToString();
                        else
                        {
                            if (lista.Count == 1)
                                this.ddlArea.SelectedItem.Value = lista[0].IdGenerica.ToString();
                        }

                        this.CargarResponsable();
                        if (oEjec.IdResponsable.IdEmpleado > 0)
                        {
                            this.ddlResponsable.SelectedItem.Value = oEjec.IdResponsable.IdEmpleado.ToString();
                        }
                        else
                        {
                            if (lista2.Count == 1)
                                this.ddlResponsable.SelectedItem.Value = lista2[0].IdEmpleado.ToString();
                        }

                        this.CargarCuadrillaResponsable();
                        if (oEjec.Cuadrilla.IdCuadrilla > 0)
                        {
                            this.ddlCuadrilla.SelectedItem.Value = oEjec.Cuadrilla.IdCuadrilla.ToString();
                            if(oEjec.EstadoOT.IdEstadoOT.ToString()=="1")
                                this.TCTab.Disabled = true;
                            else
                                this.TCTab.Disabled = false;
                        }
                        else
                        {
                            this.TCTab.Disabled = true;
                        }

                        this.ddlEstado.SelectedItem.Value = oEjec.EstadoOT.IdEstadoOT.ToString();

                        if (oEjec.TipoTrabajo.IdGenerica > 0)
                            this.ddlTipoTrabajo.SelectedItem.Value = oEjec.TipoTrabajo.IdGenerica.ToString();

                        this.LimpiarTC();
                        this.CargarTC(oEjec.IdEjecucionOT);
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void CargarAsignacion(int codmap)
            {
                
                //this.StoreArea.DataSource = lista;
                //this.StoreArea.DataBind();
                //if (lista.Count == 1)
                //    this.ddlArea.SelectedItem.Value = lista[0].IdGenerica.ToString();

                
                //this.StoreResponsable.DataSource = lista2;
                //this.StoreResponsable.DataBind();
                //if (lista2.Count == 1)
                //    this.ddlResponsable.SelectedItem.Value = lista2[0].IdEmpleado.ToString();

                //if (lista2.Count == 1)
                //{
                //    List<CuadrillaDTO> olCuadrilla = new CuadrillaBL().GetCuadrillaPorResponsable(Convert.ToInt32(lista2[0].IdEmpleado), Convert.ToInt32(lista[0].IdGenerica));
                //    this.StoreCuadrilla.DataSource = olCuadrilla;
                //    this.StoreCuadrilla.DataBind();
                //}

                
            }

            private void CargarArea()
            {
                this.StoreArea.DataSource = new GenericaBL().GetGenerica(eTabla.Area);
                this.StoreArea.DataBind();
            }

            protected void CargarResponsablePorArea(object sender, DirectEventArgs e)
            {
                this.CargarResponsable();
            }

            private void CargarResponsable()
            {
                try
                {
                    if (ddlArea.SelectedItem.Value == null || ddlArea.SelectedItem.Value == "")
                        return;

                    List<ResponsableActividadDTO> oResAct = new ResponsableActividadBL().ObtenerResponsableActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).Where(x => x.Area.IdGenerica == Convert.ToInt32(this.ddlArea.SelectedItem.Value)).ToList();
                    List<EmpleadoDTO> oRes = new List<EmpleadoDTO>();
                    foreach (var item in oResAct)
                    {
                        oRes.Add(item.Responsable);
                    }
                    this.StoreResponsable.DataSource = oRes;
                    this.StoreResponsable.DataBind();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void CargarCuadrillaPorResponsable(object sender, DirectEventArgs e)
            {
                this.CargarCuadrillaResponsable();
            }

            private void CargarCuadrillaResponsable()
            {
                try
                {
                    if (ddlArea.SelectedItem.Value == null || ddlArea.SelectedItem.Value == "")
                        return;

                    List<CuadrillaDTO> olCuadrilla = new CuadrillaBL().GetCuadrillaPorResponsable(Convert.ToInt32(this.ddlResponsable.SelectedItem.Value), Convert.ToInt32(this.ddlArea.SelectedItem.Value));
                    this.StoreCuadrilla.DataSource = olCuadrilla;
                    this.StoreCuadrilla.DataBind();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void CargarTC(object sender, DirectEventArgs e)
            {
                string unid = e.ExtraParams["Unidad"];
                string precio = e.ExtraParams["Precio"];
                this.txtUnidad.Text = unid;
                this.txtPrecio.Text = precio;
                this.txtCantidad.Focus();
            }

            private void CargarTC(int p)
            {
                try
                {
                    var listaTC = new AdminTrabajoComplementarioBL().ListarAdminTrabajoComplementarioPorEjecucion(p);
                    this.StoreTC.DataSource = listaTC;
                    this.StoreTC.DataBind();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            [DirectMethod]
            public void ManejarTC(string tipo, int idAdminTC, int IdEjecucionOT)
            {
                try
                {
                    switch (tipo)
                    {
                        case "Eliminar":
                            new AdminTrabajoComplementarioBL().EliminarAdminTrabajoComplementario(idAdminTC, Usuario.IdUsuario);
                            this.LimpiarTC();
                            this.CargarTC(IdEjecucionOT);
                            break;
                        case "Editar":
                            this.LimpiarTC();
                            this.CargarEdicion(idAdminTC, IdEjecucionOT);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void CargarEdicion(int idAdminTC, int IdEjecucionOT)
            {
                try
                {
                    this.LimpiarTC();
                    AdminTrabajoComplementarioDTO oAdminTC = new AdminTrabajoComplementarioBL().ListarAdminTrabajoComplementarioPorID(idAdminTC);
                    this.hdIdAdminTC.Text = oAdminTC.IdAdmTraCom.ToString();
                    if (oAdminTC.DesignadoA.ToUpper() == "CUADRILLA")
                    {

                        //this.rProveedor.Checked = false;
                        this.rCuadrilla.Checked = true;
                        //this.ddlEjecutorCuadrilla.SelectedItem.Value = oAdminTC.Cuadrilla.IdCuadrilla.ToString();
                        //this.ddlEjecutorCuadrilla.SelectedItem.Value = "";

                        //this.ddlEjecutorCuadrilla.SetValue(oAdminTC.Cuadrilla.IdCuadrilla.ToString());
                    }
                    else
                    {
                        //this.rCuadrilla.Checked = true;
                        this.rProveedor.Checked = true;
                        this.ddlEjecutorProveedor.SelectedItem.Value = oAdminTC.Proveedor.IdProveedor.ToString();
                    }

                    if (!string.IsNullOrEmpty(oAdminTC.DetalleCantidad))
                    {
                        string[] dimensiones = oAdminTC.DetalleCantidad.Split(';');
                        if (dimensiones.Count() == 2)
                        {
                            this.chkDimension.Checked = true;
                            this.Dimension1.Hidden = true;
                            this.Dimension2.Hidden = true;
                            this.Dimension1.Text = dimensiones[0];
                            this.Dimension2.Text = dimensiones[1];
                        }
                    }

                    if(oAdminTC.Relleno>0)
                    {
                        this.chkRelleno.Checked = true;
                        this.txtRelleno.Text = oAdminTC.Relleno.ToString();
                    }
                    
                    this.ddlTrabajoComplementario.SelectedItem.Value = oAdminTC.TrabajoComplementario.IdTrabajoComplementario.ToString();
                    this.txtUnidad.Text = oAdminTC.TrabajoComplementario.Unidad;
                    this.txtPrecio.Text = oAdminTC.CostoProgramado.ToString();
                    this.txtCantidad.Text = oAdminTC.Cantidad.ToString();
                    if (!String.IsNullOrEmpty(oAdminTC.FechaProgramada))
                        this.txtFProg.Text = oAdminTC.FechaProgramada;
                    if (!String.IsNullOrEmpty(oAdminTC.FecInicio))
                        this.txtFInicio.Text = oAdminTC.FecInicio;
                    if (!String.IsNullOrEmpty(oAdminTC.FecFin))
                        this.txtFFin.Text = oAdminTC.FecFin;
                    this.ddlEstadoTC.SelectedItem.Value = oAdminTC.EstadoOT.IdEstadoOT.ToString();
                    this.txtObsTC.Text = oAdminTC.Observacion;

                    this.txtHoraInicioTC.Text = oAdminTC.HoraInicio;
                    this.txtHoraFinTC.Text = oAdminTC.HoraFin;
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            //protected void ManejarCuadrilla(object sender, DirectEventArgs e)
            //{
            //    if (this.rCuadrilla.Checked == true)
            //    {
            //        this.ddlEjecutorCuadrilla.Hidden = true;
            //        this.ddlEjecutorProveedor.Hidden = false;
            //        this.rProveedor.Checked = false;
            //    }
            //}

            //protected void ManejarProveedor(object sender, DirectEventArgs e)
            //{
            //    if (this.rProveedor.Checked == true)
            //    {
            //        this.ddlEjecutorCuadrilla.Hidden = false;
            //        this.ddlEjecutorProveedor.Hidden = true;
            //        this.rCuadrilla.Checked = false;
            //        this.ddlEjecutorCuadrilla.SetValue(this.ddlCuadrilla.SelectedItem.Value);
            //    }
            //}

            protected void ManejarEjecutar(object sender, DirectEventArgs e)
            {
                this.MostrarOcultarEjecutor();
            }

            private void MostrarOcultarEjecutor()
            {
                try
                {
                    if (this.rCuadrilla.Checked == true)
                    {
                        this.ddlEjecutorCuadrilla.Hidden = false;
                        this.ddlEjecutorProveedor.Hidden = true;
                        if (!string.IsNullOrEmpty(hdIdAdminTC.Text))
                        {
                            AdminTrabajoComplementarioDTO oAdminTC = new AdminTrabajoComplementarioBL().ListarAdminTrabajoComplementarioPorID(Convert.ToInt32(this.hdIdAdminTC.Text));
                            if (oAdminTC.DesignadoA.ToUpper() == "CUADRILLA")
                            {
                                this.rCuadrilla.Checked = true;
                                this.ddlEjecutorCuadrilla.SetValue(oAdminTC.Cuadrilla.IdCuadrilla.ToString());
                            }
                        }
                        else
                        {
                            this.ddlEjecutorCuadrilla.SetValue(this.ddlCuadrilla.SelectedItem.Value);
                        }
                    }

                    if (this.rProveedor.Checked == true)
                    {
                        this.ddlEjecutorCuadrilla.Hidden = true;
                        this.ddlEjecutorProveedor.Hidden = false;
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void ManejarDimension(object sender, DirectEventArgs e)
            {
                try
                {
                    if (this.chkDimension.Checked == true)
                    {
                        this.Dimension1.Hidden = false;
                        this.Dimension2.Hidden = false;
                    }
                    else
                    {
                        this.Dimension1.Hidden = true;
                        this.Dimension2.Hidden = true;
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            private void LimpiarTC()
            {
                try
                {
                    this.hdIdAdminTC.Text = "";
                    this.rCuadrilla.Checked = false;
                    this.rProveedor.Checked = false;
                    this.ddlEjecutorCuadrilla.Hidden = true;
                    this.ddlEjecutorProveedor.Hidden = true;
                    this.ddlEjecutorCuadrilla.SelectedItem.Value = "";
                    this.ddlEjecutorProveedor.SelectedItem.Value = "";
                    this.chkDimension.Checked = false;
                    this.Dimension1.Text = "";
                    this.Dimension2.Text = "";
                    this.Dimension1.Hidden = true;
                    this.Dimension2.Hidden = true;
                    this.chkRelleno.Checked = false;
                    this.txtRelleno.Text = "";
                    this.ddlTrabajoComplementario.SelectedItem.Value = "";
                    this.txtUnidad.Text = "";
                    this.txtPrecio.Text = "";
                    this.txtCantidad.Text = "";
                    this.txtFProg.Text = DateTime.Now.ToShortDateString();
                    this.txtFInicio.Text = "";
                    this.txtFFin.Text = "";
                    this.ddlEstadoTC.SelectedItem.Value = "";
                    this.txtObsTC.Text = "";
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

        #endregion

        #region VENTANA ASIGNACION SIN SGI
            [DirectMethod]
            public void CargarVentanaAsignacion(int IdEjecucion)
            {
                try
                {
                    this.CargarGrillaAsignacion();
                    this.hdnEjecucionConSGI.Text = IdEjecucion.ToString();
                    this.Window2.Title = "Asignación de O/T sin SGI";
                    this.Window2.Show();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void btnBuscarAsignacion_Click(object sender, DirectEventArgs e)
            {
                this.CargarGrillaAsignacion();
            }

            private void CargarGrillaAsignacion()
            {
                try
                {


                    string cliente = "";

                    if (Usuario.IdRol == 25)
                    {
                        cliente = Usuario.EMPRESA;
                    }
                    else
                    {
                        cliente = "";
                    }

                    List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();
                    olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObraSinSGI(Convert.ToInt32(this.ddlObra.SelectedItem.Value), null, 0, "0", this.txtDireccionAsignar.Text.ToUpper(),cliente);
                    this.StoreAsignacion.DataSource = olEjecucion;
                    this.StoreAsignacion.DataBind();
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }

            protected void btnCancelarAsignacion_Click(object sender, DirectEventArgs e)
            {
                this.hdnEjecucionConSGI.Text = "";
                this.txtDireccionAsignar.Text = "";
                this.Window2.Hide();
            }

            protected void btnAsignarOTs_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    string json = e.ExtraParams["Values"];
                    List<EjecucionOTGridDTO> olEjecucionOT = JSON.Deserialize<List<EjecucionOTGridDTO>>(json);

                    if (olEjecucionOT.Count > 0)
                    {
                        int IdConSGI = Convert.ToInt32(this.hdnEjecucionConSGI.Text);

                        new EjecucionOTBL().AsignarOTSinSGI(IdConSGI, olEjecucionOT[0].IdEjecucionOT);
                        this.Window2.Hide();
                        this.Mensaje("SGI ASIGANDO EXITOSAMENTE.");
                        this.CargarGrilla();
                    }
                    else
                        this.Mensaje("DEBE SELECCIONAR LA FILA PARA ASIGNAR EL SGI");
                }
                catch (Exception ex)
                {
                    this.Mensaje(ex.Message);
                }
            }
        
        #endregion


        #region exportar a excel
            protected void StoreEjecucionOT_RefreshData(object sender, StoreRefreshDataEventArgs e)
            {
                this.CargarGrilla();
            }

            protected void StoreEjecucionOT_RecordUpdated(object sender, AfterRecordUpdatedEventArgs e)
            {
                // This event is fired once for each Record that is Updated.

                //var company = new
                //{
                //    Name = e.NewValues["company"],
                //    Price = e.NewValues["price"],
                //    LastChange = e.NewValues["lastChange"]
                //};

                //string tpl = "Name: {0}, Price: {1}, LastChange: {2}<br />";
                //this.Label1.Html += string.Format(tpl, company.Name, company.Price, company.LastChange);
            }

            protected void StoreEjecucionOT_Submit(object sender, StoreSubmitDataEventArgs e)
            {
                string format = this.FormatType.Value.ToString();

                XmlNode xml = e.Xml;

                this.Response.Clear();

                switch (format)
                {
                    //case "xml":
                    //    string strXml = xml.OuterXml;
                    //    this.Response.AddHeader("Content-Disposition", "attachment; filename=ControlOT.xml");
                    //    this.Response.AddHeader("Content-Length", strXml.Length.ToString());
                    //    this.Response.ContentType = "application/xml";
                    //    this.Response.Write(strXml);
                    //    break;

                    case "xls":
                        this.Response.ContentType = "application/vnd.ms-excel";
                        this.Response.AddHeader("Content-Disposition", "attachment; filename=ControlOTs.xls");
                        XslCompiledTransform xtExcel = new XslCompiledTransform();
                        xtExcel.Load(Server.MapPath("Excel.xsl"));
                        xtExcel.Transform(xml, null, Response.OutputStream);

                        break;

                    //case "csv":
                    //    this.Response.ContentType = "application/octet-stream";
                    //    this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.csv");
                    //    XslCompiledTransform xtCsv = new XslCompiledTransform();
                    //    xtCsv.Load(Server.MapPath("ControlOT.xsl"));
                    //    xtCsv.Transform(xml, null, Response.OutputStream);

                    //    break;
                }
                this.Response.End();
            }

        #endregion
    }
}