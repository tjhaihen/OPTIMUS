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
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure

    Public Class Contract
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Contract_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchContract.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Contract", txtContractHdID.ClientID))
                btnSearchCustomer.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Customer", txtCustomerCode.ClientID))
                btnSearchProduct.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Product", txtProductCode.ClientID))

                prepareScreen()
                SetDataGridContractDetail()
                DataBind()
            End If
        End Sub

        Private Sub txtContractHdID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractHdID.TextChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtContractNo.ClientID)
        End Sub

        Private Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _openCustomer(Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID"))
        End Sub

        Private Sub txtProductCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtProductCode.TextChanged
            _openProduct(Common.BussinessRules.ID.GetFieldValue("Product", "ProductCode", txtProductCode.Text.Trim, "ProductID"))
        End Sub

        Private Sub btnAddDetail_Click(sender As Object, e As System.EventArgs) Handles btnAddDetail.Click
            _updateContractDetail()
        End Sub

        Private Sub grdContractDetail_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdContractDetail.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtContractDtID.Text = CType(e.Item.FindControl("_lblContractDtID"), Label).Text.Trim
                    _openContractDetail(txtContractDtID.Text.Trim)
                Case "Delete"
                    txtContractDtID.Text = CType(e.Item.FindControl("_lblContractDtID"), Label).Text.Trim
                    _deleteContractDetail(txtContractDtID.Text.Trim)
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidSave) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = True
                .VisibleButton(CSSToolbarItem.tidPropose) = False
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
                    prepareScreen()
                Case CSSToolbarItem.tidNext
                    _open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen()
            txtContractHdID.Text = String.Empty
            commonFunction.Focus(Me, txtContractNo.ClientID)
            txtContractNo.Text = String.Empty
            txtContractDescription.Text = String.Empty
            calStartDate.selectedDate = Date.Now
            calEndDate.selectedDate = Date.Now
            txtCustomerID.Text = String.Empty
            txtCustomerCode.Text = String.Empty
            txtCustomerName.Text = String.Empty
            txtProductID.Text = String.Empty
            txtProductCode.Text = String.Empty
            txtProductName.Text = String.Empty
            txtDescription.Text = String.Empty
            txtReferenceNo.Text = String.Empty
            txtQty.Text = "1"
            txtUOM.Text = String.Empty
            txtDescriptionDetail.Text = String.Empty

            SetDataGridContractDetail()
            setToolbarVisibleButton()
        End Sub

        Private Sub SetDataGridContractDetail()
            Dim oContractDt As New Common.BussinessRules.ContractDt
            oContractDt.contractHdID = txtContractHdID.Text.Trim
            grdContractDetail.DataSource = oContractDt.SelectByContractHdID
            grdContractDetail.DataBind()
            oContractDt.Dispose()
            oContractDt = Nothing
        End Sub

        Private Function _openUser(ByVal strUserID As String) As String
            Dim strToReturn As String = String.Empty
            Dim oUser As New Common.BussinessRules.User
            With oUser
                .UserID = strUserID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    strToReturn = .UserName.Trim
                Else
                    strToReturn = String.Empty
                End If
            End With
            oUser.Dispose()
            oUser = Nothing
            Return strToReturn.Trim
        End Function
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oContractHd As New Common.BussinessRules.ContractHd
            With oContractHd
                .contractHdID = txtContractHdID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtContractNo.Text = .contractNo.Trim
                    txtContractDescription.Text = .description.Trim
                    calStartDate.selectedDate = .startDate
                    calEndDate.selectedDate = .endDate
                    txtCustomerID.Text = .customerID.Trim
                    _openCustomer(.customerID.Trim)
                Else
                    prepareScreen()
                End If
            End With
            oContractHd.Dispose()
            oContractHd = Nothing

            SetDataGridContractDetail()
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

        Private Sub _openProduct(ByVal _productID As String)
            Dim oProduct As New Common.BussinessRules.Product
            oProduct.productID = _productID.Trim
            If oProduct.SelectOne.Rows.Count > 0 Then
                txtProductID.Text = _productID.Trim
                txtProductCode.Text = oProduct.productCode.Trim
                txtProductName.Text = oProduct.productName.Trim
            Else
                txtProductID.Text = String.Empty
                txtProductCode.Text = String.Empty
                txtProductName.Text = String.Empty
            End If
            oProduct.Dispose()
            oProduct = Nothing
        End Sub

        Private Sub _openContractDetail(ByVal _contractDtID As String)
            Dim oContractDt As New Common.BussinessRules.ContractDt
            oContractDt.contractDtID = _contractDtID.Trim
            If oContractDt.SelectOne.Rows.Count > 0 Then
                txtDescription.Text = oContractDt.description.Trim
                txtReferenceNo.Text = oContractDt.referenceNo.Trim
                txtQty.Text = oContractDt.qty.ToString.Trim
                txtUOM.Text = oContractDt.unitOfMeasurement.Trim
                txtDescriptionDetail.Text = oContractDt.descriptionDetail.Trim
            Else
                txtDescription.Text = String.Empty
                txtReferenceNo.Text = String.Empty
                txtQty.Text = "1"
                txtUOM.Text = String.Empty
                txtDescriptionDetail.Text = String.Empty
            End If
            oContractDt.Dispose()
            oContractDt = Nothing
        End Sub

        Private Sub _delete()
            Dim oContractHd As New Common.BussinessRules.ContractHd
            oContractHd.contractHdID = txtContractHdID.Text.Trim
            If oContractHd.Delete() Then
                prepareScreen()
            End If
            oContractHd.Dispose()
            oContractHd = Nothing
            SetDataGridContractDetail()
        End Sub

        Private Sub _deleteContractDetail(ByVal _contractDtID As String)
            Dim oPr As New Common.BussinessRules.ContractDt
            With oPr
                .contractDtID = _contractDtID.Trim
                .Delete()
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridContractDetail()
            commonFunction.Focus(Me, txtDescription.ClientID)
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oContractHd As New Common.BussinessRules.ContractHd
            With oContractHd
                .contractHdID = txtContractHdID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .contractNo = txtContractNo.Text.Trim
                .description = txtContractDescription.Text.Trim
                .startDate = calStartDate.selectedDate
                .endDate = calEndDate.selectedDate
                .customerID = txtCustomerID.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then
                        txtContractHdID.Text = .contractHdID.Trim
                    End If
                Else
                    If .Update() Then
                    End If
                End If
            End With
            oContractHd.Dispose()
            oContractHd = Nothing
        End Sub

        Private Sub _updateContractDetail()
            If txtContractHdID.Text.Trim.Length = 0 Then
                commonFunction.MsgBox(Me, "Please save Contract first.")
                Exit Sub
            End If

            Dim oPr As New Common.BussinessRules.ContractDt
            With oPr
                .contractHdID = txtContractHdID.Text.Trim
                .description = txtDescription.Text.Trim
                .referenceNo = txtReferenceNo.Text.Trim
                .qty = CDec(txtQty.Text.Trim)
                .unitOfMeasurement = txtUOM.Text.Trim
                .productID = txtProductID.Text.Trim
                .descriptionDetail = txtDescriptionDetail.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                .Insert()
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridContractDetail()
            commonFunction.Focus(Me, txtContractNo.ClientID)
        End Sub

#End Region

    End Class

End Namespace