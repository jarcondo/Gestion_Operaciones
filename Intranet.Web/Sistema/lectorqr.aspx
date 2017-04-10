<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lectorqr.aspx.cs" Inherits="Prestamos.lectorqr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 
    <script type="text/javascript">
        $(document).on('click', '#reader', function (e) {
            var $this = $(this);
            if (!$this.hasClass('reader')) {
                $this.addClass('reader');
                $this.find('i').removeClass('#reader').addClass('rotar');
                
                $('.rotar').animate({ height: 335 }, 500);

            }   else {                
                $this.parents('#reader').find('#reader').slideDown(1000);
                $this.removeClass('#reader');
                $this.find('i').removeClass('.rotar').addClass('#reader');
                $('#reader').animate({ height: 600 }, 450);
        //$('#divContenedorGV').css("height", "110px");
        }
        })
    </script>
    
    <style type="text/css">
        .rotar
        {
            width: 1000px;
            height: 450px;
        }
        #reader
        {
            width: 600px;
            height: 450px;
        }

        @media screen and (min-width: 480px)
        {
            body
            {
                background-color: lightgreen;
            }
        }
   
        
    </style>
</head>
<script src="js/jquery-1.9.1.min.js"></script>
<script src="js/html5-qrcode.min.js"></script>
   
<body>
    <form id="form1" runat="server">
        <div id="reader" class="rotar" >
            
               <h3>Datos del Código QR:</h3> 
           
                <asp:TextBox ID="txtCodigo" runat="server" Width="371px"></asp:TextBox>
            

            <br />
        </div>
        </form>
        <script>
            $(document).ready(function () {
                $('#reader').html5_qrcode(function (data) {
                    $('#<%=txtCodigo.ClientID%>').val(data);
            },
                function (error) {

                }, function (videoError) {
                    alert("No hay cámara");
                }
            );
        });

    </script>

    
    </body>
</html>
