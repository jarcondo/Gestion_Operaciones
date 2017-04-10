<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDatosValorizacion.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.DatosValorizacion.rptDatosValorizacion" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
//        var FnObtenerDatosGrilla = function () {
//            Ext.net.DirectMethods.ObtenerDatosGrilla();
//        }

        var saveData = function () {
            GridData.setValue(Ext.encode(GridPanel1.getRowsValues({ selectedOnly: false })));
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
        
		<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Parámetros de Búsqueda" Frame="true">
			<Content>
                <table style="padding-top:5px;">
					<tr>
                        <td><b>Obra</b></td>
						<td style="padding-left:10px;">
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
                                    <Select OnEvent="CargarDatosValorizacion"></Select>
                                </DirectEvents>
							</ext:ComboBox>
						</td>
					    <td style="padding-left:30px;"><b>N° Valorización</b></td>
                        <td style="padding-left:10px;">
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
                        
                        <td style="padding-left:30px;">
                            <ext:Button ID="Button1" runat="server" Text="Ver Datos" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="DObtenerDatosGrilla">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>

                        <td style="padding-left:10px;">
                            <ext:Button ID="Button3" runat="server" Text="Existencia OT" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="DObtenerExistenciaOT">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                          </td>  
                          <td style="padding-left:10px;">
                            <ext:Button ID="Button4" runat="server" Text="Verificar Montos" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="DObtenerVerificarMontos">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            </td>  


				    </tr>
                     <tr>
                        <td><b>Archivo</b></td>
                        <td style=" padding-left:5px;">
                            <input id="fupDetalle" type="file" class="x-form-text x-form-field" style="width:400px;height:22px;" runat="server" />
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
                        <ext:Button ID="Button2" runat="server" Text="Exportar A Excel" AutoPostBack="true" OnClick="ToExcel" Icon="PageExcel">
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
							<ext:JsonReader IDProperty="ITEM">
								<Fields>
                                    <ext:RecordField Name="ITEM" />  
                                    <ext:RecordField Name="ENLACE" />  
                                    <ext:RecordField Name="CODIGO" />  
                                    <ext:RecordField Name="DESCRIP" />  
                                    <ext:RecordField Name="SumaDeCANTIDAD" />  
                                    <ext:RecordField Name="PRECIO_UNI" />  
                                    <ext:RecordField Name="Tipo" />  
                                    <ext:RecordField Name="NOMACTIVID" />  
                                    <ext:RecordField Name="UNIDAD" />  
                                    <ext:RecordField Name="SGI" />  

								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="ENLACE" Header="ENLACE" DataIndex="ENLACE" />
                        <ext:Column ColumnID="CODIGO" Header="CÓDIGO" DataIndex="CODIGO" />
                        <ext:Column ColumnID="DESCRIP" Header="DESCRIPCIÓN" DataIndex="DESCRIP" Width="350" />
                        <ext:Column ColumnID="SumaDeCANTIDAD" Header="CANTIDAD" DataIndex="SumaDeCANTIDAD" />
                        <ext:Column ColumnID="PRECIO_UNI" Header="PREC. UNIT." DataIndex="PRECIO_UNI" />
                        <ext:Column ColumnID="Tipo" Header="TIPO" DataIndex="Tipo" />
                        <ext:Column ColumnID="NOMACTIVID" Header="ACTIVIDAD" DataIndex="NOMACTIVID" />
                        <ext:Column ColumnID="UNIDAD" Header="UNIDAD" DataIndex="UNIDAD" />
                        <ext:Column ColumnID="SGI" Header="SGI" DataIndex="SGI" />
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
