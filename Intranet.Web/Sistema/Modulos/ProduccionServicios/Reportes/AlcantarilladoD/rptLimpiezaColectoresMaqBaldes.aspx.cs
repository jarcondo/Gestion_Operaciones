using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial;
using System.Xml;
using System.Xml.Xsl;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.Web.AppCode;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.AlcantarilladoD
{
    public partial class rptLimpiezaColectoresMaqBaldes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        [DirectMethod]
        public void ObtenerDatosGrilla()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<LimpiezaColectoresMaqBaldesDTO> olEjec = new DetalleLimpiezaBL().LimpiezaColectorMaqBalde(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreReporteMaquinaBalde.DataSource = olEjec;
            this.StoreReporteMaquinaBalde.DataBind();

            this.lblConteo.Text = "Conteo : " + olEjec.Count.ToString() + " registro(s)";

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
            List<LimpiezaColectoresMaqBaldesDTO> oLCMB = new DetalleLimpiezaBL().LimpiezaColectorMaqBalde(obra, fdesde, fhasta);
            if (oLCMB == null) return;
            if (oLCMB.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreReporteMaquinaBalde.DataSource = oLCMB;
            this.StoreReporteMaquinaBalde.DataBind();

            this.lblConteo.Text = "Conteo : " + oLCMB.Count.ToString() + " registro(s)";
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=LimpiezaColectorMaqBalde.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }
    }
}