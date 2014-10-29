<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmFondoFijoEdit.aspx.vb" Inherits="ContableWeb.frmFondoFijoEdit" 
    title="Fondo Fijo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información del Fondo Fijo</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Fondo Fijo</span></h2></div>
<br />
<form runat="server" id="frmClubEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información del Fondo Fijo</a></li>
        </ul>
        <div id="tabs-1">
            <label>Fecha</label>
            <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="mediuminput" MaxLength="10"></asp:TextBox></span>
            <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Cuentas</span></h2></div>
            <div class="widgetcontent">
                <p>
                <label>Cuenta</label>
                <span class="field"><asp:TextBox ID="txtCuenta" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
                <label>Monto</label>
                <span class="field"><asp:TextBox ID="txtMonto" runat="server" CssClass="smallinput"></asp:TextBox></span>
                <label>Observaciones</label>
                <span class="field"><asp:TextBox ID="txtObservacionesItem" runat="server" CssClass="longinput" MaxLength="100"></asp:TextBox></span>
                <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" CssClass="accept" ValidationGroup="Items" />        
                </p>
                <div runat="server" id="divErrorItem" class="notification msgerror" visible ="false" ><a class="close"></a>
                    <p><asp:Label ID="lblErrorItem" runat="server" Text=""></asp:Label></p>
                </div>                <asp:Repeater ID="grilla" runat="server" >
                    <HeaderTemplate>
                        <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                            <colgroup>
                                <col class="con0" />
                                <col class="con0" />
                                <col class="con0" />
                                <col class="con0" />
                            </colgroup>
                            <thead>
                                <tr>
                                    <th class="head1">Cuenta</th>
                                    <th class="head0">Monto</th>
                                    <th class="head0">Observaciones</th>
                                    <th class="head0">&nbsp;</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="">
                            <td><%#DataBinder.Eval(Container.DataItem, "Cuenta.Codigo")%> - <%#DataBinder.Eval(Container.DataItem, "Cuenta.Descripcion")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Monto")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Observaciones")%></td>
                            <td>
                            <asp:LinkButton id="lnkDelete" CommandName="Borrar" runat="server">Borrar</asp:LinkButton>&nbsp;-&nbsp;
                            <asp:LinkButton id="lnkEditar" CommandName="Editar" runat="server">Editar</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div><!--widgetcontent-->
        </div>
        <label>Forma de pago</label>        <span class="field"><asp:DropDownList ID="cmbFormaPago" runat="server"></asp:DropDownList></span>        <label>Observaciones</label>
        <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput" MaxLength="100"></asp:TextBox></span>

        </div>
     </div>
    <br />
    <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
        <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
    </div>
    <p class="stdformbutton">
        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept"/>
        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
    </p>
    
    <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        TargetControlID="txtCuenta"   
        ServiceMethod="VistaCuenta"
        ServicePath="servicios.asmx"
        MinimumPrefixLength="2" 
        CompletionListItemCssClass="select"
        CompletionInterval="100" />

</form>

</asp:Content>
