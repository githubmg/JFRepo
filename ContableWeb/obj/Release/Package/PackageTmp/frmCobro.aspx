<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmCobro.aspx.vb" Inherits="ContableWeb.frmCobro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Cobros
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmCobro" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Cobro" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Cobros</span></h2>
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
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Medio de Pago</th>
                <th class="head0">Importe</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idCobro")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "medioPago")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "importe")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha</th>
                <th class="head0">Medio de Pago</th>
                <th class="head0">Importe</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
