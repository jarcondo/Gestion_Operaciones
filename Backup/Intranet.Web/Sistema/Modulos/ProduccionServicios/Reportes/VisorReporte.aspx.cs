using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes
{
    public partial class VisorReporte : System.Web.UI.Page
    {
        ReportDocument rptDoc = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Unload += new EventHandler(VisorReporte_Unload);
            CrystalReportViewer1.Unload += new EventHandler(CrystalReportViewer1_Unload);



            rptDoc.Load(Server.MapPath(Session["Intranet.VisorReporte.Ruta"].ToString()));
            rptDoc.SetDataSource(Session["Intranet.VisorReporte.Data"]);
            //rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, "hola");
            rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, false, DateTime.Now.ToString());
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.DataBind();




        }

        void VisorReporte_Unload(object sender, EventArgs e)
        {
            CrystalReportViewer1.Dispose();
            rptDoc.Dispose();
            GC.Collect();
        }

        void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            CrystalReportViewer1.Dispose();
            rptDoc.Dispose();
            GC.Collect();
        }
    }
}