<%@ Page Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmEjercicioEdit.aspx.vb" Inherits="ContableWeb.frmEjercicioEdit" 
    title="Ejercicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">Información del Ejercicio</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="contenttitle"><h2 class="form"><span>Ejercicios</span></h2></div>
<br />
<form runat="server" id="frmClubEdit" class="stdform" action="" method="post">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Información del Ejercicio Comercial</a></li>
        </ul>
        <div id="tabs-1">
            <label>Fecha Inicio</label>
            <span class="field"><asp:TextBox ID="txtFechaInicio" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Fecha Fin</label>
            <span class="field"><asp:TextBox ID="txtFechaFin" runat="server" CssClass="mediuminput" MaxLength="100"></asp:TextBox></span>
            <label>Activo</label>
            <span class="field"><asp:CheckBox ID="chkActivo" runat="server" EnableViewState="true" /></span>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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


    <asp:CalendarExtender ID="txtFechaInicioExt" TargetControlID="txtFechaInicio" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
    <asp:CalendarExtender ID="txtFechaFinExt" TargetControlID="txtFechaFin" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

</form>

</asp:Content>
