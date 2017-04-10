<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CruceMateriales.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CruceMaterial.CruceMateriales" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
    	// this "setGroupStyle" function is called when the GroupingView is refreshed.     
    	var setGroupStyle = function (view) {
    		// get an instance of the Groups
    		var groups = view.getGroups();

    		for (var i = 0; i < groups.length; i++) {
    			var spans = Ext.query("span", groups[i]);

    			if (spans && spans.length > 0) {
    				// Loop through the Groups, the do a query to find the <span> with our ColorCode
    				// Get the "id" from the <span> and split on the "-", the second array item should be our ColorCode
    				var color = "#" + spans[0].id.split("-")[1];

    				// Set the "background-color" of the original Group node.
    				Ext.get(groups[i]).setStyle("background-color", color);
    			}
    		}
    	};

    	function btnBuscar() {

    		if (Ext.getCmp('ddlObra').getValue() == 0) {
    			alert("Debe seleccionar una Obra");
    			return;
    		}
    	
    		Ext.net.DirectMethods.btnBuscar_Click();

    	}


    	function btn_Imprimir() {

    		if (Ext.getCmp('ddlObra').getValue() == 0) {
    			alert("Debe seleccionar una Obra");
    			return;
    		}
    		var DescripcionObra = Ext.get('ddlObra').dom.value;
    		
    		Ext.net.DirectMethods.btnImprimir(DescripcionObra);

    	}

    </script>    

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    			
		<ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Cruce de Materiales" Frame="true">
			<Content>
				<table>
					<tr>
						<td><b>Obra</b></td>
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
							</ext:ComboBox>
						</td>
						<td style="padding-left:5px;">
						</td>
						<td style="padding-left:15px;"><b>Fecha Inicial</b></td>
						<td style="padding-left:5px;"><ext:DateField ID="FechaIni" runat="server"  Format="dd/MM/yyyy" /></td>
						<td style="padding-left:15px;"><b>Fecha Final</b></td>
                        <td style="padding-left:5px;"><ext:DateField ID="FechaFin" runat="server" Format="dd/MM/yyyy" /></td>
                        <td style="padding-left:5px;">
						</td>
                        <td style="padding-left:5px;">
						</td>
                        <td>
							<ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="DatabaseGo" Width="100">
							  <Listeners><Click Fn="btnBuscar"></Click>
                                </Listeners>

							<%--	<DirectEvents>
									<Click OnEvent="btnBuscar_Click">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
									</Click>
								</DirectEvents>--%>
							</ext:Button>
								</td>
                        <td>
							<%--<asp:Button ID="Button1" runat="server" Text="Imprimir" OnClick="btnImprimir" />--%>
						
								<ext:Button ID="BtnImprimir" runat="server" Text="Imprimirr" Icon="DatabaseGo" Width="100">
								 <Listeners><Click Fn="btn_Imprimir"></Click>
                                </Listeners>
								<%--<DirectEvents>
									<Click OnEvent="btnImprimir">
										<EventMask ShowMask="true" Msg="Cargando Datos" />
									</Click>
								</DirectEvents>--%>
							</ext:Button>

						</td>
					</tr>
				</table>
			</Content>
		</ext:Panel>
		<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="Resultado de Cruce de Materiales" >
			<Items>
				<ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                Height="450px"
              
                Collapsible="true" 
                
                TrackMouseOver="true"
                Width="1000" 
                AutoExpandColumn="CodigoCuadrilla"	>

                  <Store>
              <ext:Store ID="StoreCruceMaterial" runat="server" >
						<Reader>
							<ext:JsonReader IDProperty="Item">
								<Fields>
                                	<ext:RecordField Name="Item" />
									<ext:RecordField Name="IdAuxiliar" />
									<ext:RecordField Name="DescripcionAuxiliar" /> 
									<ext:RecordField Name="CantidadAlmacen" />
									<ext:RecordField Name="CantidadEjecutada" />
                                    <ext:RecordField Name="Diferencia" />
									<ext:RecordField Name="PrecioAuxiliar" />
                                    <ext:RecordField Name="MontoAuxiliar" />
									<ext:RecordField Name="CodigoCuadrilla" />
                                    <ext:RecordField Name="DescripcionCuadrilla" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
            </Store>


                  <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                        <ext:Column ColumnID="CodigoCuadrilla" Header="Cuadrilla" DataIndex="CodigoCuadrilla" Width="70px" />
                    	<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="70px" hidden="true"/>
						<ext:Column ColumnID="IdAuxiliar" Header="Codigo" DataIndex="IdAuxiliar" Width="70px" />
						<ext:Column ColumnID="DescripcionAuxiliar" Header="Descripcion" DataIndex="DescripcionAuxiliar" Width="300px" />
						<ext:Column ColumnID="CantidadAlmacen" Header="Almacen" DataIndex="CantidadAlmacen" Width="100px" />
						<ext:Column ColumnID="CantidadEjecutada" Header="Produccion" DataIndex="CantidadEjecutada" Width="100px" />
						<ext:Column ColumnID="Diferencia" Header="Diferencia" DataIndex="Diferencia" Width="100px" />
						<ext:Column ColumnID="PrecioAuxiliar" Header="Precio" DataIndex="PrecioAuxiliar" Width="100px" />
						<ext:Column ColumnID="MontoAuxiliar" Header="Monto" DataIndex="MontoAuxiliar" Width="100px" />
					</Columns>
				</ColumnModel>
			
				<SelectionModel>
					<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
				</SelectionModel>
		

                                <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" 
                    runat="server" 
                    PageSize="21"
                    DisplayInfo="true" 
                    DisplayMsg="Registros {0} al {1} de {2}" 
                    EmptyMsg="No plants to display" 
                    />
            </BottomBar>
         

			</ext:GridPanel>
			</Items>
		</ext:Panel>


		



    </div>
    </form>
</body>
</html>
