<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmCotizacion.aspx.vb" Inherits="ContableWeb.frmCotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Cotizaciones</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

    <div class="contenttitle radiusbottom0">
        <h2 class="table"><span>Cotizaciones</span></h2>
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
                <th class="head0">Fecha</th>
                <th class="head0">Cotizacion</th>
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idCotizacion")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Fecha")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "cotizacion")%></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
   </asp:Repeater>
<form runat="server" id="frmCotizacion" class="stdform" >
   <br /><br />
    <h4>Nueva cotización</h4>
    <label>Cotización</label><span class="field"><asp:TextBox ID="txtCotizacion" runat="server" CssClass="mediuminput" MaxLength="10"></asp:TextBox></span>
    <br />
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept"/>
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>   
   
   </form>
</asp:Content>
