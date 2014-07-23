Namespace Raven.Web

    Partial Public Class ReportViewer
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
                Dim shcr As New ShowCR

                Dim reportID As String = Request.QueryString("rpt")
                Dim parametersValue As String = Request.QueryString("par")

                shcr.CreateReport(reportID, MyReportViewer, parametersValue)
                shcr.Dispose()
                shcr = Nothing
            End If
        End Sub
    End Class

End Namespace