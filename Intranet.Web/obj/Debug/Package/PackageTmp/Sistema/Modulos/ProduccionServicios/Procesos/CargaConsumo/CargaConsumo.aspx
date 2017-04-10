<%@ Page Language="C#" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" CodeBehind="CargaConsumo.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CargaConsumo" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
					Ext.get(groups[i]).setStyle("background-color", "FEFEFE");
				}
			}
		};
    </script>    
</head>
<body style="background-color:#D0DEF0;">
    <form id="form1" runat="server">
	
	<asp:HiddenField ID="hdRutaCabecera" runat="server" />
	<asp:HiddenField ID="hdNombreCabecera" runat="server" />
	<asp:HiddenField ID="hdRutaDetalle" runat="server" />
	<asp:HiddenField ID="hdNombreDetalle" runat="server" />
    <ext:ResourceManager ID="ResourceManager1" runat="server"/>

		<ext:Store ID="StoreCarga" runat="server">
			<Reader>
				<ext:JsonReader>
					<Fields>
						<ext:RecordField Name="existe" />
						<ext:RecordField Name="observaciones" />
						<ext:RecordField Name="nro_ot" />
						<ext:RecordField Name="nis_rad" />
						<ext:RecordField Name="municipio" />
						<ext:RecordField Name="direccion" />
						<ext:RecordField Name="estado" />
					</Fields>
				</ext:JsonReader>
			</Reader>
		</ext:Store>
		
	<ext:Panel ID="Panel1" runat="server" Title="1. Datos de los archivos de carga de consumo SGIO" Frame="true">
		<Content>
			<table cellpadding="2" cellspacing="2" style="color:#15428B;">
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
						<%--<asp:DropDownList ID="ddlObra" runat="server" CssClass="x-form-text x-form-field" Width="200px" DataTextField="DescripcionCorta" DataValueField="IdObra">
						</asp:DropDownList>--%>
					</td>
				</tr>
				<tr>	
					<td><b>Cabecera</b></td>
					<td style="padding-left:5px;">
						<input id="fupCabecera" type="file" class="x-form-text x-form-field" style="width:300px;" runat="server" />
						<%--<ext:FileUploadField ID="fupCabecera" Name="fupCabecera" runat="server" Width="300" Icon="Attach" />--%>
					</td>
					<td style="padding-left:15px;"><b>Detalle</b></td>
					<td style="padding-left:5px;">
						<input id="fupDetalle" type="file" class="x-form-text x-form-field" style="width:300px;" runat="server" />
						<%--<ext:FileUploadField ID="fupDetalle" Name="fupDetalle" runat="server" Width="300" Icon="Attach" />--%>
					</td>
					<td style="padding-left:15px;">
						<ext:Button ID="btnCargarArchivos" runat="server" Text="Cargar Archivos" Icon="DatabaseAdd">
							<DirectEvents>
								<Click OnEvent="btnCargarArchivos_Click">
									<EventMask ShowMask="true" Msg="Cargando datos..." />
								</Click>
							</DirectEvents>
						</ext:Button><%--
						<asp:Button ID="Button2" runat="server" Text="Cargar Archivos" onclick="Button2_Click" />--%>
					</td>
				</tr>
			</table>
		</Content>
	</ext:Panel>
	<ext:Panel ID="Panel2" runat="server" Title="2. Datos Cargados" Frame="true" Height="400px">
		<Content>
			<ext:GridPanel ID="GridPanel1" runat="server" Height="300" StoreID="StoreCarga">
				
				<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>
							<ext:Column ColumnID="observaciones" Header="Observaciones" DataIndex="observaciones" Width="300" />
							<ext:Column ColumnID="nro_ot" Header="SGI" DataIndex="nro_ot" Width="60" />
							<ext:Column ColumnID="nis_rad" Header="NIS" DataIndex="nis_rad" Width="60" />
							<ext:Column ColumnID="municipio" Header="Distrito" DataIndex="municipio" Width="200" />
							<ext:Column ColumnID="direccion" Header="Dirección" DataIndex="direccion" Width="300" />
							<ext:Column ColumnID="estado" Header="Estado" DataIndex="estado" Width="60" />
						</Columns>
				</ColumnModel>
				<LoadMask ShowMask="true"/>
				<SaveMask ShowMask="true" />
			</ext:GridPanel>
		</Content>
		<Buttons>
			<ext:Button ID="Button1" runat="server" Text="Importar Datos" Icon="DatabaseCopy">
				<DirectEvents>
					<Click OnEvent="Button1_DirectClick">
						<EventMask ShowMask="true" Msg="Importando Datos..." />
					</Click>
				</DirectEvents>
			</ext:Button>
		</Buttons>
	</ext:Panel>
    </form>
</body>
</html>
