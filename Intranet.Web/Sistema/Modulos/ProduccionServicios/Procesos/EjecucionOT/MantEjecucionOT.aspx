<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantEjecucionOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT.MantEjecucionOT" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #NroRegistro,#nro_ot,#nis,#conteoFecProg,#vusuario,#direccion
        ,#scliente,#localidad,#municipio,#desc_actividad,#desc_subactividad
        ,#vdescripcion,#f_alta,#txtUsuarioVB,#ddlEstado
        ,#direccionCONCYSSA,#txtActualizado,#ddlArea,#ddlResponsable
        ,#ddlCuadrilla,#FechaProg,#FechaInicio,#HoraInicio,#FechaFin,#HoraFin,#ddlEstado,#ddlTipoTrabajo
        ,#observacionCONCYSSA,#NroOrden,#FechaOrden,#txtFechaPermisoMuni,#txtUsuarioVB,#txtCUS{
            height: 15px;
            font-size:11px;
        }
    </style>
		<script type="text/javascript"> 
	     
	        function oculta(id) {alert('oculta' + id);
	        	var elDiv = document.getElementById(id);
	        	elDiv.style.display = 'none';
	        }

	        function muestra(id) {
	        	alert('muestra' + id);
	        	var elDiv = document.getElementById(id);
	        	elDiv.style.display = 'block';
	        }

	        function mostrarDimension(valor, id) {
	        	var elDiv = document.getElementById(id);
	        	if (valor == true)
	        		elDiv.style.display = 'block';
	        	else
	        		elDiv.style.display = 'none';
	        }

	        var TCRenderer = function (value) {
	        	if (!Ext.isEmpty(value)) {
	        		return value.Descripcion;
	        	}
	        	return value;
	        };
	        var CuadrillaRenderer = function (value) {
	        	if (!Ext.isEmpty(value)) {
	        		return value.Descripcion;
	        	}
	        	return value;
	        };
	        var ProveedorRenderer = function (value) {
	        	if (!Ext.isEmpty(value)) {
	        		return value.Proveedor;
	        	}
	        	return value;
	        };
	        var EstadoRenderer = function (value) {
	        	if (!Ext.isEmpty(value)) {
	        		return value.DescripcionEstado;
	        	}
	        	return value;
	        };

	        var FProgRender = function (value) {
	        	if (value=="01/01/0001") {
	        		return "";
	        	}
	        	return value;
	        };

	        var FIniRender = function (value) {
	        	if (value == "01/01/0001") {
	        		return "";
	        	}
	        	return value;
	        };
	        var FFinRender = function (value) {
	        	if (value == "01/01/0001") {
	        		return "";
	        	}
	        	return value;
	        };



	       var ManejoTC = function (tipo, id1, id2) {
	        	Ext.net.DirectMethods.ManejarTC(tipo, id1, id2);
	        };

	        var ValidarNuevaTC = function () {
	            if ((Ext.getCmp('ddlEjecutorProveedor').getValue() == 0) && (Ext.getCmp('ddlEjecutorCuadrilla').getValue() == 0)) {
	                Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Seleccione el ejecutor del trabajo.");
	                return;
	            }

	            if (Ext.getCmp('ddlTrabajoComplementario').getValue() == 0) {
	                Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Seleccione el trabajo complementario.");
	                return;
	            }

//	            if (Ext.getCmp('chkDimension').getValue() == true) {
//	                if (Ext.getCmp('Dimension1').getValue() == '') {
//	                    Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Ingrese largo.");
//	                    return;
//	                }
//	                if (Ext.getCmp('Dimension2').getValue() == '') {
//	                    Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Ingrese ancho.");
//	                    return;
//	                }
//	                Ext.get('txtCantidad').dom.value = Ext.getCmp('Dimension1').getValue() * Ext.getCmp('Dimension2').getValue();
//	            }


	            if (Ext.getCmp('txtCantidad').getValue() == '') {
	                Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Ingrese la cantidad.");
	                return;
	            }
	            if (Ext.getCmp('ddlEstadoTC').getValue() == 0) {
	                Ext.Msg.alert("SMC GESTION DE OPERACIONES", "Seleccione el estado del trabajo.");
	                return;
	            }
	            Ext.net.DirectMethods.btnGuardarTC_Click();

	        };

	        var prepareCommand = function (grid, command, record, row) {
	            // you can prepare group command
	            if (command.command == 'Asignar' && (record.data.Estado == "PENDIENTE" || record.data.CambioMasivo == true)) {
	                command.hidden = false;
	            } else {
	                command.hidden = true;               
	            }
	        };

	        var ManejarRelleno = function () {
	            var CheckRelleno = Ext.getCmp('chkRelleno').getValue();
	            if (CheckRelleno == true) {
	                Ext.getCmp('txtRelleno').show();
	            } else {
	                Ext.getCmp('txtRelleno').hide();
	            }
	        }

	       


        </script>
        <script type="text/javascript">
            var submitValue = function (grid, hiddenFormat, format) {
                hiddenFormat.setValue(format);
                grid.submitData(false);
            };

//                var template = '<span style="color:{0};">{1}</span>';

//                var change = function (value) {
//                    return String.format(template, (value > 0) ? "green" : "red", value);
//                };

