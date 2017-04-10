<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="Intranet.Web.Sistema.CambioPassword" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Ingreso de Parámetros" Frame="true">
		<Content>
            <table style="padding-top:10px;">
                <tr>
                    <td><b>Ingrese Password Actual</b></td>
                    <td style="padding-left:10px;">
                        <ext:TextField ID="txtPassActual" runat="server" InputType="Password" >
                        </ext:TextField>
                    </td>
                </tr>
                <tr>
                    <td><b>Ingrese Nuevo Password</b></td>
                    <td style="padding-left:10px;">
                        <ext:TextField ID="txtPassNueva" runat="server" InputType="Password" >
                        </ext:TextField>
                    </td>
                </tr>
                <tr>
                    <td><b>Confirme Nuevo Password</b></td>
                    <td style="padding-left:10px;">
                        <ext:TextField ID="txtPassNueva2" runat="server" InputType="Password" >
                        </ext:TextField>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left:10px;padding-top:10px;">
                        <ext:Button ID="Button1" runat="server" Text="Cambiar Password" Icon="Accept">
				            <DirectEvents>
                                <Click OnEvent="CambiarPassword"></Click>
                            </DirectEvents>
                        </ext:Button>
                    </td>
                </tr>
            </table>
        </Content>
    </ext:Panel>
    </form>
</body>
</html>
