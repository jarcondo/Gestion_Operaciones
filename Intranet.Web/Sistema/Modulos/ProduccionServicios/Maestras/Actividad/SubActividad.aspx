<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubActividad.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Actividad.SubActividad" %>
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
		function Cancelar() {
			Ext.getCmp('GridPanel1').enable();
			Ext.getCmp('BtnGrabar').hide();
			Ext.getCmp('btnNuevo').show();
			Ext.getCmp('Button1').show();
			Ext.getCmp('btnCancelar').hide();
			Ext.getCmp('CodigoSubActividadField').disable();
		}

		function Nuevo() {
			Ext.getCmp('CodigoSubActividadField').enable();
			Ext.getCmp('GridPanel1').disable();
			Ext.get('CodMapField').dom.value = "";
			Ext.get('DescripcionSubActividad1Field').dom.value = "";
			Ext.get('DescripcionSubActividad2Field').dom.value = "";
			Ext.get('UnidadField').dom.value = "";
			Ext.get('CostoProgramadoField').dom.value = "";
			Ext.get('PuntajeField').dom.value = "";
			Ext.get('ObservacionField').dom.value = "";
			Ext.get('TrabajoComplementarioField').dom.value = "";
			Ext.get('ResaneField').dom.value = "";

			Ext.getCmp('BtnGrabar').show();
			Ext.getCmp('Button1').hide();
			Ext.getCmp('btnCancelar').show();
			Ext.getCmp('btnNuevo').hide();
			document.getElementById("CodigoSubActividadField").focus();
		}

		function Eliminar(comando, idregistro) {
			if (comando != 'Edit') {
				Ext.Msg.confirm('Confirmación', 'Se eliminará el registro: ' + idregistro + ' , esta seguro?', function (btn, text) {
					if (btn == 'yes') {
						Ext.net.DirectMethods.Eliminar(idregistro);
					} else {

					}
				});
			}
		}

		function btn_Actualizar() {
			var idregistro = Ext.get('IdSubActividadField').dom.value;
			if (idregistro != "") {
				Ext.Msg.confirm('Confirmación', 'Se actualizará el registro: ' + idregistro + ' , esta seguro?', function (btn, text) {
					if (btn == 'yes') {
						Ext.net.DirectMethods.ActualizarActividad(idregistro);
					} else {

					}
				});
			}
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
	<ext:ResourceManager ID="ResourceManager1" runat="server" />
	<ext:Store ID="StoreSubActividad" runat="server" SerializationMode="Complex">
        <Reader>
            <ext:JsonReader>
				<Fields>
					<ext:RecordField Name="IdSubActividad" />
                    <ext:RecordField Name="CodigoSubActividad" />
					<ext:RecordField Name="CodMap" />
					<ext:RecordField Name="Actividad" />
					<ext:RecordField Name="DescripcionSubActividad1" />
					<ext:RecordField Name="DescripcionSubActividad2" />
					<ext:RecordField Name="Unidad" />
					<ext:RecordField Name="CostoProgramado" />
					<ext:RecordField Name="Puntaje" />
					<ext:RecordField Name="TTeorico" />
                    <ext:RecordField Name="Observacion" />
					<ext:RecordField Name="TrabajoComplementario" />
                    <ext:RecordField Name="Resane" />
				</Fields>
			</ext:JsonReader>
		</Reader>
    </ext:Store>
    <ext:Panel ID="Panel1" runat="server" Width="900" Height="550">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
					<North>
						<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Frame="true">
							<Content>
								<table>
									<tr>
										<td><b>Local</b></td>
										<td style="padding-left:5px;">
											<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione Obra]" Width="250">
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
										<td style="width:20px;"></td>
										<td><b>Actividad</b></td>
										<td style="padding-left:5px;">
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
												<Template ID="Template1" runat="server">
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
									</tr>
								</table>
								<br />
							</Content>
						</ext:Panel>
					</North>
                    <West>
						<ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="StoreSubActividad" 
                            StripeRows="true"
                            Title="Registros" 
                            TrackMouseOver="true"
                            Width="630" 
                            AutoExpandColumn="IdSubActividad">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
									
									<ext:CommandColumn Width="30">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                        </Commands>
                                    </ext:CommandColumn>
                                    <ext:Column ColumnID="IdSubActividad" Width="100" DataIndex="IdSubActividad" Hidden="true" />
                                    <ext:Column  Header="Código" Width="80" DataIndex="CodigoSubActividad" />
									<ext:Column  Header="Cod. SGIO" Width="70" DataIndex="CodMap" />
                                    <ext:Column Header="Descripción 1" Width="300" DataIndex="DescripcionSubActividad1" />
									<ext:Column Header="Descripción 2" Width="300" DataIndex="DescripcionSubActividad2" />
                                </Columns>
                            </ColumnModel> 
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>     
                            <Listeners>
                                <Command Handler="Eliminar(command, record.data.IdSubActividad);" />
                            </Listeners>

                        </ext:GridPanel>
					</West>
					<center>
						<ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Right">
                            <Items>
								<ext:TextField ID="IdSubActividadField" DataIndex="IdSubActividad" runat="server" FieldLabel=" " AnchorHorizontal="100%" Hidden="true" />
                                <ext:TextField ID="CodigoSubActividadField" DataIndex="CodigoSubActividad" runat="server" FieldLabel="Código" AnchorHorizontal="100%" AllowBlank="false" />
								<ext:TextField ID="CodMapField" DataIndex="CodMap" runat="server" FieldLabel="Cod. SGIO" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextArea ID="DescripcionSubActividad1Field" DataIndex="DescripcionSubActividad1" runat="server" FieldLabel="Descripcion" AnchorHorizontal="100%" Height="70">
								</ext:TextArea>
								<ext:TextArea ID="DescripcionSubActividad2Field" DataIndex="DescripcionSubActividad2" runat="server" FieldLabel="Descripcion" AnchorHorizontal="100%" Height="70">
								</ext:TextArea>
								<ext:TextField ID="UnidadField" DataIndex="Unidad" runat="server" FieldLabel="Unidad" AnchorHorizontal="100%" AllowBlank="false" />
								<ext:TextField ID="CostoProgramadoField" DataIndex="CostoProgramado" runat="server" FieldLabel="Precio" AnchorHorizontal="100%" AllowBlank="false" />
								<ext:TextField ID="PuntajeField" DataIndex="Puntaje" runat="server" FieldLabel="Puntaje" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextField ID="tteoricold" DataIndex="TTeorico" runat="server" FieldLabel="T. Teorico Resolucion" AnchorHorizontal="100%" AllowBlank="false" />
								<ext:TextArea ID="ObservacionField" DataIndex="Observacion" runat="server" FieldLabel="Observación" AnchorHorizontal="100%" Height="70">
								</ext:TextArea>
								<ext:Checkbox ID="TrabajoComplementarioField" DataIndex="TrabajoComplementario" FieldLabel="Trab. Comp." runat="server">
								</ext:Checkbox>
                                <ext:Checkbox ID="ResaneField" DataIndex="Resane" FieldLabel="Resane" runat="server">
								</ext:Checkbox>

                            </Items>
                            <Buttons>
                                <ext:Button ID="Button1" runat="server" Text="Actualizar" Icon="DatabaseGo">
									<Listeners>
										<Click Fn="btn_Actualizar"></Click>
									</Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnGrabar" runat="server" Text="Grabar" Icon="Disk" OnDirectClick="btnGrabar_Click">
                                </ext:Button>
                                <ext:Button runat="server" ID="btnCancelar" Text="Cancelar" Icon="Cancel">
									<Listeners>
										<Click Fn="Cancelar"></Click>
                                    </Listeners>
								</ext:Button>   
                                <ext:Button runat="server" ID="btnNuevo" Text="Nuevo" Icon="Add" >
									<Listeners>
										<Click Fn="Nuevo"></Click>
									</Listeners>
								</ext:Button> 
                            </Buttons>
                        </ext:FormPanel>
					</center>
				</ext:BorderLayout>
			</Items>
		</ext:Panel>
    </form>
</body>
</html>
