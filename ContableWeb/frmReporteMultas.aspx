<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmReporteMultas.aspx.vb" Inherits="ContableWeb.frmReporteMultas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    Multas por Torneos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


 <div class="contenttitle"><h2 class="form"><span>Multas por torneo</span></h2></div>
    <br />
    <form runat="server" id="frmReporteMultas" class="stdform" action="" method="post">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        
        <label>Club</label>        <span class="field">            <asp:TextBox ID="txtClub" runat="server" CssClass="mediuminput"></asp:TextBox>            <asp:Button ID="cmdBuscarMultas" runat = "server" Text="Buscar torneos" />        </span>        <span class="field">            <asp:DropDownList ID="cmbMultaSocioCabe" runat="server"></asp:DropDownList>            <asp:Button ID="cmdVerDetalle" runat = "server" Text="Ver torneo seleccionado" />        </span>
        <br />
        <asp:UpdatePanel ID="up1" runat="server">
            <Triggers><asp:AsyncPostBackTrigger ControlID="cmdVerDetalle" EventName="Click" /></Triggers>
            <ContentTemplate>
            
            <div class="contenttitle radiusbottom0"><h2 class="table"><span>Totales</span></h2></div>
                <asp:GridView ID="grillaTotales" runat="server" CssClass="stdtable">
                    <HeaderStyle CssClass="cabecera" />
                </asp:GridView>
            
            <br />
            <div class="contenttitle radiusbottom0"><h2 class="table"><span>Socios multados</span></h2></div>
                <asp:GridView ID="grillaSocios" runat="server" CssClass="stdtable">
                    <HeaderStyle CssClass="cabecera" />
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>

        <br />     
        <p class="stdformbutton">
            <asp:Button ID="cmdAceptar" runat="server" Text="Aceptar" CssClass="accept" />
            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="reset" />
        </p>        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false"><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <br />

        <!-- EXTENDERS -->
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
            TargetControlID="txtClub"   
            ServiceMethod="VistaClub"
            ServicePath="servicios.asmx"
            MinimumPrefixLength="2" 
            CompletionListItemCssClass="select"
            CompletionInterval="100" />
        
        
    </form>





</asp:Content>
