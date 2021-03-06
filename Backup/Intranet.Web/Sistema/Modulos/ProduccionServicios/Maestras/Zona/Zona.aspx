﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zona.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Zona.Zona" %>
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
        function Cancelar() {
            Ext.getCmp('GridPanel1').enable();
            Ext.getCmp('BtnGrabar').hide();
            Ext.getCmp('btnNuevo').show();
            Ext.getCmp('Button1').show();
            Ext.getCmp('btnCancelar').hide();
        }
        function Nuevo() {
            Ext.getCmp('DescripcionZonaField').enable();
            Ext.getCmp('GridPanel1').disable();
            Ext.get('DistritoField').dom.value = "";
            Ext.get('DescripcionZonaField').dom.value = "";
            Ext.getCmp('BtnGrabar').show();
            Ext.getCmp('Button1').hide();
            Ext.getCmp('btnCancelar').show();
            Ext.getCmp('btnNuevo').hide();
            document.getElementById("DescripcionZonaField").focus();
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
            var idregistro = Ext.get('IdZonaField').dom.value;
            if (idregistro != "") {
                Ext.Msg.confirm('Confirmación', 'Se actualizará el registro:' + idregistro + ' , esta seguro?', function (btn, text) {
                    if (btn == 'yes') {
                        Ext.net.DirectMethods.Actualizar(idregistro);
                    } else {

                    }
                });
            }
        }
        function GetDistritos() {
            Ext.net.DirectMethods.ActualizarDistrito(3);

        }
        function ValorInicialObra() {
            Ext.getCmp('Obra').setValue(StoreObra.getAt('0').get('IdObra'));
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
        <ext:Store ID="Store1" runat="server">
            <Reader>
                	<ext:JsonReader>
						<Fields>
							<ext:RecordField Name="IdZona" />
                            <ext:RecordField Name="DescripcionZona" />
                            <ext:RecordField Name="IdDistrito" />
							<ext:RecordField Name="Distrito" />
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

        <div id="Contenedor1">
           <ext:Panel ID="Panel2" runat="server" Title="" Frame="true" Padding="3" Width="800"  >
			<Content>
                                <ext:ComboBox ID="Obra" DataIndex="IdObra" 
                                    runat="server" FieldLabel="Local"  Width="300px"
                                    StoreID="StoreObra" 
                                    DisplayField="DescripcionCorta" 
                                    ValueField="IdObra"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Local" 
                                    ValueNotFoundText="Selecione Local"  >
                                      <Listeners>
                                        <Select Fn="GetDistritos" />
                                        <BeforeRender Fn="ValorInicialObra"/>
                                      </Listeners>    
                                </ext:ComboBox>
       		</Content>
		</ext:Panel>
        <ext:Panel ID="Panel1" runat="server" Width="800" Height="400">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <West>
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            StoreID="Store1" 
                            StripeRows="true"
                            Title="Zonas por Distrito" 
                            TrackMouseOver="true"
                            Width="520" 
                            AutoExpandColumn="IdZona">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdZona" Header="IdZona" Width="100" DataIndex="IdZona" />
                                    <ext:Column  Header="DescripcionZona" Width="80" DataIndex="DescripcionZona" />
                                    <ext:Column Header="Distrito" Width="240" DataIndex="Distrito">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                        <ext:CommandColumn Width="60">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Eliminar" />
                                            </ext:GridCommand>
                                            <%--<ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>--%>
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
                                <Command Handler="Eliminar(command, record.data.IdZona);" />
                            </Listeners>
                        </ext:GridPanel>         
                    </West>
                    <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Detalle" Padding="5" ButtonAlign="Right">
                            <Items>
                                <ext:TextField ID="IdZonaField" DataIndex="IdZona" runat="server" FieldLabel="IdZona" AnchorHorizontal="95%"  />
                                <ext:TextField ID="DescripcionZonaField" DataIndex="DescripcionZona" runat="server" FieldLabel="Zona" AnchorHorizontal="95%" />
                                <ext:ComboBox  ID="DistritoField" DataIndex="IdDistrito" runat="server" FieldLabel="Distrito" AnchorHorizontal="95%"  
                                    StoreID="StoreCombo" 
                                    DisplayField="Distrito" 
                                    ValueField="IdDistrito"  
                                    TypeAhead="true" 
                                    Mode="Local" 
                                    ForceSelection="true"
                                    TriggerAction="All" 
                                    EmptyText="Selecione Distrito" 
                                    ValueNotFoundText="Selecione Distrito"  >
                                </ext:ComboBox>
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
