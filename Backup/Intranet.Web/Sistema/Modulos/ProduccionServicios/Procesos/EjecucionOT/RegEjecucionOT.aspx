<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegEjecucionOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT.RegEjecucionOT" %>
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
		<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Parámetros de Búsqueda" Frame="true">
			<TopBar>
				<ext:Toolbar ID="Toolbar2" runat="server">
					<Items>
						<ext:Button ID="Button1" runat="server" Text="Nueva O/T" Icon="Add">
							<DirectEvents>
								<Click OnEvent="AgregarNueva"></Click>
							</DirectEvents>
						</ext:Button>
					</Items>
				</ext:Toolbar>
			</TopBar>
			<Content>
				<table style="padding-top:5px;">
					<tr>
						<td><b>Local</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione local]" Width="300px">
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
						<td style="padding-left:15px;"><b></b></td>
						<td style="padding-left:5px;">
							<asp:TextBox ID="pNIS" runat="server" CssClass="x-form-text" Width="60px" Visible=false></asp:TextBox>
						</td>
						<td style="padding-left:15px;"><b>Fec. Alta</b></td>
						<td style="padding-left:5px;">
							<ext:DateField ID="Fecha" runat="server" Format="dd/MM/yyyy" />
						</td>
						<td style="padding-left:15px;">
							<ext:Button ID="btnBuscarTodos" runat="server" Text="Ver Todos" Icon="DatabaseGo" Width="100" >
							</ext:Button>
						</td>
					</tr>
					<tr>
						<td><b>Dirección</b></td>
						<td colspan="5" style="padding-left:5px;"><asp:TextBox ID="pDireccion" runat="server" CssClass="x-form-text" Width="470px"></asp:TextBox></td>
						<td style="padding-left:15px;">
							<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="100">
								<DirectEvents>
									<Click OnEvent="btnBuscar_Click" Timeout="0">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
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
				<ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                Height="350px"
				>
				<Store>
					<ext:Store ID="StoreEjecucionOT" runat="server">
						<Reader>
							<ext:JsonReader IDProperty="IdEjecucionOT">
								<Fields>
									<ext:RecordField Name="NroRegistro" />
									<ext:RecordField Name="IdEjecucionOT" /> 
									<ext:RecordField Name="NIS" />
									<ext:RecordField Name="Distrito" />
									<ext:RecordField Name="Direccion" />
									<ext:RecordField Name="Cliente" />
									<ext:RecordField Name="Actividad" />
									<ext:RecordField Name="Descripcion" />
									<ext:RecordField Name="FechaAlta" />
									<ext:RecordField Name="Estado" />
                                    <ext:RecordField Name="TipoTrabajo" />
                                     <ext:RecordField Name="SubActividad" />
                                    <ext:RecordField Name="FechaHoraIni" />
                                    <ext:RecordField Name="FechaHoraFin" />
                                    <ext:RecordField Name="Ingeniero" />
                                    <ext:RecordField Name="DesCuadrilla" />

								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="FechaAlta" Header="Fec. Alta" DataIndex="FechaAlta" Width="150px" />
                        <ext:Column ColumnID="TipoTrabajo" Header="TipoTrabajo" DataIndex="TipoTrabajo" Width="100px" />
                        <ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" Width="100px" />
                        <ext:Column ColumnID="Descripcion" Header="Observación" DataIndex="Descripcion" Width="300px" />

                        <ext:Column ColumnID="NroRegistro" Header="N° Orden Trabajo" DataIndex="NroRegistro" Width="120px" />
						<ext:Column ColumnID="IdEjecucionOT" Header="IdEjecucionOT" DataIndex="IdEjecucionOT" Hidden="true" />
						<ext:Column ColumnID="Cliente" Header="Cliente" DataIndex="Cliente" Width="150px" />
                        <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="150px" />
						<ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="300px" />
						<ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="180px" />
                        <ext:Column ColumnID="SubActividad" Header="SubActividad" DataIndex="SubActividad" Width="180px" />
						<ext:Column ColumnID="FechaHoraIni" Header="F.H. Inicio" DataIndex="FechaHoraIni" Width="130px" />
                        <ext:Column ColumnID="FechaHoraFin" Header="F.H. Fin" DataIndex="FechaHoraFin" Width="130px" />
						<ext:Column ColumnID="Ingeniero" Header="G. Operacion" DataIndex="Ingeniero" Width="150px" />
                        <ext:Column ColumnID="DesCuadrilla" Header="Asignado" DataIndex="DesCuadrilla" Width="220px" />
						
					</Columns>
				</ColumnModel>
				<LoadMask ShowMask="true"/>
				<SaveMask ShowMask="true" />
				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
				</SelectionModel>
				<DirectEvents>
					<RowDblClick OnEvent="RowDblClick_Event" Timeout="3600000">
						<ExtraParams>
							<ext:Parameter Name="IdEjecucionOT" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
						</ExtraParams>
					</RowDblClick>
				</DirectEvents>
			</ext:GridPanel>
			</Items>
		</ext:Panel>

		<ext:Window 
		ID="Window2" 
		runat="server" 
		IconCls="iconoCONCYSSA" 
		Width="930" 
		Height="280" 
		Modal="true"
		Hidden="true"
		Layout="Fit"
		Draggable="false">
		<Items>
			<ext:Panel ID="Panel6" runat="server" Frame="true">
				<TopBar>
					<ext:Toolbar ID="Toolbar3" runat="server">
						<Items>
							<ext:Button ID="Button2" runat="server" Text="Guardar" Icon="Disk">
								<DirectEvents>
									<Click OnEvent="GrabarNuevaOT"></Click>
								</DirectEvents>
							</ext:Button>
							<ext:ToolbarSeparator />
							<ext:Button ID="Button3" runat="server" Text="Cancelar" Icon="Delete">
								<DirectEvents>
									<Click OnEvent="CancelarNuevaOT"></Click>
								</DirectEvents>
							</ext:Button>
						</Items>
					</ext:Toolbar>
				</TopBar>
				<Content>
					<ext:Hidden ID="hdnIdEjecucionOT" runat="server">
					</ext:Hidden>
					<table style="padding-top:5px;">
						<tr>
							<td>
								<b><ext:Label ID="lblSGI" runat="server" Text="SGI" Visible=false></ext:Label></b>
							</td>
							<td style="padding-left:5px;">
								<ext:TextField ID="txtNSGI" runat="server" Width="80" Visible=false />
							</td>
						</tr>
						<tr>
							<td><b></b></td>
							<td style="padding-left:5px;">
								<ext:TextField ID="txtNNIS" runat="server" Width="80" Visible=false />
							</td>
							<td style="padding-left:15px;"><b></b></td>
							<td style="padding-left:5px;">
								<ext:ComboBox ID="ddlNDistrito" runat="server" DisplayField="Distrito" ValueField="Distrito" Width="200px" Hidden="true" EmptyText="[Seleccione Distrito]">
									<Store>
										<ext:Store ID="StoreNDistrito" runat="server">
											<Reader>
												<ext:JsonReader IDProperty="IdDistrito">
													<Fields>
														<ext:RecordField Name="IdDistrito" />
														<ext:RecordField Name="Distrito" />
													</Fields>
												</ext:JsonReader>
											</Reader>
										</ext:Store>
									</Store>
								</ext:ComboBox>
							</td>
							<td style="padding-left:15px;"><b></b></td>
							<td style="padding-left:5px;">
								<ext:TextField ID="txtNurbanizacion" runat="server" Width="250" Visible=false />
							</td>
						</tr>

                        <tr>
							<td><b>Cliente</b></td>
                            <td style="padding-left:5px;">
								<ext:ComboBox ID="ddlcliente" runat="server" DisplayField="Proveedor" ValueField="IdProveedor" Width="300px" EmptyText="[Seleccione Cliente]">
									<Store>
										<ext:Store ID="StoreCliente" runat="server">
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

						<tr>
							<td><b></b></td>
							<td style="padding-left:5px;" colspan="5">
								<ext:TextField ID="txtNDireccion" runat="server" Width="700" Hidden="true" />
							</td>
						</tr>
						<tr>
							<td><b>Actividad</b></td>
							<td style="padding-left:5px;" colspan="3">
								<ext:ComboBox ID="ddlNActividad" runat="server" DisplayField="Descripcion1" ValueField="CodMap" EmptyText="[Seleccione Actividad]" Width="300px"
									ItemSelector="div.list-item">
									<Store>
										<ext:Store ID="StoreNActividad" runat="server">
											<Reader>
												<ext:JsonReader IDProperty="IdActividad">
													<Fields>
														<ext:RecordField Name="IdActividad" />
														<ext:RecordField Name="CodMap" />
														<ext:RecordField Name="Descripcion1" />
														<ext:RecordField Name="Descripcion2" />
													</Fields> 
												</ext:JsonReader>
											</Reader>
										</ext:Store>
									</Store>
									<Template ID="Template2" runat="server">
										<Html>
											<tpl for=".">
												<div class="list-item">
													<b>{Descripcion1}</b> - {Descripcion2}
												</div>
											</tpl>
										</Html>
									</Template>
									<DirectEvents>
										<Select OnEvent="CargarSubActividad"></Select>
									</DirectEvents>
								</ext:ComboBox>
							</td>
							<td style="padding-left:15px;"><b>Sub-Actividad</b></td>
							<td style="padding-left:5px;">
								<ext:ComboBox ID="ddlNSubActividad" runat="server" DisplayField="DescripcionSubActividad1" ValueField="CodMap" EmptyText="[Seleccione SubActividad]" Width="250"
									ItemSelector="div.list-item"
									Editable="true" 
									TypeAhead="true" 
									Mode="Local" 
									ForceSelection="true" 
									TriggerAction="All" >
									<Store>
										<ext:Store ID="StoreNSubActividad" runat="server">
											<Reader>
												<ext:JsonReader IDProperty="IdSubActividad">
													<Fields>
														<ext:RecordField Name="IdSubActividad" />
														<ext:RecordField Name="CodMap" />
														<ext:RecordField Name="DescripcionSubActividad1" />
														<ext:RecordField Name="DescripcionSubActividad2" />
													</Fields> 
												</ext:JsonReader>
											</Reader>
										</ext:Store>
									</Store>
									<Template ID="Template3" runat="server">
										<Html>
											<tpl for=".">
												<div class="list-item">
													<%--<b>--%>{DescripcionSubActividad1}<%--</b>--%>
												</div>
											</tpl>
										</Html>
									</Template>
								</ext:ComboBox>
							</td>
						</tr>
						<tr>
							<td><b>Observación</b></td>
                            <td style="padding-left:5px;" colspan="5">
								<ext:TextArea ID="txtNObservacion" runat="server" Width="700" Height="44">
								</ext:TextArea>
							</td>
						</tr>

                        <tr>
                         <td><b></b></td>
                         <td><b style="color:Red;">***Recuerde colocar al inicio de la observacion su nombre y telefono celular. para consultas de nuestro equipo.</b></td>
                        </tr>
						
                        <tr>
							<td><b>Fec. Alta</b></td>
							<td style="padding-left:5px;" colspan="3">
								<ext:TextField ID="txtNFecAlta" runat="server" Width="200" />
							</td>
						</tr>
                        
                       <td style="padding-left:10px;"><b>Tipo Trab.</b></td>
										<td style="padding-left:10px;">
											<ext:ComboBox ID="ddlTipoTrabajo" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="180px">
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
					</table>
				</Content>
			</ext:Panel>
		</Items>
		</ext:Window>
    </form>
</body>
</html>
