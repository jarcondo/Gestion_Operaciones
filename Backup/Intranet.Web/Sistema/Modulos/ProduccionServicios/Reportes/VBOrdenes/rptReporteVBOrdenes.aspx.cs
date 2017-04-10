using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.Utilities;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.VBOrdenes
{
    public partial class rptReporteVBOrdenes : BasePage
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
                    this.CargaIngenieros();
                }
                                
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        private void CargaIngenieros()
        {
            try
            {
                List<ResponsableActividadDTO> oResAct = new ResponsableActividadBL().ObtenerResponsableActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                List<EmpleadoDTO> oRes = new List<EmpleadoDTO>();
                foreach (var item in oResAct)
                {
                    oRes.Add(item.Responsable);
                }
                oRes.Insert(0, new EmpleadoDTO() { IdEmpleado = 0, NombresApellidos = "TODOS" });
                this.StoreResponsable.DataSource = oRes;
                this.StoreResponsable.DataBind();
                this.ddlResponsable.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarIngenieros(object sender, DirectEventArgs e)
        {
            this.CargaIngenieros();
        }

        protected void CargarReporte(object sender, DirectEventArgs e)
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            int responsable = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value);
            List<VBIngenieroDTO> olEjec = new EjecucionOTBL().ObtenerVBIngenieros(obra, responsable, false);
            if (olEjec == null) return;
            if (olEjec.Count == 0)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return;
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/VBOrdenes/rptVBIngenierosOT.rpt";
            Session["Intranet.VisorReporte.Data"] = null;
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }
    }
}