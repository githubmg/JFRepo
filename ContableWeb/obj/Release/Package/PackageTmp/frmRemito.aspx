<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmRemito.aspx.vb" Inherits="ContableWeb.frmRemito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Remitos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmRemito" class="">
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Remitos</span></h2>
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
            <col class="con0" />
            <col class="con0" />
        </colgroup>
        <thead>
            <tr>
                <th class="head1">Nro. Remito</th>
                <th class="head0">Fecha</th>
                <th class="head0">Cliente</th>
                <th class="head0">Orden</th>
                <th class="head0">Estado</th>
                <th class="head0">Chasis</th>
                <th class="head0">Nº Factura</th>
                <th class="head0">Pendiente de Saldar</th>
                <th class="head0">Total</th>
                <th class="head0">Facturar</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idRemito")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "fechaPedido", "{0:dd/MM/yyyy}")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cliente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "orden")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "estado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "chasis")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "factura")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "pendiente")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                <td>
                    <asp:CheckBox ID="chkFacturar" runat="server" />
                    <asp:HiddenField ID="hfID" runat="server" Value ='<%#DataBinder.Eval(Container.DataItem, "idRemito")%>' />
                </td>
                <td>
                 <a target="_blank" href="frmViewer.aspx?tipo=RE&id=<%#DataBinder.Eval(Container.DataItem, "idRemito")%>">Ver Remito</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
               <th class="head1">Nro. Remito</th>
                <th class="head0">Fecha</th>
                <th class="head0">Cliente</th>
                <th class="head0">Orden</th>
                <th class="head0">Estado</th>
                <th class="head0">Chasis</th>
                <th class="head0">Nº Factura</th>
                <th class="head0">Pendiente de Saldar</th>
                <th class="head0">Total</th>
                <th class="head0">Facturar</th>
                <th class="head0">&nbsp;</th>
            </tr>
            </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
       <asp:Button ID="cmdGenerarFactura" runat="server" Text="Generar Factura" CssClass="stdbtn" />
     </p>
   </form>
</asp:Content>
