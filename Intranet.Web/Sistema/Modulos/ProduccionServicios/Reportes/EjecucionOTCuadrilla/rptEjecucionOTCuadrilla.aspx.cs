using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.DTO.SGE;
using Intranet.Web.AppCode;
using Intranet.BL.SGE;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.EjecucionOTCuadrilla
{
    public partial class rptEjecucionOTCuadrilla : BasePage
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
            try
            {
                this.CargarCombos();
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
            }
        }

        private void CargarCombos()
        {
            List<ObraDTO> olObra = new List<ObraDTO>();
            if (Usuario.IdRol != 1 && Usuario.IdRol != 6)
                olObra = new ObraBL().ListarObra(Usuario.IdBase).Where(x => x.CP == true).ToList();
            else
                olObra = new ObraBL().ListarObraTodas().Where(x => x.CP == true).ToList();

            if (olObra == null) return;

            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
            {
                this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
            }
        }

        protected void DObtenerDatosGrilla(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<EjecucionOTCuadrillaDTO> olEjec = new ConsumoMaterialBL().ObtenerEjecucionOTCuadrilla(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();
        }


        protected void ImprimirReporte(object sender, DirectEventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<EjecucionOTCuadrillaDTO> olEjec = new ConsumoMaterialBL().ObtenerEjecucionOTCuadrilla(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/EjecucionOTCuadrilla/rptEjecucionPorCuadrilla.rpt";
            Session["Intranet.VisorReporte.Data"] = null;
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }

        protected void ReporteDetallado(object sender, DirectEventArgs e)
        {
            this.ReporteDetallado();
        }

        void ReporteDetallado()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<EjecucionOTCuadrillaDTO> olEjec = new ConsumoMaterialBL().ObtenerEjecucionOTCuadrillaDet(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/EjecucionOTCuadrilla/rptEjecPorCuadrillaDet.rpt";
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }
    }
}