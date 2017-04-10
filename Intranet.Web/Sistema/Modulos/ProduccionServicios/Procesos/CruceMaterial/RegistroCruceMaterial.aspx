<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCruceMaterial.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CruceMaterial.RegistroCruceMaterial" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    		    		if (record.data.cActivo=="Revisado") {
    		    			Bttn2.setDisabled(true);
    		    			Bttn2.setTooltip("Disabled");
    		    		}
    		
    	};


    	var template = '<span style="color:{0};">{1}</span>';

    	var ColorEstado = function (value) {
   		return String.format(template, (value == "Pendiente") ? "red" : "green", value);
    	};

        var ColorDiferencia = function (value) {
        return String.format(template, (value > 0) ? "red" : "black", value);
         };

        var ColorTipoMaterial = function (value) {
            return String.format(template, (value =="Valorizable") ? "blue" : "brown", value);
        };
 
    	function linkProcesoClick(recordId) {
    		VentanaEnProceso.show();
    		Ext.get('DescripcionProductoEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("DescripcionAuxiliar")
    		Ext.get('IdAuxiliarEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("IdAuxiliar")
    		Ext.get('CodigoCuadrillaEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("CodigoCuadrilla")
    		Ext.get('CantidadEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("EnProceso")
    		Ext.get('OTEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("OrdenTrabajo")
    		Ext.get('ObservacionEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Observacionproceso")
    		Ext.get('ItemEnProceso').dom.value = StoreDetalleCruceMaterial.getById(recordId).get("Item")
    		Ext.getCmp('CantidadEnProceso').focus(true, 10); 
    	}

    	function linkProcesoRenderer(value, meta, record) {
//    	    if (Ext.get('ActivoField').dom.value == "Revisado" || compara_dias(Ext.get('FechaIncialField').dom.value, Ext.get('FechaFinalField').dom.value)) {
            if (Ext.get('ActivoField').dom.value == "Revisado" ) {
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
    		Ext.getCmp('CantidadJustificacion').focus(true, 10); 
    	}

    	function linkIdCuadrillaClick(recordId) {
    	    Ext.net.DirectMethods.ReporteCruceProducto(StoreDetalleCruceMaterial.getById(recordId).get("IdAuxiliar"), StoreDetalleCruceMaterial.getById(recordId).get("IdCuadrilla"), Ext.get('Obra').dom.value);
    	}

    	function linkJustificaRenderer(value, meta, record) {
//    	    if (Ext.get('ActivoField').dom.value == "Revisado" || compara_dias(Ext.get('FechaIncialField').dom.value, Ext.get('FechaFinalField').dom.value)) {
            if (Ext.get('ActivoField').dom.value == "Revisado" ) {
    			return String.format("<a class='company-link'>{0}</a>", value, record.id);
    		} else {
    			return String.format("<a class='company-link' href='#' onclick='linkJustificaClick(\"{1}\");'>{0}</a>", value, record.id);
			}
    	}

    	function linkIdAuxiliar(value, meta, record) {
    	    return String.format("<a class='company-link' href='#' onclick='linkIdCuadrillaClick(\"{1}\");'>{0}</a>", value, record.id);
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

        	  if (Ext.getCmp('cbReporte').getValue() == 3) {
    			      var DescripcionObra = Ext.get('Obra').dom.value;
    			      Ext.net.DirectMethods.btnImprimirCruceDetalleTeorico(DescripcionObra);

    			  };


    	}
    	function btn_CancelarImprimir() {
    		VentanaReporte.hide();
    	}

    	function GetCatalogo() {
    		Ext.net.DirectMethods.GetCatalogo();

    	}



    	function GetCabeceraCruceResponsable() {
    		Ext.net.DirectMethods.ListarCabeceraCruceResponsable();

    	}


    	function GetResponsablesBase() {
    		Ext.net.DirectMethods.ListarResponsableBase();

    	}


    	function GetCrucePoCuadrilla() {

    		if (Ext.getCmp('cbCuadrilla').getValue() == 0) {
    			Ext.getCmp('GridPanel2').store.clearFilter();
			} else {
    			Ext.getCmp('GridPanel2').store.filter("IdCuadrilla", Ext.getCmp('cbCuadrilla').getValue());
			}
    		
    	}


    	function ValorInicialObra() {
    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
    		var div = document.getElementById('Agregar');
    		div.style.display = 'none';
    		if (StoreObra.getCount() == 1) {
    			Ext.getCmp('Obra').disable();
    		} else { }
    	}

    	function ValorInicialEmpleado() {
    		Ext.getCmp('Responsable').setValue(StoreEmpleado.getAt('0').get('IdEmpleado'));
    	}

    	function ValorInicialTipoMaterial() {
    		
    		Ext.getCmp('CbTipoMaterial').setValue(StoreTipoMaterial.getAt('0').get('IdGenerica'));
    	}
 
    	var triggerHandler = function (el, trigger, index) {
    		//    		var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
    		//    		var cDescripcionProducto = Ext.get('cbStates').dom.value;
    		//    		switch (index) {
    		//    			case 0:
    		//    				this.focus().clearValue(); trigger.hide();

    		//    				break;
    		//    			case 1:
    		//    				if (cDescripcionAuxiliar.length != 0) {

    		//    					if (cDescripcionProducto.length != 0) {
    		//    						ComboBox1.getEl().applyStyles('background:white');
    		//    						Ext.net.DirectMethods.InsertarAuxiliar(cDescripcionAuxiliar);
    		//    						Ext.get('GridPanel1').focus();
    		//    					}a
    		//    				}
    		//    				break;
    		//    		}
    	}

    	function btn_Agregar() {
    		var div = document.getElementById('Agregar');
    		div.style.display = 'block';
    		Ext.getCmp('FechaIni').show();
    		Ext.getCmp('FechaFin').show();
    		Ext.getCmp('CbTipoMaterial').show();
    		Ext.getCmp('BtnAgregar').hide();
    		Ext.getCmp('BtnCancelar').show();
    		Ext.getCmp('BtnGrabar').show();

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

    		if (Ext.getCmp('ddlObra').getValue() == 0) {
    			alert("Debe seleccionar una Obra");
    			return;
    		}

    		Ext.net.DirectMethods.btnBuscar_Click();

    	}


    	function btn_Imprimir() {
    		Ext.getCmp('cbCuadrillaReporte').setValue(0);
    		Ext.getCmp('cbReporte').setValue(StoreReporte.getAt('0').get('IdReporte'));
    		VentanaReporte.show();
         }


  function btn_Regresar() {
      Window1.hide();
  }


	function compara_fechas(fecha1, fecha2)  
	  {  
		var xMonth=fecha1.substring(3, 5);  
		var xDay=fecha1.substring(0, 2);  
		var xYear=fecha1.substring(6,10);  
		var yMonth=fecha2.substring(3, 5);  
		var yDay=fecha2.substring(0, 2);  
		var yYear=fecha2.substring(6,10);  
		if (xYear> yYear)  
		{  
        return(true)  
		}  
		else  
		{  
		if (xYear == yYear)  
		{   
			if (xMonth> yMonth)  
			{  
				return(true)  
			}  
			else  
			{   
				if (xMonth == yMonth)  
				{  
					if (xDay> yDay)  
					  return(true);  
					else  
					  return(false);  
				}  
				else  
					return(false);  
			}  
			}  
		else  
        return(false);  
		}  
	}

	function compara_dias(fecha1, fecha2) {
	    var xMonth = fecha1.substring(3, 5);
	    var xDay = fecha1.substring(0, 2);
	    var xYear = fecha1.substring(6, 10);
	    var yMonth = fecha2.substring(3, 5);
	    var yDay = fecha2.substring(0, 2);
	    var yYear = fecha2.substring(6, 10);
	                    if (  yDay-xDay >= 29)
	                        return (true);
	                    else
	                        return (false);
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

//   var index = this.StoreCruceMaterial.find('cFechaInicial', Ext.getCmp('FechaIni').getValue(), 0, true, false);  
        //			StoreCruceMaterial.each(function (record) {
        //			    if (Ext.getCmp('FechaIni').getValue() == record.get('cFechaInicial'))
        //			        alert("entro");
        //                    
           //			});
//   alert(index);
//                alert(" no entro");
//			return;
    		Ext.Msg.confirm('Confirmación', 'Se agergará un nuevo registro. Esta seguro?', function (btn, text) {
    			if (btn == 'yes') {
    				Ext.net.DirectMethods.Grabar();
    			} else {

    			}
    		});


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
    				if (Ext.get('TipoMaterialField').dom.value == "Valorizable") {
    				    record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['CantidadEjecutada'] - record.data['EnProceso'] - record.data['Justificado'];   
    				} else {
    				    record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['Teorico'] - record.data['EnProceso'] - record.data['Justificado'];
                    }
    				//record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['CantidadEjecutada'] - record.data['EnProceso'] - record.data['Justificado'];
    				record.data['MontoAuxiliar'] = record.data['Diferencia'] * record.data['PrecioAuxiliar'];
    				if (record.data['ObservacionJustificacion'] == undefined) {
    					record.data['ObservacionJustificacion'] = " ";
					}
					record.data['Observacion'] = Ext.get('ObservacionEnProceso').dom.value + ' ' + record.data['ObservacionJustificacion'];
    				record.data['Observacionproceso'] = Ext.get('ObservacionEnProceso').dom.value ;
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



    				var record = GridPanel2.getSelectionModel().getSelected();
    				record.data['Justificado'] = Ext.get('CantidadJustificacion').dom.value;
    				if (Ext.get('TipoMaterialField').dom.value == "Valorizable") {
    				    record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['CantidadEjecutada'] - record.data['EnProceso'] - record.data['Justificado'];
    				} else {
    				    record.data['Diferencia'] = record.data['CantidadAlmacen'] - record.data['Teorico'] - record.data['EnProceso'] - record.data['Justificado'];
                    }
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

   function Validar(Cadena){  
    var Fecha= new String(Cadena)  
    var Ano= new String(Fecha.substring(Fecha.lastIndexOf("/")+1,Fecha.length))  
    var Mes= new String(Fecha.substring(Fecha.indexOf("/")+1,Fecha.lastIndexOf("/")))  
    var Dia= new String(Fecha.substring(0,Fecha.indexOf("/")))  
    if (isNaN(Ano) || Ano.length<4 || parseFloat(Ano)<1900){  
            alert('Año inválido')  
        return false  
    }  
    if (isNaN(Mes) || parseFloat(Mes)<1 || parseFloat(Mes)>12){  
        alert('Mes inválido')  
        return false  
    }  
    if (isNaN(Dia) || parseInt(Dia, 10)<1 || parseInt(Dia, 10)>31){  
        alert('Día inválido')  
        return false  
    }  
    if (Mes==4 || Mes==6 || Mes==9 || Mes==11 || Mes==2) {  
        if (Mes==2 && Dia > 28 || Dia>30) {  
            alert('Día inválido')  
            return false  
        }  
    }  
  return true    
}  
  




    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

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
	
   
           <ext:Store ID="StoreCruceMaterial" runat="server" >
            <Reader>
                	<ext:JsonReader IDProperty="IdCabeceraCruceMaterial">
                    <Fields>
                        <ext:RecordField Name="IdCabeceraCruceMaterial" />
                        <ext:RecordField Name="cFechaInicial"  />
                        <ext:RecordField Name="cFechaFinal" />
                        <ext:RecordField Name="cActivo" />
				        <ext:RecordField Name="DescripcionValorizable" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>

		<ext:Store ID="StoreEmpleado" runat="server" >
            <Reader>
                	<ext:JsonReader IDProperty="IdEmpleado">
                    <Fields>
                        <ext:RecordField Name="IdEmpleado" />
                        <ext:RecordField Name="NombresApellidos" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>
		
       
	   <ext:Store ID="StoreTipoMaterial" runat="server" >
            <Reader>
                	<ext:JsonReader IDProperty="IdGenerica">
                    <Fields>
                        <ext:RecordField Name="IdGenerica" />
                        <ext:RecordField Name="A2" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>
		
		
        <div id="Contenedor1">
         <ext:Panel ID="Panel2" runat="server" Title="" Frame="true" Padding="2" Width="1100" >
			<Content>
			<table>
				<tr>
				<td>Obra</td>
					<td>
                                <ext:ComboBox ID="Obra" DataIndex="IdObra" 
                                    runat="server"  Width="300px"
                                    StoreID="StoreObra" 
                                    DisplayField="DescripcionCorta" 
                                    Editable="false" 
                                    ValueField="IdObra"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Obra" 
                                    SelectOnFocus="true"
                                    ValueNotFoundText="Selecione Obra"  >
                                      <Listeners>
                                        <Select Fn="GetResponsablesBase" />
                                        <BeforeRender Fn="ValorInicialObra"/>
                                      </Listeners>    
                                </ext:ComboBox>
								</td>
								<td></td>
								<td></td>
								<td></td>
								<td>RESPONSABLE</td>
								<td>
								 <ext:ComboBox ID="Responsable" DataIndex="IdObra" 
                                    runat="server"   Width="300px"
                                    StoreID="StoreEmpleado" 
                                    DisplayField="NombresApellidos" 
                                    Editable="false" 
                                    ValueField="IdEmpleado"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="" 
                                    SelectOnFocus="true"
                                    ValueNotFoundText=""  >
                                      <Listeners>
                                        <Select Fn="GetCabeceraCruceResponsable" />
                                        <BeforeRender Fn="ValorInicialEmpleado"/>
                                      </Listeners>    
                                 </ext:ComboBox>
								</td>
									<td>
									<%--	<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="70">
										<DirectEvents>
										<Click OnEvent="BtnBuscarCruceMatResponsable">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
										</Click>
										</DirectEvents>
										</ext:Button>--%>
									</td>
							</tr>
					</table>
       		</Content>
		</ext:Panel>

        
          <ext:Panel ID="Panel3" runat="server" Title="" Frame="true" Padding="1" Width="1100" >
			<Content>    
			      <div id="Agregar">
					 <table>
					 <tr>
					    <td>Fecha Inicial</td>
						<td><ext:DateField ID="FechaIni" runat="server"  Format="dd/MM/yyyy"  Width="120px" AllowBlank="false" Editable="false"  /></td>    
						<td></td>
				
						<td></td>
						<td>Fecha Final</td>
                        <td><ext:DateField ID="FechaFin" runat="server" Format="dd/MM/yyyy" Width="120px" Editable="false" /></td>
						<td>Tipo Material</td>
						<td>
								<ext:ComboBox ID="CbTipoMaterial" DataIndex="IdGenerica" 
                                    runat="server"  Width="150px"
                                    StoreID="StoreTipoMaterial" 
                                    DisplayField="A2" 
                                    ValueField="IdGenerica"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Tipo Material" 
                                    SelectOnFocus="true"
                                    Editable="false" 
                                    ValueNotFoundText="Selecione Tipo Material"  >
                                      <Listeners>
                                        <BeforeRender Fn="ValorInicialTipoMaterial"/>
                                      </Listeners>    
                                </ext:ComboBox>
						</td>
						<td></td>
                             <td>
                                <ext:Button ID="BtnGrabar" runat="server" Text="Grabar" Icon="Disk">
                                <Listeners><Click Fn="btn_Grabar"></Click>
                                </Listeners>
                                </ext:Button>
							 </td>
							 <td>
                                <ext:Button ID="BtnCancelar" runat="server" Text="Cancelar" Icon="Cancel">
                                <Listeners><Click Fn="btn_Cancelar"></Click>
                                </Listeners>
                                </ext:Button>
							 </td>
					</tr>
					  </table>  
					  </div>
					  <table>
                    <tr>
                              <td>
                                <ext:Button ID="BtnAgregar" runat="server" Text="Agregar Nuevo Cruce" Icon="Add">
                                <Listeners><Click Fn="btn_Agregar"></Click>
                                </Listeners>
                                </ext:Button>
                              </td>
					</tr>
                    </table>  
                        
       		</Content>
		</ext:Panel>
       

        <ext:Panel ID="Panel1" runat="server" Width="1100" Height="300">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="StoreCruceMaterial" 
                            StripeRows="true"
                            Title="Registro de Cruce de Materiales" 
                            TrackMouseOver="true"
                            Width="800" 
                            AutoExpandColumn="IdCabeceraCruceMaterial">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdCabeceraCruceMaterial" Header="IdCruce" Width="150" DataIndex="IdCabeceraCruceMaterial" />
                                    <ext:Column ColumnID="cFechaInicial" Header="FechaInicial" Width="150" DataIndex="cFechaInicial" />
                                    <ext:Column ColumnID="cFechaFinal" Header="FechaFinal" Width="150" DataIndex="cFechaFinal" />
									<ext:Column ColumnID="DescripcionValorizable" Header="TipoMaterial" Width="150" DataIndex="DescripcionValorizable" >
                                        <Renderer Fn="ColorTipoMaterial" />
                                    </ext:Column>
                                    <ext:Column ColumnID="cActivo"   Header="Estado" Width="150" DataIndex="cActivo"> 
                                        <Renderer Fn="ColorEstado" />
                                    </ext:Column>
									<ext:CommandColumn Width="190">
									<Commands>										
										<ext:GridCommand Icon="PageEdit" CommandName="Edit" Text="Ver"  />
										<%--<ext:GridCommand Icon="NoteEdit" CommandName="EnProceso" Text="EnProceso" />--%>
										<ext:GridCommand Icon="Delete" CommandName="Delete" Text="Eliminar" />
									</Commands>
										<PrepareToolbar Fn="prepare" />   
									</ext:CommandColumn>
                                </Columns>
                            </ColumnModel>

								 <DirectEvents>
								<Command OnEvent="Command_Handler">
								<EventMask ShowMask="true" />
								</Command>
								</DirectEvents>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <%--<RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />--%>
                                        <RowSelect Fn="filaseleccionada" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>     
			
							<%--  <Listeners>
                                <Command Handler="Eliminar(command, record.data.IdCuadrilla,record.data.IdObra,record.data.CodigoCuadrilla);" />
                            </Listeners>--%>
                            <BottomBar>
							<ext:PagingToolbar ID="PagingToolbar1" 
								runat="server" 
								PageSize="10"
								DisplayInfo="true" 
								DisplayMsg="Registros {0} al {1} de {2}" 
								EmptyMsg="No plants to display" 
								/>
							</BottomBar>
							<Listeners>
								 <Command Handler="EjecutarAccion(command, record.data.IdCabeceraCruceMaterial,record.data.cFechaInicial,record.data.cFechaFinal,record.data.cActivo,record.data.DescripcionValorizable);"  />
								
							</Listeners>
						

                        </ext:GridPanel>         
                    </West>

                   <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Left" >
                            <Items>
                            </Items>
                        </ext:FormPanel>
                        
                   </Center>
                  
                </ext:BorderLayout>
            </Items>
        </ext:Panel>
        </div>

		<ext:Window 
            ID="Window1" 
            runat="server" 
            Icon="Application"
            Height="500px" 
            Width="1110"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="true" 
			Hidden = "true"
            Modal="true">
            <Content>
				<ext:Panel ID="Panel4" runat="server" AutoHeight="true" Title="Datos Cruce de Materiales" Frame="true">
					<Content>
						<table>
						<tr>
						<td><b>N°Cruce</b></td>
							<ext:TextField ID="ActivoField" DataIndex="ActivoField" runat="server" Hidden="true"   />
							<%--<ext:TextField ID="TipoMaterialField" DataIndex="TipoMaterialField" runat="server" Hidden="true"   />--%>
							<td style="padding-left:1px;"><ext:TextField ID="IdCruceField" DataIndex="IdCruceField" runat="server" Width="40px" ReadOnly="true" /></td>
							<td><b>Responsable</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="DescripcionResposableField" DataIndex="DescripcionResposableField" runat="server" Width="160px" ReadOnly="true" /></td>
							<td><b>Obra</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="DescripcionObraField" DataIndex="DescripcionObraField" runat="server" Width="160px" ReadOnly="true" /></td>
							<td align="right"><b>Fecha Inicial</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="FechaIncialField" DataIndex="FechaIncialField" runat="server" Width="80px" ReadOnly="true" /></td>
							<td><b>Fecha Final</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="FechaFinalField" DataIndex="FechaFinalField" runat="server" Width="80px"  ReadOnly="true" /></td>
						</tr>
						</table>
						<table>
						<tr>
						<td><b>Cuadrilla</b></td>
						<td style="padding-left:1px;">
							<ext:ComboBox ID="cbCuadrilla" runat="server" DisplayField="CodigoCuadrilla" ValueField="IdCuadrilla" Width="240px" ItemSelector="div.list-item" Editable="false" >
												<Store>
													<ext:Store ID="StoreCuadrilla" runat="server">
														<Reader>
															<ext:JsonReader IDProperty="IdCuadrilla">
																<Fields>
																	<ext:RecordField Name="IdCuadrilla" />
																	<ext:RecordField Name="CodigoCuadrilla" />
																	<ext:RecordField Name="Descripcion" />																	
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
																<b>{CodigoCuadrilla}</b><br/>{Descripcion}<br/>
															</div>
														</tpl>
													</Html>
												</Template>
												      <Listeners>
														<Select Fn="GetCrucePoCuadrilla" />
														<%--<AfterRender Fn="ValorInicial"/>--%>
												 </Listeners>    
							</ext:ComboBox>
						</td>
					
						<td><b>Tipo Material</b></td>
						
						<td style="padding-left:1px;"><ext:TextField ID="TipoMaterialField" DataIndex="TipoMaterialField" runat="server" Width="170" ReadOnly="true" /></td>
						
						<td>
							<%--<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="70">--%>
							 <%-- <Listeners><Click Fn="btnBuscar"></Click>
                              </Listeners>--%>
							<%--</ext:Button>--%>
						</td>
						<td>
						<%--	<ext:Button ID="BtnVerTodo" runat="server" Text="VerTodo" Icon="DatabaseGo" Width="70">
								 <Listeners><Click Fn="btn_Imprimir"></Click>
                                </Listeners>
							</ext:Button>--%>

						</td>
    					<td></td>
						<td></td>
                        <td>
							<ext:Button ID="BtnImprimir" runat="server" Text="Reporte" Icon="Report" Width="70">
								 <Listeners><Click Fn="btn_Imprimir"></Click>
                                </Listeners>
							</ext:Button>
						</td>

                        <td>
							<ext:Button ID="BtnRevisar" runat="server" Text="Revisar" Icon="Tick" Width="70">
								 <Listeners><Click Fn="btn_Revisar"></Click>
                                </Listeners>
							</ext:Button>
						</td>
					    <td>
							<ext:Button ID="BtnRegresar" runat="server" Text="Regresar" Icon="PageBack" Width="70">
								 <Listeners><Click Fn="btn_Regresar"></Click>
                                </Listeners>
							</ext:Button>
						</td>

					</tr>
				</table>
			</Content>
		</ext:Panel>
		<%--<ext:Panel ID="Panel5" runat="server" AutoHeight="true" Title="Resultado de Cruce de Materiales" >--%>
		<%--	<Items>--%>
				<ext:GridPanel 
				ID="GridPanel2" 
				runat="server" 
                Height="360px"
                Collapsible="true" 
                TrackMouseOver="true"
                Width="1090px" 
                Title="Resultado de Cruce de Materiales" 
				loadMask="true"
                AutoExpandColumn="CodigoCuadrilla"	>
                  <Store>
					<%--<ext:Store ID="StoreDetalleCruceMaterial" runat="server" OnRefreshData="Store_RefreshData" >--%>
					<ext:Store ID="StoreDetalleCruceMaterial" runat="server" >
						<Reader>
							<ext:JsonReader IDProperty="Item">
								<Fields>
                                	<ext:RecordField Name="Item" />
									<ext:RecordField Name="IdAuxiliar" />
									<ext:RecordField Name="DescripcionAuxiliar" /> 
									<ext:RecordField Name="CantidadAlmacen" />
									<ext:RecordField Name="CantidadEjecutada" />
                                    <ext:RecordField Name="Diferencia" />
									<ext:RecordField Name="EnProceso" />
									<ext:RecordField Name="Justificado" />
									<ext:RecordField Name="PrecioAuxiliar" />
                                    <ext:RecordField Name="MontoAuxiliar" />
									<ext:RecordField Name="CodigoCuadrilla" />
                                    <ext:RecordField Name="DescripcionCuadrilla" />
									<ext:RecordField Name="Observacion" />
									<ext:RecordField Name="Observacionjustificacion" />
									<ext:RecordField Name="Observacionproceso" />
									<ext:RecordField Name="OrdenTrabajo" />
									<ext:RecordField Name="Teorico" />
									<ext:RecordField Name="IdCuadrilla" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				 </Store>
                  <ColumnModel ID="ColumnModel2" runat="server">
                    <Columns>
                        <ext:Column ColumnID="CodigoCuadrilla" Header="Cuadrilla" DataIndex="CodigoCuadrilla" Width="80px" />
                    	<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="70px" hidden="true"/>
						<ext:Column ColumnID="IdAuxiliar" Header="Codigo" DataIndex="IdAuxiliar" Width="60px" >
                        <Renderer Fn="linkIdAuxiliar" />
						</ext:Column>
						<ext:Column ColumnID="DescripcionAuxiliar" Header="Descripcion" DataIndex="DescripcionAuxiliar" Width="360px" />
						<ext:Column ColumnID="CantidadAlmacen" Header="Almacen" DataIndex="CantidadAlmacen" Width="60px" />
						<ext:Column ColumnID="CantidadEjecutada" Header="Produccion" DataIndex="CantidadEjecutada" Width="70px" />
						<ext:Column ColumnID="Teorico" Header="Teorico" DataIndex="Teorico" Width="60px" />
						<ext:Column ColumnID="EnProceso" Header="Proceso" DataIndex="EnProceso" Width="60px">
						<Renderer Fn="linkProcesoRenderer" />
						</ext:Column>
						<ext:Column ColumnID="Justificado" Header="Justif." DataIndex="Justificado" Width="60px">
						<Renderer Fn="linkJustificaRenderer" />						
						</ext:Column>
						<ext:Column ColumnID="Diferencia" Header="Diferencia" DataIndex="Diferencia" Width="60px" >
                        <Renderer Fn="ColorDiferencia" />
                        </ext:Column>
						<ext:Column ColumnID="PrecioAuxiliar" Header="Precio" DataIndex="PrecioAuxiliar" Width="60px" />
						<ext:Column ColumnID="MontoAuxiliar" Header="Monto" DataIndex="MontoAuxiliar" Width="60px" />
						<ext:Column ColumnID="Observacion" Header="Observacion" DataIndex="Observacion" Width="260px" />
						<ext:Column ColumnID="Observacionjustificacion" Header="Observacionjustificacion" DataIndex="Observacionjustificacion" Hidden="true"  />
						<ext:Column ColumnID="OrdenTrabajo" Header="OrdenTrabajo" DataIndex="OrdenTrabajo" Hidden="true"  />
						<ext:Column ColumnID="Observacionproceso" Header="Observacionproceso" DataIndex="Observacionproceso" Hidden="true"  />
					</Columns>
				</ColumnModel>
				 <LoadMask ShowMask="true" />
				  <Plugins>
                    <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                        <Filters>
							<ext:StringFilter DataIndex="CodigoCuadrilla" />
                            <ext:StringFilter DataIndex="DescripcionAuxiliar" />
                            <ext:NumericFilter DataIndex="Diferencia" />
                        </Filters>
                    </ext:GridFilters>
                </Plugins>
				 <%--  <Listeners>
                            <CellClick  Fn="CeldaSeleccionada"></CellClick >        
                                      </Listeners>    --%>
				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
				</SelectionModel>

           <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar2" 
                    runat="server" 
                    PageSize="23"
                    DisplayInfo="true" 
                    DisplayMsg="Registros {0} al {1} de {2}" 
                    EmptyMsg="No plants to display" 
                    />
            </BottomBar>
			</ext:GridPanel>
			<%--</Items>--%>
			<%--</ext:Panel>--%>
            </Content>
        </ext:Window>



		<ext:Window 
            ID="VentanaEnProceso" 
            runat="server" 
            Title=""  
            Icon="Application"
            Height="210px" 
            Width="750px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="true" 
			Hidden = "true"
            Modal="true">
            <Content>
				<ext:Panel ID="Panel6" runat="server" AutoHeight="true" Title="Materiales en Proceso" Frame="true">
					<Content>
						<table>
						<tr>
							<td><b>Producto</b></td>
							<ext:TextField ID="ItemEnProceso" DataIndex="ItemEnProceso" runat="server" Hidden="true" />
							<td style="padding-left:1px;"><ext:TextField ID="DescripcionProductoEnProceso" DataIndex="DescripcionProductoEnProceso" runat="server" Width="350px" ReadOnly="true"  /></td>
							<td>Codigo</td><td style="padding-left:1px;"><ext:TextField ID="IdAuxiliarEnProceso" DataIndex="IdAuxiliarEnProceso" runat="server" Width="40px"  ReadOnly="true" /></td>
							<td>Cuadrilla</td><td style="padding-left:1px;"><ext:TextField ID="CodigoCuadrillaEnProceso" DataIndex="CodigoCuadrillaEnProceso" runat="server" Width="50px" ReadOnly="true" /></td>
-						</tr>
						<tr>
							<td><b>Cantidad</b></td>
							<td style="padding-left:1px;">
							<%--<ext:TextField ID="CantidadEnProceso" DataIndex="CantidadEnProceso" runat="server" Width="160px"  />--%>
							<ext:NumberField 
							
								ID="CantidadEnProceso" 
								runat="server" 
								MinValue="-9000"
								MaxValue="9000"
								decimalSeparator="."
								AllowDecimals="true"
								DecimalPrecision="2"
								Step="1"
								/>

							</td>
						</tr>
						<tr>
							<td><b>OT</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="OTEnProceso" DataIndex="OTEnProceso" runat="server" Width="160px"  /></td>
						</tr>
						<tr>
							<td><b>Observacion</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="ObservacionEnProceso" DataIndex="ObservacionEnProceso" runat="server" Width="400px"  /></td>
						</tr>

						</table>
						<table>
						<tr>
	

                        <td>
							<ext:Button ID="BttGrabarEnProceso" runat="server" Text="Grabar" Icon="Disk" Width="70">
								 <Listeners><Click Fn="btn_GrabarEnProceso"></Click>
                                </Listeners>
							</ext:Button>
						</td>

                        <td>
							<ext:Button ID="BttCancelarEnProceso" runat="server" Text="Cancelar" Icon="Cancel" Width="70">
								 <Listeners><Click Fn="btn_CancelarEnProceso"></Click>
                                </Listeners>
							</ext:Button>
						</td>
					
					</tr>
				    </table>
			     </Content>
		       </ext:Panel>
		
            </Content>
        </ext:Window>

		<ext:Window 
            ID="VentanaJustificacion" 
            runat="server" 
            Title=""  
            Icon="Application"
            Height="190px" 
            Width="750px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="true" 
			Hidden = "true"
            Modal="true">
            <Content>
				<ext:Panel ID="Panel7" runat="server" AutoHeight="true" Title="Materiales con Justificacion" Frame="true">
					<Content>
						<table>
						<tr>
							<td><b>Producto</b></td>
							<ext:TextField ID="ItemJustificacion" DataIndex="ItemJustificacion" runat="server" Hidden="true" />
							<td style="padding-left:1px;"><ext:TextField ID="DescripcionProductoJustificacion" DataIndex="DescripcionProductoJustificacion" runat="server" Width="350px"  ReadOnly="true" /></td>
							<td>Codigo</td><td style="padding-left:1px;"><ext:TextField ID="IdAuxiliarJustificacion" DataIndex="IdAuxiliarJustificacion" runat="server" Width="40px" ReadOnly="true"  /></td>
							<td>Cuadrilla</td><td style="padding-left:1px;"><ext:TextField ID="CodigoCuadrillaJustificacion" DataIndex="CodigoCuadrillaJustificacion" runat="server" Width="50px"  ReadOnly="true" /></td>
-						</tr>
						<tr>
							<td><b>Cantidad</b></td>
							<td style="padding-left:1px;">
							<%--<ext:TextField ID="CantidadJustificacion" DataIndex="CantidadJustificacion" runat="server" Width="160px"  />--%>
							<ext:NumberField
								ID="CantidadJustificacion" 
								runat="server" 
								MinValue="-9000"
								MaxValue="9000"
								decimalSeparator="."
								AllowDecimals="true"
								DecimalPrecision="2"
								Step="1"
								/>
							</td>
						</tr>
	
						<tr>
							<td><b>Observacion</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="ObservacionJustificacion" DataIndex="ObservacionJustificacion" runat="server" Width="400px"  /></td>
						</tr>

						</table>
						<table>
						<tr>
	

                        <td>
							<ext:Button ID="Button1" runat="server" Text="Grabar" Icon="Disk" Width="70">
								 <Listeners><Click Fn="btn_GrabarJustificacion"></Click>
                                </Listeners>
							</ext:Button>
						</td>

                        <td>
							<ext:Button ID="Button2" runat="server" Text="Cancelar" Icon="Cancel" Width="70">
								 <Listeners><Click Fn="btn_CancelarJustificacion"></Click>
                                </Listeners>
							</ext:Button>
						</td>
					
					</tr>
				    </table>
			     </Content>
		       </ext:Panel>
		
            </Content>
        </ext:Window>

		<ext:Window 
            ID="VentanaReporte" 
            runat="server" 
            Title=""  
            Icon="Application"
            Height="180px" 
            Width="450px"
            BodyStyle="background-color: #fff;" 
            Padding="2"
            Collapsible="true" 
			Hidden = "true"
            Modal="true">
            <Content>
				<ext:Panel ID="Panel8" runat="server" AutoHeight="true" Title="Reporte Cruce Materiales" Frame="true" Padding="2" Height="180">
					<Content>
						<table>
						<tr>
						<td><b>Cuadrilla</b></td>
						<td style="padding-left:1px;">
							<ext:ComboBox ID="cbCuadrillaReporte" runat="server" DisplayField="CodigoCuadrilla" ValueField="IdCuadrilla" Width="200px" ItemSelector="div.list-item" Editable="false">
												<Store>
													<ext:Store ID="StoreCuadrillaReporte" runat="server">
														<Reader>
															<ext:JsonReader IDProperty="IdCuadrilla">
																<Fields>
																	<ext:RecordField Name="IdCuadrilla" />
																	<ext:RecordField Name="CodigoCuadrilla" />
																	<ext:RecordField Name="Descripcion" />																	
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
																<b>{CodigoCuadrilla}</b><br/>{Descripcion}<br/>
															</div>
														</tpl>
													</Html>
												</Template>
											
							</ext:ComboBox>
						</td>
						</tr>
						</table>

						<table>
						<tr>
							<td><b>Reporte</b></td>
							<td style="padding-left:1px;">
							<ext:ComboBox ID="cbReporte" runat="server" DisplayField="Descripcion" ValueField="IdReporte" Width="200px" Editable="false">
												<Store>
													<ext:Store ID="StoreReporte" runat="server">
														<Reader>
															        <ext:ArrayReader>
																<Fields>
																	<ext:RecordField Name="IdReporte" />
																	<ext:RecordField Name="Descripcion" />
        
																</Fields>
															</ext:ArrayReader>
														</Reader>
													</ext:Store>
												</Store>
												
												
							</ext:ComboBox>
						</td>	
						<td>
						<ext:Checkbox ID="ChkDifMayorCero" runat="server" BoxLabel="Diferencia > 0" />
						</td>	
						</tr>
						

						<tr>
						</tr>
						<tr></tr>
						<tr></tr>
						<tr></tr>

						</table>

						<table>
						<tr>
						<td>
						
						</td>
						</tr>
						<tr>
						
                        <td>
							<ext:Button ID="BtnImprimirCruce" runat="server" Text="Imprimir" Icon="PrinterGo" Width="70">
								 <Listeners><Click Fn="btn_ImprimirCruce"></Click>
                                </Listeners>
							</ext:Button>
						</td>

                        <td>
							<ext:Button ID="BtnCancelarCruce" runat="server" Text="Cancelar" Icon="Cancel" Width="70">
								 <Listeners><Click Fn="btn_CancelarImprimir"></Click>
                                </Listeners>
							</ext:Button>
						</td>
					
					</tr>
				    </table>
			     </Content>
		       </ext:Panel>
		
            </Content>
        </ext:Window>
		
    </form>
</body>
</html>

