<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadoOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.EstadoOT.EstadoOT" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FormPanel - Ext.NET Examples</title>
    
    <script type="text/javascript">
        
         
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };

        function calculateCoordinates() { 
        Ext.net.DirectMethods.UpdateMsg(); }
       function Cancelar() {
            Ext.getCmp('GridPanel1').enable();
            Ext.getCmp('BtnGrabar').hide();
            Ext.getCmp('btnNuevo').show();
            Ext.getCmp('Button1').show();
            Ext.getCmp('btnCancelar').hide();
            Ext.getCmp('CodigoEstadoOTField').disable();
        }
        function Nuevo() {
            Ext.getCmp('CodigoEstadoOTField').enable();
            Ext.getCmp('GridPanel1').disable();
            Ext.get('DescripcionEstadoField').dom.value = "";
            Ext.get('CodigoEstadoOTField').dom.value = "";
            //document.getElementById('CodigoEstadoOTField').value = "";
            Ext.getCmp('BtnGrabar').show();
            Ext.getCmp('Button1').hide();
            Ext.getCmp('btnCancelar').show();
            Ext.getCmp('btnNuevo').hide();
            document.getElementById("CodigoEstadoOTField").focus();
        }
        function Eliminar(comando, idregistro) {
            if (comando != 'Edit') {
                Ext.Msg.confirm('Confirmación', 'Se eliminará el registro:' + idregistro + ' , esta seguro?', function (btn, text) {
                    if (btn == 'yes') {
                        Ext.net.DirectMethods.Eliminar(idregistro);
                    } else {

                    }
                });
            }
        }

        function btn_Actualizar() {
            var idregistro = Ext.get('CodigoEstadoOTField').dom.value;
            if (idregistro != "") {
                Ext.Msg.confirm('Confirmación', 'Se actualizará el registro:' + idregistro + ' , esta seguro?', function (btn, text) {
                    if (btn == 'yes') {
                        Ext.net.DirectMethods.Actualizar(idregistro);
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
        <ext:Store ID="Store1" runat="server">
            <Reader>
                	<ext:JsonReader>
						<Fields>
							<ext:RecordField Name="IdEstadoOT" Type="Int" />
                            <ext:RecordField Name="CodigoEstadoOT" />
							<ext:RecordField Name="DescripcionEstado" />
                            <%--<ext:RecordField Name="EstadoOT" />--%>
						</Fields>
					</ext:JsonReader>
			</Reader>
        </ext:Store>
        <div id="Contenedor1">
        <ext:Panel ID="Panel1" runat="server" Width="800" Height="400">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="Store1" 
                            StripeRows="true"
                            Title="Registros" 
                            TrackMouseOver="true"
                            Width="520" 
                            AutoExpandColumn="IdEstadoOT">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdEstado" Header="IdEstadoOT" Width="100" DataIndex="IdEstadoOT" />
                                    <ext:Column  Header="CodigoEstado" Width="80" DataIndex="CodigoEstadoOT" />
                                        <%--<Renderer Format="UsMoney" />--%>
                                    <%--</ext:Column>--%>
                                    <ext:Column Header="DescripcionEstado" Width="240" DataIndex="DescripcionEstado">
                                        
                                    </ext:Column>
                                        <ext:CommandColumn Width="60">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                        </Commands>
                                        </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />
                                    </Listeners>

                                </ext:RowSelectionModel>
                            </SelectionModel>     
                            <Listeners>
                                <Command Handler="Eliminar(command, record.data.CodigoEstadoOT);" />
                            </Listeners>

                   <%--         <DirectEvents> 
                           
                                            <Command OnEvent="gridCommand">
                                                                 <ExtraParams>
                                                                          <ext:Parameter Name="cmdName" Value="command" Mode="Raw"> 
                                                                         </ext:Parameter> 
                                                                           <ext:Parameter Name="Id" Value="record.data.CodigoEstadoOT" Mode="Raw">       
                                                                           </ext:Parameter>         
                                                                  </ExtraParams>        
                                           </Command>     
                           </DirectEvents> --%>
                        

                        </ext:GridPanel>         
                    </West>
                    <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Right">
                            <Items>
                                <%--<ext:TextField ID="IdEstadoOTField" DataIndex="IdEstadoOT" runat="server" FieldLabel="IdEstadoOT" AnchorHorizontal="95%" Disabled="true"/>--%>
                                <ext:TextField ID="CodigoEstadoOTField" DataIndex="CodigoEstadoOT" runat="server" FieldLabel="Codigo" AnchorHorizontal="95%" AllowBlank="false" />
                                <ext:TextField ID="DescripcionEstadoField" DataIndex="DescripcionEstado" runat="server" FieldLabel="Descripcion" AnchorHorizontal="95%" />
                            </Items>
                            <Buttons>
                                <ext:Button ID="Button1" runat="server" Text="Actualizar" Icon="DatabaseGo">
                                <Listeners><Click Fn="btn_Actualizar"></Click>
                                </Listeners>
                                </ext:Button>
                                <ext:Button ID="BtnGrabar" runat="server" Text="Grabar" Icon="Disk" OnDirectClick="btnGrabar_Click">
                                </ext:Button>
                                <ext:Button runat="server" ID="btnCancelar" Text="Cancelar" Icon="Cancel" ><Listeners><Click Fn="Cancelar"></Click>
                                                                                          </Listeners></ext:Button>   
                                <ext:Button runat="server" ID="btnNuevo" Text="Nuevo" Icon="Add" ><Listeners><Click Fn="Nuevo"></Click>
                                                                                          </Listeners></ext:Button>   
                                <%--<ext:Button runat="server" ID="BtnCancelar2" ><Listeners><Click Fn="calculateCoordinates"></Click>
                                                                                         </Listeners></ext:Button>   
                                --%>
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
