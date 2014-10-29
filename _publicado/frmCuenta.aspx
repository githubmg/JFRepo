<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmCuenta.aspx.vb" Inherits="ContableWeb.frmCuenta" 
    title="Cuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Cuentas</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

   <form runat="server" id="frmCuenta" class="">
   <asp:Button ID="cmdNuevaCuenta" runat="server" Text="Nueva Cuenta" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Cuentas existentes</span></h2>
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
                <th class="head1">Codigo</th>
                <th class="head0">Descripción</th>
                <th class="head0">Tipo de cuenta</th>
                <th class="head0">Centro de Costos</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "codigo")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "descripcionTabulada")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "tipoCuenta")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "centroCostos")%></td>
                <td><a href="frmCuentaEdit.aspx?codigo=<%#DataBinder.Eval(Container.DataItem, "codigo")%>">Editar</a></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Codigo</th>
                <th class="head0">Descripción</th>
                <th class="head0">Tipo de cuenta</th>
                <th class="head0">Centro de Costos</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
