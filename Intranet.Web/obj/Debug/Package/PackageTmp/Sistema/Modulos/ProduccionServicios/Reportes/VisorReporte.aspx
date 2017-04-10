<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorReporte.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.VisorReporte" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
	Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte 1.1</title>
    <script src="crystalreportviewers/js/crviewer/crv.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
			EnableDatabaseLogonPrompt="False" 
			EnableParameterPrompt="False"
			ToolbarImagesFolderUrl="" HasCrystalLogo="True"
			ToolPanelView="None" PageZoomFactor="100" />
    </form>
</body>
</html>
