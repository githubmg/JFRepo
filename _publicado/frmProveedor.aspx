<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmProveedor.aspx.vb" Inherits="ContableWeb.frmProveedor" 
    title="Sistema Contable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Proveedores</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<form runat="server" id="frmProveedor" class="">
   <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo Proveedor" CssClass="stdbtn" /><br /><br />
    
    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Proveedores existentes</span></h2>
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
                <th class="head0">Razon Social</th>
                <th class="head0">Rubro</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idProveedor")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "razonSocial")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "rubro")%></td>
                <td>
                    <a href="frmProveedorEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Editar</a>&nbsp;-&nbsp;
                    <a href="frmComprobanteProveedor.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Comprobantes</a>&nbsp;-&nbsp;
                    <a href="frmComprobanteProveedor.aspx?accion=RINT&id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Reintegros</a>&nbsp;-&nbsp;
                    <a href="frmComprobanteProveedor.aspx?accion=ADEL&id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Adelantos</a>&nbsp;-&nbsp;
                    <a href="frmOrdenesDePago.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Ordenes de Pagos</a>&nbsp;-&nbsp;
                    <a href="frmCtaCteProveedor.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idProveedor")%>">Cta. Cte.</a>
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1">Id</th>
                <th class="head0">Razon Social</th>
                <th class="head0">Rubro</th>
                <th class="head0">&nbsp;</th>
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
   </asp:Repeater>
   </form>
</asp:Content>
