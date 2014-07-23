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

    Public Class Site
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Site_MenuID
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
                SetDataGridSite()
                DataBind()
            End If
        End Sub

        Private Sub txtSiteCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSiteCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtSiteName.ClientID)
        End Sub

        Private Sub grdSite_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdSite.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtSiteCode.Text = CType(e.Item.FindControl("_lblSiteCode"), Label).Text.Trim
                    _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    _delete()
                Case CSSToolbarItem.tidNew
                    prepareScreen(True)
                Case CSSToolbarItem.tidNext
                    _Open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _Open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtSiteID.Text = String.Empty
            txtSiteName.Text = String.Empty
            chkIsActive.Checked = True
            If isNew Then
                txtSiteCode.Text = String.Empty
                commonFunction.Focus(Me, txtSiteCode.ClientID)
            Else
                commonFunction.Focus(Me, txtSiteName.ClientID)
            End If
        End Sub

        Private Sub SetDataGridSite()
            Dim oProd As New Common.BussinessRules.Site
            grdSite.DataSource = oProd.SelectAll
            grdSite.DataBind()
            oProd.Dispose()
            oProd = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oProd As New Common.BussinessRules.Site
            With oProd
                txtSiteID.Text = Common.BussinessRules.ID.GetFieldValue("Site", "SiteCode", txtSiteCode.Text.Trim, "SiteID")
                .SiteID = txtSiteID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtSiteCode.Text = .SiteCode.Trim
                    txtSiteName.Text = .SiteName.Trim
                    chkIsActive.Checked = .isActive
                Else
                    prepareScreen(False)
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub _delete()
            Dim oProd As New Common.BussinessRules.Site
            With oProd
                .SiteID = txtSiteID.Text.Trim
                If .Delete() Then
                    prepareScreen(True)
                    SetDataGridSite()
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oProd As New Common.BussinessRules.Site
            With oProd
                .SiteID = txtSiteID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .SiteCode = txtSiteCode.Text.Trim
                .SiteName = txtSiteName.Text.Trim
                .isActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtSiteID.Text = .SiteID
                Else
                    .Update()
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
            prepareScreen(True)
            SetDataGridSite()
        End Sub
#End Region
    End Class

End Namespace