<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmProductoEdit.aspx.vb" Inherits="ContableWeb.frmProductoEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<div class="contenttitle"><h2 class="form"><span>Producto</span></h2></div>
<br />
<form runat="server" id="frmProductoEdit" class="stdform" action="" method="post">
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>--%>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información de Producto</a></li>
        </ul>
        <div id="tabs-1">
         <label>Código de Producto</label>
            <span class="field"><asp:TextBox ID="txtCodProducto" runat="server" CssClass="smallinput" MaxLength="20"></asp:TextBox></span>
         <label>Familia</label>
            <span class="field"><asp:DropDownList ID="cmbFamilia" runat="server" 
            AutoPostBack="True"></asp:DropDownList></span>
            <label>Descripción</label>
            <span class="field"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="longinput" MaxLength="150"></asp:TextBox></span>
            <label>Alícuota IVA</label>
            <span class="field"><asp:DropDownList ID="cmbAlicuotaIva" runat="server" 
            AutoPostBack="True"></asp:DropDownList></span>
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
