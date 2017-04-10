using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Puntaje
{
    public partial class RprVisorPuntajeDiario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath(Session["Intranet.VisorReporte.Ruta"].ToString()));
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            rptDoc.SetDataSource(Session["Intranet.VisorReporte.Data"]);
            CrystalReportViewer1.ReportSource = rptDoc;

            crParameterDiscreteValue.Value = Session["Intranet.VisorReporte.Base"];
            crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Base"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = Session["Intranet.VisorReporte.Obra"];
            crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Obra"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = Session["Intranet.VisorReporte.Periodo"];
            crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Periodo"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Session["Intranet.VisorReporte.Responsable"];
            crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["NombreResponsable"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            //crParameterDiscreteValue.Value = Session["Intranet.VisorReporte.TipoMaterial"];
            //crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["TipoMaterial"];
            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            CrystalReportViewer1.DataBind();

        }
    }
}