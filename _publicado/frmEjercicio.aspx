<%@ Page Title="Ejercicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmEjercicio.aspx.vb" Inherits="ContableWeb.frmEjercicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Ejercicios</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
    <form runat="server" id="frmEjercicio" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Ejercicio" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Ejercicios existentes</span></h2>
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
                <th class="head0">Fecha Inicio</th>
                <th class="head0">Fecha Fin</th>
                <th class="head0">Activo</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idEjercicio")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fechaInicio","{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fechaFin","{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Activo")%></td>
                <td><a href="frmEjercicioEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idEjercicio")%>">Editar</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Fecha Inicio</th>
                <th class="head0">Fecha Fin</th>
                <th class="head0">Activo</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
