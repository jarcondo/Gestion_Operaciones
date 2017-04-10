<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptReporteVBOrdenes.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.VBOrdenes.rptReporteVBOrdenes" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
	</ext:ResourceManager>
	<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Filtro de Información" Frame="true">
		<Content>
			<table cellpadding="3" cellspacing="3">
				<tr>
					<td><b>Obra</b></td>
					<td style="padding-left:10px;">
						<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione Obra]">
							<Store>
								<ext:Store ID="StoreObra" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdObra">
											<Fields>
												<ext:RecordField Name="IdObra" />
												<ext:RecordField Name="DescripcionCorta" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
							<DirectEvents>
								<Select OnEvent="CargarIngenieros"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
				</tr>
                <tr>
                    <td><b>Ingeniero</b></td>
                    <td style="padding-left:10px;">
                        <ext:ComboBox ID="ddlResponsable" runat="server" DisplayField="NombresApellidos" ValueField="IdEmpleado" Width="200px">
							<Store>
								<ext:Store ID="StoreResponsable" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdEmpleado">
											<Fields>
												<ext:RecordField Name="IdEmpleado" />
												<ext:RecordField Name="NombresApellidos" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
						</ext:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left:10px;">
                        <ext:Button ID="Button2" runat="server" Text="Ver Reporte" Icon="Report">
				            <DirectEvents>
					            <Click OnEvent="CargarReporte">
                                    <EventMask ShowMask="true" />
                                </Click>
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
