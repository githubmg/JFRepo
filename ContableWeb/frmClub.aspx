<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmClub.aspx.vb" Inherits="ContableWeb.frmClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Clubes</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmClub" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Club" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Clubes existentes</span></h2>
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
                <td><%#DataBinder.Eval(Container.DataItem, "idClub")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "descripcion")%></td>
                <td><a href="frmClubEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idClub")%>">Editar</a>&nbsp;-&nbsp;
                    <a href="frmReporteCtaCte.aspx?idClub=<%#DataBinder.Eval(Container.DataItem, "idClub")%>">Cta. Cte.</a>
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
