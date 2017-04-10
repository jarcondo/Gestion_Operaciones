<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonitoreoOT.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.Monitoreo.MonitoreoOT" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
	<link href="../../../../../Libreria/Estilos/global.css" rel="stylesheet" type="text/css" />
    
    
     <script type="text/javascript">
         App.direct.doSomething(var1, {
             success: function (result) {
                 PlaySound();
             }
         });

         var beepSound = null;
         function PlaySound() {
             if (beepSound != null) {
                 document.body.removeChild(beepSound);
                 beepSound.removed = true;
                 beepSound = null;
             }
             beepSound = document.createElement("embed");
             beepSound.setAttribute("src", "http://www.sonidosmp3gratis.com/sounds/cartoon048.mp3");
             beepSound.setAttribute("hidden", true);
             beepSound.setAttribute("autostart", true);
             document.body.appendChild(beepSound);
         }


       </script>


       <script  language="javascript" type="text/javascript">
           function startTimer() {
               taskManager.startTask('tskList');
           }

          


       </script>

    <script type="text/javascript">
              var template = '{1}';

              var change = function (value, metaData, record, rowIndex, colIndex, store) {
                  if (value == "GESTIONANDO") {
                      metaData.css = "GESTIONANDO";
                  }

                  if (value == "ENTC") {
                      metaData.css = "ENTC";
                  }

                  if (value == "SINASIGNAR") {
                      metaData.css = "SINASIGNAR";
                  }

                  // return String.format(template, (value > 0) ? "green" : "red", value);
              };

              
              var ftipotrabajo = function (value, metaData, record, rowIndex, colIndex, store) {
                  if (value == "PROGRAMADO" || value == "CARGA DE TRABAJO") {
                      metaData.css = "PROGRAMADO";
                  }

                  if (value == "EMERGENCIA" || value == "EMERGENCIA NO INMEDIATA") {
                      metaData.css = "EMERGENCIA";
                  }

                  if (value == "REUNION" || value == "TRABAJO EN CLIENTE") {
                      metaData.css = "REUNION";
                  }
                 
                 


                 
              };

            
    </script>
    <style type="text/css">
       
       #GridPanel1 .x-grid3-cell-inner {
          font-size: 10px;
        }
        
         .REUNION 
        {
            background-color: #58D3F7;
            color:#FFFFFF;
        }
        
         .EMERGENCIA 
        {
            background-color: #FF0000; 
            color:#FFFFFF;
        }
        
         .PROGRAMADO 
        {
            background-color: #FACC2E; 
            color:#FFFFFF;
        }
        
        .GESTIONANDO 
        {
            background-color: #00FF00; 
            color: #00FF00; 
        }
        
        .ENTC 
        {
            background-color: #00FF00; 
            color: #00FF00; 
        }
        
        .SINASIGNAR 
        {
            background-color: #FFFF00; 
            color: #FFFF00; 
        }
        
    </style>



</head>

