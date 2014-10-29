<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="ContableWeb.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<title>Sistema Contable AAT</title>
<link rel="stylesheet" href="./css/style.css" type="text/css" />
<script type="text/javascript" src="./js/plugins/jquery-1.7.min.js"></script>
<script type="text/javascript" src="./js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
<!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
<![endif]-->
<meta charset="UTF-8">
</head>
<body>

<div class="loginbox radius3">
	<div class="loginboxinner radius3">
    	<div class="loginheader">
        	<div class="logo"><img src="images/starlight_admin_template_logo_small.png" alt="logo AAT" /></div>
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
    
</body>
</html>
