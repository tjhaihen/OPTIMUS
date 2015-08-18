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

    Public Class ProjectMonitoring
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.ProjectMonitoring_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareScreen(True)                
                DataBind()
            End If
        End Sub

        Protected Sub repLevel1_Inspectors_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repLevel1_Inspectors.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)                
                Dim pnlDetail As Panel = CType(e.Item.FindControl("pnlDetail"), Panel)
                Dim pnlNoActivity As Panel = CType(e.Item.FindControl("pnlNoActivity"), Panel)
                Dim repCurrentProject As Repeater = CType(e.Item.FindControl("repCurrentProject"), Repeater)

                Dim dtCurrentProjectByResourceID As DataTable = Me.GetCurrentProjectByResourceID_Level2(row("resourceID").ToString.Trim)
                If dtCurrentProjectByResourceID.Rows.Count > 0 Then
                    pnlDetail.Visible = True
                    pnlNoActivity.Visible = False
                    repCurrentProject.DataSource = dtCurrentProjectByResourceID
                    repCurrentProject.DataBind()
                Else
                    pnlDetail.Visible = False
                    pnlNoActivity.Visible = True
                End If
            End If
        End Sub

        Protected Sub repLevel2_CurrentProject_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim grdHelper As DataGrid = CType(e.Item.FindControl("grdHelper"), DataGrid)
                Dim grdProjectDt As DataGrid = CType(e.Item.FindControl("grdProjectDt"), DataGrid)

                Dim dtResourceByProjectID As DataTable = Me.GetResourceByProjectID_Level3(row("projectID").ToString.Trim, row("resourceID").ToString.Trim)
                grdHelper.DataSource = dtResourceByProjectID
                grdHelper.DataBind()

                Dim dtProjectDtByProjectID As DataTable = Me.GetProjectDtByProjectID_Level3(row("projectID").ToString.Trim)
                grdProjectDt.DataSource = dtProjectDtByProjectID
                grdProjectDt.DataBind()
            End If
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
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    GetProjectMonitoringData_Level1()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            GetProjectMonitoringData_Level1()
        End Sub

        Private Sub GetProjectMonitoringData_Level1()
            Dim oBR As New Common.BussinessRules.Resource
            With oBR
                oBR.resourceTypeSCode = Common.Constants.ResourceType.ResourceType_Inspector
                repLevel1_Inspectors.DataSource = oBR.SelectResourcesByResourceType
                repLevel1_Inspectors.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Function GetCurrentProjectByResourceID_Level2(ByVal strResourceID As String) As DataTable
            Dim dt As DataTable
            Dim oBR As New Common.BussinessRules.ProjectHd
            dt = oBR.GetCurrentProjectByResourceID(strResourceID)
            oBR.Dispose()
            oBR = Nothing
            Return dt
        End Function

        Private Function GetResourceByProjectID_Level3(ByVal strProjectID As String, ByVal strResourceIDToExclude As String) As DataTable
            Dim dt As DataTable
            Dim oBR As New Common.BussinessRules.ProjectResource
            oBR.ProjectID = strProjectID.Trim
            dt = oBR.GetResourceByProjectIDExcludeResoureID(strResourceIDToExclude)
            oBR.Dispose()
            oBR = Nothing
            Return dt
        End Function

        Private Function GetProjectDtByProjectID_Level3(ByVal strProjectID As String) As DataTable
            Dim dt As DataTable
            Dim oBR As New Common.BussinessRules.ProjectDt
            oBR.ProjectID = strProjectID.Trim
            dt = oBR.SelectByProjectID
            oBR.Dispose()
            oBR = Nothing
            Return dt
        End Function
#End Region


#Region " C,R,U,D "
        
#End Region
    End Class

End Namespace