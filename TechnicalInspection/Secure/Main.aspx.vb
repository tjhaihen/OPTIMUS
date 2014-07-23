﻿Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic


Imports System.Data.SqlTypes

Namespace Raven.Web
    Public Class Main
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                commonFunction.SetDDL_Table(ddlMySite, "UserSite", MyBase.LoggedOnUserID)
                btnSearchProject.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("SiteProject", txtProjectCode.ClientID, ddlMySite.SelectedValue.Trim))                

                SetToolbarVisibleButton()
                SetDropDownListItems()
                SetRadioButtonListItems()
                SetPanelVisibility("")

                ReadQueryString()

                If chkIsCustomer.Checked = False Then
                    If MyBase.LoggedOnProfileID.Trim <> Common.Methods.GetSettingParameter("INSPProfileID") Then
                        pnlAdministratorScreen.Visible = True
                        pnlInspectorScreen.Visible = False
                        SetDataGrid(pnlAdministratorScreen.ID)
                        commonFunction.Focus(Me, txtWorkRequestListFilter.ClientID)
                    Else
                        pnlAdministratorScreen.Visible = False
                        pnlInspectorScreen.Visible = True
                    End If
                Else
                    pnlAdministratorScreen.Visible = False
                    pnlInspectorScreen.Visible = True
                End If
            End If
        End Sub

        Private Sub ddlMySite_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMySite.SelectedIndexChanged
            btnSearchProject.Attributes.Remove("onClick")
            btnSearchProject.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("SiteProject", txtProjectCode.ClientID, ddlMySite.SelectedValue.Trim))
        End Sub

        Private Sub txtProjectCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtProjectCode.TextChanged            
            txtProjectName.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectCode", txtProjectCode.Text.Trim, "ProjectName")
            txtProjectID.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectCode", txtProjectCode.Text.Trim, "ProjectID")
            ddlMySite.SelectedValue = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "SiteID")
            ddlMySite_SelectedIndexChanged(Nothing, Nothing)
            ProjectBanner.ProjectID = txtProjectID.Text.Trim
            ProjectBanner.GetProjectInformation()
            SetDataGridReportTypeByProject()
            lblReportTypeName.Text = String.Empty
            lblReportTypePanelID.Text = String.Empty
            SetPanelVisibility(lblReportTypePanelID.Text.Trim)
        End Sub

        Private Sub ddlWorkRequestListFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlWorkRequestListFilter.SelectedIndexChanged
            SetDataGrid(pnlAdministratorScreen.ID)
        End Sub

        Private Sub btnWorkRequestListFilter_Click(sender As Object, e As System.EventArgs) Handles btnWorkRequestListFilter.Click
            SetDataGrid(pnlAdministratorScreen.ID)
            commonFunction.Focus(Me, txtWorkRequestListFilter.ClientID)
        End Sub

        Private Sub grdReportTypeByProject_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdReportTypeByProject.ItemCommand
            Select Case e.CommandName
                Case "SelectReportType"
                    Dim _lblReportTypeID As Label = CType(e.Item.FindControl("_lblReportTypeID"), Label)
                    Dim _lbtnReportTypeID As LinkButton = CType(e.Item.FindControl("_lbtnReportTypeID"), LinkButton)
                    lblReportTypeCode.Text = _lblReportTypeID.ToolTip.Trim
                    lblReportTypeName.Text = _lbtnReportTypeID.Text.Trim
                    lblReportTypePanelID.Text = _lbtnReportTypeID.ToolTip.Trim
                    SetPanelVisibility(lblReportTypePanelID.Text.Trim)
                    PrepareScreen(lblReportTypePanelID.Text.Trim, False)
                    SetDataGrid(lblReportTypePanelID.Text.Trim)
            End Select
        End Sub

        Private Sub grdReportTypeByProject_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdReportTypeByProject.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#ffffff';this.focus;this.style.cursor='pointer';")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")                    
            End Select
        End Sub

        Private Sub grdWorkRequest_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWorkRequest.ItemCommand
            Select Case e.CommandName
                Case "Process"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    pnlAdministratorScreen.Visible = False
                    pnlInspectorScreen.Visible = True                    
                    txtProjectID.Text = _lblProjectID.Text.Trim
                    txtProjectName.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "ProjectName")
                    txtProjectCode.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "ProjectCode")
                    ddlMySite.SelectedValue = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "SiteID")
                    ddlMySite_SelectedIndexChanged(Nothing, Nothing)
                    ProjectBanner.ProjectID = txtProjectID.Text.Trim
                    ProjectBanner.GetProjectInformation()
                    SetDataGridReportTypeByProject()
                    lblReportTypeName.Text = String.Empty
                    lblReportTypePanelID.Text = String.Empty
                    SetPanelVisibility(lblReportTypePanelID.Text.Trim)

                Case "Done"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    oBR.projectID = _lblProjectID.Text.Trim
                    If oBR.SelectOne.Rows.Count > 0 Then
                        oBR.isDone = True
                        oBR.doneBy = MyBase.LoggedOnUserID.Trim
                        If oBR.UpdateDone() Then
                            SetDataGrid(pnlAdministratorScreen.ID)
                        End If
                    End If
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Sub grdWorkRequest_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdWorkRequest.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                    If _drv Is Nothing Then Exit Sub

                    Dim projectID As String = CType(_drv.Row.Item("projectID"), String).Trim

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#454545';this.focus;this.style.cursor='pointer';")
                    If e.Item.ItemType = ListItemType.Item Then
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")
                    Else
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#eeeeee';this.style.color='#000000'")
                    End If                
            End Select
        End Sub

#Region " Summary of Inspection Report "
        Private Sub SOI_grdSummaryOfInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles SOI_grdSummaryOfInspection.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _SOI_lblSummaryOfInspectionID As Label = CType(e.Item.FindControl("SOI_lblSummaryOfInspectionID"), Label)
                    SOI_txtSummaryOfInspectionID.Text = _SOI_lblSummaryOfInspectionID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)

                Case "Delete"
                    Dim _SOI_lblSummaryOfInspectionID As Label = CType(e.Item.FindControl("SOI_lblSummaryOfInspectionID"), Label)
                    SOI_txtSummaryOfInspectionID.Text = _SOI_lblSummaryOfInspectionID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, SOI_txtSummaryOfInspectionID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                    SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
            End Select
        End Sub

        Private Sub SOI_rbtnlInputMethod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles SOI_rbtnlInputMethod.SelectedIndexChanged
            SOI_pnlEntry.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry")
            SOI_pnlUpload.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Upload")
            SOI_txtSheetName.Text = "Sheet1"
        End Sub
#End Region

#Region " Check List Of Completion Report "
        Private Sub CCR_grdCheckListOfCompletionReport_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles CCR_grdCheckListOfCompletionReport.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _CCR_lblCCRID As Label = CType(e.Item.FindControl("CCR_lblCCRID"), Label)
                    CCR_txtCCRID.Text = _CCR_lblCCRID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Daily Progress Report "
        Private Sub DPR_txtDailyReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DPR_txtDailyReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
        End Sub

        Private Sub DPR_grdDailyReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DPR_grdDailyReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DPR_lblDailyReportDtID As Label = CType(e.Item.FindControl("DPR_lblDailyReportDtID"), Label)
                    DPR_txtDailyReportDtID.Text = _DPR_lblDailyReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Daily Inspection Report "
        Private Sub DIR_txtDailyReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DIR_txtDailyReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)
        End Sub

        Private Sub DIR_grdDailyReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DIR_grdDailyReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DIR_lblDailyReportDtID As Label = CType(e.Item.FindControl("DIR_lblDailyReportDtID"), Label)
                    DIR_txtDailyReportDtID.Text = _DIR_lblDailyReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Timesheet "
        Private Sub TS_ddlMonth_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TS_ddlMonth.SelectedIndexChanged
            PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
            SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
        End Sub

        Private Sub TS_ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TS_ddlYear.SelectedIndexChanged
            PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
            SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
        End Sub

        Protected Sub lvwTimeSheet_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs)
            If e.Item.ItemType = ListViewItemType.DataItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim _repDateInMonthDt As Repeater = CType(e.Item.FindControl("repDateInMonthDt"), Repeater)
                Dim _projectResourceID As String = CType(row("projectResourceID"), String)
                PopulateDateInMonth(_repDateInMonthDt, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), _projectResourceID)
            End If
        End Sub

        Protected Sub repDateInMonthHd_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim TS_ddlWorkingTypeAll As DropDownList = CType(e.Item.FindControl("TS_ddlWorkingTypeAll"), DropDownList)
                commonFunction.SetDDL_Table(TS_ddlWorkingTypeAll, "CommonCode", Common.Constants.GroupCode.WorkingType_SCode, True, "")
            End If
        End Sub

        Protected Sub repDateInMonthDt_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim TS_lblDateInMonthDt As Label = CType(e.Item.FindControl("TS_lblDateInMonthDt"), Label)
                Dim TS_lblTimeSheetID As Label = CType(e.Item.FindControl("TS_lblTimeSheetID"), Label)
                Dim TS_lblProjectResourceID As Label = CType(e.Item.FindControl("TS_lblProjectResourceID"), Label)
                Dim TS_ddlWorkingType As DropDownList = CType(e.Item.FindControl("TS_ddlWorkingType"), DropDownList)
                Dim TS_chkIsNew As CheckBox = CType(e.Item.FindControl("TS_chkIsNew"), CheckBox)
                Dim _workingDate As Date = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text.Trim))
                TS_lblProjectResourceID.Text = CType(row("KeyField"), String)
                commonFunction.SetDDL_Table(TS_ddlWorkingType, "CommonCode", Common.Constants.GroupCode.WorkingType_SCode, True, "")

                Dim oBR As New Common.BussinessRules.TimeSheet
                With oBR
                    .projectResourceID = TS_lblProjectResourceID.Text.Trim
                    .workingDate = _workingDate
                    If .SelectByProjectResourceIDWorkingDate.Rows.Count > 0 Then
                        TS_lblTimeSheetID.Text = .timeSheetID
                        commonFunction.SelectListItem(TS_ddlWorkingType, .workingTypeSCode)
                        TS_chkIsNew.Checked = False
                    Else
                        TS_lblTimeSheetID.Text = String.Empty
                        TS_ddlWorkingType.SelectedIndex = 0
                        TS_chkIsNew.Checked = True
                    End If
                End With
                oBR.Dispose()
                oBR = Nothing
            End If
        End Sub
#End Region

#Region " Drill Pipe Inspection Report "
        Private Sub DP_txtSpecificationCode_TextChanged(sender As Object, e As System.EventArgs) Handles DP_txtSpecificationCode.TextChanged
            DP_txtSpecificationID.Text = Common.BussinessRules.ID.GetFieldValue("InspectionSpec", "inspectionSpecCode", DP_txtSpecificationCode.Text.Trim, "inspectionSpecID")
            _openInspectionSpec()
        End Sub

        Private Sub DP_txtDrillPipeReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DP_txtDrillPipeReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
        End Sub

        Private Sub DP_grdDrillPipeReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DP_grdDrillPipeReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DP_lblDrillPipeReportDtID As Label = CType(e.Item.FindControl("DP_lblDrillPipeReportDtID"), Label)
                    DP_txtDrillPipeReportDtID.Text = _DP_lblDrillPipeReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Service Report "
        Private Sub SR_grdServiceReport_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles SR_grdServiceReport.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _SR_lblServiceReportID As Label = CType(e.Item.FindControl("SR_lblServiceReportID"), Label)
                    SR_txtServiceReportID.Text = _SR_lblServiceReportID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Certificate of Inspection "
        Private Sub COI_grdCertificateInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles COI_grdCertificateInspection.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _COI_lblCertificateOfInspectionID As Label = CType(e.Item.FindControl("COI_lblCertificateOfInspectionID"), Label)
                    COI_txtCertificateInspectionID.Text = _COI_lblCertificateOfInspectionID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)

                Case "Delete"
                    Dim _COI_lblCertificateOfInspectionID As Label = CType(e.Item.FindControl("COI_lblCertificateOfInspectionID"), Label)
                    COI_txtCertificateInspectionID.Text = _COI_lblCertificateOfInspectionID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, COI_txtCertificateInspectionID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, False, True)
                    SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
            End Select
        End Sub
