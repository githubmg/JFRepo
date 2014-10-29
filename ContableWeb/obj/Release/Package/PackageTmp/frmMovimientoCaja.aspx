<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMovimientoCaja.aspx.vb" Inherits="ContableWeb.frmMovimientoCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Movimientos de Caja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmMovimientoCaja" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Movimiento de Caja" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Movimientos de Caja</span></h2>
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
                <th class="head1">Id</th>
                <th class="head0">Tipo de Movimiento</th>
                <th class="head0">Fecha</th>
                <th class="head0">Medio de Pago</th>
                <th class="head0">Monto</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idMovimientoCaja")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "tipoMovimiento")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "medioPago")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "monto")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Tipo de Movimiento</th>
                <th class="head0">Fecha</th>
                <th class="head0">Medio de Pago</th>
                <th class="head0">Monto</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
