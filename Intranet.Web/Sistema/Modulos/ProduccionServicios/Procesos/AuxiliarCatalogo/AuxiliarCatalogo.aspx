<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuxiliarCatalogo.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.AuxiliarCatalogo.AuxiliarCatalogo" %>
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
            record = GridPanel1.getSelectionModel().getSelected(),
//            FormPanel1.getForm().loadRecord(record);
            FormPanel2.getForm().loadRecord(record);
//            Ext.net.DirectMethods.RefreshZonaAll();
        }

        function RefreshZona() {
            Ext.net.DirectMethods.RefreshZona();
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


        function btn_Actualizar() {

            var cDescripcionAuxiliar = Ext.get('ComboBox1').dom.value;

            if (cDescripcionAuxiliar!= "Seleccione Descripcion") {
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
                                <ext:ComboBox ID="Obra" DataIndex="IdObra" 
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
                                </ext:ComboBox>
       		</Content>
		</ext:Panel>
          <ext:Panel ID="Panel3" runat="server" Title="" Frame="true" Padding="3" Width="1100" >
			<Content>
             <ext:FormPanel ID="FormPanel2" runat="server" Title="Detalle" Padding="1" ButtonAlign="Left" LabelWidth="130">
                            <Items>
                                <ext:TextField ID="IdProCatalogoField" DataIndex="IdProCatalogo" runat="server" FieldLabel="Codigo Catalogo" Width="100px"  />
                                <ext:TextField ID="IdObra" DataIndex="IdObra" runat="server" FieldLabel="IdObra"  AnchorHorizontal="100%" />
                                <ext:TextField ID="IdActividad" DataIndex="IdActividad" runat="server"  />
                                <ext:TextField ID="CodigoActividad" DataIndex="CodigoActividad" runat="server" FieldLabel="CodigoActividad" AnchorHorizontal="100%"  />
                                <ext:TextField ID="DescripcionCatalogoField" DataIndex="DescripcionCatalogo" runat="server" FieldLabel="Descripcion Catalogo" Width="800px" />
                                <ext:ComboBox ID="ComboBox1" DataIndex="IdAuxiliar" runat="server" FieldLabel="Descripcion Auxiliar" Width="800px"  
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
                                      <%--<Select Handler="#{Zona}.clearValue(); #{ZonaStore}.reload();" />--%>
                                      </Listeners>    
                                </ext:ComboBox>
                            </Items>
                            <Buttons>
                                <ext:Button ID="Button2" runat="server" Text="Actualizar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Actualizar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Text="Quitar" Icon="Delete">
                                <Listeners><Click Fn="btn_Eliminar"></Click>
                                </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>
       		</Content>
		</ext:Panel>

        <ext:Panel ID="Panel1" runat="server" Width="1100" Height="300">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="Store1" 
                            StripeRows="true"
                           
                            Title="Equivalencia Catalogo y Auxiliar" 
                            TrackMouseOver="true"
                            Width="1099" 
                            AutoExpandColumn="IdProCatalogo">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdProCatalogo" Header="IdCatalogo" Width="100" DataIndex="IdProCatalogo" />
                                    <ext:Column ColumnID="CodigoActividad" Header="Actividad" Width="100" DataIndex="CodigoActividad" />
                                    <ext:Column  Header="Descripcion Catalogo" Width="420" DataIndex="DescripcionCatalogo" />
                                    <ext:Column Header="IdAuxiliar" Width="80" DataIndex="IdAuxiliar">
                                        <Renderer Fn="ColorDistrito" />
                                    </ext:Column>
                                    <ext:Column  Header="Descripcion Auxiliar" Width="419" DataIndex="DescripcionAuxiliar">
                                        <Renderer Fn="ColorZona" />
                                    </ext:Column>
                                 
                                </Columns>
                            </ColumnModel>

							  <Plugins>
								<ext:GridFilters runat="server" ID="GridFilters1" Local="true">
									<Filters>
										<ext:StringFilter DataIndex="DescripcionCatalogo" />
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
