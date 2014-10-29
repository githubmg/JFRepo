<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmProveedorEdit.aspx.vb" Inherits="ContableWeb.frmProveedorEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información del proveedor</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<div class="contenttitle"><h2 class="form"><span>Proveedor</span></h2></div>
<br />
<form runat="server" id="frmCuentaEdit" class="stdform" action="" method="post">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>

<div id="tabs">
    <ul>
        <li><a href="#tabs-1">Información General</a></li>
        <li><a href="#tabs-2">Datos Comerciales</a></li>
        <li><a href="#tabs-3">Retenciones</a></li>
        <li><a href="#tabs-4">Contable</a></li>
    </ul>
    <div id="tabs-1">
        <label>Razon Social</label>        <span class="field"><asp:TextBox ID="txtRazonSocial" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Rubro</label>        <span class="field"><asp:DropDownList ID="cmbRubroProveedor" runat="server"></asp:DropDownList></span>        <label>Dirección</label>        <span class="field"><asp:TextBox ID="txtDireccion" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Teléfono</label>        <span class="field"><asp:TextBox ID="txtTelefono" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Fax</label>        <span class="field"><asp:TextBox ID="txtFax" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Email</label>        <span class="field"><asp:TextBox ID="txtEmail" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Web</label>        <span class="field"><asp:TextBox ID="txtWeb" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Provincia</label>        <span class="field"><asp:DropDownList ID="cmbProvincia" runat="server"></asp:DropDownList></span>        <label>Localidad</label>        <span class="field"><asp:TextBox ID="txtLocalidad" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Código Postal</label>        <span class="field"><asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="smallinput"></asp:TextBox></span>
    </div>
    <div id="tabs-2">
        <label>Condición IVA</label>        <span class="field"><asp:DropDownList ID="cmbCondicionIva" runat="server"></asp:DropDownList></span>
        <label>CUIT</label>        <span class="field"><asp:TextBox ID="txtCuit" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Cheques a la orden de</label>        <span class="field"><asp:TextBox ID="txtChequesALaOrdenDe" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Inscripto en Ganancias</label>        <span class="field"><asp:CheckBox ID="chkInscriptoGanancias" runat="server" EnableViewState="true" /></span>        <label>Recibe Facturas</label>        <span class="field"><asp:CheckBox ID="chkRecibeFacturas" runat="server" EnableViewState="true" /></span>        <label>Subdiario</label>        <span class="field"><asp:CheckBox ID="chkSubdiario" runat="server" EnableViewState="true" /></span>        <label>CAI</label>        <span class="field"><asp:TextBox ID="txtCaiNumero" runat="server" CssClass="smallinput" MaxLength="14"></asp:TextBox></span>        <label>Vencimiento CAI</label>        <span class="field"><asp:TextBox ID="txtCaiVencimiento" runat="server" CssClass="smallinput"></asp:TextBox></span>        <asp:CalendarExtender ID="txtCaiVencimientoExt" TargetControlID="txtCaiVencimiento" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />        <label>CBU</label>        <span class="field"><asp:TextBox ID="txtCuentaCBU" runat="server" CssClass="smallinput"></asp:TextBox></span>        <label>Banco</label>        <span class="field"><asp:DropDownList ID="cmbCuentaBanco" runat="server"></asp:DropDownList></span>

    </div>
    <div id="tabs-3">
        <label>% Ret. Seguridad Social</label>        <span class="field"><asp:TextBox ID="txtRetSeguridadSocialPorcentaje" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Resol. General Seg. Social</label>        <span class="field"><asp:DropDownList ID="cmbRetSeguridadSocialResolucionGeneral" runat="server"></asp:DropDownList></span>
        <label>Ganancias</label>        <span class="field"><asp:DropDownList ID="cmbGanancias" runat="server"></asp:DropDownList></span>
        <label>% Ret. IIBB</label>        <span class="field"><asp:TextBox ID="txtRetIIBBPorcentaje" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Número de IIBB</label>        <span class="field"><asp:TextBox ID="txtNumeroIIBB" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Retiene Iva</label>        <span class="field"><asp:CheckBox ID="chkRetieneIva" runat="server" EnableViewState="true" /></span>    </div>    <div id="tabs-4">            <label>Código de cuenta de resultado</label>
            <span class="field"><asp:TextBox ID="txtCuentaResultado" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            <label>Código de cuenta patrimonial</label>
            <span class="field"><asp:TextBox ID="txtCuentaPatrimonial" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                TargetControlID="txtCuentaResultado"   
                ServiceMethod="VistaCuenta"
                ServicePath="servicios.asmx"
                MinimumPrefixLength="2" 
                CompletionListItemCssClass="select"
                CompletionInterval="100" />
            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                TargetControlID="txtCuentaPatrimonial"   
                ServiceMethod="VistaCuenta"
                ServicePath="servicios.asmx"
                MinimumPrefixLength="2" 
                CompletionListItemCssClass="select"
                CompletionInterval="100" />
    </div></div>
<br /><div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
    <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
</div><p class="stdformbutton">
    <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept"/>
    <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
</p>
</form>

</asp:Content>
