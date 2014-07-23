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

    Public Class Customer
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Customer_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchParentCustomer.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Customer", txtParentCustomerCode.ClientID))

                prepareScreen(True)
                SetDataGridCustomer()
                DataBind()
            End If
        End Sub

        Private Sub txtCustomerCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtCustomerName.ClientID)
        End Sub

        Private Sub txtParentCustomerCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParentCustomerCode.TextChanged
            _openParentCustomer()            
        End Sub

        Private Sub grdCustomer_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCustomer.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtCustomerCode.Text = CType(e.Item.FindControl("_lblCustomerCode"), Label).Text.Trim
                    _open(BussinessRules.RavenRecStatus.CurrentRecord)
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

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtCustomerID.Text = String.Empty
            txtParentCustomerID.Text = String.Empty
            txtCustomerName.Text = String.Empty
            txtParentCustomerName.Text = String.Empty
            chkIsActive.Checked = True
            If isNew Then
                txtCustomerCode.Text = String.Empty
                commonFunction.Focus(Me, txtCustomerCode.ClientID)
            Else
                commonFunction.Focus(Me, txtCustomerName.ClientID)
            End If
            txtParentCustomerCode.Text = String.Empty
            txtAddress1.Text = String.Empty
            txtAddress2.Text = String.Empty
            txtAddress3.Text = String.Empty
            txtCity.Text = String.Empty
            txtPostalCode.Text = String.Empty
            txtPhone.Text = String.Empty
            txtMobile.Text = String.Empty
            txtFax.Text = String.Empty
            txtEmail.Text = String.Empty
            txtUrl.Text = String.Empty
        End Sub

        Private Sub SetDataGridCustomer()
            Dim oCustomer As New Common.BussinessRules.Customer
            grdCustomer.DataSource = oCustomer.SelectAll
            grdCustomer.DataBind()
            oCustomer.Dispose()
            oCustomer = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oCustomer As New Common.BussinessRules.Customer
            With oCustomer
                txtCustomerID.Text = Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID")
                .CustomerID = txtCustomerID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtCustomerCode.Text = .CustomerCode.Trim
                    txtCustomerName.Text = .CustomerName.Trim
                    txtAddress1.Text = .Address1.Trim
                    txtAddress2.Text = .Address2.Trim
                    txtAddress3.Text = .Address3.Trim
                    txtCity.Text = .City.Trim
                    txtPostalCode.Text = .PostalCode.Trim
                    txtPhone.Text = .Phone.Trim
                    txtMobile.Text = .Mobile.Trim
                    txtFax.Text = .Fax.Trim
                    txtEmail.Text = .Email.Trim
                    txtUrl.Text = .Url.Trim
                    chkIsActive.Checked = .IsActive

                    txtParentCustomerID.Text = .ParentCustomerID.Trim
                    If Len(txtParentCustomerID.Text.Trim) > 0 Then
                        .CustomerID = txtParentCustomerID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            txtParentCustomerCode.Text = .CustomerCode.Trim
                            txtParentCustomerName.Text = .CustomerName.Trim
                        Else
                            txtParentCustomerID.Text = String.Empty
                            txtParentCustomerCode.Text = String.Empty
                            txtParentCustomerName.Text = String.Empty
                        End If
                    End If
                Else
                    prepareScreen(False)
                End If
            End With
            oCustomer.Dispose()
            oCustomer = Nothing
        End Sub

        Private Sub _openParentCustomer()
            Dim oCustomer As New Common.BussinessRules.Customer
            With oCustomer
                txtParentCustomerID.Text = Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtParentCustomerCode.Text.Trim, "CustomerID")
                If txtParentCustomerID.Text.Trim = txtCustomerID.Text.Trim Then
                    commonFunction.MsgBox(Me, "Parent Customer tidak boleh sama dengan Customer itu sendiri.")
                    Exit Sub
                End If
                .CustomerID = txtParentCustomerID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtParentCustomerName.Text = .CustomerName.Trim
                Else
                    txtParentCustomerID.Text = String.Empty
                    txtParentCustomerCode.Text = String.Empty
                    txtParentCustomerName.Text = String.Empty
                End If
            End With
            oCustomer.Dispose()
            oCustomer = Nothing
        End Sub

        Private Sub _delete()
            Dim oCustomer As New Common.BussinessRules.Customer
            oCustomer.CustomerID = txtCustomerID.Text.Trim
            If oCustomer.Delete() Then
                prepareScreen(True)
            End If
            oCustomer.Dispose()
            oCustomer = Nothing
            SetDataGridCustomer()
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oCustomer As New Common.BussinessRules.Customer
            With oCustomer
                .CustomerID = txtCustomerID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .ParentCustomerID = txtParentCustomerID.Text.Trim
                .CustomerCode = txtCustomerCode.Text.Trim
                .CustomerName = txtCustomerName.Text.Trim
                .Address1 = txtAddress1.Text.Trim
                .Address2 = txtAddress2.Text.Trim
                .Address3 = txtAddress3.Text.Trim
                .City = txtCity.Text.Trim
                .PostalCode = txtPostalCode.Text.Trim
                .Phone = txtPhone.Text.Trim
                .Mobile = txtMobile.Text.Trim
                .Fax = txtFax.Text.Trim
                .Email = txtEmail.Text.Trim
                .Url = txtUrl.Text.Trim
                .IsActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtCustomerID.Text = .CustomerID
                Else
                    .Update()
                End If
            End With
            oCustomer.Dispose()
            oCustomer = Nothing
            prepareScreen(True)
            SetDataGridCustomer()
        End Sub
#End Region
    End Class

End Namespace