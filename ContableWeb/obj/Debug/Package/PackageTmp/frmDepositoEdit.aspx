<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmDepositoEdit.aspx.vb" Inherits="ContableWeb.frmDepositoEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del depósito
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Pagos</span></h2></div>
    <br />
    <form runat="server" id="frmPedidoEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        
        <label>Cheque</label>
        <span class="field"><asp:TextBox ID="txtChequeCartera" runat="server" CssClass="longinput"></asp:TextBox></span>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtChequeCartera"   
            ServiceMethod="VistaChequeCartera"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        <label>Fecha de depósito</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <label>Banco</label>
        <span class="field"><asp:DropDownList ID="cmbBanco" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>
         
        <label>Nro. de transacción</label>
         <span class="field"><asp:TextBox ID="txtNroTransaccion" runat="server" CssClass="longinput"></asp:TextBox></span>
   
       
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
    </form>
</asp:Content>
