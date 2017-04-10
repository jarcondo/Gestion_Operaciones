<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTValorizacion.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.OTValorizacion.OTValorizacion" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <%--Probando--%>
<%--    <script type="text/javascript">
        var OcultarCampos = function () {
            var div = document.getElementById('SGI');
            div.style.display = 'none';
        }
    </script>--%>
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
							</ext:ComboBox>
						</td>     
                        <td style="padding-left:30px;">
                            <ext:Button ID="Button1" runat="server" Text="OT x Valorización" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="ReporteOTxValo">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                                <%--<Listeners>
                                <Click Fn="OcultarCampos" />
                            </Listeners>--%>
                            </ext:Button>
                        </td>

                        <td style="padding-left:10px;">
                            <ext:Button ID="Button3" runat="server" Text="OT x Distrito" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="ReporteOTxDist">
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
                        <td> 
                        <ext:Button ID="Button4" runat="server" Text="Ver Reporte" Icon="Report">
				        <DirectEvents>
					    <Click OnEvent="CargarReporte" Timeout="0">
                        </Click>
				        </DirectEvents>
			            </ext:Button> 
                        </td>
                        <td> </td>
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
				<Store>
					<ext:Store ID="StoreOT" runat="server">
						<Reader>
							<ext:JsonReader IDProperty="ITEM">
								<Fields>
                                    <ext:RecordField Name="SGI" />  
                                    <ext:RecordField Name="monto" />  
                                    <ext:RecordField Name="Actividad" />  
                                    <ext:RecordField Name="NumeroOrden" />  
                                    <ext:RecordField Name="FechaInicio" />  
                                    <ext:RecordField Name="Suministro" />  
                                    <ext:RecordField Name="Direccion" />  
                                    <ext:RecordField Name="Urbanizacion" />  
                                    <ext:RecordField Name="CodigoDistrito" />
                                    <ext:RecordField Name="DescSubAct" />
                                    <ext:RecordField Name="tipo" />
                                    <ext:RecordField Name="Chorrillos" />
                                    <ext:RecordField Name="Miraflores" />
                                    <ext:RecordField Name="Surco" />
                                    <ext:RecordField Name="SanBorja" />
                                    <ext:RecordField Name="Surquillo" />
                                    <ext:RecordField Name="SurcoViejo" />
                                    <ext:RecordField Name="Barranco" />
                                    <ext:RecordField Name="Lince" />
                                    <ext:RecordField Name="SanIsidro" />
                                    <ext:RecordField Name="Total" />
                                    <ext:RecordField Name="Unidad" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="SGI" Header="SGI" DataIndex="SGI" />
                        <ext:Column ColumnID="monto" Header="MONTO" DataIndex="monto" />
                        <ext:Column ColumnID="Actividad" Header="ACTIVIDAD" DataIndex="Actividad" Width="350" />
                        <ext:Column ColumnID="NumeroOrden" Header="NRO ORDEN" DataIndex="NumeroOrden" />
                        <ext:Column ColumnID="FechaInicio" Header="FECHA INICIO" DataIndex="FechaInicio" />
                        <ext:Column ColumnID="Suministro" Header="SUMINISTRO" DataIndex="Suministro" />
                        <ext:Column ColumnID="Direccion" Header="DIRECCION" DataIndex="Direccion" />
                        <ext:Column ColumnID="Urbanizacion" Header="URBANIZACION" DataIndex="Urbanizacion" />
                        <ext:Column ColumnID="CodigoDistrito" Header="DISTRITO" DataIndex="CodigoDistrito" />
                        <ext:Column ColumnID="DescSubAct" Header="SUB ACTIVIDAD" DataIndex="DescSubAct" />
                        <%--<ext:Column ColumnID="tipo" Header="TIPO" DataIndex="tipo" />--%>
                        <ext:Column ColumnID="Unidad" Header="UNIDAD" DataIndex="Unidad" />
                        <ext:Column ColumnID="Chorrillos" Header="CHORRILLOS" DataIndex="Chorrillos" />
                        <ext:Column ColumnID="Miraflores" Header="MIRAFLORES" DataIndex="Miraflores" />
                        <ext:Column ColumnID="Surco" Header="SURCO" DataIndex="Surco" />
                        <ext:Column ColumnID="Surquillo" Header="SURQUILLO" DataIndex="Surquillo" />
                        <ext:Column ColumnID="SanBorja" Header="SAN BORJA" DataIndex="SanBorja" />
                        <ext:Column ColumnID="Barranco" Header="BARRANCO" DataIndex="Barranco" />
                        <ext:Column ColumnID="Lince" Header="LINCE" DataIndex="Lince" />
                        <ext:Column ColumnID="SanIsidro" Header="SAN ISIDRO" DataIndex="SanIsidro" />
                        <ext:Column ColumnID="SurcoViejo" Header="SURCO VIEJO" DataIndex="SurcoViejo" />
                        <ext:Column ColumnID="Total" Header="TOTAL" DataIndex="Total" />
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
