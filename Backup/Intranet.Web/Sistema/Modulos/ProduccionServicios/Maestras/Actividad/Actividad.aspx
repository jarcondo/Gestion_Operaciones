<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actividad.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Actividad.Actividad" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script type="text/javascript">
		function Cancelar() {
			Ext.getCmp('GridPanel1').enable();
			Ext.getCmp('BtnGrabar').hide();
			Ext.getCmp('btnNuevo').show();
			Ext.getCmp('Button1').show();
			Ext.getCmp('btnCancelar').hide();
			Ext.getCmp('CodigoActividadField').disable();
		}

		function Nuevo() {
			Ext.getCmp('CodigoActividadField').enable();
			Ext.getCmp('GridPanel1').disable();
			Ext.get('CodMapField').dom.value = "";
			Ext.get('Descripcion1Field').dom.value = "";
			Ext.get('Descripcion2Field').dom.value = "";

			Ext.getCmp('BtnGrabar').show();
			Ext.getCmp('Button1').hide();
			Ext.getCmp('btnCancelar').show();
			Ext.getCmp('btnNuevo').hide();
			document.getElementById("CodigoActividadField").focus();
		}

		function Eliminar(comando, idregistro) {
			if (comando != 'Edit') {
				Ext.Msg.confirm('Confirmación', 'Se eliminará el registro:' + idregistro + ' , esta seguro?', function (btn, text) {
					if (btn == 'yes') {
						Ext.net.DirectMethods.Eliminar(idregistro);
					} else {

					}
				});
			}
		}

		function btn_Actualizar() {
			var idregistro = Ext.get('IdActividadField').dom.value;
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
		<ext:Store ID="StoreActividad" runat="server">
            <Reader>
                	<ext:JsonReader>
						<Fields>
							<ext:RecordField Name="IdActividad" />
                            <ext:RecordField Name="CodigoActividad" />
							<ext:RecordField Name="CodMap" />
							<ext:RecordField Name="Descripcion1" />
							<ext:RecordField Name="Descripcion2" />
						</Fields>
					</ext:JsonReader>
			</Reader>
        </ext:Store>
		<ext:Panel ID="Panel1" runat="server" Width="900" Height="400">
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
													<Select OnEvent="MostrarActividad"></Select>
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
                            StoreID="StoreActividad" 
                            StripeRows="true"
                            Title="Registros" 
                            TrackMouseOver="true"
                            Width="630" 
                            AutoExpandColumn="IdActividad">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
									
									<ext:CommandColumn Width="30">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                        </Commands>
                                    </ext:CommandColumn>
                                    <ext:Column ColumnID="IdActividad" Width="100" DataIndex="IdActividad" Hidden="true" />
                                    <ext:Column  Header="Código" Width="80" DataIndex="CodigoActividad" />
									<ext:Column  Header="Cod. SGIO" Width="70" DataIndex="CodMap" />
                                    <ext:Column Header="Descripcion Breve" Width="100" DataIndex="Descripcion1" />
									<ext:Column Header="Descripcion" Width="300" DataIndex="Descripcion2" />
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
                                <Command Handler="Eliminar(command, record.data.IdActividad);" />
                            </Listeners>

                        </ext:GridPanel>
					</West>
					<center>
						<ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Right">
                            <Items>
								<ext:TextField ID="IdActividadField" DataIndex="IdActividad" runat="server" FieldLabel=" " AnchorHorizontal="100%" Hidden="true" />
                                <ext:TextField ID="CodigoActividadField" DataIndex="CodigoActividad" runat="server" FieldLabel="Código" AnchorHorizontal="100%" AllowBlank="false" />
								<ext:TextField ID="CodMapField" DataIndex="CodMap" runat="server" FieldLabel="Cod. SGIO" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextField ID="Descripcion1Field" DataIndex="Descripcion1" runat="server" FieldLabel="Descripcion Breve" AnchorHorizontal="100%" />
								<ext:TextArea ID="Descripcion2Field" DataIndex="Descripcion2" runat="server" FieldLabel="Descripcion" AnchorHorizontal="100%" Height="200">
								</ext:TextArea>
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
