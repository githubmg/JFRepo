<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmKit.aspx.vb" Inherits="ContableWeb.frmKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Kits Existentes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmCompra" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Kit" CssClass="stdbtn" />
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Compras</span></h2>
    </div><!--contenttitle-->
   <asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
        <colgroup>
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
            <col class="con0" />
           </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Producto Principal</th>
                <th class="head0">Descripción</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idKit")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "productoPrincipal")%></td>
             
                <td><%# DataBinder.Eval(Container.DataItem, "descripcion")%></td>
             
                <td><a href="frmKitEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idKit")%>">Editar</a></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
               <th class="head1">Id</th>
                <th class="head0">Producto Principal</th>
                <th class="head0">Descripción</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
