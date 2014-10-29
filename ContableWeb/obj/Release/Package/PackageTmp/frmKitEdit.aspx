<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmKitEdit.aspx.vb" Inherits="ContableWeb.frmKitEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Información del kit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <div class="contenttitle"><h2 class="form"><span>Kits</span></h2></div>
    <br />
    <form runat="server" id="frmPedidoEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <p>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <label>Familia</label>
                <span class="field"><asp:DropDownList ID="cmbFamiliaPrincipal" runat="server" 
                AutoPostBack="True"></asp:DropDownList></span>
            <label>Producto</label>
                <span class="field"><asp:DropDownList ID="cmbProductoPrincipal" runat="server"></asp:DropDownList></span>
          <label>Descripcion</label>
        <span class="field"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="longinput"></asp:TextBox></span>
           </ContentTemplate>
        </asp:UpdatePanel>
        </p>
        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Items del Kit</span></h2></div>
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
                </p>
                <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" CssClass="accept" ValidationGroup="Items" />
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
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th class="head1">Familia</th>
                                        <th class="head0">Producto</th>
                                        <th class="head0">Cantidad</th>
                                       
                                        <th class="head0">&nbsp;</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="">
                                <td><%# DataBinder.Eval(Container.DataItem,"Producto.Familia.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Producto.Descripcion")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Cantidad")%></td>
                              
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

    </form>
</asp:Content>
