<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioMasivoEstado.aspx.cs" Inherits="Intranet.Web.Modulos.ProduccionServicios.Procesos.CambioMasivoEstado" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
	<script type="text/javascript">
		var template = '<span style="color:{0};">{1}</span>';

		var SituacionObserva = function (value) {
			return String.format(template, (value == "Correcto") ? "green" : "red", value);
		};

		function btn_Actualizar() {
//			var cObra = Ext.getCmp('Obra').getValue() ;
//			alert(cObra);
			var DescripcionEstado = Ext.get('cbEstadoOT').dom.value;
//			if (idregistro != "") {
			Ext.Msg.confirm('Confirmación', 'Se actualizará masivamente al estado ' + DescripcionEstado + ' , esta seguro?', function (btn, text) {
					if (btn == 'yes') {
						Ext.net.DirectMethods.btnCambiarMasivoEstado_DirectClick();
					} else {

					}
				});
//			}
		}
    </script>

</head>
<body style="background-color:#D0DEF0;">
    <form id="form1" runat="server">
		<ext:ResourceManager ID="ResourceManager1" runat="server" />
		<%--STORES--%>
		<ext:Store ID="StoreObra" runat="server">
			<Reader>
				<ext:JsonReader IDProperty="IdObra">
					<Fields>
						<ext:RecordField Name="IdObra" />
						<ext:RecordField Name="DescripcionCorta" />
					</Fields>
				</ext:JsonReader>
			</Reader>
			<%--<Listeners>
				<Load Handler="#{Obra}.setValue(#{Obra}.store.getAt(0).get('IdObra'));" />
			</Listeners>--%>
		</ext:Store>
		<ext:Store ID="StoreEstado" runat="server">
			<Reader>
				<ext:JsonReader IDProperty="IdEstadoOT">
					<Fields>
						<ext:RecordField Name="IdEstadoOT" />
						<ext:RecordField Name="DescripcionEstado" />
					</Fields>
				</ext:JsonReader>
			</Reader>
			<%--<Listeners>
				<Load Handler="#{Estado}.setValue(#{Estado}.store.getAt(0).get('IdEstadoOT'));" />
			</Listeners>--%>
		</ext:Store>
		<ext:Store ID="StoreCarga" runat="server">
			<Reader>
				<ext:JsonReader IDProperty="SGI">
					<Fields>
						<ext:RecordField Name="SGI" />
						<ext:RecordField Name="DescripcionEstadoActual" />
						<ext:RecordField Name="DescripcionEstadoCambio" />
						<ext:RecordField Name="Observacion" />
						<ext:RecordField Name="Situacion" />
	
					</Fields>
				</ext:JsonReader>
			</Reader>
		</ext:Store>
		<%--FIN SORES--%>
		<ext:Panel ID="Panel1" runat="server" Title="Cambio Masivo Estado" Frame="true" Padding="5" >
			<Content>
				<table style="color:#15428B;">
					<tr>
						<td><b>Obra</b></td>
						<td style="padding-left:1px;">
							<ext:ComboBox ID="Obra" runat="server" StoreID="StoreObra" DisplayField="DescripcionCorta" 
							  ValueField="IdObra" EmptyText="--- Seleccione Obra ---" Width="200px">
							</ext:ComboBox>
						</td>
						<td><b>Estado Final</b></td>
						<td style="padding-left:1px;">
							<ext:ComboBox ID="cbEstadoOT" runat="server" StoreID="StoreEstado" DisplayField="DescripcionEstado" 
							  ValueField="IdEstadoOT" EmptyText="--- Seleccione Estado ---" Width="200px">
							</ext:ComboBox>
						</td>
						<td style="padding-left:15px;"><b>Archivo</b></td>
						<td style="padding-left:5px;">
							<asp:FileUpload ID="fupSGIO" runat="server" Width="300px" CssClass="x-form-text x-form-field" Height="20px" />
						</td>
						<td style="padding-left:25px;">
							<ext:Button ID="Button1" runat="server" Text="Cargar Archivo" Icon="DatabaseAdd">
								<DirectEvents>
									<Click OnEvent="btnCargar_DirectClick" Timeout="1200000">
										<EventMask ShowMask="true" Msg="Cargando datos" />
									</Click>
								</DirectEvents>
							</ext:Button>
						</td>
					</tr>
				</table>
			</Content>
		</ext:Panel>
		<ext:Panel ID="Panel2" runat="server" Title="2. Registros del Archivo SGIO" Frame="true" Padding="5">
			<Items>
				<ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
				StoreID="StoreCarga" 
                Height="250px" >
					<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>
						    <ext:RowNumbererColumn  Width="45px"/>
							<ext:Column ColumnID="SGI" Header="SGI" DataIndex="SGI" />
							<ext:Column ColumnID="DescripcionEstadoActual" Header="EstadoActual" DataIndex="DescripcionEstadoActual" />
							<ext:Column ColumnID="DescripcionEstadoCambio" Header="EstadoCambio" DataIndex="DescripcionEstadoCambio" />
							<ext:Column ColumnID="Observacion"  Header="Observacion" DataIndex="Observacion" Width="300px" >
							<Renderer Fn="SituacionObserva" />
							</ext:Column>

						</Columns>
					</ColumnModel>
				</ext:GridPanel>
				<ext:Hidden ID="hdArchivoTemp" runat="server"></ext:Hidden>
				<ext:Hidden ID="hdNomArchivoTemp" runat="server"></ext:Hidden>
			</Items>
			<Buttons>
				<ext:Button ID="btnImportar" runat="server" Text="Cambiar Estado" Icon="DatabaseGo">
				
                                <Listeners><Click Fn="btn_Actualizar"></Click>
                                </Listeners>
					<%--<DirectEvents>
						<Click OnEvent="btnCambiarMasivoEstado_DirectClick" Timeout="1200000">
							<EventMask ShowMask="true" Msg="Cambiar Estado" />
						</Click>
					</DirectEvents>--%>
				</ext:Button>
			</Buttons>
		</ext:Panel>
    </form>
</body>

</html>