#End Region

#Region " MPI Report "
        Private Sub MPI_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles MPI_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
        End Sub

        Private Sub MPI_ddlMPIType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles MPI_ddlMPIType.SelectedIndexChanged
            MPI_btnReportNo.Attributes.Remove("onclick")
            MPI_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("MPIHd", MPI_txtReportNo.ClientID, txtProjectCode.Text.Trim + "|" + MPI_ddlMPIType.SelectedValue.Trim))
            PrepareScreen(Common.Constants.ReportTypePanelID.MPIReport_PanelID, False, True)
        End Sub
#End Region

#Region " UT Spot Check "
        Private Sub UTSC_grdUTSpotCheckDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles UTSC_grdUTSpotCheckDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _UTSC_lblUTSpotCheckDtID As Label = CType(e.Item.FindControl("UTSC_lblUTSpotCheckDtID"), Label)
                    UTSC_txtUTSpotCheckDtID.Text = _UTSC_lblUTSpotCheckDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)

                Case "Delete"
                    Dim _UTSC_lblUTSpotCheckDtID As Label = CType(e.Item.FindControl("UTSC_lblUTSpotCheckDtID"), Label)
                    UTSC_txtUTSpotCheckDtID.Text = _UTSC_lblUTSpotCheckDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID, UTSC_txtUTSpotCheckDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
            End Select
        End Sub

        Private Sub UTSC_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles UTSC_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
        End Sub
#End Region

#Region " Hardness Test Report "
        Private Sub HT_grdHardnessTestDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HT_grdHardnessTestDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _HT_lblHardnessTestDtID As Label = CType(e.Item.FindControl("HT_lblHardnessTestDtID"), Label)
                    HT_txtHardnessTestDtID.Text = _HT_lblHardnessTestDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)

                Case "Delete"
                    Dim _HT_lblHardnessTestDtID As Label = CType(e.Item.FindControl("HT_lblHardnessTestDtID"), Label)
                    HT_txtHardnessTestDtID.Text = _HT_lblHardnessTestDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.HardnessTest_PanelID, HT_txtHardnessTestDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
            End Select
        End Sub

        Private Sub HT_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles HT_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
        End Sub        
#End Region

