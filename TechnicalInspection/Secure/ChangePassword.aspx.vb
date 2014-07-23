Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure

    Public Class ChangePassword
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.ChangePassword_MenuID
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
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtCurrentPassword.Text = String.Empty
            txtNewPassword.Text = String.Empty
            commonFunction.Focus(Me, txtCurrentPassword.ClientID)
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oRsrc As New Common.BussinessRules.User
            With oRsrc
                .UserID = MyBase.LoggedOnUserID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    If .Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtCurrentPassword.Text.Trim, "sha1") Then
                        .NewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPassword.Text.Trim, "sha1")
                    Else
                        '// Wrong Current Password
                        commonFunction.MsgBox(Me, "Wrong Current Password.")
                        Exit Sub
                    End If
                End If
                If .UpdatePassword() Then
                    commonFunction.MsgBox(Me, "Password changed successfully.")
                End If
            End With
            oRsrc.Dispose()
            oRsrc = Nothing
            prepareScreen(True)
        End Sub
#End Region

    End Class

End Namespace