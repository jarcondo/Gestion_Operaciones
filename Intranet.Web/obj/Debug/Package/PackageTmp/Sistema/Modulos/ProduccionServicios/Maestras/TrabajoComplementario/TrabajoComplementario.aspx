
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrabajoComplementario.aspx.cs" Inherits="Intranet.Web.Modulos.ProduccionServicios.Maestras.TrabajoComplementario.TrabajoComplementario" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FormPanel - Ext.NET Examples</title>
  
   <script type="text/javascript">
       var obraRenderer = function (value) {
           if (!Ext.isEmpty(value)) {
               return value.DescripcionCorta;
           }

           return value;
       };
    </script>

   

</head>


<body>
    <form id="Form1" runat="server">
       <ext:ResourceManager ID="ResourceManager1" runat="server" />
      <ext:Store ID="Store1" runat="server"  SerializationMode="Complex">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="IdTrabajoComplementario" />
                        <ext:RecordField Name="CodigoTrabajoComplementario" />
                        <ext:RecordField Name="CodMap" />
                        <ext:RecordField Name="Descripcion" />
                        <ext:RecordField Name="Unidad" />
                        <ext:RecordField Name="CostoProgramado" Type="Float" />
                        <ext:RecordField Name="Obra" />
                        <ext:RecordField Name="Observacion" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:Store ID="Store2" runat="server" SerializationMode="Complex">
        <Reader>
        <ext:JsonReader>
            <Fields>
                <ext:RecordField Name="IdObra" />
                <ext:RecordField Name="DescripcionCorta" />
            </Fields>
        </ext:JsonReader>
        </Reader>
       </ext:Store>
       
       <ext:Store ID="Store3" runat="server" SerializationMode="Complex">
       <Reader>
       <ext:JsonReader>
       <Fields>
              <ext:RecordField Name="IdGenerica" />
              <ext:RecordField Name="A2" />
       </Fields>
       </ext:JsonReader>
       </Reader>
       </ext:Store>

         <ext:Panel ID="Panel1" runat="server" Width="1000" Height="500">
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
                            Width="700" 
                            AutoExpandColumn="IdTrabajoComplementario"  >

                            <ColumnModel ID="Grid1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="IdTrabajoComplementario" Header="IdTrabajoComplementario" Width="0" DataIndex="IdTrabajoComplementario" Hidden="true" />
                                    <ext:Column Header="Codigo" Width="65" DataIndex="CodigoTrabajoComplementario" />
                                    <ext:Column Header="CodMap" Width="65" DataIndex="CodMap" />
                                    <ext:Column Header="Descripcion" Width="160" DataIndex="Descripcion" />
                                    <ext:Column Header="Unidad" Width="105" DataIndex="Unidad" />
                                    <ext:Column Header="Costo Programado" Width="110" DataIndex="CostoProgramado"  />
                                    <ext:Column Header="Local" Width="185" DataIndex="Obra"  >
                                    <Renderer Fn="obraRenderer" />                        
                                    </ext:Column>
                                    <ext:Column Header="Observacion"  DataIndex="Observacion" Hidden="true"/>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record); #{Obra}.setValue(record.get('Obra').IdObra);  #{Unidad}.setValue(record.get('Unidad'));" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>            
                        </ext:GridPanel>         
                    </West>
                    <Center>
                          <ext:FormPanel ID="FormPanel1" runat="server" Title="Mantenimiento" Padding="5" ButtonAlign="Right">
                            <Items>
                                <ext:TextField ID="IdTrabajoComplementario" DataIndex="IdTrabajoComplementario" runat="server" FieldLabel="Company" AnchorHorizontal="95%" Hidden="true" />
                                <ext:TextField ID="CodigoTrabajoComplementario" DataIndex="CodigoTrabajoComplementario" runat="server" FieldLabel="Codigo" AnchorHorizontal="95%"  MaxLength="10"/>
                                <ext:TextField ID="CodMap" DataIndex="CodMap" runat="server" FieldLabel="CodMap" AnchorHorizontal="95%"  MaxLength="10"/>
                                <ext:TextField ID="Descripcion" DataIndex="Descripcion" runat="server" FieldLabel="Descripcion" AnchorHorizontal="95%"  MaxLength="100"/>
                                <ext:ComboBox ID="Unidad" DataIndex="Unidad" runat="server" FieldLabel="Unidad" AnchorHorizontal="95%"  
                                StoreID="Store3" DisplayField="A2" ValueField="A2"  TypeAhead="true" Mode="Local" ForceSelection="true"
                                TriggerAction="All" EmptyText="Selecione Unidad" ValueNotFoundText="Selecione Unidad"  >
                                </ext:ComboBox>
                                <ext:TextField ID="CostoProgramado" DataIndex="CostoProgramado" runat="server" FieldLabel="Costo" AnchorHorizontal="95%" />
                                <ext:ComboBox ID="Obra" DataIndex="Obra" runat="server" FieldLabel="Local" AnchorHorizontal="95%"  
                                StoreID="Store2" DisplayField="DescripcionCorta" ValueField="IdObra"  TypeAhead="true" Mode="Local" ForceSelection="true"
                                TriggerAction="All" EmptyText="Selecione Obra" ValueNotFoundText="Selecione Obra"  >
                                </ext:ComboBox>
                                <ext:TextArea ID="Observacion" DataIndex="Observacion" runat="server" FieldLabel="Observacion" AnchorHorizontal="95%" />
                            </Items>
                            <Buttons>
                                <ext:Button ID="btnnuevo" runat="server" Text="Nuevo" Icon="Add" ToolTip="Agregar nuevo registro">
                                    <DirectEvents>
                                        <Click OnEvent="btnnuevo_Click" />
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btnguardar" runat="server" Text="Guardar" Icon="Disk" ToolTip="Guardar registro">
                                    <DirectEvents>
										<Click OnEvent="btnguardar_Click" />
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btneliminar" runat="server" Text="Eliminar" Icon="Delete" ToolTip="Eliminar registro">
                                    <DirectEvents>
                                            <Click OnEvent="btneliminar_Click" />
                                    </DirectEvents>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>