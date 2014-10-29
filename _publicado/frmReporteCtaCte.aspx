<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmReporteCtaCte.aspx.vb" Inherits="ContableWeb.frmReporteCtaCte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Label" />
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
    <form id="frmCtaCteSocio" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
      
        <label>Desde:</label>
        <span class="field"><asp:TextBox ID="txtFechaDesde" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaDesdeExt" TargetControlID="txtFechaDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

        <label>Hasta:</label>
        <span class="field"><asp:TextBox ID="txtFechaHasta" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaHastaExt" TargetControlID="txtFechaHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerCtaCte" runat="server" Text="Ver Cta. Cte." CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>Cuenta Corriente</span></h2>
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
                <th class="head1">Fecha</th>
                <th class="head0">Tipo</th>
                <th class="head1">Nro Comp</th>
                <th class="head1">Observaciones</th>
                <th class="head0">Neto Gravado</th>
                <th class="head1">IVA</th>
                <th class="head0">Total</th>
                <th class="head0">Acumulado</th>
                
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fechaEmision"), Date).ToShortDateString()%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "sigla")%></td>
                <td><a href="#"><%#DataBinder.Eval(Container.DataItem, "numeroComprobante")%></a></td>
                <td><%#DataBinder.Eval(Container.DataItem, "ObservacionesComprobante")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "netoGravado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Iva")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Acumulado")%></td>
                
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Fecha</th>
                <th class="head0">Tipo</th>
                <th class="head1">Nro Comp</th>
                <th class="head1">Observaciones</th>
                <th class="head0">Neto Gravado</th>
                <th class="head1">IVA</th>
                <th class="head0">Total</th>
                <th class="head0">Acumulado</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
   
</asp:Content>
