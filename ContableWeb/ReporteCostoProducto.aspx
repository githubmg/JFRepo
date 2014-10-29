﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="ReporteCostoProducto.aspx.vb" Inherits="ContableWeb.ReporteCostoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Reporte de Costos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<form id="frmReporteStock" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>

        <label>Producto:</label>
        <span class="field"><asp:TextBox ID="txtProducto" runat="server" CssClass="smallinput"></asp:TextBox></span>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                    TargetControlID="txtProducto"   
                    ServiceMethod="VistaProductoStockByDecripcion"
                    ServicePath="servicios.asmx"
                    MinimumPrefixLength="2" 
                    CompletionListItemCssClass="select"
                    CompletionInterval="100" />
        
        <p class="stdformbutton">
            <asp:Button ID="cmdVerValores" runat="server" Text="Ver Costos" CssClass="accept"/>
            <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
        </p>
        
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>Stock de Productos</span></h2>
        </div>
        <br />
        <div id="divExportacion" runat="server" visible="false">
            <asp:LinkButton ID="lnkExpoPDF" runat="server" CssClass="btn btn_pdf"  ><span>PDF</span></asp:LinkButton>
            <asp:LinkButton ID="lnkExpoXLS" runat="server" CssClass="btn btn_grid2"><span>Excel</span></asp:LinkButton>
        </div>
    </form>
    <br />

<asp:Repeater ID="grilla" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
        <thead>
            <tr>
            
                <th class="head0">Familia</th>
                <th class="head0">Código</th>
                <th class="head0">Descripción</th>
                <th class="head0">Costo</th>
               
                
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%# DataBinder.Eval(Container.DataItem, "familia")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "codProducto")%></td>             
                <td><%# DataBinder.Eval(Container.DataItem, "descripcion")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "costo")%></td>
      
                    
            </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                <th class="head0">&nbsp;</th>
                
                
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
