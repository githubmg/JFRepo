<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmPagoEdit.aspx.vb" Inherits="ContableWeb.frmPagoEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del pago
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Pagos</span></h2></div>
    <br />
    <form runat="server" id="frmPedidoEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Fecha de pago</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        
        <label>Medio de pago</label>
        <span class="field"><asp:DropDownList ID="cmbMedioPago" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>

        <asp:UpdatePanel ID="pnlCheque" runat="server" Visible="False" >
        <ContentTemplate>
          <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Datos del Cheque</span></h2></div>
            <div class="widgetcontent">
                  <label>¿Es cheque en cartera? </label>
            <span class="field"><asp:DropDownList ID="cmbEsCartera" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>
            <%--<span class="field"><asp:CheckBox ID="chkCartera" runat="server" 
                AutoPostBack="True" /></span>--%>
            <asp:UpdatePanel ID="pnlChequeCartera" runat="server" Visible="False">
            <ContentTemplate>
                <label>Cheque</label>
                <span class="field"><asp:TextBox ID="txtChequeCartera" runat="server" CssClass="longinput"></asp:TextBox></span>
                 <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                    TargetControlID="txtChequeCartera"   
                    ServiceMethod="VistaChequeCartera"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
               
            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="pnlChequeComun" runat="server" Visible="False">
            <ContentTemplate>
            <label>Nro. de cheque</label>
            <span class="field"><asp:TextBox ID="txtNroCheque" runat="server" CssClass="longinput"></asp:TextBox></span>
            <label>Banco</label>
            <span class="field"><asp:DropDownList ID="cmbBanco" runat="server"></asp:DropDownList></span>
            <label>Fecha de emisión</label>
            <span class="field"><asp:TextBox ID="txtFechaEmision" runat="server" CssClass="longinput"></asp:TextBox></span>
            <label>Fecha de vencimiento</label>
            <span class="field"><asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="longinput"></asp:TextBox></span>
            <label>Origen</label>
            <span class="field"><asp:DropDownList ID="cmbOrigenCheque" runat="server"></asp:DropDownList></span>
            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFechaEmision" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
            <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFechaVencimiento" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
            </ContentTemplate>
            </asp:UpdatePanel>
                
            </div><!--widgetcontent-->
        </div>
        </ContentTemplate>
       </asp:UpdatePanel>
       
        <label>Importe</label>
        <span class="field"><asp:TextBox ID="txtImporte" runat="server" CssClass="smallinput"></asp:TextBox>&nbsp;&nbsp;(9999,99)</span>
        <label>Observaciones</label>
        <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput"></asp:TextBox></span>
        </p>
        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Compras Saldadas</span></h2></div>
            <div class="widgetcontent">
                <p>
                    <label>Compra</label>
                    <span class="field"><asp:TextBox ID="txtCompra" runat="server" CssClass="longinput"></asp:TextBox>&nbsp;</span>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                    TargetControlID="txtCompra"   
                    ServiceMethod="VistaCompraSinSaldar"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
                    <label>Monto cancelado</label>
                    <span class="field"> $ <asp:TextBox ID="txtMontoCancelado" runat="server" CssClass="smallinput"></asp:TextBox>&nbsp;</span>
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
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th class="head1">Proveedor</th>
                                        <th class="head0">Fecha</th>
                                        <th class="head0">Estado</th>
                                        <th class="head0">Monto Cancelado</th>                
                                        <th class="head0">&nbsp;</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="">
                                <td><%#DataBinder.Eval(Container.DataItem, "CompraCabe.Proveedor.RazonSocial")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "CompraCabe.FechaCompra", "{0:dd/MM/yyyy}")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "CompraCabe.EstadoPedido.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "MontoCancelado")%></td>
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
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
    </form>
</asp:Content>
