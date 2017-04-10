using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Ext.Net;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.SGE;
using Intranet.DTO.Global;
namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT
{
    public partial class RegEjecucionOT : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InicializarControles();
            }
        }

        private void InicializarControles()
        {
            this.CargarCombos();
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
                        this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();


                    List<GenericaDTO> listgenerica = new GenericaBL().GetGenerica(eTabla.TipoTrabajo);
                    if (listgenerica == null) return;

                    this.StoreTipoTrabajo.DataSource = listgenerica;
                    this.StoreTipoTrabajo.DataBind();

                    List<ProveedorDTO> olistacliente = new ProveedorBL().GetCliente();
                    this.StoreCliente.DataSource = olistacliente;
                    this.StoreCliente.DataBind();

                    if (Usuario.IdRol==25)
                    {
                        ddlcliente.Text = Usuario.EMPRESA;
                    }
                    else
                    {
                        ddlcliente.Text = "";
                    }

                    txtNFecAlta.Disabled = true;
                

                

                
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
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


                if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();
                    if (!string.IsNullOrEmpty(this.pNIS.Text))
                    {
                        olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObraSinSGI(obra, null, 0, this.pNIS.Text, "0",cliente);
                        if (olEjecucion == null) return;
                        this.StoreEjecucionOT.DataSource = olEjecucion;
                        this.StoreEjecucionOT.DataBind();
                        //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                        return;
                    }
                    string sFecha;
                    if (!Fecha.Text.Contains("0001"))
                    {
                        sFecha = Convert.ToDateTime(Fecha.Text).ToShortDateString();
                    }
                    else
                    {
                        sFecha = null;
                    }
                    //int estado = Convert.ToInt32(this.ddlPEstado.SelectedItem.Value);
                    string direccion = this.pDireccion.Text.ToUpper();
                    olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObraSinSGI(obra, sFecha, 0, "0", direccion.Trim(),cliente);
                    if (olEjecucion == null) return;
                    this.StoreEjecucionOT.DataSource = olEjecucion;
                    this.StoreEjecucionOT.DataBind();
                    //Session["lista.ejecucion.mantenimiento"] = olEjecucion;
                }
                else
                {
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }

        }


        #region NUEVA O/T SIN SGI

        protected void AgregarNueva(object sender, DirectEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (Usuario.IdRol==25)
                {
                    ddlcliente.Disabled = true;
                    ddlcliente.Text = Usuario.EMPRESA;
                    ddlcliente.Value = Usuario.EMPRESA;
                }
                else
                {
                    ddlcliente.Disabled = false;
                }

                this.Window2.Title = "Nueva O/T";
                this.LimpiarNuevaOT();
                this.CargarNCombos(null);
                this.ManejarNuevaOT(true);
                this.Window2.Show();
                this.txtNFecAlta.Text = DateTime.Now.ToString();
            }
            else
                this.Mensaje("DEBE SELECCIONAR LOCAL.");
        }

        private void CargarNCombos(EjecucionOTDTO oEjecucionOTDTO)
        {
            try
            {


                List<ProveedorDTO> olistacliente = new ProveedorBL().GetCliente();
                this.StoreCliente.DataSource = olistacliente;
                this.StoreCliente.DataBind();


                List<ActividadDTO> olistaACT = new ActividadBL().ListarActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                if (olistaACT == null) return;
                this.StoreNActividad.DataSource = olistaACT;
                this.StoreNActividad.DataBind();

                List<ObraDistritoDTO> olistaDIS = new ObraDistritoBL().ListarObraDistrito(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                if (olistaDIS == null) return;
                this.StoreNDistrito.DataSource = olistaDIS;
                this.StoreNDistrito.DataBind();


                List<GenericaDTO> listgenerica = new GenericaBL().GetGenerica(eTabla.TipoTrabajo);
                if (listgenerica == null) return;

                this.StoreTipoTrabajo.DataSource = listgenerica;
                this.StoreTipoTrabajo.DataBind();


                if (oEjecucionOTDTO != null)
                {



                    List<SubActividadDTO> olistasubact = new SubActividadBL().ObtenerSubActividadCreacion(Convert.ToInt32(this.ddlObra.SelectedItem.Value), Convert.ToInt32(oEjecucionOTDTO.OrdenTrabajo.actividad));
                    if (olistasubact == null) return;
                    this.StoreNSubActividad.DataSource = olistasubact;
                    this.StoreNSubActividad.DataBind();
                }
            


            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void LimpiarNuevaOT()
        {
            try
            {
                this.hdnIdEjecucionOT.Text = "";
                this.txtNNIS.Text = "";
                this.ddlNDistrito.SelectedItem.Value = "";
                this.txtNurbanizacion.Text = "";
                this.txtNDireccion.Text = "";
                this.ddlNActividad.SelectedItem.Value = "";
                this.ddlNSubActividad.SelectedItem.Value = "";
                this.txtNObservacion.Text = "";
                this.txtNFecAlta.Text = "";
                this.txtNSGI.Text = "";
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void ManejarNuevaOT(bool activa)
        {
            this.lblSGI.Hidden = activa;
            this.txtNSGI.Hidden = activa;
        }

        protected void CargarSubActividad(object sender, DirectEventArgs e)
        {
            try
            {
                List<SubActividadDTO> olistasubact = new SubActividadBL().ObtenerSubActividadCreacion(Convert.ToInt32(this.ddlObra.SelectedItem.Value), Convert.ToInt32(this.ddlNActividad.SelectedItem.Value));
                if (olistasubact == null) return;
                this.StoreNSubActividad.DataSource = olistasubact;
                this.StoreNSubActividad.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void GrabarNuevaOT(object sender, DirectEventArgs e)
        {
            try
            {

                if (ddlcliente.Value=="" || ddlcliente.Value==null)
                {
                     Mensaje("seleccione cliente");
                     return;
                }

                if (ddlNActividad.Value == "" || ddlNActividad.Value==null)
                {
                    Mensaje("seleccione actividad");
                    return;
                }

                if (ddlNSubActividad.Value == "" || ddlNSubActividad.Value==null)
                {
                    Mensaje("seleccione sub actividad");
                    return;
                }


                if (ddlTipoTrabajo.Value == "" || ddlTipoTrabajo.Value == null)
                {
                    Mensaje("seleccione tipo de trabajo");
                    return;
                }

                OrdenTrabajoDTO oOrdenTrabajo = new OrdenTrabajoDTO();
                oOrdenTrabajo.nis_rad = this.txtNNIS.Text;
                oOrdenTrabajo.municipio=this.ddlNDistrito.SelectedItem.Value;
                oOrdenTrabajo.nro_ot = this.txtNSGI.Text;
                oOrdenTrabajo.localidad = this.txtNurbanizacion.Text.ToUpper();
                oOrdenTrabajo.direccion = this.txtNDireccion.Text.ToUpper();
                oOrdenTrabajo.actividad = Convert.ToInt32(this.ddlNActividad.SelectedItem.Value);
                oOrdenTrabajo.desc_actividad = this.ddlNActividad.SelectedItem.Text.ToUpper();
                oOrdenTrabajo.subactividad = Convert.ToInt32(this.ddlNSubActividad.SelectedItem.Value);
                oOrdenTrabajo.desc_subactividad = this.ddlNSubActividad.SelectedItem.Text.ToUpper();
                oOrdenTrabajo.f_alta = Convert.ToDateTime(this.txtNFecAlta.Text);
                oOrdenTrabajo.vdescripcion = this.txtNObservacion.Text.ToUpper();
                oOrdenTrabajo.cliente = ddlcliente.SelectedItem.Text;
                oOrdenTrabajo.TipoTrabajo =
                    new GenericaDTO()
                {
                    IdGenerica = Convert.ToInt32(this.ddlTipoTrabajo.SelectedItem.Value),
                    A1 = this.ddlTipoTrabajo.SelectedItem.Text

                };


                if (String.IsNullOrEmpty(this.hdnIdEjecucionOT.Text))
                {
                    try
                    {
                        new OrdenTrabajoBL().InsertarOrdenTrabajoSinSGI(oOrdenTrabajo, Convert.ToInt32(this.ddlObra.SelectedItem.Value), Usuario.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                    
                }
                else
                {
                    try
                    {
                        EjecucionOTDTO oEjecucionOT = new EjecucionOTBL().GetEjecucionOTPorID(Convert.ToInt32(this.hdnIdEjecucionOT.Text));
                        int idOrden = oEjecucionOT.OrdenTrabajo.IdOrdenTrabajo;
                        oEjecucionOT.OrdenTrabajo = oOrdenTrabajo;
                        oEjecucionOT.OrdenTrabajo.IdOrdenTrabajo = idOrden;
                        oEjecucionOT.Observacion = this.txtNObservacion.Text.ToUpper();
                        new OrdenTrabajoBL().ActualizarOrdenTrabajoSinSGI(oEjecucionOT, Usuario.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                }

                this.Window2.Hide();
                this.LimpiarNuevaOT();
            }
            catch
            {
                this.Mensaje("NO SE PUDO REGISTRAR LA O/T.");
            }

        }

        protected void RowDblClick_Event(object sender, DirectEventArgs e)
        {
            try
            {
                string json = e.ExtraParams["IdEjecucionOT"];
                List<EjecucionOTGridDTO> olEjecucionOT = JSON.Deserialize<List<EjecucionOTGridDTO>>(json);
                EjecucionOTDTO oEjecucionOT = new EjecucionOTBL().GetEjecucionOTPorID(olEjecucionOT[0].IdEjecucionOT);
                if (oEjecucionOT == null) return;
                this.LimpiarNuevaOT();
                this.CargarNCombos(oEjecucionOT);
                this.CargarDatosEdicion(oEjecucionOT);
                this.ManejarNuevaOT(false);
                this.Window2.Title = "Editar O/T";
                this.Window2.Show();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void CargarDatosEdicion(EjecucionOTDTO oEjecucionOT)
        {
            try
            {
                this.hdnIdEjecucionOT.Text = oEjecucionOT.IdEjecucionOT.ToString();
                this.txtNSGI.Text = oEjecucionOT.OrdenTrabajo.nro_ot;
                this.txtNNIS.Text = oEjecucionOT.OrdenTrabajo.nis_rad;
                this.ddlNDistrito.SelectedItem.Text = oEjecucionOT.OrdenTrabajo.municipio;
                this.txtNurbanizacion.Text = oEjecucionOT.OrdenTrabajo.localidad;
                this.txtNDireccion.Text = oEjecucionOT.OrdenTrabajo.direccion;
                this.ddlNActividad.SelectedItem.Value = oEjecucionOT.OrdenTrabajo.actividad.ToString();
                this.ddlNSubActividad.SelectedItem.Value = oEjecucionOT.OrdenTrabajo.subactividad.ToString();
                this.txtNObservacion.Text = oEjecucionOT.Observacion;
                this.txtNFecAlta.Text = oEjecucionOT.OrdenTrabajo.f_alta.ToString();
                this.ddlcliente.Text = oEjecucionOT.OrdenTrabajo.cliente;
                this.ddlTipoTrabajo.SelectedItem.Value = oEjecucionOT.TipoTrabajo.IdGenerica.ToString();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void CancelarNuevaOT(object sender, DirectEventArgs e)
        {
            this.LimpiarNuevaOT();
            this.Window2.Hide();
        }
        #endregion
    }
}