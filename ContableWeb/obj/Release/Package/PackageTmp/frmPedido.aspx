<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmPedido.aspx.vb" Inherits="ContableWeb.frmPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Pedidos</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <form runat="server" id="frmPedido" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Pedido" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Pedidos</span></h2>
    </div><!--contenttitle-->
     <br />
     <div id="divExportacion" runat="server" >
   
            <asp:LinkButton ID="lnkExpoXLS" runat="server" CssClass="btn btn_grid2"><span>Excel</span></asp:LinkButton>
     </div>
     <br />
   <asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
        <colgroup>
            <col class="con0" />
            <col class="con0" 
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha de Pedido</th>
                <th class="head0">Cliente</th>
                <th class="head0">Chasis</th>
                <th class="head0">Orden</th>
                <th class="head0">Estado</th>
                <th class="head0">Pendiente de Saldar</th>
                <th class="head0">Total</th>
                <th class="head0">Tipo</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idPedidoCabe")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fechaPedido", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "razonSocial")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "chasis")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "orden")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "estado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "pendiente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "tipoOrden")%></td>
                <td><a href="frmPedidoEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idPedidoCabe")%>">Editar</a></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha de Pedido</th>
                <th class="head0">Cliente</th>
                <th class="head0">Chasis</th>
                <th class="head0">Orden</th>
                <th class="head0">Estado</th>
                <th class="head0">Pendiente de Saldar</th>
                <th class="head0">Total</th>
                <th class="head0">Tipo</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
