<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaTeorico.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsultaTeorico.ConsultaTeorico" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">

    	var template = '<span style="color:{0};">{1}</span>';

    	var ColorDistrito = function (value) {

    		return String.format(template, (value == "No Asignado") ? "red" : "green", value);
    	};

    	var ColorZona = function (value) {

    		return String.format(template, (value == "No Asignado") ? "red" : "green", value);
    	};

    	var filaseleccionada = function (store, records) {
//    		record = GridPanel1.getSelectionModel().getSelected(),
//    		
//            FormPanel2.getForm().loadRecord(record);
    	}

    	function RefreshZona() {
    		Ext.net.DirectMethods.RefreshZona();
       }

    	function btn_CancelarFactor() {
    	    VentanaJustificacion.hide();
    	}

    	function btn_ActualizaFactor() {
    	    var record = GridPanel1.getSelectionModel().getSelected();
    	    Ext.net.DirectMethods.ActualizarFactor(record.data['Teorico'], Ext.get('ValorFactor').dom.value);
    	    record.data['Factor'] = Ext.get('ValorFactor').dom.value;
    	    record.commit();
    	    VentanaJustificacion.hide();
    	}

    	function btn_Eliminar() {
    		var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
    		var idObra = Ext.get('IdObra').dom.value;
    		var idactividad = Ext.get('IdActividad').dom.value;
    		var idcatalogo = Ext.get('IdProCatalogoField').dom.value;
    		if (cDescripcionAuxiliar != "Seleccione Descripcion") {
    			Ext.Msg.confirm('Confirmación', 'Se eliminará la asignación al registro: ' + idcatalogo + ' , esta seguro?', function (btn, text) {
    				if (btn == 'yes') {
    					Ext.net.DirectMethods.Eliminar(idObra, idactividad, idcatalogo);
    				} else {

    				}
    			});
    		}
    	}

    	function GetCatalogo() {
    		Ext.net.DirectMethods.GetCatalogo();

    	}
    	function ValorInicialObra() {
    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));

    		if (StoreObra.getCount() == 1) {
    			Ext.getCmp('Obra').disable();
    		} else { }

    	}

    	function linkFactor(value, meta, record) {
    	    return String.format("<a class='company-link' href='#' onclick='linkFactorClick(\"{1}\");'>{0}</a>", value, record.id);
    	}

    	function linkFactorClick(recordId) {
    	    VentanaJustificacion.show();
    	        	    Ext.get('DescripcionSubactividad').dom.value = StoreTeorico.getById(recordId).get("subactividad")
    	        	    Ext.get('DescripcionProducto').dom.value = StoreTeorico.getById(recordId).get("material")
    	        	    Ext.get('ValorFactor').dom.value = StoreTeorico.getById(recordId).get("Factor")
    	                Ext.getCmp('ValorFactor').focus(true, 10);
    	}

    	var ExportaExcel = function () {
    	    App.GridData.setValue(Ext.encode(App.GridPanel1.getRowsValues({ selectedOnly: false })));
    	};


    	function btn_Actualizar() {

    		var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;

    		if (cDescripcionAuxiliar != "Seleccione Descripcion") {
    			Ext.Msg.confirm('Confirmación', 'Se actualizará el registro. Esta seguro?', function (btn, text) {
    				if (btn == 'yes') {
    					Ext.net.DirectMethods.Actualizar(cDescripcionAuxiliar);
    					record = GridPanel1.getSelectionModel().getSelected();
    				} else {

    				}
    			});
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
         <ext:Store ID="StoreCombo" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="IdAuxiliar">
                    <Fields>
                        <ext:RecordField Name="IdAuxiliar" />
                        <ext:RecordField Name="Descripcion" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

		  <ext:Store ID="StoreTeorico" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="Teorico">
                    <Fields>
                        <ext:RecordField Name="subactividad" />
                        <ext:RecordField Name="material" />
						<ext:RecordField Name="actividad" />
						<ext:RecordField Name="Factor" />
						<ext:RecordField Name="Teorico" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

     
        <ext:Store ID="Store1" runat="server"  OnRefreshData="MyData_Refresh" >
            <Reader>
                	<ext:JsonReader IDProperty="IdProCatalogo">
                    <Fields>
                        <ext:RecordField Name="IdProCatalogo" />
                        <ext:RecordField Name="DescripcionCatalogo" />
                        <ext:RecordField Name="IdAuxiliar" />
                        <ext:RecordField Name="DescripcionAuxiliar" />
                        <ext:RecordField Name="IdActividad" />
                        <ext:RecordField Name="CodigoActividad" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>

        <div id="Contenedor1">
         <ext:Panel ID="Panel2" runat="server" Title="" Frame="true" Padding="3" Width="1100" >
			<Content>
            <table>
            <tr>
            <td>Obra</td><td>
                                <ext:ComboBox ID="Obra" DataIndex="IdObra" 
                                    runat="server" Width="300px"
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
                                        <Select Fn="GetCatalogo" />
                                        <BeforeRender Fn="ValorInicialObra"/>
                                      </Listeners>    
                                </ext:ComboBox>
                           </td>
                           <td>      
                        <%--    <ext:Button ID="BtnExcel" runat="server" Text="A Excel" AutoPostBack="true" OnClick="ToExcel" Icon="PageExcel">
                            <Listeners>
                                <Click Fn="ExportaExcel" />
                            </Listeners>
                            </ext:Button>--%>
                           </td>
                </tr>
                </table>
       		</Content>
		</ext:Panel>
          <%--<ext:Panel ID="Panel3" runat="server" Title=" " Frame="true" Padding="3" Width="1100">
			<Content>--%>
   <%--          <ext:FormPanel ID="FormPanel2" runat="server" Title="Detalle" Padding="1" ButtonAlign="Left" LabelWidth="130">
                            <Items>--%>
                  <%--             <ext:TextField ID="IdProCatalogoField" DataIndex="IdProCatalogo" runat="server" FieldLabel="Codigo Catalogo" Width="100px"  />
                                <ext:TextField ID="IdObra" DataIndex="IdObra" runat="server" FieldLabel="IdObra"  AnchorHorizontal="100%" />
                                <ext:TextField ID="IdActividad" DataIndex="IdActividad" runat="server"  />
                                <ext:TextField ID="CodigoActividad" DataIndex="CodigoActividad" runat="server" FieldLabel="CodigoActividad" AnchorHorizontal="100%"  />
                                <ext:TextField ID="DescripcionCatalogoField" DataIndex="DescripcionCatalogo" runat="server" FieldLabel="Descripcion Catalogo" Width="800px" />--%>
            <%--                    <ext:ComboBox ID="ComboBox1" DataIndex="IdAuxiliar" runat="server" FieldLabel="Descripcion Auxiliar" Width="800px"  
                                    StoreID="StoreCombo" 
                                    DisplayField="Descripcion" 
                                    ValueField="IdAuxiliar"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Seleccione Descripcion" 
                                    ValueNotFoundText="Seleccione Descripcion"  >
                                      <Listeners>
                                      <%--<Select Handler="#{Zona}.clearValue(); #{ZonaStore}.reload();" />
                                      </Listeners>    
                                </ext:ComboBox>--%>
                            <%--</Items>--%>
           <%--                 <Buttons>
                                <ext:Button ID="Button2" runat="server" Text="Actualizar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Actualizar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Text="Quitar" Icon="Delete">
                                <Listeners><Click Fn="btn_Eliminar"></Click>
                                </Listeners>
                                </ext:Button>
                            </Buttons>--%>
                       <%-- </ext:FormPanel>--%>
     <%--  		</Content>
		</ext:Panel>--%>

        <ext:Panel ID="Panel1" runat="server" Width="1100" Height="460">
            <Items>
                      <ext:Hidden ID="GridData" runat="server" />
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="StoreTeorico" 
                            StripeRows="true"
                           
                            Title="Equivalencia Teorica de Materiales No Valorizables y Subactividad" 
                            TrackMouseOver="true"
                            Width="1099" 
                            Height="460"
                            AutoExpandColumn="Teorico">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Actividad" Header="Actividad" Width="100" DataIndex="actividad"/>
                                    <ext:Column ColumnID="Subactividad" Header="Subactividad" Width="350" DataIndex="subactividad" />
                                    <ext:Column ColumnID="Material" Header="Material" Width="350" DataIndex="material" />
                                    <ext:Column ColumnID="Factor" Header="Factor" Width="80" DataIndex="Factor" >
                						<Renderer Fn="linkFactor" />						
				            		</ext:Column>
									 <ext:Column ColumnID="Teorico"  Width="80" DataIndex="Teorico" Hidden="true" />
                                </Columns>
                            </ColumnModel>

							  <Plugins>
								<ext:GridFilters runat="server" ID="GridFilters1" Local="true">
									<Filters>
                                    	<ext:StringFilter DataIndex="actividad" />
										<ext:StringFilter DataIndex="subactividad" />
										<ext:StringFilter DataIndex="material" />
									</Filters>
								</ext:GridFilters>
							</Plugins>
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
                    PageSize="18"
                    DisplayInfo="true" 
                    DisplayMsg="Registros {0} al {1} de {2}" 
                    EmptyMsg="No plants to display" 
                    />
            </BottomBar>

                        </ext:GridPanel>         

            </Items>
        </ext:Panel>


        <ext:Window 
            ID="VentanaJustificacion" 
            runat="server" 
            Title=""  
            Icon="Application"
            Height="190px" 
            Width="550px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="true" 
			Hidden = "true"
            Modal="true">
            <Content>
				<ext:Panel ID="Panel7" runat="server" AutoHeight="true" Title="Actualizar Factor" Frame="true">
					<Content>
						<table>
						<tr>
							<%--<ext:TextField ID="ItemJustificacion" DataIndex="ItemJustificacion" runat="server" Hidden="true" />--%>
							<td><b>Subactividad</b></td><td style="padding-left:1px;"><ext:TextField ID="DescripcionSubactividad" DataIndex="DescripcionSubactividad" runat="server" Width="420px"  /></td>
                        </tr>
                        <tr>
							<td><b>Producto</b></td><td style="padding-left:1px;"><ext:TextField ID="DescripcionProducto" DataIndex="DescripcionProducto" runat="server" Width="420px"  /></td>
							<%--<td>Cuadrilla</td><td style="padding-left:1px;"><ext:TextField ID="CodigoCuadrillaJustificacion" DataIndex="CodigoCuadrillaJustificacion" runat="server" Width="50px"  /></td>--%>
-						</tr>
						<tr>
							<td><b>Factor</b></td>
							<td style="padding-left:1px;">
							<ext:NumberField
								ID="ValorFactor" 
								runat="server" 
								MinValue="0"
								MaxValue="100"
								decimalSeparator="."
								AllowDecimals="true"
								DecimalPrecision="2"
								Step="1"
								/>
							</td>
						</tr>
<%--						<tr>
							<td><b>Observacion</b></td>
							<td style="padding-left:1px;"><ext:TextField ID="ObservacionJustificacion" DataIndex="ObservacionJustificacion" runat="server" Width="400px"  /></td>
						</tr>
--%>
						</table>
						<table>
						<tr>
                        <td>
							<ext:Button ID="Button1" runat="server" Text="Grabar" Icon="Disk" Width="70">
								 <Listeners><Click Fn="btn_ActualizaFactor"></Click>
                                </Listeners>
							</ext:Button>
						</td>
                        <td>
							<ext:Button ID="Button2" runat="server" Text="Cancelar" Icon="Cancel" Width="70">
								 <Listeners><Click Fn="btn_CancelarFactor"></Click>
                                </Listeners>
							</ext:Button>
						</td>
					</tr>
				    </table>
			     </Content>
		       </ext:Panel>
            </Content>
        </ext:Window>
        </div>
    </form>
</body>
</html>
