<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmSocioEdit.aspx.vb" Inherits="ContableWeb.frmSocioEdit" title="Socios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información de socio</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Socio</span></h2></div>
<br />
<form runat="server" id="frmCuentaEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información General</a></li>
            <li><a href="#tabs-2">Datos Administrativos</a></li>
        </ul>
        <div id="tabs-1">
            <label>Nombre</label>
            <span class="field"><asp:TextBox ID="txtNombre" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>

            <label>Fecha de Nacimiento</label>
            <span class="field"><asp:TextBox ID="txtFechaNacimiento" OnTextChanged="txtFechaNacimiento_TextChanged" AutoPostBack="true" runat="server" CssClass="smallinput" MaxLength="10"></asp:TextBox></span>
            <asp:CalendarExtender ID="txtFechaNacimientoExt" TargetControlID="txtFechaNacimiento" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
                

            <asp:UpdatePanel ID="up1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtFechaNacimiento" EventName="TextChanged" />
                    </Triggers>
                <ContentTemplate>
                    <label>Categoría correspondiente</label>
                    <span class="field"><asp:TextBox ID="txtCategoria" runat="server" CssClass="smallinput" MaxLength="100" ReadOnly="true"></asp:TextBox></span>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            <label>Es profesional</label>
            <span class="field"><asp:CheckBox ID="chkEsProfesional" runat="server" /></span>
            <label>Clasificación Single</label>
            <span class="field"><asp:TextBox ID="txtClasificacionSingle" runat="server" CssClass="smallinput" MaxLength="2"></asp:TextBox></span>
            <label>Clasificación Dobles</label>
            <span class="field"><asp:TextBox ID="txtClasificacionDobles" runat="server" CssClass="smallinput" MaxLength="2"></asp:TextBox></span>
            
            
            <label>Tipo de documento</label>
            <span class="field"><asp:DropDownList ID="cmbTipoDocumento" runat="server"></asp:DropDownList></span>

            <label>Número de documento</label>
            <span class="field"><asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="smallinput" MaxLength="10"></asp:TextBox></span>

            <label>Sexo</label>
            <span class="field"><asp:DropDownList ID="cmbSexo" runat="server"></asp:DropDownList></span>

            <label>Estado Civil</label>
            <span class="field"><asp:DropDownList ID="cmbEstadoCivil" runat="server"></asp:DropDownList></span>
            
            <label>Nacionalidad</label>
            <span class="field"><asp:DropDownList ID="cmbNacionalidad" runat="server"></asp:DropDownList></span>

            <label>Provincia</label>
            <span class="field"><asp:DropDownList ID="cmbProvincia" runat="server"></asp:DropDownList></span>
            
            <label>Localidad</label>
            <span class="field"><asp:TextBox ID="txtLocalidad" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            
            <label>Dirección</label>
            <span class="field"><asp:TextBox ID="txtDireccion" runat="server" CssClass="mediuminput"></asp:TextBox></span>

            <label>Código Postal</label>
            <span class="field"><asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="smallinput"></asp:TextBox></span>

            <label>Teléfono</label>
            <span class="field"><asp:TextBox ID="txtTelefono" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            
            <label>Celular</label>
            <span class="field"><asp:TextBox ID="txtCelular" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            
            <label>Correo Electrónico</label>
            <span class="field"><asp:TextBox ID="txtEmail" runat="server" CssClass="mediuminput"></asp:TextBox></span>
            
            <label>Web</label>
            <span class="field"><asp:TextBox ID="txtWeb" runat="server" CssClass="mediuminput"></asp:TextBox></span>


        </div>
        <div id="tabs-2">

            <label>Federación</label>
            <span class="field"><asp:TextBox ID="txtFederacion" runat="server" CssClass="mediuminput"></asp:TextBox></span>

            <label>Pertenece a</label>
            <span class="field"><asp:TextBox ID="txtClub" runat="server" CssClass="mediuminput"></asp:TextBox></span>

            <label>Fecha de Ingreso</label>
            <span class="field"><asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="mediuminput" MaxLength="10"></asp:TextBox></span>
            <asp:CalendarExtender ID="txtFechaIngresoExt" TargetControlID="txtFechaIngreso" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

            <label>Estado</label>
            <span class="field"><asp:DropDownList ID="cmbEstadoSocio" runat="server"></asp:DropDownList></span>

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
    
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        TargetControlID="txtClub"   
        ServiceMethod="VistaClub"
        ServicePath="servicios.asmx"
        MinimumPrefixLength="2" 
        CompletionListItemCssClass="select"
        CompletionInterval="100" />

    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
        TargetControlID="txtFederacion"   
        ServiceMethod="VistaFederacion"
        ServicePath="servicios.asmx"
        MinimumPrefixLength="2" 
        CompletionListItemCssClass="select"
        CompletionInterval="100" />
        
</form>

</asp:Content>
