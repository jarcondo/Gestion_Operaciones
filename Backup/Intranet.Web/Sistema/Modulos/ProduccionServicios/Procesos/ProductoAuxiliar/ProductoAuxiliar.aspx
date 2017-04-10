<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoAuxiliar.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ProductoAuxiliar.ProductoAuxiliar" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FormPanel - Ext.NET Examples</title>
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
    </style>

    <script type="text/javascript">

        var template = '<span style="color:{0};">{1}</span>';

        var ColorDistrito = function (value) {

            return String.format(template, (value == "No Asignado") ? "red" : "green", value);
        };

        var ColorZona = function (value) {

            return String.format(template, (value == "No Asignado") ? "red" : "green", value);
        };


        var filaseleccionada = function (store, records) {


            record = GridPanel1.getSelectionModel().getSelected();
            //            FormPanel1.getForm().loadRecord(record);
            FormPanel2.getForm().loadRecord(record);
            //            Ext.net.DirectMethods.RefreshZonaAll();
            Ext.getCmp('ComboBox1').hide();
            Ext.getCmp('cbStates').hide();
            Ext.getCmp('Button3').hide();
            Ext.getCmp('Button2').show();
            Ext.getCmp('Button1').show();
            Ext.getCmp('Button4').hide();
        }

        function RefreshZona() {
            Ext.net.DirectMethods.RefreshZona();
        }


        function btn_Eliminar() {
            var IdProductoAuxiliar = Ext.get('IdProductoAuxiliar').dom.value;
            var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
            var idObra = Ext.get('IdObra').dom.value;
            var idProducto = Ext.get('IdProducto').dom.value;
            var rows = Ext.getCmp('GridPanel1').getSelectionModel().getSelections();
            if(rows.length === 0){  
                return false;   
            }   

                Ext.Msg.confirm('Confirmación', 'Se eliminará la asignación para el producto: ' + idProducto + ' , Confirma ?', function (btn, text) {
                    if (btn == 'yes') {
                        var filaseleccionada = GridPanel1.getSelectionModel().getSelected();
                        GridPanel1.getStore().remove(filaseleccionada);
                        Ext.net.DirectMethods.Eliminar(IdProductoAuxiliar);
                    } else {

                    }
                });
            
        }

        function GetCatalogo() {
            Ext.net.DirectMethods.GetCatalogo();

        }
        function ValorInicialObra() {
            Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
        }

        var triggerHandler = function (el, trigger, index) {
            var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
            var cDescripcionProducto = Ext.get('cbStates').dom.value;
            switch (index) {
                case 0:
                    this.focus().clearValue(); trigger.hide();

                    break;
                case 1:
                    if (cDescripcionAuxiliar.length != 0) {

                        if (cDescripcionProducto.length != 0) {
                            ComboBox1.getEl().applyStyles('background:white');
                            Ext.net.DirectMethods.InsertarAuxiliar(cDescripcionAuxiliar);
                            Ext.get('GridPanel1').focus();
                        }
                    }
                    break;
            }
        }

        function btn_Actualizar() {

            Ext.get('ComboBox1').dom.value = "";
            Ext.get('cbStates').dom.value = "";
            Ext.getCmp('ComboBox1').show();
            Ext.getCmp('cbStates').show();
            Ext.getCmp('Button3').show();
            Ext.getCmp('Button2').hide();
            Ext.getCmp('Button1').hide();
            Ext.getCmp('Button4').show();
            Ext.getCmp('cbStates').focus();
        }

        function btn_Cancelar() {
            Ext.getCmp('ComboBox1').hide();
            Ext.getCmp('cbStates').hide();
            Ext.getCmp('Button3').hide();
            Ext.getCmp('Button2').show();
            Ext.getCmp('Button1').show();
            Ext.getCmp('Button4').hide();
        }


        function btn_Grabar() {

            var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;
            var cDescripcionProducto = Ext.get('cbStates').dom.value;


//            alert(typeof (Ext.getCmp('ComboBox1').getValue()));
//            alert(Ext.getCmp('ComboBox1').getValue().length);
            

            if (cDescripcionAuxiliar.length != 0) {

                if (cDescripcionProducto.length != 0) {

//                    if (typeof (Ext.getCmp('ComboBox1').getValue()) == 'String') {
//                               alert(Ext.getCmp('ComboBox1').getValue().length);
//                    }
                    


                    Ext.Msg.confirm('Confirmación', 'Se agergará un nuevo registro. Esta seguro?', function (btn, text) {
                        if (btn == 'yes') {
                            Ext.net.DirectMethods.Actualizar(cDescripcionAuxiliar);
                            record = GridPanel1.getSelectionModel().getSelected();
                            Ext.getCmp('ComboBox1').hide();
                            Ext.getCmp('cbStates').hide();
                            Ext.getCmp('Button3').hide();
                            Ext.getCmp('Button2').show();
                            Ext.getCmp('Button1').show();
                            Ext.getCmp('Button4').hide();
                        } else {

                        }
                    });


                }

            
            }
        }

        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Ext.getCmp('ComboBox1').focus();
                //    Ext.net.DirectMethods.LogIn(); e.stopEvent();
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
         <ext:Store ID="StoreCombo" runat="server" >
            <Reader>
                <ext:JsonReader IDProperty="IdAuxiliar">
                    <Fields>
                        <ext:RecordField Name="IdAuxiliar" />
                        <ext:RecordField Name="Descripcion" />
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


         <ext:Store ID="StoreAuxiliarProducto" runat="server" >
            <Reader>
                	<ext:JsonReader IDProperty="IdProductoAuxiliar">
                    <Fields>
                        <ext:RecordField Name="IdProducto" />
                        <ext:RecordField Name="DescripcionProducto" />
                        <ext:RecordField Name="IdAuxiliar" />
                        <ext:RecordField Name="DescripcionAuxiliar" />
                        <ext:RecordField Name="IdObra" />
                        <ext:RecordField Name="IdProductoAuxiliar" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>


         <ext:Store ID="StoreProducto" runat="server">
            <Reader>
                	<ext:JsonReader IDProperty="IdProducto">
                    <Fields>
                        <ext:RecordField Name="IdProducto" />
                        <ext:RecordField Name="Descripcion" />
                        <ext:RecordField Name="CodigoProducto" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>



        <div id="Contenedor1">
         <ext:Panel ID="Panel2" runat="server" Title="" Frame="true" Padding="3" Width="1100" >
			<Content>
                              <%--  <ext:ComboBox ID="Obra" DataIndex="IdObra" 
                                    runat="server" FieldLabel="Obra"  Width="300px"
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
                                </ext:ComboBox>--%>
       		</Content>
		</ext:Panel>
        <div id="Div1">
          <ext:Panel ID="Panel3" runat="server" Title="Detalle Productos de Almacen" Frame="true" Padding="1" Width="1100" >
			<Content>
             <ext:FormPanel ID="FormPanel2" runat="server" Title="" Padding="1" ButtonAlign="Left" LabelWidth="130">
                            <Items>
                                <ext:TextField ID="IdObra" DataIndex="IdObra" runat="server" FieldLabel="IdObra" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextField ID="IdAuxiliar" DataIndex="IdAuxiliar" runat="server" FieldLabel="IdAuxiliar" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextField ID="IdProducto" DataIndex="IdProducto" runat="server" FieldLabel="IdProducto" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:TextField ID="IdProductoAuxiliar" DataIndex="IdProductoAuxiliar" runat="server" FieldLabel="IdProductoAuxiliar" AnchorHorizontal="100%" AllowBlank="false" />
                                <ext:ComboBox 
                                    ID="cbStates" 
                                    DataIndex="IdProducto"
                                    FieldLabel="Descripcion Producto"
                                    runat="server"
                                    EmptyText="Seleccione Producto"
                                    TypeAhead="true"
                                    ForceSelection="true"
                                    StoreID="StoreProducto"
                                    Mode="Local"
                                    DisplayField="Descripcion" 
                                    ValueField="IdProducto"
                                    MinChars="1"
                                    AnchorHorizontal="100%"
                                    ListWidth="600"
                                    PageSize="10"
                                    ItemSelector="tr.list-item">
                                    <Template ID="Template1" runat="server">
                                        <Html>
					                        <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th>Descripcion</th>
									                        <th>CodigoProducto</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style="padding:3px 0px;">{Descripcion}</td>
							                        <td>{CodigoProducto}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
				                        </Html>
                                    </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.focus().clearValue(); trigger.hide();}" />
                                    <Select Handler="this.triggers[0].show();" />
                                    <SpecialKey Fn="enterKeyPressHandler" /> 
                                </Listeners>
                            </ext:ComboBox>           

                                <ext:ComboBox ID="ComboBox1" runat="server" FieldLabel="Descripcion Auxiliar" AnchorHorizontal="100%"  
                                    DataIndex="IdAuxiliar"
                                    StoreID="StoreCombo" 
                                    DisplayField="Descripcion" 
                                    ValueField="IdAuxiliar"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    TriggerAction="All" 
                                     ForceSelection="true"
                                     >
                                         <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            <ext:FieldTrigger Icon="SimplePlus" />
                                         </Triggers>
                                      <Listeners>
                                      <%--<Select Handler="#{Zona}.clearValue(); #{ZonaStore}.reload();" />--%>
                                      <TriggerClick Fn="triggerHandler" />
                                       <Select Handler="this.triggers[0].show();" />
                                      </Listeners>    

                                </ext:ComboBox>
                            </Items>
                            <Buttons>
                                <ext:Button ID="Button2" runat="server" Text="Agregar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Actualizar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Text="Eliminar" Icon="Delete">
                                <Listeners><Click Fn="btn_Eliminar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button3" runat="server" Text="Grabar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Grabar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button4" runat="server" Text="Cancelar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Cancelar"></Click>
                                </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>
       		</Content>
		</ext:Panel>
        </div>


        <ext:Panel ID="Panel1" runat="server" Width="1100" Height="300">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="StoreAuxiliarProducto" 
                            StripeRows="true"
                           
                            Title="Equivalencia Producto Almacen y Catalogo Auxiliar" 
                            TrackMouseOver="true"
                            Width="1099" 
                            AutoExpandColumn="IdProductoAuxiliar">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdProductoAuxiliar" Header="IdProductoAuxiliar" Width="100" DataIndex="IdProductoAuxiliar" hidden="true"/>
                                    <ext:Column ColumnID="IdProducto" Header="IdProducto" Width="100" DataIndex="IdProducto" />
                                    <ext:Column ColumnID="DescripcionProducto" Header="DescripcionProducto" Width="400" DataIndex="DescripcionProducto" />
                                    <ext:Column  Header="IdAuxiliar" Width="100" DataIndex="IdAuxiliar" />
                                    <ext:Column Header="DescripcionAuxiliar" Width="400" DataIndex="DescripcionAuxiliar">
                                        <Renderer Fn="ColorDistrito" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
							  <Plugins>
								<ext:GridFilters runat="server" ID="GridFilters1" Local="true">
									<Filters>
										<ext:StringFilter DataIndex="DescripcionProducto" />
										<ext:StringFilter DataIndex="DescripcionAuxiliar" />
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
                    PageSize="10"
                    DisplayInfo="true" 
                    DisplayMsg="Registros {0} al {1} de {2}" 
                    EmptyMsg="No plants to display" 
                    />
            </BottomBar>

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
    </form>
</body>
</html>
