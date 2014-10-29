<%@ Page Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmPagoProveedor.aspx.vb" Inherits="ContableWeb.frmPagoProveedor" 
    title="Pagos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    <asp:Label ID="lblProveedor" runat="server" Text="Label"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<div class="contenttitle"><h2 class="form"><span>Realizar orden de pago</span></h2></div>
<br />
<form runat="server" id="frmComprobanteProveedor" class="stdform" action="" method="post">
<div runat="server" id="codigo"></div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Copmprobantes</a></li>
            <li><a href="#tabs-2">Impuestos</a></li>
            <li><a href="#tabs-3">Valores</a></li>
            <li><a href="#tabs-4">Adelantos</a></li>
        </ul>
        <div id="tabs-1">
            <div class="contenttitle"><h2 class="form"><span>Comprobantes pendientes de pago</span></h2></div>
            <asp:Repeater ID="grillaComprobantes" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head0">&nbsp;</th>
                                <th class="head1">Id</th>
                                <th class="head0">Tipo</th>
                                <th class="head0">Numero</th>
                                <th class="head0">Subtotal</th>
                                <th class="head0">Iva</th>
                                <th class="head0">Total</th>

                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><asp:LinkButton id="lnkSelect" CommandName="Seleccionar" runat="server">Seleccionar</asp:LinkButton></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "idComprobante")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "TipoComprobante.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Numero")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Subtotal")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MontoIva")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <div class="contenttitle"><h2 class="form"><span>Comprobantes a pagar</span></h2></div>
            <asp:Repeater ID="grillaComprobantesSeleccionados" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head0">&nbsp;</th>
                                <th class="head1">Id</th>
                                <th class="head0">Tipo</th>
                                <th class="head0">Numero</th>
                                <th class="head0">Subtotal</th>
                                <th class="head0">Iva</th>
                                <th class="head0">Total</th>

                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><asp:LinkButton id="lnkQuitar" CommandName="Quitar" runat="server">Quitar</asp:LinkButton></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "idComprobante")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "TipoComprobante.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Numero")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Subtotal")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MontoIva")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater><br />
            <div runat="server" id="divErrorComprobantes" class="notification msgerror" visible ="false" ><a class="close"></a>
                <p><asp:Label ID="lblErrorComprobantes" runat="server" Text=""></asp:Label></p>
            </div>
            
        </div>
        <div id="tabs-2">
            <div class="contenttitle"><h2 class="form"><span>Retenciones</span></h2></div>
            <label>Retencion</label><span class="field"><asp:DropDownList ID="cmbRetencion" runat="server" AutoPostBack="true" /></span>    
            <label>Concepto</label><span class="field"><asp:DropDownList ID="cmbConceptoRetencion" runat="server" /></span>    
            <label>Importe</label><span class="field"><asp:TextBox ID="txtImpoteRetencion" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
            <p class="stdformbutton">
                <asp:Button ID="cmdAgregarRetencion" runat="server" Text="Agregar" CssClass="accept" />
            </p>
            <div runat="server" id="divErrorRetenciones" class="notification msgerror" visible ="false" ><a class="close"></a>
                <p><asp:Label ID="lblErrorRetenciones" runat="server" Text=""></asp:Label></p>
            </div>
            <div class="contenttitle"><h2 class="form"><span>Retenciones cargadas</span></h2></div>
            <asp:Repeater ID="GrillaRetenciones" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head0">&nbsp;</th>
                                <th class="head1">Retención</th>
                                <th class="head1">Concepto</th>
                                <th class="head0">Importe</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><asp:LinkButton id="lnkQuitar" CommandName="Quitar" runat="server">Quitar</asp:LinkButton></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Retencion.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "ConceptoRetencion.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Importe")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
        </div>
        <div id="tabs-3">
            <div class="contenttitle"><h2 class="form"><span>Valores</span></h2></div>
            <br />
            <h4>Monto</h4>
            <label>Forma de pago</label><span class="field"><asp:DropDownList ID="cmbFormaPago" runat="server" AutoPostBack="true" /></span>
            <label>Importe</label><span class="field"><asp:TextBox ID="txtImporteValor" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
            
            
            <div id="divBanco" runat="server" visible="false">
                <h4>Banco</h4>
                <label>Banco</label><span class="field"><asp:DropDownList ID="cmbBanco" runat="server" /></span>    
            </div>
            
            <div id="divCheque" runat="server" visible="false">
                <h4>Datos del cheque</h4>
                <label>Sucursal</label><span class="field"><asp:TextBox ID="txtChequeSucursal" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
                <label>Número de cheque</label><span class="field"><asp:TextBox ID="txtChequeNumero" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
                <label>Fecha de Cobro</label><span class="field"><asp:TextBox ID="txtChequeFechaCobro" runat="server" MaxLength = "10" CssClass="smallinput" /></span>                
                <asp:CalendarExtender ID="txtChequeFechaCobroExt" TargetControlID="txtChequeFechaCobro" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

            </div>
            
            <div id="divInterdeposito" runat="server" visible="false">
                <h4>Interdeposito</h4>
                <label>Fecha</label><span class="field"><asp:TextBox ID="txtInterdepositoFecha" runat="server" MaxLength = "10" CssClass="smallinput" /></span>                
                <asp:CalendarExtender ID="txtInterdepositoFechaExt" TargetControlID="txtInterdepositoFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
                <label>Tipo</label><span class="field"><asp:DropDownList ID="cmbTipoInterdeposito" runat="server" /></span>    
                <label>Boleta</label><span class="field"><asp:TextBox ID="txtInterdepositoBoleta" runat="server" MaxLength = "10" CssClass="smallinput" /></span>                
                <label>Terminal</label><span class="field"><asp:TextBox ID="txtInterdepositoTerminalBancaria" runat="server" MaxLength = "10" CssClass="smallinput" /></span>                
            </div>
            
            <div id="divTarjeta" runat="server" visible="false">
                <h4>Tarjeta</h4>
                <label>Número de tarjeta</label><span class="field"><asp:TextBox ID="txtTarjetaNumero" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
                <label>Cupón</label><span class="field"><asp:TextBox ID="txtTarjetaCupon" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
                <label>Autorización</label><span class="field"><asp:TextBox ID="txtTarjetaAutorizacion" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
                <label>Cuotas</label><span class="field"><asp:TextBox ID="txtTarjetaCuotas" runat="server" MaxLength = "10" CssClass="smallinput" /></span>
            </div>
            <br />
            <p class="stdformbutton">
                <asp:Button ID="cmdAgregarValor" runat="server" Text="Agregar" CssClass="accept" />
            </p>
            <br />         
            <div class="contenttitle"><h2 class="form"><span>Valores cargados</span></h2></div>
            <asp:Repeater ID="grillaValores" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head1">Forma de Pago</th>
                                <th class="head0">Importe</th>
                                <th class="head0">Acción</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><%#DataBinder.Eval(Container.DataItem, "FormaPago.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "ImportePesos")%></td>
                        <td><asp:LinkButton id="lnkQuitar" CommandName="Quitar" runat="server">Quitar</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            

            <div runat="server" id="divErrorValores" class="notification msgerror" visible ="false" ><a class="close"></a>
                <p><asp:Label ID="lblErrorValores" runat="server" Text=""></asp:Label></p>
            </div>
            <br />
    </div>
        <div id="tabs-4">
            <div class="contenttitle"><h2 class="form"><span>Adelantos no utilizados</span></h2></div>
            <asp:Repeater ID="GrillaAdelantos" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head0">&nbsp;</th>
                                <th class="head1">Id</th>
                                <th class="head0">Tipo</th>
                                <th class="head0">Numero</th>
                                <th class="head0">Subtotal</th>
                                <th class="head0">Iva</th>
                                <th class="head0">Total</th>

                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><asp:LinkButton id="lnkSelect" CommandName="Seleccionar" runat="server">Seleccionar</asp:LinkButton></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "idComprobante")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "TipoComprobante.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Numero")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Subtotal")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MontoIva")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <div class="contenttitle"><h2 class="form"><span>Adelantos a utilizar</span></h2></div>
            <asp:Repeater ID="GrillaAdelantosSeleccionados" runat="server" >
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                        <thead>
                            <tr>
                                <th class="head0">&nbsp;</th>
                                <th class="head1">Id</th>
                                <th class="head0">Tipo</th>
                                <th class="head0">Numero</th>
                                <th class="head0">Subtotal</th>
                                <th class="head0">Iva</th>
                                <th class="head0">Total</th>

                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="">
                        <td><asp:LinkButton id="lnkQuitar" CommandName="Quitar" runat="server">Quitar</asp:LinkButton></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "idComprobante")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "TipoComprobante.Descripcion")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Numero")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Subtotal")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MontoIva")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Total")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater><br />
            <div runat="server" id="divErrorAdelantos" class="notification msgerror" visible ="false" ><a class="close"></a>
                <p><asp:Label ID="lblErrorAdelantos" runat="server" Text=""></asp:Label></p>
            </div>       
        </div>
    </div>
    <br />
    <div class="notification msginfo">
        <a class="close"></a>
        <p>
        <strong>Total de comprobantes: </strong><asp:Label ID="lblTotalComprobantes" runat="server" Text=""></asp:Label><br />
        <strong>Total de retenciones: </strong><asp:Label ID="lblTotalRetenciones" runat="server" Text=""></asp:Label><br />
        <strong>Total de valores: </strong><asp:Label ID="lblTotalValores" runat="server" Text=""></asp:Label><br />
        <strong>Total de adelantos: </strong><asp:Label ID="lblTotalAdelantos" runat="server" Text=""></asp:Label><br />
        <strong>Faltante: </strong><asp:Label ID="lblFaltante" runat="server" Text=""></asp:Label><br />
        </p>
    </div>    <br />
    
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>
</form>
</asp:Content>
