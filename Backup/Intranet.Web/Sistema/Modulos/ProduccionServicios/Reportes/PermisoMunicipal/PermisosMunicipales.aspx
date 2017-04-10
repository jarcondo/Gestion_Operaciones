<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisosMunicipales.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.PermisoMunicipal.PermisosMunicipales" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
	</ext:ResourceManager>
	<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Filtro de Información" Frame="true">
		<Content>
			<table>
				<tr>
					<td><b>Obra</b></td>
					<td colspan="2">
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
					<td><b>Cuadrilla</b></td>
					<td colspan="2">
						<ext:ComboBox ID="ddlCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="200px" ItemSelector="div.list-item">
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
					<td><b>Tipo Trabajo</b></td>
					<td colspan="2">
						<ext:ComboBox ID="ddlTipoTrabajo" runat="server" DisplayField="A2" ValueField="IdGenerica">
							<Store>
								<ext:Store ID="StoreTipoTrabajo" runat="server">
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
					<td><b>Estado</b></td>
					<td colspan="2">
						<ext:ComboBox ID="ddlEstado" Hidden="true" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" >
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
					<td><b>Fecha</b></td>
					<td>Desde
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
					<td></td>
					<td colspan="2">
						<table cellpadding="0" cellspacing="0">
							<tr>
													
								<td>
									<ext:Checkbox ID="chkPermisoMunicipal" runat="server">
									</ext:Checkbox>
								</td>
								<td style="padding-left:5px;"><b>PERMISO MUNICIPAL</b></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<br />
			<ext:Button ID="Button2" runat="server" Text="Ver Reporte" Icon="Report">
				<DirectEvents>
					<Click OnEvent="CargarReporte" Timeout="0"> </Click>
				</DirectEvents>
			</ext:Button>
		</Content>
	</ext:Panel>
    </form>
</body>
</html>
