<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmCompraEdit.aspx.vb" Inherits="ContableWeb.frmCompraEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información de la compra
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <div class="contenttitle"><h2 class="form"><span>Compras</span></h2></div>
    <br />
    <form runat="server" id="frmPedidoEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
        <label>Proveedor</label>
        <span class="field"><asp:TextBox ID="txtProveedor" runat="server" CssClass="mediuminput"></asp:TextBox></span>
                              
        <label>Fecha de compra</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="smallinput"></asp:TextBox></span>
        
        <label>Estado</label>
        <span class="field"><asp:DropDownList ID="cmbEstado" runat="server"></asp:DropDownList></span>
        
        <label>Tipo</label>
        <span class="field"><asp:DropDownList ID="cmbTipoOrden" runat="server"></asp:DropDownList></span>

        <label>Observaciones</label>
        <span class="field"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="longinput"></asp:TextBox></span>
        </p>
        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Items de la compra</span></h2></div>
            <div class="widgetcontent">
                <p>
                    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <label>Familia</label>
                          <span class="field"><asp:DropDownList ID="cmbFamilia" runat="server" 
                            AutoPostBack="True"></asp:DropDownList></span>
                        <label>Producto</label>
                          <span class="field"><asp:DropDownList ID="cmbProducto" runat="server"></asp:DropDownList></span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <label>Cantidad</label>
                      <span class="field"><asp:TextBox ID="txtCantidad" runat="server" CssClass="smallinput" MaxLength=10></asp:TextBox></span>
                    <label>Precio unitario</label>
                      <span class="field"><asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="smallinput"></asp:TextBox></span>
                    <label>Observaciones</label>
                      <span class="field"><asp:TextBox ID="txtObservacionesItem" runat="server" CssClass="smallinput"></asp:TextBox></span>
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
                                        <th class="head1">Familia</th>
                                        <th class="head0">Producto</th>
                                        <th class="head0">Cantidad</th>
                                        <th class="head0">Precio unitario</th>                
                                        <th class="head0">&nbsp;</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="">
                                <td><%# DataBinder.Eval(Container.DataItem,"Producto.Familia.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Producto.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Cantidad")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "PrecioUnitario")%></td>
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
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>

     <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtProveedor"   
            ServiceMethod="VistaProveedor"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
    </form>
</asp:Content>
