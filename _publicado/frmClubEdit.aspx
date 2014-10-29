<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmClubEdit.aspx.vb" Inherits="ContableWeb.frmClubEdit" 
    title="Clubes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información del club</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Club</span></h2></div>
<br />
<form runat="server" id="frmClubEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información General</a></li>
        </ul>
        <div id="tabs-1">
            <label>Descripcion</label><span class="field"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>pleno</label><span class="field"><asp:CheckBox ID="chkPleno" runat="server" /></span>
            <label>activo</label><span class="field"><asp:CheckBox ID="chkActivo" runat="server" /></span>
            <label>Cantidad de Canchas</label><span class="field"><asp:TextBox ID="txtcantidadCanchas" runat="server" CssClass="smallinput" MaxLength="100"></asp:TextBox></span>

            <br />
            <h4>Información Administrativa</h4>
            <label>CUIT</label><span class="field"><asp:TextBox ID="txtcuit" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Fecha de estatuto</label><span class="field"><asp:TextBox ID="txtfechaEstatuto" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Fecha de alta</label><span class="field"><asp:TextBox ID="txtfechaAlta" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Condicion de Iva</label><span class="field"><asp:DropDownList ID="cmbCondicionIva" runat="server"> </asp:DropDownList></span>
            
            
            <br />
            <h4>Administración</h4>
            <label>Dirección</label><span class="field"><asp:TextBox ID="txtdireccionAdministracion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Provincia</label><span class="field"><asp:DropDownList ID="cmbProvinciaAdministracion" runat="server"> </asp:DropDownList></span>
            <label>Localidad</label><span class="field"><asp:TextBox ID="txtlocalidadAdministracion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Teléfono</label><span class="field"><asp:TextBox ID="txttelefonoAdministracion" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            
            <br />
            <h4>Club</h4>
            <label>Dirección</label><span class="field"><asp:TextBox ID="txtdireccionClub" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Provincia</label><span class="field"><asp:DropDownList ID="cmbProvinciaClub" runat="server"> </asp:DropDownList></span>        
            <label>Localidad</label><span class="field"><asp:TextBox ID="txtlocalidadClub" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Teléfono</label><span class="field"><asp:TextBox ID="txttelefonoClub" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>web</label><span class="field"><asp:TextBox ID="txtweb" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            
            <br />
            <h4>Contacto</h4>
            <label>Correo electrónico</label><span class="field"><asp:TextBox ID="txtcorreo" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Contacto</label><span class="field"><asp:TextBox ID="txtcontacto" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Telefono</label><span class="field"><asp:TextBox ID="txttelefonoContacto" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Celular</label><span class="field"><asp:TextBox ID="txtcelularContacto" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>


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
    

<asp:CalendarExtender ID="txtfechaEstatutoExt" TargetControlID="txtfechaEstatuto" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
<asp:CalendarExtender ID="txtfechaAltaExt" TargetControlID="txtfechaAlta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

</form>

</asp:Content>