#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub SetToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidSave
                    If pnlSummaryOfInspection.Visible Then
                        _update(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
                    If pnlCheckListCompletionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
                    End If
                    If pnlTimeSheet.Visible Then
                        _update(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
                    End If
                    If pnlDailyProgressReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
                    End If
                    If pnlDailyInspectionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)
                    End If
                    If pnlDrillPipeInspectionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
                    End If
                    If pnlServiceReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
                    End If
                    If pnlCertificateInspection.Visible Then
                        _update(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    End If
                    If pnlMPIReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
                    End If
                    If pnlUTSpotCheck.Visible Then
                        _update(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    End If
                    If pnlHardnessTestReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    End If

                Case CSSToolbarItem.tidNew
                    If pnlSummaryOfInspection.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
                    If pnlCheckListCompletionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
                    End If
                    If pnlTimeSheet.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.TimeSheet_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
                    End If
                    If pnlDailyProgressReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
                    End If
                    If pnlDailyInspectionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)
                    End If
                    If pnlDrillPipeInspectionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
                    End If
                    If pnlServiceReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
                    End If
                    If pnlCertificateInspection.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    End If
                    If pnlMPIReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.MPIReport_PanelID, False, True)
                        'SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    End If
                    If pnlUTSpotCheck.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    End If
                    If pnlHardnessTestReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.HardnessTest_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    End If

                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    Dim strUserID As String = MyBase.LoggedOnUserID.Trim

                    If pnlSummaryOfInspection.Visible Then
                        br.ReportCode = "1000000071"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlCheckListCompletionReport.Visible Then
                        br.ReportCode = "1000000001"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlTimeSheet.Visible Then
                        br.ReportCode = "1000000002"
                        br.AddParameters(TS_ddlMonth.SelectedValue.Trim)
                        br.AddParameters(TS_ddlYear.SelectedValue.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDailyProgressReport.Visible Then
                        br.ReportCode = "1000000003"
                        br.AddParameters(DPR_txtDailyReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDailyInspectionReport.Visible Then
                        br.ReportCode = "1000000004"
                        br.AddParameters(DIR_txtDailyReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDrillPipeInspectionReport.Visible Then
                        br.ReportCode = "1000000005"
                        br.AddParameters(DP_txtDrillPipeReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlServiceReport.Visible Then
                        br.ReportCode = "1000000025"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlCertificateInspection.Visible Then
                        br.ReportCode = "1000000100"
                        br.AddParameters(COI_txtCertificateInspectionID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlMPIReport.Visible Then
                        br.ReportCode = "1000000008"
                        br.AddParameters(MPI_txtMPIHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlUTSpotCheck.Visible Then
                        br.ReportCode = "1000000009"
                        br.AddParameters(UTSC_txtUTSpotCheckHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlUTSpotCheck.Visible Then
                        br.ReportCode = "1000000011"
                        br.AddParameters(HT_txtHardnessTestHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If
                    
                    br.Dispose()
                    br = Nothing

                Case CSSToolbarItem.tidApprove
                    If pnlSummaryOfInspection.Visible Then
                        UpdateApproval(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, True)
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If

                Case CSSToolbarItem.tidVoid
                    If pnlSummaryOfInspection.Visible Then
                        UpdateApproval(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False)
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            Dim b As Boolean = False
            chkIsCustomer.Checked = False
            ddlMySite.Enabled = True
            btnSearchProject.Enabled = True

            If Not Request.QueryString("isc") = Nothing Then
                If Request.QueryString("isc").Trim = "True" Then
                    chkIsCustomer.Checked = True
                    ddlMySite.Enabled = False
                    btnSearchProject.Enabled = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidNew) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                End If
            End If

            If Not Request.QueryString("pid") = Nothing Then
                txtProjectCode.Text = Request.QueryString("pid").Trim
                txtProjectCode_TextChanged(Nothing, Nothing)
            End If

            Return b
        End Function

        Private Sub SetDataGridReportTypeByProject()
            Dim oPRT As New Common.BussinessRules.ProjectReportType
            oPRT.ProjectID = txtProjectID.Text.Trim
            grdReportTypeByProject.DataSource = oPRT.GetReportTypeByProjectID
            grdReportTypeByProject.DataBind()
            oPRT.Dispose()
            oPRT = Nothing
        End Sub

        Private Sub SetDataGrid(ByVal _VisiblePanelID As String)
            Select Case _VisiblePanelID
                Case pnlAdministratorScreen.ID
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    grdWorkRequest.DataSource = oBR.GetWorkRequestListByStatus(ddlWorkRequestListFilter.SelectedValue.Trim, _
                        txtWorkRequestListFilter.Text.Trim, _
                        CInt(IIf(IsNumeric(txtWorkRequestListDisplayFilter.Text.Trim) = True, CInt(txtWorkRequestListDisplayFilter.Text.Trim), 50).ToString.Trim))
                    grdWorkRequest.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    SOI_grdSummaryOfInspection.DataSource = oBR.SelectByProjectID
                    SOI_grdSummaryOfInspection.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                    _refreshStatus(_VisiblePanelID)
                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    oBR.projectID = txtProjectID.Text.Trim
                    CCR_grdCheckListOfCompletionReport.DataSource = oBR.SelectByProjectID
                    CCR_grdCheckListOfCompletionReport.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.ProjectResource
                    oBR.ProjectID = txtProjectID.Text.Trim
                    lvwTimeSheet.DataSource = oBR.GetResourceByProjectID
                    lvwTimeSheet.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oBR As New Common.BussinessRules.DailyReportDt
                    oBR.dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                    DPR_grdDailyReportDt.DataSource = oBR.SelectByDailyReportHdID
                    DPR_grdDailyReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID
                    Dim oBR As New Common.BussinessRules.DailyReportDt
                    oBR.dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                    DIR_grdDailyReportDt.DataSource = oBR.SelectByDailyReportHdID
                    DIR_grdDailyReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oBR As New Common.BussinessRules.DrillPipeReportDt
                    oBR.drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                    DP_grdDrillPipeReportDt.DataSource = oBR.SelectByDrillPipeReportHdID
                    DP_grdDrillPipeReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oBR As New Common.BussinessRules.ServiceReport
                    oBR.projectID = txtProjectID.Text.Trim
                    oBR.serviceReportForSCode = SR_ddlServiceReportFor.SelectedValue.Trim
                    SR_grdServiceReport.DataSource = oBR.SelectByProjectIDForSCode
                    SR_grdServiceReport.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    COI_grdCertificateInspection.DataSource = oBR.SelectByProjectID
                    COI_grdCertificateInspection.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oBR As New Common.BussinessRules.UTSpotCheckDt
                    oBR.UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                    UTSC_grdUTSpotCheckDt.DataSource = oBR.SelectByUTSpotCheckHdID
                    UTSC_grdUTSpotCheckDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oBR As New Common.BussinessRules.HardnessTestDt
                    oBR.hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                    HT_grdHardnessTestDt.DataSource = oBR.SelectByHardnessTestHdID
                    HT_grdHardnessTestDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Sub GetReportTypeName(ByVal _ReportTypeID As String)
            lblReportTypeName.Text = Common.BussinessRules.ID.GetFieldValue("ReportType", "ReportTypeID", _ReportTypeID.Trim, "ReportTypeName")
        End Sub

        Private Sub SetPanelVisibility(ByVal _VisiblePanelID As String)
            pnlCheckListCompletionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlCheckListCompletionReport.ID, True, False))
            pnlServiceAcceptance.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlServiceAcceptance.ID, True, False))
            pnlSummaryOfInspection.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlSummaryOfInspection.ID, True, False))

            pnlTimeSheet.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlTimeSheet.ID, True, False))
            pnlDailyProgressReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDailyProgressReport.ID, True, False))
            pnlDailyInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDailyInspectionReport.ID, True, False))

            pnlServiceReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlServiceReport.ID, True, False))
            pnlMPIReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlMPIReport.ID, True, False))
            pnlDrillPipeInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDrillPipeInspectionReport.ID, True, False))

            pnlThroughVisualInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlThroughVisualInspectionReport.ID, True, False))
            pnlInspectionTallyReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlInspectionTallyReport.ID, True, False))
            pnlUTSpotCheck.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlUTSpotCheck.ID, True, False))

            pnlRotaryShoulderConnectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlRotaryShoulderConnectionReport.ID, True, False))
            pnlUTSpotEndArea.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlUTSpotEndArea.ID, True, False))
            pnlCertificateInspection.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlCertificateInspection.ID, True, False))

            pnlHardnessTestReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlHardnessTestReport.ID, True, False))
        End Sub

        Private Sub SetDropDownListItems()
            commonFunction.SetDDL_Table(CCR_ddlTypeOfReport, "CommonCode", Common.Constants.GroupCode.TypeOfReport_SCode)
            commonFunction.SetDDL_Table(DPR_ddlWeatherCondition, "CommonCode", Common.Constants.GroupCode.Weather_SCode)
            commonFunction.SetDDL_Table(DIR_ddlWeatherCondition, "CommonCode", Common.Constants.GroupCode.Weather_SCode)
            commonFunction.SetDDL_Table(SR_ddlServiceReportFor, "CommonCode", Common.Constants.GroupCode.ServiceReportFor_SCode)
            commonFunction.SetDDL_Table(MPI_ddlMPIType, "CommonCode", Common.Constants.GroupCode.MPIType_SCode)
            commonFunction.SetDDL_Table(HT_ddlLocation, "CommonCode", Common.Constants.GroupCode.HardnessTestLocation_SCode)
        End Sub

        Private Sub SetRadioButtonListItems()
            commonFunction.SetRBTNL_Table(MPI_rbtnlYoke, "CommonCode", Common.Constants.GroupCode.MPIYoke_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlCoil, "CommonCode", Common.Constants.GroupCode.MPICoil_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlFluorescent, "CommonCode", Common.Constants.GroupCode.MPIFluorescent_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlContrastBW, "CommonCode", Common.Constants.GroupCode.MPIContrastBW_SCode)
        End Sub

        Private Sub PrepareScreen(ByVal _VisiblePanelID As String, ByVal _isAfterInsert As Boolean, Optional ByVal _isNew As Boolean = True)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    If _isAfterInsert Then
                        If IsNumeric(SOI_txtSequenceNo.Text.Trim) Then
                            SOI_txtSequenceNo.Text = CStr(CDec(SOI_txtSequenceNo.Text.Trim) + 1)
                        Else
                            SOI_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, SOI_txtDescOfEquip.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("SummaryOfInspection", "SequenceNo", _
                                                    "projectID", txtProjectID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            SOI_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            SOI_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(SOI_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, SOI_txtDescOfEquip.ClientID)
                        Else
                            commonFunction.Focus(Me, SOI_txtSequenceNo.ClientID)
                        End If
                    End If
                    SOI_txtSummaryOfInspectionID.Text = String.Empty                    
                    SOI_pnlEntry.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry")
                    SOI_pnlUpload.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Upload")
                    SOI_txtSheetName.Text = "Sheet1"

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    If _isAfterInsert Then
                        If IsNumeric(CCR_txtSequenceNo.Text.Trim) Then
                            CCR_txtSequenceNo.Text = CStr(CDec(CCR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            CCR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, CCR_txtDescription.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("CheckListOfCompletionReport", "SequenceNo", _
                                                    "ProjectID", txtProjectID.Text.Trim)
                        CCR_txtSequenceNo.Text = IIf(IsNumeric(strMaxSequenceNo) = True, CInt(strMaxSequenceNo) + 1, strMaxSequenceNo).ToString.Trim
                        CCR_txtPreparedByName.Text = String.Empty
                        If Len(CCR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, CCR_txtDescription.ClientID)
                        Else
                            commonFunction.Focus(Me, CCR_txtSequenceNo.ClientID)
                        End If
                    End If
                    CCR_txtCCRID.Text = String.Empty
                    CCR_txtDescription.Text = String.Empty
                    CCR_ddlTypeOfReport.SelectedIndex = 0
                    CCR_txtReportNo.Text = String.Empty
                    CCR_txtRemarks.Text = String.Empty

                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    oBR.projectID = txtProjectID.Text.Trim
                    oBR.SelectOne()
                    commonFunction.SetDDL_Table(TS_ddlMonth, "MonthInYear", String.Empty)
                    commonFunction.SetDDL_YearPeriod(TS_ddlYear, Year(oBR.startDate), Year(oBR.endDate))
                    TS_ddlMonth.SelectedValue = Month(Date.Today).ToString.Trim
                    TS_ddlYear.SelectedValue = Year(Date.Today).ToString.Trim
                    PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    DPR_btnSearchDailyReportHd.Attributes.Remove("onclick")
                    DPR_btnSearchDailyReportHd.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DailyReportHd", DPR_txtDailyReportHdID.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        DPR_txtDailyReportHdID.Text = String.Empty
                        DPR_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DPR_txtSequenceNo.Text.Trim) Then
                            DPR_txtSequenceNo.Text = CStr(CDec(DPR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DPR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DPR_ddlWeatherCondition.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DailyReportDt", "SequenceNo", _
                                                    "DailyReportHdID", DPR_txtDailyReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DPR_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DPR_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(DPR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DPR_ddlWeatherCondition.ClientID)
                        Else
                            commonFunction.Focus(Me, DPR_txtSequenceNo.ClientID)
                        End If
                    End If

                    DPR_txtDailyReportDtID.Text = String.Empty
                    DPR_txtDescription.Text = String.Empty
                    DPR_ddlWeatherCondition.SelectedIndex = 0
                    DPR_txtQtyCurrent.Text = "0"
                    DPR_txtQtyPrevious.Text = "0"
                    DPR_txtQtyCumulative.Text = "0"

                Case Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID
                    DIR_btnSearchDailyReportHd.Attributes.Remove("onclick")
                    DIR_btnSearchDailyReportHd.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DailyReportHd", DIR_txtDailyReportHdID.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        DIR_txtDailyReportHdID.Text = String.Empty
                        DIR_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DIR_txtSequenceNo.Text.Trim) Then
                            DIR_txtSequenceNo.Text = CStr(CDec(DIR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DIR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DIR_ddlWeatherCondition.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DailyReportDt", "SequenceNo", _
                                                    "DailyReportHdID", DIR_txtDailyReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DIR_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DIR_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(DIR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DIR_ddlWeatherCondition.ClientID)
                        Else
                            commonFunction.Focus(Me, DIR_txtSequenceNo.ClientID)
                        End If
                    End If

                    DIR_txtDailyReportDtID.Text = String.Empty
                    DIR_txtDescription.Text = String.Empty
                    DIR_ddlWeatherCondition.SelectedIndex = 0
                    DIR_txtQty.Text = "0"
                    DIR_txtResult.Text = String.Empty                    

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    DP_btnSearchDrillPipeReport.Attributes.Remove("onclick")
                    DP_btnSearchDrillPipeReport.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DPRHd", DP_txtDrillPipeReportHdID.ClientID, txtProjectCode.Text.Trim))
                    DP_btnSearchSpecification.Attributes.Remove("onclick")
                    DP_btnSearchSpecification.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("InspectionSpec", DP_txtSpecificationCode.ClientID))

                    If _isNew = True Then
                        DP_txtDrillPipeReportHdID.Text = String.Empty
                        DP_txtReportNo.Text = String.Empty
                        DP_calReportDate.selectedDate = Date.Today
                        DP_txtSize.Text = String.Empty
                        DP_txtWeight.Text = String.Empty
                        DP_txtGrade.Text = String.Empty
                        DP_txtConnection.Text = String.Empty
                        DP_txtRange.Text = String.Empty
                        DP_txtNominalWT.Text = String.Empty
                        DP_txtSpecificationID.Text = String.Empty
                        DP_txtSpecificationName.Text = String.Empty
                        DP_Premium_txtMinOD.Text = String.Empty
                        DP_Premium_txtMaxID.Text = String.Empty
                        DP_Premium_txtMinWall.Text = String.Empty
                        DP_Premium_txtMinShoulder.Text = String.Empty
                        DP_Premium_txtMinSeal.Text = String.Empty
                        DP_Class2_txtMinOD.Text = String.Empty
                        DP_Class2_txtMaxID.Text = String.Empty
                        DP_Class2_txtMinWall.Text = String.Empty
                        DP_Class2_txtMinShoulder.Text = String.Empty
                        DP_Class2_txtMinSeal.Text = String.Empty
                        DP_Class2_txtMinTongSpacePB.Text = String.Empty
                        DP_Class2_txtMaxQC.Text = String.Empty
                        DP_Class2_txtBevelDia.Text = String.Empty
                        DP_Class2_txtMinQCDepth.Text = String.Empty
                        DP_Class2_txtMaxLengthPin.Text = String.Empty
                        DP_Class2_txtMaxPinNeck.Text = String.Empty
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DP_txtSequenceNo.Text.Trim) Then
                            DP_txtSequenceNo.Text = CStr(CDec(DP_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DP_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DP_txtSerialNo.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DrillPipeReportDt", "SequenceNo", _
                                                    "DrillPipeReportHdID", DP_txtDrillPipeReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DP_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DP_txtSequenceNo.Text = strMaxSequenceNo
                        End If
                        If Len(DP_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DP_txtSerialNo.ClientID)
                        Else
                            commonFunction.Focus(Me, DP_txtSequenceNo.ClientID)
                        End If
                    End If

                    DP_txtDrillPipeReportDtID.Text = String.Empty
                    DP_txtSerialNo.Text = String.Empty

                    If _isNew = True Then
                        DP_txtbdBodyWear.Text = String.Empty
                        DP_txtbdBent.Text = String.Empty
                        DP_txtbdBodyDamage.Text = String.Empty
                        DP_txtbdEMI.Text = String.Empty
                        DP_txtbdUTEndArea.Text = String.Empty
                        DP_txtbdPlasticCoating.Text = String.Empty
                        DP_txtbdWall.Text = String.Empty
                        DP_txtbdWallRemanent.Text = String.Empty
                        DP_txtbdTubeClass.Text = String.Empty
                        DP_txtpcToolJointYear.Text = String.Empty
                        DP_txtpcOutsideDia.Text = String.Empty
                        DP_txtpcInsideDia.Text = String.Empty
                        DP_txtpcTongSpace.Text = String.Empty
                        DP_txtpcThreadLength.Text = String.Empty
                        DP_txtpcBevelDia.Text = String.Empty
                        DP_txtpcLead.Text = String.Empty
                        DP_txtpcShoulderWidth.Text = String.Empty
                        DP_txtpcNeckLength.Text = String.Empty
                        DP_txtpcReface.Text = String.Empty
                        DP_txtpcFinalCondition.Text = String.Empty
                        DP_txtbcOutsideDia.Text = String.Empty
                        DP_txtbcTongSpace.Text = String.Empty
                        DP_txtbcQCDia.Text = String.Empty
                        DP_txtbcQCDepth.Text = String.Empty
                        DP_txtbcShoulderWidth.Text = String.Empty
                        DP_txtbcBevelDia.Text = String.Empty
                        DP_txtbcSealWidth.Text = String.Empty
                        DP_txtbcReface.Text = String.Empty
                        DP_txtbcFinalCondition.Text = String.Empty
                        DP_txtRemarks.Text = String.Empty
                        commonFunction.Focus(Me, DP_txtReportNo.ClientID)
                    End If

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    SR_txtServiceReportID.Text = String.Empty
                    SR_ddlServiceReportFor.SelectedIndex = 0
                    SR_calServiceReportDate.selectedDate = Date.Today
                    SR_txtTypeOfInspection.Text = String.Empty
                    SR_txtManufacturer.Text = String.Empty
                    SR_txtTypeOfPipe.Text = String.Empty
                    SR_txtPipeOD.Text = String.Empty
                    SR_txtPipeGrade.Text = String.Empty
                    SR_txtPipeWeight.Text = String.Empty
                    SR_txtThreadConnection.Text = String.Empty
                    SR_txtRange.Text = String.Empty
                    SR_txtTotalInspected.Text = String.Empty
                    SR_txtTotalAccepted.Text = String.Empty
                    SR_txtMaterialDescription.Text = String.Empty
                    SR_txtResult.Text = String.Empty

                    commonFunction.SetDDL_Table(SR_ddlServiceReportFor, "CommonCode", Common.Constants.GroupCode.ServiceReportFor_SCode)

                    Select Case lblReportTypeCode.Text.Trim
                        Case Common.Constants.ReportTypeCode.ServiceReportMPIDPI
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPILoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIPullTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.Tubular).Enabled = False
                            SR_pnlTubular.Visible = False
                            SR_pnlNotTubular.Visible = True
                        Case Common.Constants.ReportTypeCode.ServiceReportMPILoadPullTest
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIDPI).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.Tubular).Enabled = False
                            SR_pnlTubular.Visible = False
                            SR_pnlNotTubular.Visible = True
                        Case Common.Constants.ReportTypeCode.ServiceReportTubular
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIDPI).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPILoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIPullTest).Enabled = False
                            SR_pnlTubular.Visible = True
                            SR_pnlNotTubular.Visible = False
                    End Select

                    commonFunction.Focus(Me, SR_ddlServiceReportFor.ClientID)

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    COI_txtCertificateInspectionID.Text = String.Empty
                    COI_calCertificateDate.selectedDate = Date.Today
                    COI_caInspectionDate.selectedDate = Date.Today
                    COI_calExpiredDate.selectedDate = Date.Today
                    COI_txtCertificateNo.Text = String.Empty
                    COI_txtOwner.Text = String.Empty
                    COI_txtUser.Text = String.Empty
                    COI_txtLocation.Text = String.Empty
                    COI_txtDescription.Text = String.Empty
                    COI_txtSerialNo.Text = String.Empty
                    COI_txtMaxGossWeightR.Text = String.Empty
                    COI_txtLoadTest.Text = String.Empty
                    COI_txtDuration.Text = String.Empty
                    COI_txtSpecification.Text = String.Empty
                    COI_txtExamination.Text = String.Empty
                    COI_txtResult.Text = String.Empty
                    COI_txtNotes.Text = String.Empty

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    If _isAfterInsert = False Then
                        MPI_btnReportNo.Attributes.Remove("onclick")
                        MPI_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("MPIHd", MPI_txtReportNo.ClientID, txtProjectCode.Text.Trim + "|" + MPI_ddlMPIType.SelectedValue.Trim))
                        If _isNew = True Then
                            MPI_txtMPIHdID.Text = String.Empty
                            MPI_txtReportNo.Text = String.Empty
                            MPI_calReportDate.selectedDate = Date.Today
                            MPI_txtSerialNo.Text = String.Empty
                            MPI_calExpiredDate.selectedDate = Date.Today
                        End If
                        MPI_txtDescription.Text = String.Empty
                        MPI_chkACIsASME.Checked = False
                        MPI_chkACIsAPISpec.Checked = False
                        MPI_chkIsACDS1.Checked = False
                        MPI_chkIsACOther.Checked = False
                        MPI_txtACOtherDescription.Text = String.Empty
                        MPI_txtQty.Text = String.Empty
                        MPI_txtDimension.Text = String.Empty
                        MPI_txtAreaInspection.Text = String.Empty
                        MPI_txtMaterial.Text = String.Empty
                        MPI_txtApplication.Text = String.Empty
                        MPI_txtSurfaceCondition.Text = String.Empty
                        MPI_txtContrast.Text = String.Empty
                        MPI_txtMetalSurfaceTemp.Text = String.Empty
                        MPI_txtMagneticParticle.Text = String.Empty
                        MPI_txtMaterialThickness.Text = String.Empty
                        MPI_txtCleaner.Text = String.Empty
                        MPI_txtSetCalibration.Text = String.Empty
                        MPI_txtPenetrant.Text = String.Empty
                        MPI_txtPoleSpacing.Text = String.Empty
                        MPI_txtDeveloper.Text = String.Empty
                        MPI_rbtnlYoke.SelectedIndex = 0
                        MPI_rbtnlCoil.SelectedIndex = 0
                        MPI_chkIsBlacklight.Checked = False
                        MPI_chkIsRods.Checked = False
                        MPI_rbtnlFluorescent.SelectedIndex = 0
                        MPI_rbtnlContrastBW.SelectedIndex = 0
                        MPI_chkIsDyePenetrant.Checked = False
                        MPI_chkIsWireBrush.Checked = False
                        MPI_chkIsBlastCleaning.Checked = False
                        MPI_chkIsGrinding.Checked = False
                        MPI_chkIsMachining.Checked = False
                        MPI_txtInspectionResult.Text = String.Empty
                        MPI_txtNotes.Text = String.Empty

                        commonFunction.Focus(Me, MPI_ddlMPIType.ClientID)
                    Else
                        commonFunction.Focus(Me, MPI_txtReportNo.ClientID)
                    End If

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    UTSC_btnReportNo.Attributes.Remove("onclick")
                    UTSC_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("UTSpotCheckHd", UTSC_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        UTSC_txtUTSpotCheckHdID.Text = String.Empty
                        UTSC_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        UTSC_txtUTSpotCheckDtID.Text = String.Empty
                        commonFunction.Focus(Me, UTSC_txtTallyNo.ClientID)
                    Else
                        If _isNew Then
                            If Len(UTSC_txtTallyNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, UTSC_txtLocation.ClientID)
                            Else
                                commonFunction.Focus(Me, UTSC_txtTallyNo.ClientID)
                            End If

                            UTSC_txtNominalWT.Text = String.Empty
                            UTSC_txtMinimalWT.Text = String.Empty
                            UTSC_txtWallThicknessInch1.Text = "0"
                            UTSC_txtWallThicknessInch2.Text = "0"
                            UTSC_txtWallThicknessInch3.Text = "0"
                            UTSC_txtRemark.Text = String.Empty
                        End If                        
                    End If

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    HT_btnReportNo.Attributes.Remove("onclick")
                    HT_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("HardnessTestHd", HT_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        HT_txtHardnessTestHdID.Text = String.Empty
                        HT_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        HT_txtHardnessTestDtID.Text = String.Empty
                        commonFunction.Focus(Me, HT_txtPipeNo.ClientID)
                    Else
                        If _isNew Then
                            If Len(HT_txtPipeNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, HT_ddlLocation.ClientID)
                            Else
                                commonFunction.Focus(Me, HT_txtPipeNo.ClientID)
                            End If

                            HT_ddlLocation.SelectedIndex = 0
                            HT_txtHRB1.Text = "0"
                            HT_txtHRB2.Text = "0"
                            HT_txtHRB3.Text = "0"
                            HT_txtHRB4.Text = "0"
                            HT_txtHRBAvg.Text = "0"
                            HT_txtHB1.Text = "0"
                            HT_txtHB2.Text = "0"
                            HT_txtHB3.Text = "0"
                            HT_txtHB4.Text = "0"
                            HT_txtHBAvg.Text = "0"
                        End If
                    End If
            End Select
        End Sub

        Private Sub PopulateDateInMonth(ByVal _Repeater As Repeater, ByVal _Year As Integer, ByVal _Month As Integer, Optional ByVal _KeyFieldValue As String = "")
            Dim tblDateInMonth As New DataTable
            With tblDateInMonth
                .Columns.Add("DateNo", System.Type.GetType("System.String"))
                .Columns.Add("KeyField", System.Type.GetType("System.String"))
            End With
            For i As Integer = 1 To Date.DaysInMonth(_Year, _Month)
                Dim newRow As DataRow = tblDateInMonth.NewRow
                newRow("DateNo") = CStr(i)
                newRow("KeyField") = _KeyFieldValue
                tblDateInMonth.Rows.Add(newRow)
            Next
            _Repeater.DataSource = tblDateInMonth
            _Repeater.DataBind()
        End Sub

        Private Sub UpdateApproval(ByVal _VisiblePanelID As String, ByVal _isApproval As Boolean)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    If oBR.SelectByProjectID.Rows.Count > 0 Then
                        oBR.isApproval = _isApproval
                        oBR.approvalBy = MyBase.LoggedOnUserID.Trim
                        If oBR.UpdateApproval() Then
                            _refreshStatus(_VisiblePanelID.Trim)
                        End If
                    End If
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Sub _refreshStatus(ByVal _VisiblePanelID As String)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.SummaryOfInspection
                    With oBr
                        .projectID = txtProjectID.Text.Trim
                        If .SelectByProjectID.Rows.Count > 0 Then
                            If .isApproval = True Then
                                SOI_pnlApproved.Visible = True
                                SOI_lblApprovalBy.Text = _openUser(.approvalBy.Trim)
                                SOI_lblApprovalDate.Text = .approvalDate.ToString.Trim
                            Else
                                SOI_pnlApproved.Visible = False
                                SOI_lblApprovalBy.Text = String.Empty
                                SOI_lblApprovalDate.Text = String.Empty
                            End If

                            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = Not .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = Not .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = .isApproval 'And Not chkIsCustomer.Checked
                        Else
                            SOI_pnlApproved.Visible = False
                            SOI_lblApprovalBy.Text = String.Empty
                            SOI_lblApprovalDate.Text = String.Empty

                            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                        End If
                    End With
                    oBr.Dispose()
                    oBr = Nothing
            End Select
        End Sub

        Private Sub UploadImage()
            '//get the image file that was posted (binary format)
            '    Dim theImage As HttpPostedFile
            '    theImage = MPI_ImageFile.PostedFile.ContentLength
            'byte[] theImage = new byte[FileUpload1.PostedFile.ContentLength];
            'HttpPostedFile Image = FileUpload1.PostedFile;
            'Image.InputStream.Read(theImage, 0, (int)FileUpload1.PostedFile.ContentLength);
            'int length = theImage.Length; //get the length of the image
            'string fileName = FileUpload1.FileName.ToString(); //get the file name of the posted image
            'string type = FileUpload1.PostedFile.ContentType; //get the type of the posted image
            'int size = FileUpload1.PostedFile.ContentLength; //get the size in bytes that
            'if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            '{
            '    //Call the method to execute Insertion of data to the Database
            '    ExecuteInsert(theImage, type, size, fileName, length);
            '    Response.Write("Save Successfully!");
            '}
        End Sub
    
#End Region

#Region " C,R,U,D "
        Private Sub _open(ByVal _VisiblePanelID As String)
            Dim isNew As Boolean = True
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    With oBR
                        .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            SOI_txtSequenceNo.Text = .sequenceNo.Trim
                            SOI_txtDescOfEquip.Text = .descriptionOfEquipment.Trim
                            SOI_txtSerialNo.Text = .serialIDNo.Trim
                            SOI_txtLocation.Text = .location.Trim
                            SOI_txtManufacture.Text = .manufacture.Trim
                            SOI_txtSWLWWLMGW.Text = .SWL_WWL_MGW.Trim
                            SOI_txtDimensional.Text = .dimensional.Trim
                            SOI_txtDefectFound.Text = .defectFound.Trim
                            SOI_txtResult.Text = .result.Trim
                            SOI_calExamDate.selectedDate = .examDate
                            SOI_calExpiredDate.selectedDate = .expireDate
                            SOI_txtReportNumber.Text = .reportNo.Trim
                            SOI_chkIsV.Checked = .isToiV
                            SOI_chkIsN.Checked = .isToiN
                            SOI_chkIsT.Checked = .isToiT
                            SOI_txtInterval.Text = .interval.Trim
                            SOI_txtRemarks.Text = .remarks.Trim
                        Else
                            PrepareScreen(_VisiblePanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    With oBR
                        .CCRID = CCR_txtCCRID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            CCR_txtSequenceNo.Text = .sequenceNo.Trim
                            CCR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(CCR_ddlTypeOfReport, .typeOfReportSCode.Trim)
                            CCR_txtPreparedByName.Text = .preparedBy.Trim
                            CCR_calPreparedDate.selectedDate = .preparedDate
                            CCR_txtReportNo.Text = .reportNo.Trim
                            CCR_txtRemarks.Text = .remarks.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DPR_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DPR_txtDailyReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DPR_txtSequenceNo.Text = .sequenceNo.Trim
                            DPR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(DPR_ddlWeatherCondition, .weatherConditionSCode.Trim)
                            DPR_txtQtyCurrent.Text = CStr(.currentQty)
                            DPR_txtQtyPrevious.Text = CStr(.beginningQty)
                            DPR_txtQtyCumulative.Text = CStr(.endingQty)
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)

                Case Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DIR_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DIR_txtDailyReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DIR_txtSequenceNo.Text = .sequenceNo.Trim
                            DIR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(DIR_ddlWeatherCondition, .weatherConditionSCode.Trim)
                            DIR_txtQty.Text = CStr(.currentQty)
                            DIR_txtResult.Text = .result.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID)

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DrillPipeReportHd
                    With oHd
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DP_calReportDate.selectedDate = .reportDate
                            DP_txtReportNo.Text = .reportNo.Trim
                            DP_txtRemarks.Text = .remarks.Trim
                            DP_txtSize.Text = .size.Trim
                            DP_txtWeight.Text = .weight.Trim
                            DP_txtGrade.Text = .grade.Trim
                            DP_txtConnection.Text = .connection.Trim
                            DP_txtRange.Text = .range.Trim
                            DP_txtNominalWT.Text = .nominalWT.Trim
                            DP_txtSpecificationID.Text = .inspectionSpecID.Trim
                            _openInspectionSpec()
                            isNew = False
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DrillPipeReportDt
                    With oDt
                        .drillPipeReportDtID = DP_txtDrillPipeReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DP_txtSequenceNo.Text = .sequenceNo.Trim
                            DP_txtSerialNo.Text = .serialNo.Trim
                            DP_txtRemarks.Text = .remarks.Trim
                            DP_txtbdBodyWear.Text = .bdBodyWear.Trim
                            DP_txtbdBent.Text = .bdBent.Trim
                            DP_txtbdBodyDamage.Text = .bdBodyDamage.Trim
                            DP_txtbdEMI.Text = .bdEMI.Trim
                            DP_txtbdUTEndArea.Text = .bdUTEndArea.Trim
                            DP_txtbdPlasticCoating.Text = .bdPlasticCoating.Trim
                            DP_txtbdWall.Text = .bdWall.Trim
                            DP_txtbdWallRemanent.Text = .bdWallRemanent.Trim
                            DP_txtbdTubeClass.Text = .bdTubeClass.Trim
                            DP_txtpcToolJointYear.Text = .pcToolJointYear.Trim
                            DP_txtpcOutsideDia.Text = .pcOutsideDia.Trim
                            DP_txtpcInsideDia.Text = .pcInsideDia.Trim
                            DP_txtpcTongSpace.Text = .pcTongSpace.Trim
                            DP_txtpcThreadLength.Text = .pcThreadLength.Trim
                            DP_txtpcBevelDia.Text = .pcBevelDia.Trim
                            DP_txtpcLead.Text = .pcLead.Trim
                            DP_txtpcShoulderWidth.Text = .pcShoulderWidth.Trim
                            DP_txtpcNeckLength.Text = .pcNeckLength.Trim
                            DP_txtpcReface.Text = .pcReface.Trim
                            DP_txtpcFinalCondition.Text = .pcFinalCondition.Trim
                            DP_txtbcOutsideDia.Text = .bcOutsideDia.Trim
                            DP_txtbcTongSpace.Text = .bcTongSpace.Trim
                            DP_txtbcQCDia.Text = .bcQCDia.Trim
                            DP_txtbcQCDepth.Text = .bcQCDepth.Trim
                            DP_txtbcShoulderWidth.Text = .bcShoulderWidth.Trim
                            DP_txtbcBevelDia.Text = .bcBevelDia.Trim
                            DP_txtbcSealWidth.Text = .bcSealWidth.Trim
                            DP_txtbcReface.Text = .bcReface.Trim
                            DP_txtbcFinalCondition.Text = .bcFinalCondition.Trim
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oSR As New Common.BussinessRules.ServiceReport
                    With oSR
                        .serviceReportID = SR_txtServiceReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            commonFunction.SelectListItem(SR_ddlServiceReportFor, .serviceReportForSCode.Trim)
                            SR_calServiceReportDate.selectedDate = .serviceReportDate
                            txtProjectID.Text = .projectID.Trim
                            SR_txtTypeOfInspection.Text = .typeOfInspection.Trim
                            SR_txtManufacturer.Text = .mdManufacturer.Trim
                            SR_txtTypeOfPipe.Text = .mdTypeOfPipe.Trim
                            SR_txtPipeOD.Text = .mdPipeOD.Trim
                            SR_txtPipeGrade.Text = .mdPipeGrade.Trim
                            SR_txtPipeWeight.Text = .mdPipeWeight.Trim
                            SR_txtThreadConnection.Text = .mdThreadConnection.Trim
                            SR_txtRange.Text = .mdRange.Trim
                            SR_txtTotalInspected.Text = .mdTotalInspected.Trim
                            SR_txtTotalAccepted.Text = .mdTotalAccepted.Trim
                            SR_txtMaterialDescription.Text = .mdNotes.Trim
                            SR_txtResult.Text = .result.Trim
                            commonFunction.Focus(Me, SR_ddlServiceReportFor.ClientID)
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False)
                        End If
                    End With
                    oSR.Dispose()
                    oSR = Nothing

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    With oBR
                        .certificateInspectionID = COI_txtCertificateInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            COI_txtCertificateNo.Text = .certificateNo.Trim
                            COI_calCertificateDate.selectedDate = .certificateDate
                            COI_txtOwner.Text = .owner.Trim
                            COI_txtUser.Text = .userLabel.Trim
                            COI_txtLocation.Text = .location.Trim
                            COI_txtDescription.Text = .description.Trim
                            COI_txtSerialNo.Text = .serialNo.Trim
                            COI_txtMaxGossWeightR.Text = .maxGrossWeightR.Trim
                            COI_txtLoadTest.Text = .loadTest.Trim
                            COI_txtDuration.Text = .duration.Trim
                            COI_txtSpecification.Text = .specification.Trim
                            COI_txtExamination.Text = .examination.Trim
                            COI_txtResult.Text = .result.Trim
                            COI_txtNotes.Text = .notes.Trim
                            COI_caInspectionDate.selectedDate = .inspectionDate
                            COI_calExpiredDate.selectedDate = .expiredDate
                        Else
                            PrepareScreen(_VisiblePanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    MPI_txtMPIHdID.Text = Common.BussinessRules.ID.GetFieldValue("MPIHd", "reportNo", MPI_txtReportNo.Text.Trim, "MPIHdID")
                    Dim oBR As New Common.BussinessRules.MPIHd
                    With oBR
                        .MPIHdID = MPI_txtMPIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            MPI_ddlMPIType.SelectedValue = .MPITypeSCode.Trim
                            MPI_calReportDate.selectedDate = .reportDate
                            MPI_txtReportNo.Text = .reportNo.Trim
                            MPI_txtSerialNo.Text = .serialNo.Trim
                            MPI_calExpiredDate.selectedDate = .expiredDate
                            MPI_txtDescription.Text = .description.Trim
                            MPI_chkACIsASME.Checked = .ACIsASME
                            MPI_chkACIsAPISpec.Checked = .ACIsAPISpec
                            MPI_chkIsACDS1.Checked = .ACIsDS1
                            MPI_chkIsACOther.Checked = .ACIsOther
                            MPI_txtACOtherDescription.Text = .ACOtherDescription.Trim
                            MPI_txtQty.Text = .qty.Trim
                            MPI_txtDimension.Text = .dimension.Trim
                            MPI_txtAreaInspection.Text = .areaInspection.Trim
                            MPI_txtMaterial.Text = .material.Trim
                            MPI_txtApplication.Text = .application.Trim
                            MPI_txtSurfaceCondition.Text = .surfaceCondition.Trim
                            MPI_txtContrast.Text = .contrast.Trim
                            MPI_txtMetalSurfaceTemp.Text = .metalSurfaceTemp.Trim
                            MPI_txtMagneticParticle.Text = .magneticParticle.Trim
                            MPI_txtMaterialThickness.Text = .materialThickness.Trim
                            MPI_txtCleaner.Text = .cleaner.Trim
                            MPI_txtSetCalibration.Text = .setCalibration.Trim
                            MPI_txtPenetrant.Text = .penetrant.Trim
                            MPI_txtPoleSpacing.Text = .poleSpacing.Trim
                            MPI_txtDeveloper.Text = .developer.Trim
                            MPI_rbtnlYoke.SelectedValue = .yokeSCode.Trim
                            MPI_rbtnlCoil.SelectedValue = .coilSCode.Trim
                            MPI_chkIsBlacklight.Checked = .isBlacklight
                            MPI_chkIsRods.Checked = .isRods
                            MPI_rbtnlFluorescent.SelectedValue = .fluorescentSCode.Trim
                            MPI_rbtnlContrastBW.SelectedValue = .contrastBWSCode.Trim
                            MPI_chkIsDyePenetrant.Checked = .isDyePenetrant
                            MPI_chkIsWireBrush.Checked = .isWireBrush
                            MPI_chkIsBlastCleaning.Checked = .isBlastCleaning
                            MPI_chkIsGrinding.Checked = .isGrinding
                            MPI_chkIsMachining.Checked = .isMachining
                            MPI_txtInspectionResult.Text = .inspectionResult.Trim
                            MPI_txtNotes.Text = .notes.Trim
                        Else
                            PrepareScreen(_VisiblePanelID, False, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    UTSC_txtUTSpotCheckHdID.Text = Common.BussinessRules.ID.GetFieldValue("UTSpotCheckHd", "reportNo", UTSC_txtReportNo.Text.Trim, "UTSpotCheckHdID")
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSC_calReportDate.selectedDate = .reportDate
                            UTSC_txtNominalWT.Text = .nominalWT.Trim
                            UTSC_txtMinimalWT.Text = .minimalWT.Trim
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.UTSpotCheckDt
                    With oDt
                        .UTSpotCheckDtID = UTSC_txtUTSpotCheckDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSC_txtTallyNo.Text = .tallyNo.Trim
                            UTSC_txtLocation.Text = .location.Trim
                            UTSC_txtWallThicknessInch1.Text = .wallThicknessInch1.ToString.Trim
                            UTSC_txtWallThicknessInch2.Text = .wallThicknessInch2.ToString.Trim
                            UTSC_txtWallThicknessInch3.Text = .wallThicknessInch3.ToString.Trim
                            UTSC_txtRemark.Text = .remark.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    HT_txtHardnessTestHdID.Text = Common.BussinessRules.ID.GetFieldValue("HardnessTestHd", "reportNo", HT_txtReportNo.Text.Trim, "HardnessTestHdID")
                    Dim oHd As New Common.BussinessRules.HardnessTestHd
                    With oHd
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            HT_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.HardnessTestDt
                    With oDt
                        .hardnessTestDtID = HT_txtHardnessTestDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            HT_txtPipeNo.Text = .pipeNo.Trim
                            HT_ddlLocation.SelectedValue = .locationSCode.Trim
                            HT_txtHRB1.Text = .HRB1.ToString.Trim
                            HT_txtHRB2.Text = .HRB2.ToString.Trim
                            HT_txtHRB3.Text = .HRB3.ToString.Trim
                            HT_txtHRB4.Text = .HRB4.ToString.Trim
                            HT_txtHRBAvg.Text = .HRBAvg.ToString.Trim
                            HT_txtHB1.Text = .HB1.ToString.Trim
                            HT_txtHB2.Text = .HB2.ToString.Trim
                            HT_txtHB3.Text = .HB3.ToString.Trim
                            HT_txtHB4.Text = .HB4.ToString.Trim
                            HT_txtHBAvg.Text = .HBAvg.ToString.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
            End Select
        End Sub

        Private Sub _openInspectionSpec()
            Dim oIS As New Common.BussinessRules.InspectionSpec
            With oIS
                .inspectionSpecID = DP_txtSpecificationID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    DP_txtSpecificationName.Text = .inspectionSpecName.Trim
                    DP_Premium_txtMinOD.Text = .minODpremium.Trim
                    DP_Premium_txtMaxID.Text = .maxIDpremium.Trim
                    DP_Premium_txtMinWall.Text = .minWallpremium.Trim
                    DP_Premium_txtMinShoulder.Text = .minShldrpremium.Trim
                    DP_Premium_txtMinSeal.Text = .minSealpremium.Trim
                    DP_Class2_txtMinOD.Text = .minODclass2.Trim
                    DP_Class2_txtMaxID.Text = .maxIDclass2.Trim
                    DP_Class2_txtMinWall.Text = .minWallclass2.Trim
                    DP_Class2_txtMinShoulder.Text = .minShldrclass2.Trim
                    DP_Class2_txtMinSeal.Text = .minSealclass2.Trim
                    DP_Class2_txtMinTongSpacePB.Text = .minTongSpacePinclass2.Trim
                    DP_Class2_txtMaxQC.Text = .maxQCclass2.Trim
                    DP_Class2_txtBevelDia.Text = .minBevelDiaclass2.Trim
                    DP_Class2_txtMinQCDepth.Text = .minQCDepthclass2.Trim
                    DP_Class2_txtMaxLengthPin.Text = .maxLengthPinclass2.Trim
                    DP_Class2_txtMaxPinNeck.Text = .maxPinNeckclass2.Trim
                Else
                    DP_txtSpecificationID.Text = String.Empty
                    DP_txtSpecificationCode.Text = String.Empty
                    DP_txtSpecificationName.Text = String.Empty
                    DP_txtSize.Text = String.Empty
                    DP_txtWeight.Text = String.Empty
                    DP_txtGrade.Text = String.Empty
                    DP_txtConnection.Text = String.Empty
                    DP_txtRange.Text = String.Empty
                    DP_txtNominalWT.Text = String.Empty
                    DP_Premium_txtMinOD.Text = String.Empty
                    DP_Premium_txtMaxID.Text = String.Empty
                    DP_Premium_txtMinWall.Text = String.Empty
                    DP_Premium_txtMinShoulder.Text = String.Empty
                    DP_Premium_txtMinSeal.Text = String.Empty
                    DP_Class2_txtMinOD.Text = String.Empty
                    DP_Class2_txtMaxID.Text = String.Empty
                    DP_Class2_txtMinWall.Text = String.Empty
                    DP_Class2_txtMinShoulder.Text = String.Empty
                    DP_Class2_txtMinSeal.Text = String.Empty
                    DP_Class2_txtMinTongSpacePB.Text = String.Empty
                    DP_Class2_txtMaxQC.Text = String.Empty
                    DP_Class2_txtBevelDia.Text = String.Empty
                    DP_Class2_txtMinQCDepth.Text = String.Empty
                    DP_Class2_txtMaxLengthPin.Text = String.Empty
                    DP_Class2_txtMaxPinNeck.Text = String.Empty
                End If
            End With
            oIS.Dispose()
            oIS = Nothing
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

        Private Sub _update(ByVal _VisiblePanelID As String)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    If SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry" Then
                        With oBR
                            .projectID = txtProjectID.Text.Trim
                            .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .projectID = txtProjectID.Text.Trim
                            .sequenceNo = SOI_txtSequenceNo.Text.Trim
                            .descriptionOfEquipment = SOI_txtDescOfEquip.Text.Trim
                            .serialIDNo = SOI_txtSerialNo.Text.Trim
                            .location = SOI_txtLocation.Text.Trim
                            .manufacture = SOI_txtManufacture.Text.Trim
                            .SWL_WWL_MGW = SOI_txtSWLWWLMGW.Text.Trim
                            .dimensional = SOI_txtDimensional.Text.Trim
                            .defectFound = SOI_txtDefectFound.Text.Trim
                            .result = SOI_txtResult.Text.Trim
                            .reportNo = SOI_txtReportNumber.Text.Trim
                            .typeOfInspectionSCode = ""
                            .isToiV = SOI_chkIsV.Checked
                            .isToiN = SOI_chkIsN.Checked
                            .isToiT = SOI_chkIsT.Checked
                            .interval = SOI_txtInterval.Text.Trim
                            .remarks = SOI_txtRemarks.Text.Trim
                            .detailReportSection = ""
                            .examDate = SOI_calExamDate.selectedDate
                            .expireDate = SOI_calExpiredDate.selectedDate
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID

                            If txtFileUrl.Value.Trim.Length > 0 Then
                                Dim fileExt As String, fileName As String
                                fileExt = Path.GetExtension(txtFileUrl.Value.Trim)
                                If SOI_txtSummaryOfInspectionID.Text.Trim.Length = 0 Then
                                    fileName = Common.BussinessRules.ID.GenerateIDNumber("SummaryOfInspection", "summaryOfInspectionID") + fileExt.Trim
                                Else
                                    fileName = SOI_txtSummaryOfInspectionID.Text.Trim + fileExt.Trim
                                End If
                                .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                                Dim Pathdb As String = Common.Methods.GetCommonCode("SOIDIR", "FILEDIR").Trim
                                Dim fNotNew As Boolean = False
                                Dim nmFile As String
                                Try
                                    .fileName = fileName.Trim
                                    .fileExtension = fileExt.Trim

                                    '// validate if the file exist
                                    nmFile = Pathdb + fileName
                                    If txtFileUrl.Value.Trim.Length > 0 Then
                                        If File.Exists(nmFile) Then
                                            File.Delete(nmFile)
                                        End If
                                        txtFileUrl.PostedFile.SaveAs(nmFile)
                                    End If
                                Catch ex As Exception
                                    commonFunction.MsgBox(Me, "Upload File tidak berhasil.")
                                    Exit Sub
                                End Try
                            Else
                                .fileName = String.Empty
                                .fileExtension = String.Empty
                            End If

                            If isNew Then
                                If .Insert() Then SOI_txtSummaryOfInspectionID.Text = .summaryOfInspectionID.Trim
                                PrepareScreen(_VisiblePanelID.Trim, True)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, False)
                            End If
                        End With
                    Else
                        '// Upload
                        Dim MyConnection As System.Data.OleDb.OleDbConnection

                        If Len(SOI_txtSheetName.Text.Trim) = 0 Then
                            commonFunction.MsgBox(Me, "Sheet Name harus diisi.")
                            Exit Sub
                        End If

                        Dim strFileFolder As String = Common.Methods.GetCommonCode("SOIUPLDIR", "FILEDIR").Trim
                        Dim strFileName As String = Path.GetFileName(SOI_File.Value.Trim).Trim
                        Dim strFilePath As String = String.Empty

                        strFilePath = strFileFolder + strFileName

                        If (Not File.Exists(strFilePath)) Then
                            commonFunction.MsgBox(Me, "Upload Failed. File " + strFileName.Trim + " doesn't exist.")
                            Exit Sub
                        End If

                        Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
                        Dim b(CInt(fs.Length)) As Byte
                        fs.Read(b, 0, CInt(fs.Length))
                        fs.Close()

                        Try
                            '// Fetch Data from Excel
                            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                            Dim DtSet As System.Data.DataSet

                            'MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & strFilePath & " '; " & "Extended Properties=Excel 12.0;")
                            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & strFilePath & " '; " & "Extended Properties=Excel 8.0;")
                            MyCommand = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + SOI_txtSheetName.Text.Trim + "$]", MyConnection)

                            DtSet = New System.Data.DataSet

                            MyCommand.Fill(DtSet, "[" + SOI_txtSheetName.Text.Trim + "$]")

                            '// -------------------------------------------------------------------------------
                            Dim iRecCount As Integer = 0
                            While DtSet.Tables(0).Rows.Count > iRecCount
                                With oBR
                                    .projectID = txtProjectID.Text.Trim
                                    If (DtSet.Tables(0).Rows(iRecCount)(0)) Is System.DBNull.Value Then
                                        .sequenceNo = "0"
                                    Else
                                        .sequenceNo = CType(DtSet.Tables(0).Rows(iRecCount)(0), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(1)) Is System.DBNull.Value Then
                                        .descriptionOfEquipment = String.Empty
                                    Else
                                        .descriptionOfEquipment = CType(DtSet.Tables(0).Rows(iRecCount)(1), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(2)) Is System.DBNull.Value Then
                                        .serialIDNo = String.Empty
                                    Else
                                        .serialIDNo = CType(DtSet.Tables(0).Rows(iRecCount)(2), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(3)) Is System.DBNull.Value Then
                                        .location = String.Empty
                                    Else
                                        .location = CType(DtSet.Tables(0).Rows(iRecCount)(3), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(4)) Is System.DBNull.Value Then
                                        .manufacture = String.Empty
                                    Else
                                        .manufacture = CType(DtSet.Tables(0).Rows(iRecCount)(4), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(5)) Is System.DBNull.Value Then
                                        .SWL_WWL_MGW = String.Empty
                                    Else
                                        .SWL_WWL_MGW = CType(DtSet.Tables(0).Rows(iRecCount)(5), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(6)) Is System.DBNull.Value Then
                                        .dimensional = String.Empty
                                    Else
                                        .dimensional = CType(DtSet.Tables(0).Rows(iRecCount)(6), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(7)) Is System.DBNull.Value Then
                                        .defectFound = String.Empty
                                    Else
                                        .defectFound = CType(DtSet.Tables(0).Rows(iRecCount)(7), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(8)) Is System.DBNull.Value Then
                                        .result = String.Empty
                                    Else
                                        .result = CType(DtSet.Tables(0).Rows(iRecCount)(8), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(9)) Is System.DBNull.Value Then
                                        Throw New Exception("Kolom Exam_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                    Else
                                        Dim strDate As String
                                        strDate = CType(DtSet.Tables(0).Rows(iRecCount)(9), String)

                                        Try
                                            .examDate = DateSerial(Convert.ToInt32(strDate.Substring(6, 4)), Convert.ToInt32(strDate.Substring(3, 2)), Convert.ToInt32(strDate.Substring(0, 2)))
                                        Catch
                                            Throw New Exception("Kolom Exam_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                        End Try
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(10)) Is System.DBNull.Value Then
                                        Throw New Exception("Kolom Expire_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                    Else
                                        Dim strDate As String
                                        strDate = CType(DtSet.Tables(0).Rows(iRecCount)(10), String)

                                        Try
                                            .expireDate = DateSerial(Convert.ToInt32(strDate.Substring(6, 4)), Convert.ToInt32(strDate.Substring(3, 2)), Convert.ToInt32(strDate.Substring(0, 2)))
                                        Catch
                                            Throw New Exception("Kolom Expire_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                        End Try
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(11)) Is System.DBNull.Value Then
                                        .reportNo = String.Empty
                                    Else
                                        .reportNo = CType(DtSet.Tables(0).Rows(iRecCount)(11), String)
                                    End If

                                    .typeOfInspectionSCode = String.Empty

                                    If (DtSet.Tables(0).Rows(iRecCount)(12)) Is System.DBNull.Value Then
                                        .isToiV = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(12), String) = "Yes" Then
                                            .isToiV = True
                                        Else
                                            .isToiV = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(13)) Is System.DBNull.Value Then
                                        .isToiN = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(13), String) = "Yes" Then
                                            .isToiN = True
                                        Else
                                            .isToiN = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(14)) Is System.DBNull.Value Then
                                        .isToiT = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(14), String) = "Yes" Then
                                            .isToiT = True
                                        Else
                                            .isToiT = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(15)) Is System.DBNull.Value Then
                                        .interval = String.Empty
                                    Else
                                        .interval = CType(DtSet.Tables(0).Rows(iRecCount)(15), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(16)) Is System.DBNull.Value Then
                                        .remarks = String.Empty
                                    Else
                                        .remarks = CType(DtSet.Tables(0).Rows(iRecCount)(16), String)
                                    End If

                                    .detailReportSection = ""
                                    .userIDinsert = MyBase.LoggedOnUserID
                                    .userIDupdate = MyBase.LoggedOnUserID

                                    If (DtSet.Tables(0).Rows(iRecCount)(17)) Is System.DBNull.Value Then
                                        .fileName = String.Empty
                                        .fileExtension = String.Empty
                                    Else
                                        Dim strFileURL As String = (DtSet.Tables(0).Rows(iRecCount)(17)).ToString.Trim
                                        If strFileURL.Trim.Length > 0 Then
                                            Dim fileExt As String, fileName As String
                                            SOI_FileDetail.Value = strFileURL.Trim
                                            fileExt = Path.GetExtension(SOI_FileDetail.Value.Trim)
                                            fileName = Common.BussinessRules.ID.GenerateIDNumber("SummaryOfInspection", "summaryOfInspectionID") + fileExt.Trim
                                            Dim Pathdb As String = Common.Methods.GetCommonCode("SOIDIR", "FILEDIR").Trim
                                            Dim fNotNew As Boolean = False
                                            Dim nmFile As String
                                            Try
                                                .fileName = fileName.Trim
                                                .fileExtension = fileExt.Trim

                                                '// validate if the file exist
                                                nmFile = Pathdb + fileName
                                                If txtFileUrl.Value.Trim.Length > 0 Then
                                                    If File.Exists(nmFile) Then
                                                        File.Delete(nmFile)
                                                    End If
                                                    SOI_FileDetail.PostedFile.SaveAs(nmFile)
                                                End If
                                            Catch ex As Exception
                                                commonFunction.MsgBox(Me, "Upload File tidak berhasil.")
                                                Exit Sub
                                            End Try
                                        Else
                                            .fileName = String.Empty
                                            .fileExtension = String.Empty
                                        End If
                                    End If

                                    .Insert()
                                    iRecCount = iRecCount + 1
                                End With
                            End While
                        Catch ex As Exception
                            MyConnection.Close()
                            Throw ex
                        End Try

                        PrepareScreen(_VisiblePanelID.Trim, True)
                    End If
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    With oBR
                        .CCRID = CCR_txtCCRID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .sequenceNo = CCR_txtSequenceNo.Text.Trim
                        .description = CCR_txtDescription.Text.Trim
                        .typeOfReportSCode = CCR_ddlTypeOfReport.SelectedValue.Trim
                        .preparedBy = CCR_txtPreparedByName.Text.Trim
                        .preparedDate = CCR_calPreparedDate.selectedDate
                        .reportNo = CCR_txtReportNo.Text.Trim
                        .remarks = CCR_txtRemarks.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then CCR_txtCCRID.Text = .CCRID
                            PrepareScreen(_VisiblePanelID.Trim, True)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.TimeSheet
                    With oBR
                        If TS_chkIsAll.Checked Then
                            For Each repItemHd As RepeaterItem In repDateInMonthHd.Items
                                Dim TS_lblDateInMonthHd As Label = CType(repItemHd.FindControl("TS_lblDateInMonthHd"), Label)
                                Dim TS_ddlWorkingTypeAll As DropDownList = CType(repItemHd.FindControl("TS_ddlWorkingTypeAll"), DropDownList)

                                For Each lvwItem As ListViewItem In lvwTimeSheet.Items
                                    Dim _repDateInMonthDt As Repeater = CType(lvwItem.FindControl("repDateInMonthDt"), Repeater)

                                    For Each repItem As RepeaterItem In _repDateInMonthDt.Items
                                        Dim TS_lblDateInMonthDt As Label = CType(repItem.FindControl("TS_lblDateInMonthDt"), Label)
                                        Dim TS_lblTimeSheetID As Label = CType(repItem.FindControl("TS_lblTimeSheetID"), Label)
                                        Dim TS_lblProjectResourceID As Label = CType(repItem.FindControl("TS_lblProjectResourceID"), Label)
                                        Dim TS_chkIsNew As CheckBox = CType(repItem.FindControl("TS_chkIsNew"), CheckBox)

                                        If TS_lblDateInMonthDt.Text.Trim = TS_lblDateInMonthHd.Text.Trim Then
                                            .timeSheetID = TS_lblTimeSheetID.Text.Trim
                                            .projectResourceID = TS_lblProjectResourceID.Text.Trim
                                            .workingDate = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text))
                                            .workingTypeSCode = TS_ddlWorkingTypeAll.SelectedValue
                                            .remarks = ""
                                            .userIDinsert = MyBase.LoggedOnUserID.Trim
                                            .userIDupdate = MyBase.LoggedOnUserID.Trim

                                            If TS_chkIsNew.Checked = False Then
                                                If .workingTypeSCode <> "" Then
                                                    .Update()
                                                End If                                                
                                            Else
                                                If .workingTypeSCode <> "" Then
                                                    .Insert()
                                                End If
                                            End If
                                        End If                                    
                                    Next
                                Next
                            Next
                        Else
                            For Each lvwItem As ListViewItem In lvwTimeSheet.Items
                                Dim _repDateInMonthDt As Repeater = CType(lvwItem.FindControl("repDateInMonthDt"), Repeater)

                                For Each repItem As RepeaterItem In _repDateInMonthDt.Items
                                    Dim TS_lblDateInMonthDt As Label = CType(repItem.FindControl("TS_lblDateInMonthDt"), Label)
                                    Dim TS_lblTimeSheetID As Label = CType(repItem.FindControl("TS_lblTimeSheetID"), Label)
                                    Dim TS_lblProjectResourceID As Label = CType(repItem.FindControl("TS_lblProjectResourceID"), Label)
                                    Dim TS_ddlWorkingType As DropDownList = CType(repItem.FindControl("TS_ddlWorkingType"), DropDownList)
                                    Dim TS_chkIsNew As CheckBox = CType(repItem.FindControl("TS_chkIsNew"), CheckBox)

                                    .timeSheetID = TS_lblTimeSheetID.Text.Trim
                                    .projectResourceID = TS_lblProjectResourceID.Text.Trim
                                    .workingDate = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text))
                                    .workingTypeSCode = TS_ddlWorkingType.SelectedValue
                                    .remarks = ""
                                    .userIDinsert = MyBase.LoggedOnUserID.Trim
                                    .userIDupdate = MyBase.LoggedOnUserID.Trim

                                    If TS_chkIsNew.Checked = False Then
                                        .Update()
                                    Else
                                        If .workingTypeSCode <> "" Then
                                            .Insert()
                                        End If
                                    End If
                                Next
                            Next
                        End If                        
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = ""
                        .remarks = DPR_txtDescription.Text.Trim
                        .reportDate = DPR_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DPR_txtDailyReportHdID.Text = .dailyReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DPR_txtDailyReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        .sequenceNo = DPR_txtSequenceNo.Text.Trim
                        .weatherConditionSCode = DPR_ddlWeatherCondition.SelectedValue
                        .description = DPR_txtDescription.Text.Trim
                        .currentQty = CDec(DPR_txtQtyCurrent.Text.Trim)
                        .beginningQty = CDec(DPR_txtQtyPrevious.Text.Trim)
                        .endingQty = .beginningQty + .currentQty
                        .result = ""
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DPR_txtDailyReportDtID.Text = .dailyReportDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.DailyInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = ""
                        .remarks = DIR_txtDescription.Text.Trim
                        .reportDate = DIR_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DIR_txtDailyReportHdID.Text = .dailyReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DIR_txtDailyReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        .sequenceNo = DIR_txtSequenceNo.Text.Trim
                        .weatherConditionSCode = DIR_ddlWeatherCondition.SelectedValue
                        .description = DIR_txtDescription.Text.Trim
                        .currentQty = CDec(DIR_txtQty.Text.Trim)
                        .beginningQty = 0D
                        .endingQty = 0D + .currentQty
                        .result = DIR_txtResult.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DIR_txtDailyReportDtID.Text = .dailyReportDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DrillPipeReportHd
                    With oHd
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .inspectionSpecID = DP_txtSpecificationID.Text.Trim
                        .reportNo = DP_txtReportNo.Text.Trim
                        .reportDate = DP_calReportDate.selectedDate
                        .remarks = ""
                        .size = DP_txtSize.Text.Trim
                        .weight = DP_txtWeight.Text.Trim
                        .grade = DP_txtGrade.Text.Trim
                        .connection = DP_txtConnection.Text.Trim
                        .range = DP_txtRange.Text.Trim
                        .nominalWT = DP_txtNominalWT.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DP_txtDrillPipeReportHdID.Text = .drillPipeReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DrillPipeReportDt
                    With oDt
                        .drillPipeReportDtID = DP_txtDrillPipeReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        .sequenceNo = DP_txtSequenceNo.Text.Trim
                        .serialNo = DP_txtSerialNo.Text.Trim
                        .remarks = DP_txtRemarks.Text.Trim
                        .bdBodyWear = DP_txtbdBodyWear.Text.Trim
                        .bdBent = DP_txtbdBent.Text.Trim
                        .bdBodyDamage = DP_txtbdBodyDamage.Text.Trim
                        .bdEMI = DP_txtbdEMI.Text.Trim
                        .bdUTEndArea = DP_txtbdUTEndArea.Text.Trim
                        .bdPlasticCoating = DP_txtbdPlasticCoating.Text.Trim
                        .bdWall = DP_txtbdWall.Text.Trim
                        .bdWallRemanent = DP_txtbdWallRemanent.Text.Trim
                        .bdTubeClass = DP_txtbdTubeClass.Text.Trim
                        .pcToolJointYear = DP_txtpcToolJointYear.Text.Trim
                        .pcOutsideDia = DP_txtpcOutsideDia.Text.Trim
                        .pcInsideDia = DP_txtpcInsideDia.Text.Trim
                        .pcTongSpace = DP_txtpcTongSpace.Text.Trim
                        .pcThreadLength = DP_txtpcThreadLength.Text.Trim
                        .pcBevelDia = DP_txtpcBevelDia.Text.Trim
                        .pcLead = DP_txtpcLead.Text.Trim
                        .pcShoulderWidth = DP_txtpcShoulderWidth.Text.Trim
                        .pcNeckLength = DP_txtpcNeckLength.Text.Trim
                        .pcReface = DP_txtpcReface.Text.Trim
                        .pcFinalCondition = DP_txtpcFinalCondition.Text.Trim
                        .bcOutsideDia = DP_txtbcOutsideDia.Text.Trim
                        .bcTongSpace = DP_txtbcTongSpace.Text.Trim
                        .bcQCDia = DP_txtbcQCDia.Text.Trim
                        .bcQCDepth = DP_txtbcQCDepth.Text.Trim
                        .bcShoulderWidth = DP_txtbcShoulderWidth.Text.Trim
                        .bcBevelDia = DP_txtbcBevelDia.Text.Trim
                        .bcSealWidth = DP_txtbcSealWidth.Text.Trim
                        .bcReface = DP_txtbcReface.Text.Trim
                        .bcFinalCondition = DP_txtbcFinalCondition.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If Len(DP_txtSerialNo.Text.Trim) > 0 Then
                                If .Insert() Then DP_txtDrillPipeReportDtID.Text = .drillPipeReportDtID
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            End If
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oBR As New Common.BussinessRules.ServiceReport
                    With oBR
                        .serviceReportID = SR_txtServiceReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .serviceReportForSCode = SR_ddlServiceReportFor.SelectedValue.Trim
                        .serviceReportDate = SR_calServiceReportDate.selectedDate
                        .projectID = txtProjectID.Text.Trim
                        .typeOfInspection = SR_txtTypeOfInspection.Text.Trim
                        .mdManufacturer = SR_txtManufacturer.Text.Trim
                        .mdTypeOfPipe = SR_txtTypeOfPipe.Text.Trim
                        .mdPipeOD = SR_txtPipeOD.Text.Trim
                        .mdPipeGrade = SR_txtPipeGrade.Text.Trim
                        .mdPipeWeight = SR_txtPipeWeight.Text.Trim
                        .mdThreadConnection = SR_txtThreadConnection.Text.Trim
                        .mdRange = SR_txtRange.Text.Trim
                        .mdTotalInspected = SR_txtTotalInspected.Text.Trim
                        .mdTotalAccepted = SR_txtTotalAccepted.Text.Trim
                        .mdNotes = SR_txtMaterialDescription.Text.Trim
                        .result = SR_txtResult.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID

                        If isNew Then
                            If .Insert() Then SR_txtServiceReportID.Text = .serviceReportID.Trim
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, True)
                        Else
                            .Update()
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    With oBR
                        .certificateInspectionID = COI_txtCertificateInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .certificateNo = COI_txtCertificateNo.Text.Trim
                        .certificateDate = COI_calCertificateDate.selectedDate
                        .owner = COI_txtOwner.Text.Trim
                        .userLabel = COI_txtUser.Text.Trim
                        .location = COI_txtLocation.Text.Trim
                        .description = COI_txtDescription.Text.Trim
                        .serialNo = COI_txtSerialNo.Text.Trim
                        .maxGrossWeightR = COI_txtMaxGossWeightR.Text.Trim
                        .loadTest = COI_txtLoadTest.Text.Trim
                        .duration = COI_txtDuration.Text.Trim
                        .specification = COI_txtSpecification.Text.Trim
                        .examination = COI_txtExamination.Text.Trim
                        .result = COI_txtResult.Text.Trim
                        .inspectionDate = COI_caInspectionDate.selectedDate
                        .expiredDate = COI_calExpiredDate.selectedDate
                        .notes = COI_txtNotes.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then COI_txtCertificateInspectionID.Text = .certificateInspectionID
                            PrepareScreen(_VisiblePanelID.Trim, True)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    Dim oBR As New Common.BussinessRules.MPIHd
                    With oBR
                        .MPIHdID = MPI_txtMPIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .MPITypeSCode = MPI_ddlMPIType.SelectedValue.Trim
                        .reportDate = MPI_calReportDate.selectedDate
                        .reportNo = MPI_txtReportNo.Text.Trim
                        .serialNo = MPI_txtSerialNo.Text.Trim
                        .expiredDate = MPI_calExpiredDate.selectedDate
                        .description = MPI_txtDescription.Text.Trim
                        .ACIsASME = MPI_chkACIsASME.Checked
                        .ACIsAPISpec = MPI_chkACIsAPISpec.Checked
                        .ACIsDS1 = MPI_chkIsACDS1.Checked
                        .ACIsOther = MPI_chkIsACOther.Checked
                        .ACOtherDescription = MPI_txtACOtherDescription.Text.Trim
                        .qty = MPI_txtQty.Text.Trim
                        .dimension = MPI_txtDimension.Text.Trim
                        .areaInspection = MPI_txtAreaInspection.Text.Trim
                        .material = MPI_txtMaterial.Text.Trim
                        .application = MPI_txtApplication.Text.Trim
                        .surfaceCondition = MPI_txtSurfaceCondition.Text.Trim
                        .contrast = MPI_txtContrast.Text.Trim
                        .metalSurfaceTemp = MPI_txtMetalSurfaceTemp.Text.Trim
                        .magneticParticle = MPI_txtMagneticParticle.Text.Trim
                        .materialThickness = MPI_txtMaterialThickness.Text.Trim
                        .cleaner = MPI_txtCleaner.Text.Trim
                        .setCalibration = MPI_txtSetCalibration.Text.Trim
                        .penetrant = MPI_txtPenetrant.Text.Trim
                        .poleSpacing = MPI_txtPoleSpacing.Text.Trim
                        .developer = MPI_txtDeveloper.Text.Trim
                        .yokeSCode = MPI_rbtnlYoke.SelectedValue.Trim
                        .coilSCode = MPI_rbtnlCoil.SelectedValue.Trim
                        .isBlacklight = MPI_chkIsBlacklight.Checked
                        .isRods = MPI_chkIsRods.Checked
                        .fluorescentSCode = MPI_rbtnlFluorescent.SelectedValue.Trim
                        .contrastBWSCode = MPI_rbtnlContrastBW.SelectedValue.Trim
                        .isDyePenetrant = MPI_chkIsDyePenetrant.Checked
                        .isWireBrush = MPI_chkIsWireBrush.Checked
                        .isBlastCleaning = MPI_chkIsBlastCleaning.Checked
                        .isGrinding = MPI_chkIsGrinding.Checked
                        .isMachining = MPI_chkIsMachining.Checked
                        .inspectionResult = MPI_txtInspectionResult.Text.Trim
                        .notes = MPI_txtNotes.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then MPI_txtMPIHdID.Text = .MPIHdID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = UTSC_txtReportNo.Text.Trim
                        .reportDate = UTSC_calReportDate.selectedDate
                        .nominalWT = UTSC_txtNominalWT.Text.Trim
                        .minimalWT = UTSC_txtMinimalWT.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then UTSC_txtUTSpotCheckHdID.Text = .UTSpotCheckHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.UTSpotCheckDt
                    With oDt
                        .UTSpotCheckDtID = UTSC_txtUTSpotCheckDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                        .tallyNo = UTSC_txtTallyNo.Text.Trim
                        .location = UTSC_txtLocation.Text.Trim
                        .wallThicknessInch1 = CDec(IIf(IsNumeric(UTSC_txtWallThicknessInch1.Text.Trim), UTSC_txtWallThicknessInch1.Text.Trim, 0))
                        .wallThicknessInch2 = CDec(IIf(IsNumeric(UTSC_txtWallThicknessInch2.Text.Trim), UTSC_txtWallThicknessInch2.Text.Trim, 0))
                        .wallThicknessInch3 = CDec(IIf(IsNumeric(UTSC_txtWallThicknessInch3.Text.Trim), UTSC_txtWallThicknessInch3.Text.Trim, 0))
                        .remark = UTSC_txtRemark.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then UTSC_txtUTSpotCheckDtID.Text = .UTSpotCheckDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oHd As New Common.BussinessRules.HardnessTestHd
                    With oHd
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = HT_txtReportNo.Text.Trim
                        .reportDate = HT_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then HT_txtHardnessTestHdID.Text = .hardnessTestHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.HardnessTestDt
                    With oDt
                        .hardnessTestDtID = HT_txtHardnessTestDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        .pipeNo = HT_txtPipeNo.Text.Trim
                        .locationSCode = HT_ddlLocation.SelectedValue.Trim
                        .HRB1 = CDec(IIf(IsNumeric(HT_txtHRB1.Text.Trim), HT_txtHRB1.Text.Trim, 0))
                        .HRB2 = CDec(IIf(IsNumeric(HT_txtHRB2.Text.Trim), HT_txtHRB2.Text.Trim, 0))
                        .HRB3 = CDec(IIf(IsNumeric(HT_txtHRB3.Text.Trim), HT_txtHRB3.Text.Trim, 0))
                        .HRB4 = CDec(IIf(IsNumeric(HT_txtHRB4.Text.Trim), HT_txtHRB4.Text.Trim, 0))
                        .HRBAvg = (CDec(IIf(IsNumeric(HT_txtHRB1.Text.Trim), HT_txtHRB1.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB2.Text.Trim), HT_txtHRB2.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB3.Text.Trim), HT_txtHRB3.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB4.Text.Trim), HT_txtHRB4.Text.Trim, 0))) / 4
                        .HB1 = CDec(IIf(IsNumeric(HT_txtHB1.Text.Trim), HT_txtHB1.Text.Trim, 0))
                        .HB2 = CDec(IIf(IsNumeric(HT_txtHB2.Text.Trim), HT_txtHB2.Text.Trim, 0))
                        .HB3 = CDec(IIf(IsNumeric(HT_txtHB3.Text.Trim), HT_txtHB3.Text.Trim, 0))
                        .HB4 = CDec(IIf(IsNumeric(HT_txtHB4.Text.Trim), HT_txtHB4.Text.Trim, 0))
                        .HBAvg = (CDec(IIf(IsNumeric(HT_txtHB1.Text.Trim), HT_txtHB1.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB2.Text.Trim), HT_txtHB2.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB3.Text.Trim), HT_txtHB3.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB4.Text.Trim), HT_txtHB4.Text.Trim, 0))) / 4
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then HT_txtHardnessTestDtID.Text = .hardnessTestDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)
            End Select
        End Sub

        Private Sub _delete(ByVal _VisiblePanelID As String, ByVal _IDtoDelete As String)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.SummaryOfInspection
                    With oBr
                        .summaryOfInspectionID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.CertificateInspection
                    With oBr
                        .certificateInspectionID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oBr As New Common.BussinessRules.UTSpotCheckDt
                    With oBr
                        .UTSpotCheckDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oBr As New Common.BussinessRules.HardnessTestDt
                    With oBr
                        .hardnessTestDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing
            End Select
        End Sub
#End Region

    End Class

End Namespace