<body>



    <form id="form1" runat="server">
    
    <ext:TaskManager ID="taskManager" runat="server" IDMode="Static">
        <Tasks>
            <ext:Task TaskID="tskList" Interval="60000" AutoRun="false">
                <DirectEvents>
                <Update OnEvent="btnBuscar_Click" Timeout="1200000">
                  <EventMask ShowMask="true" Msg="Cargando Datos" />
                </Update>
                </DirectEvents>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>


    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <ext:Panel ID="Panel1" runat="server" AutoHeight="true" Title="Monitoreo de la operacion" Height="550px">
    <Items>
    


    <ext:Button ID="btnBuscar" runat="server" Text="Monitoreo Automatico" Icon="DatabaseGo" Width="100">
	    <Listeners>
            <Click Handler="startTimer();" />
        </Listeners>

        <DirectEvents>
		    <Click OnEvent="btnBuscar_Click" Timeout="1200000">
			    <EventMask ShowMask="true" Msg="Cargando Datos" />
		    </Click>
	    </DirectEvents>
    </ext:Button>

     <ext:Hidden ID="FormatType" runat="server" />
       <ext:GridPanel ID="GridPanel1" runat="server" Height="500px">
               <Store>
					<ext:Store ID="StoreEjecucionOT" runat="server"
                      OnAfterRecordUpdated="StoreEjecucionOT_RecordUpdated" 
                      OnRefreshData="StoreEjecucionOT_RefreshData"
                      RemoteSort="false" >
                        <DirectEventConfig IsUpload="true" />
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
						<Reader>
							<ext:JsonReader IDProperty="idindex">
								<Fields>
                                    <ext:RecordField Name="idindex" />
                                    <ext:RecordField Name="GESTION" />
                                    <ext:RecordField Name="IdEjecucionOT" /> 
                                    <ext:RecordField Name="IdCuadrilla" />
                                    <ext:RecordField Name="DesCuadrilla" />
                                    <ext:RecordField Name="NroRegistro" />
                                    <ext:RecordField Name="DiasCont" />
									<ext:RecordField Name="Item" />
									<ext:RecordField Name="NroOT" />
									<ext:RecordField Name="NIS" />
									<ext:RecordField Name="NroOrden" />
									<ext:RecordField Name="Distrito" />
									<ext:RecordField Name="Direccion" />
                                    <ext:RecordField Name="Direccion2" />
                                    <ext:RecordField Name="Localidad" />
									<ext:RecordField Name="Cliente" />
									<ext:RecordField Name="Actividad" />
                                    <ext:RecordField Name="SubActividad" />
									<ext:RecordField Name="Descripcion" />
									<ext:RecordField Name="FechaAlta" />
									<ext:RecordField Name="Estado" />
                                    <ext:RecordField Name="CambioMasivo" />
                                    <ext:RecordField Name="TipoTrabajo" />
                                     <ext:RecordField Name="FechaHoraIni" />
                                    <ext:RecordField Name="FechaHoraFin" />
                                    <ext:RecordField Name="Ingeniero" />
                                    
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>

                	<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
                        
                        <ext:Column ColumnID="Item" Header="Item" DataIndex="idindex" Width="40px" Hidden="true"/>
                        
                        

						<ext:Column ColumnID="NroRegistro" Header="N° Orden Trabajo" DataIndex="NroRegistro" Width="70px" />
                        <ext:Column ColumnID="Estado" Header="Estado" DataIndex="Estado" Width="80px" />
                        <ext:Column ColumnID="GESTION" Header="GESTION" DataIndex="GESTION" Width="25px">
                          <Renderer Fn="change" /></ext:Column> 
                          
                          <ext:Column ColumnID="TipoTrabajo2" Header="TipoTrabajo" DataIndex="TipoTrabajo" Width="130px" />
                          <ext:Column ColumnID="TipoTrabajo" Header="TT" DataIndex="TipoTrabajo" Width="20px" >
                          <Renderer Fn="ftipotrabajo" />
                          </ext:Column> 

                         <ext:Column ColumnID="Cliente" Header="Cliente" DataIndex="Cliente" Width="120px"  />
                         <ext:Column ColumnID="FechaAlta" Header="Fec. Alta" DataIndex="FechaAlta" Width="120px" />
						<ext:Column ColumnID="Actividad" Header="Actividad" DataIndex="Actividad" Width="150px"/>
                        <ext:Column ColumnID="DesCuadrilla" Header="Asignado" DataIndex="DesCuadrilla" Width="120px" />
  						<ext:Column ColumnID="Descripcion" Header="Descripción" DataIndex="Descripcion" Width="300px" />
                        <ext:Column ColumnID="FechaHoraIni" Header="F.H. Inicio" DataIndex="FechaHoraIni" Width="100px" />
                        <ext:Column ColumnID="FechaHoraFin" Header="F.H. Fin" DataIndex="FechaHoraFin" Width="100px" />
   						
						<ext:Column ColumnID="IdEjecucionOT" Header="IdEjecucionOT" DataIndex="IdEjecucionOT" Hidden="true" />
						<ext:Column ColumnID="Distrito" Header="Distrito" DataIndex="Distrito" Width="130px" Hidden="true" />
						
					</Columns>
				</ColumnModel>
                <LoadMask ShowMask="true" />

        </ext:GridPanel>
    </Items>
    </ext:Panel>
    </form>
</body>
</html>
