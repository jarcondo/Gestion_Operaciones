<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuadrillaZona.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CuadrillaZona.CuadrillaZona" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FormPanel - Ext.NET Examples</title>
    <script type="text/javascript">

    	var template = '<span style="color:{0};">{1}</span>';

    	var ColorDistrito = function (value) {

    		return String.format(template, (value == "No Asignado") ? "red" : "green", value);
    	};

    	var ColorZona = function (value) {

    		return String.format(template, (value == "No Asignado") ? "red" : "green", value);
    	};


    	var filaseleccionada = function (store, records) {
    		record = GridPanel1.getSelectionModel().getSelected(),
            FormPanel1.getForm().loadRecord(record);
    		Ext.net.DirectMethods.RefreshZonaAll();
    		Ext.getCmp('CodigoCuadrillaField').show();
    		Ext.getCmp('DescripcionCuadrillaField').show();
    		Ext.getCmp('Distrito').setReadOnly(true);
    		Ext.getCmp('Zona').setReadOnly(true);
    		Ext.getCmp('BtnAgregar').show();
    		Ext.getCmp('BtnCancelar').hide();
    		Ext.getCmp('Cuadrilla').hide();
    		Ext.getCmp('BtnGrabar').hide();
    		Ext.getCmp('BtnActualizar').show();
    	}

    	function RefreshZona() {
    		Ext.net.DirectMethods.RefreshZona();
    	}


    	function Eliminar(comando, pIdCuadrillaDistrito, pIdObra) {
    		//        	var IdCuadrillaDistrito = Ext.get('IdCuadrillaDistrito').dom.value;
    		if (comando != 'Edit') {
    			Ext.Msg.confirm('Confirmación', 'Se eliminará la asignación al registro.... esta seguro?', function (btn, text) {
    				if (btn == 'yes') {
    					Ext.net.DirectMethods.Eliminar(pIdCuadrillaDistrito, pIdObra);
    				} else {

    				}
    			});
    		}
    	}

    	function GetDistritos() {
    		Ext.net.DirectMethods.ActualizarObraDistrito(3);

    	}
    	function ValorInicialObra() {
    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
    	}

    	function btn_Agregar() {

    		Ext.getCmp('Distrito').setReadOnly(false);
    		Ext.getCmp('Zona').setReadOnly(false);
    		Ext.getCmp('BtnAgregar').hide();
    		Ext.getCmp('BtnCancelar').show();
    		Ext.getCmp('Cuadrilla').show();
    		Ext.getCmp('BtnGrabar').show();
    		Ext.getCmp('BtnActualizar').hide();
    		Ext.getCmp('CodigoCuadrillaField').hide();
    		Ext.getCmp('DescripcionCuadrillaField').hide();
    		Ext.get('AccionRegistro').dom.value = "Agregar";
    		Ext.getCmp('Distrito').setValue(0);
    		Ext.getCmp('Zona').setValue(0);
    		Ext.getCmp('Cuadrilla').setValue(0);
    	}

    	function btn_Cancelar() {
    		Ext.getCmp('CodigoCuadrillaField').show();
    		Ext.getCmp('DescripcionCuadrillaField').show();
    		Ext.getCmp('Distrito').setReadOnly(true);
    		Ext.getCmp('Zona').setReadOnly(true);
    		Ext.getCmp('BtnAgregar').show();
    		Ext.getCmp('BtnCancelar').hide();
    		Ext.getCmp('Cuadrilla').hide();
    		Ext.getCmp('BtnGrabar').hide();
    		Ext.getCmp('BtnActualizar').show();

    	}
    	function btn_Grabar() {

    		if (Ext.getCmp('Cuadrilla').getValue() == 0) {
    			alert("Debe seleccionar una Cuadrilla");
    			return;
    		}

    		if (Ext.getCmp('Distrito').getValue() == 0) {
    			alert("Debe seleccionar una Distrito");
    			return;
    		}
    		if (Ext.getCmp('Zona').getValue() == 0) {
    			alert("Debe seleccionar una Zona");
    			return;
    		}

    		Ext.Msg.confirm('Confirmación', 'Se actualizará el registro. Esta seguro?', function (btn, text) {
    			if (btn == 'yes') {
    				if (Ext.get('AccionRegistro').dom.value == "Editar") {
    					var cDistrito = Ext.get('Distrito').dom.value;
    					var cZona = Ext.get('Zona').dom.value;
    					var cCodigoCuadrilla = Ext.get('CodigoCuadrillaField').dom.value;
    					var cDescripcionCuadrilla = Ext.get('Cuadrilla').dom.value;
    					var IdCuadrillaDistrito = Ext.get('IdCuadrillaDistrito').dom.value;
    					var IdDistrito = Ext.getCmp('Distrito').getValue();
    					var IdZona = Ext.getCmp('Zona').getValue();
    					var IdCuadrilla = Ext.getCmp('Cuadrilla').getValue();

    					Ext.net.DirectMethods.Actualizar(cDistrito, cZona, cCodigoCuadrilla, IdCuadrillaDistrito, IdDistrito, IdZona, IdCuadrilla);
    				}
    				if (Ext.get('AccionRegistro').dom.value == "Agregar") {
    					var cDistrito = Ext.get('Distrito').dom.value;
    					var IdDistrito = Ext.getCmp('Distrito').getValue();
    					var IdZona = Ext.getCmp('Zona').getValue();
    					var cZona = Ext.get('Zona').dom.value;
    					var cDescripcionCuadrilla = Ext.get('Cuadrilla').dom.value
    					var IdCuadrilla = Ext.getCmp('Cuadrilla').getValue();


    					Ext.net.DirectMethods.Insertar(cDistrito, cZona, cDescripcionCuadrilla, IdDistrito, IdZona, IdCuadrilla);
    				}

    			} else {

    			}
    		});


    		Ext.getCmp('CodigoCuadrillaField').show();
    		Ext.getCmp('DescripcionCuadrillaField').show();
    		Ext.getCmp('Distrito').setReadOnly(true);
    		Ext.getCmp('Zona').setReadOnly(true);
    		Ext.getCmp('BtnAgregar').show();
    		Ext.getCmp('BtnCancelar').hide();
    		Ext.getCmp('Cuadrilla').hide();
    		Ext.getCmp('BtnGrabar').hide();
    		Ext.getCmp('BtnActualizar').show();
    	}

    	function btn_Actualizar() {
    		Ext.get('AccionRegistro').dom.value = "Editar";
    		Ext.getCmp('Distrito').setReadOnly(false);
    		Ext.getCmp('Zona').setReadOnly(false);
    		Ext.getCmp('BtnAgregar').hide();
    		Ext.getCmp('BtnCancelar').show();
    		Ext.getCmp('BtnGrabar').show();
    		Ext.getCmp('BtnActualizar').hide();

    	}
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Store ID="StoreCuadrilla" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="IdCuadrilla">
                    <Fields>
                        <ext:RecordField Name="IdCuadrilla" />
                        <ext:RecordField Name="DescripcionCuadrilla" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            </ext:Store>
        

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
                <ext:JsonReader IDProperty="IdDistrito">
                    <Fields>
                        <ext:RecordField Name="IdDistrito" />
                        <ext:RecordField Name="Distrito" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:Store runat="server" ID="ZonaStore" OnRefreshData="ZonaRefresh">
        <DirectEventConfig>
            <EventMask ShowMask="false" />
        </DirectEventConfig>
        <Reader>
            <ext:JsonReader IDProperty="IdZona">
                <Fields>
                    <ext:RecordField Name="IdZona" Type="String" Mapping="IdZona" />
                   <ext:RecordField Name="DescripcionZona" Type="String" Mapping="DescripcionZona" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        </ext:Store>

        <ext:Store ID="Store1" runat="server">
            <Reader>
                	<ext:JsonReader IDProperty="IdCuadrillaDistrito">
                    <Fields>
                        <ext:RecordField Name="IdCuadrillaDistrito" />
                        <ext:RecordField Name="CodigoCuadrilla" />
                        <ext:RecordField Name="DescripcionCuadrilla" />
                        <ext:RecordField Name="DescripcionDistrito" />
                        <ext:RecordField Name="IdDistrito" />
                        <ext:RecordField Name="IdZona" />
                        <ext:RecordField Name="DescripcionZona" />
                        <ext:RecordField Name="IdObra" />
                        <ext:RecordField Name="IdCuadrilla" />
                    </Fields>
                </ext:JsonReader>
			</Reader>
        </ext:Store>
        <div id="Contenedor1">
         <ext:Panel ID="Panel2" runat="server" Title="" Frame="true" Padding="3" Width="1100"  >
			<Content>
                                <ext:ComboBox ID="Obra" DataIndex="IdObra" 
                                    runat="server" FieldLabel="Obra"  Width="300px"
                                    StoreID="StoreObra" 
                                    DisplayField="DescripcionCorta" 
                                    ValueField="IdObra"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Obra" 
                                    ValueNotFoundText="Selecione Obra"  >
                                      <Listeners>
                                        <Select Fn="GetDistritos" />
                                        <BeforeRender Fn="ValorInicialObra"/>
                                      </Listeners>    
                                </ext:ComboBox>
       		</Content>
		</ext:Panel>
        <ext:Panel ID="Panel1" runat="server" Width="1100" Height="400">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="Store1" 
                            StripeRows="true"
                            Title="Asignacion de Zonas por Cuadrilla" 
                            TrackMouseOver="true"
                            Width="760" 
                            AutoExpandColumn="CodigoCuadrilla">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
								    <ext:Column ColumnID="IdCuadrillaDistrito" Header="CodigoCuadrilla" Width="150" DataIndex="IdCuadrillaDistrito" hidden="true"/>
                                    <ext:Column ColumnID="CodigoCuadrilla" Header="CodigoCuadrilla" Width="150" DataIndex="CodigoCuadrilla" />
                                    <ext:Column  Header="DescripcionCuadrilla" Width="200" DataIndex="DescripcionCuadrilla" />
                                    <ext:Column Header="Distrito" Width="200" DataIndex="DescripcionDistrito">
                                      
                                    </ext:Column>
                                    <ext:Column  Header="Zona" Width="150" DataIndex="DescripcionZona">
                                       
                                    </ext:Column>
                                        <ext:CommandColumn Width="60">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Eliminar Asignación" />
                                            </ext:GridCommand>
                                        </Commands>
                                        </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <%--<RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />--%>
                                        <RowSelect Fn="filaseleccionada" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>     
                            <Listeners>
                                <Command Handler="Eliminar(command, record.data.IdCuadrillaDistrito,record.data.IdObra);" />
                            </Listeners>
                            
                        </ext:GridPanel>         
                    </West>
                    <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Right">
                            <Items>
                               
                                <ext:TextField ID="IdObra" DataIndex="IdObra" runat="server" FieldLabel="IdObra" AnchorHorizontal="95%" AllowBlank="false" />
								<ext:TextField ID="IdCuadrillaDistrito" DataIndex="IdCuadrillaDistrito" runat="server" FieldLabel="IdObra" AnchorHorizontal="95%" AllowBlank="false" />
								<ext:TextField ID="AccionRegistro" DataIndex="AccionRegistro" runat="server" FieldLabel="" AnchorHorizontal="95%"  />
                                <ext:TextField ID="CodigoCuadrillaField" DataIndex="CodigoCuadrilla" runat="server" FieldLabel="Codigo" AnchorHorizontal="95%" AllowBlank="false" readOnly="true" />
                                <ext:TextField ID="DescripcionCuadrillaField" DataIndex="DescripcionCuadrilla" runat="server" FieldLabel="Descripcion" AnchorHorizontal="95%" readOnly="true" />
                                <ext:ComboBox ID="Cuadrilla" DataIndex="IdCuadrilla" runat="server" FieldLabel="Cuadrilla" AnchorHorizontal="95%"  
                                    StoreID="StoreCuadrilla" 
                                    DisplayField="DescripcionCuadrilla" 
                                    ValueField="IdCuadrilla"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Cuadrilla" 
                                    ValueNotFoundText="Selecione Cuadrilla"  >
                                      <Listeners>
                                      <%--<Select Handler="#{Zona}.clearValue(); #{ZonaStore}.reload();" />--%>
                                      </Listeners>    
                                </ext:ComboBox>
                                <ext:ComboBox ID="Distrito" DataIndex="IdDistrito" runat="server" FieldLabel="Distrito" AnchorHorizontal="95%"  
                                    StoreID="StoreCombo" 
                                    DisplayField="Distrito" 
                                    ValueField="IdDistrito"  
                                    TypeAhead="true" 
                                    Mode="Local" 
									readOnly="true"
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Distrito" 
                                    ValueNotFoundText="Selecione Distrito"  >
                                      <Listeners>
                                      <Select Handler="#{Zona}.clearValue(); #{ZonaStore}.reload();" />
                                      </Listeners>    
                                </ext:ComboBox>
                                <ext:ComboBox ID="Zona" DataIndex="IdZona" runat="server" FieldLabel="Zona" AnchorHorizontal="95%"  
                                    StoreID="ZonaStore" 
                                    TypeAhead="true" 
                                    Mode="Local"
									readOnly="true"
                                    ForceSelection="true" 
                                    TriggerAction="All" 
                                    DisplayField="DescripcionZona" 
                                    ValueField="IdZona"
                                    EmptyText="Seleccione Zona" 
                                    ValueNotFoundText="Seleccione Zona">
                                      <Listeners>
                                      <BeforeQuery  Fn="RefreshZona" /> 
                                      </Listeners>    
                                </ext:ComboBox>

                            </Items>
                            <Buttons>
                                <ext:Button ID="BtnAgregar" runat="server" Text="Agregar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Agregar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnEliminar" runat="server" Text="Eliminar" Icon="Delete">
                                <Listeners>
                              <%--  <Click Fn="btn_Eliminar"></Click>--%>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnGrabar" runat="server" Text="Grabar" Icon="DatabaseGo">
                                <Listeners>
                                <Click Fn="btn_Grabar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnCancelar" runat="server" Text="Cancelar" Icon="DatabaseGo">
                                <Listeners>
                                <Click Fn="btn_Cancelar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnActualizar" runat="server" Text="Actualizar" Icon="DatabaseGo">
                                <Listeners>
                                <Click Fn="btn_Actualizar"></Click>
                                </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Panel>
        </div>
    </form>
</body>
</html>
