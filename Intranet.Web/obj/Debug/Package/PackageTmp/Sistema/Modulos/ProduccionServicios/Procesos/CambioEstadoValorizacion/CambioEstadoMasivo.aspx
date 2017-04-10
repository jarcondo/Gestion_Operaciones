<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioEstadoMasivo.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CambioEstadoMasivo" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var FnIngresarValorizacion = function() {
            Ext.net.DirectMethods.btnIngresaValorizacion_Click();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Cambio Masivo de Estado para Valorización" Frame="true">
			<Content>
                <ext:Hidden ID="hdnArchivo" runat="server">
                </ext:Hidden>
                <table>
                    <tr>
                        <td><b>Obra</b></td>
                        <td style=" padding-left:5px;">
                            <ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione Obra]" Width="200px">
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
                                    <Select OnEvent="CargaValorizacionObra"></Select>
                                </DirectEvents>
							</ext:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Archivo</b></td>
                        <td style=" padding-left:5px;">
                            <input id="fupDetalle" type="file" class="x-form-text x-form-field" style="width:400px;height:22px;" runat="server" />
                        </td>
                        <td style=" padding-left:10px;">
                            <ext:Button ID="Button1" runat="server" Text="Cargar Archivo" Icon="DatabaseAdd">
								<DirectEvents>
									<Click OnEvent="btnCargar_DirectClick" Timeout="1200000">
										<EventMask ShowMask="true" Msg="Cargando datos" />
									</Click>
								</DirectEvents>
							</ext:Button>
                        </td>
                    </tr>
                </table>
            </Content>
        </ext:Panel>
        <ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Cambio Masivo de Estado para Valorización" Frame="true">
			<Content>
                <table>
                    <tr>
                        <td style=" vertical-align:top;" rowspan="4">
                            <ext:GridPanel 
				                ID="GridPanel1" 
				                runat="server" 
                                width="310"
                                Height="250px"
				                >
				                    <Store>
                                        <ext:Store ID="StoreCarga" runat="server">
			                                <Reader>
				                                <ext:JsonReader IDProperty="sgi">
					                                <Fields>
						                                <ext:RecordField Name="sgi" />
						                                <ext:RecordField Name="descripcion" />
					                                </Fields>
				                                </ext:JsonReader>
			                                </Reader>
		                                </ext:Store>
				                    </Store>
				                    <ColumnModel ID="ColumnModel1" runat="server">
					                    <Columns>
                                            
                                            <ext:Column ColumnID="sgi" Header="SGI" DataIndex="sgi" Width="70px" />
						                    <ext:Column ColumnID="descripcion" Header="" DataIndex="descripcion" Width="230px" />
					                    </Columns>
				                    </ColumnModel>
				                <LoadMask ShowMask="true"/>
				                <SaveMask ShowMask="true" />
			                </ext:GridPanel>
                        </td>
                        <td style="padding-left:30px;">
                            <b>Cambiar a Estado</b>
                        </td>
                        <td style=" padding-left:5px;">
                            <ext:ComboBox ID="ddlEstadoOT" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="110px">
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
                        <td></td>
                    </tr>
                    <tr>
                        <td style="padding-left:30px; padding-top:5px;">
                            <b>N° de Valorización</b>
                        </td>
                        <td style=" padding-left:5px; padding-top:5px;">
                            <ext:ComboBox ID="ddlValorizacion" runat="server" DisplayField="Descripcion" ValueField="IdValorizacion" Width="210px">
								<Store>
									<ext:Store ID="StoreValor" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdValorizacion">
												<Fields>
													<ext:RecordField Name="IdValorizacion" />
													<ext:RecordField Name="Descripcion" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
							</ext:ComboBox>
                        </td>
                        <td style="padding-left:5px;padding-top:5px;">
                            <ext:Button ID="Button3" runat="server" Text="" Icon="Add" ToolTip="Nueva Valorización" ToolTipType="Qtip">
                                <Listeners>
                                    <Click Handler="#{Window1}.show();" />
                                </Listeners>
							</ext:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style=" padding-top:5px;"></td>
                        <td style=" padding-left:5px; padding-top:5px;">
                            <ext:Button ID="Button2" runat="server" Text="Cambiar Estado" Icon="DatabaseEdit">
								<DirectEvents>
									<Click OnEvent="btnCambiarEstado_Click" Timeout="1200000">
										<EventMask ShowMask="true" Msg="Cargando datos" />
									</Click>
								</DirectEvents>
							</ext:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:200px;"></td>
                        <td></td>
                    </tr>
                </table>
            </Content>
        </ext:Panel>

        <%--VENTANA DE CREACIÓN DE VALORIZACIÓN--%>

        <ext:Window 
            ID="Window1" 
            runat="server" 
            Icon="LinkAdd" 
            Title="Ingreso de Nueva Valorización" 
            Hidden="true" 
            Modal="true" 
			Width="520px" AutoHeight="true">
            <TopBar>
                <ext:Toolbar ID="barraValorizacion" runat="server">
                    <Items>
                        <ext:Button ID="btnIngresaCargo" Icon="Disk" runat="server" Text="Agregar">
				            <Listeners>
                                <Click Fn="FnIngresarValorizacion" />
                            </Listeners>
			            </ext:Button>
                        <ext:Button ID="Button4" Icon="Cancel" runat="server" Text="Cancelar">
				            <%--<DirectEvents>
					            <Click OnEvent="btnIngresaCargo_Click"></Click>
				            </DirectEvents>--%>
			            </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
			<Content>
                <br />
                <table>
                    <tr>
                        <td style="padding-left:5px;">Código</td>
                        <td style="padding-left:5px;" colspan="3">
                            <ext:TextField ID="txtCodigo" runat="server" Width="30">
                            </ext:TextField>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:5px;">Descripción</td>
                        <td style="padding-left:5px;" colspan="3">
                            <ext:TextField ID="txtDescripcion" runat="server" Width="270">
                            </ext:TextField>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:5px;">Fecha Inicio</td>
                        <td style="padding-left:5px;">
                            <ext:DateField ID="DateField1" runat="server">
                            </ext:DateField>
                        </td>
                        <td style="padding-left:5px;">Fecha Fin</td>
                        <td style="padding-left:5px;">
                            <ext:DateField ID="DateField2" runat="server">
                            </ext:DateField>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:5px;">Fecha Valorización</td>
                        <td style="padding-left:5px;">
                            <ext:DateField ID="DateField3" runat="server">
                            </ext:DateField>
                        </td>
                        <td></td>
                        <td style="padding-left:40px;">
                            
                        </td>
                    </tr>
                </table>
                <br />
                <ext:GridPanel 
				ID="GridPanel2" 
				runat="server" 
                Height="200px"
				>
				    <Store>
					    <ext:Store ID="StoreValorizacion" runat="server">
						    <Reader>
							    <ext:JsonReader IDProperty="Descripcion">
								    <Fields>
                                        <ext:RecordField Name="CodigoValorizacion" /> 
                                        <ext:RecordField Name="Descripcion" /> 
                                        <ext:RecordField Name="FechaInicio" /> 
                                        <ext:RecordField Name="FechaFin" /> 
                                        <ext:RecordField Name="FechaValorizacion" /> 
								    </Fields>
							    </ext:JsonReader>
						    </Reader>
					    </ext:Store>
				    </Store>
				    <ColumnModel ID="ColumnModel3" runat="server">
					    <Columns>
                            <ext:Column ColumnID="CodigoValorizacion" Header="Fecha" DataIndex="CodigoValorizacion" />
						    <ext:Column ColumnID="Descripcion" Header="Descripción" DataIndex="Descripcion" />
                            <ext:Column ColumnID="FechaInicio" Header="Fec. Inicio" DataIndex="FechaInicio" />
                            <ext:Column ColumnID="FechaFin" Header="Fec. Fin" DataIndex="FechaFin" />
                            <ext:Column ColumnID="FechaValorizacion" Header="Fec. Valorizacion" DataIndex="FechaValorizacion" />
					    </Columns>
				    </ColumnModel>
				    <LoadMask ShowMask="true"/>
				    <SaveMask ShowMask="true" />
			    </ext:GridPanel>
            </Content>
        </ext:Window>
    </form>
</body>
</html>
