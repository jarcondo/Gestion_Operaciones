<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObservacionEstadisticaOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.ObservacionEstadisticaOT" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var CrearEstados = function () {
            var estado = '';
            if (Ext.getCmp('chkPENDIENTE').checked == true) {
                estado += Ext.getCmp('chkPENDIENTE').value + ',';
            }
            if (Ext.getCmp('chkASIGNADO').checked == true) {
                estado += Ext.getCmp('chkASIGNADO').value + ',';
            }
            if (Ext.getCmp('chkTRABAJANDO').checked == true) {
                estado += Ext.getCmp('chkTRABAJANDO').value + ',';
            }
            if (Ext.getCmp('chkATENDIDO').checked == true) {
                estado += Ext.getCmp('chkATENDIDO').value + ',';
            }
            if (Ext.getCmp('chkANULADO').checked == true) {
                estado += Ext.getCmp('chkANULADO').value + ',';
            }

            Ext.get('hdnEstados').dom.value = estado;
            Ext.net.DirectMethods.CargarReporte(estado);
        };

        var FnObtenerDatosGrilla = function () {
            var estado = '';
            if (Ext.getCmp('chkPENDIENTE').checked == true) {
                estado += Ext.getCmp('chkPENDIENTE').value + ',';
            }
            if (Ext.getCmp('chkASIGNADO').checked == true) {
                estado += Ext.getCmp('chkASIGNADO').value + ',';
            }
            if (Ext.getCmp('chkTRABAJANDO').checked == true) {
                estado += Ext.getCmp('chkTRABAJANDO').value + ',';
            }
            if (Ext.getCmp('chkATENDIDO').checked == true) {
                estado += Ext.getCmp('chkATENDIDO').value + ',';
            }
            if (Ext.getCmp('chkANULADO').checked == true) {
                estado += Ext.getCmp('chkANULADO').value + ',';
            }
            Ext.net.DirectMethods.ObtenerDatosGrilla(estado);
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
			<table cellpadding="3" cellspacing="3" border="0">
				<tr>
					<td><b>Obra</b></td>
					<td colspan="2" style="padding-left:10px;">
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
								<Select OnEvent="CargarCuadrilla"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
				</tr>
                <tr>
					<td><b>Tipo</b></td>
					<td style="padding-left:10px;" colspan="2">
						<ext:ComboBox ID="ddlTipo" runat="server" DisplayField="tipo" ValueField="abbr" Width="250px">
							<Store>
								<ext:Store ID="StoreTipo" runat="server">
                                    <Reader>
                                        <ext:ArrayReader>
                                            <Fields>
                                                <ext:RecordField Name="abbr" />
                                                <ext:RecordField Name="tipo" />
                                            </Fields>
                                        </ext:ArrayReader>
                                    </Reader>            
                                </ext:Store>
							</Store>
						</ext:ComboBox>
					</td>
					<td><b>Área</b></td>
					<td style="padding-left:10px;" colspan="2">
						<ext:ComboBox ID="ddlArea" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="150px">
							<Store>
								<ext:Store ID="StoreArea" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdGenerica">
											<Fields>
												<ext:RecordField Name="IdGenerica" />
												<ext:RecordField Name="A2" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
							<DirectEvents>
								<Select OnEvent="CargarCuadrillaPorArea"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
					<td><b>Cuadrilla</b></td>
					<td colspan="2" style="padding-left:10px;">
						<ext:ComboBox ID="ddlCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="300px" ItemSelector="div.list-item">
							<Store>
								<ext:Store ID="StoreCuadrilla" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdCuadrilla">
											<Fields>
												<ext:RecordField Name="IdCuadrilla" />
												<ext:RecordField Name="Descripcion" />
												<ext:RecordField Name="DetalleZona" />
												<ext:RecordField Name="NombresApellidos" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
							<Template ID="Template1" runat="server">
								<Html>
									<tpl for=".">
										<div class="list-item">
											<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
										</div>
									</tpl>
								</Html>
							</Template>
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b>Estado</b></td>
					<td colspan="5" style="padding-left:10px;">
                        <ext:Hidden ID="hdnEstados" runat="server">
                        </ext:Hidden>
						<ext:CheckboxGroup ID="chkListaEstado" runat="server" ColumnsNumber="5" ColumnWidth="1" Width="490">
                        </ext:CheckboxGroup>
					</td>
				<%--</tr>
				<tr>--%>
					<td><b>Fecha</b></td>
					<td style="padding-left:10px;">Desde
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
					<td style="padding-left:15px;">Hasta
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
				</tr>
                <tr>
                    
                </tr>
			</table>
			
            <table>
                <tr>
                    <td>
                        <ext:Button ID="Button3" runat="server" Text="Ver Datos" Icon="Find">
                            <Listeners>
                                <Click Fn="FnObtenerDatosGrilla" />
                            </Listeners>
                        </ext:Button>
                    </td>
                    <td style="padding-left:20px;">
                        <ext:Button ID="Button2" runat="server" Text="Ver Reporte" Icon="Report">
				            <Listeners>
                                <Click Fn="CrearEstados" />
                            </Listeners>
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
							<ext:JsonReader IDProperty="SGI">
								<Fields>
                                    <ext:RecordField Name="SGI" />
                                    <ext:RecordField Name="NIS" />
                                    <ext:RecordField Name="Direccion" />
                                    <ext:RecordField Name="Urbanizacion" />
                                    <ext:RecordField Name="Distrito" />
                                    <ext:RecordField Name="Actividad" />
                                    <ext:RecordField Name="Observacion" />
                                    <ext:RecordField Name="FechaProg" />
                                    <ext:RecordField Name="HoraProg" />
                                    <ext:RecordField Name="FechaInicio" />
                                    <ext:RecordField Name="HoraInicio" />
                                    <ext:RecordField Name="FechaFin" />
                                    <ext:RecordField Name="HoraFin" />
                                    <ext:RecordField Name="Cuadrilla" />
                                    <ext:RecordField Name="Estado" />
                                    <ext:RecordField Name="Correlativo" />
                                    <ext:RecordField Name="NroOrden" />
                                    <ext:RecordField Name="FechaOrden" />            
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="SGI" Header="SGI" DataIndex="SGI" />
                        <ext:Column ColumnID="NIS" Header="NIS" DataIndex="NIS" />
                        <ext:Column ColumnID="Direccion" Header="Dirección" DataIndex="Direccion" />
                        <ext:Column ColumnID="Urbanizacion" Header="Urbanización" DataIndex="Urbanizacion" />
                        <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" />
                        <ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" />
                        <ext:Column ColumnID="Observacion" Header="Observacion" DataIndex="Observacion" />
                        <ext:Column ColumnID="FechaProg" Header="FechaProg" DataIndex="FechaProg" />
                        <ext:Column ColumnID="HoraProg" Header="HoraProg" DataIndex="HoraProg" />
                        <ext:Column ColumnID="FechaInicio" Header="FechaInicio" DataIndex="FechaInicio" />
                        <ext:Column ColumnID="HoraInicio" Header="HoraInicio" DataIndex="HoraInicio" />
                        <ext:Column ColumnID="FechaFin" Header="FechaFin" DataIndex="FechaFin" />
                        <ext:Column ColumnID="HoraFin" Header="HoraFin" DataIndex="HoraFin" />
                        <ext:Column ColumnID="Cuadrilla" Header="Cuadrilla" DataIndex="Cuadrilla" />
                        <ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" />
                        <ext:Column ColumnID="Correlativo" Header="Correlativo" DataIndex="Correlativo" />   
                        <ext:Column ColumnID="NroOrden" Header="NroOrden" DataIndex="NroOrden" />  
                        <ext:Column ColumnID="FechaOrden" Header="FechaOrden" DataIndex="FechaOrden" />  
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
