<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="ContableWeb._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<title>JF Servicios - Sistema de gestión</title>
<link rel="stylesheet" href="./css/style.css" type="text/css" />
<link rel="shortcut icon" href="images/favicon.ico" />
<script type="text/javascript" src="./js/plugins/jquery-1.7.min.js"></script>
<script type="text/javascript" src="./js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
<!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
<![endif]-->
<meta charset="UTF-8">
    <style type="text/css">
        .style1
        {
            width: 151px;
            height: 66px;
        }
    </style>
</head>
<body>

<div class="loginbox radius3">
	<div class="loginboxinner radius3">
    	<div class="loginheader">
        	<div class="logo">
                <img alt="" class="style1" 
                    src="images/starlight_admin_template_logo_small.png" /></div>
    	</div><!--loginheader-->
        
        <div class="loginform">
        	
        	<form id="login" method="post" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>        	
        	    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers><asp:AsyncPostBackTrigger ControlID="cmdIngresar" EventName="Click" /></Triggers>
                    <ContentTemplate>
                        <div id="divError" class="loginerror" visible = "false" runat="server"><p>Usuario o contraseña inválidos</p></div>
            	        <p>
                	        <label for="username" class="bebas">Usuario</label>
                            <asp:TextBox id="username" CssClass="radius2" runat="server"></asp:TextBox>
                        </p>
                        <p>
                	        <label for="password" class="bebas">Contraseña</label>
                            <asp:TextBox id="password" CssClass="radius2" TextMode="Password" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button ID="cmdIngresar" runat="server" Text="Ingresar" CssClass="radius3 bebas botonLogin" />

                        </p>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div><!--loginform-->
    </div><!--loginboxinner-->
</div><!--loginbox-->
    <asp:Label ID="lblError" runat="server" Text="" class="loginerror"></asp:Label>
</body>
</html>
