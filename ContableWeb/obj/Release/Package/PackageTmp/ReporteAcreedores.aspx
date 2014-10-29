<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="ReporteAcreedores.aspx.vb" Inherits="ContableWeb.ReporteAcreedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Reporte de Acreedores por Compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 <script language="javascript" type="text/javascript">
     window.onload = function lalal() {
         var iframes = document.getElementsByTagName("IFRAME");
         for (var i = 0, ln = iframes.length; i < ln; i++) {
             iframes[0].parentNode.removeChild(iframes[0]);
         }
     }
</script>
    <form id="frmReporteAcreedores" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
      
        <label>Desde:</label>
        <span class="field"><asp:TextBox ID="txtFechaDesde" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaDesdeExt" TargetControlID="txtFechaDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

        <label>Hasta:</label>
        <span class="field"><asp:TextBox ID="txtFechaHasta" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaHastaExt" TargetControlID="txtFechaHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerAcreedores" runat="server" Text="Ver Acreedores" CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>Acreedores por compras</span></h2>
        </div>
        <br />
        <div id="divExportacion" runat="server" visible="false">
            <asp:LinkButton ID="lnkExpoPDF" runat="server" CssClass="btn btn_pdf"  ><span>PDF</span></asp:LinkButton>
            <asp:LinkButton ID="lnkExpoXLS" runat="server" CssClass="btn btn_grid2"><span>Excel</span></asp:LinkButton>
        </div>
    </form>
    <br />

<asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
        <thead>
            <tr>
                <th class="head1">ID Compra</th>
                <th class="head0">Fecha Compra</th>
                <th class="head0">CUIT</th>
                <th class="head0">Razón Social</th>
                <th class="head0">Subtotal</th>
                <th class="head0">IVA</th>
                <th class="head0">Total</th>
                <th class="head0">Cobrado</th>
                <th class="head0">Pendiente</th>
                
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idCompraCabe")%></td>
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fecha"), Date).ToShortDateString()%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cuit")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "razonSocial")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "subtotal")%></td>
                <td><%# DataBinder.Eval(Container.DataItem,"iva")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "saldado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "pendiente")%></td>
                
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">ID Compra</th>
                <th class="head0">Fecha Compra</th>
                <th class="head0">CUIT</th>
                <th class="head0">Razón Social</th>
                <th class="head0">Subtotal</th>
                <th class="head0">IVA</th>
                <th class="head0">Total</th>
                <th class="head0">Cobrado</th>
                <th class="head0">Pendiente</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
