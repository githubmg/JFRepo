<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMovimientoStock.aspx.vb" Inherits="ContableWeb.frmMovimientoStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Movimiento de Stock
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmMovimientoStock" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Movimiento de Stock" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Movimientos existentes</span></h2>
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
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head0">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Tipo de Movimiento</th>
                <th class="head0">Familia</th>
                <th class="head0">Producto</th>
                <th class="head0">Cantidad</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idMovimientoStock")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "fecha")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "tipoMovimiento")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "familia")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "producto")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cantidad")%></td>
                <td>
                   <a href="frmMovimientoStockEdit.aspx?idMovimientoStock=<%#DataBinder.Eval(Container.DataItem, "idMovimientoStock")%>">Editar</a>&nbsp;-&nbsp;               
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
             <tr>
                <th class="head0">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Tipo de Movimiento</th>
                <th class="head0">Familia</th>
                <th class="head0">Producto</th>
                <th class="head0">Cantidad</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
