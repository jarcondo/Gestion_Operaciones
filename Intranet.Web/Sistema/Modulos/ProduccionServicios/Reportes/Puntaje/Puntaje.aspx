<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Puntaje.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Puntaje.Puntaje" %>
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
            if (record.data.cActivo == "Revisado") {
                Bttn2.setDisabled(true);
                Bttn2.setTooltip("Disabled");
            }


        };


        var template = '<span style="color:{0};">{1}</span>';

        var ColorEstado = function (value) {

            return String.format(template, (value == "Pendiente") ? "red" : "green", value);
        };





        function GetCuadrillaResponsable() {
           
            Ext.net.DirectMethods.ListarCuadrillaResponsable();

        }

        function GetResponsablesBase() {
            Ext.net.DirectMethods.ListarResponsableBase();
            Ext.net.DirectMethods.ListarCuadrillaResponsable();

        }



        function ValorInicialObra() {
            Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
//            var div = document.getElementById('Agregar');
//            div.style.display = 'none';
            if (StoreObra.getCount() == 1) {
                Ext.getCmp('Obra').disable();
            } else { }

  
        }

        function ValorInicialEmpleado() {
            Ext.getCmp('Responsable').setValue(StoreEmpleado.getAt('0').get('IdEmpleado'));
            
            if (StoreEmpleado.getCount() == 1) {
                
//                Ext.net.DirectMethods.ListarCuadrillaResponsable();
                Ext.getCmp('Responsable').disable();
             

            }
        }

        function ValorInicialCuadrilla() {
            if (StoreCuadrillaReporte.getCount() >= 1) {
                Ext.net.DirectMethods.ListarCuadrillaResponsable();
                Ext.getCmp('cbCuadrillaReporte').setValue(StoreCuadrillaReporte.getAt('0').get('IdCuadrilla'));
                //Ext.getCmp('cbCuadrillaReporte').setValue(0);
            } else {
                Ext.net.DirectMethods.ListarCuadrillaResponsable();
                //Ext.getCmp('cbCuadrillaReporte').setValue(0);
            }
        }




        function btn_Agregar() {
            if (Ext.getCmp('Responsable').getValue().length == 0) {
                alert("Debe seleccionar un Responsable de Actividad");
                return;

            }

            if (Ext.getCmp('cbCuadrillaReporte').getValue().length == 0) {
                alert("Debe seleccionar una Cuadrilla");
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

    		


            var checkedItem = Ext.getCmp('RadioGroup2').getValue();
            var DescripObra = Ext.get('Obra').dom.value;
            var DescripResponsable = Ext.get('Responsable').dom.value;
            Ext.net.DirectMethods.btnImprimirReportePuntaje(DescripObra, DescripResponsable, checkedItem.getGroupValue());
 

        }






        function compara_fechas(fecha1, fecha2) {
            var xMonth = fecha1.substring(3, 5);
            var xDay = fecha1.substring(0, 2);
            var xYear = fecha1.substring(6, 10);
            var yMonth = fecha2.substring(3, 5);
            var yDay = fecha2.substring(0, 2);
            var yYear = fecha2.substring(6, 10);
            if (xYear > yYear) {
                return (true)
            }
            else {
                if (xYear == yYear) {
                    if (xMonth > yMonth) {
                        return (true)
                    }
                    else {
                        if (xMonth == yMonth) {
                            if (xDay > yDay)
                                return (true);
                            else
                                return (false);
                        }
                        else
                            return (false);
                    }
                }
                else
                    return (false);
            }
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
                                    Editable="true"
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
                                </tr>
                                <tr>
								<td>Responsable</td>
								<td>
								 <ext:ComboBox ID="Responsable" DataIndex="IdObra" 
                                    runat="server"   Width="300px"
                                    StoreID="StoreEmpleado" 
                                    DisplayField="NombresApellidos" 
                                    Editable="true"
                                    ValueField="IdEmpleado"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="" 
                                    SelectOnFocus="true"
                                    ValueNotFoundText=""  >
                                      <Listeners>
                                        <Select Fn="GetCuadrillaResponsable" />
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
                            	<tr>
						<td><b>Cuadrilla</b></td>
						<td style="padding-left:1px;">
							<ext:ComboBox ID="cbCuadrillaReporte" runat="server" DisplayField="CodigoCuadrilla" ValueField="IdCuadrilla" Width="200px" ItemSelector="div.list-item">
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
											  <Listeners>
                                                    <%--<Select Fn="GetCuadrillaResponsable" />--%>
                                                    <BeforeRender Fn="ValorInicialCuadrilla"/>
                                              </Listeners>    
							</ext:ComboBox>
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
                        <ext:RadioGroup ID="RadioGroup2" 
                            runat="server" 
                            LabelWidth="140"
                            FieldLabel="Opciones de Reporte" 
                            ColumnsNumber="1"
                            height="70px"
                            Width="1000px" 
                            >
                            <Items>
                                <ext:Radio ID="RdgSubactividad" runat="server"    LabelWidth="350"  BoxLabel="Fecha y Subactividad"   Width="1100px"/>
                                <ext:Radio ID="Rdgfecha" runat="server" BoxLabel="Por fecha " Width="1100px" Checked="true" />
                                <ext:Radio ID="RdgAcumulado" runat="server" BoxLabel="Acumulado" Width="1100px" />
                            </Items>
                        </ext:RadioGroup> 
                     </tr>
					 <tr>
					    <td>Fecha Inicial</td>
						<td><ext:DateField ID="FechaIni" runat="server"  Format="dd/MM/yyyy"  Width="120px" AllowBlank="false" /></td>    
						<td></td>
						<td></td>
						<td>Fecha Final</td>
                        <td><ext:DateField ID="FechaFin" runat="server" Format="dd/MM/yyyy" Width="120px" /></td>
						<td></td>
  					</tr>
					  </table>  
					  </div>
					  <table>
                    <tr>
                              <td>
                                <ext:Button ID="BtnAgregar" runat="server" Text="Visualizar" Icon="Add">
                                <Listeners><Click Fn="btn_Agregar"></Click>
                                </Listeners>
                                </ext:Button>
                              </td>
					</tr>
                    </table>  
                        
       		</Content>
		</ext:Panel>


         


       

        </div>



		

		
    </form>
</body>
</html>

