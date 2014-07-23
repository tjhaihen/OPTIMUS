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

    Public Class Profile
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Profile_MenuID
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
                SetDataGridProfile()
                DataBind()
            End If
        End Sub

        Private Sub txtProfileCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProfileCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtProfileName.ClientID)
        End Sub

        Private Sub grdProfile_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProfile.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProfileCode.Text = CType(e.Item.FindControl("_lblProfileCode"), Label).Text.Trim
                    _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
        End Sub

#Region " Profile Menu "
        Private Sub btnProfileMenuAdd_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuAdd.Click
            _updateProfileMenu(False)
        End Sub

        Private Sub btnProfileMenuAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuAddAll.Click
            _updateProfileMenu(True)
        End Sub

        Private Sub btnProfileMenuRemove_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuRemove.Click
            _deleteProfileMenu(False)
        End Sub

        Private Sub btnProfileMenuRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuRemoveAll.Click
            _deleteProfileMenu(True)
        End Sub
#End Region
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
            txtProfileID.Text = String.Empty
            txtProfileName.Text = String.Empty
            chkIsActive.Checked = True
            chkIsSystem.Checked = False
            If isNew Then
                txtProfileCode.Text = String.Empty
                commonFunction.Focus(Me, txtProfileCode.ClientID)
            Else
                commonFunction.Focus(Me, txtProfileName.ClientID)
            End If

            SetDataGridProfile()
            SetDataGridProfileMenu()
        End Sub

        Private Sub SetDataGridProfile()
            Dim oProd As New Common.BussinessRules.Profile
            grdProfile.DataSource = oProd.SelectAll
            grdProfile.DataBind()
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub SetDataGridProfileMenu()
            Dim oPr As New Common.BussinessRules.ProfileMenu
            grdMenu.DataSource = oPr.SelectMenuNotInProfileMenuByProfileID(txtProfileID.Text.Trim)
            grdMenu.DataBind()
            grdProfileMenu.DataSource = oPr.SelectMenuByProfileID(txtProfileID.Text.Trim)
            grdProfileMenu.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oProd As New Common.BussinessRules.Profile
            With oProd
                txtProfileID.Text = Common.BussinessRules.ID.GetFieldValue("Profile", "ProfileCode", txtProfileCode.Text.Trim, "ProfileID")
                .ProfileID = txtProfileID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtProfileCode.Text = .ProfileCode.Trim
                    txtProfileName.Text = .ProfileName.Trim
                    chkIsActive.Checked = .IsActive
                    chkIsSystem.Checked = .IsSystem
                Else
                    prepareScreen(False)
                End If
            End With
            oProd.Dispose()
            oProd = Nothing

            SetDataGridProfileMenu()            
        End Sub

        Private Sub _delete()
            If Not chkIsSystem.Checked Then
                Dim oProd As New Common.BussinessRules.Profile
                With oProd
                    .ProfileID = txtProfileID.Text.Trim
                    If .Delete() Then
                        prepareScreen(True)
                        SetDataGridProfile()
                    End If
                End With
                oProd.Dispose()
                oProd = Nothing
            Else
                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_IsSystem)
                Exit Sub
            End If

            SetDataGridProfileMenu()
            SetDataGridProfile()
        End Sub

        Private Sub _deleteProfileMenu(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileMenu
            With oPr
                For Each item As DataGridItem In grdProfileMenu.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProfileMenuID As Label = CType(item.FindControl("_lblProfileMenuID"), Label)
                    .ProfileMenuID = lblProfileMenuID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileMenu()
        End Sub

        Private Sub _update()
            If Not chkIsSystem.Checked Then
                Page.Validate()
                If Not Page.IsValid Then Exit Sub
                Dim isNew As Boolean = True

                Dim oProd As New Common.BussinessRules.Profile
                With oProd
                    .ProfileID = txtProfileID.Text.Trim
                    If .SelectOne.Rows.Count > 0 Then
                        isNew = False
                    Else
                        isNew = True
                    End If
                    .ProfileCode = txtProfileCode.Text.Trim
                    .ProfileName = txtProfileName.Text.Trim
                    .IsActive = chkIsActive.Checked
                    .IsSystem = False
                    .UserIDInsert = MyBase.LoggedOnUserID
                    .UserIDUpdate = MyBase.LoggedOnUserID
                    If isNew Then
                        If .Insert() Then txtProfileID.Text = .ProfileID
                    Else
                        .Update()
                    End If
                End With
                oProd.Dispose()
                oProd = Nothing
                prepareScreen(True)                
                SetDataGridProfile()
                SetDataGridProfileMenu()
            Else
                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_IsSystem)
                Exit Sub
            End If
        End Sub

        Private Sub _updateProfileMenu(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileMenu
            With oPr
                For Each item As DataGridItem In grdMenu.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblMenuID As Label = CType(item.FindControl("_lblMenuID"), Label)
                    .ProfileID = txtProfileID.Text.Trim
                    .MenuID = lblMenuID.Text.Trim
                    .isAllowCreate = True
                    .isAllowDelete = True
                    .isAllowRead = True
                    .isAllowUpdate = True
                    .UserIDInsert = MyBase.LoggedOnUserID
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileMenu()
        End Sub
#End Region
    End Class

End Namespace