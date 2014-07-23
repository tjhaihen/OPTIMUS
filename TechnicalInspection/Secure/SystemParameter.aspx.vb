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

    Public Class SystemParameter
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.SystemParameter_MenuID
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
                SetDataGridSystemParameter()
                DataBind()
            End If
        End Sub

        Private Sub txtCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtValue.ClientID)
        End Sub

        Private Sub grdSystemParameter_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdSystemParameter.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtCode.Text = CType(e.Item.FindControl("_lblCode"), Label).Text.Trim
                    _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
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
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
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
            txtCode.Text = String.Empty
            txtCaption.Text = String.Empty
            txtRemark.Text = String.Empty
            txtValue.Text = String.Empty
            chkIsSystem.Checked = False            
        End Sub

        Private Sub SetDataGridSystemParameter()
            grdSystemParameter.DataSource = Common.SystemParameter.SelectAll
            grdSystemParameter.DataBind()
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oSysPar As New Common.SystemParameter
            With oSysPar
                Common.SystemParameter.Code = txtCode.Text.Trim
                If Common.SystemParameter.SelectOne.Rows.Count > 0 Then
                    txtCaption.Text = Common.SystemParameter.Caption.Trim
                    txtRemark.Text = Common.SystemParameter.Remark.Trim
                    txtValue.Text = Common.SystemParameter.Value.Trim
                    chkIsSystem.Checked = Common.SystemParameter.IsSystem
                Else
                    prepareScreen(False)
                End If
            End With
        End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Common.SystemParameter.Code = txtCode.Text.Trim
            Common.SystemParameter.Value = txtValue.Text.Trim
            Common.SystemParameter.UserIDUpdate = MyBase.LoggedOnUserID
            Common.SystemParameter.Update()

            prepareScreen(True)
            SetDataGridSystemParameter()
        End Sub
#End Region
    End Class

End Namespace