<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Intranet.Web.Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="WestMenu.ascx" tagname="WestMenu" tagprefix="uc1" %>
<%@ Register src="HelpWindow.ascx" tagname="HelpWindow" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="../Libreria/Estilos/main.css" rel="stylesheet" type="text/css" />
	<link rel="shortcut icon" href="../favicon.ico" />
	<link rel="icon" type="image/gif" href="../animated_favicon1.gif" />
    <title>.: SGC: MÓDULO DE PRODUCCIÓN :.</title>
	<style type="text/css">
		.iconoCONCYSSA
		{
		    background-image:url('../Libreria/Imagenes/iconCONCYSSA.png');
		    background-repeat:no-repeat;
		}
	</style>
<%--    <script type="text/javascript" language="javascript">
        <!--
        var CONTROLADOR = "mantener_sesion.ashx";
        function MantenSesion() {
            var head = document.getElementsByTagName("head").item(0);
            script = document.createElement("script");
            script.src = CONTROLADOR;
            script.setAttribute("type", "text/javascript");
            script.defer = true;
            head.appendChild(script);
        }

        setInterval("MantenSesion()",54000);
        //-->
    </script>--%>
	<script type="text/javascript">
		var addTab = function (tabPanel, id, url, ntitle) {
			var tab = tabPanel.getComponent(id);

			if (!tab) {
				tab = tabPanel.add({
					id: id,
					title: ntitle,
					closable: true,
					iconCls: 'iconoCONCYSSA',
					autoLoad: {
						showMask: true,
						url: url,
						mode: "iframe",
						maskMsg: "Cargando " + ntitle + "..."
					}
				});

			}

			tabPanel.setActiveTab(tab);
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
	<ext:ResourceManager ID="ResourceManager1" runat="server">
	</ext:ResourceManager>
	<ext:Viewport runat="server" Layout="border">
		<Items>
			
			<ext:Toolbar ID="Toolbar1" 
                runat="server" 
                Region="North" 
                Height="25" 
                Margins="0 0 4 0">
				<Items>
					<ext:Label ID="Label1" runat="server" IconCls="iconoCONCYSSA" Html="<b>SGC: MODULO DE PRODUCCIÓN</b> (1.0 RC)"
						Cls="title-label"
                        AutoDataBind="true"/>
                    <ext:ToolbarFill ID="ToolbarFill1" runat="server" /> 
					<ext:Label ID="Label2" runat="server" Cls="title-label" /> 
					<ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server" /> 
					<ext:Label ID="Label3" runat="server" Cls="title-label" /> 
					<ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server" /> 
					<ext:Label ID="Label4" runat="server" Cls="title-label" /> 
					
					<ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
					<ext:Button ID="Button2" runat="server" Icon="ComputerConnect" Text="Opciones">
                        <Menu runat="server">
                            <ext:Menu ID="Menu2" runat="server">
                                <Items>
                                    <ext:MenuItem Text="Cambiar Password" Icon="LockEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tpMain},'Cambio de Password','CambioPassword.aspx','Password');" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Reportar defecto" Icon="Bug">
                                       <%-- <Listeners>
                                            <Click Handler="addTab(#{TabPanel1},'Reportar Defecto','Modulos/ProduccionServicios/Procesos/ObraDistrito/ObraDistrito.aspx','Zona');" />
                                        </Listeners>--%>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Acerca De" Icon="Information">
                                        <%--<Listeners>
                                            <Click Handler="#{winAbout}.show();" />
                                        </Listeners>--%>
                                    </ext:MenuItem>
                                </Items>
                            </ext:Menu>
                        </Menu>
                    </ext:Button>
					<ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                    <ext:Button ID="Button1" runat="server" Icon="LockGo" Text="Cerrar Sesión">
                        <DirectEvents>
                            <Click OnEvent="Button1_Click"></Click>
                        </DirectEvents>
                    </ext:Button>
				</Items>
			</ext:Toolbar>

			<ext:Panel ID="pnlWest" runat="server" Collapsible="true" Layout="accordion" Region="West" Split="false" Width="200">
				<%--<Items>
					<ext:Panel ID="Panel7" runat="server" Border="false" Collapsed="True" AutoHeight="true" Icon="FolderGo" Title="PRODUCCIÓN SERVICIOS" BodyStyle="background-color:#D0DEF0;">
						<Items>
							<ext:MenuPanel ID="MenuPanel1" runat="server" AutoWidth="true" BodyStyle="background-color:#D0DEF0;">
								<Menu runat="server">
									<Items>
										<ext:MenuItem ID="MenuItem4" runat="server" Text="MAESTRAS" Icon="ApplicationForm" >
                                        <Menu>
                                            <ext:Menu ID="Menu4_1" runat="server" >
                                                <Items>
                                                    <ext:MenuItem ID="MenuItem4_1" runat="server" Text="Trabajo Complementario" Icon="FolderExplore">
                                                    <Listeners>
                                                    <Click Handler="addTab(#{TabPanel1},'TrabajoComplementario','Modulos/ProduccionServicios/Maestras/TrabajoComplementario/TrabajoComplementario.aspx','Trabajo Complementario');" />
                                                    </Listeners>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="MenuItem6" runat="server" Text="Estado OT" Icon="FolderExplore">
                                                    <Listeners>
                                                    <Click Handler="addTab(#{TabPanel1},'Estado OT','Modulos/ProduccionServicios/Maestras/EstadoOT/EstadoOT.aspx','Estado OT');" />
                                                    </Listeners>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="MenuItem7" runat="server" Text="Zona por Distrito" Icon="FolderExplore">
                                                    <Listeners>
                                                    <Click Handler="addTab(#{TabPanel1},'Zona','Modulos/ProduccionServicios/Maestras/Zona/Zona.aspx','Zona');" />
                                                    </Listeners>
                                                    </ext:MenuItem>
                                                    

                                                </Items>
                                            </ext:Menu>
                                        </Menu>


										</ext:MenuItem>

										<ext:MenuItem ID="MenuItem1" runat="server" Text="PROCESOS" Icon="ApplicationForm">
											<Menu>
												<ext:Menu ID="Menu1" runat="server">
													<Items>
														<ext:MenuItem ID="MenuItem3" runat="server" Text="Carga SGIO" Icon="FolderExplore">
															<Listeners>
																<Click Handler="addTab(#{TabPanel1}, 'CargaSGIO', 'Modulos/ProduccionServicios/Procesos/Carga/CargaSGIO.aspx','Carga SGIO');" />
															</Listeners>
														</ext:MenuItem>
														<ext:MenuItem ID="MenuItem11" runat="server" Text="Carga Consumo SGIO" Icon="FolderExplore">
															<Listeners>
																<Click Handler="addTab(#{TabPanel1}, 'CargaConsumoSGIO', 'Modulos/ProduccionServicios/Procesos/CargaConsumo/CargaConsumo.aspx','Carga Consumo SGIO');" />
															</Listeners>
														</ext:MenuItem>
														<ext:MenuItem ID="MenuItem9" runat="server" Text="Consumo Materiales" Icon="PackageIn">
															<Listeners>
																<Click Handler="addTab(#{TabPanel1}, 'consumomateriales', 'Modulos/ProduccionServicios/Procesos/ConsumoMateriales/ConsumoMaterial.aspx','Consumo de Materiales');" />
															</Listeners>
														</ext:MenuItem>
														<ext:MenuItem ID="MenuItem2" runat="server" Text="Orden Trabajo" Icon="PackageIn">
															<Listeners>
																<Click Handler="addTab(#{TabPanel1}, 'ListaOT', 'Modulos/ProduccionServicios/Procesos/EjecucionOT/ListaOT.aspx','Listado de Órdenes de Trabajo');" />
															</Listeners>
														</ext:MenuItem>
														<ext:MenuItem ID="MenuItem8" runat="server" Text="Asignar Zonas por Cuadrilla" Icon="PackageIn">
															<Listeners>
																<Click Handler="addTab(#{TabPanel1}, 'ListaOT', 'Modulos/ProduccionServicios/Procesos/CuadrillaZona/CuadrillaZona2.aspx','Asignar Zona por Cuadrilla');" />
															</Listeners>
														</ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem10" runat="server" Text="Distrito por Obra" Icon="FolderExplore">
                                                        <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1},'Zona','Modulos/ProduccionServicios/Procesos/ObraDistrito/ObraDistrito.aspx','Zona');" />
                                                        </Listeners>
                                                        </ext:MenuItem>

													</Items>
												</ext:Menu>
											</Menu>
										</ext:MenuItem>
										<ext:MenuItem ID="MenuItem5" runat="server" Text="REPORTES" Icon="ApplicationForm">
										</ext:MenuItem>
									</Items>
								</Menu>
							</ext:MenuPanel>
						</Items>
					</ext:Panel>

				</Items>--%>
				<Content>
                    <uc1:WestMenu ID="WestMenu1" runat="server" />
                </Content>
			</ext:Panel>
			<ext:TabPanel 
                ID="tpMain" runat="server" 
                Region="Center">
				<Items>
                    <ext:Panel 
                        ID="Tab1" 
                        runat="server" 
                        Title="Dashboard" 
                        IconCls="iconoCONCYSSA"
                        Border="false">
                        <AutoLoad 
                            Url="Dashboard.aspx" 
                            Mode="IFrame" 
                            ShowMask="true" 
                            MaskMsg="Cargando 'Dashboard'..." 
                            />
                    </ext:Panel>                        
                </Items>
                <Plugins>
                    <ext:TabCloseMenu ID="TabCloseMenu1" runat="server" />
                </Plugins>
			</ext:TabPanel>
		</Items>
	</ext:Viewport>
	<uc2:HelpWindow ID="HelpWindow1" runat="server" />
    </form>
</body>
</html>
