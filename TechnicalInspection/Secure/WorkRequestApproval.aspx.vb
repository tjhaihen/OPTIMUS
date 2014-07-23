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

    Public Class WorkRequestApproval
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.WorkRequestApproval_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchCustomer.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Customer", txtCustomerCode.ClientID))

                prepareScreen(True)
                SetDataGrid()
                DataBind()
            End If
        End Sub

        Private Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _openCustomer(Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID"))
        End Sub

        Private Sub ddlWRStatus_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlWRStatus.SelectedIndexChanged
            Select Case ddlWRStatus.SelectedValue.Trim
                Case "Proposed"
                    pnlApprovedCaption.Visible = False
                    pnlApprovedHistory.Visible = False
                    txtLast.Text = "0"
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                Case "Approved"
                    pnlApprovedCaption.Visible = True
                    pnlApprovedHistory.Visible = True
                    txtLast.Text = "10"
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = True
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    SetDataGrid()
                Case CSSToolbarItem.tidApprove
                    _updateApproval(True)
                Case CSSToolbarItem.tidVoid
                    _updateApproval(False)
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtCustomerID.Text = String.Empty
            txtCustomerCode.Text = String.Empty
            txtCustomerName.Text = String.Empty
            ddlWRStatus_SelectedIndexChanged(Nothing, Nothing)
        End Sub

        Private Sub SetDataGrid()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtInspectionInfo As New DataTable
            dtInspectionInfo = oProject.GetInspectionInformation(txtCustomerID.Text.Trim, ddlWRStatus.SelectedValue.Trim, CInt(txtLast.Text.Trim))
            oProject.Dispose()
            oProject = Nothing

            grdInspection.DataSource = dtInspectionInfo
            grdInspection.DataBind()
        End Sub

        Private Sub _openCustomer(ByVal _customerID As String)
            Dim oCustomer As New Common.BussinessRules.Customer
            oCustomer.CustomerID = _customerID.Trim
            If oCustomer.SelectOne.Rows.Count > 0 Then
                txtCustomerID.Text = _customerID.Trim
                txtCustomerCode.Text = oCustomer.CustomerCode.Trim
                txtCustomerName.Text = oCustomer.CustomerName.Trim
            Else
                txtCustomerID.Text = String.Empty
                txtCustomerCode.Text = String.Empty
                txtCustomerName.Text = String.Empty
            End If
            oCustomer.Dispose()
            oCustomer = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _updateApproval(ByVal isApproval As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectHd
            With oPr
                For Each item As DataGridItem In grdInspection.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectID As Label = CType(item.FindControl("_lblProjectID"), Label)
                    .projectID = lblProjectID.Text.Trim
                    .isApproval = isApproval
                    .approvalBy = MyBase.LoggedOnUserID
                    If chkSelect.Checked Then .UpdateApproval()
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGrid()
        End Sub
#End Region

    End Class

End Namespace