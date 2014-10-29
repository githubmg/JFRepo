<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmUsuarioEdit.aspx.vb" Inherits="ContableWeb.frmUsuarioEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Usuario</span></h2></div>
<br />
<form runat="server" id="frmUsuarioEdit" class="stdform" action="" method="post">

    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información General</a></li>
        </ul>
        <div  id="Div5">
            <label>Nombre de Usuario</label><span class="field"><asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
        </div>
        <div id="Div1">
            <label>Contraseña</label><span class="field"><asp:TextBox ID="txtContrasenia" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
        </div>
        <div id="Div4">
            <label>Repetir contraseña</label><span class="field"><asp:TextBox ID="txtContrasenia2" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
        </div>
        <div id="Div2">
            <label>Nombre</label><span class="field"><asp:TextBox ID="txtNombre" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
        </div>
        <div id="Div3">
            <label>Email</label><span class="field"><asp:TextBox ID="txtEmail" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
        </div>
     </div>
    <br />
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept"/>
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>
</form>
</asp:Content>
