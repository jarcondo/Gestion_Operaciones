<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptStock.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Stock.rptStock" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <ext:Panel ID="Panel0" runat="server" AutoHeight="true" Title="Datos de Búsqueda" Frame="true">
    <Content>
    <table>
    <tr>
    <td>
    <ext:Label ID="lbl1" runat="server" Text="Ingrese Código o Descripción"></ext:Label>
    </td>
    <td>
    <ext:TextField ID="tfCodoDes" runat="server"></ext:TextField>
    </td>
    <td>
    <ext:Button ID="btnBusca" runat="server" Text="Buscar" Icon="Zoom">
    <DirectEvents>
    <Click OnEvent="BuscarxCodoDes" Timeout="1200000" >
    <EventMask ShowMask="true" Msg="Cargando Datos" />
    </Click>
    </DirectEvents>
    </ext:Button>
    </td>
    <td>
    <ext:Button ID="btnVerReporte" runat="server" Text="Ver Reporte" Icon="Report">
    <DirectEvents>
    <Click OnEvent="MostrarReporte"></Click>
    </DirectEvents>
    </ext:Button>
    </td>
    </tr>
    </table>
    </Content>
    </ext:Panel>
    <ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Reporte Stock" Frame="true">
    <Items>
    <ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                Height="450px"
				>
				<Store>
					<ext:Store ID="StoreStock" runat="server">
						<Reader>
							<ext:JsonReader IDProperty="CodigoProducto">
								<Fields>
                                    <ext:RecordField Name="CodigoProducto" />
                                    <ext:RecordField Name="Descripcion1" />
                                    <ext:RecordField Name="A2" />
                                    <ext:RecordField Name="MantoVes" />
                                    <ext:RecordField Name="MantoCho" />
                                    <ext:RecordField Name="AguaCentro" />
                                    <ext:RecordField Name="AguaNorte" />
                                    <ext:RecordField Name="PozosSur" />
                                    <ext:RecordField Name="PrevItem2" />
                                    <ext:RecordField Name="PrevItem1" />
                                    <ext:RecordField Name="MantoPte" />
                                    <ext:RecordField Name="MantoCallao" />       
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:Column ColumnID="CodigoProducto" Header="Código" DataIndex="CodigoProducto" />
                        <ext:Column ColumnID="Descripcion1" Header="Producto" DataIndex="Descripcion1" />
                        <ext:Column ColumnID="A2" Header="Unidad" DataIndex="A2" />
                        <ext:Column ColumnID="MantoVes" Header="MANTTO VILLA SALVADOR" DataIndex="MantoVes" />
                        <ext:Column ColumnID="MantoCho" Header="MANTTO CHORRILLOS" DataIndex="MantoCho" />
                        <ext:Column ColumnID="AguaCentro" Header="POZOS AGUA CENTRO (CP 033 ITEM2)" DataIndex="AguaCentro" />
                        <ext:Column ColumnID="AguaNorte" Header="POZOS AGUA NORTE (CP 033 ITEM1)" DataIndex="AguaNorte" />
                        <ext:Column ColumnID="PozosSur" Header="POZOS SUR (AMC 0048-2012 )" DataIndex="PozosSur" />   
                        <ext:Column ColumnID="PrevItem2" Header="PREVENTIVO  ITEM 02 - 032" DataIndex="PrevItem2" />   
                        <ext:Column ColumnID="PrevItem1" Header="PREVENTIVO  ITEM 01 - 032" DataIndex="PrevItem1" />   
                        <ext:Column ColumnID="MantoPte" Header="MANTTO. PTE PIEDRA 042" DataIndex="MantoPte" />   
                        <ext:Column ColumnID="MantoCallao" Header="MANTTO. CALLAO 042" DataIndex="MantoCallao" />   
					</Columns>
				</ColumnModel>
			</ext:GridPanel>
            </Items>
    </ext:Panel>

    </form>
</body>
</html>
