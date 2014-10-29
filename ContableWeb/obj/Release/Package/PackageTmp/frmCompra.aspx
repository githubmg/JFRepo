<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmCompra.aspx.vb" Inherits="ContableWeb.frmCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmCompra" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nueva Compra" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Compras</span></h2>
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
                <th class="head1">Id</th>
                <th class="head0">Proveedor</th>
                <th class="head0">Fecha</th>
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
                <td><%#DataBinder.Eval(Container.DataItem, "idCompraCabe")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "proveedor")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fechaCompra", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "estado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "pendiente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "tipoOrden")%></td>
                <td><a href="frmCompraEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idCompraCabe")%>">Editar</a></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Proveedor</th>
                <th class="head0">Fecha de Compra</th>
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
