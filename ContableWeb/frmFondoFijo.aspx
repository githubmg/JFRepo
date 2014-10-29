<%@ Page Title="Fondo Fijo" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFondoFijo.aspx.vb" Inherits="ContableWeb.frmFondoFijo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Fondo Fijo</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
    <form runat="server" id="frmEjercicio" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Fondo Fijo" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Fondos Fijos existentes</span></h2>
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
                <th class="head0">Fecha</th>
                <th class="head0">Observaciones</th>
                <th class="head0">Monto</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idFondoFijo")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Observaciones")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "monto")%></td>
                <td><a href="frmFondoFijoEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idFondoFijo")%>">Editar</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Observaciones</th>
                <th class="head0">Monto</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
