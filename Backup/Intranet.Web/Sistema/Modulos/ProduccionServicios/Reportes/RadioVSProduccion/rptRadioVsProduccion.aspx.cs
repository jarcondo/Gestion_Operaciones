using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Xml;
using System.Xml.Xsl;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.RadioVSProduccion
{
    public partial class rptRadioVsProduccion : BasePage
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
            List<RadioProduccionDTO> olEjec = new ConsumoMaterialBL().ObtenerCruceRadioProduccion(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=OTEjecutadasFecha.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }

        protected void ImprimirReporte(object sender, DirectEventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<RadioProduccionDTO> olEjec = new ConsumoMaterialBL().ObtenerCruceRadioProduccion(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/RadioVSProduccion/CruceRadioProduccions.rpt";
            Session["Intranet.VisorReporte.Data"] = null;
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }

        protected void ImprimirReporteResumen(object sender, DirectEventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<CruceOTsDTO> olEjec = new ConsumoMaterialBL().ObtenerCruceOTsProduccion(obra);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }

            switch (obra)
            {
                case 16:
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceOTs/rptCruceOTComas.rpt";
                    //Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceOTs/rptCruceOTVilla.rpt";
                    break;
                case 17:
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceOTs/rptCruceOTCallao.rpt";
                    break;
                case 20:
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceOTs/rptCruceOTVilla.rpt";
                    break;
                case 21:
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceOTs/rptCruceOTChorrillos.rpt";
                    break;
            }
            
            Session["Intranet.VisorReporte.Data"] = null;
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }
    }
}