<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmUsuarioPantalla.aspx.vb" Inherits="ContableWeb.frmUsuarioPantalla" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Permisos del Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<script language="javascript" type="text/javascript">
    window.onload = function lalal() {
        var iframes = document.getElementsByTagName("IFRAME");
        for (var i = 0, ln = iframes.length; i < ln; i++) {
            iframes[0].parentNode.removeChild(iframes[0]);
        }
    }
</script>
    <form id="frmReporteAcreedores" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        <label>Usuario</label>
                <span class="field"><asp:TextBox ID="txtUsuario" runat="server" CssClass="longinput"></asp:TextBox></span>
                 <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                    TargetControlID="txtUsuario"   
                    ServiceMethod="VistaUsuarioAjax"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerPermisos" runat="server" Text="Ver Permisos" CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        <div id = "Permisos" runat="server" visible="false">
           <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Permisos del Usuario</span></h2></div>
            <div class="widgetcontent">
                <p>
                <label>Permiso</label>
                 <span class="field"><asp:TextBox ID="txtPermisos" runat="server" CssClass="longinput"></asp:TextBox></span>
                 <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                    TargetControlID="txtPermisos"   
                    ServiceMethod="PermisosVistaAjax"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
                    <label>Es pantalla principal</label>
                <span class="field"><asp:DropDownList ID="cmbSiNo" runat="server" 
                    AutoPostBack="True"></asp:DropDownList></span>
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
                                        
                                        <th class="head0">Descripcion</th>
                                        <th class="head0">Url</th>
                                        <th class="head0">Tipo</th>  
                                        <th class="head0">Es Principal</th>                                         
                                        <th class="head0">&nbsp;</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="">
                                <td><%# DataBinder.Eval(Container.DataItem, "Pantalla.Descripcion")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"Pantalla.Url")%></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Pantalla.Tipo")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"esPantallaPrincipal")%></td>
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
       

        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
         </div><!--permisos-->
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
 </form>
</asp:Content>
