<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmUsuario.aspx.vb" Inherits="ContableWeb.frmUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmUsuario" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Usuario" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Usuarios existentes</span></h2>
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
                <th class="head0">Nombre de Usuario</th>
               
                <th class="head0">Nombre</th>
                <th class="head0">Email</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "idUsuario")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "nombreUsuario")%></td>
                
                <td><%#DataBinder.Eval(Container.DataItem, "nombre")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "email")%></td>
                <td><a href="frmUsuarioEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idUsuario")%>">Editar</a>&nbsp;-&nbsp;
                 <asp:LinkButton id="lnkDelete" CommandName="Borrar"  CommandArgument='<%#DataBinder.Eval(Container.DataItem, "idUsuario")%>' runat="server">Borrar</asp:LinkButton>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                 <th class="head1">Id</th>
                <th class="head0">Nombre de Usuario</th>
                
                <th class="head0">Nombre</th>
                <th class="head0">Email</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
