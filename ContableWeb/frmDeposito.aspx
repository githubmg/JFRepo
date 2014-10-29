<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmDeposito.aspx.vb" Inherits="ContableWeb.frmDeposito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Depósitos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmBanco" class="">
 <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Depósito" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Depósitos</span></h2>
    </div><!--contenttitle-->
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
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Banco</th>
                <th class="head0">Nro. Transacción</th>
                <th class="head0">Cheque</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idDeposito")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "banco")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "numeroTransaccion")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "cheque")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
