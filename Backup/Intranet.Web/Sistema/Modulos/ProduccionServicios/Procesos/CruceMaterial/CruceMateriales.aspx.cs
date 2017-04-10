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
using Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using Intranet.Utilities;



namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CruceMaterial
{
    public partial class CruceMateriales : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ObraDTO> olObra = new List<ObraDTO>();
            ObraBL oObraBL = new ObraBL();
            if (Usuario.IdRol != 1)
            { 
                olObra = oObraBL.ListarObra(Usuario.IdBase);

              
            }
            else { 
                olObra = oObraBL.ListarObraTodas();
                olObra = (List<ObraDTO>)(from item in olObra
                                         where item.CP ==true
                                         select item).ToList();
                
            }
            int IdObraIni = olObra.ElementAt(0).IdObra;
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            //this.FechaIni.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //this.FechaFin.Text = DateTime.Now.ToString("dd-MM-yyyy"); 

        }

        [DirectMethod]
        public void btnBuscar_Click()
        {

            //string FechaIni = Convert.ToDateTime(this.FechaIni.Text).ToString("yyyy-MM-dd");
            //string FechaFin = Convert.ToDateTime(this.FechaFin.Text).ToString("yyyy-MM-dd");

            string FechaIni = Convert.ToDateTime(this.FechaIni.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFin.Text).ToString("dd-MM-yyyy");


            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            //this.StoreCruceMaterial.DataSource = oCruceMaterialBL.ListarCruceMaterial(Convert.ToInt32(this.ddlObra.Text), FechaIni, FechaFin);
            this.StoreCruceMaterial.DataBind();
            //this.CargarGrilla();
        }
        [DirectMethod]
        public void btnImprimir(string DescripcionObra )
        {
            //string FechaIni = Convert.ToDateTime(this.FechaIni.Text).ToString("yyyy-MM-dd");
            //string FechaFin = Convert.ToDateTime(this.FechaFin.Text).ToString("yyyy-MM-dd");


            string FechaIni = Convert.ToDateTime(this.FechaIni.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFin.Text).ToString("dd-MM-yyyy");


            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CruceMaterialDTO> olistaCruceMaterial = new List<CruceMaterialDTO>();
            //olistaCruceMaterial = oCruceMaterialBL.ListarCruceMaterial(Convert.ToInt32(this.ddlObra.Text), FechaIni, FechaFin);

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceMaterial/CruceMaterial.rpt";
            Session["Intranet.VisorReporte.Data"] = olistaCruceMaterial;
            Session["Intranet.VisorReporte.Base"] = "Base Chorrillos";
            Session["Intranet.VisorReporte.Obra"] = DescripcionObra;
            Session["Intranet.VisorReporte.Periodo"] = "Del " + Convert.ToDateTime(this.FechaIni.Text).ToString("dd/MM/yyyy") + " Al " + Convert.ToDateTime(this.FechaFin.Text).ToString("dd/MM/yyyy"); 

            //Page.ClientScript.RegisterStartupScript(GetType(), "", Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterial.aspx", "no", 800, 600, 10, 10, "no", "yes", "yes", "yes"));
            //Page.ClientScript.RegisterStartupScript(GetType(), "", Controles.MostrarPopUp("../VisorReporte.aspx", "no", 800, 600, 10, 10, "no", "yes", "yes", "yes"));

            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterial.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
            //this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));

         

        }

        protected void btnBuscarTodos_Click(object sender, DirectEventArgs e)
        {
            //List<EjecucionOTGridDTO> olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(Convert.ToInt32(this.ddlObra.SelectedItem.Value), "0", null, 0, "0", "0");
            //this.StoreEjecucionOT.DataSource = olEjecucion;
            //this.StoreEjecucionOT.DataBind();
            //Session["lista.ejecucion.mantenimiento"] = olEjecucion;

        }

        protected void RowDblClick_Event(object sender, DirectEventArgs e)
        {


        }
    }
}