<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmRegistroMultas.aspx.vb" Inherits="ContableWeb.frmRegistroMultas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Registro de Multas</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


    <div class="contenttitle"><h2 class="form"><span>Datos de la organización</span></h2></div>
    <br />
    <form runat="server" id="frmCuentaEdit" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        
        <label>Fecha</label>
        <span class="field"><asp:TextBox ID="txtFecha" runat="server" CssClass="smallinput"></asp:TextBox></span>

        <label>Torneo</label>        <span class="field"><asp:TextBox ID="txtNombreTorneo" runat="server" CssClass="mediuminput"></asp:TextBox></span>

        <label>Club</label>        <span class="field"><asp:TextBox ID="txtClub" runat="server" CssClass="mediuminput"></asp:TextBox></span>
        <asp:UpdatePanel ID="up1" runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="cmdBuscarSocio" EventName="Click" /></Triggers>
            <ContentTemplate>
                <label>Documento Organizador</label>
                <span class="field">
                <asp:TextBox ID="txtDocumentoOrganizador" runat="server" CssClass="smallinput" />
                <asp:Button ID="cmdBuscarSocio" runat = "server" Text="..." />
                <asp:TextBox ID="txtNombreOrganizador" runat="server" CssClass="mediuminput" ReadOnly="true" />
                </span>
            </ContentTemplate>
        </asp:UpdatePanel>

        <label>Monto de la multa</label>
        <span class="field"><asp:TextBox ID="txtMontoMulta" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <br />
        <div class="widgetbox" style="width:75%; position:relative; margin-left:220px;">
            <div class="title"><h2 class="general"><span>Lista de multados</span></h2></div>
            <div class="widgetcontent">
                <label>Numero Documento</label>
                <span class="field"><asp:TextBox ID="txtNumeroDocumentoSocio" runat="server" CssClass="smallinput"></asp:TextBox></span>
                <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" CssClass="accept" ValidationGroup="Items" />        
                <br /><br />
                
                <div runat="server" id="divErrorItem" class="notification msgerror" visible ="false" ><a class="close"></a>
                    <p><asp:Label ID="lblErrorItem" runat="server" Text=""></asp:Label></p>
                </div>                                <asp:Repeater ID="grilla" runat="server" >
                    <HeaderTemplate>
                        <table cellpadding="0" cellspacing="0" border="1" class="stdtable delete">
                            <thead>
                                <tr>
                                    <th class="head1">Número de Documento</th>
                                    <th class="head0">Nombre</th>
                                    <th class="head0">Club</th>
                                    <th class="head0">&nbsp;</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="">
                            <td><%#DataBinder.Eval(Container.DataItem, "numeroDocumento")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Nombre")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem, "Club.Descripcion")%></td>
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
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        
        <p class="stdformbutton">
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>
        </div>
        <!-- EXTENDERS -->
        <asp:CalendarExtender ID="txtFechaExt" TargetControlID="txtFecha" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtClub"   
            ServiceMethod="VistaClub"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        
        
    </form>
</asp:Content>
