<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFormaPagoEdit.aspx.vb" Inherits="ContableWeb.frmFormaPagoEdit" 
    title="Formas de Pago" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información de la Forma de Pago</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Forma de pago</span></h2></div>
<br />
<form runat="server" id="frmClubEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información General</a></li>
        </ul>
        <div id="tabs-1">
            <label>Descripcion</label>
            <span class="field"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Código de cuenta</label>
            <span class="field"><asp:TextBox ID="txtCuenta" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            <label>Es cheque</label>            <span class="field"><asp:CheckBox ID="chkEsCheque" runat="server" EnableViewState="true" /></span>
            <label>Es tarjeta</label>            <span class="field"><asp:CheckBox ID="chkEsTarjeta" runat="server" EnableViewState="true" /></span>
            <label>Es interdeposito</label>            <span class="field"><asp:CheckBox ID="chkEsInterdeposito" runat="server" EnableViewState="true" /></span>            <label>Válido para Fondo Fijo</label>            <span class="field"><asp:CheckBox ID="chkUsadoParaFondoFijo" runat="server" EnableViewState="true" /></span>            <label>Moneda</label>            <span class="field"><asp:DropDownList ID="cmbMoneda" runat="server"></asp:DropDownList></span>
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
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
    TargetControlID="txtCuenta"   
    ServiceMethod="VistaCuenta"
    ServicePath="servicios.asmx"
    MinimumPrefixLength="2" 
    CompletionListItemCssClass="select"
    CompletionInterval="100" />

</form>

</asp:Content>
