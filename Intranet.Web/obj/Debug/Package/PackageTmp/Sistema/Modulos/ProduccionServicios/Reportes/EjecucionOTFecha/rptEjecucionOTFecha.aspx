﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptEjecucionOTFecha.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.EjecucionOTFecha.rptEjecucionOTFecha" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
								<%--<DirectEvents>
									<Select OnEvent="CargarCuadrillasFiltro"></Select>
								</DirectEvents>--%>
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

                        <%--<td style="padding-left:10px;">
                            <ext:Button ID="Button2" runat="server" Text="Imprimir" Icon="Printer">
                                <DirectEvents>
                                    <Click OnEvent="ImprimirReporte"></Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>--%>
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
							<ext:JsonReader IDProperty="Sgi">
								<Fields>
                                    <ext:RecordField Name="Sgi" />
                                    <ext:RecordField Name="NumeroOrden" />
                                    <ext:RecordField Name="Suministro" />
                                    <ext:RecordField Name="Estado" />
                                    <ext:RecordField Name="Direccion" />
                                    <ext:RecordField Name="Urbanizacion" />
                                    <ext:RecordField Name="Distrito" />
                                    <ext:RecordField Name="Cuadrilla" />
                                    <ext:RecordField Name="PuntajePrincipal" />
                                    <ext:RecordField Name="CuadReposicion" />
                                    <ext:RecordField Name="PuntajeReposicion" />
                                    <ext:RecordField Name="PuntajeTotal" />
                                    <ext:RecordField Name="FechaInicio" />
                                    <ext:RecordField Name="HoraInicio" />
                                    <ext:RecordField Name="FechaTermino" />
                                    <ext:RecordField Name="Horatermino" />
                                    <ext:RecordField Name="SubActividad" />
                                    <ext:RecordField Name="Diametro" />
                                    <ext:RecordField Name="Cantidad" />
                                    <ext:RecordField Name="Total" />       
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="Sgi" Header="SGI" DataIndex="Sgi" />
                        <ext:Column ColumnID="NumeroOrden" Header="NumeroOrden" DataIndex="NumeroOrden" />
                        <ext:Column ColumnID="Suministro" Header="NIS" DataIndex="Suministro" />
                        <ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" />
                        <ext:Column ColumnID="Direccion" Header="Dirección" DataIndex="Direccion" />
                        <ext:Column ColumnID="Urbanizacion" Header="Urbanización" DataIndex="Urbanizacion" />
                        <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" />
                        <ext:Column ColumnID="FechaInicio" Header="Fec. Inicio" DataIndex="FechaInicio" />
                        <ext:Column ColumnID="HoraInicio" Header="Hora Inicio" DataIndex="HoraInicio" />
                        <ext:Column ColumnID="FechaTermino" Header="Fec. Termino" DataIndex="FechaTermino" />
                        <ext:Column ColumnID="Horatermino" Header="Hora Término" DataIndex="Horatermino" />
                        <ext:Column ColumnID="SubActividad" Header="Sub-Actividad" DataIndex="SubActividad" />
                        <ext:Column ColumnID="Cuadrilla" Header="Cuadrilla Pincipal" DataIndex="Cuadrilla" />
                        <ext:Column ColumnID="PuntajePrincipal"  Header="Puntaje Principal" DataIndex="PuntajePrincipal" />
                        <ext:Column ColumnID="CuadReposicion"  Header="Cuadrilla Reposición" DataIndex="CuadReposicion" />
                        <ext:Column ColumnID="PuntajeReposicion"  Header="Puntaje Reposición" DataIndex="PuntajeReposicion" />
                        <ext:Column ColumnID="PuntajeTotal"  Header="Puntaje Total" DataIndex="PuntajeTotal" />
                        <ext:Column ColumnID="Diametro" Header="Diámetro" DataIndex="Diametro" />
                        <ext:Column ColumnID="Cantidad" Header="Cantidad" DataIndex="Cantidad" />
                        <ext:Column ColumnID="Total" Header="Total" DataIndex="Total" />   
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
