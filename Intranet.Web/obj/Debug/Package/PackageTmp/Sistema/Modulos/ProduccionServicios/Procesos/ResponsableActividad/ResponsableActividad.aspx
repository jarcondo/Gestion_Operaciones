<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponsableActividad.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ResponsableActividad.ResponsableActividad" %>
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
	<script type="text/javascript">
		var ActividadRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.Descripcion1 + ' - ' + value.Descripcion2;
			}
			return value;
		};
		var AreaRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.A2;
			}
			return value;
		};
		var ResponsableRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.NombresApellidos;
			}
			return value;
		};

		function ManejarAsignacion(comando, idregistro) {
			if (comando == 'Delete') {
				Ext.Msg.confirm('Confirmación', 'Se eliminará el registro:' + idregistro + ' , esta seguro?', function (btn, text) {
					if (btn == 'yes') {
						Ext.net.DirectMethods.Eliminar(idregistro);
					} else {

					}
				});
			}
			if (comando == 'Edit') {
				Ext.net.DirectMethods.Editar(idregistro);
			}
		}
	</script>
	
</head>
<body>
    <form id="form1" runat="server">
	<ext:ResourceManager ID="ResourceManager1" runat="server">
	</ext:ResourceManager>
	<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Datos para Asignación" Frame="true">
		<TopBar>
			<ext:Toolbar runat="server">
				<items>
					<ext:Button ID="btnGuardar" runat="server" Text="Guardar" Icon="Disk">
						<DirectEvents>
							<Click OnEvent="GrabarAsignacion"></Click>
						</DirectEvents>
					</ext:Button>
					<ext:ToolbarSeparator></ext:ToolbarSeparator>
					<ext:Button ID="btnCancelar" runat="server" Text="Cancelar" Icon="Delete">
						<DirectEvents>
							<Click OnEvent="CancelarAsignacion"></Click>
						</DirectEvents>
					</ext:Button>
				</items>
			</ext:Toolbar>
		</TopBar>
		<Content>
			<table>
				<tr>
					<td><b>Local</b></td>
					<td style="padding-left:15px;">
						<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione Local]" Width="200px">
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
								<Select OnEvent="CargarActividad"></Select>
							</DirectEvents>
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b>Actividad</b></td>
					<td style="padding-left:15px;">
						<ext:Hidden ID="hdnIdRespAct" runat="server">
						</ext:Hidden>
						<ext:ComboBox ID="ddlActividad" runat="server" DisplayField="Descripcion1" ValueField="IdActividad" EmptyText="[Seleccione Actividad]" Width="300px"
						  ItemSelector="div.list-item">
							<Store>
								<ext:Store ID="StoreActividad" runat="server">
									<Reader>
										<ext:JsonReader IDProperty="IdActividad">
											<Fields>
												<ext:RecordField Name="IdActividad" />
												<ext:RecordField Name="CodigoActividad" />
												<ext:RecordField Name="Descripcion1" />
												<ext:RecordField Name="Descripcion2" />
											</Fields> 


										</ext:JsonReader>
									</Reader>
								</ext:Store>
							</Store>
							<Template runat="server">
								<Html>
									<tpl for=".">
										<div class="list-item">
											<b>{Descripcion1}</b> - {Descripcion2}
										</div>
									</tpl>
								</Html>
							</Template>
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b>Area</b></td>
					<td style="padding-left:15px;">
						<ext:ComboBox ID="ddlArea" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="150px" EmptyText="[Seleccione Area]">
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
						</ext:ComboBox>
					</td>
				</tr>
				<tr>
					<td><b>Responsable</b></td>
					<td style="padding-left:15px;">
						<ext:ComboBox ID="ddlResponsable" runat="server" DisplayField="NombresApellidos" ValueField="IdEmpleado" Width="300px" EmptyText="[Seleccione Responsable]">
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
			</table>
		</Content>
	</ext:Panel>
	<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Listado de Asignaciones">
		<Items>
			<ext:GridPanel ID="gpnAsignacion" runat="server" Height="250">
					<Store>
						<ext:Store ID="StoreAsignacion" runat="server" SerializationMode="Complex">
							<Reader>
								<ext:JsonReader IDProperty="IdResponsableActividad">
									<Fields>
										<ext:RecordField Name="IdResponsableActividad" /> 
										<ext:RecordField Name="Actividad" /> 
										<ext:RecordField Name="Area" /> 
										<ext:RecordField Name="Responsable" /> 
									</Fields>
								</ext:JsonReader>
							</Reader>
						</ext:Store>
					</Store>
					<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>
							<ext:CommandColumn Width="60">
                                <Commands>
                                    <ext:GridCommand Icon="Delete" CommandName="Delete">
                                        <ToolTip Text="Delete" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                        <ToolTip Text="Edit" />
                                    </ext:GridCommand>
                                </Commands>
                            </ext:CommandColumn>
							<ext:Column ColumnID="IdResponsableActividad" Header="IdResponsableActividad" DataIndex="IdResponsableActividad" Hidden="true"/>
							<ext:Column DataIndex="Actividad" Header="Actividad" Width="450">
								<Renderer Fn="ActividadRenderer" />
							</ext:Column>
							<ext:Column DataIndex="Area" Header="Area" Width="150px">
								<Renderer Fn="AreaRenderer" />
							</ext:Column>
							<ext:Column DataIndex="Responsable" Header="Responsable" Width="250px">
								<Renderer Fn="ResponsableRenderer" />
							</ext:Column>
						</Columns>
					</ColumnModel>
					<LoadMask ShowMask="true"/>
					<SaveMask ShowMask="true" />
					<Listeners>
                        <Command Handler="ManejarAsignacion(command, record.data.IdResponsableActividad);" />
                    </Listeners>
				</ext:GridPanel>
		</Items>
	</ext:Panel>
    </form>
	
	
</body>
</html>
