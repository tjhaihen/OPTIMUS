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

    Public Class CustomerInspectionInformation
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.CustomerInspectionInformation_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchCustomer.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("UserCustomer", txtCustomerCode.ClientID, MyBase.LoggedOnUserID.Trim))

                prepareDDL()
                prepareScreen(True)
                SetDataGridCustomerInspectionInformation()
                DataBind()
            End If
        End Sub

        Private Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _openCustomer(Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID"))
        End Sub

        Private Sub ddlInformationType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlInformationType.SelectedIndexChanged
            Select Case ddlInformationType.SelectedValue.Trim
                Case "Due"
                    pnlDueCaption.Visible = True
                    pnlDue.Visible = True
                    txtDueIn.Text = "30"
                    pnlHistoryCaption.Visible = False
                    pnlHistory.Visible = False
                Case "History"
                    pnlDueCaption.Visible = False
                    pnlDue.Visible = False
                    pnlHistoryCaption.Visible = True
                    pnlHistory.Visible = True
                    txtLast.Text = "10"
            End Select
        End Sub

        Private Sub grdCustomerInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCustomerInspection.ItemCommand
            Select Case e.CommandName
                Case "Process"
                    Dim _lblProjectCode As Label = CType(e.Item.FindControl("_lblProjectCode"), Label)
                    Response.Redirect(PageBase.UrlBase + "/Secure/Main.aspx?isc=True&pid=" + _lblProjectCode.Text.Trim)
            End Select
        End Sub

        Private Sub grdCustomerInspection_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdCustomerInspection.ItemCreated
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim x As DataRowView = CType(e.Item.DataItem, DataRowView)
                If Not x Is Nothing Then
                    Dim dr As DataRow = x.Row
                    If Not dr Is Nothing Then
                        Dim strOverdue As String = CType(dr("IsOverDue"), String)
                        If strOverdue = "Overdue" Then
                            e.Item.ForeColor = System.Drawing.Color.Red
                        End If
                    End If
                End If
            End If
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
                .VisibleButton(CSSToolbarItem.tidSave) = False
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
                Case CSSToolbarItem.tidRefresh
                    GetDashboardInformation()
                    SetDataGridCustomerInspectionInformation()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtCustomerID.Text = String.Empty
            txtCustomerCode.Text = String.Empty
            txtCustomerName.Text = String.Empty
            ddlInformationType_SelectedIndexChanged(Nothing, Nothing)

            Dim oUC As New Common.BussinessRules.UserCustomer
            With oUC
                If .SelectCustomerByUserID(MyBase.LoggedOnUserID.Trim).Rows.Count = 1 Then                    
                    txtCustomerID.Text = .CustomerID.Trim
                    Dim oC As New Common.BussinessRules.Customer
                    oC.CustomerID = txtCustomerID.Text.Trim
                    If oC.SelectOne.Rows.Count > 0 Then
                        txtCustomerCode.Text = oC.CustomerCode.Trim
                        txtCustomerName.Text = oC.CustomerName.Trim
                    Else
                        txtCustomerCode.Text = String.Empty
                        txtCustomerName.Text = String.Empty
                    End If
                    oC.Dispose()
                    oC = Nothing
                Else
                    txtCustomerID.Text = String.Empty
                End If
            End With
            oUC.Dispose()
            oUC = Nothing
        End Sub

        Private Sub SetDataGridCustomerInspectionInformation()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtInspectionInfo As New DataTable
            With oProject
                Select Case ddlInformationType.SelectedValue.Trim
                    Case "Due"
                        dtInspectionInfo = .GetCustomerInspectionInformation(txtCustomerID.Text.Trim, ddlInformationType.SelectedValue.Trim, CInt(txtDueIn.Text.Trim))
                    Case "History"
                        dtInspectionInfo = .GetCustomerInspectionInformation(txtCustomerID.Text.Trim, ddlInformationType.SelectedValue.Trim, CInt(txtLast.Text.Trim))
                End Select                
            End With
            oProject.Dispose()
            oProject = Nothing

            grdCustomerInspection.DataSource = dtInspectionInfo
            grdCustomerInspection.DataBind()
        End Sub

        Private Sub GetDashboardInformation()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtTotalInspectionByCustomer As New DataTable
            Dim dtItemDueToExpiredInspection As New DataTable
            Dim dtInspectionSerialIDNo As New DataTable
            With oProject
                dtTotalInspectionByCustomer = .GetTotalInspectionByCustomer(txtCustomerID.Text.Trim)
                dtItemDueToExpiredInspection = .GetListOfItemDueToExpiredInspectionByCustomer(txtCustomerID.Text.Trim, CInt(txtItemDueToExpiredInspectionInDay.Text.Trim))
                dtInspectionSerialIDNo = .GetListOfInspectionByCustomerIDSerialIDNo(txtCustomerID.Text.Trim, txtSerialNo.Text.Trim)

                If dtTotalInspectionByCustomer.Rows.Count > 0 Then
                    lblTotalWorkOrder.Text = .totalWorkOrder.ToString.Trim
                    lblTotalItemIspected.Text = .totalItemInspected.ToString.Trim
                    lblTotalItemAccepted.Text = .totalItemAccepted.ToString.Trim
                    lblTotalItemRejected.Text = .totalItemRejected.ToString.Trim
                Else
                    lblTotalWorkOrder.Text = "0"
                    lblTotalItemIspected.Text = "0"
                    lblTotalItemAccepted.Text = "0"
                    lblTotalItemRejected.Text = "0"
                End If
            End With
            oProject.Dispose()
            oProject = Nothing

            grdItemDueToExpiredInspection.DataSource = dtItemDueToExpiredInspection
            grdItemDueToExpiredInspection.DataBind()

            grdInspectionBySerialIDNo.DataSource = dtInspectionSerialIDNo
            grdInspectionBySerialIDNo.DataBind()
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
        
#End Region

    End Class

End Namespace