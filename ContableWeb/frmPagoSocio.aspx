<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmPagoSocio.aspx.vb" Inherits="ContableWeb.frmPagoSocio" 
    title="Pago de cuotas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    <asp:Label ID="lblSocio" runat="server" Text="Socio"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">

<form runat="server" id="frmPagoSocio" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div runat="server" id="codigo"></div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Cuotas</a></li>
            <li><a href="#tabs-2">Multas</a></li>
            <li><a href="#tabs-3">Formas de Pago</a></li>
        </ul>
        <div id="tabs-1">
            <div class="contenttitle"><h2 class="form"><span>Registrar pago de cuota</span></h2></div>
            <br />
            <label>Concepto</label>            <span class="field"><asp:DropDownList ID="cmbConceptoCuota" runat="server" AutoPostBack="true"></asp:DropDownList></span>            <label>Año</label><span class="field"><asp:TextBox ID="txtAño" runat="server" CssClass="smallinput"></asp:TextBox></span>            <label>Monto</label><span class="field"><asp:TextBox ID="txtMonto" runat="server" CssClass="smallinput"></asp:TextBox></span>            <br />
            <p class="stdformbutton">
                <asp:Button ID="cmdAgregarPagoCuota" runat="server" Text="Agregar" CssClass="accept" />
            </p>
        </div>
        
        <div id="tabs-2">
            <div class="contenttitle"><h2 class="form"><span>Registrar pago de multa</span></h2></div>
            <br />
            <label>Seleccione la multa a pagar</label>
            <span class="field"><asp:DropDownList ID="cmbMulta" runat="server"></asp:DropDownList></span>            <br />
            <p class="stdformbutton">
                <asp:Button ID="cmdAgregarPagoMulta" runat="server" Text="Agregar" CssClass="accept" />
            </p>
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
            
            
            
            <p class="stdformbutton">
                <asp:Button ID="cmdAgregarValor" runat="server" Text="Agregar" CssClass="accept" />
            </p>
            <div runat="server" id="divErrorValores" class="notification msgerror" visible ="false" ><a class="close"></a>
                <p><asp:Label ID="lblErrorValores" runat="server" Text=""></asp:Label></p>
            </div>
            <br />
        </div>
    </div>
    
    <br />
    <div class="contenttitle"><h2 class="form"><span>A Pagar</span></h2></div>
    <asp:Repeater ID="grilla" runat="server" >
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
            <thead>
                <tr>
                    <th class="head0">Descripcion</th>
                    <th class="head0">Monto</th>
                    <th class="head0">Acción</th>
                </tr>
            </thead>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="">
            <td><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Monto")%></td>
            <td>
            <asp:LinkButton id="lnkDelete" CommandName="Borrar" runat="server">Borrar</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    </asp:Repeater>
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
    
    
    
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>
    <br />
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
</form>

</asp:Content>
