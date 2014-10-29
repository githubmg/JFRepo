<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmAsientoEdit.aspx.vb" Inherits="ContableWeb.frmAsientoEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Asiento contable</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
    
    <div class="contenttitle"><h2 class="form"><span>Asientos</span></h2></div>
    <br />
    <form runat="server" id="frmCuentaEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Guardar como "asiento tipo"</label>
        <span class="field"><asp:CheckBox ID="chkEsAsientoTipo" runat="server" Checked="false" /></span>
                
        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Tipo de Comprobante</label>        <span class="field"><asp:DropDownList ID="cmbTipoComprobante" runat="server"></asp:DropDownList></span>
        <label>Número de comprobante</label>        <span class="field"><asp:TextBox ID="txtNumeroComprobante" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <label>Concepto</label>        <span class="field"><asp:TextBox ID="txtConcepto" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <label>Observaciones</label>        <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput"></asp:TextBox></span>
        </p>        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Items del asiento</span></h2></div>
            <div class="widgetcontent">
                <p>
                    <label>Código de cuenta</label>
                    <span class="field"><asp:TextBox ID="txtCuenta" runat="server" CssClass="mediuminput"></asp:TextBox></span>
                    <label>Debe</label>
                    <span class="field"><asp:TextBox ID="txtDebe" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    <label>Haber</label>
                    <span class="field"><asp:TextBox ID="txtHaber" runat="server" CssClass="smallinput"></asp:TextBox></span>
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
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th class="head1">Cuenta</th>
                                        <th class="head0">Debe</th>
                                        <th class="head0">Haber</th>
                                        <th class="head0">&nbsp;</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="">
                                <td><%#DataBinder.Eval(Container.DataItem, "Cuenta.Codigo")%> - <%#DataBinder.Eval(Container.DataItem, "Cuenta.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Debe")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Haber")%></td>
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
        </div>        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtCuenta"   
            ServiceMethod="VistaCuenta"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
    </form>

</asp:Content>
