<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Intranet.Web.Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="shortcut icon" href="../favicon.ico"  />
	<link rel="icon" type="image/gif" href="../favicon.ico" />
    <title>.: SMC GESTION DE OPERACIONES :. Login</title>
	<style type="text/css">
        h1 {
            font: normal 60px tahoma, arial, verdana;
            color: #E1E1E1;
        }
        
        h2 {
            font: normal 20px tahoma, arial, verdana;
            color: #E1E1E1;
        }
        
        .x-window-mc {
            background-color : #F4F4F4 !important;
        }
    </style>
    <script type="text/javascript">
    	if (window.top.frames.length !== 0) {
    		window.top.location = self.document.location;
    	}
    </script>
</head>
<body>

	<ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
	<h1>SMC GESTION DE OPERACIONES</h1>
    <h2>SMARTCODE  CONSULTING SERVICES - <asp:Literal ID="ltrAnho" runat="server"></asp:Literal></h2>
    <ext:Window ID="LoginWindow"
        runat="server" 
        Closable="false"
        Resizable="false"
        Height="130" 
        Icon="Lock" 
        Title="Login"
        Draggable="true"
        Width="250"
        Modal="true"
        Layout="fit"
        BodyBorder="true"
        Padding="5">        
		<Items>
                <ext:FormPanel ID="FormPanel1" 
                    runat="server" 
                    FormID="form1"
                    Border="false"
                    Layout="form"
                    BodyBorder="false" 
                    BodyStyle="background:transparent;" >
                    <Items>
                        <ext:TextField 
                            ID="txtUsername" 
                            runat="server" 
                            FieldLabel="Usuario" 
                            AllowBlank="false"
                            BlankText="Ingrese Usuario."
                            AnchorHorizontal="100%"
                            />
                         <ext:TextField 
                            ID="txtPassword" 
                            runat="server" 
                            InputType="Password" 
                            FieldLabel="Password" 
                            AllowBlank="false" 
                            BlankText="Ingrese Password."
                            AnchorHorizontal="100%"
                            />
                    </Items>
                </ext:FormPanel>
        </Items>
		<Buttons>
			<ext:Button ID="Button1" runat="server" Text="Ingresar" Icon="Accept">
				<DirectEvents>
                    <Click OnEvent="Button1_Click"
					Timeout="60000"
					FormID="form1"
                    CleanRequest="true" 
                    Method="POST">
                        <EventMask MinDelay="250" ShowMask="true" Msg="Verificando..."  />
						<ExtraParams>
                            <ext:Parameter Name="ReturnUrl" Value="Ext.urlDecode(String(document.location).split('?')[1]).r || '/'" Mode="Raw" />
                        </ExtraParams>
                    </Click>
                </DirectEvents>
			</ext:Button>
		</Buttons>
	</ext:Window>


	
</body>
</html>

