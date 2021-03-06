﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReporte.aspx.vb" Inherits="ContableWeb.frmReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server"
        ProcessingMode="Local" Width="100%"
        AsyncRendering="false" 
        SizeToReportContent="true"
        ShowExportControls="true" 
        ShowFindControls="false"
        ShowRefreshButton="false">
        <LocalReport ReportPath="reportes\reporteCtaCteProveedor.rdlc"></LocalReport>
    </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
