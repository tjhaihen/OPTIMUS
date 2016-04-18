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

    Public Class CustomerInspectionInformationDetail
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.CustomerInspectionInformation_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                If ReadQueryString() Then
                    _openProject(lblProjectID.Text.Trim)
                    SetDataGridCustomerInspectionInformation()
                    SetDataGridDailyReportHd()
                    SetDataGridProjectFile()
                    SetDataGridResourceFile()
                End If
                DataBind()
            End If
        End Sub

        Private Sub grdDailyReportHd_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdDailyReportHd.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#ffffff';this.focus;this.style.cursor='pointer';")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")
            End Select
        End Sub

        Private Sub grdDailyReportHd_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDailyReportHd.ItemCommand
            Select Case e.CommandName
                Case "SelectReportDate"
                    Dim _lbtnReportDate As LinkButton = CType(e.Item.FindControl("_lbtnReportDate"), LinkButton)
                    lblDailyReportHdID.ToolTip = _lbtnReportDate.ToolTip.Trim
                    lblDailyReportHdID.Text = _lbtnReportDate.Text.Trim
                    SetDataGridDailyReportDt()
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            lblProjectID.Text = ProcessNull.GetString(Request.QueryString("pid"))
            Return (lblProjectID.Text.Trim.Length > 0)
        End Function

        Private Sub SetDataGridCustomerInspectionInformation()
            Dim oSOI As New Common.BussinessRules.SummaryOfInspection
            oSOI.projectID = lblProjectID.Text.Trim
            grdSummaryOfInspection.DataSource = oSOI.SelectByProjectID
            grdSummaryOfInspection.DataBind()
            oSOI.Dispose()
            oSOI = Nothing

            GetDashboardInformationByProjectID()
        End Sub

        Private Sub SetDataGridDailyReportHd()
            Dim br As New Common.BussinessRules.DailyReportHd
            Dim dt As New DataTable
            With br
                .projectID = lblProjectID.Text.Trim
                dt = .SelectByProjectID()
            End With
            grdDailyReportHd.DataSource = dt.DefaultView
            grdDailyReportHd.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub SetDataGridDailyReportDt()
            Dim br As New Common.BussinessRules.DailyReportDt
            Dim dt As New DataTable
            With br
                .dailyReportHdID = lblDailyReportHdID.ToolTip.Trim
                dt = .SelectByDailyReportHdID()
            End With
            grdDailyReportDt.DataSource = dt.DefaultView
            grdDailyReportDt.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub SetDataGridProjectFile()
            Dim br As New Common.BussinessRules.ProjectFile
            Dim dt As New DataTable
            With br
                .projectID = lblProjectID.Text.Trim
                dt = .GetFileByProjectID(True)
            End With

            grdProjectFile.DataSource = dt.DefaultView
            grdProjectFile.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub SetDataGridResourceFile()
            Dim br As New Common.BussinessRules.ResourceFile
            Dim dt As New DataTable
            With br
                dt = .GetFileByProjectID(lblProjectID.Text.Trim, True)
            End With
            grdResourceFile.DataSource = dt.DefaultView
            grdResourceFile.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetDashboardInformationByProjectID()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtTotalInspectionByProjectID As New DataTable
            With oProject
                dtTotalInspectionByProjectID = .GetTotalInspectionByProjectID(lblProjectID.Text.Trim)

                If dtTotalInspectionByProjectID.Rows.Count > 0 Then
                    lblTotalItemIspected.Text = .totalItemInspected.ToString.Trim
                    lblTotalItemAccepted.Text = .totalItemAccepted.ToString.Trim
                    lblTotalItemNeedRepair.Text = .totalItemNeedRepair.ToString.Trim
                    lblItemClass2.Text = .totalItemClass2.ToString.Trim
                    lblItemRejected.Text = .totalItemRejected.ToString.Trim
                    lblTotalItemRejected.Text = (.totalItemClass2 + .totalItemRejected).ToString.Trim
                    If .totalItemInspected > 0 And .totalItemAccepted > 0 Then
                        lblTotalItemAcceptedPct.Text = Format((.totalItemAccepted / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemAcceptedPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemNeedRepair > 0 Then
                        lblTotalItemNeedRepairPct.Text = Format((.totalItemNeedRepair / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemNeedRepairPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemClass2 > 0 Then
                        lblItemClass2Pct.Text = Format((.totalItemClass2 / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblItemClass2Pct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemRejected > 0 Then
                        lblItemRejectedPct.Text = Format((.totalItemRejected / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblItemRejectedPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And (.totalItemClass2 + .totalItemRejected) > 0 Then
                        lblTotalItemRejectedPct.Text = Format(((.totalItemClass2 + .totalItemRejected) / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemRejectedPct.Text = "0"
                    End If
                Else
                    lblTotalItemIspected.Text = "0"
                    lblTotalItemAccepted.Text = "0"
                    lblTotalItemAcceptedPct.Text = "0"
                    lblTotalItemNeedRepair.Text = "0"
                    lblTotalItemNeedRepairPct.Text = "0"
                    lblItemClass2.Text = "0"
                    lblItemClass2Pct.Text = "0"
                    lblItemRejected.Text = "0"
                    lblItemRejectedPct.Text = "0"
                    lblTotalItemRejected.Text = "0"
                    lblTotalItemRejectedPct.Text = "0"
                End If
            End With

            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub _openProject(ByVal _projectID As String)
            Dim oPr As New Common.BussinessRules.ProjectHd
            oPr.projectID = _projectID.Trim
            If oPr.SelectOne.Rows.Count > 0 Then
                lblWRNo.Text = oPr.workOrderNo.Trim
                lblProjectCode.Text = oPr.projectCode.Trim
                lblProjectID.Text = oPr.projectID.Trim
            Else
                lblWRNo.Text = String.Empty
                lblProjectCode.Text = String.Empty
                lblProjectID.Text = String.Empty
            End If
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "

#End Region

    End Class

End Namespace