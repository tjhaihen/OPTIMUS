Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure

    Public Class Reports
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Reports_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareDDL()
                prepareScreen(True)
                ReadQueryString()
                DataBind()
            End If
        End Sub

        Private Sub ddlPeriod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPeriod.SelectedIndexChanged
            Select Case ddlPeriod.SelectedValue.Trim
                Case "ThisMonth"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month + 1, 1 - 1)
                Case "LastMonth"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1 + 1, 1 - 1)
                Case "ThisYear"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, 12 + 1, 1 - 1)
                Case "LastYear"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year - 1, 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year - 1, 12 + 1, 1 - 1)
                Case Else
                    pnlCustomPeriod.Visible = True
                    calStartDate.selectedDate = Date.Today
                    calEndDate.selectedDate = Date.Today
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    Dim url As New StringBuilder

                    If lblReportID.Text.Trim.Length = 0 Then
                        commonFunction.MsgBox(Me, "Please select Report from the Report Explorer first.")
                        Exit Sub
                    Else
                        br.ReportID = lblReportID.Text.Trim
                    End If

                    '// Periode
                    If pdPeriod.Visible Then
                        br.AddParameters(Format(calStartDate.selectedDate, "yyyyMMdd"))
                        br.AddParameters(Format(calEndDate.selectedDate, "yyyyMMdd"))
                    End If

                    br.AddParameters(MyBase.LoggedOnUserID.Trim)
                    br.GetReportDataByReportCode()
                    If br.ReportFormat = "XLS" Then
                        br.ExportToExcel(br.generateReportDataTable, Response)
                    Else
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    br.Dispose()
                    br = Nothing
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            If Not CType(Request.QueryString("id"), String) Is Nothing Then
                lblReportID.Text = CType(Request.QueryString("id"), String)
            End If
            If Not CType(Request.QueryString("rc"), String) Is Nothing Then
                lblReportCaption.Text = CType(Request.QueryString("rc"), String)
            End If

            Try
                pdPeriod.Visible = (Request.QueryString("pdPeriod") = "True")

                If pdPeriod.Visible Then
                    calStartDate.selectedDate = Date.Now
                    calEndDate.selectedDate = Date.Now
                End If
            Catch
            End Try
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            GenerateReportExplorer()
            ddlPeriod_SelectedIndexChanged(Nothing, Nothing)
        End Sub

        Private Sub prepareDDL()
            commonFunction.SetDDL_Period(ddlPeriod)
        End Sub
#End Region


#Region " Report Explorer "
        Private Sub GenerateReportExplorer()
            '// Get Reports
            Dim dt As DataTable
            Dim br As New Common.BussinessRules.Report
            br.AppID = Common.Constants.AppID.TechnicalInspection_AppID
            dt = br.SelectRootActiveReports()
            br.Dispose()
            br = Nothing

            PopulateNodes(dt, trvReport.Nodes)
        End Sub

        Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)
            For Each dr As DataRow In dt.Rows
                Dim tn As New TreeNode()
                tn.Text = dr("caption").ToString()
                tn.Value = dr("reportID").ToString()
                If Not (CInt(dr("ChildCount")) > 0) Then
                    tn.NavigateUrl = PageBase.UrlBase + "/secure/" + dr("Url").ToString()
                Else
                    tn.SelectAction = TreeNodeSelectAction.Expand
                End If
                nodes.Add(tn)

                'If node has child nodes, then enable on-demand populating
                tn.PopulateOnDemand = (CInt(dr("ChildCount")) > 0)
            Next
        End Sub

        Private Sub PopulateSubLevel(ByVal parentid As Integer, ByVal parentNode As TreeNode)
            Dim br As New Common.BussinessRules.Report
            br.ParentReportID = parentid
            br.AppID = Common.Constants.AppID.TechnicalInspection_AppID
            Dim dt As DataTable
            dt = br.SelectChildActiveReports()
            br.Dispose()
            br = Nothing
            PopulateNodes(dt, parentNode.ChildNodes)
        End Sub

        Protected Sub trvReport_TreeNodePopulate(ByVal sender As Object, ByVal e As TreeNodeEventArgs) Handles trvReport.TreeNodePopulate
            PopulateSubLevel(CInt(e.Node.Value), e.Node)
        End Sub
#End Region


#Region " C,R,U,D "
        
#End Region
    End Class

End Namespace