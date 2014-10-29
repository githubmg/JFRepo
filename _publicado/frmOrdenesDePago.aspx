<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmOrdenesDePago.aspx.vb" Inherits="ContableWeb.frmOrdenesDePago" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    <asp:Label ID="lblProveedor" runat="server" Text="Label" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<%--<script language="JavaScript" type="text/JavaScript">
window.onload=function resize(){
var viewer = document.getElementById("<%=ReportViewer1.ClientID %>");
var htmlheight = document.documentElement.clientHeight;
viewer.style.height = (htmlheight - 120) + "px";
}
</script>--%>
<script language="javascript" type="text/javascript">
    window.onload = function lalal() {
        var iframes = document.getElementsByTagName("IFRAME");
        for (var i = 0, ln = iframes.length; i < ln; i++) {
            iframes[0].parentNode.removeChild(iframes[0]);
        }
    }
</script>
    <form id="frmCtaCteProveedor" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        
        <asp:Button ID="cmdNuevo" runat="server" Text="Nueva Orden de Pago" CssClass="stdbtn" /><br /><br />
      
        <label>Desde:</label>
        <span class="field"><asp:TextBox ID="txtFechaDesde" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaDesdeExt" TargetControlID="txtFechaDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

        <label>Hasta:</label>
        <span class="field"><asp:TextBox ID="txtFechaHasta" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaHastaExt" TargetControlID="txtFechaHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerCtaCte" runat="server" Text="Ver OP" CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Órdenes de Pago</span></h2>
    </div>
    <br />
    <div id="divExportacion" runat="server" visible="false">
        <asp:LinkButton ID="lnkExpoPDF" runat="server" CssClass="btn btn_pdf"  ><span>PDF</span></asp:LinkButton>
        <asp:LinkButton ID="lnkExpoXLS" runat="server" CssClass="btn btn_grid2"><span>Excel</span></asp:LinkButton>
    </div>
<%--    <rsweb:ReportViewer ID="ReportViewer1" runat="server"
        ProcessingMode="Local" Width="100%"
        AsyncRendering="false" 
        SizeToReportContent="true"
        ShowExportControls="true" 
        ShowFindControls="false"
        ShowRefreshButton="false">
        <LocalReport ReportPath="reportes\reporteCtaCteProveedor.rdlc"></LocalReport>
    </rsweb:ReportViewer>--%>

    </form>
    <br />

    <asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
        <thead>
            <tr>
                <th class="head0">Orden de Pago</th>
                <th class="head1">Fecha</th>
                <th class="head1">Importe</th>
                <th class="head1">Acción</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "ordenPago")%></td>
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fechaPago"), Date).ToShortDateString()%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "importe")%></td>
                <td><a target="_blank" href="frmImprimirComprobante.aspx?tipo=OP&id=<%#DataBinder.Eval(Container.DataItem, "ordenPago")%>">Ver Orden de Pago</a> &nbsp;-&nbsp;
                    <a target="_blank" href="frmImprimirComprobante.aspx?tipo=RET&id=<%#DataBinder.Eval(Container.DataItem, "ordenPago")%>">Ver Retenciones</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head0">Orden de Pago</th>
                <th class="head1">Fecha</th>
                <th class="head1">Importe</th>
                <th class="head1">Acción</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
   
</asp:Content>
