<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmAgendaEdit.aspx.vb" Inherits="ContableWeb.frmAgendaEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del evento
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Pagos</span></h2></div>
    <br />
    <form runat="server" id="frmPedidoEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <label>Cliente</label>
        <span class="field"><asp:TextBox ID="txtCliente" runat="server" CssClass="longinput"></asp:TextBox></span>
         <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtCliente"   
            ServiceMethod="VistaCliente"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        <label>Trabajo a realizar</label>
        <span class="field"><asp:TextBox ID="txtTrabajo" runat="server" 
                TextMode="MultiLine" Rows="3" Width="260px"></asp:TextBox></span>
        <label>Datos de contacto</label>
        <span class="field"><asp:TextBox ID="txtDatosContacto" runat="server" 
                TextMode="MultiLine" Rows="3" Width="260px"></asp:TextBox></span>

        <label>Estado</label>
        <span class="field"><asp:DropDownList ID="cmbEstado" runat="server">
            <asp:ListItem Text="Pendiente"></asp:ListItem>
            <asp:ListItem Text="A confirmar"></asp:ListItem>
            <asp:ListItem Text="Terminado"></asp:ListItem>
            <asp:ListItem Text="Anulado"></asp:ListItem>
        </asp:DropDownList></span>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <label>Domicilio</label>
            <span class="field"><asp:DropDownList ID="cmbDomicilio" runat="server" AutoPostBack="true">
                <asp:ListItem Text="Irigoyen"></asp:ListItem>
                <asp:ListItem Text="San Isidro"></asp:ListItem>
                <asp:ListItem Text="Domicilio"></asp:ListItem>
                <asp:ListItem Text="Otros"></asp:ListItem>
            </asp:DropDownList></span>
            <asp:Panel runat="server" ID="pnlDomicilio" Visible="false">
                 <span class="field"><asp:TextBox ID="txtDomicilio" runat="server" CssClass="longinput"></asp:TextBox></span>
            </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
        
        </p>

        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
    </form>
</asp:Content>
