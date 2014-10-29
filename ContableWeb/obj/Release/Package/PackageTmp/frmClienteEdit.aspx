<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmClienteEdit.aspx.vb" Inherits="ContableWeb.frmClienteEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información de cliente</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<div class="contenttitle"><h2 class="form"><span>Cliente</span></h2></div>
<br />
<form runat="server" id="frmCuentaEdit" class="stdform" action="" method="post">
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>--%>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información de Cliente</a></li>
        </ul>
        <div id="tabs-1">
            <label>CUIT</label>
            <span class="field"><asp:TextBox ID="txtCuit" runat="server" CssClass="smallinput" MaxLength="11"></asp:TextBox></span>
            <label>Razon social</label>
            <span class="field"><asp:TextBox ID="txtRazonSocial" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Provincia</label>
            <span class="field"><asp:DropDownList ID="cmbProvincia" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>
            <label>Localidad</label>
            <span class="field"><asp:DropDownList ID="cmbLocalidad" runat="server"></asp:DropDownList></span>
            <label>Domicilio</label>
            <span class="field"><asp:TextBox ID="txtDomicilio" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Código postal</label>
            <span class="field"><asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="smallinput" MaxLength="10"></asp:TextBox></span>
            <label>Condicion IVA</label>  
            <span class="field"><asp:DropDownList ID="cmbCondicionIva" runat="server"></asp:DropDownList></span>
            <label>Teléfono</label>
            <span class="field"><asp:TextBox ID="txtTelefono" runat="server" CssClass="mediuminput" MaxLength="20"></asp:TextBox></span>  
            <label>Correo Electrónico</label>
            <span class="field"><asp:TextBox ID="txtEmail" runat="server" CssClass="mediuminput" MaxLength="100"> </asp:TextBox></span>
            <label>Observaciones</label>
            <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput" MaxLength="250"> </asp:TextBox></span>
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