//                var pctChange = function (value) {
//                    return String.format(template, (value > 0) ? "green" : "red", value + "%");
//                };
        </script>

        <script type="text/javascript">
            var template = '{1}';

            var change = function (value, metaData, record, rowIndex, colIndex, store) {
                if (value == "GESTIONANDO") {
                    metaData.css = "GESTIONANDO";
                }

                if (value == "ENTC") {
                    metaData.css = "ENTC";
                }

                if (value == "SINASIGNAR") {
                    metaData.css = "SINASIGNAR";
                }

               // return String.format(template, (value > 0) ? "green" : "red", value);
            };

            var ftipotrabajo = function (value, metaData, record, rowIndex, colIndex, store) {
                if (value == "PROGRAMADO" || value == "CARGA DE TRABAJO") {
                    metaData.css = "PROGRAMADO";
                }

                if (value == "EMERGENCIA" || value == "EMERGENCIA NO INMEDIATA") {
                    metaData.css = "EMERGENCIA";
                }

                if (value == "REUNION" || value == "TRABAJO EN CLIENTE") {
                    metaData.css = "REUNION";
                }
            };

            
    </script>


    <style type="text/css">
       
       #GridPanel1 .x-grid3-cell-inner {
          font-size: 10px;
        }
        
         .REUNION 
        {
            background-color: #58D3F7;
            color:#FFFFFF;
        }
        
         .EMERGENCIA 
        {
            background-color: #FF0000; 
            color:#FFFFFF;
        }
        
         .PROGRAMADO 
        {
            background-color: #FACC2E; 
            color:#FFFFFF;
        }
        
        
        .GESTIONANDO 
        {
            background-color: #00FF00; 
            color: #00FF00; 
        }
        
        .ENTC 
        {
            background-color: #00FF00; 
            color: #00FF00; 
        }
        
        .SINASIGNAR 
        {
            background-color: #FFFF00; 
            color: #FFFF00; 
        }
        
    </style>


