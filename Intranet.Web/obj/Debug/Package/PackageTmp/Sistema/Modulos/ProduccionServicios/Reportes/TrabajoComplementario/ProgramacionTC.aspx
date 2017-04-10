<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramacionTC.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.TrabajoComplementario.ProgramacionTC" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
        .list-item {
            font:normal 11px tahoma, arial, helvetica, sans-serif;
            padding:3px 10px 3px 10px;
            border:1px solid #fff; 
            border-bottom:1px solid #eeeeee;
            white-space:normal;
        }
	</style>
	<link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
	<ext:ResourceManager ID="ResourceManager1" runat="server" />

		<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Filtro de Información" Frame="true">
		<Content>
			<table>
				<tr>
					<td><b>Local</b></td>
					<td style="padding-left:15px;" colspan="2">
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
								<Select OnEvent="CargarEjecutor"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b></b></td>
					<td style="padding-left:15px;" colspan="2">
						<ext:ComboBox ID="ddlTipo" runat="server" Visible=false DisplayField="A2" ValueField="IdGenerica">
							<Store>
								<ext:Store ID="StoreTipo" runat="server">
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
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b>Área</b></td>
					<td style="padding-left:15px;" colspan="2">
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
				</tr>
                
				<tr>
					<td><b>Ejecutor</b></td>
					<td style="padding-left:15px;" colspan="2">
						<table>
							<tr>
								<td>
									<ext:RadioGroup ID="RadioGroup1" runat="server"  ColumnsNumber="2" ColumnWidth="1" Width="160">
										<Items>
											<ext:Radio ID="Radio1" runat="server" BoxLabel="Asignado" />
											<ext:Radio ID="Radio2" runat="server" BoxLabel="Proveedor" />
										</Items>
										<DirectEvents>
											<Change OnEvent="ManejarEjecutar"></Change>
										</DirectEvents>
									</ext:RadioGroup>
								</td>
								<td>
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
									<ext:ComboBox ID="ddlEjecutorProveedor" runat="server" 
										DisplayField="Proveedor" 
										ValueField="IdProveedor" 
										Editable="true" 
										TypeAhead="true" 
										Mode="Local"
										ForceSelection="true"
										TriggerAction="All"
										Width="300px">
										<Store>
											<ext:Store ID="StoreEjecutorProveedor" runat="server">
												<Reader>
													<ext:JsonReader IDProperty="IdProveedor">
														<Fields>
															<ext:RecordField Name="IdProveedor" />
															<ext:RecordField Name="Proveedor" />
														</Fields>
													</ext:JsonReader>
												</Reader>
											</ext:Store>
										</Store>
									</ext:ComboBox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
                <tr>
					<td colspan="3" style="height:3px;"> </td>
				</tr>
				<tr>
					<td><b>Estado</b></td>
					<td style="padding-left:15px;" colspan="2">
						<ext:ComboBox ID="ddlEstado" runat="server" Hidden="true" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" >
							<Store>
								<ext:Store ID="StoreEstadoOT" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdEstadoOT">
											<Fields>
												<ext:RecordField Name="IdEstadoOT" />
												<ext:RecordField Name="DescripcionEstado" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
						</ext:ComboBox>
                        <ext:MultiSelect ID="mslEstado" runat="server" Width="130" AutoHeight="true" DisplayField="DescripcionEstado" ValueField="IdEstadoOT">
                            <Store>
								<ext:Store ID="StoreEstadoOT1" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdEstadoOT">
											<Fields>
												<ext:RecordField Name="IdEstadoOT" />
												<ext:RecordField Name="DescripcionEstado" />
											</Fields>
										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
                        </ext:MultiSelect>
					</td>
				</tr>
				<tr>
                    <td><b></b></td>
                    <td style="padding-left:15px;" colspan="2">
                        <ext:RadioGroup ID="RadioGroup2" Visible=false runat="server"  ColumnsNumber="2" ColumnWidth="1" Width="100">
							<Items>
								<ext:Radio ID="Radio3" runat="server" BoxLabel="O/T" Checked="true" />
								<ext:Radio ID="Radio4" runat="server" BoxLabel="T/C" />
							</Items>
							<DirectEvents>
								<Change OnEvent="ManejarEjecutar"></Change>
							</DirectEvents>
						</ext:RadioGroup>
                    </td>
                </tr>
				<tr>
					<td><b>Fecha</b></td>
					<td style="padding-left:15px;">Desde
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
			</table>
			<br />
			<ext:Button ID="Button2" runat="server" Text="Ver Reporte" Icon="Report">
				<DirectEvents>
					<Click OnEvent="CargarReporte" Timeout="0"></Click>
				</DirectEvents>
			</ext:Button>
		</Content>
	</ext:Panel>
    </form>
</body>
</html>
