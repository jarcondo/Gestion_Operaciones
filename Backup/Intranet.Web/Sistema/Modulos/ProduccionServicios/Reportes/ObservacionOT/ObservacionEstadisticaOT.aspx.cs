using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.DTO.SGE;
using Intranet.Web.AppCode;
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.Global;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;
using System.Xml;
using System.Xml.Xsl;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes
{
    public partial class ObservacionEstadisticaOT : BasePage
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

            Checkbox chkEstado = new Checkbox();
            List<EstadoOTDTO> olEstado = new List<EstadoOTDTO>();
            olEstado = new EstadoOTBL().ListarEstadoOT();
            olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 6 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();
            foreach (var oEstado in olEstado)
            {
                chkEstado = new Checkbox();
                chkEstado.ID = "chk" + oEstado.DescripcionEstado;
                chkEstado.BoxLabel = oEstado.DescripcionEstado;
                chkEstado.Value = oEstado.IdEstadoOT.ToString();
                this.chkListaEstado.Items.Add(chkEstado);
            }
            
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
                    this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                    this.CargaCuadrilla();
                }

                //List<GenericaDTO> olGenerica = new GenericaBL().GetGenerica(eTabla.TipoTrabajo);
                //olGenerica.Insert(0, new GenericaDTO() { IdGenerica = 0, A2 = "TODOS" });
                //this.StoreTipoTrabajo.DataSource = olGenerica;
                //this.StoreTipoTrabajo.DataBind();
                //this.ddlTipoTrabajo.SelectedItem.Value = "0";

                this.StoreTipo.DataSource = new object[]
                {
                    new object[]{"TR", "TR - TUBERIA ROTA"},
                    new object[] { "CO", "CO - FUGA EN TOMA"},
                    new object[] { "RAM", "RAM - ROTURA ANTES DE MEDIDOR"},
                    new object[] { "LD", "LD - LIMPIEZA Y DESINFECCION"},
                    new object[] { "OET", "OET - BOMBEO"},
                };
                this.StoreTipo.DataBind();
                this.ddlTipo.SelectedItem.Value = "TR";
                
                

                List<GenericaDTO> olArea = new List<GenericaDTO>();
                olArea = new GenericaBL().GetGenerica(eTabla.Area);
                olArea.Insert(0, new GenericaDTO() { IdGenerica = 0, A2 = "TODOS" });
                this.StoreArea.DataSource = olArea;
                this.StoreArea.DataBind();
                this.ddlArea.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarCuadrilla(object sender, DirectEventArgs e)
        {
            this.CargaCuadrilla();
        }

        private void CargaCuadrilla()
        {
            try
            {
                List<CuadrillaDTO> olCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).OrderBy(x => x.Descripcion).ToList();
                olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                this.StoreCuadrilla.DataSource = olCuadrilla;
                this.StoreCuadrilla.DataBind();
                this.ddlCuadrilla.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarCuadrillaPorArea(object sender, DirectEventArgs e)
        {
            try
            {
                if (this.ddlObra.SelectedItem.Value != "0")
                {
                    if (this.ddlArea.SelectedItem.Value != "0")
                    {
                        List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
                        olCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                        olCuadrilla = olCuadrilla.Where(x => x.IdArea == Convert.ToInt32(this.ddlArea.SelectedItem.Value)).ToList();
                        olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                        this.StoreCuadrilla.DataSource = olCuadrilla;
                        this.StoreCuadrilla.DataBind();
                        this.ddlCuadrilla.SelectedItem.Value = "0";
                    }
                    else
                    {
                        var listaCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).OrderBy(d => d.Descripcion).ToList();
                        listaCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                        this.StoreCuadrilla.DataSource = listaCuadrilla;
                        this.StoreCuadrilla.DataBind();
                        this.ddlCuadrilla.SelectedItem.Value = "0";
                    }
                }
                else
                    this.Mensaje("DEBE SELECCIONAR OBRA.");
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        [DirectMethod]
        public void CargarReporte(string estado)
        {
            try
            {
                if (this.ddlObra.SelectedIndex >= 0)
                {
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    int cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);
                    int tipo = 0; // Convert.ToInt32(this.ddlTipoTrabajo.SelectedItem.Value);
                    int area = Convert.ToInt32(this.ddlArea.SelectedItem.Value);

                    if (estado.Length==0)
                    {
                        this.Mensaje("DEBE SELECCIONAR EL ESTADO DE LAS O/T.");
                        return;
                    }
                    estado = estado.Substring(0, estado.Length - 1);

                    string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
                    string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();

                    if (fDesde == null || fHasta == null)
                    {
                        this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA SU REPORTE");
                        return;
                    }

                    string obs = this.ddlTipo.SelectedItem.Value;

                    List<ObservacionEstadisticaDTO> olOTProgramacion = new List<ObservacionEstadisticaDTO>();
                    olOTProgramacion = new EjecucionOTBL().ObtenerObservacionOT(obra, cuadrilla, tipo, estado, fDesde, fHasta, area, obs);

                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/ObservacionOT/rptIndicadorEstadisticoOT.rpt";
                    Session["Intranet.VisorReporte.Data"] = null;
                    Session["Intranet.VisorReporte.Data"] = olOTProgramacion;
                    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        [DirectMethod]
        public void ObtenerDatosGrilla(string estado)
        {
            try
            {
                if (this.ddlObra.SelectedIndex >= 0)
                {
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    int cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);
                    int tipo = 0; // Convert.ToInt32(this.ddlTipoTrabajo.SelectedItem.Value);
                    int area = Convert.ToInt32(this.ddlArea.SelectedItem.Value);

                    if (estado.Length == 0)
                    {
                        this.Mensaje("DEBE SELECCIONAR EL ESTADO DE LAS O/T.");
                        return;
                    }
                    estado = estado.Substring(0, estado.Length - 1);

                    string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
                    string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();

                    if (fDesde == null || fHasta == null)
                    {
                        this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA SU REPORTE");
                        return;
                    }

                    string obs = this.ddlTipo.SelectedItem.Value;

                    List<ObservacionEstadisticaDTO> olOTProgramacion = new List<ObservacionEstadisticaDTO>();
                    olOTProgramacion = new EjecucionOTBL().ObtenerObservacionOT(obra, cuadrilla, tipo, estado, fDesde, fHasta, area, obs);
                    if (olOTProgramacion == null) return;
                    if (olOTProgramacion.Count == 0)
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                        return;
                    }
                    this.StoreEjecucionOT.DataSource = olOTProgramacion;
                    this.StoreEjecucionOT.DataBind();
                    
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=ObservacionEstadistica.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }
    }
}