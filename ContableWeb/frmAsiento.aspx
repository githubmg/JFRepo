<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmAsiento.aspx.vb" Inherits="ContableWeb.frmAsiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Asientos</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

   <form runat="server" id="frmAsiento" class="">
    <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Asiento" CssClass="stdbtn" />
    <span class="stdform field"><asp:DropDownList ID="cmbAsientoTipo" runat="server"></asp:DropDownList></span>
    <br /><br />
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Asientos</span></h2>
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
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">fecha</th>
                <th class="head0">Tipo de comprobante</th>
                <th class="head0">Numero de comprobante</th>
                <th class="head0">concepto</th>
                <th class="head0">Debe</th>
                <th class="head0">Haber</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idAsiento")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fecha", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "TipoComprobante")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "numeroComprobante")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "concepto")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Debe")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Haber")%></td>
                <td><a href="frmAsientoEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idAsiento")%>">Editar</a></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">fecha</th>
                <th class="head0">Tipo de comprobante</th>
                <th class="head0">Numero de comprobante</th>
                <th class="head0">concepto</th>
                <th class="head0">Debe</th>
                <th class="head0">Haber</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
