<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="ReporteValoresCedidos.aspx.vb" Inherits="ContableWeb.ReporteValoresCedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Valores Cedidos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <form id="frmReporteValores" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
      
        <label>Desde:</label>
        <span class="field"><asp:TextBox ID="txtFechaDesde" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaDesdeExt" TargetControlID="txtFechaDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

        <label>Hasta:</label>
        <span class="field"><asp:TextBox ID="txtFechaHasta" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaHastaExt" TargetControlID="txtFechaHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerValores" runat="server" Text="Ver Valores" CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>Valores Cedidos</span></h2>
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
                <th class="head1">Número de Cheque</th>
                <th class="head0">Banco</th>
                <th class="head0">Origen</th>
                <th class="head0">Cliente</th>
                <th class="head0">Monto</th>
                <th class="head0">Fecha de Emisión</th>
                <th class="head0">Fecha de Vencimiento</th>
                <th class="head0">Días restantes</th>
            
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "numero")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "banco")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "origenCheque")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cliente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "importe")%></td>
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fechaEmision"), Date).ToShortDateString()%></td>
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fechaVencimiento"), Date).ToShortDateString()%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "diasRestantes")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
              <th class="head1">Número de Cheque</th>
                <th class="head0">Banco</th>
                <th class="head0">Origen</th>
                <th class="head0">Cliente</th>
                <th class="head0">Monto</th>
                <th class="head0">Fecha de Emisión</th>
                <th class="head0">Fecha de Vencimiento</th>
                <th class="head0">Días restantes</th>
                
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
