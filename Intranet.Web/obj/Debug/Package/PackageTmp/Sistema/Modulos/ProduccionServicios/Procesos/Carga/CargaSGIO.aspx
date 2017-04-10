
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargaSGIO.aspx.cs" Inherits="Intranet.Web.Modulos.ProduccionServicios.Procesos.CargaSGIO" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
				<ext:JsonReader IDProperty="nro_ot">
					<Fields>
						<ext:RecordField Name="Existe" />
						<ext:RecordField Name="os_ot" />
						<ext:RecordField Name="ncod_centro" />
						<ext:RecordField Name="center" />
						<ext:RecordField Name="nro_ot" />
						<ext:RecordField Name="nis_rad" />
						<ext:RecordField Name="cliente" />
						<ext:RecordField Name="municipio" />
						<ext:RecordField Name="localidad" />
						<ext:RecordField Name="direccion" />
						<ext:RecordField Name="estado" />
						<ext:RecordField Name="nest_ot" />
						<ext:RecordField Name="actividad" />
						<ext:RecordField Name="desc_actividad" />
						<ext:RecordField Name="subactividad" />
						<ext:RecordField Name="desc_subactividad" />
						<ext:RecordField Name="ncosto_ot" />
						<ext:RecordField Name="vobservacion_contrata" />
						<ext:RecordField Name="f_alta" />
						<ext:RecordField Name="f_ini" />
						<ext:RecordField Name="f_fin" />
						<ext:RecordField Name="f_atendido" />
						<ext:RecordField Name="f_res_contrata" />
						<ext:RecordField Name="tipo_red" />
						<ext:RecordField Name="ntip_red" />
						<ext:RecordField Name="vdescripcion" />
						<ext:RecordField Name="vref_direccion" />
						<ext:RecordField Name="vusuario" /> 
						<ext:RecordField Name="nres_contrata" />
						<ext:RecordField Name="ncod_cuadrilla" />
						<ext:RecordField Name="ncod_incidencia" />
						<ext:RecordField Name="ncod_factura" />
						<ext:RecordField Name="secs" />
						<ext:RecordField Name="secsfin" />
						<ext:RecordField Name="ot_contrata" />
						<ext:RecordField Name="ntip_ot" />
						<ext:RecordField Name="tipo_ot" />
						<ext:RecordField Name="nnum_os" />
						
					</Fields>
				</ext:JsonReader>
			</Reader>
		</ext:Store>
		<%--FIN SORES--%>
		<ext:Panel ID="Panel1" runat="server" Title="1. Datos del Archivo SGIO" Frame="true" Padding="5" >
			<Content>
				<table style="color:#15428B;">
					<tr>
						<td><b>Obra</b></td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="Obra" runat="server" StoreID="StoreObra" DisplayField="DescripcionCorta" 
							  ValueField="IdObra" EmptyText="--- Seleccione Obra ---" Width="200px">
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
                Height="350px" >
					<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>
							<ext:Column ColumnID="Existe" Header="Existe" DataIndex="Existe" />
							<ext:Column ColumnID="os_ot" Header="os_ot" DataIndex="os_ot" />
							<ext:Column ColumnID="ncod_centro" Header="ncod_centro" DataIndex="ncod_centro" />
							<ext:Column ColumnID="center" Header="center" DataIndex="center" />
							<ext:Column ColumnID="nro_ot" Header="nro_ot" DataIndex="nro_ot" />
							<ext:Column ColumnID="nis_rad" Header="nis_rad" DataIndex="nis_rad" />
							<ext:Column ColumnID="cliente" Header="cliente" DataIndex="cliente" />
							<ext:Column ColumnID="municipio" Header="municipio" DataIndex="municipio" />
							<ext:Column ColumnID="localidad" Header="localidad" DataIndex="localidad" />
							<ext:Column ColumnID="direccion" Header="direccion" DataIndex="direccion" />
							<ext:Column ColumnID="estado" Header="estado" DataIndex="estado" />
							<ext:Column ColumnID="nest_ot" Header="nest_ot" DataIndex="nest_ot" />
							<ext:Column ColumnID="localidad" Header="localidad" DataIndex="localidad" />
							<ext:Column ColumnID="actividad" Header="actividad" DataIndex="actividad" />
							<ext:Column ColumnID="desc_actividad" Header="desc_actividad" DataIndex="desc_actividad" />
							<ext:Column ColumnID="subactividad" Header="subactividad" DataIndex="subactividad" />
							<ext:Column ColumnID="desc_subactividad" Header="desc_subactividad" DataIndex="desc_subactividad" />
							<ext:Column ColumnID="ncosto_ot" Header="ncosto_ot" DataIndex="ncosto_ot" />
							<ext:Column ColumnID="vobservacion_contrata" Header="vobservacion_contrata" DataIndex="vobservacion_contrata" />
							<ext:Column ColumnID="f_alta" Header="f_alta" DataIndex="f_alta" />
							<ext:Column ColumnID="f_ini" Header="f_ini" DataIndex="f_ini" />
							<ext:Column ColumnID="f_fin" Header="f_fin" DataIndex="f_fin" />
							<ext:Column ColumnID="f_atendido" Header="f_atendido" DataIndex="f_atendido" />
							<ext:Column ColumnID="f_res_contrata" Header="f_res_contrata" DataIndex="f_res_contrata" />
							<ext:Column ColumnID="tipo_red" Header="tipo_red" DataIndex="tipo_red" />
							<ext:Column ColumnID="ntip_red" Header="ntip_red" DataIndex="ntip_red" />
							<ext:Column ColumnID="vdescripcion" Header="vdescripcion" DataIndex="vdescripcion" />
							<ext:Column ColumnID="vref_direccion" Header="vref_direccion" DataIndex="vref_direccion" />
							<ext:Column ColumnID="vusuario" Header="vusuario" DataIndex="vusuario" />
							<ext:Column ColumnID="nres_contrata" Header="nres_contrata" DataIndex="nres_contrata" />
							<ext:Column ColumnID="ncod_cuadrilla" Header="ncod_cuadrilla" DataIndex="ncod_cuadrilla" />
							<ext:Column ColumnID="ncod_incidencia" Header="ncod_incidencia" DataIndex="ncod_incidencia" />
							<ext:Column ColumnID="ncod_factura" Header="ncod_factura" DataIndex="ncod_factura" />
							<ext:Column ColumnID="secs" Header="secs" DataIndex="secs" />
							<ext:Column ColumnID="secsfin" Header="secsfin" DataIndex="secsfin" />
							<ext:Column ColumnID="ot_contrata" Header="ot_contrata" DataIndex="ot_contrata" />
							<ext:Column ColumnID="ntip_ot" Header="ntip_ot" DataIndex="ntip_ot" />
							<ext:Column ColumnID="tipo_ot" Header="tipo_ot" DataIndex="tipo_ot" />
							<ext:Column ColumnID="nnum_os" Header="nnum_os" DataIndex="nnum_os" />
						</Columns>
					</ColumnModel>
				</ext:GridPanel>
				<ext:Hidden ID="hdArchivoTemp" runat="server"></ext:Hidden>
				<ext:Hidden ID="hdNomArchivoTemp" runat="server"></ext:Hidden>
			</Items>
			<Buttons>
				<ext:Button ID="btnImportar" runat="server" Text="Importar Archivo" Icon="DatabaseGo">
					<DirectEvents>
						<Click OnEvent="btnImportar_DirectClick" Timeout="1200000">
							<EventMask ShowMask="true" Msg="Importando Datos" />
						</Click>
					</DirectEvents>
				</ext:Button>
			</Buttons>
		</ext:Panel>
    </form>
</body>

</html>
