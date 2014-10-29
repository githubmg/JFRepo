Imports Microsoft.Reporting.WebForms
Imports Negocio

Public Class frmViewer
    Inherits System.Web.UI.Page

    Private _tipo As String
    Private _codigo As Integer

    Public Property Tipo() As String
        Get
            Return Me._tipo
        End Get
        Set(ByVal value As String)
            Me._tipo = value
        End Set
    End Property
    Public Property Codigo() As Integer
        Get
            Return Me._codigo
        End Get
        Set(ByVal value As Integer)
            Me._codigo = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("tipo") Is Nothing Then
            Me.Tipo = Me.Request.QueryString("tipo").ToString()
        End If
        If Not Me.Request.QueryString("id") Is Nothing AndAlso IsNumeric(Me.Request.QueryString("id")) Then
            Me.Codigo = CType(Me.Request.QueryString("id"), Integer)
        End If
        Select Case Me.Tipo
            Case "RE" : ImprimirRemito()
                'Case "FAA" : ImprimirFacturaA()
                'Case "FAB" : ImprimirFacturaB()
            Case "FA" : ImprimirFactura()
            Case "DEU" : ImprimirDeudores()
            Case "DEUEX" : ImprimirDeudoresExcel()
            Case "ACR" : ImprimirAcreedores()
            Case "ACREX" : ImprimirAcreedoresExcel()
            Case "VAC" : ImprimirValoresCartera()
            Case "VACEX" : ImprimirValoresCarteraExcel()
            Case "VACE" : ImprimirValoresCedidos()
            Case "VACEEX" : ImprimirValoresCedidosExcel()
            Case "VE" : ImprimirVentasVendedores()
            Case "VEEX" : ImprimirVentasVendedoresExcel()
            Case "ST" : ImprimirStock()
            Case "STEX" : ImprimirStockExcel()
            Case "MC" : ImprimirMovCaja()
            Case "MCEX" : ImprimirMovCajaExcel()
            Case "CT" : ImprimirCosto()
            Case "CTEX" : ImprimirCostoExcel()
            Case "PAGEX", "COBEX", "PEDEX", "COMEX" : ImprimirVistaExcel()
            Case "AGENDA" : ImprimirAgenda()
            Case "AGENDAEX" : ImprimirAgendaExcel()
            Case Else

        End Select

    End Sub
    Private Sub ImprimirAgenda()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaReporteEventoPorFecha(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptAgenda.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=agenda_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirAgendaExcel()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaReporteEventoPorFecha(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptAgenda.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=agenda_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirVistaExcel()
        Dim path As String
        Dim nombre As String
        Dim rds1 As ReportDataSource
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        response = System.Web.HttpContext.Current.Response
        Select Case Me.Tipo
            Case "PAGEX"
                rds1 = New ReportDataSource("DSContableWeb", Sistema.VistaPago)
                path = "reportes\rptPagos.rdlc"
                nombre = "pagos"
            Case "COBEX"
                rds1 = New ReportDataSource("DSContableWeb", Sistema.VistaCobro)
                path = "reportes\rptCobros.rdlc"
                nombre = "cobros"
            Case "PEDEX"
                rds1 = New ReportDataSource("DSContableWeb", Sistema.VistaPedidoCabe)
                path = "reportes\rptPedidos.rdlc"
                nombre = "pedidos"
            Case Else
                rds1 = New ReportDataSource("DSContableWeb", Sistema.VistaCompraCabe)
                path = "reportes\rptCompras.rdlc"
                nombre = "compras"
        End Select
        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = path
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing

        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=" & nombre & ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirStockExcel()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.ReporteProductoStock(Me.Codigo))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptProductoStock.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing

        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=reporteStock.xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirStock()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.ReporteProductoStock(Me.Codigo))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptProductoStock.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=reporteStock.pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirCostoExcel()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.ReporteCosto(Me.Codigo))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptProductoCosto.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing

        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=reporteCosto.xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirCosto()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.ReporteCosto(Me.Codigo))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptProductoCosto.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=reporteCosto.pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirVentasVendedoresExcel()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        Dim idVendedor = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        If Not Me.Request.QueryString("idVendedor") Is Nothing Then
            idVendedor = Me.Request.QueryString("idVendedor").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaVentasVendedor(desde, hasta, idVendedor))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptVentasVendedor.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=ventasVendedor_desde:" + desde + "_hasta:" + hasta + "_nro:" + idVendedor + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirVentasVendedores()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        Dim idVendedor = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        If Not Me.Request.QueryString("idVendedor") Is Nothing Then
            idVendedor = Me.Request.QueryString("idVendedor").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaVentasVendedor(desde, hasta, idVendedor))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptVentasVendedor.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=ventasVendedor_desde:" + desde + "_hasta:" + hasta + "_nro:" + idVendedor + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirValoresCartera()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaValoresCartera(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptValoresCartera.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=valoresEnCartera_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirValoresCarteraExcel()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim rds As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaValoresCartera(desde, hasta))
        response = System.Web.HttpContext.Current.Response

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptValoresCartera.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=valoresEnCartera_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirValoresCedidos()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        Dim cobrado = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        If Not Me.Request.QueryString("cobrado") Is Nothing Then
            cobrado = Me.Request.QueryString("cobrado").ToString()
        End If

        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaValoresCedidos(desde, hasta, cobrado))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptValoresCedidos.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=valoresCedidos_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirValoresCedidosExcel()
        Dim desde = ""
        Dim hasta = ""
        Dim cobrado = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        If Not Me.Request.QueryString("cobrado") Is Nothing Then
            cobrado = Me.Request.QueryString("cobrado").ToString()
        End If
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim rds As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaValoresCedidos(desde, hasta, cobrado))
        response = System.Web.HttpContext.Current.Response

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptValoresCedidos.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=valoresCedidos_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirAcreedoresExcel()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim rds As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaAcreedores(desde, hasta))
        response = System.Web.HttpContext.Current.Response

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptAcreedores.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=acreedores_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirDeudoresExcel()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim rds As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaDeudores(desde, hasta))
        response = System.Web.HttpContext.Current.Response

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptDeudores.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=deudores_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirMovCajaExcel()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim rds As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaMovCaja(desde, hasta))
        response = System.Web.HttpContext.Current.Response

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptMovCaja.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=movcaja_desde:" + desde + "_hasta:" + hasta + ".xls")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirAcreedores()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaAcreedores(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptAcreedores.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=acreedores_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirDeudores()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaDeudores(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptDeudores.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=deudores_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirMovCaja()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()
        Dim desde = ""
        Dim hasta = ""
        If Not Me.Request.QueryString("desde") Is Nothing Then
            desde = Me.Request.QueryString("desde").ToString()
        End If
        If Not Me.Request.QueryString("hasta") Is Nothing Then
            hasta = Me.Request.QueryString("hasta").ToString()
        End If
        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSContableWeb", Sistema.VistaMovCaja(desde, hasta))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptMovCaja.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=movcaja_desde:" + desde + "_hasta:" + hasta + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirRemito()

        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()

        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("dsContableWeb", Sistema.VistaRemitoReporte(Me.Codigo))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptRemitoComprobante.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=remito_" + Me.Codigo.ToString + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
    End Sub
    Private Sub ImprimirFactura()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()

        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DSCabe", Sistema.VistaFacturaCabe(Me.Codigo))
        Dim rds2 As ReportDataSource = New ReportDataSource("DSDetalle", Sistema.VistaFacturaDetalle(Me.Codigo))
        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptFactura.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.DataSources.Add(rds2)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=factura_" + Me.Codigo.ToString + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
      
    End Sub
    Private Sub ImprimirFacturaB()
        Dim response As System.Web.HttpResponse
        Dim reportViewer1 As ReportViewer = New ReportViewer()

        response = System.Web.HttpContext.Current.Response
        Dim rds1 As ReportDataSource = New ReportDataSource("DataSet1", Sistema.VistaRemitoReporte(1))

        reportViewer1.ProcessingMode = ProcessingMode.Local
        reportViewer1.LocalReport.ReportPath = "reportes\rptFactura.rdlc"
        reportViewer1.LocalReport.DataSources.Clear()
        reportViewer1.LocalReport.DataSources.Add(rds1)
        reportViewer1.LocalReport.Refresh()

        Dim bytes As Byte() = Nothing
        Dim warnings As Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        response.Buffer = True
        response.Clear()
        response.ContentType = mimeType
        response.AddHeader("content-disposition", "attachment; filename=factura_" + Me.Codigo.ToString + ".pdf")
        response.BinaryWrite(bytes)
        response.Flush()
        'Dim response As System.Web.HttpResponse
        'Dim reportViewer1 As ReportViewer = New ReportViewer()

        'response = System.Web.HttpContext.Current.Response
        'Dim rds1 As ReportDataSource = New ReportDataSource("dsContableWeb", Sistema.VistaFacturaReporte(Me.Codigo))

        'reportViewer1.ProcessingMode = ProcessingMode.Local
        'reportViewer1.LocalReport.ReportPath = "reportes\rptFacturaBComprobante.rdlc"
        'reportViewer1.LocalReport.DataSources.Clear()
        'reportViewer1.LocalReport.DataSources.Add(rds1)
        'reportViewer1.LocalReport.Refresh()

        'Dim bytes As Byte() = Nothing
        'Dim warnings As Warning() = Nothing
        'Dim streamIds As String() = Nothing
        'Dim mimeType As String = String.Empty
        'Dim encoding As String = String.Empty
        'Dim extension As String = String.Empty

        'bytes = reportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

        'response.Buffer = True
        'response.Clear()
        'response.ContentType = mimeType
        'response.AddHeader("content-disposition", "attachment; filename=factura_" + Me.Codigo.ToString + ".pdf")
        'response.BinaryWrite(bytes)
        'response.Flush()
    End Sub
  
End Class