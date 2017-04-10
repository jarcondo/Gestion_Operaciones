<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCatalogoAuxiliar.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsultaCatalogoAuxiliar.ConsultaCatalogoAuxiliar" %>
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
    		record = GridPanel1.getSelectionModel().getSelected();
    		//alert(record.data.IdAuxiliar);
    		//,FormPanel2.getForm().loadRecord(record);
    		Ext.getCmp('GridPanel2').store.filter("CodigoAuxiliar", record.data.CodigoAuxiliar);
    		Ext.getCmp('GridPanel3').store.filter("CodigoAuxiliar", record.data.CodigoAuxiliar);    
 

    		//Ext.net.DirectMethods.Actualizar(record.data.IdAuxiliar);
    	};

    	function ValorInicialObra() {
    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
    		if (StoreObra.getCount() == 1) {
    			Ext.getCmp('Obra').disable();    			
    		} else { }
//    		var div = document.getElementById('Agregar');
//    		div.style.display = 'none';
    	}

    	function GetCatalogoAuxiliarObra() {
    		Ext.net.DirectMethods.ListarCatalogoAuxiliarObra();

//    		Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
    		//    		var div = document.getElementById('Agregar');
    		//    		div.style.display = 'none';
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
         <ext:Store ID="StoreAuxiliar" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="CodigoAuxiliar">
                    <Fields>
                        <ext:RecordField Name="CodigoAuxiliar" />
                        <ext:RecordField Name="Descripcion" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

         <ext:Store ID="StoreCatalogo" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="IdProCatalogo">
                    <Fields>
					    <ext:RecordField Name="IdProCatalogo" />
						<ext:RecordField Name="CodigoAuxiliar" />
                        <ext:RecordField Name="CodigoActividad" />
                        <ext:RecordField Name="DescripcionCatalogo" />
						<ext:RecordField Name="UnidadSedapro" />

                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
		    <ext:Store ID="StoreAlmacen" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="IdProducto">
                    <Fields>
                         <ext:RecordField Name="IdProducto" />
						 <ext:RecordField Name="CodigoAuxiliar" />
                         <ext:RecordField Name="DescripcionAlmacen" />
						 <ext:RecordField Name="unidadalmacen" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
       
        <div id="Contenedor1">
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
                                        <Select Fn="GetCatalogoAuxiliarObra" />
                                        <BeforeRender Fn="ValorInicialObra"/>
                                      </Listeners>    
                                </ext:ComboBox>

        <ext:Panel ID="Panel1" runat="server" Width="1050" Height="430">
            <Items>
			
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
					
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="StoreAuxiliar" 
                            StripeRows="true"
                            Title="Catalogo Auxiliar" 
                            TrackMouseOver="true"
                            Width="349" 
                            AutoExpandColumn="CodigoAuxiliar">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="CodigoAuxiliar" Header="Codigo" Width="50" DataIndex="CodigoAuxiliar" />
                                    <ext:Column ColumnID="Descripcion" Header="Descripcion" Width="300" DataIndex="Descripcion">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
							 <LoadMask ShowMask="true" />
							    <Plugins>
								<ext:GridFilters runat="server" ID="GridFilters1" Local="true">
									<Filters>
										<ext:StringFilter DataIndex="Descripcion" />
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
                        
                            <BottomBar>
							<ext:PagingToolbar ID="PagingToolbar1" 
								runat="server" 
								PageSize="16"
								DisplayInfo="true" 
								DisplayMsg="Registros {0} al {1} de {2}" 
								EmptyMsg="No plants to display" 
								/>
							</BottomBar>

                        </ext:GridPanel>         
                    </West>

                   <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Equivalencias" Padding="5" ButtonAlign="Left"  Height="300" Width="600">
                            <Items>

			
											<ext:GridPanel 
												ID="GridPanel2" 
												runat="server" 
												StoreID="StoreAlmacen" 
												StripeRows="true"
												Title="Almacen" 
												TrackMouseOver="true"
												Height="200"
												Width="680" 
												AutoExpandColumn="IdProducto">
												<ColumnModel ID="ColumnModel2" runat="server">
													<Columns>
														<ext:Column ColumnID="IdProducto" Header="Codigo" Width="50" DataIndex="IdProducto"/>
														<ext:Column ColumnID="DescripcionAlmacen" Header="Descripcion" Width="500" DataIndex="DescripcionAlmacen"/>
														<ext:Column ColumnID="unidadalmacen" Header="Unidad" Width="50" DataIndex="unidadalmacen"/>
													</Columns>
												</ColumnModel>
												<SelectionModel>
													<ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
														<Listeners>
															<%--<RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />--%>
															<%--<RowSelect Fn="filaseleccionada" />--%>
														</Listeners>
													</ext:RowSelectionModel>
												</SelectionModel>     
                        
												<BottomBar>
												<ext:PagingToolbar ID="PagingToolbar2" 
													runat="server" 
													PageSize="6"
													DisplayInfo="true" 
													DisplayMsg="Registros {0} al {1} de {2}" 
													EmptyMsg="No plants to display" 
													/>
												</BottomBar>

											</ext:GridPanel>         
                

											<ext:GridPanel 
												ID="GridPanel3" 
												runat="server" 
												StoreID="StoreCatalogo" 
												StripeRows="true"
												Title="Produccion" 
												TrackMouseOver="true"
												Height="200"
												Width="680" 
												AutoExpandColumn="IdProCatalogo">
												<ColumnModel ID="ColumnModel3" runat="server">
													<Columns>
													    <ext:Column ColumnID="CodigoActividad" Header="Actividad" Width="50" DataIndex="CodigoActividad" />
														<ext:Column ColumnID="IdProCatalogo" Header="Codigo" Width="50" DataIndex="IdProCatalogo" />
														<ext:Column ColumnID="DescripcionCatalogo" Header="Descripcion" Width="450" DataIndex="DescripcionCatalogo"/>
														<ext:Column ColumnID="UnidadSedapro" Header="Unidad" Width="50" DataIndex="UnidadSedapro"/>
														
													</Columns>
												</ColumnModel>
												<SelectionModel>
													<ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true">
														<Listeners>
															<%--<RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />--%>
															<%--<RowSelect Fn="filaseleccionada" />--%>
														</Listeners>
													</ext:RowSelectionModel>
												</SelectionModel>     
                        
												<BottomBar>
												<ext:PagingToolbar ID="PagingToolbar3" 
													runat="server" 
													PageSize="6"
													DisplayInfo="true" 
													DisplayMsg="Registros {0} al {1} de {2}" 
													EmptyMsg="No plants to display" 
													/>
												</BottomBar>

											</ext:GridPanel>         

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

