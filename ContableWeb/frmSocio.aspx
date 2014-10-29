<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmSocio.aspx.vb" Inherits="ContableWeb.frmSocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Socios</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
    <form runat="server" id="frmSocio" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Socio" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Socios existentes</span></h2>
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
                <th class="head0">Nombre</th>
                <th class="head0">Federacion</th>
                <th class="head0">Pertenece a</th>
                <th class="head0">Tipo Doc</th>
                <th class="head0">Documento</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idSocio")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "nombre")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "federacion")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "perteneceA")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "tipoDocumento")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "numeroDocumento")%></td>
                <td><a href="frmSocioEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idSocio")%>">Editar</a>&nbsp;-&nbsp;
                    <a href="frmPagoSocio.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idSocio")%>">Pagos</a>&nbsp;-&nbsp;
                    <a href="frmReporteCtaCte.aspx?idSocio=<%#DataBinder.Eval(Container.DataItem, "idSocio")%>">Cta. Cte.</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Nombre</th>
                <th class="head0">Federacion</th>
                <th class="head0">Pertenece a</th>
                <th class="head0">Tipo Doc</th>
                <th class="head0">Documento</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
