<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCargoOTChorrillos.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.AlcantarilladoD.rptCargoOTChorrillos" %>
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
                        <td style="padding-left:5px;" colspan="2">
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
                                    <Select OnEvent="CargosPorObra"></Select>
                                </DirectEvents>
						    </ext:ComboBox>
                        </td>
                        <td></td>
                        <td style="padding-left:15px;"><b>Ordenar Por</b></td>
                        <td style="padding-left:5px;">
                            <ext:RadioGroup ID="RadioGroup1" runat="server">
								<Items>
									<ext:Radio ID="rCuadrilla" runat="server" BoxLabel="Cuadrilla" BoxLabelStyle="padding-right:15px;" Checked="true" />
									<ext:Radio ID="rIngreso" runat="server" BoxLabel="Ingreso" BoxLabelStyle="padding-right:15px;" />
								</Items>
							</ext:RadioGroup>
                        </td>
                        <td style="padding-left:15px;">
                            <ext:Button ID="btnProcesar" runat="server" Text="Procesar" Icon="ApplicationGo" Hidden="true">
                               
                            </ext:Button>
                        </td>
                    </tr>
					<tr>
                        <td><b>Cargo</b></td>
                        <td style="padding-left:5px;">
                            <ext:ComboBox ID="ddlCargo" runat="server" DisplayField="NombreCargo" ValueField="IdCargoEntrega" Width="150px"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All">
								<Store>
									<ext:Store ID="StoreCargo" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCargoEntrega">
												<Fields>
                                                    <ext:RecordField Name="IdCargoEntrega" /> 
													<ext:RecordField Name="NombreCargo" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
                                <%--<DirectEvents>
                                    <Select OnEvent="CargaCargosSGI"></Select>
                                </DirectEvents>--%>
							</ext:ComboBox>
                        </td>
						<td style="padding-left:15px;"><b>Área</b></td>
                        <td style="padding-left:5px;">
                            <ext:ComboBox ID="ddlArea" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="150px">
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
								<DirectEvents>
									<Select OnEvent="CargarResponsablePorArea"></Select>
								</DirectEvents>
							</ext:ComboBox>
                        </td>
                        <td style="padding-left:15px;"><b>Responsable</b></td>
                        <td style="padding-left:5px;">
                            <ext:ComboBox ID="ddlResponsable" runat="server" DisplayField="NombresApellidos" ValueField="IdEmpleado" Width="200px">
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
								<%--<DirectEvents>
									<Select OnEvent="CargarCuadrillaPorResponsable"></Select>
								</DirectEvents>--%>
							</ext:ComboBox>
                        </td>
						<%--<td style="padding-left:5px;">
							
						</td>--%>
                        <td style="padding-left:15px;">
                            <ext:Button ID="Button1" runat="server" Text="Ver Cargo" Icon="Vcard">
                                <DirectEvents>
                                    <Click OnEvent="DObtenerDatosGrilla" Timeout="1200000" >
                                    <EventMask ShowMask="true" Msg="Cargando Datos" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
					</tr>
                </table>
            </Content>
        </ext:Panel>
        <ext:Hidden ID="GridData" runat="server" />
        <ext:GridPanel 
		ID="GridPanel1" 
		runat="server" 
        Height="400px">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button4" runat="server" Text="Exportar A Excel" AutoPostBack="true" OnClick="ToExcel" Icon="PageExcel">
                            <Listeners>
                                <Click Fn="saveData" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
		    <Store>
			    <ext:Store ID="StoreCargoSGI" runat="server">
				    <Reader>
					    <ext:JsonReader IDProperty="Nro">
						    <Fields>
							    <ext:RecordField Name="sgi" />
                                <ext:RecordField Name="Suministro" />
                                <ext:RecordField Name="FechaDigitacion" />
                                <ext:RecordField Name="DescEstado" />
                                <ext:RecordField Name="Actividad" />
                                <ext:RecordField Name="SubActividad" />
                                <ext:RecordField Name="Direccion" />
                                <ext:RecordField Name="Distrito" />
                                <ext:RecordField Name="Cserv" />
                                <ext:RecordField Name="NroOrden" />
                                <ext:RecordField Name="FechaInicio" />
                                <ext:RecordField Name="Sca" />
                                <ext:RecordField Name="CostoOT" />
                                <ext:RecordField Name="Diferencia" />
						    </Fields>
					    </ext:JsonReader>
				    </Reader>
			    </ext:Store>
		    </Store>
	        <ColumnModel ID="ColumnModel3" runat="server">
		        <Columns>
                    <ext:Column ColumnID="sgi" Header="SGI" DataIndex="sgi" Width="70px" />
                    <ext:Column ColumnID="Suministro" Header="NIS" DataIndex="Suministro" Width="70px" />
                    <ext:Column ColumnID="FechaDigitacion" Header="Fecha Digitación" DataIndex="FechaDigitacion" Width="70px" />
                    <ext:Column ColumnID="SUBACTIVIDAD" Header="SUBACTIVIDAD" DataIndex="SUBACTIVIDAD" Width="70px" Hidden="true" />
                    <ext:Column ColumnID="DescEstado" Header="Estado" DataIndex="DescEstado" Width="70px" />
                    <ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="80px" />
                    <ext:Column ColumnID="SubActividad" Header="SubActividad" DataIndex="SubActividad" Width="150px" Hidden="true" />
                    <ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="200px" Hidden="true" />
                    <ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="70px" />
                    <ext:Column ColumnID="Cserv" Header="C. Serv" DataIndex="Cserv" Width="70px" />
                    <ext:Column ColumnID="NroOrden" Header="N OT" DataIndex="NroOrden" Width="80px" />
                    <ext:Column ColumnID="FechaInicio" Header="FechaInicio" DataIndex="FechaInicio" Width="70px" />
                    <ext:Column ColumnID="Sca" Header="SCA" DataIndex="Sca" Width="70px" />
                    <ext:Column ColumnID="CostoOT" Header="SGIO" DataIndex="CostoOT" Width="70px" />
                    <ext:Column ColumnID="Diferencia" Header="Diferencia" DataIndex="Diferencia" Width="70px">
                    </ext:Column>
		        </Columns>
	        </ColumnModel>
        </ext:GridPanel>
          
        </form>
</body>
</html>


