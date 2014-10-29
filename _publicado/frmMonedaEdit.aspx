<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMonedaEdit.aspx.vb" Inherits="ContableWeb.frmMonedaEdit" 
    title="Monedas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información del Moneda</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Moneda</span></h2></div>
<br />
<form runat="server" id="frmMonedaEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información General</a></li>
        </ul>
        <div id="tabs-1">
            <label>Descripcion</label><span class="field"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Simbolo</label><span class="field"><asp:TextBox ID="txtSimbolo" runat="server" CssClass="mediuminput" MaxLength="10"></asp:TextBox></span>
            <label>Abreviatura</label><span class="field"><asp:TextBox ID="txtAbreviatura" runat="server" CssClass="mediuminput" MaxLength="10"></asp:TextBox></span>
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
