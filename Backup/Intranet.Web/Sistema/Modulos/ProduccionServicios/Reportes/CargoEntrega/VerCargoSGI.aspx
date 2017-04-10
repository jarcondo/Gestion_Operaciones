<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCargoSGI.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.CargoEntrega.VerCargoSGI" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';
        var prepareCommand = function (grid, command, record, row) {
            // you can prepare group command
            if (command.command == 'Editar' && record.data.DIFERENCIA=='0') {
                command.hidden = true;
            } else {
                command.hidden = false;
            }
        };

        var change = function (value) {
            return String.format(template, (value != 0) ? "red" : "black", value);
        };

        var addTab = function (id, url, ntitle) {
            var tab = parent.tpMain.getComponent(id);

            if (!tab) {
                tab = parent.tpMain.add({
                    id: id,
                    title: ntitle,
                    closable: true,
                    iconCls: 'iconoCONCYSSA',
                    autoLoad: {
                        showMask: true,
                        url: url,
                        mode: "iframe",
                        maskMsg: "Cargando " + ntitle + "..."
                    }
                });

            }

            parent.tpMain.setActiveTab(tab);
        }

        var FnObtenerCargoEntrega = function () {
            Ext.net.DirectMethods.CargarCargoEntrega();
        };

        var saveData = function () {
            GridData.setValue(Ext.encode(GridPanel2.getRowsValues({ selectedOnly: false })));
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
                                    <Click OnEvent="CargarCargoEntrega" Timeout="1200000" >
                                    <EventMask ShowMask="true" Msg="Cargando Datos" />
                                    </Click>
                                </DirectEvents>
                              <%--  
                                <Listeners>
                                    <Click Fn="FnObtenerCargoEntrega"   />
                                    
                                </Listeners>--%>
                            
                            </ext:Button>
                        </td>
                        <td style="padding-left:15px;">
                            <ext:Button ID="Button2" runat="server" Text="Imprimir" Icon="Printer">
                                <DirectEvents>
                                    <Click OnEvent="ImprimirCargoEntrega" Timeout="1200000">
                                    <EventMask ShowMask="true" Msg="Cargando Datos" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
                        <td style="padding-left:15px;">
                            <ext:Button ID="Button3" runat="server" Text="Generar TXT" Icon="Note">
                                <DirectEvents>
                                    <Click OnEvent="GenerarTXTCargoEntrega"  Timeout="1200000" ></Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
					</tr>
                </table>
            </Content>
        </ext:Panel>
        <ext:Hidden ID="GridData" runat="server" />
        <ext:GridPanel 
		ID="GridPanel2" 
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
					    <ext:JsonReader IDProperty="SGI">
						    <Fields>
							    <ext:RecordField Name="Item" /> 
							    <ext:RecordField Name="SGI" />
                                <ext:RecordField Name="NIS" />
                                <ext:RecordField Name="ACTIVIDAD" />
                                <ext:RecordField Name="SUBACTIVIDAD" />
                                <ext:RecordField Name="ORDEN" />
                                <ext:RecordField Name="FechaEjecucion" />
                                <ext:RecordField Name="MUNICIPIO" />
                                <ext:RecordField Name="LOCALIDAD" />
                                <ext:RecordField Name="DIRECCION" />
                                <ext:RecordField Name="CUADRILLA" />
                                <ext:RecordField Name="DISTRITO" />
                                <ext:RecordField Name="FechaEmision" />
                                <ext:RecordField Name="ESTADO" />
                                <ext:RecordField Name="COSTO_SEDAPRO" />
                                <ext:RecordField Name="COSTO_OPEN" />
                                <ext:RecordField Name="DIFERENCIA" />
						    </Fields>
					    </ext:JsonReader>
				    </Reader>
			    </ext:Store>
		    </Store>
	        <ColumnModel ID="ColumnModel3" runat="server">
		        <Columns>
                    <ext:Column ColumnID="Item" Header="NRO" DataIndex="Item" Width="40px" />
                    <ext:Column ColumnID="SGI" Header="SGI" DataIndex="SGI" Width="70px" />
                    <ext:Column ColumnID="NIS" Header="NIS" DataIndex="NIS" Width="70px" />
                    <ext:Column ColumnID="ACTIVIDAD" Header="ACTIVIDAD" DataIndex="ACTIVIDAD" Width="70px" />
                    <ext:Column ColumnID="SUBACTIVIDAD" Header="SUBACTIVIDAD" DataIndex="SUBACTIVIDAD" Width="70px" Hidden="true" />
                    <ext:Column ColumnID="ORDEN" Header="ORDEN" DataIndex="ORDEN" Width="70px" />
                    <ext:Column ColumnID="FechaEjecucion" Header="FEC. EJECUCIÓN" DataIndex="FechaEjecucion" Width="80px" />
                    <ext:Column ColumnID="MUNICIPIO" Header="MUNICIPIO" DataIndex="MUNICIPIO" Width="150px" Hidden="true" />
                    <ext:Column ColumnID="LOCALIDAD" Header="LOCALIDAD" DataIndex="LOCALIDAD" Width="200px" Hidden="true" />
                    <ext:Column ColumnID="DIRECCION" Header="DIRECCIÓN" DataIndex="DIRECCION" Width="200px" />
                    <ext:Column ColumnID="CUADRILLA" Header="CUADRILLA" DataIndex="CUADRILLA" Width="70px" />
                    <ext:Column ColumnID="DISTRITO" Header="DISTRITO" DataIndex="DISTRITO" Width="70px" />
                    <ext:Column ColumnID="FechaEmision" Header="FEC. EMISIÓN" DataIndex="FechaEmision" Width="80px" />
                    <ext:Column ColumnID="ESTADO" Header="ESTADO" DataIndex="ESTADO" Width="70px" />
                    <ext:Column ColumnID="COSTO_SEDAPRO" Header="COSTO PRODUCCIÓN" DataIndex="COSTO_SEDAPRO" Width="70px" />
                    <ext:Column ColumnID="COSTO_OPEN" Header="COSTO OPEN" DataIndex="COSTO_OPEN" Width="70px" />
                    <ext:Column ColumnID="DIFERENCIA" Header="DIFERENCIA" DataIndex="DIFERENCIA" Width="70px">
                        <Renderer Fn="change" />
                    </ext:Column>
                    <ext:ImageCommandColumn Width="30">
						<Commands>
							<ext:ImageCommand CommandName="Editar" Icon="BuildingEdit" Text="">
								<ToolTip Text="Editar O/T" />
							</ext:ImageCommand>
						</Commands>
						<PrepareCommand Fn="prepareCommand" />
					</ext:ImageCommandColumn>
		        </Columns>
	        </ColumnModel>
            <LoadMask ShowMask="true"/>
            <SaveMask ShowMask="true" />
            <Listeners>
                <%--<Command Fn="EditarOT(" />--%>
                <Command Handler="addTab('ConsumoMaterial','Modulos/ProduccionServicios/Procesos/ConsumoMateriales/ConsumoMaterial.aspx?sgi='+record.data.SGI,'Completar Informacion O/T');" />
            </Listeners>

        </ext:GridPanel>
        <ext:HyperLink ID="hplRutaTxt" runat="server" Text=""></ext:HyperLink>
        
       <%-- <ext:Window 
		ID="Window3" 
		runat="server" 
		IconCls="iconoCONCYSSA" 
		Width="120" 
		Height="100" 
		Modal="true"
		Hidden="true"
		Layout="Fit"
		Draggable="false">
        <Content>
            
        </Content>
        </ext:Window>--%>
    </form>
</body>
</html>
