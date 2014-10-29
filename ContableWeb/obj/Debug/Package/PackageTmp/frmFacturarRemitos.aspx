<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFacturarRemitos.aspx.vb" Inherits="ContableWeb.frmFacturarRemitos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Facturar Remitos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Factura</span></h2></div>
    <br />
    <form runat="server" id="frmFactura" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        <label>Observaciones</label>
        <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput"></asp:TextBox></span>
        </p>
        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Remitos a Facturar</span></h2></div>
            <div class="widgetcontent">
                <p>
                    <label>Remito</label>
                    <span class="field"><asp:TextBox ID="txtRemito" runat="server" CssClass="longinput"></asp:TextBox>&nbsp;</span>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                    TargetControlID="txtRemito"   
                    ServiceMethod="VistaRemitoSinFacturar"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
                    <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" CssClass="accept" ValidationGroup="Items" />
                            
                </p>
                <div runat="server" id="divErrorItem" class="notification msgerror" visible ="false" ><a class="close"></a>
                    <p><asp:Label ID="lblErrorItem" runat="server" Text=""></asp:Label></p>
                </div>
                        <asp:Repeater ID="grilla" runat="server" >
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
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
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th class="head1">Nro. Remito</th>
                                        <th class="head0">Fecha de Pedido</th>
                                        <th class="head0">Cliente</th>
                                        <th class="head0">Orden</th>                
                                        <th class="head0">Estado</th>                
                                        <th class="head0">Chasis</th>                
                                        <th class="head0">Pendiente</th>                
                                        <th class="head0">Total</th>                
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
                                <td><%#DataBinder.Eval(Container.DataItem, "pendiente")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "total")%></td>
                                <td>
                                <asp:LinkButton id="lnkDelete" CommandName="Borrar" runat="server">Borrar</asp:LinkButton>
                            </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                
            </div><!--widgetcontent-->
        </div>
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Volver" CssClass="reset" />
        </p>
    </form>
</asp:Content>
