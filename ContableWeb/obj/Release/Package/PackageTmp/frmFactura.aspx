<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFactura.aspx.vb" Inherits="ContableWeb.frmFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Facturas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmRemito" class="">
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>FACTURAS</span></h2>
    </div><!--contenttitle-->
   <asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
        <colgroup>
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Nro. Factura</th>
                <th class="head0">Fecha</th>
                <th class="head0">Cliente</th>
                <th class="head0">Total</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idFactura")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cliente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                <td>
                 <a target="_blank" href="frmViewer.aspx?tipo=FA&id=<%#DataBinder.Eval(Container.DataItem, "idFactura")%>">Ver factura</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Nro. Factura</th>
                <th class="head0">Fecha</th>
                <th class="head0">Cliente</th>
                <th class="head0">Total</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>

   </form>
</asp:Content>