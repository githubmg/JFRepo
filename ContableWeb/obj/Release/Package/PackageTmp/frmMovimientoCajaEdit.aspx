<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMovimientoCajaEdit.aspx.vb" Inherits="ContableWeb.frmMovimientoCajaEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del Movimiento de Caja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Movimiento de Caja</span></h2></div>
    <br />
    <form runat="server" id="frmMovimientoCajaEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Tipo de Movimiento</label>
        <span class="field"><asp:DropDownList ID="cmbTipoMovimiento" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>

        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <label>Medio de pago</label>
        <span class="field"><asp:DropDownList ID="cmbMedioPago" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>

        <asp:UpdatePanel ID="pnlCheque" runat="server" Visible="False" >
        <ContentTemplate>
          <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Datos del Cheque</span></h2></div>
            <div class="widgetcontent">
            <label>Origen</label>
            <span class="field"><asp:DropDownList ID="cmbOrigenCheque" runat="server"></asp:DropDownList></span>
            <label>Nro. de cheque</label>
            <span class="field"><asp:TextBox ID="txtNroCheque" runat="server" CssClass="longinput"></asp:TextBox></span>
            <label>Banco</label>
            <span class="field"><asp:DropDownList ID="cmbBanco" runat="server"></asp:DropDownList></span>
            <label>Fecha de emisión</label>
            <span class="field"><asp:TextBox ID="txtFechaEmision" runat="server" CssClass="longinput"></asp:TextBox></span>
            <label>Fecha de vencimiento</label>
            <span class="field"><asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="longinput"></asp:TextBox></span>
            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFechaEmision" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
            <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFechaVencimiento" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

                
            </div><!--widgetcontent-->
        </div>
        </ContentTemplate>
       </asp:UpdatePanel>
       
        <label>Monto</label>
        <span class="field"><asp:TextBox ID="txtMonto" runat="server" CssClass="smallinput"></asp:TextBox>&nbsp;&nbsp;(9999,99)</span>
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
