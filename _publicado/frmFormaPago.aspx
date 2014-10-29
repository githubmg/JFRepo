<%@ Page Title="Formas de Pago" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFormaPago.aspx.vb" Inherits="ContableWeb.frmFormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Formas de pago</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
    <form runat="server" id="frmFormaPago" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nueva Forma de Pago" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Formas de Pago existentes</span></h2>
    </div><!--contenttitle-->
   <asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
        <colgroup>
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Descripcion</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idFormaPago")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "descripcion")%></td>
                <td><a href="frmFormaPagoEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idFormaPago")%>">Editar</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Descripcion</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
