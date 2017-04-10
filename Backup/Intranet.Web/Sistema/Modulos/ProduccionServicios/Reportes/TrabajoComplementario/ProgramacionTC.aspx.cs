using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.SGE;
using Intranet.DTO.Global;
using Ext.Net;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.Utilities;
using Intranet.BL.ProduccionServicios.Maestra;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.TrabajoComplementario
{
    public partial class ProgramacionTC : BasePage
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
            this.ddlCuadrilla.Hidden = true;
            this.ddlEjecutorProveedor.Hidden = true;
            //this.MostrarOcultarEjecutor();

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
                    this.CargaEjecutor();
                }

                List<EstadoOTDTO> olEstado = new List<EstadoOTDTO>();
                olEstado = new EstadoOTBL().ListarEstadoOT();
                olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 6 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();

                this.StoreEstadoOT1.DataSource = olEstado; //(List<EstadoOTDTO>)Session["session.estadoOT.intranet"];
                this.StoreEstadoOT1.DataBind();

                List<GenericaDTO> olTipo = new GenericaBL().GetGenerica(eTabla.TrabajoComplementario);
                this.StoreTipo.DataSource = olTipo;
                this.StoreTipo.DataBind();
                if (olTipo.Count > 0)
                    this.ddlTipo.SelectedItem.Value = olTipo[0].IdGenerica.ToString();

                List<GenericaDTO> olArea = new List<GenericaDTO>();
                olArea = new GenericaBL().GetGenerica(eTabla.Area);
                olArea.Insert(0, new GenericaDTO() { IdGenerica = 0, A2 = "TODOS" });
                this.StoreArea.DataSource = olArea;
                this.StoreArea.DataBind();
                this.ddlArea.SelectedItem.Value = "0";
            }
            catch(Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarEjecutor(object sender, DirectEventArgs e)
        {
            this.CargaEjecutor();
        }

        private void CargaEjecutor()
        {
            try
            {
                var listaCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).OrderBy(d => d.Descripcion).ToList();
                listaCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                this.StoreCuadrilla.DataSource = listaCuadrilla;
                this.StoreCuadrilla.DataBind();
                this.ddlCuadrilla.SelectedItem.Value = "0";

                var listaProveedor = (List<ProveedorDTO>)Session["session.proveedorCP.intranet"];
                listaProveedor.Where(x => (x.IdBase == Usuario.IdBase || x.ProveedorGeneral == true)).ToList();
                listaProveedor.Insert(0, new ProveedorDTO() { IdProveedor = 0, Proveedor = "TODOS" });
                this.StoreEjecutorProveedor.DataSource = listaProveedor;
                this.StoreEjecutorProveedor.DataBind();
                this.ddlEjecutorProveedor.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void ManejarEjecutar(object sender, DirectEventArgs e)
        {
            this.MostrarOcultarEjecutor();
        }

        private void MostrarOcultarEjecutor()
        {
            if (this.Radio1.Checked == true)
            {
                this.ddlCuadrilla.Hidden = false;
                this.ddlEjecutorProveedor.Hidden = true;
            }

            if (this.Radio2.Checked == true)
            {
                this.ddlCuadrilla.Hidden = true;
                this.ddlEjecutorProveedor.Hidden = false;
            }
        }

        protected void CargarReporte(object sender, DirectEventArgs e)
        {
            try
            {
                int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                string tipo = this.ddlTipo.SelectedItem.Text;
                string ejecutor = "";
                int idEjecutor = 0;
                if (this.Radio1.Checked)
                {
                    ejecutor = "CUADRILLA";
                    idEjecutor = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);
                }
                if (this.Radio2.Checked)
                {
                    ejecutor = "PROVEEDOR";
                    idEjecutor = Convert.ToInt32(this.ddlEjecutorProveedor.SelectedItem.Value);
                }


                string estado = "";
                if (this.mslEstado.SelectedItems.Count > 0)
                {
                    foreach (SelectedListItem item in this.mslEstado.SelectedItems)
                    {
                        estado += item.Value + ",";
                    }
                    estado = estado.Substring(0, estado.Length - 1);
                }
                else
                {
                    this.Mensaje("DEBE SELECCIONAR POR LO MENOS UN ESTADO");
                    return;
                }


                string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
                string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();
                int area = Convert.ToInt32(this.ddlArea.SelectedItem.Value);

                if (fDesde == null || fHasta == null)
                {
                    this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA REPORTE");
                    return;
                }

                string tipoObservacion = "";
                if (this.Radio3.Checked)
                {
                    tipoObservacion = "OT";
                }
                if (this.Radio4.Checked)
                {
                    tipoObservacion = "TC";
                }

                List<ProgramacionCuadrillaDTO> olProg = new EjecucionOTBL().ObtenerProgramacionTC(obra, tipo, ejecutor, idEjecutor, estado, fDesde, fHasta, area, tipoObservacion);

                switch (tipo)
                {
                    case "RESANE":
                        Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/TrabajoComplementario/rptProgramacionResane.rpt";
                        break;
                    case "SEÑALIZACION":
                        Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/TrabajoComplementario/rptProgramacionSenalizacion.rpt";
                        break;
                    case "DESMONTE":
                        Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/TrabajoComplementario/rptProgramacionDesmonte.rpt";
                        break;
                    case "CORTE":
                        Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/TrabajoComplementario/rptProgramacionCorte.rpt";
                        break;
                    case "ROTURA":
                        Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/TrabajoComplementario/rptProgramacionRotura.rpt";
                        break;
                }
                Session["Intranet.VisorReporte.Data"] = olProg;
                this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
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
        
        
    }
}