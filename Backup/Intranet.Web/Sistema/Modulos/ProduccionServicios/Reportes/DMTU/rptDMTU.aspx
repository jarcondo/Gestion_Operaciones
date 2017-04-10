<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDMTU.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.DMTU.rptDMTU" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    	var FnObtenerDatosGrilla = function () {
    		Ext.net.DirectMethods.ObtenerDatosGrilla();
    	}

    	var saveData = function () {
    		GridData.setValue(Ext.encode(GridPanel1.getRowsValues({ selectedOnly: false })));
    	};
    </script>
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
						</ext:ComboBox>
					</td>
					<td style="padding-left:30px;"><b>Fecha</b></td>
                    <td style="padding-left:10px;">Desde</td>
					<td style="padding-left:5px;">
						<ext:DateField 
							ID="txtFDesde" 
							runat="server"
							Vtype="daterange"
							AnchorHorizontal="100%">  
							<CustomConfig>
								<ext:ConfigItem Name="endDateField" Value="#{DateField2}" Mode="Value" />
							</CustomConfig>                        
						</ext:DateField>
					</td>
                    <td style="padding-left:15px;">Hasta</td>
					<td style="padding-left:5px;">
						<ext:DateField 
							ID="txtFHasta"
							runat="server" 
							Vtype="daterange"
							AnchorHorizontal="100%">    
							<CustomConfig>
								<ext:ConfigItem Name="startDateField" Value="#{DateField1}" Mode="Value" />
							</CustomConfig>                                 
						</ext:DateField>
					</td>
                    <td style="padding-left:10px;">
                        <ext:Button ID="Button2" runat="server" Text="Ver Datos" Icon="Find">
				            <DirectEvents>
					            <Click OnEvent="ObtenerDatosGrilla">
                                    <EventMask ShowMask="true" />
                                </Click>
				            </DirectEvents>
			            </ext:Button>
                    </td>
					<td style="padding-left:10px;">
                        <ext:Button ID="Button3" runat="server" Text="Imprimir" Icon="Printer">
                            <DirectEvents>
                                <Click OnEvent="ImprimirReporte">
                                    <EventMask ShowMask="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </td>
                </tr>
            </table>
        </Content>
    </ext:Panel>
	<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Resultado de la Búsqueda">
            <Items>
                <ext:Hidden ID="GridData" runat="server" />
                <ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                Height="350px"
				>
                <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button1" runat="server" Text="Exportar A Excel" AutoPostBack="true" OnClick="ToExcel" Icon="PageExcel">
                            <Listeners>
                                <Click Fn="saveData" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
                </TopBar>
				<Store>
					<ext:Store ID="StoreEjecucionOT" runat="server">
						<Reader>
							<ext:JsonReader>
								<Fields>
									<ext:RecordField Name="Direccion" />  
									<ext:RecordField Name="Localidad" />  
									<ext:RecordField Name="Distrito" />  
									<ext:RecordField Name="Actividad" />  
									<ext:RecordField Name="SubActividad" />  
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                        <ext:Column ColumnID="Direccion" Header="Dirección" DataIndex="Direccion" Width="200" />
                        <ext:Column ColumnID="Localidad" Header="Localidad" DataIndex="Localidad" Width="200" />
                        <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="120" />
                        <ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="200"/>
						<ext:Column ColumnID="SubActividad" Header="Sub-Actividad" DataIndex="SubActividad" Width="200" />
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
