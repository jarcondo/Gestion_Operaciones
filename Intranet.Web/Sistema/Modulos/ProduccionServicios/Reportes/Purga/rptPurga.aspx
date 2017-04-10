<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPurga.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Purga.rptPurga" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var FnObtenerDatosGrilla = function () {
            Ext.net.DirectMethods.ObtenerDatosGrilla();
        }

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
							</ext:ComboBox>
						</td>
					    <td style="padding-left:30px;"><b>Fecha</b></td>
                        <td style="padding-left:10px;">Desde</td>
					    <td style="padding-left:5px;">
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
                        <td style="padding-left:15px;">Hasta</td>
					    <td style="padding-left:5px;">
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
                        <td style="padding-left:30px;">
                            <ext:Button ID="Button1" runat="server" Text="Ver Datos" Icon="Find">
                                <%--<Listeners>
                                    <Click Fn="FnObtenerDatosGrilla" />
                                </Listeners>--%>
                                <DirectEvents>
                                    <Click OnEvent="DObtenerDatosGrilla" Timeout="0">
                                        <EventMask ShowMask="true" />
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
					<ext:Store ID="StoreReporteBuzonesMaquinaBalde" runat="server">
						<Reader>
							<ext:JsonReader IDProperty="Nro">
								<Fields>
                                    <ext:RecordField Name="sgi" />
                                    <ext:RecordField Name="Sector" />
                                    <ext:RecordField Name="Suministro" />
                                    <ext:RecordField Name="FechaInicio" />
                                    <ext:RecordField Name="Direccion" />
                                    <ext:RecordField Name="Urbanizacion" />
                                    <ext:RecordField Name="Distrito" />
                                    <ext:RecordField Name="TiempoPurga" />
                                    <ext:RecordField Name="Presion" />
                                    <ext:RecordField Name="Cloro" />
                                    <ext:RecordField Name="ANF" />
                                    <ext:RecordField Name="OpPrevMayor" />
                                    <ext:RecordField Name="OpPrevMenor" />
                                    <ext:RecordField Name="InopCorrectivo" />
                                    <ext:RecordField Name="InopCambio" />
                                    <ext:RecordField Name="Marca" />
                                    <ext:RecordField Name="NroBocas" />
                                    <ext:RecordField Name="NroTapas" />
                                    <ext:RecordField Name="CGI" />
                                    <ext:RecordField Name="Ubica" />
                                    <ext:RecordField Name="SinMyT" />
                                    <ext:RecordField Name="LosaDeteriorada" />
                                    <ext:RecordField Name="MantSi" />
                                    <ext:RecordField Name="MantNo" />
                                    <ext:RecordField Name="CaracteristicaAgua" />
                                    <ext:RecordField Name="ColorAgua" />
                                    <ext:RecordField Name="DescargaEn" />
                                    <ext:RecordField Name="DistanciaDescarga" />
                                    <ext:RecordField Name="Observacion" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="Direccion" Header="Dirección" DataIndex="Direccion" />
                        <ext:Column ColumnID="Urbanizacion" Header="Localidad" DataIndex="Urbanizacion" />
                        <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" />
                        <ext:Column ColumnID="sgi" Header="SGI" DataIndex="sgi" />
                        <ext:Column ColumnID="Suministro" Header="NIS" DataIndex="Suministro" />
                        <ext:Column ColumnID="Sector" Header="Sector" DataIndex="Sector" />
                        <ext:Column ColumnID="FechaInicio" Header="Fec. Inicio" DataIndex="FechaInicio" />
                        <ext:Column ColumnID="TiempoPurga" Header="Tiempo Purgado (min)" DataIndex="TiempoPurga" />
                        <ext:Column ColumnID="Presion" Header="Presión (PSI)" DataIndex="Presion" />
                        <ext:Column ColumnID="Cloro" Header="Cloro (PPM)" DataIndex="Cloro" />
                        <ext:Column ColumnID="ANF" Header="ANF (m3)" DataIndex="ANF" />
                        <ext:Column ColumnID="OpPrevMayor" Header="Op. Prev. May." DataIndex="OpPrevMayor" />
                        <ext:Column ColumnID="OpPrevMenor" Header="Op. Prev. Men." DataIndex="OpPrevMenor" />
                        <ext:Column ColumnID="InopCorrectivo" Header="Inop. Correc." DataIndex="InopCorrectivo" />
                        <ext:Column ColumnID="InopCambio" Header="Inop. Cambio" DataIndex="InopCambio" />
                        <ext:Column ColumnID="Marca" Header="Marca" DataIndex="Marca" />
                        <ext:Column ColumnID="NroBocas" Header="N° Bocas" DataIndex="NroBocas" />
                        <ext:Column ColumnID="NroTapas" Header="N° Tapas" DataIndex="NroTapas" />
                        <ext:Column ColumnID="CGI" Header="Cuerpo" DataIndex="CGI" />
                        <ext:Column ColumnID="Ubica" Header="No se Ubica" DataIndex="Ubica" />
                        <ext:Column ColumnID="SinMyT" Header="Sin MyT" DataIndex="SinMyT" />
                        <ext:Column ColumnID="LosaDeteriorada" Header="Losa Deteriorada" DataIndex="LosaDeteriorada" />
                        <ext:Column ColumnID="MantSi" Header="Mant. Si" DataIndex="MantSi" />
                        <ext:Column ColumnID="MantNo" Header="Mant. No" DataIndex="MantNo" />
                        <ext:Column ColumnID="CaracteristicaAgua" Header="Caracteris. Agua" DataIndex="CaracteristicaAgua" />
                        <ext:Column ColumnID="ColorAgua" Header="Color Agua" DataIndex="ColorAgua" />
                        <ext:Column ColumnID="DescargaEn" Header="Descarga En" DataIndex="DescargaEn" />
                        <ext:Column ColumnID="DistanciaDescarga" Header="Distancia Apóx." DataIndex="DistanciaDescarga" />
                        <ext:Column ColumnID="Observacion" Header="Observación" DataIndex="Observacion" />
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            <ext:Label ID="lblConteo" runat="server" StyleSpec="font-size:11px;font-weight:bold;font-family:verdana">
            </ext:Label>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>



