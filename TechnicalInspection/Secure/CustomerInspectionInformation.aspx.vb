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
                btnSearchProduct.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Product", txtProductCode.ClientID))

                prepareDDL()
                prepareScreen(True)
                SetDataGridCustomerInspectionInformation()
                DataBind()
            End If
        End Sub

        Private Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _openCustomer(Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID"))
        End Sub

        Private Sub txtProductCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtProductCode.TextChanged
            _openProduct(Common.BussinessRules.ID.GetFieldValue("Product", "ProductCode", txtProductCode.Text.Trim, "ProductID"))
        End Sub

        Private Sub txtWorkOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtWorkOrderNo.TextChanged
            _openProjectByWorkOrderNo()
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

        Private Sub ddlInformationTypeSOI_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlInformationTypeSOI.SelectedIndexChanged
            Select Case ddlInformationTypeSOI.SelectedValue.Trim
                Case "Due"
                    pnlDueToExpired.Visible = True
                    pnlPeriod.Visible = False
                    pnlInspectionTotalSummary.Visible = False
                    txtItemDueToExpiredInspectionInDay.Text = "30"
                Case "History"
                    pnlDueToExpired.Visible = False
                    pnlPeriod.Visible = True
                    pnlInspectionTotalSummary.Visible = True
                    ddlPeriod.SelectedIndex = 0
                    ddlPeriod_SelectedIndexChanged(Nothing, Nothing)
            End Select
        End Sub

        Private Sub ddlPeriod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPeriod.SelectedIndexChanged
            Select Case ddlPeriod.SelectedValue.Trim
                Case "ThisMonth"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month + 1, 1 - 1)
                Case "LastMonth"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1 + 1, 1 - 1)
                Case "ThisYear"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, 12 + 1, 1 - 1)
                Case "LastYear"
                    pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year - 1, 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year - 1, 12 + 1, 1 - 1)
                Case Else
                    pnlCustomPeriod.Visible = True
                    calStartDate.selectedDate = Date.Today
                    calEndDate.selectedDate = Date.Today
            End Select
        End Sub

        Private Sub chkPeriod_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkPeriod.CheckedChanged
            ddlPeriod.Enabled = chkPeriod.Checked
            ddlInformationTypeSOI.Enabled = chkPeriod.Checked
            If chkPeriod.Checked = True Then
                txtProjectID.Text = String.Empty
                txtProjectCode.Text = String.Empty
                txtWorkOrderNo.Text = String.Empty
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            Else
                ddlInformationTypeSOI.SelectedIndex = 0
                ddlPeriod.SelectedIndex = 0
                ddlPeriod_SelectedIndexChanged(Nothing, Nothing)
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            End If
        End Sub

        Private Sub grdCustomerInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCustomerInspection.ItemCommand
            Select Case e.CommandName
                Case "Preview"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Response.Write("<script language=javascript>window.open('" + PageBase.UrlBase + "/Secure/CustomerInspectionInformationDetail.aspx?isc=True&pid=" + _lblProjectID.Text.Trim + "','CustomerViewDetail','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
                Case "PreviewByWR"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Dim _lblProjectCode As Label = CType(e.Item.FindControl("_lblProjectCode"), Label)
                    Dim _lblWorkOrderNo As Label = CType(e.Item.FindControl("_lblWorkOrderNo"), Label)
                    rtsInspectionInformation.Tabs(1).Selected = True
                    rmpInspectionInformation.PageViews(1).Selected = True
                    txtWorkOrderNo.Text = _lblWorkOrderNo.Text.Trim
                    txtProjectCode.Text = _lblProjectCode.Text.Trim
                    txtProjectID.Text = _lblProjectID.Text.Trim
                    chkPeriod.Checked = False
                    chkPeriod_CheckedChanged(Nothing, Nothing)
                    GetSummaryOfInspectionByProjectIDStatus(txtProjectID.Text.Trim, String.Empty)
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            End Select
        End Sub

        Private Sub grdItemDueToExpiredInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdItemDueToExpiredInspection.ItemCommand
            Select Case e.CommandName
                Case "Preview"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Response.Write("<script language=javascript>window.open('" + PageBase.UrlBase + "/Secure/CustomerInspectionInformationDetail.aspx?isc=True&pid=" + _lblProjectID.Text.Trim + "','CustomerViewDetail','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
            End Select
        End Sub

        Private Sub lbtnAccepted_Click(sender As Object, e As System.EventArgs) Handles lbtnAccepted.Click
            If txtProjectID.Text.Trim.Length = 0 Then
                GetSummaryOfInspectionByStatus(Common.Constants.SOIStatus.Status_Accept)
            Else
                GetSummaryOfInspectionByProjectIDStatus(txtProjectID.Text.Trim, Common.Constants.SOIStatus.Status_Accept)
            End If
        End Sub

        Private Sub lbtnRepair_Click(sender As Object, e As System.EventArgs) Handles lbtnRepair.Click
            If txtProjectID.Text.Trim.Length = 0 Then
                GetSummaryOfInspectionByStatus(Common.Constants.SOIStatus.Status_Repair)
            Else
                GetSummaryOfInspectionByProjectIDStatus(txtProjectID.Text.Trim, Common.Constants.SOIStatus.Status_Repair)
            End If
        End Sub

        Private Sub lbtnRejected_Click(sender As Object, e As System.EventArgs) Handles lbtnRejected.Click
            If txtProjectID.Text.Trim.Length = 0 Then
                GetSummaryOfInspectionByStatus(Common.Constants.SOIStatus.Status_Reject)
            Else
                GetSummaryOfInspectionByProjectIDStatus(txtProjectID.Text.Trim, Common.Constants.SOIStatus.Status_Reject)
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
                .VisibleButton(CSSToolbarItem.tidDownload) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    SetDataGridCustomerInspectionInformation()
                    SetDataGridSummaryOfInspection()
                    SetDataGridHistoryOfInspectionBySerialNo()
                    If chkPeriod.Checked Then
                        GetDashboardInformation()
                    Else
                        GetSummaryOfInspectionByProjectIDStatus(txtProjectID.Text.Trim, String.Empty)
                    End If

                Case CSSToolbarItem.tidDownload
                    Dim oRPT As New Common.BussinessRules.MyReport
                    oRPT.AddParameters(txtProjectID.Text.Trim)
                    oRPT.ReportCode = Common.Constants.ReportID.DownloadSummaryOfInspection_ReportID
                    oRPT.GetReportDataByReportCode()
                    If oRPT.ReportFormat = "XLS" Then
                        oRPT.ExportToExcel(oRPT.generateReportDataTable, Response)
                    End If
                    oRPT.Dispose()
                    oRPT = Nothing
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Period(ddlPeriod)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtCustomerID.Text = String.Empty
            txtCustomerCode.Text = String.Empty
            txtCustomerName.Text = String.Empty
            txtProductID.Text = String.Empty
            txtProductCode.Text = String.Empty
            txtProductName.Text = String.Empty
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

            ddlInformationTypeSOI.SelectedIndex = 0
            ddlInformationTypeSOI_SelectedIndexChanged(Nothing, Nothing)
            ddlPeriod.SelectedIndex = 0
            pnlCustomPeriod.Visible = False
            calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month, 1)
            calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month + 1, 1 - 1)

            ddlInformationTypeSOI.Enabled = True
            chkPeriod.Checked = True
            ddlPeriod.Enabled = True
            txtWorkOrderNo.Text = String.Empty
            txtProjectCode.Text = String.Empty
            txtProjectID.Text = String.Empty            
        End Sub

        Private Sub SetDataGridCustomerInspectionInformation()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtInspectionInfo As New DataTable
            With oProject
                Select Case ddlInformationType.SelectedValue.Trim
                    Case "Due"
                        dtInspectionInfo = .GetCustomerInspectionInformation(txtCustomerID.Text.Trim, txtProductID.Text.Trim, ddlInformationType.SelectedValue.Trim, CInt(txtDueIn.Text.Trim))
                    Case "History"
                        dtInspectionInfo = .GetCustomerInspectionInformation(txtCustomerID.Text.Trim, txtProductID.Text.Trim, ddlInformationType.SelectedValue.Trim, CInt(txtLast.Text.Trim))
                End Select
            End With
            oProject.Dispose()
            oProject = Nothing

            grdCustomerInspection.DataSource = dtInspectionInfo
            grdCustomerInspection.DataBind()
        End Sub

        Private Sub SetDataGridSummaryOfInspection()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtItemDueToExpiredInspection As New DataTable
            With oProject
                dtItemDueToExpiredInspection = .GetListOfItemDueToExpiredInspectionByCustomer(txtCustomerID.Text.Trim, ddlInformationTypeSOI.SelectedValue.Trim, CInt(txtItemDueToExpiredInspectionInDay.Text.Trim), calStartDate.selectedDate, calEndDate.selectedDate, txtProductID.Text.Trim)
            End With
            oProject.Dispose()
            oProject = Nothing

            grdItemDueToExpiredInspection.DataSource = dtItemDueToExpiredInspection
            grdItemDueToExpiredInspection.DataBind()
        End Sub

        Private Sub SetDataGridHistoryOfInspectionBySerialNo()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtInspectionSerialIDNo As New DataTable
            With oProject
                dtInspectionSerialIDNo = .GetListOfInspectionByCustomerIDSerialIDNo(txtCustomerID.Text.Trim, txtSerialNo.Text.Trim, txtProductID.Text.Trim)
            End With
            oProject.Dispose()
            oProject = Nothing

            grdInspectionBySerialIDNo.DataSource = dtInspectionSerialIDNo
            grdInspectionBySerialIDNo.DataBind()
        End Sub

        Private Sub GetDashboardInformation()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtTotalInspectionByCustomer As New DataTable

            With oProject
                dtTotalInspectionByCustomer = .GetTotalInspectionByCustomer(txtCustomerID.Text.Trim, calStartDate.selectedDate, calEndDate.selectedDate, txtProductID.Text.Trim)

                If dtTotalInspectionByCustomer.Rows.Count > 0 Then
                    lblTotalWorkOrder.Text = .totalWorkOrder.ToString.Trim
                    lblTotalItemIspected.Text = .totalItemInspected.ToString.Trim
                    lblTotalItemAccepted.Text = .totalItemAccepted.ToString.Trim
                    lblTotalItemNeedRepair.Text = .totalItemNeedRepair.ToString.Trim
                    lblTotalItemRejected.Text = .totalItemRejected.ToString.Trim
                    If .totalItemInspected > 0 And .totalItemAccepted > 0 Then
                        lblTotalItemAcceptedPct.Text = Format((.totalItemAccepted / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemAcceptedPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemNeedRepair > 0 Then
                        lblTotalItemNeedRepairPct.Text = Format((.totalItemNeedRepair / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemNeedRepairPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemRejected > 0 Then
                        lblTotalItemRejectedPct.Text = Format((.totalItemRejected / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemRejectedPct.Text = "0"
                    End If
                Else
                    lblTotalWorkOrder.Text = "0"
                    lblTotalItemIspected.Text = "0"                    
                    lblTotalItemAccepted.Text = "0"
                    lblTotalItemAcceptedPct.Text = "0"
                    lblTotalItemNeedRepair.Text = "0"
                    lblTotalItemNeedRepairPct.Text = "0"
                    lblTotalItemRejected.Text = "0"
                    lblTotalItemRejectedPct.Text = "0"
                End If
            End With            

            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub GetDashboardInformationByProjectID()
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtTotalInspectionByProjectID As New DataTable
            With oProject
                dtTotalInspectionByProjectID = .GetTotalInspectionByProjectID(txtProjectID.Text.Trim)
                
                If dtTotalInspectionByProjectID.Rows.Count > 0 Then
                    lblTotalWorkOrder.Text = .totalWorkOrder.ToString.Trim
                    lblTotalItemIspected.Text = .totalItemInspected.ToString.Trim
                    lblTotalItemAccepted.Text = .totalItemAccepted.ToString.Trim
                    lblTotalItemNeedRepair.Text = .totalItemNeedRepair.ToString.Trim
                    lblTotalItemRejected.Text = .totalItemRejected.ToString.Trim
                    If .totalItemInspected > 0 And .totalItemAccepted > 0 Then
                        lblTotalItemAcceptedPct.Text = Format((.totalItemAccepted / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemAcceptedPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemNeedRepair > 0 Then
                        lblTotalItemNeedRepairPct.Text = Format((.totalItemNeedRepair / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemNeedRepairPct.Text = "0"
                    End If
                    If .totalItemInspected > 0 And .totalItemRejected > 0 Then
                        lblTotalItemRejectedPct.Text = Format((.totalItemRejected / .totalItemInspected) * 100, commonFunction.FORMAT_PERCENTAGE)
                    Else
                        lblTotalItemRejectedPct.Text = "0"
                    End If
                Else
                    lblTotalWorkOrder.Text = "0"
                    lblTotalItemIspected.Text = "0"
                    lblTotalItemAccepted.Text = "0"
                    lblTotalItemAcceptedPct.Text = "0"
                    lblTotalItemNeedRepair.Text = "0"
                    lblTotalItemNeedRepairPct.Text = "0"
                    lblTotalItemRejected.Text = "0"
                    lblTotalItemRejectedPct.Text = "0"
                End If
            End With

            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub GetSummaryOfInspectionByStatus(ByVal strStatus As String)
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtItemDueToExpiredInspection As New DataTable
            With oProject
                dtItemDueToExpiredInspection = .GetListOfItemDueToExpiredInspectionByCustomerStatus(txtCustomerID.Text.Trim, ddlInformationTypeSOI.SelectedValue.Trim, CInt(txtItemDueToExpiredInspectionInDay.Text.Trim), calStartDate.selectedDate, calEndDate.selectedDate, strStatus.Trim)
            End With
            grdItemDueToExpiredInspection.DataSource = dtItemDueToExpiredInspection
            grdItemDueToExpiredInspection.DataBind()
            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub GetSummaryOfInspectionByProjectIDStatus(ByVal strProjectID As String, ByVal strStatus As String)
            Dim oProject As New Common.BussinessRules.ProjectHd
            Dim dtItemDueToExpiredInspection As New DataTable
            With oProject
                dtItemDueToExpiredInspection = .GetListOfItemDueToExpiredInspectionByProjectIDStatus(strProjectID.Trim, ddlInformationTypeSOI.SelectedValue.Trim, CInt(txtItemDueToExpiredInspectionInDay.Text.Trim), strStatus.Trim)
            End With
            grdItemDueToExpiredInspection.DataSource = dtItemDueToExpiredInspection
            grdItemDueToExpiredInspection.DataBind()
            oProject.Dispose()
            oProject = Nothing

            GetDashboardInformationByProjectID()
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

            ddlInformationTypeSOI.Enabled = True            
            ddlPeriod.Enabled = True
            chkPeriod.Checked = True
            txtWorkOrderNo.Text = String.Empty
            txtProjectCode.Text = String.Empty
            txtProjectID.Text = String.Empty
            txtSerialNo.Text = String.Empty
            SetDataGridCustomerInspectionInformation()
            SetDataGridSummaryOfInspection()
            SetDataGridHistoryOfInspectionBySerialNo()
        End Sub

        Private Sub _openProduct(ByVal _productID As String)
            Dim oProduct As New Common.BussinessRules.Product
            oProduct.productID = _productID.Trim
            If oProduct.SelectOne.Rows.Count > 0 Then
                txtProductID.Text = _productID.Trim
                txtProductCode.Text = oProduct.productCode.Trim
                txtProductName.Text = oProduct.productName.Trim
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            Else
                txtProductID.Text = String.Empty
                txtProductCode.Text = String.Empty
                txtProductName.Text = String.Empty
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = False
            End If
            oProduct.Dispose()
            oProduct = Nothing
        End Sub

        Private Sub _openProjectByWorkOrderNo()
            Dim oProject As New Common.BussinessRules.ProjectHd
            With oProject
                .workOrderNo = txtWorkOrderNo.Text.Trim
                If .SelectOneByWorkOrderNo.Rows.Count > 0 Then
                    txtProjectCode.Text = .projectCode.Trim
                    txtProjectID.Text = .projectID.Trim
                    chkPeriod.Checked = False
                    chkPeriod_CheckedChanged(Nothing, Nothing)
                Else
                    txtWorkOrderNo.Text = String.Empty
                    txtProjectCode.Text = String.Empty
                    txtProjectID.Text = String.Empty
                End If
            End With
            oProject.Dispose()
            oProject = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        
#End Region

    End Class

End Namespace