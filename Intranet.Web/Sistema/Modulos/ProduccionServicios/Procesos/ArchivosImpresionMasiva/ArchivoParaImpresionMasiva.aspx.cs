using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Ext.Net;
using System.Xml;
using System.Xml.Xsl;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ArchivosImpresionMasiva
{
    public partial class ArchivoParaImpresionMasiva : BasePage
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
                this.GridPanel1.Hide();
                this.GridPanel2.Hide();
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


        protected void DObtenerDatosSEPI(object sender, EventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<EjecucionOTFechaDTO> olEjec = new ConsumoMaterialBL().GenerarSEPI(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreEjecucionOT2.DataSource = olEjec;
            this.StoreEjecucionOT2.DataBind();

            this.GridPanel1.Hide();
            this.GridPanel2.Show();
        }

        protected void DObtenerDatosSEPC(object sender, EventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            string fdesde = this.txtFDesde.Text;
            string fhasta = this.txtFHasta.Text;
            List<EjecucionOTFechaDTO> olEjec = new ConsumoMaterialBL().GenerarSEPC(obra, fdesde, fhasta);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();

            this.GridPanel1.Show();
            this.GridPanel2.Hide();
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=SEP.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }
    }
}