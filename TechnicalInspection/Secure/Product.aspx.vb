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

    Public Class Product
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "        
        Private MenuID As String = Common.Constants.MenuID.Product_MenuID
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
                SetDataGridProduct()
                DataBind()
            End If
        End Sub

        Private Sub txtProductCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtProductName.ClientID)
        End Sub

        Private Sub grdProduct_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProduct.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProductCode.Text = CType(e.Item.FindControl("_lblProductCode"), Label).Text.Trim
                    _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
        End Sub

#Region " Product Report Type "
        Private Sub btnProductReportTypeAdd_Click(sender As Object, e As System.EventArgs) Handles btnProductReportTypeAdd.Click
            _updateProductReportType(False)
        End Sub

        Private Sub btnProductReportTypeAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProductReportTypeAddAll.Click
            _updateProductReportType(True)
        End Sub

        Private Sub btnProductReportTypeRemove_Click(sender As Object, e As System.EventArgs) Handles btnProductReportTypeRemove.Click
            _deleteProductReportType(False)
        End Sub

        Private Sub btnProductReportTypeRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProductReportTypeRemoveAll.Click
            _deleteProductReportType(True)
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
            txtProductID.Text = String.Empty            
            txtProductName.Text = String.Empty
            chkIsActive.Checked = True
            If isNew Then
                txtProductCode.Text = String.Empty
                commonFunction.Focus(Me, txtProductCode.ClientID)
            Else
                commonFunction.Focus(Me, txtProductName.ClientID)
            End If
        End Sub

        Private Sub SetDataGridProduct()
            Dim oProd As New Common.BussinessRules.Product
            grdProduct.DataSource = oProd.SelectAll
            grdProduct.DataBind()
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub SetDataGridProductReportType()
            Dim oPr As New Common.BussinessRules.ProductReportType
            oPr.ProductID = txtProductID.Text.Trim
            grdReportType.DataSource = oPr.SelectReportTypeNotInProdctReportType()
            grdReportType.DataBind()
            grdProductReportType.DataSource = oPr.SelectReportTypeByProductID()
            grdProductReportType.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oProd As New Common.BussinessRules.Product
            With oProd
                txtProductID.Text = Common.BussinessRules.ID.GetFieldValue("Product", "ProductCode", txtProductCode.Text.Trim, "ProductID")
                .productID = txtProductID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtProductCode.Text = .productCode.Trim
                    txtProductName.Text = .productName.Trim
                    chkIsActive.Checked = .isActive
                Else
                    prepareScreen(False)
                End If
            End With
            oProd.Dispose()
            oProd = Nothing

            SetDataGridProductReportType()
        End Sub

        Private Sub _delete()
            Dim oProd As New Common.BussinessRules.Product
            With oProd
                .productID = txtProductID.Text.Trim
                If .Delete() Then
                    prepareScreen(True)
                    SetDataGridProduct()
                End If                
            End With
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub _deleteProductReportType(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProductReportType
            With oPr
                For Each item As DataGridItem In grdProductReportType.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProductReportTypeID As Label = CType(item.FindControl("_lblProductReportTypeID"), Label)
                    .ProductReportTypeID = lblProductReportTypeID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProductReportType()
        End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oProd As New Common.BussinessRules.Product
            With oProd
                .productID = txtProductID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .productCode = txtProductCode.Text.Trim
                .parentProductCode = String.Empty
                .productName = txtProductName.Text.Trim
                .isActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtProductID.Text = .productID
                Else
                    .Update()
                End If
            End With
            oProd.Dispose()
            oProd = Nothing
            prepareScreen(True)
            SetDataGridProduct()
        End Sub

        Private Sub _updateProductReportType(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProductReportType
            With oPr
                For Each item As DataGridItem In grdReportType.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblReportTypeID As Label = CType(item.FindControl("_lblReportTypeID"), Label)
                    .ProductID = txtProductID.Text.Trim
                    .ReportTypeID = lblReportTypeID.Text.Trim
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

            SetDataGridProductReportType()
        End Sub
#End Region
    End Class

End Namespace