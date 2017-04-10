<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantMasivoEjecucionOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT.MantMasivoEjecucionOT" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
	<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Parámetros de Búsqueda" Frame="true">
		<Content>
			<table style="padding-top:5px;">
				<tr>
					<td><b>Obra</b></td>
					<td style="padding-left:5px;">
						<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione]" Width="200px">
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
								<Select OnEvent="CargarCuadrillasFiltro"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
                    <td><b>Desde</b></td>
					<td style="padding-left:15px;">
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
                    <td><b>Hasta</b></td>
					<td style="padding-left:15px;">
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
					<td style="padding-left:15px;">
							<ext:Button ID="btnBuscarTodos" runat="server" Text="Buscar" Icon="Find">
								<DirectEvents>
									<Click OnEvent="btnBuscarTodos_Click" Timeout="36000">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
									</Click>
								</DirectEvents>
							</ext:Button>
						</td>
				</tr>
			</table>
		</Content>
	</ext:Panel>
	<ext:GridPanel 
	ID="GridPanel1" 
	runat="server" 
    Height="380px"
	>
		<Store>
			<ext:Store ID="StoreEjecucionOT" runat="server"  RemoteSort="true" OnRefreshData="Store1_RefreshData">
                <Proxy>
                    <ext:PageProxy />
                </Proxy>
				<Reader>
					<ext:JsonReader IDProperty="IdEjecucionOT">
						<Fields>
							<%--<ext:RecordField Name="Item" />--%>
							<ext:RecordField Name="NroRegistro" />
							<ext:RecordField Name="IdEjecucionOT" />
							<%--<ext:RecordField Name="NroOT" />
							<ext:RecordField Name="NIS" />--%>
							<ext:RecordField Name="NroOrden" />
							<ext:RecordField Name="DesCuadrilla" />
							<%--<ext:RecordField Name="Distrito" />--%>
							<ext:RecordField Name="Direccion" />
							<%--<ext:RecordField Name="Cliente" />
							<ext:RecordField Name="Actividad" />
							<ext:RecordField Name="Descripcion" />
							<ext:RecordField Name="FechaAlta" />--%>
							<ext:RecordField Name="Estado" />
							<ext:RecordField Name="os_ot" />
							<ext:RecordField Name="ncod_centro" />
							<ext:RecordField Name="center" />
							<ext:RecordField Name="nro_ot" />
							<ext:RecordField Name="nis_rad" />
							<ext:RecordField Name="cliente" />
							<ext:RecordField Name="municipio" />
							<ext:RecordField Name="localidad" />
							<ext:RecordField Name="direccion" />
							<ext:RecordField Name="estado" />
							<ext:RecordField Name="nest_ot" />
							<ext:RecordField Name="actividad" />
							<ext:RecordField Name="desc_actividad" />
							<ext:RecordField Name="subactividad" />
							<ext:RecordField Name="desc_subactividad" />
							<ext:RecordField Name="ncosto_ot" />
							<ext:RecordField Name="vobservacion_contrata" />
							<ext:RecordField Name="f_alta" />
							<ext:RecordField Name="f_ini" />
							<ext:RecordField Name="f_fin" />
							<ext:RecordField Name="f_atendido" />
							<ext:RecordField Name="f_res_contrata" />
							<ext:RecordField Name="tipo_red" />
							<ext:RecordField Name="ntip_red" />
							<ext:RecordField Name="vdescripcion" />
							<ext:RecordField Name="vref_direccion" />
							<ext:RecordField Name="vusuario" />
							<ext:RecordField Name="nres_contrata" />
							<ext:RecordField Name="ncod_cuadrilla" />
							<ext:RecordField Name="ncod_incidencia" />
							<ext:RecordField Name="ncod_factura" />
							<ext:RecordField Name="secs" />
							<ext:RecordField Name="secsfin" />
							<ext:RecordField Name="ot_contrata" />
							<ext:RecordField Name="ntip_ot" />
							<ext:RecordField Name="tipo_ot" />
							<ext:RecordField Name="nnum_os" />
						</Fields>
					</ext:JsonReader>
				</Reader>
			</ext:Store>
		</Store>
		<ColumnModel ID="ColumnModel1" runat="server">
			<Columns>
				
				<%--<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="40px" Hidden="true"/>--%>
				<ext:Column ColumnID="NroRegistro" Header="Correlativo" DataIndex="NroRegistro" Width="70px" />
				<ext:Column ColumnID="IdEjecucionOT" Header="IdEjecucionOT" DataIndex="IdEjecucionOT" Hidden="true" />
				<%--<ext:Column ColumnID="NroOT" Header="NroOT" DataIndex="NroOT" Width="60px" />
				<ext:Column ColumnID="NIS" Header="NIS" DataIndex="NIS" Width="60px" />--%>
				<ext:Column ColumnID="NroOrden" Header="Nro. Orden" DataIndex="NroOrden" Width="60px" />
				<ext:Column ColumnID="DesCuadrilla" Header="Cuadrilla" DataIndex="DesCuadrilla" Width="130px" />
				<%--<ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="130px" />--%>
				<ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="300px" />
				<%--<ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="300px" />
				<ext:Column ColumnID="Descripcion" Header="Descripción" DataIndex="Descripcion" Width="300px" />
				<ext:Column ColumnID="FechaAlta" Header="Fec. Alta" DataIndex="FechaAlta" Width="120px" />--%>
				<ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" Width="80px" />
				<ext:Column ColumnID="os_ot" Header="os_ot" DataIndex="os_ot"  />
							<ext:Column ColumnID="ncod_centro" Header="ncod_centro" DataIndex="ncod_centro"  />
							<ext:Column ColumnID="center" Header="center" DataIndex="center"  />
							<ext:Column ColumnID="nro_ot" Header="nro_ot" DataIndex="nro_ot"  />
							<ext:Column ColumnID="nis_rad" Header="nis_rad" DataIndex="nis_rad"  />
							<ext:Column ColumnID="cliente" Header="cliente" DataIndex="cliente"  />
							<ext:Column ColumnID="municipio" Header="municipio" DataIndex="municipio"  />
							<ext:Column ColumnID="localidad" Header="localidad" DataIndex="localidad"  />
							<ext:Column ColumnID="direccion" Header="direccion" DataIndex="direccion"  />
							<ext:Column ColumnID="actividad" Header="actividad" DataIndex="actividad"  />
							<ext:Column ColumnID="desc_actividad" Header="desc_actividad" DataIndex="desc_actividad"  />
							<ext:Column ColumnID="subactividad" Header="subactividad" DataIndex="subactividad"  />
							<ext:Column ColumnID="desc_subactividad" Header="desc_subactividad" DataIndex="desc_subactividad"  />
							<ext:Column ColumnID="ncosto_ot" Header="ncosto_ot" DataIndex="ncosto_ot"  />
							<ext:Column ColumnID="vobservacion_contrata" Header="vobservacion_contrata" DataIndex="vobservacion_contrata"  />
							<ext:Column ColumnID="f_alta" Header="f_alta" DataIndex="f_alta"  />
							<ext:Column ColumnID="f_ini" Header="f_ini" DataIndex="f_ini"  />
							<ext:Column ColumnID="f_fin" Header="f_fin" DataIndex="f_fin"  />
							<ext:Column ColumnID="f_atendido" Header="f_atendido" DataIndex="f_atendido"  />
							<ext:Column ColumnID="f_res_contrata" Header="f_res_contrata" DataIndex="f_res_contrata"  />
							<ext:Column ColumnID="tipo_red" Header="tipo_red" DataIndex="tipo_red"  />
							<ext:Column ColumnID="ntip_red" Header="ntip_red" DataIndex="ntip_red"  />
							<ext:Column ColumnID="vdescripcion" Header="vdescripcion" DataIndex="vdescripcion"  />
							<ext:Column ColumnID="vref_direccion" Header="vref_direccion" DataIndex="vref_direccion"  />
							<ext:Column ColumnID="vusuario" Header="vusuario" DataIndex="vusuario"  />
							<ext:Column ColumnID="nres_contrata" Header="nres_contrata" DataIndex="nres_contrata"  />
							<ext:Column ColumnID="ncod_cuadrilla" Header="ncod_cuadrilla" DataIndex="ncod_cuadrilla"  />
							<ext:Column ColumnID="ncod_incidencia" Header="ncod_incidencia" DataIndex="ncod_incidencia"  />
							<ext:Column ColumnID="ncod_factura" Header="ncod_factura" DataIndex="ncod_factura"  />
							<ext:Column ColumnID="secs" Header="secs" DataIndex="secs"  />
							<ext:Column ColumnID="secsfin" Header="secsfin" DataIndex="secsfin"  />
							<ext:Column ColumnID="ot_contrata" Header="ot_contrata" DataIndex="ot_contrata"  />
							<ext:Column ColumnID="ntip_ot" Header="ntip_ot" DataIndex="ntip_ot"  />
							<ext:Column ColumnID="tipo_ot" Header="tipo_ot" DataIndex="tipo_ot"  />
							<ext:Column ColumnID="nnum_os" Header="nnum_os" DataIndex="nnum_os"  />
			</Columns>
		</ColumnModel>
		<LoadMask ShowMask="true" />
		<SaveMask ShowMask="true" />
		<Plugins>
            <ext:GridFilters runat="server" ID="GridFilters1">
                <Filters>
					<ext:NumericFilter DataIndex="NroRegistro" />
					<ext:StringFilter DataIndex="NroOrden" />
					<ext:StringFilter DataIndex="DesCuadrilla" />
					<ext:StringFilter DataIndex="Direccion" />
					<ext:StringFilter DataIndex="Estado" />
					<ext:StringFilter DataIndex="os_ot"  />
					<ext:NumericFilter DataIndex="ncod_centro"  />
					<ext:StringFilter DataIndex="center"  />
					<ext:StringFilter DataIndex="nro_ot"  />
					<ext:StringFilter DataIndex="nis_rad"  />
					<ext:StringFilter DataIndex="cliente"  />
					<ext:StringFilter DataIndex="municipio"  />
					<ext:StringFilter DataIndex="localidad"  />
					<ext:StringFilter DataIndex="direccion"  />
					<ext:NumericFilter DataIndex="actividad"  />
					<ext:StringFilter DataIndex="desc_actividad"  />
					<ext:NumericFilter DataIndex="subactividad"  />
					<ext:StringFilter DataIndex="desc_subactividad"  />
					<ext:NumericFilter DataIndex="ncosto_ot"  />
					<ext:StringFilter DataIndex="vobservacion_contrata"  />
					<ext:DateFilter DataIndex="f_alta">
						<DatePickerOptions runat="server" TodayText="Now" />
					</ext:DateFilter>
					<ext:DateFilter DataIndex="f_ini">
						<DatePickerOptions runat="server" TodayText="Now" />
					</ext:DateFilter>
					<ext:DateFilter DataIndex="f_fin">
						<DatePickerOptions runat="server" TodayText="Now" />
					</ext:DateFilter>
					<ext:DateFilter DataIndex="f_atendido">
						<DatePickerOptions runat="server" TodayText="Now" />
					</ext:DateFilter>
					<ext:DateFilter DataIndex="f_res_contrata">
						<DatePickerOptions runat="server" TodayText="Now" />
					</ext:DateFilter>
					<ext:StringFilter DataIndex="tipo_red"  />
					<ext:NumericFilter DataIndex="ntip_red"  />
					<ext:StringFilter DataIndex="vdescripcion"  />
					<ext:StringFilter DataIndex="vref_direccion"  />
					<ext:StringFilter DataIndex="vusuario"  />
					<ext:NumericFilter DataIndex="nres_contrata"  />
					<ext:NumericFilter DataIndex="ncod_cuadrilla"  />
					<ext:NumericFilter DataIndex="ncod_incidencia"  />
					<ext:NumericFilter DataIndex="ncod_factura"  />
					<ext:StringFilter DataIndex="secs"  />
					<ext:StringFilter DataIndex="secsfin"  />
					<ext:StringFilter DataIndex="ot_contrata"  />
					<ext:NumericFilter DataIndex="ntip_ot"  />
					<ext:StringFilter DataIndex="tipo_ot"  />
					<ext:NumericFilter DataIndex="num_os"  />
                </Filters>
            </ext:GridFilters>
        </Plugins>
		<SelectionModel>
			<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
		</SelectionModel>
		<%--<DirectEvents>
			<RowDblClick OnEvent="RowDblClick_Event" Timeout="3600000">
				<ExtraParams>
					<ext:Parameter Name="IdEjecucionOT" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
				</ExtraParams>
			</RowDblClick>
		</DirectEvents>
		<Listeners>
			<Command Handler="Ext.net.DirectMethods.CargarVentanaAsignacion(record.data.IdEjecucionOT);" />
		</Listeners>--%>
	</ext:GridPanel>
	<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Cambio Masivo" Frame="true">
		<Content>
			<table style="padding-top:5px;">
				<tr>
						<td><b>Cuadrilla</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlCuadrillaFiltro" runat="server" Editable="true" 
											TypeAhead="true" 
											Mode="Local" 
											ForceSelection="true" 
											TriggerAction="All" DisplayField="Descripcion" ValueField="IdCuadrilla" EmptyText="[Seleccione]" Width="200px" ItemSelector="div.list-item">
								<Store>
									<ext:Store ID="StoreCuadrillaFiltro" runat="server">
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
								<Template ID="Template3" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
						</td>
						<td style="padding-left:15px;"><b>Estado</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlPEstado" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" EmptyText="[Seleccione]" Width="110px">
								<Store>
									<ext:Store ID="StoreEstado" runat="server">
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
						</td>
						<td style="padding-left:15px;">
							<ext:Button ID="Button1" runat="server" Text="Asignación Masiva" Icon="PackageGo">
								<DirectEvents>
									<Click OnEvent="btnAsignar_Click">
										<EventMask ShowMask="true" Msg="Procesando Datos" />
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
