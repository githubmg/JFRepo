<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmProducto.aspx.vb" Inherits="ContableWeb.frmProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <form runat="server" id="frmProducto" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Producto" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Productos existentes</span></h2>
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
                <th class="head0">idProducto</th>
                <th class="head0">Código de Producto</th>
                <th class="head0">Familia</th>
                <th class="head0">Descripcion</th>
                <th class="head0">Alícuota IVA</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idProducto")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "codProducto")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "familia")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "descripcion")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "alicuotaIva")%></td>
                <td><a href="frmProductoEdit.aspx?idProducto=<%#DataBinder.Eval(Container.DataItem, "idProducto")%>">Editar</a>&nbsp;
                  /&nbsp;  <asp:LinkButton id="lnkDelete" CommandName="Borrar"  CommandArgument='<%#DataBinder.Eval(Container.DataItem, "idProducto")%>' runat="server">Borrar</asp:LinkButton>
                <asp:HiddenField ID="hfID" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "idProducto")%>' />
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head0">idProducto</th>
                <th class="head0">Código de Producto</th>
                <th class="head0">Familia</th>
                <th class="head0">Descripción</th>
                <th class="head0">Alícuota IVA</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
