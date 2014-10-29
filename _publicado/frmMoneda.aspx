<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMoneda.aspx.vb" Inherits="ContableWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Monedas</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmMoneda" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nueva Moneda" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Monedas existentes</span></h2>
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
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Descripcion</th>
                <th class="head0">Abreviatura</th>
                <th class="head0">Simbolo</th>
                <th class="head0">Cotizacion</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idMoneda")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "descripcion")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "abreviatura")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "simbolo")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cotizacion")%></td>
                <td><a href="frmMonedaEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idMoneda")%>">Editar</a>&nbsp;-&nbsp;
                    <a href="frmCotizacion.aspx?idMoneda=<%#DataBinder.Eval(Container.DataItem, "idMoneda")%>">Cotizaciones</a>
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
