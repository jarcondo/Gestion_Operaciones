﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RprVisorPuntajeDiario.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Puntaje.RprVisorPuntajeDiario" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
			AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
			EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" 
			ToolbarImagesFolderUrl="" HasCrystalLogo="False"
			ToolPanelView="None" PageZoomFactor="90" />
     


    </div>
    </form>
</body>
</html>
