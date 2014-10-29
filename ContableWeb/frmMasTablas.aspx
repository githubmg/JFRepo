<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmMasTablas.aspx.vb" Inherits="ContableWeb.frmMasTablas" 
    title="Más tablas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
    Mas tablas de sistema
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
   <ul class="buttonlist">
   
   <li><a href="frmMoneda.aspx" class="btn btn_link"><span>Monedas</span></a></li><br />
   <li><a href="frmFormaPago.aspx" class="btn btn_link"><span>Formas de Pago</span></a></li><br /> 
   <li><a href="frmEjercicio.aspx" class="btn btn_link"><span>Ejercicio Comercial</span></a></li><br /> 
   
<%--   		<li><a href="" class="btn btn_search radius50"><span>Search</span></a></li>
   		<li><a href="" class="btn btn_trash"><span>Trash</span></a></li>
   		<li><a href="" class="btn btn_flag"><span>Flag</span></a></li>
   		<li><a href="" class="btn btn_home"><span>Home</span></a></li>
   		<li><a href="" class="btn btn_link"><span>Link</span></a></li>
   		<li><a href="" class="btn btn_book"><span>Book</span></a></li>
   		<li><a href="" class="btn btn_mail"><span>Mail</span></a></li>
   		<li><a href="" class="btn btn_help"><span>Help</span></a></li>
   		<li><a href="" class="btn btn_rss"><span>RSS</span></a></li>
   		<li><a href="" class="btn btn_archive"><span>Archive</span></a></li>
   		<li><a href="" class="btn btn_info"><span>Info</span></a></li>
   		<li><a href="" class="btn btn_bell"><span>Bell</span></a></li>
   		<li><a href="" class="btn btn_world"><span>World</span></a></li>
   		<li><a href="" class="btn btn_bulb"><span>Bulb</span></a></li>
   		<li><a href="" class="btn btn_cloud"><span>Cloud</span></a></li>--%>
    </ul>

</asp:Content>
