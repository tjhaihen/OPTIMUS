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

    Public Class ReportType
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.ReportType_MenuID
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
                SetDataGridReportType()
                DataBind()
            End If
        End Sub

        Private Sub txtReportTypeCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReportTypeCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtReportTypeName.ClientID)
        End Sub

        Private Sub grdReportType_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdReportType.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtReportTypeCode.Text = CType(e.Item.FindControl("_lblReportTypeCode"), Label).Text.Trim
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
            txtReportTypeID.Text = String.Empty
            txtReportTypeName.Text = String.Empty
            txtSequence.Text = String.Empty
            txtDocumentNo.Text = String.Empty
            txtRevisionNo.Text = String.Empty
            calEffectiveDate.selectedDate = Nothing
            chkIsNoEffectiveDate.Checked = True
            chkIsMandatory.Checked = False
            txtPanelID.Text = String.Empty
            chkIsActive.Checked = True
            If isNew Then
                txtReportTypeCode.Text = String.Empty
                commonFunction.Focus(Me, txtReportTypeCode.ClientID)
            Else
                commonFunction.Focus(Me, txtReportTypeName.ClientID)
            End If
        End Sub

        Private Sub SetDataGridReportType()
            Dim oProd As New Common.BussinessRules.ReportType
            grdReportType.DataSource = oProd.SelectAll
            grdReportType.DataBind()
            oProd.Dispose()
            oProd = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oProd As New Common.BussinessRules.ReportType
            With oProd
                txtReportTypeID.Text = Common.BussinessRules.ID.GetFieldValue("ReportType", "ReportTypeCode", txtReportTypeCode.Text.Trim, "ReportTypeID")
                .ReportTypeID = txtReportTypeID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtReportTypeCode.Text = .ReportTypeCode.Trim
                    txtReportTypeName.Text = .reportTypeName.Trim
                    txtSequence.Text = .sequence.Trim
                    txtPanelID.Text = .panelID.Trim
                    chkIsActive.Checked = .isActive
                    txtDocumentNo.Text = .documentNo.Trim
                    txtRevisionNo.Text = .revisionNo.Trim
                    If .effectiveDate <> Nothing Then
                        calEffectiveDate.selectedDate = .effectiveDate
                        chkIsNoEffectiveDate.Checked = False
                    Else
                        calEffectiveDate.selectedDate = Nothing
                        chkIsNoEffectiveDate.Checked = True
                    End If
                    chkIsMandatory.Checked = .isMandatory
                Else
                    prepareScreen(False)
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub _delete()
            Dim oProd As New Common.BussinessRules.ReportType
            With oProd
                .ReportTypeID = txtReportTypeID.Text.Trim
                If .Delete() Then
                    prepareScreen(True)
                    SetDataGridReportType()
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If calEffectiveDate.selectedDate = Nothing And chkIsNoEffectiveDate.Checked = False Then
                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_EffeciveDateCannotEmpty)
                Exit Sub
            End If

            Dim isNew As Boolean = True

            Dim oProd As New Common.BussinessRules.ReportType
            With oProd
                .ReportTypeID = txtReportTypeID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .ReportTypeCode = txtReportTypeCode.Text.Trim
                .parentReportTypeCode = String.Empty
                .reportTypeName = txtReportTypeName.Text.Trim
                .sequence = txtSequence.Text.Trim
                .panelID = txtPanelID.Text.Trim
                .isActive = chkIsActive.Checked
                .documentNo = txtDocumentNo.Text.Trim
                .revisionNo = txtRevisionNo.Text.Trim
                If calEffectiveDate.selectedDate = Nothing Or chkIsNoEffectiveDate.Checked Then
                    .effectiveDate = Nothing
                Else
                    .effectiveDate = calEffectiveDate.selectedDate
                End If
                .isMandatory = chkIsMandatory.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtReportTypeID.Text = .ReportTypeID
                Else
                    .Update()
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
            prepareScreen(True)
            SetDataGridReportType()
        End Sub
#End Region
    End Class

End Namespace