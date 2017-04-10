﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptEjecucionOTCuadrilla.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.EjecucionOTCuadrilla.rptEjecucionOTCuadrilla" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
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
                            <ext:Button ID="Button1" runat="server" Text="Ver Datos" Icon="Find" timeout="0" >
                                <%--<Listeners>
                                    <Click Fn="FnObtenerDatosGrilla" />
                                </Listeners>--%>
                                <DirectEvents>
                                <%--    <Click OnEvent="DObtenerDatosGrilla" Timeout="360000">--%>
                                    <Click OnEvent="DObtenerDatosGrilla" Timeout="0">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
                        <td style="padding-left:10px;">
                            <ext:Button ID="Button2" runat="server" Text="Imprimir" Icon="Printer">
                                <DirectEvents>
                                    <Click OnEvent="ImprimirReporte" Timeout="360000">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
                        <td>
                        <ext:Button ID="Button3" runat="server" Text="Reporte Detallado" Icon="Report">
                                <DirectEvents>
                                    <Click OnEvent="ReporteDetallado">
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
                Height="350px">
				<Store>
					<ext:Store ID="StoreEjecucionOT" runat="server">
						<Reader>
							<ext:JsonReader IDProperty="Cuadrilla">
								<Fields>
                                    <ext:RecordField Name="Cuadrilla" />
                                    <ext:RecordField Name="TotalSubAct" />
                                    <ext:RecordField Name="TotalMat" />
                                    <ext:RecordField Name="TotalRes" />
                                    <ext:RecordField Name="Total" />     
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="Cuadrilla" Header="Cuadrilla" DataIndex="Cuadrilla" />
                        <ext:Column ColumnID="SubActividad" Header="Sub-Actividad" DataIndex="TotalSubAct" />
                        <ext:Column ColumnID="Material" Header="Material" DataIndex="TotalMat" />
                        <ext:Column ColumnID="Resane" Header="Resane" DataIndex="TotalRes" />
                        <ext:Column ColumnID="Total" Header="Total" DataIndex="Total" />  
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