</head>
<body>
    <form id="form1" runat="server">
	<ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
        
		<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Parámetros de Búsqueda" Frame="true">
			<Content>
				<table style="padding-top:5px;">
					<tr>
						<td><b>Local</b></td>
						<td style="padding-left:5px;">
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
									<Select OnEvent="CargarCuadrillasFiltro"></Select>
								</DirectEvents>
							</ext:ComboBox>
						</td>
                        <td style="padding-left:15px;"><b>Área</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlAreaFiltro" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="150px">
								<Store>
									<ext:Store ID="StoreAreaFiltro" runat="server">
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
							</ext:ComboBox>
						</td>
					</tr>
					<tr>
						<td><b>Asignado</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlCuadrillaFiltro" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="200px" ItemSelector="div.list-item">
								<Store>
									<ext:Store ID="StoreCuadrillaFiltro" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCuadrilla">
												<Fields>
													<ext:RecordField Name="IdCuadrilla" />
													<ext:RecordField Name="Descripcion" />
													<ext:RecordField Name="DetalleZona" />
													<ext:RecordField Name="NombresApellidos" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
								<Template ID="Template3" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
						</td>
						<td style="padding-left:15px;"><b></b></td>
						<td style="padding-left:5px;">
							<asp:TextBox ID="Numero" runat="server" CssClass="x-form-text" Width="60px" Visible=false></asp:TextBox>
						</td>
						<td style="padding-left:15px;"><b></b></td>
						<td style="padding-left:5px;">
							<asp:TextBox ID="pNIS" runat="server" CssClass="x-form-text" Width="60px" Visible=false></asp:TextBox>
						</td>
						<td style="padding-left:15px;"><b>N° Orden Trabajo</b></td>
						<td style="padding-left:5px;"><asp:TextBox ID="txtCorrelativo" runat="server" CssClass="x-form-text" Width="60px"></asp:TextBox></td>
						<td style="padding-left:15px;"><b></b></td>
						<td style="padding-left:5px;"><asp:TextBox ID="OTConcyssa" runat="server" CssClass="x-form-text" Width="30px" Visible=false></asp:TextBox></td>
						
						<td style="padding-left:15px;">
							<ext:Button ID="btnBuscarTodos" runat="server" Text="Ver Todos" Icon="DatabaseGo" Width="100" Visible="false">
								<DirectEvents>
									<Click OnEvent="btnBuscarTodos_Click" Timeout="1200000">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
									</Click>
								</DirectEvents>
							</ext:Button>
						</td>
					</tr>
					<tr>
						<td><b>Cliente</b></td>
						<td colspan="3" style="padding-left:5px;"><asp:TextBox ID="pDireccion" runat="server" CssClass="x-form-text" Width="310px"></asp:TextBox></td>
						<td style="padding-left:15px;"><b>Fec. Desde</b></td>
						<td style="padding-left:5px;"><ext:DateField ID="FechaD" runat="server" Format="dd/MM/yyyy" AllowBlank="false"/></td>
						<td style="padding-left:15px;"><b>Fec. Hasta</b></td>
						<td style="padding-left:5px;"><ext:DateField ID="Fecha" runat="server" Format="dd/MM/yyyy" /></td>
						<td style="padding-left:15px;"><b>Estado</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlPEstado" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="110px">
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
						<td style="padding-left:15px;">
							<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="100">
								<DirectEvents>
									<Click OnEvent="btnBuscar_Click" Timeout="1200000">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
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
                <ext:Hidden ID="FormatType" runat="server" />
				<ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                Height="350px" 
				>
                <TopBar>
                    <ext:Toolbar ID="Toolbar3" runat="server">
                        <Items>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                            <ext:Button ID="Button4" runat="server" Text="A Excel" Icon="PageExcel">
                                <Listeners>
                                    <Click Handler="submitValue(#{GridPanel1}, #{FormatType}, 'xls');" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
				<Store>
					<ext:Store ID="StoreEjecucionOT" runat="server"
                    OnAfterRecordUpdated="StoreEjecucionOT_RecordUpdated" 
                    OnRefreshData="StoreEjecucionOT_RefreshData"
                    OnSubmitData="StoreEjecucionOT_Submit"
                    RemoteSort="false">
                        <DirectEventConfig IsUpload="true" />
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
						<Reader>
							<ext:JsonReader IDProperty="IdEjecucionOT">
								<Fields>
									<ext:RecordField Name="Item" />
									<ext:RecordField Name="NroRegistro" />
									<ext:RecordField Name="IdEjecucionOT" /> 
									<ext:RecordField Name="NroOT" />
									<ext:RecordField Name="NIS" />
									<ext:RecordField Name="DesCuadrilla" />
									<ext:RecordField Name="NroOrden" />
									<ext:RecordField Name="Distrito" />
									<ext:RecordField Name="Direccion" />
                                    <ext:RecordField Name="Direccion2" />
                                    <ext:RecordField Name="Localidad" />
									<ext:RecordField Name="Cliente" />
									<ext:RecordField Name="Actividad" />
                                    <ext:RecordField Name="SubActividad" />
									<ext:RecordField Name="Descripcion" />
									<ext:RecordField Name="FechaAlta" />
									<ext:RecordField Name="Estado" />
                                    <ext:RecordField Name="CambioMasivo" />
                                     
                                    <ext:RecordField Name="TipoTrabajo" />
                                     <ext:RecordField Name="FechaHoraIni" />
                                    <ext:RecordField Name="FechaHoraFin" />
                                    <ext:RecordField Name="Ingeniero" />
                                    <ext:RecordField Name="GESTION" />

								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:ImageCommandColumn Width="30">
							<Commands>
								<ext:ImageCommand CommandName="Asignar" Icon="BuildingEdit" Text="">
									<ToolTip Text="Asignar" />
								</ext:ImageCommand>
							</Commands>
							<PrepareCommand Fn="prepareCommand" />
						</ext:ImageCommandColumn>
						
                        <ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="40px" Hidden="true"/>
                         
                         

						<ext:Column ColumnID="NroRegistro" Header="N° Orden Trabajo" DataIndex="NroRegistro" Width="70px">
                        </ext:Column>
                        <ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" Width="80px" />
                        <ext:Column ColumnID="GESTION" Header="GESTION" DataIndex="GESTION" Width="20px">
                          <Renderer Fn="change" /></ext:Column> 

                         

                         <ext:Column ColumnID="TipoTrabajo2" Header="TipoTrabajo" DataIndex="TipoTrabajo" Width="130px" />
                          <ext:Column ColumnID="TipoTrabajo" Header="TT" DataIndex="TipoTrabajo" Width="20px" >
                          <Renderer Fn="ftipotrabajo" />
                          </ext:Column> 

                         <ext:Column ColumnID="Cliente" Header="Cliente" DataIndex="Cliente" Width="120px" />
                         <ext:Column ColumnID="FechaAlta" Header="Fec. Alta" DataIndex="FechaAlta" Width="120px" />
						<ext:Column ColumnID="SubActividad" Header="Sub-Actividad" DataIndex="SubActividad" Width="150px"/>
                        <ext:Column ColumnID="DesCuadrilla" Header="Asignado" DataIndex="DesCuadrilla" Width="120px" />
  						<ext:Column ColumnID="Descripcion" Header="Descripción" DataIndex="Descripcion" Width="300px" />
                        <ext:Column ColumnID="FechaHoraIni" Header="F.H. Inicio" DataIndex="FechaHoraIni" Width="100px" />
                        <ext:Column ColumnID="FechaHoraFin" Header="F.H. Fin" DataIndex="FechaHoraFin" Width="100px" />
   						<ext:Column ColumnID="Ingeniero" Header="G. Operacion" DataIndex="Ingeniero" Width="150px" />
						<ext:Column ColumnID="IdEjecucionOT" Header="IdEjecucionOT" DataIndex="IdEjecucionOT" Hidden="true" />
						<ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="130px" Hidden="true" />
						<ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="300px" />
					</Columns>
				</ColumnModel>

				<LoadMask ShowMask="true" />
				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
				</SelectionModel>
				<DirectEvents>
					<RowDblClick OnEvent="RowDblClick_Event" Timeout="0">
                    <%--3600000--%>
						<ExtraParams>
							<ext:Parameter Name="IdEjecucionOT" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
						</ExtraParams>
					</RowDblClick>
				</DirectEvents>
				<Listeners>
					<Command Handler="Ext.net.DirectMethods.CargarVentanaAsignacion(record.data.IdEjecucionOT);" />
				</Listeners>
			</ext:GridPanel>
			</Items>
		</ext:Panel>


		<ext:Window 
		ID="Window1" 
		runat="server" 
		IconCls="iconoCONCYSSA" 
		Width="920" 
		Height="550" 
		Modal="true"
		Hidden="true"
		Layout="Fit"
		Draggable="false">
		<Items>
			<ext:TabPanel ID="TabPanel1" runat="server" Border="false">
				<Items>
                <ext:Panel 
                    ID="OTTab" 
                    runat="server" 
                    Title="Programacion Orden de Trabajo" 
                    Icon="PageCode">
					
                    <Items>
						
						<ext:AbsoluteLayout ID="AbsoluteLayout1" runat="server">
							<Content>
								<ext:Panel ID="Panel3" runat="server" Title="1. Información OPERADOR" Frame="true" Padding="3" >
								<Content>
								<table cellpadding="2" cellspacing="2" style="font-size:11px;">

									<tr>
										<td><b>N° Orden Trabajo</b></td>
										<td style="padding-left:10px;">
											<ext:Hidden ID="hdnIdEjecucionOT" runat="server">
											</ext:Hidden>
											<ext:TextField ID="NroPosicion" runat="server" Width="60" ReadOnly="true" Hidden="true" />
											<ext:TextField ID="NroRegistro" runat="server" Width="60" ReadOnly="true" />
										</td>
										<td style="padding-left:10px;"><b></b></td>
										<td style="padding-left:10px;"><ext:TextField ID="nro_ot" runat="server" Width="60" ReadOnly="true" Visible=false /></td>
										<td style="padding-left:10px;"><b></b></td>
										<td style="padding-left:10px;">
										
											<ext:TextField ID="nis" runat="server" Width="60" ReadOnly="true" Visible=false  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<b style="color:Red;">Días</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<ext:TextField ID="conteoFecProg" runat="server" Width="55" ReadOnly="true" StyleSpec="font-weight:bold; font-size:13px;border:1px solid red;" />
										</td>
										<td style="padding-left:10px;"><b></b></td>
										<td style="padding-left:10px;"><ext:TextField ID="vusuario" runat="server" Width="80" ReadOnly="true" Visible=false /></td>
										
									</tr>
                                    <tr>
										<td><b>Dirección</b></td>
										<td colspan="7" style="padding-left:10px;"><ext:TextField ID="direccion" runat="server" Width="750" ReadOnly="true" /></td>
									</tr>
									<tr>
										<td><b>Cliente</b></td>
										<td colspan="3" style="padding-left:10px;"><ext:TextField ID="scliente" runat="server" Width="250" ReadOnly="true" /></td>
										<td style="padding-left:10px;"><b></b></td>
										<td style="padding-left:10px;"><ext:TextField ID="localidad" runat="server" Width="200" ReadOnly="true" Visible=false /></td>
										<td style="padding-left:10px;"><b>Distrito</b></td>
										<td style="padding-left:10px;"><ext:TextField ID="municipio" runat="server" Width="150" ReadOnly="true" /></td>
									</tr>
									<tr>
										<td><b>Actividad</b></td>
										<td colspan="7" style="padding-left:10px;"><ext:TextField ID="desc_actividad" runat="server" Width="750" ReadOnly="true" /></td>
									</tr>
									<tr>
										<td><b>Sub-Actividad</b></td>
										<td colspan="7" style="padding-left:10px;"><ext:TextField ID="desc_subactividad" runat="server" Width="750" ReadOnly="true" /></td>
									</tr>
									<tr>
										<td><b>Observación</b></td>
										<td colspan="5" style="padding-left:10px;"><ext:TextField ID="vdescripcion" runat="server" Width="550" ReadOnly="true"  Height="40px"/></td>
										<td style="padding-left:10px;"><b>Fec. Alta</b></td>
										<td style="padding-left:10px;"><ext:TextField ID="f_alta" runat="server" Width="150" ReadOnly="true" /></td>
									</tr>
								</table>
								</Content>
								</ext:Panel>
								<ext:Panel ID="Panel4" runat="server" Title="2. Información - Gestor de la Operacion" Frame="true" Padding="0">
								<TopBar>
									<ext:Toolbar ID="barraDatos" runat="server">
										<Items>
											<ext:Button ID="btnGuardarOT" runat="server" Text="Guardar" Icon="Disk">
												<DirectEvents>
													<Click OnEvent="btnGuardarOT_click" Timeout="0">
														<EventMask ShowMask="true" />
													</Click>
												</DirectEvents>
											</ext:Button>
										</Items>
									</ext:Toolbar>
								</TopBar>
								<Content>
								<table cellpadding="2" cellspacing="2" border="0">
									<tr>
										<td><b>Dirección</b></td>
										<td colspan="3" style="padding-left:10px;"><ext:TextField ID="direccionCONCYSSA" runat="server" Width="500px" /></td>
										<td style="padding-left:10px;"><b>Actualizado</b></td>
										<td style="padding-left:10px;">
											<ext:TextField ID="txtActualizado" runat="server" Width="200px" Enabled="false" />
										</td>
									</tr>
									<tr>
										<td><b>Area</b></td>
										<td id="CellArea" style="padding-left:10px;">
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
										<td style="padding-left:10px;"><b>G. Operacion</b></td>
										<td id="CellResponsable" style="padding-left:10px;">
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
												<DirectEvents>
													<Select OnEvent="CargarCuadrillaPorResponsable"></Select>
												</DirectEvents>
											</ext:ComboBox>
										</td>
										<td style="padding-left:10px;"><b>Asignado</b></td>
										<td id="CellCuadrilla" style="padding-left:10px;">
											
											<ext:ComboBox ID="ddlCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="200px" 
                                            ItemSelector="div.list-item" 
                                            Editable="true" 
							                TypeAhead="true" 
							                Mode="Local" 
							                ForceSelection="true" 
							                TriggerAction="All" >
												<Store>
													<ext:Store ID="StoreCuadrilla" runat="server">
														<Reader>
															<ext:JsonReader IDProperty="IdCuadrilla">
																<Fields>
																	<ext:RecordField Name="IdCuadrilla" />
																	<ext:RecordField Name="Descripcion" />
																	<ext:RecordField Name="DetalleZona" />
																	<ext:RecordField Name="NombresApellidos" />
																</Fields>
															</ext:JsonReader>
														</Reader>
													</ext:Store>
												</Store>
												<Template ID="Template1" runat="server">
													<Html>
														<tpl for=".">
															<div class="list-item">
																<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
															</div>
														</tpl>
													</Html>
												</Template>
											</ext:ComboBox>
										</td>
									</tr>
									<tr>
										<td><b>F. Prog.</b></td>
										<td style="padding-left:10px;">
											<ext:DateField ID="FechaProg" runat="server" Width="100px" Format="dd/MM/yyyy" />
										</td>
										<td style="padding-left:10px;"><b>Fec. Inicio</b></td>
										<td style="padding-left:10px;">
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td><ext:DateField ID="FechaInicio" runat="server" Width="100px" Format="dd/MM/yyyy" /></td>
													<td>
														<ext:TextField ID="HoraInicio" runat="server" Width="80">
														</ext:TextField>
													</td>
												</tr>
											</table>
										</td>
										<td style="padding-left:10px;"><b>Fec. Fin</b></td>
										<td style="padding-left:10px;">
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td><ext:DateField ID="FechaFin" runat="server" Width="100px" Format="dd/MM/yyyy" /></td>
													<td>
														<ext:TextField ID="HoraFin" runat="server" Width="80">
														</ext:TextField>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td rowspan="3" colspan="2" style=" vertical-align:top;">
											<table>
												<tr>
													<td><b>LLU</b> - Llamar al usuario</td>
													<td><ext:Checkbox ID="chkTuberiaRota" runat="server"></ext:Checkbox></td>
												</tr>
												<tr>
													<td><b>RE</b> - Replicacion del error</td>
													<td><ext:Checkbox ID="chkFugaToma" runat="server"></ext:Checkbox></td>
												</tr>
												<tr>
													<td><b>RI</b> - Recopilar informacion</td>
													<td><ext:Checkbox ID="chkRoturaMedidor" runat="server"></ext:Checkbox></td>
												</tr>
												<tr>
													<td><b>IS</b> - Informar Solucion</td>
													<td><ext:Checkbox ID="chkLimpieza" runat="server"></ext:Checkbox></td>
												</tr>
												<tr> 
													<td><b>ECC</b> - Envio correo cierre</td>
													<td><ext:Checkbox ID="chkBombeo" runat="server"></ext:Checkbox></td>
												</tr>
											</table>
										</td>
										<td style="padding-left:10px;color:red;"><b>Estado</b></td>
										<td style="padding-left:10px;">
											<ext:ComboBox ID="ddlEstado" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="160px" StyleSpec="border:1px solid red;">
												<Store>
													<ext:Store ID="StoreEstadoOT" runat="server">
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
										<td style="padding-left:10px;"><b>Tipo Trab.</b></td>
										<td style="padding-left:10px;">
											<ext:ComboBox ID="ddlTipoTrabajo" runat="server" DisplayField="A2" ValueField="IdGenerica" Width="180px">
												<Store>
													<ext:Store ID="StoreTipoTrabajo" runat="server">
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
											</ext:ComboBox>
										</td>
									</tr>
									<tr>
										<td style="padding-left:10px;"><b>Observación</b></td>
										<td colspan="3" style="padding-left:10px;">
											<ext:TextArea ID="observacionCONCYSSA" runat="server" Width="550px" Height="60px">
											</ext:TextArea>
										</td>
									</tr>
									<tr>

										<td style="padding-left:10px;"><b></b></td>
                                        <td colspan="2" style="padding-left:10px;">
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td>
														<ext:Checkbox ID="chkOrden" runat="server" Hidden="true">
														</ext:Checkbox>
													</td>
													
													<td></td>
													<td style="padding-left:10px;"><ext:TextField ID="NroOrden" runat="server" Width="80px" Visible=false /></td>
													<td style="padding-left:10px;"></td>
													<td style="padding-left:10px;"><ext:DateField ID="FechaOrden" runat="server" Width="100px" Format="dd/MM/yyyy" Visible=false /></td>
												</tr>
											</table>
										</td>

									<td style="padding-left:5px;">
											<table cellpadding="0" cellspacing="0">
												<tr>
                                                  <td style="padding-left:5px;"><ext:Checkbox ID="chkPermisoMunicipal" runat="server" Disabled="true" Visible=false /></td>

                                                    <td style="padding-left:5px;"><b></b></td>
													<td style="padding-left:5px;">
                                                    	<ext:DateField ID="txtFechaPermisoMuni" runat="server" Disabled="true" Visible=false>
														</ext:DateField>
													</td>
												</tr>
											</table>
										</td>
									</tr>
                                    <tr>
                                        <td colspan="2">
                                            <table>
												<tr>
													<td><b>V°B°</b></td>
													<td style="padding-left:20px;"><ext:Checkbox ID="chkVB" runat="server" Disabled="true"></ext:Checkbox></td>
                                                    <td>
                                                        <ext:TextField ID="txtUsuarioVB" runat="server" Width="150" Disabled="true">
														</ext:TextField>
                                                    </td>
                                                    
												</tr>
                                            </table>
                                        </td>
										<td style="padding-left:10px;color:Red;">
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td><b></b></td>
													<td style="padding-left:10px;"><ext:Checkbox ID="chkDMTU" runat="server" Visible=false StyleSpec="border:1px solid red;"></ext:Checkbox></td>
												</tr>
											</table>
										</td>
										<td>
											<table cellpadding="0" cellspacing="0">
                                            
												<tr>
													<td style="padding-left:10px;"><b></b></td>
													<td style="padding-left:10px;">
														<ext:TextField ID="txtCUS" runat="server" Width="60" ReadOnly="true" Visible=false>
														</ext:TextField>
													</td>

                                                    <td style="padding-left:5px;" ><b></b>
                                                        <ext:TextField ID="txtpuntaje" runat="server" Width="40" Height="20px" ReadOnly="false"  Visible=false  >
														</ext:TextField>
                                                      
                                                      
                                                    <td style="padding-left:5px;" ><b></b>    
                                                     <ext:TextField ID="txtDiasEstimadoEjec" runat="server" Width="20"  Height="20px" ReadOnly="false"  Visible=false  >
														</ext:TextField>
													</td>
												</tr>
                                               </table>
										</td>
	    							   </td>
    	    					    </tr>
									</table>
								</td>
                                    </tr>
								</table>
								</Content>
								</ext:Panel>
							</Content>
						</ext:AbsoluteLayout>
                    </Items>
                </ext:Panel>
				<ext:Panel 
                    ID="TCTab" 
                    runat="server" 
                    Title="Programacion Trabajo Complementario" 
                    Icon="PageRed">
                    <Items>
						<ext:Panel ID="Panel5" runat="server" Title="1. Administración de Trabajos Complementarios" Padding="3" Height="500px">
							<TopBar>
								<ext:Toolbar runat="server" ID="toolbar1">
									<Items>
										<ext:Button ID="btnGuardarTC" runat="server" Text="Guardar" Icon="Disk">
											<%--<DirectEvents>
												<Click OnEvent="btnGuardarTC_Click"></Click>
												
											</DirectEvents>--%>
											<Listeners>
												<Click Fn="ValidarNuevaTC"></Click>
											</Listeners>
										</ext:Button>
										<ext:Button ID="btnLimpiarTC" runat="server" Text="Limpiar" Icon="Erase">
											<DirectEvents>
												<Click OnEvent="btnLimpiarTC_Click"></Click>
											</DirectEvents>
										</ext:Button>
									</Items>
								</ext:Toolbar>
							</TopBar>
							<Content>
								<ext:Hidden ID="hdIdAdminTC" runat="server">
								</ext:Hidden>
								<table cellpadding="2" cellspacing="2" style="color:#15428B;" border="0">
									<tr>
										<td><b></b></td>
										<td colspan="7">
											<table cellpadding="0" cellspacing="0" style="color:#15428B;" border="0">
												<tr>
													<td style="padding-left:5px;">
                                                        <ext:RadioGroup ID="RadioGroup1" runat="server">
										                    <Items>
											                    <ext:Radio ID="rCuadrilla" runat="server" BoxLabel=" Asignado" BoxLabelStyle="padding-right:10px;" />
											                    <ext:Radio ID="rProveedor" runat="server" BoxLabel="Proveedor" BoxLabelStyle="padding-right:15px;" />
										                    </Items>
										                    <DirectEvents>
											                    <Change OnEvent="ManejarEjecutar"></Change>
										                    </DirectEvents>
									                    </ext:RadioGroup>
													</td>
													<td>
														<ext:ComboBox ID="ddlEjecutorProveedor" runat="server" 
																DisplayField="Proveedor" 
																ValueField="IdProveedor" 
																Editable="true" 
																TypeAhead="true" 
																Mode="Local"
																ForceSelection="true"
																TriggerAction="All"
																Width="300px">
																<Store>
																	<ext:Store ID="StoreEjecutorProveedor" runat="server">
																		<Reader>
																			<ext:JsonReader IDProperty="IdProveedor">
																				<Fields>
																					<ext:RecordField Name="IdProveedor" />
																					<ext:RecordField Name="Proveedor" />
																				</Fields>
																			</ext:JsonReader>
																		</Reader>
																	</ext:Store>
																</Store>
															</ext:ComboBox>
														<ext:ComboBox ID="ddlEjecutorCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" 
                                                        Width="300px" ItemSelector="div.list-item" 
                                                        Editable="true" 
							                            TypeAhead="true" 
							                            Mode="Local" 
							                            ForceSelection="true" 
							                            TriggerAction="All" >
															<Store>
																<ext:Store ID="StoreEjecutorCuadrilla" runat="server">
																	<Reader>
																		<ext:JsonReader IDProperty="IdCuadrilla">
																			<Fields>
																				<ext:RecordField Name="IdCuadrilla" />
																				<ext:RecordField Name="Descripcion" />
																				<ext:RecordField Name="DetalleZona" />
																				<ext:RecordField Name="NombresApellidos" />
																			</Fields>
																		</ext:JsonReader>
																	</Reader>
																</ext:Store>
															</Store>
															<Template ID="Template2" runat="server">
																<Html>
																	<tpl for=".">
																		<div class="list-item">
																			<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
																		</div>
																	</tpl>
																</Html>
															</Template>
														</ext:ComboBox>
													</td>
												</tr>
											</table>
										</td>
                                        <td style="padding-left:5px;"><b></b> 
											<ext:Checkbox ID="chkDimension" runat="server">
												<DirectEvents>
													<Check OnEvent="ManejarDimension"></Check>
												</DirectEvents>
											</ext:Checkbox>
										</td>
										<td colspan="3" style="padding-left:5px;">
											<ext:TextField ID="Dimension1" runat="server" FieldLabel="Largo"></ext:TextField>
											<ext:TextField ID="Dimension2" runat="server" FieldLabel="Ancho"></ext:TextField>
										</td>
									</tr>
									<tr>
										<td><b>Trabajo</b></td>
										<td colspan="5" style="padding-left:5px;">
											<ext:ComboBox ID="ddlTrabajoComplementario" runat="server" 
											DisplayField="Descripcion" 
											ValueField="IdTrabajoComplementario" 
											Editable="true" 
											TypeAhead="true" 
											Mode="Local" 
											ForceSelection="true" 
											TriggerAction="All" 
											Width="300px">
												<Store>
													<ext:Store ID="StoreTrabajoComplementario" runat="server">
														<Reader>
															<ext:JsonReader IDProperty="IdTrabajoComplementario">
																<Fields>
																	<ext:RecordField Name="IdTrabajoComplementario" />
																	<ext:RecordField Name="Descripcion" />
																	<ext:RecordField Name="Unidad" />
																	<ext:RecordField Name="CostoProgramado" />
																</Fields>
															</ext:JsonReader>
														</Reader>
													</ext:Store>
												</Store>
												<DirectEvents>
													<Select OnEvent="CargarTC">
														<ExtraParams>
															<ext:Parameter Name="Unidad" Value="record.data.Unidad" Mode="Raw" />
															<ext:Parameter Name="Precio" Value="record.data.CostoProgramado" Mode="Raw" />
														</ExtraParams>
													</Select>
												</DirectEvents>
											</ext:ComboBox>
										</td>
                                        <td style="padding-left:5px;"><b></b></td>
										<td style="padding-left:5px;">
											<ext:TextField ID="txtUnidad" runat="server" Width="60" ReadOnly="true">
											</ext:TextField>
											
										<td style="padding-left:5px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <ext:Checkbox ID="chkRelleno" runat="server">
												            <Listeners>
                                                                <Check Fn="ManejarRelleno" />
                                                            </Listeners>
											            </ext:Checkbox>
                                                    </td>
                                                    <td><b></b></td>
                                                </tr>
                                            </table>
                                        </td>
										<td style="padding-left:5px;">
                                            <ext:NumberField ID="txtRelleno" runat="server" Hidden="true" AllowDecimals="true" DecimalSeparator="." DecimalPrecision="2" Width="40px">
                                            </ext:NumberField>
											<ext:TextField ID="txtPrecio" runat="server" Width="60" Hidden="true">
											</ext:TextField>
										</td>
									</tr>
									<tr>
										<td><b>F. Prog</b></td>
										<td style="padding-left:5px;">
											<ext:DateField ID="txtFProg" runat="server">
											</ext:DateField>
										</td>
										<td></td>
										<td style="padding-left:5px;"><b>F. Inicio</b></td>
										<td style="padding-left:5px;">
											<ext:DateField ID="txtFInicio" runat="server" Format="dd/MM/yyyy">
											</ext:DateField>
                                            <td>
												<ext:TextField ID="txtHoraInicioTC" runat="server" Width="80">
												</ext:TextField>
											</td>

										</td>

										<td style="padding-left:5px;"><b>F. Fin</b></td>
										<td style="padding-left:5px;">
											<ext:DateField ID="txtFFin" runat="server" Format="dd/MM/yyyy">
											</ext:DateField>
                                            <td>
												<ext:TextField ID="txtHoraFinTC" runat="server" Width="80">
												</ext:TextField>
											</td>
										</td>
										<td style="padding-left:5px;"><b>Estado</b></td>
										<td id="cellEstadoTC" style="padding-left:5px;">
											<ext:ComboBox ID="ddlEstadoTC" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="120px">
												<Store>
													<ext:Store ID="StoreEstadoTC" runat="server">
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
									</tr>
									<tr>
										<td><b>Observación</b></td>
										<td style="padding-left:5px;" colspan="11">
											<ext:TextArea ID="txtObsTC" runat="server" Height="40" width="750">
											</ext:TextArea>
										</td>
									</tr>

                                    <td style="padding-left:5px;"><b>Cantidad H.</b></td>
										<td style="padding-left:5px;">
											<ext:TextField ID="txtCantidad" runat="server" Width="60">
											</ext:TextField>
										</td>
								</table>
								<hr style="border:1px solid #99BBE8; background-color:#99BBE8;" />
								
								<ext:GridPanel ID="GridTC" runat="server" Height="250" Width="900">
									<Store>
										<ext:Store ID="StoreTC" runat="server" SerializationMode="Complex">
											<Reader>
												<ext:JsonReader IDProperty="IdAdmTraCom">
													<Fields>
														<ext:RecordField Name="IdAdmTraCom" /> 
														<ext:RecordField Name="Item" /> 
														<ext:RecordField Name="DesignadoA" /> 
														<ext:RecordField Name="Cuadrilla" /> 
														<ext:RecordField Name="Proveedor" /> 
														<ext:RecordField Name="DetalleCantidad" /> 
														<ext:RecordField Name="EjecucionOT" /> 
														<ext:RecordField Name="TrabajoComplementario" /> 
														<ext:RecordField Name="Cantidad" /> 
														<ext:RecordField Name="CostoProgramado" /> 
														<ext:RecordField Name="Total" /> 
														<ext:RecordField Name="FechaProgramada" /> 
														<ext:RecordField Name="FecInicio" /> 
														<ext:RecordField Name="FecFin" /> 
														<ext:RecordField Name="EstadoOT" /> 
														<ext:RecordField Name="Observacion" /> 
														<ext:RecordField Name="Usuario" /> 
                                                        <ext:RecordField Name="HoraInicio" /> 
                                                        <ext:RecordField Name="HoraFin" /> 
													</Fields>
												</ext:JsonReader>
											</Reader>
										</ext:Store>
									</Store>
									<ColumnModel ID="ColumnModel2" runat="server">
										<Columns>
											<ext:CommandColumn Width="60px" ButtonAlign="Center">
												<Commands>
													<ext:GridCommand Icon="Cross" CommandName="Eliminar" >
														<ToolTip Text="Eliminar" />
													</ext:GridCommand>
													<ext:CommandSeparator />
													<ext:GridCommand Icon="NoteEdit" CommandName="Editar">
														<ToolTip Text="Editar" />
													</ext:GridCommand>
												</Commands>
											</ext:CommandColumn>
											<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="30px" />
											<ext:Column ColumnID="IdAdmTraCom" Header="IdAdmTraCom" DataIndex="IdAdmTraCom" Hidden="true" />
											
                                            <ext:Column DataIndex="EstadoOT" Header="Estado" Width="100px">
												<Renderer Fn="EstadoRenderer" />
											</ext:Column>

                                            <ext:Column DataIndex="TrabajoComplementario" Header="Descripcion" Width="120px">
												<Renderer Fn="TCRenderer" />
											</ext:Column>

                                            <ext:Column Header="Observación" DataIndex="Observacion" Width="200px">
											</ext:Column>

											<ext:Column DataIndex="Cuadrilla" Header="Asignado" Width="120px">
												<Renderer Fn="CuadrillaRenderer" />
											</ext:Column>
											<ext:Column DataIndex="Proveedor" Header="Proveedor" Width="60px">
												<Renderer Fn="ProveedorRenderer" />
											</ext:Column>
											<ext:Column ColumnID="Cantidad" Header="Cant." DataIndex="Cantidad" Width="40px" />
											<ext:Column Header="F. Prog." DataIndex="FechaProgramada" Width="80px">
												<Renderer Fn="FProgRender" />
											</ext:Column>
											
                                            <ext:Column Header="F. Inicio" DataIndex="FecInicio" Width="80px">
												<Renderer Fn="FIniRender" />
											</ext:Column>

                                            <ext:Column ColumnID="HoraInicio" Header="HoraInicio" DataIndex="HoraInicio" Width="100px" />

											<ext:Column Header="F. Fin" DataIndex="FecFin" Width="80px">
												<Renderer Fn="FFinRender" />
											</ext:Column>

                                            <ext:Column ColumnID="HoraFin" Header="HoraFin" DataIndex="HoraFin" Width="100px" />

											
											
											<ext:Column Header="Usuario" DataIndex="Usuario" Width="100px">
											</ext:Column>
											


										</Columns>
									</ColumnModel>
									<LoadMask ShowMask="true"/>
									<SaveMask ShowMask="true" />
									<Listeners>
										<Command Handler="ManejoTC(command, record.data.IdAdmTraCom,record.data.EjecucionOT.IdEjecucionOT);" />
									</Listeners>
								</ext:GridPanel>
							</Content>
						</ext:Panel>
					</Items>
				</ext:Panel>
				</Items>
			</ext:TabPanel>
		</Items>
		<Buttons>
            
			<ext:Button ID="btnPrevious" runat="server" Text="Anterior" Icon="PreviousGreen">
				<DirectEvents>
					<Click OnEvent="btnPrevious_click"/>
				</DirectEvents>
			</ext:Button>
			<ext:Button ID="btnNext" runat="server" Text="Siguiente" Icon="NextGreen" IconAlign="Right">
				<DirectEvents>
					<Click OnEvent="btnNext_click"/>
				</DirectEvents>
			</ext:Button>
		</Buttons>
		</ext:Window>

		<ext:Window 
		ID="Window2" 
		runat="server" 
		IconCls="iconoCONCYSSA" 
		Width="850" 
		Height="360" 
		Modal="true"
		Hidden="true"
		Layout="Fit"
		Draggable="true">
			<BottomBar>
				<ext:Toolbar ID="Toolbar2" runat="server">
					<Items>
						<ext:Button ID="Button1" runat="server" Text="Asignar" Icon="DatabaseGo">
							<DirectEvents>
								<Click OnEvent="btnAsignarOTs_Click">
									<EventMask ShowMask="true" Msg="Cargando Datos" />
									<ExtraParams>
										<ext:Parameter Name="Values" Value="Ext.encode(#{GridPanel2}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
									</ExtraParams>
								</Click>
							</DirectEvents>
						</ext:Button>
						<ext:Button ID="Button3" runat="server" Text="Cancelar" Icon="Delete">
							<DirectEvents>
								<Click OnEvent="btnCancelarAsignacion_Click">
									<EventMask ShowMask="true" Msg="Cargando Datos" />
								</Click>
							</DirectEvents>
						</ext:Button>
					</Items>
				</ext:Toolbar>
			</BottomBar>
			<Items>
					<ext:Panel 
						ID="Panel6" 
						runat="server"
						 Frame="true"
						 AutoHeight="true">
						<Content>
							<ext:Hidden ID="hdnEjecucionConSGI" runat="server">
							</ext:Hidden>
							<table style="padding-top:5px;">
								<tr>
									<td><b>Dirección</b></td>
									<td style="padding-left:5px;"><asp:TextBox ID="txtDireccionAsignar" runat="server" CssClass="x-form-text" Width="470px"></asp:TextBox></td>
									<td style="padding-left:15px;">
										<ext:Button ID="Button2" runat="server" Text="Buscar" Icon="DatabaseGo" Width="100">
											<DirectEvents>
												<Click OnEvent="btnBuscarAsignacion_Click">
													<EventMask ShowMask="true" Msg="Cargando Datos" />
												</Click>
											</DirectEvents>
										</ext:Button>
									</td>
								</tr>
							</table>
						</Content>
					</ext:Panel>
					<ext:GridPanel 
					ID="GridPanel2" 
					runat="server" 
					Height="250px"
					>
					<Store>
						<ext:Store ID="StoreAsignacion" runat="server">
							<Reader>
								<ext:JsonReader IDProperty="IdEjecucionOT">
									<Fields>
										<ext:RecordField Name="NroRegistro" />
										<ext:RecordField Name="IdEjecucionOT" /> 
										<ext:RecordField Name="NIS" />
										<ext:RecordField Name="Distrito" />
										<ext:RecordField Name="Direccion" />
										<ext:RecordField Name="Cliente" />
										<ext:RecordField Name="Actividad" />
										<ext:RecordField Name="Descripcion" />
										<ext:RecordField Name="FechaAlta" />
										<ext:RecordField Name="Estado" />
									</Fields>
								</ext:JsonReader>
							</Reader>
						</ext:Store>
					</Store>
					<ColumnModel ID="ColumnModel3" runat="server">
						<Columns>
							<ext:Column ColumnID="NroRegistro" Header="Correlativo" DataIndex="NroRegistro" Width="80px" />
							<ext:Column ColumnID="IdEjecucionOT" Header="IdEjecucionOT" DataIndex="IdEjecucionOT" Hidden="true" />
							<ext:Column ColumnID="NIS" Header="NIS" DataIndex="NIS" Width="80px" />
							<ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="150px" />
							<ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="300px" />
							<ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="80px" />
							<ext:Column ColumnID="Descripcion" Header="Observación" DataIndex="Descripcion" Width="300px" />
							<ext:Column ColumnID="FechaAlta" Header="Fec. Alta" DataIndex="FechaAlta" Width="150px" />
							<ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" Width="100px" />
						</Columns>
					</ColumnModel>
					<LoadMask ShowMask="true"/>
					<SaveMask ShowMask="true" />
					<SelectionModel>
						<ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
					</SelectionModel>
				</ext:GridPanel>
			</Items>
		</ext:Window>
    </form>
	
</body>

</html>
