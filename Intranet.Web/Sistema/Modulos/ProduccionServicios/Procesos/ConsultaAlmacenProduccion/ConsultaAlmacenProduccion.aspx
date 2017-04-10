<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaAlmacenProduccion.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsultaAlmacenProduccion.ConsultaAlmacenProduccion" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style type="text/css">
        .cbStates-list 
        {
            width: 400px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }
        
        .cbStates-list th {
            font-weight: bold;
        }
        
        .cbStates-list td, .cbStates-list th {
            padding: 3px;
        }
        
       
        .list-item {
            font:normal 11px tahoma, arial, helvetica, sans-serif;
            padding:3px 10px 3px 10px;
            border:1px solid #fff; 
            border-bottom:1px solid #eeeeee;
            white-space:normal;
        }
	
        
    </style>

    <script type="text/javascript">

    	var change = function (value) {
    		return String.format(template, (value > 0) ? "green" : "red", value);
    	};

    	var pctChange = function (value) {
    		return String.format(template, (value > 0) ? "green" : "red", value + "%");
    	};

    	var prepare = function (grid, toolbar, rowIndex, record) {

    		//    		alert(record.data.IdCabeceraCruceMaterial);
    		var Bttn1 = toolbar.items.get(0);
    		var Bttn2 = toolbar.items.get(1);
    		if (record.data.cActivo == "Revisado") {
    			Bttn2.setDisabled(true);
    			Bttn2.setTooltip("Disabled");
    		}


    	};


    	var template = '<span style="color:{0};">{1}</span>';

    	var ColorEstado = function (value) {

    		return String.format(template, (value == "Pendiente") ? "red" : "green", value);
    	};

    	//    	var ColorZona = function (value) {

    	//    		return String.format(template, (value == "No Asignado") ? "red" : "green", value);
    	//    	};
    	function linkProcesoClick(recordId) {
    		VentanaEnProceso.show();

    		Ext.get('DescripcionProductoEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("DescripcionAuxiliar")
    		Ext.get('IdAuxiliarEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("IdAuxiliar")
    		Ext.get('CodigoCuadrillaEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("CodigoCuadrilla")
    		Ext.get('CantidadEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("EnProceso")
    		Ext.get('OTEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("OrdenTrabajo")
    		Ext.get('ObservacionEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Observacionproceso")
    		Ext.get('ItemEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Item")

    		//    		Ext.get('OrdenTrabajo').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("OrdenTrabajo")
    		//alert(StoreDetalleCruceMaterial.getById(recordId).get("DescripcionAuxiliar"));

    		Ext.getCmp('CantidadEnProceso').focus(true, 10);
    	}

    	function linkProcesoRenderer(value, meta, record) {
    		if (Ext.get('ActivoField').dom.value == "Revisado") {
    			return String.format("<a class='company-link'>{0}</a>", value, record.id);
    		} else {
    			return String.format("<a class='company-link' href='#' onclick='linkProcesoClick(\"{1}\");'>{0}</a>", value, record.id);
    		}
    	}

    	function linkJustificaClick(recordId) {
    		VentanaJustificacion.show();
    		Ext.get('DescripcionProductoJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("DescripcionAuxiliar")
    		Ext.get('IdAuxiliarJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("IdAuxiliar")
    		Ext.get('CodigoCuadrillaJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("CodigoCuadrilla")
    		Ext.get('CantidadJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Justificado")
    		Ext.get('ObservacionJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Observacionjustificacion")
    		Ext.get('ItemJustificacion').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Item")
    		//alert(StoreDetalleCruceMaterial.getById(recordId).get("DescripcionAuxiliar"));
    		Ext.getCmp('CantidadJustificacion').focus(true, 10);
    	}

    	function linkJustificaRenderer(value, meta, record) {
    		if (Ext.get('ActivoField').dom.value == "Revisado") {
    			return String.format("<a class='company-link'>{0}</a>", value, record.id);
    		} else {
    			return String.format("<a class='company-link' href='#' onclick='linkJustificaClick(\"{1}\");'>{0}</a>", value, record.id);
    		}
    	}


    	var filaseleccionada = function (store, records) {
    		//    		record = GridPanel1.getSelectionModel().getSelected();
    		//    		//            FormPanel1.getForm().loadRecord(record);
    		//    		FormPanel2.getForm().loadRecord(record);
    		//    		//            Ext.net.DirectMethods.RefreshZonaAll();
    		//    		Ext.getCmp('ComboBox1').hide();
    		//    		Ext.getCmp('cbStates').hide();
    		//    		Ext.getCmp('Button3').hide();
    		//    		Ext.getCmp('Button2').show();
    		//    		Ext.getCmp('Button1').show();
    		//    		Ext.getCmp('Button4').hide();
    	}

    	var EjecutarAccion = function (command, id, cfecini, cfecfin, cActivo, cTipoMaterial) {


    		if (command == "Edit") {
    			Ext.getCmp('GridPanel2').getStore().removeAll()
    			Window1.show();

    			Ext.get('IdCruceField').dom.value = id;
    			Ext.get('DescripcionResposableField').dom.value = Ext.get('Responsable').dom.value;
    			Ext.get('DescripcionObraField').dom.value = Ext.get('Obra').dom.value;
    			Ext.get('FechaIncialField').dom.value = cfecini;
    			Ext.get('FechaFinalField').dom.value = cfecfin;
    			Ext.get('ActivoField').dom.value = cActivo;
    			Ext.get('TipoMaterialField').dom.value = cTipoMaterial;
    			Ext.net.DirectMethods.MostrarCrucematerial(cfecini, cfecfin, id, cTipoMaterial);
    			if (cTipoMaterial == "Valorizable") {
    				GridPanel2.getColumnModel().setHidden(6, true);
    			} else {
    				GridPanel2.getColumnModel().setHidden(6, false);
    			}
    			if (cActivo == "Revisado") {
    				Ext.getCmp('BtnRevisar').hide();
    			} else {
    				Ext.getCmp('BtnRevisar').show();
    			}

    		}
    		if (command == "Delete") {
    			var idcrucematerial = id;
    			//  var rows = Ext.getCmp('GridPanel1').getSelectionModel().getSelections();
    			Ext.Msg.confirm('Confirmación', 'Se eliminará el Cruce N° ' + idcrucematerial + ' , Confirma ?', function (btn, text) {
    				if (btn == 'yes') {
    					Ext.net.DirectMethods.Eliminar(idcrucematerial);
    				} else {

    				}
    			});


    		}

    	}



    	function btn_Eliminar() {
    		var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
    		var idObra = Ext.get('IdObra').dom.value;
    		var idProducto = Ext.get('IdProducto').dom.value;
    		var rows = Ext.getCmp('GridPanel1').getSelectionModel().getSelections();
    		if (rows.length === 0) {
    			return false;
    		}

    		Ext.Msg.confirm('Confirmación', 'Se eliminará la asignación para el producto: ' + idProducto + ' , Confirma ?', function (btn, text) {
    			if (btn == 'yes') {
    				Ext.net.DirectMethods.Eliminar(idObra, idactividad, idcatalogo);
    			} else {

    			}
    		});

    	}

    	function btn_ImprimirCruce() {

    		var CheckDiferencia = Ext.getCmp('ChkDifMayorCero').getValue();


    		if (Ext.getCmp('cbReporte').getValue() == 1) {
    			if (Ext.getCmp('Obra').getValue() == 0) {
    				alert("Debe seleccionar una Obra");
    				return;
    			}
    			var DescripcionObra = Ext.get('Obra').dom.value;

    			Ext.net.DirectMethods.btnImprimir(DescripcionObra, CheckDiferencia);

    		};
    		if (Ext.getCmp('cbReporte').getValue() == 2) {
    			var DescripcionObra = Ext.get('Obra').dom.value;
    			Ext.net.DirectMethods.btnImprimirCruceDetalle(DescripcionObra);

    		};

    		//    		Ext.net.DirectMethods.GetCatalogo();

    	}
    	function btn_CancelarImprimir() {

    		//    		Ext.net.DirectMethods.GetCatalogo();
    		VentanaReporte.hide();


    	}

    	


    


    	


    	function ValorInicialObra() {
    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
    		var div = document.getElementById('Agregar');
    		div.style.display = 'none';
    	}

    	function ValorInicialEmpleado() {
    		Ext.getCmp('Responsable').setValue(StoreEmpleado.getAt('0').get('IdEmpleado'));
    	}

    	function ValorInicialTipoMaterial() {

    		Ext.getCmp('CbTipoMaterial').setValue(StoreTipoMaterial.getAt('0').get('IdGenerica'));
    	}

    	

    	function btn_Agregar() {
    		//    		Ext.get('ComboBox1').dom.value = "";
    		//    		Ext.get('cbStates').dom.value = "";
    		var div = document.getElementById('Agregar');
    		div.style.display = 'block';

    		Ext.getCmp('FechaIni').show();
    		Ext.getCmp('FechaFin').show();
    		Ext.getCmp('CbTipoMaterial').show();
    		Ext.getCmp('BtnAgregar').hide();
    		Ext.getCmp('BtnCancelar').show();
    		Ext.getCmp('BtnGrabar').show();

    		//    		Ext.getCmp('cbStates').focus();

    	}

    	function btn_Cancelar() {

    		Ext.getCmp('FechaIni').hide();
    		Ext.getCmp('FechaFin').hide();
    		Ext.getCmp('CbTipoMaterial').hide();
    		Ext.getCmp('BtnAgregar').show();
    		Ext.getCmp('BtnCancelar').hide();
    		Ext.getCmp('BtnGrabar').hide();
    		var div = document.getElementById('Agregar');
    		div.style.display = 'none';

    	}

    	function btn_CancelarEnProceso() {
    		VentanaEnProceso.hide();


    	}

    	var CeldaSeleccionada = function (grid, rowIndex, columnIndex, e) {

    		var record = grid.getStore().getAt(rowIndex);
    		record.data['EnProceso'] = 9999;
    		record.commit();
    		alert(rowIndex);


    	}
    	function btn_CancelarJustificacion() {
    		VentanaJustificacion.hide();


    	}

    	function btnBuscar() {

//    		if (Ext.getCmp('ddlObra').getValue() == 0) {
//    			alert("Debe seleccionar una Obra");
//    			return;
//    		}
    		var IdVale = Ext.get('IdVale').dom.value;
    		Ext.net.DirectMethods.btnBuscarVale_Click(IdVale);

    	}

    	function btnBuscarSGI() {

    		if (Ext.getCmp('SGIBuscar').getValue().length == 0) {
    			alert("Debe ingresar un SGI");
    			return;

    		}
    		var SGI = Ext.get('SGIBuscar').dom.value;
    		Ext.net.DirectMethods.btnBuscarSGI_Click(SGI," ",1);

    	}
    	function btnBuscarOT() {

    		if (Ext.getCmp('NumeroOTBuscar').getValue().length == 0) {
    			alert("Debe ingresar un numero de OT");
    			return;

    		}
    		var NumeroOT = Ext.get('NumeroOTBuscar').dom.value;
    		Ext.net.DirectMethods.btnBuscarSGI_Click(" ", NumeroOT, 2);
    	

    	}
    	

    	function btn_Grabar() {

    		if (Ext.getCmp('Responsable').getValue().length == 0) {
    			alert("Debe seleccionar un Responsable de Actividad");
    			return;

    		}

    		if (Ext.getCmp('FechaIni').getValue().length == 0) {
    			alert("Debe ingresar la fecha inicial");
    			return;

    		}


    		if (Ext.getCmp('FechaFin').getValue().length == 0) {
    			alert("Debe ingresar la fecha Final");
    			return;
    		}


    		if (compara_fechas(Ext.get('FechaIni').dom.value, Ext.get('FechaFin').dom.value)) {
    			alert("La fecha inicial debe ser menor a la fecha final");
    			return;
    		}



    		Ext.Msg.confirm('Confirmación', 'Se agergará un nuevo registro. Esta seguro?', function (btn, text) {
    			if (btn == 'yes') {
    				Ext.net.DirectMethods.Grabar();
    				//    						record = GridPanel1.getSelectionModel().getSelected();
    				////    						Ext.getCmp('ComboBox1').hide();

    			} else {

    			}
    		});


    		//    			}


    		//    		}

    		Ext.getCmp('FechaIni').hide();
    		Ext.getCmp('FechaFin').hide();
    		Ext.getCmp('CbTipoMaterial').hide();
    		Ext.getCmp('BtnAgregar').show();
    		Ext.getCmp('BtnCancelar').hide();
    		Ext.getCmp('BtnGrabar').hide();
    		var div = document.getElementById('Agregar');
    		div.style.display = 'none';

    	}


    	function btn_GrabarEnProceso() {


    		//    		Ext.Msg.confirm('Confirmación', 'Se agergará un nuevo registro. Esta seguro?', function (btn, text) {
    		//    			if (btn == 'yes') {
    		var record = GridPanel2.getSelectionModel().getSelected();
    		record.data['EnProceso'] = Ext.get('CantidadEnProceso').dom.value;
    		record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['CantidadEjecutada'] - record.data['EnProceso'] - record.data['Justificado'];
    		record.data['MontoAuxiliar'] = record.data['Diferencia'] * record.data['PrecioAuxiliar'];

    		if (record.data['ObservacionJustificacion'] == undefined) {
    			record.data['ObservacionJustificacion'] = " ";
    		}

    		record.data['Observacion'] = Ext.get('ObservacionEnProceso').dom.value + ' ' + record.data['ObservacionJustificacion'];

    		record.data['Observacionproceso'] = Ext.get('ObservacionEnProceso').dom.value;
    		record.data['OrdenTrabajo'] = Ext.get('OTEnProceso').dom.value;
    		record.commit();
    		//CeldaSeleccionada;
    		Ext.net.DirectMethods.GrabarEnProceso();


    		//    			} else {

    		//    			}
    		//    		});

    		//    		alert(Ext.getCmp('cbCuadrilla').getValue());
    		//    		if (Ext.getCmp('cbCuadrilla').getValue() == 0) {
    		//    		} else {
    		//    			Ext.getCmp('GridPanel2').store.filter("IdCuadrilla", Ext.getCmp('cbCuadrilla').getValue());
    		//    		}

    	}

    	function btn_GrabarJustificacion() {


    		//    		Ext.Msg.confirm('Confirmación', 'Se agergará un nuevo registro. Esta seguro?', function (btn, text) {
    		//    			if (btn == 'yes') {
    		var record = GridPanel2.getSelectionModel().getSelected();
    		record.data['Justificado'] = Ext.get('CantidadJustificacion').dom.value;
    		record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['CantidadEjecutada'] - record.data['EnProceso'] - record.data['Justificado'];
    		record.data['MontoAuxiliar'] = record.data['Diferencia'] * record.data['PrecioAuxiliar'];
    		record.data['Observacionjustificacion'] = Ext.get('ObservacionJustificacion').dom.value;
    		if (record.data['Observacionproceso'] == undefined) {
    			record.data['Observacionproceso'] = " ";
    		}
    		record.data['Observacion'] = record.data['Observacionproceso'] + ' ' + Ext.get('ObservacionJustificacion').dom.value;
    		record.data['Observacionjustificacion'] = Ext.get('ObservacionJustificacion').dom.value;
    		record.commit();
    		Ext.net.DirectMethods.GrabarJustificacion();

    		//    			} else {

    		//    			}
    		//    		});



    	}


    	var enterKeyPressHandler = function (f, e) {
    		if (e.getKey() == e.ENTER) {
    			Ext.getCmp('ComboBox1').focus();

    		}
    	}


    	function btn_Revisar() {
    		var IdCruce = Ext.get('IdCruceField').dom.value;


    		Ext.Msg.confirm('Confirmación', 'Se Cerrara el Cruce N° ' + IdCruce + ' , Confirma ?', function (btn, text) {
    			if (btn == 'yes') {
    				Ext.net.DirectMethods.RevisarCruce(IdCruce);
    			} else {

    			}
    		});

    	}



    </script>

</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:TabPanel runat="server" Width="850">
        <Items>
            <ext:Panel 
                ID="Tab1"
                runat="server" 
                Title="ALMACEN" 
                AutoHeight="true"
                BodyPadding="6">
                <Content>
                    
				
							<ext:Panel ID="Panel4" runat="server" AutoHeight="true" Title="Vale de Almacen" Frame="true">
							<Content>
								<table>
									<tr>							
									<td><b>N°Vale</b></td><td style="padding-left:1px;">
									<%--<ext:TextField ID="IdVale" DataIndex="IdVale" runat="server" Width="60px"  />--%>
									<ext:NumberField
										ID="IdVale" 
										runat="server" 
										MinValue="0"
										MaxValue="100000"
										Width="60px"
									/>
									</td>
									<td><b></b></td><td style="padding-left:1px;">
										<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="70">
										 <Listeners><Click Fn="btnBuscar"></Click>
										  </Listeners>
										</ext:Button></td></tr>
								</table>
							</Content>
							</ext:Panel>
							<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Datos Generales de Vale" Frame="true">
							<Content>
									<table>	
									<tr>	
									<td><b>N°Vale</b>
									<ext:TextField ID="IdCabecera" DataIndex="IdCabecera" runat="server" Width="70px"/>									
									</td>
									<td><b>Obra</b></td><td style="padding-left:1px;"><ext:TextField ID="DescripcionObra" DataIndex="DescripcionObra" runat="server" Width="200px"/></td>
									<td><b>Movimiento</b></td><td style="padding-left:4px;"><ext:TextField ID="DescripcionMovimiento" DataIndex="DescripcionMovimiento" runat="server" Width="160px"  /></td>
									<td align="right"><b>Fecha</b></td><td style="padding-left:1px;"><ext:TextField ID="Fecha" DataIndex="Fecha" runat="server" Width="80px"  /></td>
									</tr>
									</table>
									<table>	
									<tr>
									<td><b>Cuadrilla</b></td><td style="padding-left:1px;"><ext:TextField ID="CodigoCuadrilla" DataIndex="CodigoCuadrilla" runat="server" Width="70px"   />
																						   <ext:TextField ID="DescripcioCuadrilla" DataIndex="DescripcioCuadrilla" runat="server" Width="170px" /></td>
									<td><b>Responsable</b></td><td style="padding-left:1px;"><ext:TextField ID="Responsable" DataIndex="Responsable" runat="server" Width="170px"   /></td>
									<td><b>Entregado/Recibido</b></td><td style="padding-left:1px;"><ext:TextField ID="Entregado" DataIndex="Entregado" runat="server" Width="170px"   /></td>
									</tr>
									</table>							
									<table>	
									<tr>
									<td><b>Referencia</b></td><td style="padding-left:1px;"><ext:TextField ID="Referencia" DataIndex="Referencia" runat="server" Width="100px"   />																						
									<td><b>Observacion</b></td><td style="padding-left:1px;"><ext:TextField ID="Observacion" DataIndex="Observacion" runat="server" Width="350px"   /></td>									
									</tr>
									</table>							
							</Content>
							</ext:Panel>

		
															<ext:GridPanel 
															ID="GridPanel2" 
															runat="server" 
															Height="250px"
															Title="Detalle de Vale" 															
															TrackMouseOver="true"
															Width="850px" 
															loadMask="true"
															AutoExpandColumn="Item"	>

															  <Store>
																<%--<ext:Store ID="StoreDetalleCruceMaterial" runat="server" OnRefreshData="Store_RefreshData" >--%>
																<ext:Store ID="StoreDetalle" runat="server" >
																	<Reader>
																		<ext:JsonReader IDProperty="Item">
																			<Fields>
                                												<ext:RecordField Name="Item" />
																				<ext:RecordField Name="IdProducto" />
																				<ext:RecordField Name="CodigoProducto" /> 
																				<ext:RecordField Name="Unidad" />
																				<ext:RecordField Name="PrecioUnitarioNacional" />
																				<ext:RecordField Name="TotalNacional" />
																				<ext:RecordField Name="Descripcion1" />
																				<ext:RecordField Name="Cantidad" />
																			</Fields>
																		</ext:JsonReader>
																	</Reader>
																</ext:Store>
															 </Store>
															  <ColumnModel ID="ColumnModel2" runat="server">
																<Columns>
																	<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="80px" />                    												
																	<ext:Column ColumnID="IdProducto" Header="IdProducto" DataIndex="IdProducto" Width="80px" Hidden="true" />
																	<ext:Column ColumnID="CodigoProducto" Header="Codigo" DataIndex="CodigoProducto" Width="80px" />
																	<ext:Column ColumnID="Descripcion1" Header="Descripcion" DataIndex="Descripcion1" Width="360px" />
																	<ext:Column ColumnID="Unidad" Header="Unidad" DataIndex="Unidad" Width="100px" />
																	<ext:Column ColumnID="Cantidad" Header="Cantidad" DataIndex="Cantidad" Width="60px" />
																	<ext:Column ColumnID="PrecioUnitarioNacional" Header="Precio" DataIndex="PrecioUnitarioNacional" Width="70px" />	
																	<ext:Column ColumnID="TotalNacional" Header="Total" DataIndex="TotalNacional" Width="70px" />	
																</Columns>
															</ColumnModel>
															 <LoadMask ShowMask="true" />
															  
															 <%--  <Listeners>
																		<CellClick  Fn="CeldaSeleccionada"></CellClick >        
																				  </Listeners>    --%>
															<SelectionModel>
																<ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
															</SelectionModel>

													<%--   <BottomBar>
															<ext:PagingToolbar ID="PagingToolbar2" 
																runat="server" 
																PageSize="15"
																DisplayInfo="true" 
																DisplayMsg="Registros {0} al {1} de {2}" 
																EmptyMsg="No plants to display" 
																/>
														</BottomBar>--%>
														</ext:GridPanel>
								
                </Content>
            </ext:Panel>
            <ext:Panel
                ID="Tab2"
                runat="server" 
                Title="PRODUCCION" 
                AutoHeight="true"
                BodyPadding="6">
                <Content>
                   

				            
				
							<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Orden de Trabajo" Frame="true">
							<Content>
								<table>
									<tr>							
									<td><b>N°SGI</b></td><td style="padding-left:1px;">
									<%--<ext:TextField ID="IdVale" DataIndex="IdVale" runat="server" Width="60px"  />--%>
									<ext:NumberField
										ID="SGIBuscar" 
										runat="server" 
										MinValue="0"
										
										Width="60px"
									/>
									</td>
									<td><b></b></td>
									<td style="padding-left:1px;">
									       <ext:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../../../../Libreria/Imagenes/search2.png">
										    <Listeners><Click Fn="btnBuscarSGI"></Click>
										  </Listeners>
                                          <%--  <DirectEvents>
                                                <Click OnEvent="BuscarPorCorrelativo" Timeout="36000"></Click>
                                            </DirectEvents>--%>
                                        </ext:ImageButton>
										<%--<ext:Button ID="BtnBuscarSGI" runat="server" Text="Buscar" Icon="DatabaseGo" Width="70">
										 <Listeners><Click Fn="btnBuscarSGI"></Click>
										  </Listeners>
										</ext:Button>--%>
										</td>
										<td><b>N°OT</b></td><td style="padding-left:1px;">
									<ext:TextField ID="NumeroOTBuscar" DataIndex="NumeroOTBuscar" runat="server" Width="60px"  />
									<%--<ext:NumberField
										ID="NumberField2" 
										runat="server" 
										MinValue="0"
										MaxValue="100000"
										Width="60px"
									/>--%>
									</td>
										<td style="padding-left:1px;">
									       <ext:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../../../../Libreria/Imagenes/search2.png">
										    <Listeners><Click Fn="btnBuscarOT"></Click>
										  </Listeners>
                                          <%--  <DirectEvents>
                                                <Click OnEvent="BuscarPorCorrelativo" Timeout="36000"></Click>
                                            </DirectEvents>--%>
                                        </ext:ImageButton>
										<%--<ext:Button ID="BtnBuscarSGI" runat="server" Text="Buscar" Icon="DatabaseGo" Width="70">
										 <Listeners><Click Fn="btnBuscarSGI"></Click>
										  </Listeners>
										</ext:Button>--%>
										</td>

										</tr>
								</table>
							</Content>
							</ext:Panel>
							<ext:Panel ID="Panel3" runat="server" AutoHeight="true" Title="Datos Generales de la OT" Frame="true">
							<Content>
									<table>	
									<tr>	
									<td><b>N°SGI</b><ext:TextField ID="SGI" DataIndex="SGI" runat="server" Width="60px"/></td>
									<td><b>NIS</b></td><td style="padding-left:1px;"><ext:TextField ID="NIS" DataIndex="NIS" runat="server" Width="60px"/></td>
									<td><b>N°OT</b></td><td style="padding-left:1px;"><ext:TextField ID="NumeroOT" DataIndex="NumeroOT" runat="server" Width="60px"   /></td>
									<td><b>FechaInicio</b></td><td style="padding-left:1px;"><ext:TextField ID="FechaInicio" DataIndex="FechaInicio" runat="server" Width="80px" /></td>
									<td><b>FechaTermino</b></td><td style="padding-left:1px;"><ext:TextField ID="FechaTermino" DataIndex="FechaTermino" runat="server" Width="80px"   />																						
									<td><b>FechaDigitacion</b></td><td style="padding-left:1px;"><ext:TextField ID="FechaDigitacion" DataIndex="FechaDigitacion" runat="server" Width="80px"   /></td>									
						
									</tr>
									</table>
									<table>	
									<tr>
									<td><b>Actividad</b></td><td style="padding-left:4px;"><ext:TextField ID="Actividad" DataIndex="Actividad" runat="server" Width="450px"  /></td>
									<td><b>Cuadrilla</b></td><td style="padding-left:1px;"><ext:TextField ID="Cuadrilla" DataIndex="Cuadrilla" runat="server" Width="70px"   />
									</tr>
									</table>							
									<table>	
									<tr>
									
									<td><b>Direccion</b></td><td style="padding-left:1px;"><ext:TextField ID="Direccion" DataIndex="Direccion" runat="server" Width="300px"  /></td>
									<td><b>Urbanizacion</b></td><td style="padding-left:1px;"><ext:TextField ID="Urbanizacion" DataIndex="Urbanizacion" runat="server" Width="200px"   /></td>
									<td><b>Distrito</b></td><td style="padding-left:1px;"><ext:TextField ID="Distrito" DataIndex="Distrito" runat="server" Width="120px"   /></td>									
									</tr>
									</table>							
							</Content>
							</ext:Panel>


										<ext:GridPanel 
															ID="GridPanel3" 
															runat="server" 
															Height="100px"
															Title="Detalle de Subactividad" 															
															TrackMouseOver="true"
															Width="850px" 
															loadMask="true"
															AutoExpandColumn="IdProducto"	>

															  <Store>
																<%--<ext:Store ID="StoreDetalleCruceMaterial" runat="server" OnRefreshData="Store_RefreshData" >--%>
																<ext:Store ID="StoreSubactividad" runat="server" >
																	<Reader>
																		<ext:JsonReader IDProperty="IdProducto">
																			<Fields>
                                												<%--<ext:RecordField Name="Item" />--%>
																				<ext:RecordField Name="IdProducto" />
																				<ext:RecordField Name="CodigoProducto" /> 
																				<ext:RecordField Name="Unidad" />
																				<ext:RecordField Name="PrecioUnitarioNacional" />
																				<ext:RecordField Name="TotalNacional" />
																				<ext:RecordField Name="Descripcion1" />
																				<ext:RecordField Name="Cantidad" />
																			</Fields>
																		</ext:JsonReader>
																	</Reader>
																</ext:Store>
															 </Store>
															  <ColumnModel ID="ColumnModel3" runat="server">
																<Columns>
																	<%--<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="80px" />  --%>                  												
																	<ext:Column ColumnID="IdProducto" Header="IdProducto" DataIndex="IdProducto" Width="50px"  />
																	<%--<ext:Column ColumnID="CodigoProducto" Header="Codigo" DataIndex="CodigoProducto" Width="80px" />--%>
																	<ext:Column ColumnID="Descripcion1" Header="Descripcion" DataIndex="Descripcion1" Width="450px" />
																	<ext:Column ColumnID="Unidad" Header="Unidad" DataIndex="Unidad" Width="100px" />
																	<ext:Column ColumnID="Cantidad" Header="Cantidad" DataIndex="Cantidad" Width="60px" />
																	<ext:Column ColumnID="PrecioUnitarioNacional" Header="Precio" DataIndex="PrecioUnitarioNacional" Width="70px" />	
																	<ext:Column ColumnID="TotalNacional" Header="Total" DataIndex="TotalNacional" Width="70px" />	
																</Columns>
															</ColumnModel>
															 <LoadMask ShowMask="true" />
															  
															 <%--  <Listeners>
																		<CellClick  Fn="CeldaSeleccionada"></CellClick >        
																				  </Listeners>    --%>
															<SelectionModel>
																<ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
															</SelectionModel>

												
														</ext:GridPanel>
								
		
															<ext:GridPanel 
															ID="GridPanel1" 
															runat="server" 
															Height="250px"
															Title="Detalle de Materiales" 															
															TrackMouseOver="true"
															Width="850px" 
															loadMask="true"
															AutoExpandColumn="IdProducto"	>

															  <Store>
																<%--<ext:Store ID="StoreDetalleCruceMaterial" runat="server" OnRefreshData="Store_RefreshData" >--%>
																<ext:Store ID="StoreMaterial" runat="server" >
																	<Reader>
																		<ext:JsonReader IDProperty="IdProducto">
																			<Fields>
                                												<%--<ext:RecordField Name="Item" />--%>
																				<ext:RecordField Name="IdProducto" />
																				<ext:RecordField Name="CodigoProducto" /> 
																				<ext:RecordField Name="Unidad" />
																				<ext:RecordField Name="PrecioUnitarioNacional" />
																				<ext:RecordField Name="TotalNacional" />
																				<ext:RecordField Name="Descripcion1" />
																				<ext:RecordField Name="Cantidad" />
																			</Fields>
																		</ext:JsonReader>
																	</Reader>
																</ext:Store>
															 </Store>
															  <ColumnModel ID="ColumnModel1" runat="server">
																<Columns>
																	<%--<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="80px" />  --%>                  												
																	<ext:Column ColumnID="IdProducto" Header="IdProducto" DataIndex="IdProducto" Width="50px"  />
																	<%--<ext:Column ColumnID="CodigoProducto" Header="Codigo" DataIndex="CodigoProducto" Width="80px" />--%>
																	<ext:Column ColumnID="Descripcion1" Header="Descripcion" DataIndex="Descripcion1" Width="450px" />
																	<ext:Column ColumnID="Unidad" Header="Unidad" DataIndex="Unidad" Width="100px" />
																	<ext:Column ColumnID="Cantidad" Header="Cantidad" DataIndex="Cantidad" Width="60px" />
																	<ext:Column ColumnID="PrecioUnitarioNacional" Header="Precio" DataIndex="PrecioUnitarioNacional" Width="70px" />	
																	<ext:Column ColumnID="TotalNacional" Header="Total" DataIndex="TotalNacional" Width="70px" />	
																</Columns>
															</ColumnModel>
															 <LoadMask ShowMask="true" />
															  
															 <%--  <Listeners>
																		<CellClick  Fn="CeldaSeleccionada"></CellClick >        
																				  </Listeners>    --%>
															<SelectionModel>
																<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
															</SelectionModel>

												
														</ext:GridPanel>
								











                </Content>
            </ext:Panel>
        </Items>
    </ext:TabPanel>

</body>
</html>
