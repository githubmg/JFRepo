<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmComprobante.aspx.vb" Inherits="ContableWeb.frmComprobante" 
    title="Carga de comprobante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Emisión de comprobantes</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<div class="contenttitle"><h2 class="form"><span>Carga de comprobante</span></h2></div>
<br />
<form runat="server" id="frmComprobanteProveedor" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>

    <label>Tipo de comprobante</label>
    <span class="field"><asp:DropDownList ID="cmbTipoComprobante" runat="server" AutoPostBack="true" /></span>
    <label>Comprobante</label>
    <span class="field">
        <asp:TextBox ID="txtPuntoVenta" ReadOnly="true" runat="server" CssClass="smallinput" Width="40px" MaxLength="4"></asp:TextBox>
        &nbsp;-&nbsp;
        <asp:TextBox ID="txtNumeroFactura" ReadOnly="true" runat="server" CssClass="smallinput" Width="100px" MaxLength="8"></asp:TextBox>
    </span>
 
    <label>Fecha de emision</label>
    <span class="field"><asp:TextBox ID="txtFechaComprobante" runat="server" CssClass="smallinput"></asp:TextBox></span>
    <asp:CalendarExtender ID="txtFechaComprobanteExt" TargetControlID="txtFechaComprobante" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
 
    <label>Fecha de vencimiento</label>
    <span class="field"><asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="smallinput"></asp:TextBox></span>
    <asp:CalendarExtender ID="txtFechaVencimientoExt" TargetControlID="txtFechaVencimiento" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

    <label>Fecha de Servicios Desde</label>
    <span class="field"><asp:TextBox ID="txtFechaserviciosDesde" runat="server" CssClass="smallinput"></asp:TextBox></span>
    <asp:CalendarExtender ID="txtFechaserviciosDesdeExt" TargetControlID="txtFechaserviciosDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

    <label>Fecha de serviciosHasta</label>
    <span class="field"><asp:TextBox ID="txtFechaserviciosHasta" runat="server" CssClass="smallinput"></asp:TextBox></span>
    <asp:CalendarExtender ID="txtFechaserviciosHastaExt" TargetControlID="txtFechaserviciosHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

    <label>Condición de pago</label>
    <span class="field"><asp:TextBox ID="txtCondicionPago" runat="server" CssClass="smallinput"></asp:TextBox></span>

    <label>Detalle</label>
    <span class="field"><asp:TextBox ID="txtDetalle" runat="server" CssClass="longinput" MaxLength="500"></asp:TextBox></span>

    <br />
    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmdAgregar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="grilla" EventName="ItemCommand" />
        </Triggers>
        <ContentTemplate>

        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Items del comprobante</span></h2></div>
            <div class="widgetcontent">
                <p>
                    <label>Descripción</label>
                    <span class="field"><asp:TextBox ID="txtDescripcionItem" runat="server" CssClass="longinput" MaxLength="100"></asp:TextBox></span>
                    <label>Comentario</label>
                    <span class="field"><asp:TextBox ID="txtComentarioItem" runat="server" CssClass="longinput" MaxLength="100"></asp:TextBox></span>

                    <label>Valor Unitario</label>
                    <span class="field"><asp:TextBox ID="txtPrecioUnitarioItem" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    <label>Cantidad</label>
                    <span class="field"><asp:TextBox ID="txtCantidadItem" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    <label>IVA</label>
                    <span class="field"><asp:TextBox ID="txtIVA" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    
                    <label>Porcentaje de descuento</label>
                    <span class="field"><asp:TextBox ID="txtDescuento" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    
                    <label>Motivo de descuento</label>
                    <span class="field"><asp:TextBox ID="txtMotivoDescuento" runat="server" CssClass="smallinput"></asp:TextBox></span>
                   
                    
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
                            </colgroup>
                            <thead>
                                <tr>
                                    <th class="head1">Descripcion</th>
                                    <th class="head0">Cantidad</th>
                                    <th class="head0">PU</th>
                                    <th class="head0">IVA</th>
                                    <th class="head0">Subtotal</th>
                                    <th class="head0">Total</th>
                                    <th class="head0">&nbsp;</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="">
                            <td><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Cantidad")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "PrecioUnitario")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "IVA")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Subtotal")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
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
    
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>
</form>
</asp:Content>
