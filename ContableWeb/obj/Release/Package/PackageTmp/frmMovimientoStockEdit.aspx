<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMovimientoStockEdit.aspx.vb" Inherits="ContableWeb.frmMovimientoStockEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del Movimiento de Stock
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<div class="contenttitle"><h2 class="form"><span>Movimiento de Stock</span></h2></div>
<br />
<form runat="server" id="frmProductoEdit" class="stdform" action="" method="post">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>--%>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información del Movimiento de Stock</a></li>
        </ul>
        <div id="tabs-1">
        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Tipo de Movimiento</label>
        <span class="field"><asp:DropDownList ID="cmbTipoMovimiento" runat="server" AutoPostBack="True"></asp:DropDownList></span>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <label>Familia</label>
                <span class="field"><asp:DropDownList ID="cmbFamilia" runat="server" AutoPostBack="True"></asp:DropDownList></span>
                <label>Producto</label>
                <span class="field"><asp:DropDownList ID="cmbProducto" runat="server" AutoPostBack="True"></asp:DropDownList></span>
            </ContentTemplate>
            </asp:UpdatePanel>   
        <label>Cantidad</label>
        <span class="field"><asp:TextBox ID="txtCantidad" runat="server" 
                CssClass="smallinput" MaxLength="11"></asp:TextBox></span>
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
    <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
</form>
</asp:Content>
