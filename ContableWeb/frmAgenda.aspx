<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="frmAgenda.aspx.vb" Inherits="ContableWeb.frmAgenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentTitulo" runat="server">
Agenda
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentCuerpo" runat="server">
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script language="javascript" type="text/javascript">
    window.onload = function lalal() {
        var iframes = document.getElementsByTagName("IFRAME");
        for (var i = 0, ln = iframes.length; i < ln; i++) {
            iframes[0].parentNode.removeChild(iframes[0]);
        }
    }
</script>
    <form id="frmReporteValores" runat="server" class="stdform" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
      <table>
      <tr>
          <td>
             <asp:Button ID="btnNuevoEvento" runat="server" Text="Nuevo Evento" CssClass="accept"/>       
          </td>
      </tr>
      <tr>
      <td>
            <label>Desde:</label>
            <span class="field"><asp:TextBox ID="txtFechaDesde" runat="server" CssClass="longinput"></asp:TextBox></span>
            <asp:CalendarExtender ID="txtFechaDesdeExt" TargetControlID="txtFechaDesde" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

            <label>Hasta:</label>
            <span class="field"><asp:TextBox ID="txtFechaHasta" runat="server" CssClass="longinput"></asp:TextBox></span>
            <asp:CalendarExtender ID="txtFechaHastaExt" TargetControlID="txtFechaHasta" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />

               
            <p class="stdformbutton">
                <asp:Button ID="cmdVerValores" runat="server" Text="Ver" CssClass="accept"/>
                <asp:Button ID="cmdVolver" runat="server" Text="Volver" CssClass="reset" />
            </p>
      </td>
       </tr>
      </table>
              
        <div runat="server" id="divErrorForm" class="notification msgerror" visible ="false" ><a class="close"></a>
            <p><asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>Agenda</span></h2>
        </div>
        <div id="divExportacion" runat="server">
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
                <th class="head1">Nro. Evento</th>
                <th class="head0">Fecha</th>
                <th class="head0">Cliente</th>
                <th class="head0">Trabajo a realizar</th>
                <th class="head0">Datos de contacto</th>
                <th class="head0">Estado</th>
                <th class="head0">Domicilio</th>
                <th class="head0">Acción</th>
                
            
            </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
            <tr class="">
                <td><%#DataBinder.Eval(Container.DataItem, "idEvento")%></td>
                <td><%#CType(DataBinder.Eval(Container.DataItem, "fecha"), Date).ToShortDateString()%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "razonSocial")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "trabajo").split("< br/>")(0) & "..."%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "datosContacto").split("< br/>")(0) & "..."%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "estado")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "domicilio")%></td>
                <td><a href="frmAgendaEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "idEvento")%>">Editar</a>
          </tr>
    </ItemTemplate>
    <FooterTemplate>
            <tfoot>
            <tr>
                <th class="head1"></th>
                <th class="head0"></th>
                <th class="head0"></th>
                <th class="head0"></th>
                <th class="head0"></th>
                <th class="head0"></th>
                <th class="head0"></th>              
                <th class="head0"></th>              
            </tr>
        </tfoot>
        </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
