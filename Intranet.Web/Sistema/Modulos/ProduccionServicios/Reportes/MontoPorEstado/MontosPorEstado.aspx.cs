using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Ext.Net;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.Utilities;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.MontoPorEstado
{
    public partial class MontosPorEstado : BasePage
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
                {
                    this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                    //this.CargaResponsable();
                }

                //List<EstadoOTDTO> olEstado = new EstadoOTBL().ListarEstadoOT();
                //if (olEstado == null) return;
                //olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 5 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();
                //this.StoreEstadoOT1.DataSource = olEstado;
                //this.StoreEstadoOT1.DataBind();
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        //private void CargaResponsable()
        //{
        //    try
        //    {
        //        List<EmpleadoDTO> olResponsable = new EmpleadoBL().ObtenerResponsables(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
        //        if (olResponsable == null) return;
        //        olResponsable.Insert(0, new EmpleadoDTO() { IdEmpleado = 0, NombresApellidos = "TODOS" });
        //        this.StoreResponsable.DataSource = olResponsable;
        //        this.StoreResponsable.DataBind();
        //        this.ddlResponsable.SelectedItem.Value = "0";

        //        List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
        //        olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
        //        this.StoreCuadrilla.DataSource = olCuadrilla;
        //        this.StoreCuadrilla.DataBind();
        //        this.ddlCuadrilla.SelectedItem.Value = "0";
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Mensaje(ex.Message);
        //    }

        //}

        //protected void CargarResponsable(object sender, DirectEventArgs e)
        //{
        //    this.CargaResponsable();
        //}

        //protected void CargarCuadrillaPorResponsable(object sender, DirectEventArgs e)
        //{
        //    try
        //    {
        //        List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
        //        if (Convert.ToInt32(this.ddlResponsable.SelectedItem.Value) == 0)
        //        {
                    
        //            olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
        //            this.StoreCuadrilla.DataSource = olCuadrilla;
        //            this.StoreCuadrilla.DataBind();
        //            this.ddlCuadrilla.SelectedItem.Value = "0";
        //        }
        //        olCuadrilla = new CuadrillaBL().GetCuadrillaPorResponsable(Convert.ToInt32(this.ddlResponsable.SelectedItem.Value), 0);
        //        if (olCuadrilla == null) return;
        //        olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
        //        this.StoreCuadrilla.DataSource = olCuadrilla;
        //        this.StoreCuadrilla.DataBind();
        //        this.ddlCuadrilla.SelectedItem.Value = "0";
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Mensaje(ex.Message);
        //    }
        //}

        protected void btnVerReporte_Click(object sender, DirectEventArgs e)
        {
            int obra;
            if (string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                this.Mensaje("DEBE SELECCIONAR LA OBRA");
                return;
            }
            else
                obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

            //string estado = "";
            //if (this.mslEstado.SelectedItems.Count > 0)
            //{
            //    foreach (SelectedListItem item in this.mslEstado.SelectedItems)
            //    {
            //        estado += item.Value + ",";
            //    }
            //    estado = estado.Substring(0, estado.Length - 1);
            //}
            //else
            //{
            //    this.Mensaje("DEBE SELECCIONAR POR LO MENOS UN ESTADO");
            //    return;
            //}

            //int responsable;
            //if (string.IsNullOrEmpty(this.ddlResponsable.SelectedItem.Value))
            //{
            //    this.Mensaje("DEBE SELECCIONAR EL RESPONSABLE");
            //    return;
            //}
            //else
            //    responsable = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value);

            //int cuadrilla;
            //if (string.IsNullOrEmpty(this.ddlCuadrilla.SelectedItem.Value))
            //{
            //    this.Mensaje("DEBE SELECCIONAR LA OBRA");
            //    return;
            //}
            //else
            //    cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);

            string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
            string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();

            if (fDesde == null || fHasta == null)
            {
                this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA SU REPORTE");
                return;
            }

            List<MontoEstadoDTO> olMontoEstado = new List<MontoEstadoDTO>();
            olMontoEstado = new EjecucionOTBL().ObtenerReporteMontoEstado(obra,fDesde,fHasta);

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/MontoPorEstado/rptMontoEstadoFinal.rpt";
            Session["Intranet.VisorReporte.Data"] = null;
            Session["Intranet.VisorReporte.Data"] = olMontoEstado;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }


        //protected void btnVerResumen_Click(object sender, DirectEventArgs e)
        //{
        //    int obra;
        //    if (string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
        //    {
        //        this.Mensaje("DEBE SELECCIONAR LA OBRA");
        //        return;
        //    }
        //    else
        //        obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

        //    string estado = "";
        //    if (this.mslEstado.SelectedItems.Count > 0)
        //    {
        //        foreach (SelectedListItem item in this.mslEstado.SelectedItems)
        //        {
        //            estado += item.Value + ",";
        //        }
        //        estado = estado.Substring(0, estado.Length - 1);
        //    }
        //    else
        //    {
        //        this.Mensaje("DEBE SELECCIONAR POR LO MENOS UN ESTADO");
        //        return;
        //    }

        //    int responsable;
        //    if (string.IsNullOrEmpty(this.ddlResponsable.SelectedItem.Value))
        //    {
        //        this.Mensaje("DEBE SELECCIONAR EL RESPONSABLE");
        //        return;
        //    }
        //    else
        //        responsable = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value);

        //    int cuadrilla;
        //    if (string.IsNullOrEmpty(this.ddlCuadrilla.SelectedItem.Value))
        //    {
        //        this.Mensaje("DEBE SELECCIONAR LA OBRA");
        //        return;
        //    }
        //    else
        //        cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);

        //    string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
        //    string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();

        //    if (fDesde == null || fHasta == null)
        //    {
        //        this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA SU REPORTE");
        //        return;
        //    }

        //    List<MontoEstadoDTO> olMontoEstado = new List<MontoEstadoDTO>();
        //    olMontoEstado = new EjecucionOTBL().ObtenerMontosEstadoResumen(obra, estado, responsable, cuadrilla,fDesde,fHasta);

        //    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/MontoPorEstado/rptMontosEstadoResumen.rpt";
        //    Session["Intranet.VisorReporte.Data"] = null;
        //    Session["Intranet.VisorReporte.Data"] = olMontoEstado;
        //    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        //}
    }
}